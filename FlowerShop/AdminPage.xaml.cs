using Microsoft.Win32;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShop
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            DatabaseFlower.entity = new flowershopEntitiesd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите картинку";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            var f = op.FileName;
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                DatabaseFlower.ImageToAdd = op.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var goods = new goods()
            {
                name = nameBox.Text.Trim(),
                price = priceBox.Text.Trim(),
                description = descBox.Text.Trim(),
                image = DatabaseFlower.ImageToAdd,

            };
            DatabaseFlower.entity.goods.Add(goods);
            DatabaseFlower.entity.SaveChanges();
        }
    }
}
//            File.Copy(paths, System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..", ".."), $"images\\{saymyname}")));

