using Shelter.Guestbook.Domain.Animals.CreateAnimal;
using Xunit;

namespace Shelter.Guestbook.Domain.Test.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandlerShould
    {
        [Theory]
        [InlineData("Lua","Cat","Is Cute", true)]
        [InlineData("","","", false)]
        public async void ReturnSuccessfulResult(string name, string species, string description, bool isSuccess)
        {
            var createAnimalCommand = new CreateAnimalCommand(name, species, description);
            var handler = new CreateAnimalCommandHandler();

            var result = await handler.Handle(createAnimalCommand, CancellationToken.None);

            Assert.Equal(isSuccess, result.IsSuccess);
        }
    }
}
