using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Result>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

        public CreateUserCommandHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<Result> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = User.Create(request);

            if (user.IsFailure)
            {
                logger.Warning("User can't be created {e}", user.Error);
                return user;
            }

            userRepository.CreateUser(user.Value);
            await userRepository.SaveAsync();

            return user;
        }
    }
}
