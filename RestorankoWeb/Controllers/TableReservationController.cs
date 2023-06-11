using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestorankoWeb.Controllers
{
    public class TableReservationController : Controller
    {
        // GET: TableReservation
        public ActionResult TablesList()
        {
            return View();
        }
    }
}