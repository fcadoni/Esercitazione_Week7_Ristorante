using Ristorante.Core.Entities;

namespace Ristorante.Core.BusinessLayer
{
    public interface IMainBusinessLayer
    {
        #region Dishes Functionalities
        public List<Dish> FetchDishes();
        public Result AddDish(Dish dish);
        public Result UpdateDish(Dish dish);
        public Result DeleteDish(Dish dish);
        #endregion
        #region Menus Functionalities
        public List<Menu> FetchMenus();
        public Result AddMenu(Menu menu);
        public Result UpdateMenu(Menu menu, Dish dish);
        public Result DeleteMenu(Menu menu);
        #endregion
        #region Admin Functionalities
        public List<Menu> FetchAdmins();
        public Result AddAdmin(Admin admin);
        public Result UpdateAdmin(Admin admin);
        public Result DeleteAdmin(Admin admin);
        #endregion
        #region User Functionalities
        public List<Menu> FetchUsers();
        public Result AddUser(User user);
        public Result UpdateUser(User user);
        public Result DeleteUser(User user);
        #endregion
    }
}