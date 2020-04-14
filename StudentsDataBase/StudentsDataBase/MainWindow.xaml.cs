using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentsDataBase.SqlConnection;
using StudentsDataBase.Services;
using StudentsDataBase.Validation;

namespace StudentsDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserService userService;

        public MainWindow()
        {
            this.userService = new UserService(new DBConnection().MySqlConnection);

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    if (loginTextBox.Text.Length == 0)
                    {
                        throw new ArgumentException("Логин не может быть пустым.");
                    }
                    else if (!this.userService.IsUserExists(loginTextBox.Text))
                    {
                        throw new ArgumentException("Пользователь с таким логином не существует.");
                    }
                }
                catch (IndexOutOfRangeException)
                {

                }

                UserValidation.LoginValidation(loginTextBox.Text, passwordTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                string statusString = this.userService.AuthorizationUser(loginTextBox.Text, passwordTextBox.Text);

                if (statusString == "Blocked")
                {
                    MessageBox.Show("Пользователь заблокирован.");
                    return;
                }
                else if (statusString == "Deleted")
                {
                    MessageBox.Show("Пользователь заблокирован.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный пароль.");
                return;
            }

            loginTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            this.Hide();

            LoginedWindows loginedWindows = new LoginedWindows(this.userService, this);
            loginedWindows.Show();
        }

        private void SugnUpButton_Click(object sender, RoutedEventArgs e)
        {
            loginTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;

            this.Hide();

            RegistrationWindows registrationWindows = new RegistrationWindows(userService, this);
            registrationWindows.Show();
        }
    }
}
