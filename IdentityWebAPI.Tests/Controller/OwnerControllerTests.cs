using FakeItEasy;
using FluentAssertions;
using IdentityWebAPI.Controllers;
using IdentityWebAPI.Models.DTO.Owner;
using IdentityWebAPI.Repository.Owner;

namespace IdentityWebAPI.Tests.Controller
{
    public class OwnerControllerTests
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerControllerTests()
        {
            _ownerRepository = A.Fake<IOwnerRepository>();
        }

        [Fact]
        public async Task OwnerController_GetOwners_ReturnOK()
        {
            //arrange
            var owners = A.Fake<List<OwnerDTO>>();
            CancellationToken cancellationToken = new CancellationToken();

            var controller = new OwnerController(_ownerRepository);
            //
            //act
            var result = await controller.GetAll(cancellationToken);

            //asset
            result.Should().NotBeNull();
            // var d = result.GetType();
            // result.Should().BeOfType(typeof(ServiceResponse<List<OwnerDTO>>));
        }
    }
}
