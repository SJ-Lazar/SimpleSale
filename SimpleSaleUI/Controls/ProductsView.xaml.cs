using SimpleSalesDomain.Models;
using SimpleSalesEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleSaleUI.Controls
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        List<Product> products;
        public ProductsView()
        {
            InitializeComponent();     
        }

        void PopulateDataGridWithProductsList()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
               
                dgProducts.ItemsSource = products;

                dgProducts.Columns[0].Header = "Name";
                dgProducts.Columns[1].Header = "Bar Code";
                dgProducts.Columns[2].Header = "Description";
                dgProducts.Columns[3].Header = "Purchase Price";
                
                dgProducts.Columns[4].Visibility = Visibility.Collapsed;
                dgProducts.Columns[5].Visibility = Visibility.Collapsed;
                dgProducts.Columns[6].Visibility = Visibility.Collapsed;
                dgProducts.Columns[7].Visibility = Visibility.Collapsed;
                dgProducts.Columns[8].Visibility = Visibility.Collapsed;
            }
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateDataGridWithProductsList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
