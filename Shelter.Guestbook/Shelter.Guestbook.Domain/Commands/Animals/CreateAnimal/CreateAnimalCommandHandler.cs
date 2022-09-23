using CSharpFunctionalExtensions;
using MediatR;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Result<Animal>>
    {
        public async Task<Result<Animal>> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            //todo validate
            var animal = Animal.Create(request);
            if (animal.IsFailure)
            {
                //todo log
            }            
            //todo save Entity framework
            return await Task.FromResult(animal);
        }
    }
}
