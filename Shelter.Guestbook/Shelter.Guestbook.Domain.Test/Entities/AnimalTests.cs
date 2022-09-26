using Shelter.Guestbook.Domain.Animals.CreateAnimal;
using Shelter.Guestbook.Domain.Entities;
using Xunit;

namespace Shelter.Guestbook.Domain.Test.Entities
{
    public class AnimalShould
    {
        [Theory]
        [InlineData("","Cat","", true)]
        [InlineData("","Cat","Is cute", true)]
        [InlineData("Lua","Cat","", true)]
        [InlineData("Lua","Cat", "Is cute", true)]
        [InlineData("","","", false)]
        [InlineData("Lua","", "Is cute", false)]
        [InlineData("","", "Is cute", false)]
        [InlineData("Lua","", "", false)]
        public void CreateAnimalSuccessfully(string name, string species, string description, bool isSuccess)
        {
            var createAnimalCommand = new CreateAnimalCommand(name, species, description);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal(animal.IsSuccess, isSuccess);
        }

        [Fact]
        public void SetDataProperly()
        {
            var createAnimalCommand = new CreateAnimalCommand("Lua", "Cat", "Is Cute");

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal("Lua", animal.Value.Name);
            Assert.Equal("Cat", animal.Value.Species);
            Assert.Equal("Is Cute", animal.Value.Description);
        }
    }
}