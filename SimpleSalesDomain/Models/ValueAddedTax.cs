using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class ValueAddedTax : DomainObject
    {
        public string VATName { get; set; }
        public decimal VATValue { get; set; }
    }
}
