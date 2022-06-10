using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Entities
{
    public class Admin : Person
    {
        [Column(TypeName = "datetime")]
        public DateTime HireDate { get; set; }
    }
}
