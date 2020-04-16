using StudentsDataBase.Services;
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
    /// Interaction logic for BlockUserWindow.xaml
    /// </summary>
    public partial class BlockUserWindow : Window
    {
        private readonly UserService userService;
        private readonly MainWindow mainWindow;

        public BlockUserWindow(UserService userService, MainWindow mainWindow)
        {
            this.userService = userService;
            this.mainWindow = mainWindow;

            InitializeComponent();
        }

        private void blockUser_Click(object sender, RoutedEventArgs e)
        {
            int timeForBlock = 0;

            switch (timeComboBox.SelectedIndex)
            {
                case 0: timeForBlock = 10;
                    break;
                case 1: timeForBlock = 600;
                    break;
                case 2: timeForBlock = 3600;
                    break;
                case 3: timeForBlock = 86400;
                    break;
            }

            if (this.userService.AuthorizedUser == loginTextBox.Text)
            {
                MessageBox.Show("Нельзя заблокировать себя.");
                return;
            }

            if (this.userService.IsUserExists(loginTextBox.Text))
            {
                this.userService.BlockOnTime(loginTextBox.Text, timeForBlock);
            }

            this.Hide();
        }
    }
}
