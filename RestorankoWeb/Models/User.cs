using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RestorankoWeb.Models
{
    public class User
    {
        [Display(Name = "IDUser")]
        public int IDUser { get; set; }

        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter LastName")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }

        public List<User> Usersinfo { get; set; }

    }
}