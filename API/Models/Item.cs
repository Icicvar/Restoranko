using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Item
{
    public int Iditem { get; set; }

    public int Amount { get; set; }

    public int? EmpolyeeId { get; set; }

    public int? ProductId { get; set; }

    public int? OrderId { get; set; }

    public virtual User? Empolyee { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<ProductTime> ProductTimes { get; set; } = new List<ProductTime>();
}
