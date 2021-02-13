using SimpleSaleUI.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleSaleUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TabItem _tabUserControl;
        public MainWindow()
        {
            InitializeComponent();
            GetView("Home");
        }

        //METHODS
        public void GetView(string view)
        {  
            if( view != null)
            {
                MainTab.Items.Clear();

                UserControl uc = new UserControl();

                if (view == "Home")
                {
                    HomeView homeView = new HomeView();
                    uc = homeView;
                }
                else if (view == "Transactions")
                {
                    TransactionsView transactionView = new TransactionsView();
                    uc = transactionView;
                }
                else if (view == "Products")
                {
                    ProductsView productsView = new ProductsView();
                    uc = productsView;
                }
                else
                {
                    MessageBox.Show("View Not Reconized, View");
 
                    return;
                }
                
                _tabUserControl = new TabItem { Content = uc };
                MainTab.Items.Add(_tabUserControl);
                _tabUserControl.Visibility = Visibility.Collapsed;
                MainTab.Items.Refresh();
                
            }
            else
            {
                MessageBox.Show("View is Null, Please Provide valid View");
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            GetView("Home");
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            GetView("Transactions");
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            GetView("Products");
        }

        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            GetView("Sales");
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
