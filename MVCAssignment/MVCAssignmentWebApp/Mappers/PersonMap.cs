using AutoMapper;
using MVCAssignment.Model;
using MVCAssignment.Repository.DTOs;

namespace MVCAssignment.WebApp.Mappers
{
    public class PersonMap : Profile
    {
        public PersonMap()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}
