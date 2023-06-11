using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class ProductTime
    {
        public int IdproductTime { get; set; }

        public int ItemId { get; set; }

        public int OrderId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }
    }
}