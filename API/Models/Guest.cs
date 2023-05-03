using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Guest
{
    public int Idguest { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual User? User { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
