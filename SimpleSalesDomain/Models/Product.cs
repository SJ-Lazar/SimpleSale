using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class Product : DomainObject
    {
        [DisplayName("Product")]
        [StringLength(30)]
        public string ProductName { get; set; } 
        public string Barcode { get; set; }
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [DisplayName("Purchase Price")]
        public decimal PurchasePrice { get; set; }
        [DisplayName("Selling Price")]
        public decimal SellingPrice { get; set; }

    }
}
