using Microsoft.EntityFrameworkCore;
using Ristorante.Core.Entities;
using Ristorante.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF
{
    public class RepositoryDishesEF : IRepositoryDishes
    {
        public Dish Add(Dish item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Dishes.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Dish item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Dishes.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Dish> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Dishes.ToList();

            }
        }

        public List<Dish> GetAllInMenu()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Dishes.Include(c => c.Menu).ToList();

            }
        }

        public Dish GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Dishes.FirstOrDefault(c => c.Id == id);

            }
        }

        public Dish InsertDishInMenu(Dish dish)
        {
            throw new NotImplementedException();
        }

        public Dish Update(Dish item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Dishes.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
