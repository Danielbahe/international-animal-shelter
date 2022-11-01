using CSharpFunctionalExtensions;
using Shelter.Guestbook.Domain.ValueObjects.Commands;
using Shelter.Infrastructure;

namespace Shelter.Guestbook.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }

        private Address()
        {
        }

        public static Result<Address> Create(CreateAddressCommandRequest command)
        {
            var address = new Address();
            return Constraints
                .AddResult(address.SetStreet(command.Street))
                .AddResult(address.SetCity(command.Street))
                .AddResult(address.SetZipCode(command.Street))
                .AddResult(address.SetCountry(command.Street))
                .AddResult(address.SetState(command.Street))
                .CombineIn(address);
        }

        private Result<Address> SetStreet(string street)
        {
            street = street.Trim();
            if (string.IsNullOrEmpty(street))
            {
                return Result.Failure<Address>("Street can't be empty");
            }

            Street = street;
            return Result.Success(this);
        }

        private Result<Address> SetCity(string city)
        {
            city = city.Trim();
            if (string.IsNullOrEmpty(city))
            {
                return Result.Failure<Address>("Street can't be empty");
            }

            City = city;
            return Result.Success(this);
        }

        private Result<Address> SetZipCode(string zipCode)
        {
            zipCode = zipCode.Trim();
            if (string.IsNullOrEmpty(zipCode))
            {
                return Result.Failure<Address>("Street can't be empty");
            }

            ZipCode = zipCode;
            return Result.Success(this);
        }

        private Result<Address> SetCountry(string country)
        {
            country = country.Trim();
            if (string.IsNullOrEmpty(country))
            {
                return Result.Failure<Address>("Street can't be empty");
            }

            Country = country;
            return Result.Success(this);
        }

        private Result<Address> SetState(string state)
        {
            state = state.Trim();
            if (string.IsNullOrEmpty(state))
            {
                return Result.Failure<Address>("Street can't be empty");
            }

            State = state;
            return Result.Success(this);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
