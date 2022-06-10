using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Entities;
using Ristorante.MVC.Helper;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Controllers
{
    public class MenusController : Controller
    {
        private readonly IMainBusinessLayer BL;

        public MenusController(IMainBusinessLayer bl)
        {
            BL = bl;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Devo recuperare la lista di corsi dal mio repository,
            List<Menu> corsi = BL.FetchMenus();
            //trasformarla in una lista di corsiViewModel da passare alla vista
            List<MenuViewModel> corsiViewModel = new List<MenuViewModel>();
            foreach (var item in corsi)
            {
                corsiViewModel.Add(item.ToMenuViewModel());
            }

            //per visualizzarli in una tabella

            return View(corsiViewModel);
        }

        [HttpGet("Corsi/Details/{codice}")] //Corsi/Details/id
        public IActionResult Details(int id)
        {
            var corso = BL.FetchMenus().FirstOrDefault(c => c.Id == id);
            var corsoViewModel = corso.ToMenuViewModel();
            return View(corsoViewModel);
        }

        //[Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                //dobbiamo aggiungere il corsoViewModel al repository
                Menu menu = menuViewModel.ToMenu();
                Result result = BL.AddMenu(menu);
                if (result.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //visualizzo il messaggio d'errore in una pagina
                    ViewBag.ErrorMessage = result.Message;
                    return View("ErroriDiBusiness");
                }
            }
            return View(menuViewModel);
        }

        //[Authorize(Policy = "Adm")]
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var menu = BL.FetchMenus().FirstOrDefault(c => c.Id == id);
        //    var menuVM = menu.ToMenuViewModel();
        //    return View(menuVM);
        //}
        
        //[Authorize(Policy = "Adm")]
        //[HttpPost]
        //public IActionResult Edit(MenuViewModel menuViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var menu = menuViewModel.ToMenu();
        //        Result result = BL.UpdateMenu(menu);
        //        if (result.IsOk == true)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            ViewBag.ErrorMessage = result.Message;
        //            return View("ErroriDiBusiness");
        //        }
        //    }
        //    return View(menuViewModel);
        //}
        
        //[Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = BL.FetchMenus().FirstOrDefault(c => c.Id == id);
            var menuVM = menu.ToMenuViewModel();
            return View(menuVM);
        }
        //[Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Delete(MenuViewModel menuViewModel)
        {
            var menu = menuViewModel.ToMenu();
            Result esito = BL.DeleteMenu(menu);
            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = esito.Message;
                return View("ErroriDiBusiness");
            }

        }

        //private void LoadViewBag()
        //{
        //    List<Dish> dishes = BL.FetchDishes().Where(x => x.MenuId == null).ToList();
        //    ViewBag.Dishes = new SelectList(dishes);
        //}
    }
}
