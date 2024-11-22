using GoldDigger.Model;
using System;
using System.Windows;

namespace GoldDigger.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            string username = UsernameTb.Text;
            string password = PasswordTb.Password;
            string passwordConf = PasswordTb2.Password;
            DBConnect database = new DBConnect();

            if (database.CheckUsername(username))
            {
                MessageBox.Show($"Username: {username} already registered.");
                UsernameTb.Clear();
            }

            else 
            {
                if (String.Equals(password, passwordConf))
                {
                    
                    var (HashedPassword, salt) = Model.PasswordHasher.HashPassword(password);

                    string query = $"INSERT INTO credentials (username, HashedPassword, Salt) VALUES ('{username}', '{HashedPassword}', '{salt}')";
                    database.Insert(query);
                    PasswordTb.Clear();
                    UsernameTb.Clear();
                    PasswordTb2.Clear();
                }
                else
                {
                    MessageBox.Show("Passwords don't match");
                    PasswordTb.Clear();
                    PasswordTb2.Clear();
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

      
    }
}
