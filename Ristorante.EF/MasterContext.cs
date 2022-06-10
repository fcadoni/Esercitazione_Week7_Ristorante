using Microsoft.EntityFrameworkCore;
using Ristorante.Core.Entities;
using Ristorante.EF.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF
{
    public class MasterContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        public MasterContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ristorante;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Dish>(new DishConfiguration());
            modelBuilder.ApplyConfiguration<Menu>(new MenuConfiguration());
            modelBuilder.ApplyConfiguration<Admin>(new AdminConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        }
    }
}
