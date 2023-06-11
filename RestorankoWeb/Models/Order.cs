using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class Order
    {
        public int Idorder { get; set; }

        public int OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalPrice { get; set; }

        public int? WaiterId { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();

        public virtual ICollection<ProductTime> ProductTimes { get; set; } = new List<ProductTime>();

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public virtual User Waiter { get; set; }
    }
}