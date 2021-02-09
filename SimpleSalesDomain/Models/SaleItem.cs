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

       
        [DisplayName("Sale Price")]
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
    }
}
