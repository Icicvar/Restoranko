using Microsoft.AspNetCore.Mvc;

namespace RestorankoWebs.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
