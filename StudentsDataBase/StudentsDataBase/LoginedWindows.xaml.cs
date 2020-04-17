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
using StudentsDataBase.Services;

namespace StudentsDataBase
{
    /// <summary>
    /// Interaction logic for LoginedWindows.xaml
    /// </summary>
    public partial class LoginedWindows : Window
    {
        private readonly UserService userService;
        private readonly MainWindow mainWindow;

        public LoginedWindows(UserService userService, MainWindow mainWindow)
        {
            this.userService = userService;
            this.mainWindow = mainWindow;

            InitializeComponent();

            label1.Content = this.userService.AuthorizedUser;
        }

        private void deleteCurrentAccount_Click(object sender, RoutedEventArgs e)
        {
            this.userService.DeleteUser(this.userService.AuthorizedUser);

            this.Hide();

            mainWindow.Show();
            
        }

        private void exitFromAccount_Click(object sender, RoutedEventArgs e)
        {
            this.userService.AuthorizedUser = string.Empty;

            this.Hide();

            mainWindow.Show();
        }

        private void updateAccount_Click(object sender, RoutedEventArgs e)
        {
            // this.userService.UpdateUser("10", "10", "10", "10", 1, "10", "1-10-1", "10", 1, "10", 1, "10", 1, 1, "10", "10", "10", 1, "10", 1, "10", "1");

            this.Hide();

            UpdateWindow updateWindow = new UpdateWindow(this.userService, this.mainWindow);
            updateWindow.Show();
        }

        private void blockOnTime_Click(object sender, RoutedEventArgs e)
        {
            BlockUserWindow blockUserWindow = new BlockUserWindow(this.userService, this.mainWindow);
            blockUserWindow.Show();
        }

        private void backupButton_Click(object sender, RoutedEventArgs e)
        {
            this.userService.BackupUser(this.userService.AuthorizedUser);
        }
    }
}
