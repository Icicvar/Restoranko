using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Reservation
{
    public int Idreservation { get; set; }

    public DateTime DateReservation { get; set; }

    public int? TableId { get; set; }

    public int? OrderId { get; set; }

    public int? GuestId { get; set; }

    public int? UserId { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Table? Table { get; set; }

    public virtual User? User { get; set; }
}
