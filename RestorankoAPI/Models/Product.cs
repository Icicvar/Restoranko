using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Product
{
    public int Idproduct { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<Item> Items { get; } = new List<Item>();
}
