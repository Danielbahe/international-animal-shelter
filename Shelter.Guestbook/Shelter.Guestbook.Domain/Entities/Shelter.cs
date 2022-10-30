using CSharpFunctionalExtensions;
using Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Shelter.Infrastructure;
using System.Reflection.Metadata;

namespace Shelter.Guestbook.Domain.Entities
{
    public class AnimalShelter : Entity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        private AnimalShelter()
        {
        }

        public static Result<AnimalShelter> Create(CreateAnimalShelterCommand command)
        {
            var shelter = new AnimalShelter();

            return Constraints
                .AddResult(shelter.SetName(command.Name))
                .AddResult(shelter.SetEmail(command.Email))
                .AddResult(shelter.SetAddress(command.Address))
                .CombineIn(shelter);
        }

        private Result<AnimalShelter> SetName(string name)
        {
            name = string.IsNullOrEmpty(name) ? string.Empty : name;
            Name = name.Trim();
            return Result.Success(this);
        }
    }
}
