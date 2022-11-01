using CSharpFunctionalExtensions;
using Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Shelter.Guestbook.Domain.ValueObjects;
using Shelter.Guestbook.Domain.ValueObjects.Commands;
using Shelter.Infrastructure;
using System.Reflection.Metadata;

namespace Shelter.Guestbook.Domain.Entities
{
    public class AnimalShelter : Entity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public EmailAddress Email { get; private set; }

        private AnimalShelter()
        {
        }

        public static Result<AnimalShelter> Create(CreateAnimalShelterCommandRequest command)
        {
            var shelter = new AnimalShelter();

            return Constraints
                .AddResult(shelter.SetName(command.Name))
                .AddResult(shelter.SetPhoneNumber(command.PhoneNumber))
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

        private Result<AnimalShelter> SetPhoneNumber(string phoneNumber)
        {
            var result = PhoneNumber.Create(phoneNumber);
            if (result.IsFailure)
            {
                return Result.Failure<AnimalShelter>(result.Error);
            }

            PhoneNumber = result.Value;
            return Result.Success(this);
        }

        private Result<AnimalShelter> SetEmail(string email)
        {
            var result = EmailAddress.Create(email);
            if (result.IsFailure)
            {
                return Result.Failure<AnimalShelter>(result.Error);
            }

            Email = result.Value;
            return Result.Success(this);
        }

        private Result<AnimalShelter> SetAddress(CreateAddressCommandRequest address)
        {
            var result = Address.Create(address);
            if (result.IsFailure)
            {
                return Result.Failure<AnimalShelter>(result.Error);
            }

            Address = result.Value;
            return Result.Success(this);
        }
    }
}
