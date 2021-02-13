using SimpleSalesDomain.Models;
using SimpleSalesEF;
using SimpleSaleUI.Helper;
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

        public void CreateSale() 
        {
            Sale newSale = new Sale();

            newSale.SaleSubTotal = GetCartSubTotal();
            newSale.SaleTotalTax = GetCartVatTotal();
            newSale.SaleTotalTax = GetCartTotal();

            if(newSale.SaleSubTotal < 0)
            {
                MessageBox.Show("Please provide a subtotal.", "Error - Invaild Value", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(newSale.SaleTotalTax < 0)
            {
                MessageBox.Show("Please provide a tax total.", "Error - Invaild Value", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (newSale.SaleTotal < 0)
            {
                MessageBox.Show("Please provide a  total.", "Error - Invaild Value", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
                {
                    _context.Sales.Add(newSale);
                    _context.SaveChanges();

                    Sale sale = _context.Sales.OrderBy(p => p.DateCreated).LastOrDefault();

                    if(sale == null)
                    {
                        MessageBox.Show("Unable to find Sale.", "Error - Null Return");
                        return;
                    }
                    else
                    {
                        if(dgSaleItem.Items.Count <= 0)
                        {
                            MessageBox.Show("No items in cart, Please add items to cart", "Error - Empty Value", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            foreach (SaleItem item in dgSaleItem.Items)
                            {
                                item.SaleId = sale.Id;
                                _context.SalesItems.Add(item);
                                _context.SaveChanges();
                            }

                            Receipt newReceipt = new Receipt();
                            newReceipt.SaleId = sale.Id;
                            newReceipt.AmountTendered = decimal.Parse(txtAmountTendred.Text.Remove(0, 1));
                            newReceipt.Change = CalculateChange();
                            if (CalculateChange() < 0)
                            {
                                MessageBox.Show("Amount tendred is below total amount, Please enter a amount greater than the total.", "Error - Amount Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                                txtAmountTendred.Focus();
                                return;
                            }
                            else
                            {
                                _context.Receipts.Add(newReceipt);
                                _context.SaveChanges();

                                dgSaleItem.Items.Clear();
                                lblDiscountTotal.Text = string.Empty;
                                lblSubTotal.Text = string.Empty;
                                lblTotalVat.Text = string.Empty;
                                lblPriceTotalVat.Text = string.Empty;
                                txtSaleGrandTotal.Clear();
                                txtAmountTendred.Clear();
                            }
                           
                        }                        
                    }                   
                }
            }          
        }

        public void CreateSaleItem()
        {
            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                //Handles product Qty
                int quantity = 1;
                if (txtgetItemQuantity.Text != null && txtgetItemQuantity.Text != "")
                {
                    quantity = int.Parse(txtgetItemQuantity.Text);
                }

                Product product = _context.Products
                   .FirstOrDefault(x =>
                   x.Barcode ==
                   txtgetAddItemToCartBarcode.Text
                   .ToString());

                if (product == null)
                {
                    MessageBox.Show("Please enter a valid product barcode", "Error - No Value", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtgetAddItemToCartBarcode.Focus();
                }
                else
                {
                    
                    ValueAddedTax vat = _context.ValueAddedTaxes.FirstOrDefault(y => y.Id == 4);

                    DiscountProduct discountOnProduct = _context.DiscountOnProducts.FirstOrDefault(z => z.ProductId == product.Id);
                    Discount discount = new Discount();

                    if(discountOnProduct == null)
                    {
                        discount.DiscountName = "No Discount";
                        discount.DiscountValue = 0;
                    }
                    else
                    {
                         discount = _context.Discounts.FirstOrDefault(z => z.Id == discountOnProduct.DiscountId);
                    }                  

                    SaleItem saleItem = new SaleItem();

                    saleItem.ProductId = product.Id;
                    saleItem.ValueAddedTaxId = vat.Id;
                    saleItem.DiscountId = discount.Id;
                    saleItem.Item = product.ProductName;
                    saleItem.Barcode = product.Barcode;
                    saleItem.Quantity = quantity;
                    saleItem.UnitPrice = product.SellingPrice;
                    saleItem.Discount = (saleItem.UnitPrice * saleItem.Quantity) * (discount.DiscountValue / 100);
                    saleItem.PriceVat = saleItem.UnitPrice + (saleItem.UnitPrice * vat.VATValue / 100);

                    saleItem.ItemsPrice = (saleItem.Quantity * saleItem.PriceVat) - saleItem.Discount;

                    dgSaleItem.Items.Add(saleItem);
                    saleItemsList.Add(saleItem);
                } 
            }             
        }

        public decimal GetCartSubTotal()
        {
            decimal sum = 0m;

            foreach (SaleItem item in saleItemsList)
            {
                sum += item.Quantity * item.UnitPrice - item.Discount;
            }
            return sum;
        }

        public decimal GetCartDiscountTotal()
        {
            decimal sum = 0m;

            foreach (SaleItem item in saleItemsList)
            {
                sum += item.Discount;
            }
            return sum;
        }

        public decimal GetCartVatTotal()
        {
            decimal sum = 0m;

            foreach (SaleItem item in saleItemsList)
            {
                sum +=  item.Quantity * (item.PriceVat - item.UnitPrice);
            }
            return sum;
        }

        public decimal GetCartTotal()
        {
            decimal sum = 0m;
            
            foreach(SaleItem item in saleItemsList)
            {
                sum += item.ItemsPrice;             
            }
            return sum;
        }

        public decimal GetCartPriceTotalVat()
        {
            decimal sum = 0m;

            foreach (SaleItem item in saleItemsList)
            {
                sum += item.Quantity * item.PriceVat;
            }
            return sum;
        }

        public void GetItems() 
        {
            List<Product> products = new List<Product>();

            using (SimpleSaleDbContext _context = new SimpleSaleDbContext())
            {
                products = _context.Products.ToList();
            }

            foreach(var p in products)
            {
                cbItems.Items.Add(p.Barcode + " " + p.ProductName + " " + string.Format("{0:c}",p.SellingPrice));
            }
            

        }

        public decimal CalculateChange()
        {
            decimal change = 0m;

            decimal amountTendred = decimal.Parse(txtAmountTendred.Text.Remove(0, 1));
            decimal grandTotal = decimal.Parse(txtSaleGrandTotal.Text.Substring(1));

            change = amountTendred - grandTotal;
         
            return change;
        }

        public void GetBarcode()
        {
            if(cbItems.Text == null || cbItems.Text == "")
            {
                return;
            }
            else
            {
                string item = cbItems.Text.ToString();
                string itemsub = item.Substring(0, 1);
                txtgetAddItemToCartBarcode.Text = itemsub;
            }
          
        }

        private void btnAddItemToCartUsingBarcode_Click(object sender, RoutedEventArgs e)
        {   
            //Checking for Null Values.
            if (txtgetAddItemToCartBarcode.Text.IsEmpty())
            {
                MessageBox.Show("Please enter a valid product barcode", "Error - No Value", MessageBoxButton.OK, MessageBoxImage.Error);
                txtgetAddItemToCartBarcode.Focus();
            }
            else
            {
                CreateSaleItem();
                lblDiscountTotal.Text = string.Format("{0:c}", GetCartDiscountTotal());
                lblPriceTotalVat.Text = string.Format("{0:c}", GetCartPriceTotalVat());
                lblSubTotal.Text = string.Format("{0:c}", GetCartSubTotal());
                lblTotalVat.Text = string.Format("{0:c}", GetCartVatTotal());
                txtSaleGrandTotal.Text = string.Format("{0:c}", GetCartTotal());
                cbItems.Items.Clear();
                txtgetAddItemToCartBarcode.Clear();
            }      
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if(dgSaleItem.Items.Count <= 0)
            {
                MessageBox.Show("No items in cart please add items to cart", "Error - No Value", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(txtSaleGrandTotal.Text.IsEmpty())
            {
                MessageBox.Show("No total value", "Error - No Value", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSaleGrandTotal.Focus();
            }
            else if (txtAmountTendred.Text.IsEmpty())
            {
                MessageBox.Show("No amount tendred, Please provide amount", "Error - No Value", MessageBoxButton.OK, MessageBoxImage.Error);
                txtAmountTendred.Focus();
            }
            else if(CalculateChange() < 0)
            {
                MessageBox.Show("Amount tendred is below total amount, Please enter a amount greater than the total.", "Error - Amount Invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                txtAmountTendred.Focus();
            }
            else
            {
                CreateSale();
            }
          
        }
        private void cbItems_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cbItems.Items.Clear();
            GetItems();
        }
        private void cbItems_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            GetBarcode();
        }
       
    }
}
