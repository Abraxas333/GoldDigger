using GoldDigger.Model;
using MySqlX.XDevAPI;
using System;
using System.Windows;
using System.Windows.Input;

namespace GoldDigger.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var RegisterWindow = new RegisterWindow();
            RegisterWindow.Show();
            RegisterWindow.Closed += (s, args) => Show();
            Hide();
        }

        private void onLoginClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(PasswordTb.Password) && !String.IsNullOrEmpty(UsernameTb.Text))
            {
                string password = PasswordTb.Password;
                string username = UsernameTb.Text;

                DBConnect Database = new DBConnect();
                var (HashedPassword, Salt) = Database.CheckPassword(username);
                
                
                if (Model.PasswordHasher.VerifyPassword(password, HashedPassword, Salt))
                {
                    var MainWindow = new MainWindow();
                    MainWindow.Show();
                    MainWindow.Closed += (s, args) => Show();
                    Hide();
                }            
            }           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
