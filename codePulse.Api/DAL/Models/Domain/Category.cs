using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL.Models.Domain;

namespace DAL.Domain
{
    public class Category
    {
        private ICollection<Klip> _klips;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Register))]
        public Guid RegisterId { get; set; }
        public Register Register { get; set; }

        public IEnumerable<Klip> Klips => _klips;
    }
}
