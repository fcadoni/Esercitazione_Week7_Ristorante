using Microsoft.AspNetCore.Mvc;

namespace Ristorante.MVC.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
