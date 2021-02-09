using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class Receipt : DomainObject
    {
        public int SaleId { get; set; }
        [DisplayName("Amount Tendered ")]
        public decimal AmountTendered { get; set; }
        public decimal Change { get; set; }

    }
}
