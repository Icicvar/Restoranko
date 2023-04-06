using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Employment
{
    public int Idemployment { get; set; }

    public int? UserId { get; set; }

    public int? JobId { get; set; }

    public virtual Job? Job { get; set; }

    public virtual User? User { get; set; }
}
