using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowerShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseFlower.entity = new flowershopEntitiesd();
            ListView1.ItemsSource = DatabaseFlower.entity.goods.ToList();
            if (DatabaseFlower.staff == 1)
                AdminButton.Visibility = Visibility.Visible;

            

            SortBy.ItemsSource = new string[] { "Название", "цена" };
            var enumDirection = new string[] { "по возрастанию", "по убыванию" };

            sortProp.ItemsSource = enumDirection;
            sortProp.SelectedValue = enumDirection[0];
            SortBy.SelectedValue = "Название";
            ListView1.Items.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));

            ListView1.Items.Filter = NameFilter;

            sortProp.SelectionChanged += SelectionChanged;
            SortBy.SelectionChanged += SelectionChanged;


        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedFilter = sortProp.SelectedItem.ToString();
            string selectedSort = SortBy.SelectedItem.ToString();
            ListSortDirection sortDirection = selectedFilter.Contains("по возрастанию") ? ListSortDirection.Ascending : ListSortDirection.Descending;

            var view = (CollectionView)CollectionViewSource.GetDefaultView(ListView1.ItemsSource);
            view.SortDescriptions.Clear();

            if (selectedSort == "Название")
                selectedSort = "name";
            if (selectedSort == "цена")
                selectedSort = "price";

            view.SortDescriptions.Add(new SortDescription(selectedSort, sortDirection));
        }

        private bool NameFilter(object obj)
        {
            var FilterObj = obj as goods;

            return FilterObj.name.Contains(filter.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            // Получаем данные текущего элемента
            var data = button.DataContext as goods;

            var isGoods = DatabaseFlower.entity.basket.Any(b => b.idgood == data.idgood);
            var needGoods = DatabaseFlower.entity.basket.FirstOrDefault(b => b.idgood == data.idgood);
            if (isGoods) {
                needGoods.quantity += 1;
                DatabaseFlower.entity.SaveChanges();
            }
            else
            {
                var cartItem = new basket()
                {
                    idbasket = DatabaseFlower.authUserId,
                    idgood = data.idgood,
                    quantity = 1,

                };
                DatabaseFlower.entity.basket.Add(cartItem);
                DatabaseFlower.entity.SaveChanges();
            }

        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filter.Text == null)
                ListView1.Items.Filter = null;
            else
                ListView1.Items.Filter = NameFilter;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            orderWin orderWindow = new orderWin();
            orderWindow.Show();
            this.Close();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
