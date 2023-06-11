using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestorankoWeb.Models
{
    public class Transaction
    {
        public int Idtransaction { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionType { get; set; } = null!;

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}