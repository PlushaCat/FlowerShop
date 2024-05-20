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

namespace FlowerShop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization registration = new Authorization();
            registration.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           var login = LoginBox.Text.Trim();
            var password = PasswordBox.Text.Trim();
             var phonenumber = PhoneBox.Text.Trim();
              var email = EmailBox.Text.Trim();
               var name = NameBox.Text.Trim();
                var surname = SurnameBox.Text.Trim();
                 var patronymic = PatronymicBox.Text.Trim();

            if (login.Length < 7 || password.Length < 7 || phonenumber.Length < 7 || email.Length < 7 || name.Length < 2 || surname.Length < 2 || patronymic.Length < 2)
                MessageBox.Show("Длина символов в поле слишком мала");
            var passwordConfirm = ConfirmPasswordBox.Text.Trim();

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm) || string.IsNullOrEmpty(phonenumber) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(patronymic) || string.IsNullOrEmpty(login))
                MessageBox.Show("Заполните все поля");

            if (password.Any(char.IsUpper) || password.Any(char.IsLower))
            {
                MessageBox.Show("Слабый пароль, исплользуйте разные регистры");
            }

            
            if (password.Any(char.IsDigit))
            {
                MessageBox.Show("Слабый пароль, исплользуйте цифры и буквы вместе");
            }

            
            if (password.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Слабый пароль, исплользуйте специльные символы");
            }

            if (email.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Неправильный Email");
            }






            var loginVerf = LoginBox.Text;
            var passwordVerf = LoginBox.Text;
            var phonenumberVerf = LoginBox.Text;
            var emailVerf = LoginBox.Text;
            var nameVerf = LoginBox.Text;
            var surnameVerf = LoginBox.Text;
            var patronymic = LoginBox.Text;


            var user = new users
            {
                iduser = 1,
                staff = 0,
                login = LoginBox.Text,
                password = PasswordBox.Text,
                phonenumber = PhoneBox.Text,
                email = EmailBox.Text,
                name = NameBox.Text,
                surname = SurnameBox.Text, 
                patronymic = PatronymicBox.Text,
            };

            DatabaseFlower.entity.users.Add(user);
            DatabaseFlower.entity.SaveChanges();
        }
    }
}
