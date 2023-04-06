using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Order
{
    public int Idorder { get; set; }

    public int OrderNumber { get; set; }

    public DateTime OrderDate { get; set; }

    public int TotalPrice { get; set; }

    public int? WaiterId { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual Job? Waiter { get; set; }
}
