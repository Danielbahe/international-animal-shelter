using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.ValueObjects;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal
{
    public record CreateAnimalCommandRequest : IRequest<Result<Animal>>
    {
        public string Name { get; init; }
        public Species Species { get; init; }
        public string Description { get; init; }
        public Guid ShelterId { get; init; }
        public AnimalStatusValue Status { get; init; }

        public CreateAnimalCommandRequest(string name, Species species, string description, Guid shelterId, AnimalStatusValue status)
        {
            Name = name;
            Species = species;
            Description = description;
            ShelterId = shelterId;
            Status = status;
        }
    }
}
