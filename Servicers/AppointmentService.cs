using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Axl_Nunez.Servicers
{
    public class AppointmentService
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public void AddAppointment(int customerId, int userId, string title, DateTime start, DateTime end)
        {
            using (var connection = _dbHelper.GetConnection())
            {
                connection.Open();
                ValidateAppointment(customerId, start, end, connection);

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO appointment (customerId, userId, title, start, end, createDate, createdBy)
                    VALUES (@customerId, @userId, @title, @start, @end, NOW(), 'system')";
                    AddParameter(command, "@customerId", DbType.Int32, customerId);
                    AddParameter(command, "@userId", DbType.Int32, userId);
                    AddParameter(command, "@title", DbType.String, title);
                    AddParameter(command, "@start", DbType.DateTime, start);
                    AddParameter(command, "@end", DbType.DateTime, end);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void ValidateAppointment(int customerId, DateTime start, DateTime end, DbConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId AND (start < @end AND end > @start)";
                AddParameter(command, "@customerId", DbType.Int32, customerId);
                AddParameter(command, "@start", DbType.DateTime, start);
                AddParameter(command, "@end", DbType.DateTime, end);

                if (Convert.ToInt32(command.ExecuteScalar()) > 0)
                    throw new ArgumentException("Overlapping appointments are not allowed.");
            }
        }

        private void AddParameter(DbCommand command, string name, DbType type, object value)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = type;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}
