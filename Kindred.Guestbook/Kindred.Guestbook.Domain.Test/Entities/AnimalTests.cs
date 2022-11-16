using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Entities;
using Xunit;

namespace Kindred.Guestbook.Domain.Test.Entities
{
    public class AnimalShould
    {
        [Theory]
        [InlineData("", "Cat", "", true, true)]
        [InlineData("", "Cat", "Is cute", true, true)]
        [InlineData("Lua", "Cat", "", true, true)]
        [InlineData("Lua", "Cat", "Is cute", true, true)]
        [InlineData("", "", "", true, false)]
        [InlineData("Lua", "", "Is cute", true, false)]
        [InlineData("", "", "Is cute", true, false)]
        [InlineData("Lua", "", "", true, false)]
        [InlineData(null, " Cat", null, true, true)]
        [InlineData(null, "Cat", "Is cute", true, true)]
        [InlineData("Lua", "Cat", null, true, true)]
        [InlineData(null, null, null, true, false)]
        [InlineData("Lua", null, "Is cute", true, false)]
        [InlineData(null, null, "Is cute", true, false)]
        [InlineData("Lua", null, null, true, false)]
        [InlineData("Lua", "Cat", null, true, false)]
        [InlineData("Lua", "Cat", "Is cute", false, true)]

        public void CreateAnimalSuccessfully(string name, string species, string description, bool validShelter, bool isSuccess)
        {
            var shelterId = validShelter ? Guid.NewGuid() : Guid.Empty;
            var createAnimalCommand = new CreateAnimalCommandRequest(name, species, description, shelterId);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal(animal.IsSuccess, isSuccess);
        }

        [Fact]
        public void SetDataProperly()
        {
            var createAnimalCommand = new CreateAnimalCommandRequest("Lua", "Cat", "Is Cute", Guid.NewGuid());

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal("Lua", animal.Value.Name);
            Assert.Equal("Cat", animal.Value.Species);
            Assert.Equal("Is Cute", animal.Value.Description);
            Assert.NotEqual(Guid.Empty, animal.Value.ShelterId);
        }
    }
}