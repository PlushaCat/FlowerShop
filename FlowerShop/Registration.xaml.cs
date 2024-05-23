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
            DatabaseFlower.entity = new flowershopEntitiesd();

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
            {
                MessageBox.Show("Длина символов в поле слишком мала");
                return;
            }
                
            

            var passwordConfirm = ConfirmPasswordBox.Text.Trim();


            if (!(passwordConfirm == password))
            {
                MessageBox.Show("Пароль не равен подтверждённому паролю");
                return;
            }


            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordConfirm) || string.IsNullOrEmpty(phonenumber) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(patronymic) || string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }


            if (char.IsDigit(login[0]))
            {
                MessageBox.Show("логин не должен начинатся с цифр");
                return;
            }

            if (!password.Any(char.IsDigit) && !password.Any(char.IsLetter))
            {
                MessageBox.Show("Слабый пароль, используйте цифры и буквы вместе");
                return;
            }


            if (!password.Any(char.IsUpper) && !password.Any(char.IsLower))
            {
                MessageBox.Show("Слабый пароль, исплользуйте разные регистры и буквы");
                return;
            }
            
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Слабый пароль, исплользуйте специльные символы");
                return;
            }

            if (!email.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Неправильный формат Email");
                return;
            }

            if (login.Length > 24 || password.Length > 24 || phonenumber.Length > 24 || email.Length > 40 || name.Length > 50 || surname.Length > 50 || patronymic.Length > 50)
            {
                MessageBox.Show("Длина символов в поле слишком длинная");
                return;
            }

            if (!name.Any(c => !char.IsDigit(c)) || !surname.Any(c => !char.IsDigit(c)) || !patronymic.Any(c => !char.IsDigit(c)))
            {
                if (!name.Any(c => !char.IsSeparator(c)) || !surname.Any(c => !char.IsSeparator(c)) || !patronymic.Any(c => !char.IsSeparator(c)))
                {
                    MessageBox.Show("ФИО не должна содержать цифр и знаков");
                    return;
                }
            }

            try
            {
                users user = new users()
                {
                    staff = 0,
                    login = login,
                    password = password,
                    phonenumber = phonenumber,
                    email = email,
                    name = name,
                    surname = surname,
                    patronymic = patronymic
                };

                DatabaseFlower.entity.users.Add(user);
                DatabaseFlower.entity.SaveChanges();
                DatabaseFlower.authUserId = user.iduser;
                MessageBox.Show("Вы успешно зарегистрированы");
                

                MainWindow mainWin = new MainWindow();
                mainWin.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("пользователь не создается в базе данных");
            }


        }
    }
}
