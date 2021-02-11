using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class SaleItem : DomainObject
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ValueAddedTaxId { get; set; }
        public int DiscountId { get; set; }
        public string Item { get; set; }
        public string Barcode { get; set; }

        [DisplayName("Sale Price")]
        public decimal UnitPrice { get; set; }
        public decimal PriceVat { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal ItemsPrice { get; set; }
    }
}
