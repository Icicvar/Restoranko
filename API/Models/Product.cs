using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Product
{
    public int Idproduct { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public int? RecepieId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Recipe? Recepie { get; set; }
}
