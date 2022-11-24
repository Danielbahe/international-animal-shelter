using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Shelters
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateShelterCommandRequest, Response<Result<Shelter>>>
    {
        private readonly ISheltersRepository shelterRepository;
        private readonly ILogger logger;

        public UpdateAnimalCommandHandler(ISheltersRepository shelterRepository, ILogger logger)
        {
            this.shelterRepository = shelterRepository;
            this.logger = logger;
        }

        public async Task<Response<Result<Shelter>>> Handle(UpdateShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var shelterToUpdate = await shelterRepository.GetByIdAsync(command.Id);
            if (shelterToUpdate.IsFailure)
            {
                logger.Warning("Shelter can't be updated: {e}", shelterToUpdate.Error);
                return shelterToUpdate.ToResponse(ResponseCode.ValidationError);
            }

            return await UpdateAnimalAsync(command, shelterToUpdate);
        }

        private async Task<Response<Result<Shelter>>> UpdateAnimalAsync(UpdateShelterCommandRequest command, Result<Shelter> shelterToUpdate)
        {
            var result = shelterToUpdate.Value.Update(command);
            if (result.IsFailure)
            {
                logger.Warning("Shelter can't be updated: {e}", result.Error);
                return result.ToResponse(ResponseCode.ValidationError);
            }

            shelterRepository.UpdateShelter(shelterToUpdate.Value);
            await shelterRepository.SaveAsync();

            return shelterToUpdate.ToResponse(ResponseCode.Success);
        }
    }
}
