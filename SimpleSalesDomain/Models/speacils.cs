using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class speacils : DomainObject
    {
        public string SpeacilName { get; set; }
        public decimal SpeacilValue { get; set; }
    }
}
