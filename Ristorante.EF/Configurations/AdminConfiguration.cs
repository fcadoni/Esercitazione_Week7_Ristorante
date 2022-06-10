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
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Amministratore");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.Username).IsRequired();
            builder.Property(s => s.EMail).IsRequired();
            builder.Property(s => s.BirthDate).IsRequired();
            builder.Property(s => s.Password).IsRequired();
            builder.Property(s => s.HireDate).IsRequired();
        }
    }
}
