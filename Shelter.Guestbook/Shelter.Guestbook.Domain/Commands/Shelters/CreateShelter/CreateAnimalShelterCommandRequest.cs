using CSharpFunctionalExtensions;
using MediatR;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.ValueObjects.Commands;

namespace Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter
{
    public record CreateAnimalShelterCommandRequest : IRequest<Result<AnimalShelter>>
    {
        public string Name { get; init; }
        public CreateAddressCommandRequest Address { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }

        public CreateAnimalShelterCommandRequest(string name, CreateAddressCommandRequest address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}