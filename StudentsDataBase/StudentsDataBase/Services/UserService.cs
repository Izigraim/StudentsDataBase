using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void RegistrationUser(string firstName, string lastName, string thirdName, string passportSeria, int passportNumber, string issuedBy, string date5, string identNumber,
            int sex, string house, int housing, string flat, int zipCode, long phoneNumber, string email, string region, string district, int townType, string town,
            int streetType, string street, string login, string password)
        {
            using (this.mySqlConnection)
            {
                string command = $"call students.registration_procedure('{firstName}', '{lastName}', '{thirdName}', '{passportSeria}', {passportNumber}," +
                    $" '{issuedBy}', '{date5}', '{identNumber}', {sex}, '{house}', {housing}, '{flat}', {zipCode}, {phoneNumber}, '{email}', '{region}'," +
                    $" '{district}', {townType}, '{town}', {streetType}, '{street}', '{login}', '{password}', 2, 1);";

                this.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, this.mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
            }
        }

        public bool IsUserExists(string login)
        {
            using (this.mySqlConnection)
            {
                string command = $"select students.user.id from students.user where students.user.login = {login}";

                this.mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, this.mySqlConnection);
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                if (dataTable.AsEnumerable().ToArray()[0].ItemArray[0].ToString() != null || dataTable.AsEnumerable().ToArray()[0].ItemArray[0].ToString().Length != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
