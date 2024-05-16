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
            SortBy.ItemsSource = new string[] { "name", "price" };
            sortProp.ItemsSource = Enum.GetNames(typeof(ListSortDirection));
            ListView1.Items.SortDescriptions.Add(new SortDescription("name", ListSortDirection.Ascending));


        }

        private void sortProp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedSort = SortBy.SelectedItem.ToString();
            string selectedFilter = sortProp.SelectedItem.ToString();
            ListSortDirection sortDirection = selectedFilter.Contains("Ascending") ? ListSortDirection.Ascending : ListSortDirection.Descending;


            var view = (CollectionView)CollectionViewSource.GetDefaultView(ListView1.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(selectedSort, sortDirection));
        }

        private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedSort = SortBy.SelectedItem.ToString();
            string selectedFilter = sortProp.SelectedItem.ToString();
            ListSortDirection sortDirection = selectedFilter.Contains("Ascending") ? ListSortDirection.Ascending : ListSortDirection.Descending;


            var view = (CollectionView)CollectionViewSource.GetDefaultView(ListView1.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(selectedSort, sortDirection));
        }
    }
}
