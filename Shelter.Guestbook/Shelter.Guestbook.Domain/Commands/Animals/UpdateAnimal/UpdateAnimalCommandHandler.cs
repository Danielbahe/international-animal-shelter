using CSharpFunctionalExtensions;
using MediatR;
using Serilog;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.Domain.Commands.Animals.UpdateAnimal
{
    internal class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommandRequest, Result<Animal>>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ILogger logger;

        public UpdateAnimalCommandHandler(IAnimalsRepository animalRepository, ILogger logger)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
        }

        public async Task<Result<Animal>> Handle(UpdateAnimalCommandRequest command, CancellationToken cancellationToken)
        {
            var animalToUpdate = await GetAnimalByIdAsync(command.Id);
            return await UpdateAnimalAsync(command, animalToUpdate);
        }

        private async Task<Result<Animal>> GetAnimalByIdAsync(Guid id)
        {
            var animalToUpdate = await animalRepository.GetByIdAsync(id);
            if (animalToUpdate.IsFailure)
            {
                logger.Warning("Animal can't be updated: {e}", animalToUpdate.Error);
            }

            return animalToUpdate;
        }

        private async Task<Result<Animal>> UpdateAnimalAsync(UpdateAnimalCommandRequest command, Result<Animal> animalToUpdate)
        {
            var result = animalToUpdate.Value.Update(command);
            if (result.IsFailure)
            {
                logger.Warning("Animal can't be updated: {e}", result.Error);
                return result;
            }

            animalRepository.UpdateAnimal(animalToUpdate.Value);
            await animalRepository.SaveAsync();

            return animalToUpdate;
        }
    }
}
