using AutoMapper;
using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.DeleteAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kindred.Guestbook.Domain.Queries.Animals;
using Kindred.Guestbook.Api.Models.Animal;
using Kindred.Infrastructure;

namespace Kindred.Guestbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AnimalsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IResult> CreateAnimal([FromBody] CreateAnimalRequest request)
        {
            var command = mapper.Map<CreateAnimalCommandRequest>(request);
            var response = await mediator.Send(command);

            return response.ToHttpResponse(nameof(CreateAnimal));
        }

        [HttpGet]
        public async Task<IResult> GetAllAnimals()
        {
            var result = await mediator.Send(new GetAllAnimalsQuery());

            return Results.Ok(mapper.Map<IEnumerable<AnimalBasicInfoResponse>>(result));            
        }

        [HttpPut]
        public async Task<IResult> UpdateAnimal([FromBody] UpdateAnimalRequest request)
        {
            var command = mapper.Map<UpdateAnimalCommandRequest>(request);
            var response = await mediator.Send(command);

            return response.ToHttpResponse(nameof(UpdateAnimal));
        }

        [HttpDelete]
        public async Task<IResult> DeleteAnimal([FromBody] DeleteAnimalRequest request)
        {
            var command = mapper.Map<DeleteAnimalCommandRequest>(request);
            var response = await mediator.Send(command);

            return response.ToHttpResponse(nameof(DeleteAnimal));
        }
    }
}
