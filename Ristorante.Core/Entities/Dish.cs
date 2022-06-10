using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public Category KindOfDish { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int? MenuId { get; set; }
        public Menu? Menu { get; set; }
    }

    public enum Category
    {
        Primo = 1,
        Secondo,
        Contorno,
        Dolce
    }
}
