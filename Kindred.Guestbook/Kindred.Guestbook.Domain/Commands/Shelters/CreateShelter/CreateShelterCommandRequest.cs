using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.ValueObjects.Commands;
using Kindred.Infrastructure;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter
{
    public record CreateShelterCommandRequest : IRequest<Response<Shelter>>
    {
        public string Name { get; init; }
        public CreateAddressCommandRequest Address { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }

        public CreateShelterCommandRequest(string name, CreateAddressCommandRequest address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}