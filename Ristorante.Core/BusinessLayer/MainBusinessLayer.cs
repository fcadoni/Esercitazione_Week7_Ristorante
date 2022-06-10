using Ristorante.Core.Entities;
using Ristorante.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IRepositoryDishes dishesRepo;
        private readonly IRepositoryMenus menusRepo;

        public MainBusinessLayer(IRepositoryDishes dishesRepo, IRepositoryMenus menusRepo)
        {
            this.dishesRepo = dishesRepo;
            this.menusRepo = menusRepo;
        }

        #region Dishes Functionalities

        public List<Dish> FetchDishes()
        {
            return dishesRepo.Fetch();
        }
        public Result AddDish(Dish dish)
        {
            Dish alreadyInTableDish = dishesRepo.GetById(dish.Id);
            if (alreadyInTableDish == null)
            {
                return new Result { Message = "Id del piatto errato", IsOk = false };
            }
            dishesRepo.Add(dish);

            return new Result { Message = "Piatto inserito correttamente", IsOk = true };
        }
        public Result UpdateDish(Dish dish)
        {
            Dish alreadyInTableDish = dishesRepo.GetById(dish.Id);
            if (alreadyInTableDish == null)
            {
                return new Result { Message = "Il piatto che cerchi non esiste", IsOk = false };
            }
            Menu availableMenu = menusRepo.GetById(dish.Menu.Id);
            if (availableMenu == null)
            {
                return new Result { Message = "Il menu che cerchi non esiste", IsOk = false };
            }
            dish.MenuId = availableMenu.Id;
            dishesRepo.Update(dish);
            UpdateMenu(availableMenu, dish);
            return new Result { Message = $"Piatto associato correttamente al menu {dish.Menu.Name}", IsOk = true };
        }
        public Result DeleteDish(Dish dish)
        {
            var alreadyInTableDish = dishesRepo.GetById(dish.Id);
            if (alreadyInTableDish == null)
            {
                return new Result { Message = "Il piatto che cerchi non esiste", IsOk = false };
            }
            dishesRepo.Delete(alreadyInTableDish);
            return new Result { Message = "Piatto eliminato correttamente", IsOk = true };
        }
        #endregion
        #region Menus Functionalities
        public List<Menu> FetchMenus()
        {
            return menusRepo.Fetch();
        }

        public Result AddMenu(Menu menu)
        {
            Menu alreadyInTableMenu = menusRepo.GetById(menu.Id);
            if (alreadyInTableMenu == null)
            {
                return new Result { Message = "Id del menu errato", IsOk = false };
            }
            menusRepo.Add(menu);

            return new Result { Message = "Menu inserito correttamente", IsOk = true };
        }
        public Result UpdateMenu(Menu menu, Dish dish)
        {
            Dish alreadyInTableDish = dishesRepo.GetById(dish.Id);
            if (alreadyInTableDish == null)
            {
                return new Result { Message = "Il piatto che cerchi non esiste", IsOk = false };
            }
            Menu availableMenu = menusRepo.GetById(menu.Id);
            if (availableMenu == null)
            {
                return new Result { Message = "Il menu che cerchi non esiste", IsOk = false };
            }
            menu.Dishes.Add(dish);

            return new Result { Message = $"Piatto aggiunto correttamente al menu {menu.Name}", IsOk = true };
        }

        public Result DeleteMenu(Menu menu)
        {
            var alreadyInTableMenu = menusRepo.GetById(menu.Id);
            if (alreadyInTableMenu == null)
            {
                return new Result { Message = "Il menu che cerchi non esiste", IsOk = false };
            }
            menusRepo.Delete(alreadyInTableMenu);
            return new Result { Message = "Menu eliminato correttamente", IsOk = true };
        }



        #endregion
        #region Admin Functionalities
        public List<Menu> FetchAdmins()
        {
            throw new NotImplementedException();
        }

        public Result AddAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Result UpdateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Result DeleteAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region User Functionalities
        public List<Menu> FetchUsers()
        {
            throw new NotImplementedException();
        }

        public Result AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Result UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Result DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
