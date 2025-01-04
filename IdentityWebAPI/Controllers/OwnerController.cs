using IdentityWebAPI.Models.DTO.Owner;
using IdentityWebAPI.Models;
using IdentityWebAPI.Repository.Owner;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OwnerDTO>>>> GetAll(CancellationToken cancellationToken)
        {
            var owners = await _ownerRepository.GetOwnersAsync(cancellationToken);
            return Ok(owners.Data);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _ownerRepository.GetOwnerAsync(id);

            if (!result.IsSuccessStatusCode)
            {
                return StatusCode((int)result.StatusCode, result.ServiceResponseMessage);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult> AddOwner([FromBody] CreateOwnerDTO data)
        {
            var result = await _ownerRepository.AddOwnerAsync(data);

            if (!result.IsSuccessStatusCode)
            {
                return StatusCode((int)result.StatusCode, result.ServiceResponseMessage);
            }

            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOwner([FromBody] UpdateOwnerDTO data, Guid id)
        {
            if (string.IsNullOrWhiteSpace(data.Name))
            {
                return BadRequest("Name is required.");
            }

            var result = await _ownerRepository.UpdateOwnerAsync(data, id);

            if (!result.IsSuccessStatusCode)
            {
                return StatusCode((int)result.StatusCode, result.ServiceResponseMessage);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOwner(Guid ownerId)
        {
            var result = await _ownerRepository.RemoveOwnerAsync(ownerId);

            if (!result.IsSuccessStatusCode)
            {
                return StatusCode((int)result.StatusCode, result.ServiceResponseMessage);
            }

            return Ok();
        }

    }
}
