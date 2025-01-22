using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Axl_Nunez.Servicers
{
    public class UserService
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public bool Authenticate(string username, string password)
        {
            using (var connection = _dbHelper.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM user WHERE userName = @username AND password = @password AND active = 1";
                    AddParameter(command, "@username", DbType.String, username);
                    AddParameter(command, "@password", DbType.String, password);

                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        public void LogLogin(string username)
        {
            string logEntry = $"{DateTime.Now:G} - User: {username}\n";
            System.IO.File.AppendAllText("Login_History.txt", logEntry);
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
