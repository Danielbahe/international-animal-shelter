using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal;
using Kindred.Guestbook.Domain.ValueObjects;
using Kindred.Infrastructure;

namespace Kindred.Guestbook.Domain.Entities
{
    public class Animal : Entity
    {
        public string Name { get; private set; }
        public string Species { get; private set; }
        public string Description { get; private set; }
        public Guid ShelterId { get; private set; }
        public AnimalStatus Status { get; private set; }

        private Animal()
        {
        }

        public static Result<Animal> Create(CreateAnimalCommandRequest command)
        {
            var animal = new Animal();

            return Constraints
                .AddResult(animal.SetName(command.Name))
                .AddResult(animal.SetSpecies(command.Species))
                .AddResult(animal.SetDescription(command.Description))
                .AddResult(animal.SetShelter(command.ShelterId))
                .AddResult(animal.SetStatus(command.Status))
                .CombineIn(animal);
        }

        public Result<Animal> Update(UpdateAnimalCommandRequest command)
        {
            return Constraints
                .AddResult(SetName(command.Name))
                .AddResult(SetSpecies(command.Species))
                .AddResult(SetDescription(command.Description))
                .AddResult(SetStatus(command.Status))
                .CombineIn(this);
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

        private Result<Animal> SetShelter(Guid shelterId)
        {
            if (shelterId.Equals(Guid.Empty)) return Result.Failure<Animal>("Shelter assigment is mandatory");
            ShelterId = shelterId;

            return Result.Success(this);
        }

        private Result<Animal> SetStatus(AnimalStatusValue newStatus)
        {
            Result<AnimalStatus> status;

            if (Status == null)
            {
                status = CreateAnimalStatus(newStatus);
            }
            else
            {
                status = Status.UpdateStatus(newStatus);
            }
            if (status.IsFailure)
            {
                return Result.Failure<Animal>(status.Error);
            }

            Status = status.Value;

            return Result.Success(this);

        }

        private Result<AnimalStatus> CreateAnimalStatus(AnimalStatusValue newStatus)
        {
            return newStatus switch
            {
                AnimalStatusValue.Adoptable => AnimalStatus.CreateAdoptable(),
                AnimalStatusValue.Lost => AnimalStatus.CreateLost(),
                _ => AnimalStatus.CreateAdoptable(),
            };
        }
    }    
}
