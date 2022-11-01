using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Entities;
using Xunit;

namespace Kindred.Guestbook.Domain.Test.Entities
{
    public class AnimalShould
    {
        [Theory]
        [InlineData("", "Cat", "", true)]
        [InlineData("", "Cat", "Is cute", true)]
        [InlineData("Lua", "Cat", "", true)]
        [InlineData("Lua", "Cat", "Is cute", true)]
        [InlineData("", "", "", false)]
        [InlineData("Lua", "", "Is cute", false)]
        [InlineData("", "", "Is cute", false)]
        [InlineData("Lua", "", "", false)]
        [InlineData(null, " Cat", null, true)]
        [InlineData(null, "Cat", "Is cute", true)]
        [InlineData("Lua", "Cat", null, true)]
        [InlineData(null, null, null, false)]
        [InlineData("Lua", null, "Is cute", false)]
        [InlineData(null, null, "Is cute", false)]
        [InlineData("Lua", null, null, false)]

        public void CreateAnimalSuccessfully(string name, string species, string description, bool isSuccess)
        {
            var createAnimalCommand = new CreateAnimalCommandRequest(name, species, description);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal(animal.IsSuccess, isSuccess);
        }

        [Fact]
        public void SetDataProperly()
        {
            var createAnimalCommand = new CreateAnimalCommandRequest("Lua", "Cat", "Is Cute");

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal("Lua", animal.Value.Name);
            Assert.Equal("Cat", animal.Value.Species);
            Assert.Equal("Is Cute", animal.Value.Description);
        }
    }
}