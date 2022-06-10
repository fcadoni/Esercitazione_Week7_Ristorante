using System.ComponentModel.DataAnnotations.Schema;

namespace Ristorante.Core.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        public ICollection<Dish>? Dishes { get; set; } = new List<Dish>();

        
    }
}