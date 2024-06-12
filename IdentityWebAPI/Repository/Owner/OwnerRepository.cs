using AutoMapper;
using AutoMapper.Execution;
using IdentityWebAPI.Data;
using IdentityWebAPI.Data.Entities;
using IdentityWebAPI.Models;
using IdentityWebAPI.Models.DTO.Owner;
using IdentityWebAPI.Repository.Owner;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CenamonWebAPI.Repository.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _dataContext;
        private readonly IMapper _mapper;
        public OwnerRepository(ApplicationDbContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;

        }

        public async Task<ServiceResponse<Guid>> AddOwnerAsync(CreateOwnerDTO createOwnerDTO)
        {
            try
            {
                var owner = new Owner()
                {
                    Id = new Guid(),
                    Name = createOwnerDTO.Name
                };



                var ownerEntity = await _dataContext.Owners.AddAsync(owner);
                await _dataContext.SaveChangesAsync();

                return new ServiceResponse<Guid>(HttpStatusCode.OK)
                {
                    Data = ownerEntity.Entity.Id
                };
            }
            catch (Exception e)
            {
                var message = $"{nameof(OwnerRepository)} - {nameof(GetOwnersAsync)} - {e.Message}";

                return new ServiceResponse<Guid>(HttpStatusCode.InternalServerError);
            }


        }

        public async Task<ServiceResponse<OwnerDTO>> GetOwnerAsync(Guid ownerId)
        {
            try
            {
                var owner = await _dataContext.Owners.FirstOrDefaultAsync(x => x.Id == ownerId);

                if (owner == null)
                {
                    return new ServiceResponse<OwnerDTO>(HttpStatusCode.InternalServerError);
                }


                return new ServiceResponse<OwnerDTO> (HttpStatusCode.OK)
                {
                    Data = _mapper.Map<OwnerDTO>(owner)

                };
            }
            catch (Exception e)
            {
                var message = $"{nameof(OwnerRepository)} - {nameof(GetOwnersAsync)} - {e.Message}";

                return new ServiceResponse<OwnerDTO>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ServiceResponse<List<OwnerDTO>>> GetOwnersAsync(CancellationToken cancellationToken)          
        {
            try 
            {              
                var owners = await _dataContext.Owners
                                    .Include(c => c.Notes)
                                    .ToListAsync(cancellationToken);
               

                return new ServiceResponse<List<OwnerDTO>>(HttpStatusCode.OK)
                {
                    Data = owners.Select(o => _mapper.Map<OwnerDTO>(o)).ToList()

                 };

            }
            catch (Exception e) 
            {
                var message = $"{nameof(OwnerRepository)} - {nameof(GetOwnersAsync)} - {e.Message}";

                return new ServiceResponse<List<OwnerDTO>>(HttpStatusCode.InternalServerError, "There was an error getting the event types.");
            }
        }

        public async Task<ServiceResponse> RemoveOwnerAsync(Guid ownerId)
        {
            try
            {
                var owner = await _dataContext.Owners
                                    .Include(c => c.Notes).FirstOrDefaultAsync(x => x.Id == ownerId);

                if (owner == null)
                {
                    return new ServiceResponse(HttpStatusCode.InternalServerError);
                }

                _dataContext.Owners.RemoveRange(owner);


                await _dataContext.SaveChangesAsync();

                return new ServiceResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                var message = $"{nameof(OwnerRepository)} - {nameof(GetOwnersAsync)} - {e.Message}";

                return new ServiceResponse<Guid>(HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ServiceResponse> UpdateOwnerAsync(UpdateOwnerDTO updateOwnerDTO, Guid ownerId)
        {
            try
            {
                var owner = await _dataContext.Owners.FirstOrDefaultAsync(x => x.Id == ownerId);

                if (owner == null)
                {
                    return new ServiceResponse(HttpStatusCode.InternalServerError);
                }

               owner.Name = updateOwnerDTO.Name;


                await _dataContext.SaveChangesAsync();

                return new ServiceResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                var message = $"{nameof(OwnerRepository)} - {nameof(GetOwnersAsync)} - {e.Message}";

                return new ServiceResponse<Guid>(HttpStatusCode.InternalServerError);
            }
        }
    }
}
