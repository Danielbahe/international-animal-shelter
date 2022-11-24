using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal
{
    internal class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommandRequest, Response<Result<Animal>>>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ILogger logger;

        public UpdateAnimalCommandHandler(IAnimalsRepository animalRepository, ILogger logger)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
        }

        public async Task<Response<Result<Animal>>> Handle(UpdateAnimalCommandRequest command, CancellationToken cancellationToken)
        {
            var animalToUpdate = await animalRepository.GetByIdAsync(command.Id);
            if (animalToUpdate.IsFailure)
            {
                logger.Warning("Animal can't be updated: {e}", animalToUpdate.Error);
                return animalToUpdate.ToResponse(ResponseCode.NotFound);
            }

            var result = await UpdateAnimalAsync(command, animalToUpdate);

            return result.ToResponse(ResponseCode.Success);
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
