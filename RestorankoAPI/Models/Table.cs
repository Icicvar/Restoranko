using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Table
{
    public int Idtable { get; set; }

    public int TableNumber { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
