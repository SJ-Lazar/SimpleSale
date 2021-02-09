using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesDomain.Models
{
    public class DomainObject
    {
        public int Id { get; set; }
        public int UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserModified { get; set; }
        public DateTime DateModified { get; set; }
    }
}
