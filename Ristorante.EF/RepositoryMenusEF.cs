using Ristorante.Core.Entities;
using Ristorante.Core.Interfaces;

namespace Ristorante.EF
{
    public class RepositoryMenusEF : IRepositoryMenus
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menus.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menus.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menus.ToList();

            }
        }

        public Menu GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menus.FirstOrDefault(c => c.Id == id);

            }
        }

        public List<Dish> MenuDetails(Menu menu)
        {
            using (var ctx = new MasterContext())
            {
                return menu.Dishes.ToList();
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menus.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}