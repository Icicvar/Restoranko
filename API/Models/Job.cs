using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Job
{
    public int Idjob { get; set; }

    public int? UserId { get; set; }

    public int? JobTypeId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual JobType? JobType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }

    public virtual ICollection<JobType> JobTypes { get; set; } = new List<JobType>();
}
