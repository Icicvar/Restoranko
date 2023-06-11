using RestorankoWeb.Dao;
using RestorankoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RestorankoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository repository;

        public HomeController()
        {
            repository = new Repository();
        }
        // GET: Home
        [HttpGet]
        public async Task<ActionResult> Welcome()
        {
            IEnumerable<User> users = await repository.GetAllUsers();
            return View(users);
        }

    }
}