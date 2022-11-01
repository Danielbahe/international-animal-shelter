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
        [InlineData("Lua", "Cat", "Is Cute", true)]
        [InlineData("", "", "", false)]
        public async void ReturnSuccessfulResult(string name, string species, string description, bool isSuccess)
        {
            var animalRepositoryMock = new Mock<IAnimalsRepository>();
            var loggerMock = new Mock<ILogger>();

            var createAnimalCommand = new CreateAnimalCommandRequest(name, species, description);
            var handler = new CreateAnimalCommandHandler(animalRepositoryMock.Object, loggerMock.Object);

            var result = await handler.Handle(createAnimalCommand, CancellationToken.None);

            Assert.Equal(isSuccess, result.IsSuccess);
        }
    }
}
