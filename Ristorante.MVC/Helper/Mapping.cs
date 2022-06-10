using Ristorante.Core.Entities;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Helper
{
    public static class Mapping
    {
        public static DishViewModel ToDishViewModel(this Dish dish)
        {
            return new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                KindOfDish = dish.KindOfDish,
                Price = dish.Price,
                MenuId = dish.MenuId
            };
        }
        public static Dish ToDish(this DishViewModel dishViewModel)
        {
            return new Dish
            {
                Id = dishViewModel.Id,
                Name = dishViewModel.Name,
                Description = dishViewModel.Description,
                KindOfDish = dishViewModel.KindOfDish,
                Price = dishViewModel.Price,
                MenuId = dishViewModel.MenuId
            };
        }
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            List<DishViewModel> dishViewModels = new List<DishViewModel>();

            foreach (var item in menu.Dishes)
            {
                dishViewModels.Add(item?.ToDishViewModel());
            }
            return new MenuViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Dishes = dishViewModels
            };
        }
        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            List<Dish> dishes = new List<Dish>();

            foreach (var item in menuViewModel.Dishes)
            {
                dishes.Add(item?.ToDish());
            }
            return new Menu
            {
                Id = menuViewModel.Id,
                Name = menuViewModel.Name,
                Dishes = dishes
            };
        }
    }
}
