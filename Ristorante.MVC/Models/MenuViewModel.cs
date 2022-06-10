using System.ComponentModel.DataAnnotations;

namespace Ristorante.MVC.Models
{
    public class MenuViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<DishViewModel>? Dishes { get; set; } = new List<DishViewModel>();


    }
}