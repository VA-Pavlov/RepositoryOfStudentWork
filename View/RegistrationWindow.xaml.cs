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
using DPKPApp.Data;

namespace DPKPApp.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "" || txtPassword.Password == "" || txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoginClass loginClass = new LoginClass();
            loginClass.CreateUser(txtLogin.Text, txtPassword.Password, txtFirstName.Text, txtFirstName.Text, txtLastName.Text);
            this.Close();
        }
    }
}
