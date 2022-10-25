using CSharpFunctionalExtensions;
using MediatR;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Commands.Animals.UpdateAnimal
{
    public record UpdateAnimalCommand : IRequest<Result<Animal>>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Species { get; init; }
        public string Description { get; init; }

        public UpdateAnimalCommand(Guid id, string name, string species, string description)
        {
            Id = id;
            Name = name;
            Species = species;
            Description = description;
        }
    }
}
