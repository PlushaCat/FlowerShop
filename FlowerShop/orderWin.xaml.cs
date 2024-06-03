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
    /// Логика взаимодействия для orderWin.xaml
    /// </summary>
    public partial class orderWin : Window
    {
        public orderWin()
        {
            InitializeComponent();
            DatabaseFlower.entity = new flowershopEntitiesd();
            ListView2.ItemsSource = DatabaseFlower.entity.basket.ToList();
     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            basket data = button.DataContext as basket;

            DatabaseFlower.entity.basket.Remove(data);
            DatabaseFlower.entity.SaveChanges();
            RefreshListView();
        }

        private void RefreshListView()
        {

            ListView2.ItemsSource = DatabaseFlower.entity.basket.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        //ss

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var haveOrder = DatabaseFlower.entity.orders.Any(o => o.iduser == DatabaseFlower.authUserId);
            var needOrder = DatabaseFlower.entity.orders.FirstOrDefault(o => o.iduser == DatabaseFlower.authUserId);

            if (haveOrder)
            {
                MessageBoxResult result = MessageBox.Show("У вас уже есть заказ, хотите его отменить?", "sfsf", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        DatabaseFlower.entity.orders.Remove(needOrder);
                        DatabaseFlower.entity.SaveChanges();
                        RefreshListView();
                        MessageBox.Show("Заказ удален");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                var order = new orders()
                {
                    iduser = DatabaseFlower.authUserId,
                    orderdate = DateTime.Now,
                    orderstatus = 0,
                };

                DatabaseFlower.entity.orders.Add(order);
                DatabaseFlower.entity.SaveChanges();
                MessageBox.Show("Заказ сделан");
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }
    }
}
