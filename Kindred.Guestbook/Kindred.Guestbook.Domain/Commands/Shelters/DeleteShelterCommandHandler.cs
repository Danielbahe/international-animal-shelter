using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Shelters
{
    internal class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommandRequest, Response>
    {
        private readonly ISheltersRepository shelterRepository;
        private readonly ILogger logger;

        public DeleteShelterCommandHandler(ISheltersRepository shelterRepository, ILogger logger)
        {
            this.shelterRepository = shelterRepository;
            this.logger = logger;
        }

        public async Task<Response> Handle(DeleteShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var shelterToDelete = await shelterRepository.GetByIdAsync(command.Id);
            if (shelterToDelete.IsFailure)
            {
                logger.Warning("Shelter can't be deleted: {e}", shelterToDelete.Error);
                return Result.Failure(shelterToDelete.Error).ToResponse(ResponseCode.NotFound);
            }

            await DeleteShelterAsync(shelterToDelete.Value);

            return Result.Success().ToResponse(ResponseCode.Success);
        }

        private async Task DeleteShelterAsync(Shelter ShelterToDelete)
        {
            ShelterToDelete.Delete();
            shelterRepository.DeleteShelter(ShelterToDelete);
            await shelterRepository.SaveAsync();
        }
    }
}
