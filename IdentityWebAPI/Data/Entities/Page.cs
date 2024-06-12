using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityWebAPI.Data.Entities
{
    public class Page : IEntity
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(512)]
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Attachment> Attachments { get; set; }
    }
}
