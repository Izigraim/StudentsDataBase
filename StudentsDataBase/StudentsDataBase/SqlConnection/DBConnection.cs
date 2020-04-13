using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataBase.SqlConnection
{
    public class DBConnection
    {
        private const string connection = "datasource=127.0.0.1;port=3306;username=student;password=student;database=students";

        public DBConnection()
        {
            this.MySqlConnection = new MySqlConnection(connection);
        }

        public MySqlConnection MySqlConnection { get; private set; }

    }
}
