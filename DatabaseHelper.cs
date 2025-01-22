using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C969___Axl_Nunez
{
    public class DatabaseHelper
    {
        private const string ConnectionString = "Server=localhost;Database=scheduling;User ID=test;Password=test;";

        public DbConnection GetConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
            DbConnection connection = factory.CreateConnection();
            if (connection == null) throw new InvalidOperationException("Failed to create a database connection.");
            connection.ConnectionString = ConnectionString;
            return connection;
        }
    }
}
