using AutoMapper;
using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.DeleteAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kindred.Guestbook.Domain.Queries.Animals;
using Kindred.Guestbook.Api.Models.Animal;

namespace Kindred.Guestbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AnimalsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalRequest request)
        {
            var command = mapper.Map<CreateAnimalCommandRequest>(request);
            var response = await mediator.Send(command);
            return MapToHttpResponse(response, nameof(CreateAnimal), response.Result.Value.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await mediator.Send(new GetAllAnimalsQuery());

            return Ok(mapper.Map<IEnumerable<AnimalBasicInfoResponse>>(animals));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalRequest request)
        {
            var command = mapper.Map<UpdateAnimalCommandRequest>(request);
            var response = await mediator.Send(command);

            return MapToHttpResponse(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnimal([FromBody] DeleteAnimalRequest request)
        {
            var command = mapper.Map<DeleteAnimalCommandRequest>(request);
            var response = await mediator.Send(command);

            return MapToHttpResponse(response);
        }
    }
}
