using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BassPriceComparator.Models
{
    public class BasePrice
    {
        public int id{ get; set; }
        public virtual Bass bass{ get; set; }
        public virtual Source source { get; set; }
        public decimal price { get; set; }
    }
}