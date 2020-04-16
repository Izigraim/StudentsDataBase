using StudentsDataBase.Services;
using StudentsDataBase.Validation;
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

namespace StudentsDataBase
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private readonly UserService userService;
        private readonly MainWindow mainWindow;
        private readonly List<string> currentUserInfo;

        public UpdateWindow(UserService userService, MainWindow mainWindow)
        {
            this.userService = userService;
            this.mainWindow = mainWindow;
            this.currentUserInfo = this.userService.GetCurrentuserInfo(this.userService.AuthorizedUser);

            InitializeComponent();

            mainLabel.Content += userService.AuthorizedUser;
            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            name1TextBox.Text = currentUserInfo[0];
            name2TextBox.Text = currentUserInfo[1];
            name3TextBox.Text = currentUserInfo[2];
            passportSeriaTextBox.Text = currentUserInfo[3];
            passportNumberTextBox.Text = currentUserInfo[4];
            issuedByTextBox.Text = currentUserInfo[5];
            date5TextBox.Text = GetDateFormat(currentUserInfo[6]);
            identNumberTextBox.Text = currentUserInfo[7];
            if (currentUserInfo[8] == "м")
            {
                sexComboBox.SelectedIndex = 0;
            }
            else
            {
                sexComboBox.SelectedIndex = 1;
            }
            houseTextBox.Text = currentUserInfo[9];
            housingTextBox.Text = currentUserInfo[10];
            flatTextBox.Text = currentUserInfo[11];
            zipCodeTextBox.Text = currentUserInfo[12];
            phoneNumberTextBox.Text = currentUserInfo[13];
            emailTextBox.Text = currentUserInfo[14];
            regionTextBox.Text = currentUserInfo[15];
            districtTextBox.Text = currentUserInfo[16];
            if (currentUserInfo[17] == "Город")
            {
                townTypeComboBox.SelectedIndex = 0;
            }
            else if (currentUserInfo[17] == "Поселок")
            {
                townTypeComboBox.SelectedIndex = 1;
            }
            else if (currentUserInfo[17] == "Населенный пункт")
            {
                townTypeComboBox.SelectedIndex = 2;
            }
            else
            {
                townTypeComboBox.SelectedIndex = 3;
            }
            townTextBox.Text = currentUserInfo[18];
            if (currentUserInfo[19] == "Проспект")
            {
                streetTypeComboBox.SelectedIndex = 0;
            }
            else if (currentUserInfo[19] == "Переулок")
            {
                streetTypeComboBox.SelectedIndex = 1;
            }
            else if (currentUserInfo[19] == "Площадь")
            {
                streetTypeComboBox.SelectedIndex = 2;
            }
            else if (currentUserInfo[19] == "Улица")
            {
                streetTypeComboBox.SelectedIndex = 3;
            }
            else
            {
                streetTypeComboBox.SelectedIndex = 4;
            }
            streetTextBox.Text = currentUserInfo[20];
        }

        private string GetDateFormat(string date5)
        {
            string[] yearMonthDay = date5.Split(' ')[0].Split('.');
            
            return yearMonthDay[2] + "-" + yearMonthDay[1] + "-" + yearMonthDay[0];
        }

        private void updateClick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserValidation.RegistrationValidation(name1TextBox.Text, name2TextBox.Text, name3TextBox.Text, passportSeriaTextBox.Text, passportNumberTextBox.Text, issuedByTextBox.Text,
                    date5TextBox.Text, identNumberTextBox.Text, sexComboBox.SelectedIndex + 1, houseTextBox.Text, housingTextBox.Text, flatTextBox.Text, zipCodeTextBox.Text, phoneNumberTextBox.Text,
                    emailTextBox.Text, regionTextBox.Text, districtTextBox.Text, townTypeComboBox.SelectedIndex + 1, townTextBox.Text, streetTypeComboBox.SelectedIndex + 1,
                    streetTextBox.Text, "1", "1");

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
                this.userService.UpdateUser(name1TextBox.Text, name2TextBox.Text, name3TextBox.Text, passportSeriaTextBox.Text, Convert.ToInt32(passportNumberTextBox.Text), issuedByTextBox.Text,
                date5TextBox.Text, identNumberTextBox.Text, sexComboBox.SelectedIndex + 1, houseTextBox.Text, Convert.ToInt32(housingTextBox.Text), flatTextBox.Text, Convert.ToInt32(zipCodeTextBox.Text), Convert.ToInt64(phoneNumberTextBox.Text),
                emailTextBox.Text, regionTextBox.Text, districtTextBox.Text, townTypeComboBox.SelectedIndex + 1, townTextBox.Text, streetTypeComboBox.SelectedIndex + 1,
                streetTextBox.Text, this.userService.AuthorizedUser);
            }
            catch (Exception)
            {
                return;
            }

            this.Hide();

            LoginedWindows loginedWindows = new LoginedWindows(this.userService, this.mainWindow);
            loginedWindows.Show();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            LoginedWindows loginedWindows = new LoginedWindows(this.userService, this.mainWindow);
            loginedWindows.Show();
        }
    }
}
