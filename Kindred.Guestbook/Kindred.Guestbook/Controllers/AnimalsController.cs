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
        public async Task<IActionResult> GetAllAnimals()
        {
            var query = new GetAllAnimalsQuery();
            var result = await mediator.Send(query);

            var response = mapper.Map<IEnumerable<AnimalBasicInfoResponse>>(result);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalRequest request)
        {
            var command = mapper.Map<UpdateAnimalCommandRequest>(request);
            var result = await mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnimal([FromBody] DeleteAnimalRequest request)
        {
            var command = mapper.Map<DeleteAnimalCommandRequest>(request);
            var result = await mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
