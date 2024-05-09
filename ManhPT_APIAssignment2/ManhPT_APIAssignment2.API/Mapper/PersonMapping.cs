using AutoMapper;
using ManhPT_APIAssignment2.API.DTOs;
using ManhPT_APIAssignment2.Model;

namespace ManhPT_APIAssignment2.API.Mapper
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<PersonCreateDto, Person>();

        }
    }
}
