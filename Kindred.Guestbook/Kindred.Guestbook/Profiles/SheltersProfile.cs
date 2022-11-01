using AutoMapper;
using Kindred.Guestbook.Api.Models.Shelter;
using Kindred.Guestbook.Domain.Commands.Shelters;
using Kindred.Guestbook.Domain.Commands.Shelters.CreateShelter;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.ValueObjects.Commands;

namespace Kindred.Guestbook.Api.Profiles
{
    public class SheltersProfile : Profile
    {
        public SheltersProfile()
        {

            CreateMap<CreateShelterRequest, CreateShelterCommandRequest>();
            CreateMap<CreateAddressRequest, CreateAddressCommandRequest>();

            CreateMap<UpdateShelterRequest, UpdateShelterCommandRequest>();
            CreateMap<DeleteShelterRequest, DeleteShelterCommandRequest>();

            CreateMap<Shelter, ShelterBasicInfoResponse>();
        }
    }
}
