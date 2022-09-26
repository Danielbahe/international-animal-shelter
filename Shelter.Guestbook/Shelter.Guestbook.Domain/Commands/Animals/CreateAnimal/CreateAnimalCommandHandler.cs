using CSharpFunctionalExtensions;
using MediatR;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.Domain.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, Result<Animal>>
    {
        private readonly IAnimalsRepository animalRepository;

        public CreateAnimalCommandHandler(IAnimalsRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public async Task<Result<Animal>> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var animal = Animal.Create(request);
            if (animal.IsFailure)
            {
                //todo log
                return animal;
            }

            animalRepository.AddAnimal(animal.Value);
            await animalRepository.SaveAsync();

            return animal;
        }
    }
}
