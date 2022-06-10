using Ristorante.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ristorante.MVC.Models
{
    public class DishViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Category KindOfDish { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int? MenuId { get; set; }
        public MenuViewModel? Menu { get; set; }
    }
}
