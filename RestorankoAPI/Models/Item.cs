using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Item
{
    public int Iditem { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int Amount { get; set; }

    public int? BarmanId { get; set; }

    public virtual Job? Barman { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
