using CSharpFunctionalExtensions;
using MediatR;

namespace Shelter.Guestbook.Domain.Commands.Animals.DeleteAnimal
{
    public record DeleteAnimalCommand : IRequest<Result>
    {
        public Guid Id { get; init; }

        public DeleteAnimalCommand(Guid id)
        {
            Id = id;
        }
    }
}
