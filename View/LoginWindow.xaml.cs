using DPKPApp.Data;
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

namespace DPKPApp.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text == "Логин")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "Логин";
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Заполнены не все поля!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoginClass loginClass = new LoginClass();
            if (loginClass.FindUser(txtLogin.Text, txtPassword.Password))
            {
                if (Tables.RefreshTabls())
                {
                    CatalogeWindow catalogeWindow = new CatalogeWindow();
                    catalogeWindow.Show();
                    this.Close();
                }
                return;
            }
            MessageBox.Show("Неверный логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
