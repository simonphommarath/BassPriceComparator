using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BassPriceComparator.Models
{
    public class Bass
    {
        public int id { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string description { get; set; }

        public virtual ICollection<Source> sourcePrice{ get; set; }
    }
}