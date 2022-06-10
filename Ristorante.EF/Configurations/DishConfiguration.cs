using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.Configurations
{
    internal class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.KindOfDish).IsRequired();
            builder.Property(s => s.Price).IsRequired();


            //relazione piatti menu m : 1 (oppure 0)
            builder.HasOne(s => s.Menu).WithMany(c => c.Dishes).HasForeignKey(s => s.MenuId).IsRequired(false);
        }
    }
}
