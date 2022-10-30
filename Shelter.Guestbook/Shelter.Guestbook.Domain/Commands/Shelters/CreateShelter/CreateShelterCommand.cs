using CSharpFunctionalExtensions;
using MediatR;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter
{
    public record CreateAnimalShelterCommand : IRequest<Result<AnimalShelter>>
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public string PhoneNumber { get; init; }
        public string Email { get; init; }

        public CreateAnimalShelterCommand(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
