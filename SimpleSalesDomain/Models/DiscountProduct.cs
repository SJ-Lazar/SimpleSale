using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class DiscountProduct : DomainObject
    {
        public int ProductId { get; set; }
        public int DiscountId { get; set; }

    }
}
