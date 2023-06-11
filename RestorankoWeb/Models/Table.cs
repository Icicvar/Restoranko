using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class Table
    {
        public int Idtable { get; set; }

        public int TableNumber { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}