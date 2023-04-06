using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class Guest
{
    public int Idguest { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual User? User { get; set; }
}
