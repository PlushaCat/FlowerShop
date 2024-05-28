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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
			DatabaseFlower.entity = new flowershopEntitiesd();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
			try
			{
				string login = LoginBox.Text.Trim();
				string password = PasswordBox.Text.Trim();

				if (!string.IsNullOrEmpty(login) && login.Length >= 3 && login.Length <= 50)
				{
					if (!string.IsNullOrEmpty(password) && 3 <= password.Length && password.Length <= 50)
					{
						var userDb = DatabaseFlower.entity.users.FirstOrDefault(x => x.login == login && x.password == password);
						if (userDb.iduser != 0)
						{
							DatabaseFlower.authUserId = userDb.iduser;
							DatabaseFlower.staff = userDb.staff;
							MessageBox.Show("Успешный вход");
							MainWindow mainWindoww = new MainWindow();
							mainWindoww.Show();
							this.Close();
						}
						else
						{
							MessageBox.Show("Не можете войти! Возможно, вы ввели неправильный логин или пароль.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
						}
					}
					else
					{
						MessageBox.Show("Поле пароля пусто!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
					}
				}
				else
				{
					MessageBox.Show("Поле для входа пусто!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
			}
			catch
			{
				MessageBox.Show("Пользователь не найден");
			}
		}
    }
}
