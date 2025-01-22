using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Axl_Nunez.Servicers
{
    public class CustomerService
    {
        private readonly DatabaseHelper _dbHelper = new DatabaseHelper();

        public DataTable GetAllCustomers()
        {
            using (var connection = _dbHelper.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    SELECT customer.customerId, customer.customerName, address.address, address.phone
                    FROM customer
                    INNER JOIN address ON customer.addressId = address.addressId";

                    using (var adapter = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateDataAdapter())
                    {
                        if (adapter == null) throw new InvalidOperationException("Failed to create data adapter.");
                        adapter.SelectCommand = command;
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public void AddCustomer(string name, string address, string phone)
        {
            using (var connection = _dbHelper.GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy) VALUES (@name, @address, 1, NOW(), 'system')";
                    AddParameter(command, "@name", DbType.String, name);
                    AddParameter(command, "@address", DbType.String, address);
                    AddParameter(command, "@phone", DbType.String, phone);

                    command.ExecuteNonQuery();
                }
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
