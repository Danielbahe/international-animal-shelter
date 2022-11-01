using CSharpFunctionalExtensions;
using Shelter.Guestbook.Domain.Animals.CreateAnimal;
using Shelter.Guestbook.Domain.Commands.Animals.UpdateAnimal;
using Shelter.Infrastructure;

namespace Shelter.Guestbook.Domain.Entities
{
    public class Animal : Entity
    {
        public string Name { get; private set; }
        public string Species { get; private set; }
        public string Description { get; private set; }

        public Animal()
        {
        }

        public static Result<Animal> Create(CreateAnimalCommandRequest command)
        {
            var animal = new Animal();

            return Constraints
                .AddResult(animal.SetName(command.Name))
                .AddResult(animal.SetSpecies(command.Species))
                .AddResult(animal.SetDescription(command.Description))
                .CombineIn(animal);
        }

        public Result<Animal> Update(UpdateAnimalCommandRequest command)
        {
            return Constraints
                .AddResult(SetName(command.Name))
                .AddResult(SetSpecies(command.Species))
                .AddResult(SetDescription(command.Description))
                .CombineIn(this);
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        private Result<Animal> SetName(string name)
        {
            name = string.IsNullOrEmpty(name) ? string.Empty : name;
            Name = name.Trim();
            return Result.Success(this);
        }

        private Result<Animal> SetDescription(string description)
        {
            description = string.IsNullOrEmpty(description) ? string.Empty : description;
            Description = description.Trim();
            return Result.Success(this);
        }

        private Result<Animal> SetSpecies(string species)
        {
            if (string.IsNullOrEmpty(species))
            {
                return Result.Failure<Animal>("Species cannot be empty");
            }
            
            Species = species.Trim();
            return Result.Success(this);
        }
    }
}
