using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Commands.Shelters;
using Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Kindred.Guestbook.Domain.ValueObjects;
using Kindred.Guestbook.Domain.ValueObjects.Commands;
using Kindred.Infrastructure;

namespace Kindred.Guestbook.Domain.Entities
{
    public class Shelter : Entity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public EmailAddress Email { get; private set; }

        private Shelter()
        {
        }

        public static Result<Shelter> Create(CreateShelterCommandRequest command)
        {
            var shelter = new Shelter();

            return Constraints
                .AddResult(shelter.SetName(command.Name))
                .AddResult(shelter.SetPhoneNumber(command.PhoneNumber))
                .AddResult(shelter.SetEmail(command.Email))
                .AddResult(shelter.SetAddress(command.Address))
                .CombineIn(shelter);
        }

        private Result<Shelter> SetName(string name)
        {
            name = string.IsNullOrEmpty(name) ? string.Empty : name;
            Name = name.Trim();
            return Result.Success(this);
        }

        private Result<Shelter> SetPhoneNumber(string phoneNumber)
        {
            var result = PhoneNumber.Create(phoneNumber);
            if (result.IsFailure)
            {
                return Result.Failure<Shelter>(result.Error);
            }

            PhoneNumber = result.Value;
            return Result.Success(this);
        }

        private Result<Shelter> SetEmail(string email)
        {
            var result = EmailAddress.Create(email);
            if (result.IsFailure)
            {
                return Result.Failure<Shelter>(result.Error);
            }

            Email = result.Value;
            return Result.Success(this);
        }

        private Result<Shelter> SetAddress(CreateAddressCommandRequest address)
        {
            var result = Address.Create(address);
            if (result.IsFailure)
            {
                return Result.Failure<Shelter>(result.Error);
            }

            Address = result.Value;
            return Result.Success(this);
        }

        public Result<Shelter> Update(UpdateShelterCommandRequest command)
        {
             return Constraints
                .AddResult(SetName(command.Name))
                .AddResultIf(!PhoneNumber.Equals(command.PhoneNumber), SetPhoneNumber(command.PhoneNumber))
                .AddResultIf(!Email.Equals(command.Email), SetEmail(command.Email))
                .AddResultIf(!Address.Equals(command.Address), SetAddress(command.Address))
                .CombineIn(this);
        }
    }
}
