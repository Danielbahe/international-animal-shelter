using AutoMapper;
using Shelter.Guestbook.Api.Dto;
using Shelter.Guestbook.Api.Models;
using Shelter.Guestbook.Domain.Animals.CreateAnimal;
using Shelter.Guestbook.Domain.Commands.Animals.DeleteAnimal;
using Shelter.Guestbook.Domain.Commands.Animals.UpdateAnimal;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Api.Profiles
{
    public class AnimalsProfile : Profile
    {
        public AnimalsProfile()
        {
            CreateMap<Animal, AnimalBasicInfoResponse>();

            CreateMap<CreateAnimalRequest, CreateAnimalCommand>();
            CreateMap<UpdateAnimalRequest, UpdateAnimalCommand>();
            CreateMap<DeleteAnimalRequest, DeleteAnimalCommand>();
        }
    }
}
