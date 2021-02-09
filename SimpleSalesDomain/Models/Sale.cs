using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class Sale : DomainObject
    {
        [DisplayName("Sub Total")]
        public decimal SaleSubTotal { get; set; }
        [DisplayName("Total Tax")]
        public decimal SaleTotalTax { get; set; }
        [DisplayName("Total")]
        public decimal SaleTotal { get; set; }
    }
}
