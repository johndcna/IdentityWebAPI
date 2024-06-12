using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityWebAPI.Data.Entities
{
    public class Attachment : IEntity
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        public Guid? PageId { get; set; }

        public Page? Page { get; set; }
    }
}
