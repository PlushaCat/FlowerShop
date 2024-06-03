using System;
using System.Collections.Generic;
using System.IO;
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
using iTextSharp.text;
using iTextSharp.text.pdf;

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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            // Получаем данные текущего элемента
            var data = button.DataContext as basket;

            var needGoods = DatabaseFlower.entity.basket.FirstOrDefault(b => b.idgood == data.idgood);
            if (needGoods.quantity > 1)
            {
                needGoods.quantity -= 1;
                DatabaseFlower.entity.SaveChanges();
                ListView2.ItemsSource = DatabaseFlower.entity.basket.ToList();
            }
            else
            {
                DatabaseFlower.entity.basket.Remove(needGoods);
                DatabaseFlower.entity.SaveChanges();
                ListView2.ItemsSource = DatabaseFlower.entity.basket.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            // Получаем данные текущего элемента
            var data = button.DataContext as basket;
            var needGoods = DatabaseFlower.entity.basket.FirstOrDefault(b => b.idgood == data.idgood);
            needGoods.quantity += 1;
            DatabaseFlower.entity.SaveChanges();
            ListView2.ItemsSource = DatabaseFlower.entity.basket.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Document doc = new Document();
            string filePath = "S:\\USERS\\51-02\\Цыбанев Никита Алексеевич\\praktikaWPF\\FlowerShop\\FlowerShop\\images";

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Чек покупки");
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new iTextSharp.text.Paragraph("\n"));


                List<basket> basketItems = DatabaseFlower.entity.basket.ToList();

                foreach (var item in basketItems)
                {
                    goods product = DatabaseFlower.entity.goods.FirstOrDefault(g => g.idgood == item.idgood);
                    if (product != null)
                    {
                        string itemInfo = $"{product.name} - {item.quantity} шт. x {product.price} руб.";
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(product.CorrectImage);
                        doc.Add(new iTextSharp.text.Paragraph(itemInfo));
                        doc.Add(image);


                    }
                }

                doc.Close();

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании PDF: " + ex.Message);
            }
        }
    }
}

