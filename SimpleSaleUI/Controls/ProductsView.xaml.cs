using SimpleSalesDomain.Models;
using SimpleSalesEF;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        #region Constrcutor

        public ProductsView()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void PopulateDataGridWithProductsList()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                List<Product> products = new List<Product>();
                products = _context.Products.ToList();
                dgSearchedProducts.ItemsSource = products;

                dgSearchedProducts.Columns[0].Header = "Name";
                dgSearchedProducts.Columns[1].Header = "Bar Code";
                dgSearchedProducts.Columns[2].Header = "Description";
                dgSearchedProducts.Columns[3].Header = "Purchase Price";
                dgSearchedProducts.Columns[4].Header = "Selling Price";

                dgSearchedProducts.Columns[5].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[6].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[7].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[8].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[9].Visibility = Visibility.Collapsed;
            }
        }
        public void CreateNewProduct()
        {
            using (SimpleSaleDbContext _contex = new SimpleSaleDbContext())
            {
                Product p = new Product();

                p.ProductName = txtProductName.Text.ToString();
                p.Barcode = txtBarcode.Text.ToString();
                p.ProductDescription = txtProductDescription.Text.ToString();
                p.PurchasePrice = Decimal.Parse(txtProductPurchasePrice.Text);
                p.SellingPrice = Decimal.Parse(txtProductSellingPrice.Text);

                //Checks for duplication using the products Barcode
                if (_contex.Products.ToList().Any(x => x.Barcode == p.Barcode))
                {
                    MessageBox.Show("Product Already Exsits in table products.");
                    return;
                }
                else
                {
                    _contex.Products.Add(p);
                    _contex.SaveChanges();

                    MessageBox.Show("Product Successfully Added");

                    txtProductName.Clear();
                    txtBarcode.Clear();
                    txtProductDescription.Clear();
                    txtProductPurchasePrice.Clear();
                    txtProductSellingPrice.Clear();
                    PopulateDataGridWithProductsList();
                }
            }
        }
        public bool GetUpdateProduct()
        {
            bool IsVaild = false;
            using (SimpleSaleDbContext _contex = new SimpleSaleDbContext())
            {
                Product p = new Product();
                string givenBarcode = txtGetBarcode.Text.ToString();
                p = _contex.Products.FirstOrDefault(x => x.Barcode == givenBarcode);

                txtUpdateProductName.Text = p.ProductName.ToString();
                txtUpdateProductDescription.Text = p.ProductDescription.ToString();
                txtUpdateProductPurchasePrice.Text = p.PurchasePrice.ToString();
                txtUpdateProductSellingPrice.Text = p.SellingPrice.ToString();

                if (p != null)
                {
                    IsVaild = true;
                    return IsVaild;
                }
                else
                {
                    IsVaild = false;
                    MessageBox.Show("Could Not Find Product To Update");
                    return IsVaild;
                }
            }
        }
        public void SearchProducts()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                List<Product> products = new List<Product>();
                string searchPhrase = sbSearchProduct.Text.ToString();
                products = _context.Products.Where(x => x.ProductName.Contains(searchPhrase)).ToList();

                dgSearchedProducts.ItemsSource = products;
                dgSearchedProducts.Columns[0].Header = "Name";
                dgSearchedProducts.Columns[1].Header = "Bar Code";
                dgSearchedProducts.Columns[2].Header = "Description";
                dgSearchedProducts.Columns[3].Header = "Purchase Price";
                dgSearchedProducts.Columns[4].Header = "Selling Price";

                dgSearchedProducts.Columns[5].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[6].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[7].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[8].Visibility = Visibility.Collapsed;
                dgSearchedProducts.Columns[9].Visibility = Visibility.Collapsed;
            }
        }
        public void UpdateProduct()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {


                var p = _context.Products.FirstOrDefault(x => x.Barcode == txtGetBarcode.Text.ToString());

                p.ProductName = txtUpdateProductName.Text.ToString();
                p.Barcode = txtGetBarcode.Text.ToString();
                p.ProductDescription = txtUpdateProductDescription.Text.ToString();
                p.PurchasePrice = Decimal.Parse(txtUpdateProductPurchasePrice.Text.ToString());
                p.SellingPrice = Decimal.Parse(txtUpdateProductSellingPrice.Text.ToString());

                _context.SaveChanges();
                txtUpdateProductName.Clear();
                txtUpdateProductDescription.Clear();
                txtUpdateProductPurchasePrice.Clear();
                txtUpdateProductSellingPrice.Clear();
                txtGetBarcode.Clear();
                PopulateDataGridWithProductsList();
                MessageBox.Show("Product Successfully Updated");
            }
        }
        public void GetProductToDelete()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                var p = _context.Products
                    .FirstOrDefault(x => x.Barcode == txtGetDeleteBarcode.Text.ToString());

                lblDeleteInFoName.Text = p.ProductName.ToString();
                lblDeleteInFoBarcode.Text = p.Barcode.ToString();


            }
        }
        public void DeleteProduct()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                var p = _context.Products.FirstOrDefault(x => x.Barcode == lblDeleteInFoBarcode.Text.ToString());
                _context.Remove(p);
                _context.SaveChanges();
                lblDeleteInFoBarcode.Text = "";
                lblDeleteInFoName.Text = "";
                txtGetDeleteBarcode.Clear();
                MessageBox.Show("Product Successfully Deleted!!!");
            }
        }
        public void AddNewVat()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                ValueAddedTax vat = new ValueAddedTax();

                vat.VATName = txtVatName.Text.ToString();
                vat.VATValue = Convert.ToDecimal(txtVatValue.Text.ToString());

                _context.ValueAddedTaxes.Add(vat);
                _context.SaveChanges();
                txtVatName.Clear();
                txtVatValue.Clear();
                MessageBox.Show("VAT Successfully Added To Table", "VAT");
            }
        }
        public void AddNewDicount()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                Discount discount = new Discount();

                discount.DiscountName = txtDiscountName.Text.ToString();
                discount.DiscountValue = decimal.Parse(txtDicountValue.Text);

                _context.Discounts.Add(discount);

                txtDiscountName.Clear();
                txtDicountValue.Clear();
                MessageBox.Show("Discount Successfully Added To Table", "Discount");
            }
        }

        #endregion

        #region Events

        private void btnCreateNewProduct_Click(object sender, RoutedEventArgs e)
        {
            CreateNewProduct();
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct();
        }

        private void btnFetchedProduct_Click(object sender, RoutedEventArgs e)
        {
            GetUpdateProduct();
        }

        private void sbSearchProduct_KeyUp(object sender, KeyEventArgs e)
        {
            SearchProducts();
        }

        private void tabSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateDataGridWithProductsList();
        }

        private void btnRefreshProductsGrid_Click(object sender, RoutedEventArgs e)
        {
            PopulateDataGridWithProductsList();
        }

        private void btnGetProductToDelete_Click(object sender, RoutedEventArgs e)
        {
            GetProductToDelete();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            DeleteProduct();
        }

        private void btnAddVat_Click(object sender, RoutedEventArgs e)
        {
            AddNewVat();
        }

        private void btnAddDiscount_Click(object sender, RoutedEventArgs e)
        {
            AddNewDicount();
        }

        #endregion

        private void txtVatValue_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtVatValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            string.Format("{0:P2}", txtVatValue.Text.ToString());
        }
    }
}
