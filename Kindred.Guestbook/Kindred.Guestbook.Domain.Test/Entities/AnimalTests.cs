using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Entities;
using Xunit;

namespace Kindred.Guestbook.Domain.Test.Entities
{
    public class AnimalShould
    {
        [Theory]
        [InlineData("", Species.Cat, "", true, true)]
        [InlineData("", Species.Cat, "Is cute", true, true)]
        [InlineData("Lua", Species.Cat, "", true, true)]
        [InlineData("Lua", Species.Cat, "Is cute", true, true)]
        [InlineData("", Species.None, "", true, false)]
        [InlineData("Lua", null, "Is cute", true, false)]
        [InlineData("", Species.None, "Is cute", true, false)]
        [InlineData("Lua", Species.None, "", true, false)]
        [InlineData(null, Species.Cat, null, true, true)]
        [InlineData(null, Species.Cat, "Is cute", true, true)]
        [InlineData("Lua", Species.Cat, null, true, true)]
        [InlineData(null, null, null, true, false)]
        [InlineData("Lua", null, "Is cute", true, false)]
        [InlineData(null, null, "Is cute", true, false)]
        [InlineData("Lua", null, null, true, false)]
        [InlineData("Lua", Species.Cat, null, true, false)]
        [InlineData("Lua", Species.Cat, "Is cute", false, true)]

        public void CreateAnimalSuccessfully(string name, Species species, string description, bool validShelter, bool isSuccess)
        {
            var shelterId = validShelter ? Guid.NewGuid() : Guid.Empty;
            var createAnimalCommand = new CreateAnimalCommandRequest(name, species, description, shelterId, ValueObjects.AnimalStatusValue.None);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal(animal.IsSuccess, isSuccess);
        }

        [Fact]
        public void SetDataProperly()
        {
            var createAnimalCommand = new CreateAnimalCommandRequest("Lua", Species.Cat, "Is Cute", Guid.NewGuid(), ValueObjects.AnimalStatusValue.None);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal("Lua", animal.Value.Name);
            Assert.Equal(Species.Cat, animal.Value.Species);
            Assert.Equal("Is Cute", animal.Value.Description);
            Assert.True(ValueObjects.AnimalStatusValue.None == animal.Value.Status.Status);
            Assert.NotEqual(Guid.Empty, animal.Value.ShelterId);
        }
    }
}