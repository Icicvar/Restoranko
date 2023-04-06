using System;
using System.Collections.Generic;

namespace RestorankoAPI.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Employment> Employments { get; } = new List<Employment>();

    public virtual ICollection<Guest> Guests { get; } = new List<Guest>();
}
