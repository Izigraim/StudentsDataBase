using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataBase.Services
{
    public class UserService
    {
        private readonly MySqlConnection mySqlConnection;

        public UserService(MySqlConnection mySqlConnection)
        {
            this.mySqlConnection = mySqlConnection;
        }

        public void RegistrationUser(string firstName, string lastName, string thirdName, string login, string password, int role, int status)
        {
            using (this.mySqlConnection)
            {
                string command = $"call students.registration_procedure('{firstName}' ,'{lastName}' ,'{thirdName}', '{login}', '{password}', {role}, {status});";

                this.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, this.mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }
    }
}
