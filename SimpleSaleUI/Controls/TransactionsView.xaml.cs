using SimpleSalesDomain.Models;
using SimpleSalesEF;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace SimpleSaleUI.Controls
{
    /// <summary>
    /// Interaction logic for TransactionsView.xaml
    /// </summary>
    public partial class TransactionsView : UserControl
    {
        List<SaleItem> saleItemsList = new List<SaleItem>();
        public TransactionsView()
        {
            InitializeComponent();
        }


        public void GetSaleItems()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                var SaleItemsList =_context.Products.ToList();
                foreach(var item in SaleItemsList)
                {                        
                        cbSaleItems.Items.Add(item.ProductName + " " + item.Barcode);       
                }
            }
        }

        public void CreateSaleItem()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
               

                Product product = _context.Products
                    .FirstOrDefault(x =>
                    x.Barcode ==
                    txtgetAddItemToCartBarcode.Text
                    .ToString());

                ValueAddedTax vat = _context.ValueAddedTaxes.FirstOrDefault(y => y.Id == 2);

                DiscountProduct discountOnProduct = _context.DiscountOnProducts.FirstOrDefault(z => z.ProductId == product.Id);

                Discount discount = _context.Discounts.FirstOrDefault(z => z.Id == discountOnProduct.DiscountId);

                SaleItem saleItem = new SaleItem();

                saleItem.ProductId = product.Id;
                saleItem.ValueAddedTaxId = vat.Id;
                saleItem.DiscountId = discountOnProduct.Id;
                saleItem.Item = product.ProductName;
                saleItem.Barcode = product.Barcode;
                saleItem.UnitPrice = product.SellingPrice;
                saleItem.Discount = saleItem.UnitPrice - (saleItem.UnitPrice * discount.DiscountValue);  
                saleItem.PriceVat = (product.SellingPrice - saleItem.Discount) * vat.VATValue;
                saleItem.Quantity = 1;
                saleItem.ItemsPrice = saleItem.Quantity * saleItem.PriceVat;

                dgSaleItem.Items.Add(saleItem);
                saleItemsList.Add(saleItem);
            }
                
        }

        public decimal getCartSubTotal()
        {
            decimal sum = 0m;

            foreach (SaleItem item in saleItemsList)
            {
                sum += item.UnitPrice;
            }
            return sum;
        }

        public decimal getCartVatTotal()
        {
            decimal sum = 0m;

            foreach (SaleItem item in saleItemsList)
            {
                sum += item.PriceVat;
            }
            return sum;
        }

        public decimal getCartTotal()
        {
            decimal sum = 0m;
            
            foreach(SaleItem item in saleItemsList)
            {
                sum += item.ItemsPrice;             
            }
            return sum;
        }

        private void cbSaleItems_GotFocus(object sender, RoutedEventArgs e)
        {
            GetSaleItems();
        }

        private void btnAddItemToCartUsingBarcode_Click(object sender, RoutedEventArgs e)
        {
            CreateSaleItem();
            txtSaleSubTotal.Text = getCartSubTotal().ToString();
            txtSaleTotalVAT.Text = getCartVatTotal().ToString();
            txtSaleGrandTotal.Text = getCartTotal().ToString();
            txtSaleTotal.Text = getCartTotal().ToString();    
        }

        public void CalculateChange()
        {
            decimal change = 0m;

            decimal amountTendred = decimal.Parse(txtAmountTendred.Text);
            decimal grandTotal = decimal.Parse(txtSaleGrandTotal.Text);

            change = amountTendred - grandTotal;

            MessageBox.Show($"Your Change is {change}", "Change");
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            CalculateChange();
        }
    }
}
