﻿using System;
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
    }
}
