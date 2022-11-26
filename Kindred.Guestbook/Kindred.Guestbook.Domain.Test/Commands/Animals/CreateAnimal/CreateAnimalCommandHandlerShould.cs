using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Repositories;
using Moq;
using Serilog;
using Xunit;

namespace Kindred.Guestbook.Domain.Test.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandlerShould
    {
        [Theory]
        [InlineData("Lua", Species.Cat, "Is Cute", true)]
        [InlineData("", Species.None, "", false)]
        public async void ReturnSuccessfulResult(string name, Species species, string description, bool isSuccess)
        {
            var animalRepositoryMock = new Mock<IAnimalRepository>();
            var shelterRepositoryMock = new Mock<IShelterRepository>();
            var loggerMock = new Mock<ILogger>();

            var createAnimalCommand = new CreateAnimalCommandRequest(name, species, description, Guid.NewGuid(), ValueObjects.AnimalStatusValue.None);
            var handler = new CreateAnimalCommandHandler(animalRepositoryMock.Object, loggerMock.Object, shelterRepositoryMock.Object);

            var response = await handler.Handle(createAnimalCommand, CancellationToken.None);

            Assert.Equal(isSuccess, response.Result.IsSuccess);
        }
    }
}
