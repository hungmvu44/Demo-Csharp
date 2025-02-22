using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
using AirConditionerShop.BLL.Services;
using Microsoft.VisualBasic.Logging;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.IdentityModel.Tokens;
using AirConditionerShop.DAL.Entities;

namespace AirConditionerShop_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private StaffMemberService _staffservice = new();
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //If user with a Administrator and Staff role logs in successfully(using email address/ password for login process), save this information to a temporary parameter.All CRUD actions are required authentication. In the case login unsuccessfully, display “You have no permission to access this function!”.
            //login authenticate
            if (EmailAddressTextBox.Text.IsNullOrEmpty() ||
                EmailAddressTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Email and Password are both Required", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;

            }
            StaffMember? account = _staffservice.Authenticate(EmailAddressTextBox.Text, PasswordTextBox.Text);
            if (account == null)
            {
                MessageBox.Show("Invalid email address or password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (account.Role == 3)
            {
                MessageBox.Show("You do not have permission !", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }
            MainWindow m = new();
            m.CurrentAccount = account; //2 chang tro 1 nang
            m.Show();
            this.Hide();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
