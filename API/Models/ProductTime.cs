using System;
using System.Collections.Generic;

namespace API.Models;

public partial class ProductTime
{
    public int IdproductTime { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
