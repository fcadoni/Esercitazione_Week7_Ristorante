using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Entities;
using Ristorante.MVC.Helper;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Controllers
{
    public class DishesController : Controller
    {
        private readonly IMainBusinessLayer BL; //per collegarsi alle logiche di business

        public DishesController(IMainBusinessLayer bl)
        {
            BL = bl;
        }

        public IActionResult Index()
        {
            var dishes = BL.FetchDishes();
            List<DishViewModel> dishesViewModel = new List<DishViewModel>();
            foreach (var item in dishes)
            {
                dishesViewModel.Add(item.ToDishViewModel());
            }
            return View(dishesViewModel);
        }

        public IActionResult Details(int id)
        {
            var dish = BL.FetchDishes().FirstOrDefault(s => s.Id == id);
            var dishViewModel = dish.ToDishViewModel();
            return View(dishViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }


        [HttpPost]
        public IActionResult Create(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                var dish = dishViewModel.ToDish();
                var result = BL.AddDish(dish);
                if (result.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = result.Message;
                    return View("ErroriDiBusiness");
                }
            }
            else
            {
                LoadViewBag();
                return View(dishViewModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dish = BL.FetchDishes().FirstOrDefault(s => s.Id == id);
            var dishViewModel = dish.ToDishViewModel();
            LoadViewBag();
            return View(dishViewModel);
        }

        [HttpPost]
        public IActionResult Edit(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                var dish = dishViewModel.ToDish();
                var result = BL.UpdateDish(dish);
                if (result.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = result.Message;
                    return View("ErroriDiBusiness");
                }
            }
            LoadViewBag();
            return View(dishViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dish = BL.FetchDishes().FirstOrDefault(s => s.Id == id);
            var dishViewModel = dish.ToDishViewModel();
            return View(dishViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DishViewModel dishViewModel)
        {
            var dish = dishViewModel.ToDish();
            var result = BL.DeleteDish(dish);
            if (result.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = result.Message;
                return View("ErroriDiBusiness");
            }
        }

        private void LoadViewBag()
        {
            ViewBag.Categories = new SelectList(new[]
            {
                new{Value = Category.Primo, Text = "Primo Piatto"},
                new{Value = Category.Secondo, Text = "Secondo Piatto"},
                new{Value = Category.Contorno, Text = "Contorno"},
                new{Value = Category.Dolce, Text = "Dolce"}
            }.OrderBy(x => x.Value), "Value", "Text");
        }
    }
}
