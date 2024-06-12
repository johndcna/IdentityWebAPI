using IdentityWebAPI.Models;
using IdentityWebAPI.Models.DTO.Owner;

namespace IdentityWebAPI.Repository.Owner
{
    public interface IOwnerRepository
    {
        Task<ServiceResponse<List<OwnerDTO>>> GetOwnersAsync(CancellationToken cancellationToken);
        Task<ServiceResponse<OwnerDTO>> GetOwnerAsync(Guid ownerId);
        Task<ServiceResponse<Guid>> AddOwnerAsync(CreateOwnerDTO createOwnerDTO);

        Task<ServiceResponse> RemoveOwnerAsync(Guid ownerId);
        Task<ServiceResponse> UpdateOwnerAsync(UpdateOwnerDTO updateOwnerDTO, Guid ownerId);
    }
}
