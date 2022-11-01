using CSharpFunctionalExtensions;
using MediatR;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Animals.CreateAnimal
{
    public record CreateAnimalCommandRequest : IRequest<Result<Animal>>
    {
        public string Name { get; init; }
        public string Species { get; init; }
        public string Description { get; init; }

        public CreateAnimalCommandRequest(string name, string species, string description)
        {
            Name = name;
            Species = species;
            Description = description;
        }
    }
}
