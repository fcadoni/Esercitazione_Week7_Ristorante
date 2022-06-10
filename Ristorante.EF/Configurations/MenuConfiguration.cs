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
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();

            //relazione menu piatti 1: molti
            builder.HasMany(c => c.Dishes).WithOne(s => s.Menu).HasForeignKey(s => s.MenuId);

        }
    }
}
