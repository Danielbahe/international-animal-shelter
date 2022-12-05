using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal;
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
        [InlineData("Lua", Species.None, "Is cute", true, false)]
        [InlineData("", Species.None, "Is cute", true, false)]
        [InlineData("Lua", Species.None, "", true, false)]
        [InlineData(null, Species.Cat, null, true, true)]
        [InlineData(null, Species.Cat, "Is cute", true, true)]
        [InlineData("Lua", Species.Cat, null, true, true)]
        [InlineData(null, Species.None, null, true, false)]
        [InlineData(null, Species.None, "Is cute", true, false)]
        [InlineData("Lua", Species.None, null, true, false)]
        [InlineData("Lua", Species.Cat, "Is cute", false, false)]

        public void CreateAnimalSuccessfully(string name, Species species, string description, bool validShelter, bool isSuccess)
        {
            var shelterId = validShelter ? Guid.NewGuid() : Guid.Empty;
            var createAnimalCommand = new CreateAnimalCommandRequest(name, species, description, shelterId, ValueObjects.AnimalStatusValue.Lost);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal(animal.IsSuccess, isSuccess);
        }

        [Fact]
        public void SetDataProperly()
        {
            var createAnimalCommand = new CreateAnimalCommandRequest("Lua", Species.Cat, "Is Cute", Guid.NewGuid(), ValueObjects.AnimalStatusValue.Lost);

            var animal = Animal.Create(createAnimalCommand);

            Assert.Equal("Lua", animal.Value.Name);
            Assert.Equal(Species.Cat, animal.Value.Species);
            Assert.Equal("Is Cute", animal.Value.Description);
            Assert.True(ValueObjects.AnimalStatusValue.Lost == animal.Value.Status.Status);
            Assert.NotEqual(Guid.Empty, animal.Value.ShelterId);
        }

        [Fact]
        public void ShouldUpdateDataProperly()
        {
            var createAnimalCommand = new CreateAnimalCommandRequest("Lua", Species.Cat, "Is cute", Guid.NewGuid(), ValueObjects.AnimalStatusValue.Lost);
            var animal = Animal.Create(createAnimalCommand);

            var updateAnimalCommand = new UpdateAnimalCommandRequest(animal.Value.Id, "Leo", Species.Dog, "Is funny", ValueObjects.AnimalStatusValue.Found);
            animal.Value.Update(updateAnimalCommand);

            Assert.True(animal.IsSuccess);
            Assert.NotEqual(animal.Value.Name, createAnimalCommand.Name);
            Assert.NotEqual(animal.Value.Species, createAnimalCommand.Species);
            Assert.NotEqual(animal.Value.Description, createAnimalCommand.Description);
            Assert.False(animal.Value.Status.Status == createAnimalCommand.Status);
        }

        [Fact]
        public void BeSoftDeleted()
        {
            var createAnimalCommand = new CreateAnimalCommandRequest("Lua", Species.Cat, "Is Cute", Guid.NewGuid(), ValueObjects.AnimalStatusValue.Lost);
            var animal = Animal.Create(createAnimalCommand);

            animal.Value.Delete();

            Assert.True(animal.Value.IsDeleted);
        }
    }
}