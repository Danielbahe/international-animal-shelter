using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal
{
    public record UpdateAnimalCommandRequest : IRequest<Result<Animal>>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Species { get; init; }
        public string Description { get; init; }

        public UpdateAnimalCommandRequest(Guid id, string name, string species, string description)
        {
            Id = id;
            Name = name;
            Species = species;
            Description = description;
        }
    }
}
