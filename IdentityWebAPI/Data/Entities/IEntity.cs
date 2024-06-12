using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IdentityWebAPI.Data.Entities
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
