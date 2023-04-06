using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Job
{
    public int Idjob { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employment> Employments { get; } = new List<Employment>();

    public virtual ICollection<Item> Items { get; } = new List<Item>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
