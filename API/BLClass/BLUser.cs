using API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.BLClass
{
    public class BLUser
    {
        public int Iduser { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int? UserTypeId { get; set; }

        public virtual UserType? UserType { get; set; }
    }
}
