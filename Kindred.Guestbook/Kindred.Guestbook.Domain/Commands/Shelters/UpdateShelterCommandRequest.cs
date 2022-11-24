using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.ValueObjects.Commands;
using Kindred.Infrastructure;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Shelters
{
    public class UpdateShelterCommandRequest : IRequest<Response<Shelter>>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public CreateAddressCommandRequest Address { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }

        public UpdateShelterCommandRequest(Guid id, string name, CreateAddressCommandRequest address, string phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
