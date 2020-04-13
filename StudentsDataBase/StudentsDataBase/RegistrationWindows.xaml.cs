﻿using StudentsDataBase.Services;
using StudentsDataBase.SqlConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentsDataBase.Validation;

namespace StudentsDataBase
{
    /// <summary>
    /// Interaction logic for RegistrationWindows.xaml
    /// </summary>
    public partial class RegistrationWindows : Window
    {
        private readonly UserService userService;

        public RegistrationWindows()
        {
            this.userService = new UserService(new DBConnection().MySqlConnection);

            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.userService.IsUserExists(loginTextBox.Text))
                {
                    throw new ArgumentException("Пользователь с таким логином уже существует.");
                }

                UserValidation.RegistrationValidation(name1TextBox.Text, name2TextBox.Text, name3TextBox.Text, passportSeriaTextBox.Text, passportNumberTextBox.Text, issuedByTextBox.Text,
                    date5TextBox.Text, identNumberTextBox.Text, sexComboBox.SelectedIndex + 1, houseTextBox.Text, housingTextBox.Text, flatTextBox.Text, zipCodeTextBox.Text, phoneNumberTextBox.Text,
                    emailTextBox.Text, regionTextBox.Text, districtTextBox.Text, townTypeComboBox.SelectedIndex + 1, townTextBox.Text, streetTypeComboBox.SelectedIndex + 1,
                    streetTextBox.Text, loginTextBox.Text, passwordTextBox.Text);

                if (housingTextBox.Text.Length == 0)
                {
                    housingTextBox.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                this.userService.RegistrationUser(name1TextBox.Text, name2TextBox.Text, name3TextBox.Text, passportSeriaTextBox.Text, Convert.ToInt32(passportNumberTextBox.Text), issuedByTextBox.Text,
                date5TextBox.Text, identNumberTextBox.Text, sexComboBox.SelectedIndex + 1, houseTextBox.Text, Convert.ToInt32(housingTextBox.Text), flatTextBox.Text, Convert.ToInt32(zipCodeTextBox.Text), Convert.ToInt64(phoneNumberTextBox.Text),
                emailTextBox.Text, regionTextBox.Text, districtTextBox.Text, townTypeComboBox.SelectedIndex + 1, townTextBox.Text, streetTypeComboBox.SelectedIndex + 1,
                streetTextBox.Text, loginTextBox.Text, passwordTextBox.Text);
            }
            catch (Exception)
            {

            }
        }
    }
}
