using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class ProductStock : DomainObject
    {

        public int ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
