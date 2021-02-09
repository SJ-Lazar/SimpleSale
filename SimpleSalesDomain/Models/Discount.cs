using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class Discount : DomainObject
    {
        public string DiscountName { get; set; }
        public decimal DiscountValue { get; set; }

    }
}
