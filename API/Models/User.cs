using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? UserTypeId { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Reservation> ReservationEmployees { get; set; } = new List<Reservation>();

    public virtual ICollection<Reservation> ReservationGuests { get; set; } = new List<Reservation>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual UserType? UserType { get; set; }
}
