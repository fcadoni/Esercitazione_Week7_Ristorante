using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Username { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string EMail { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Password { get; set; }

    }
}
