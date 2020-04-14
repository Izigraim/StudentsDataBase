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

        public LoginedWindows(UserService userService)
        {
            this.userService = userService;

            InitializeComponent();

            label1.Content = this.userService.AuthorizedUser;
        }
    }
}
