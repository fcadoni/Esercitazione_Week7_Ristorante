using Microsoft.AspNetCore.Mvc;

namespace Ristorante.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
