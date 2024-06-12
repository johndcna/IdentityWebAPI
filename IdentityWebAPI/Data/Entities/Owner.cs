using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace IdentityWebAPI.Data.Entities
{
    public class Owner : IEntity
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }

    
    }
}
