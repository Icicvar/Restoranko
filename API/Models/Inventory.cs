using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Inventory
{
    public int Idinventory { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
