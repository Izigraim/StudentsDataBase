﻿using MySql.Data.MySqlClient;
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

namespace StudentsDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string connection = "datasource=127.0.0.1;port=3306;username=student;password=student;database=students";
        private readonly UserService userService;

        public MainWindow()
        {
            this.userService = new UserService(new DBConnection(connection).MySqlConnection);

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.userService.RegistrationUser(loginTextBox.Text, passwordTextBox.Text, 2, 2);
        }
    }
}
