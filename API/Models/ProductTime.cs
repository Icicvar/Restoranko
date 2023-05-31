using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ProductTime
{
    public int IdproductTime { get; set; }

    public int ItemId { get; set; }

    public int OrderId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
