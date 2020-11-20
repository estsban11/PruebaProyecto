using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectionManager
    {
        public SqlConnection _connection;

        public ConnectionManager(string connection)
        {
            _connection = new SqlConnection(connection);
        }

        public void Open()
        {
            _connection.Open();
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}
