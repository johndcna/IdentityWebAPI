using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityWebAPI.Data.Entities
{
    public class Note : IEntity
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public ICollection<Page> Pages { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
