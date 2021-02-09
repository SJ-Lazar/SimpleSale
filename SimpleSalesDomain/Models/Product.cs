using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class Product : DomainObject
    {
        [DisplayName("Product")]
        public string ProductName { get; set; }
        
        public string Barcode { get; set; }
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [DisplayName("Purchase Price")]
        public decimal PurchasePrice { get; set; }

    }
}
