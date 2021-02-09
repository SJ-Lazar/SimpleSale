using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class SpeacilOnProduct : DomainObject
    {
        public int ProductId { get; set; }
        public int SpeacilId { get; set; }
    }
}
