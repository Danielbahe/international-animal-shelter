using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.ValueObjects;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal
{
    public record UpdateAnimalCommandRequest : IRequest<Result<Animal>>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public Species Species { get; init; }
        public string Description { get; init; }
        public AnimalStatusValue Status { get; init; }

        public UpdateAnimalCommandRequest(Guid id, string name, Species species, string description, AnimalStatusValue status)
        {
            Id = id;
            Name = name;
            Species = species;
            Description = description;
            Status = status;
        }
    }
}
