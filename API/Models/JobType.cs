using System;
using System.Collections.Generic;

namespace API.Models;

public partial class JobType
{
    public int IdjobType { get; set; }

    public string JobTypeName { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<Job> JobsNavigation { get; set; } = new List<Job>();
}
