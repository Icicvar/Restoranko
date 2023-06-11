using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class Product
    {

        public int Idproduct { get; set; }

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public int RecepieId { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();

        public virtual Recipe Recepie { get; set; }
    }
}