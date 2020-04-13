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
        public DBConnection(string mySqlConnection)
        {
            this.MySqlConnection = new MySqlConnection(mySqlConnection);
        }

        public MySqlConnection MySqlConnection { get; private set; }

    }
}
