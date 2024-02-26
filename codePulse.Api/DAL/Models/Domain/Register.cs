using DAL.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Register
    {
        private  ICollection<Klip> _klips;
        private ICollection<Category> _categories;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public IEnumerable<Klip> Klips => _klips;
        public IEnumerable<Category> Categories => _categories;

    }
}