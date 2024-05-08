using AutoMapper;
using ManhPT_APIAssignment.API.Dtos;
using ManhPT_APIAssignment.Model;
namespace ManhPT_APIAssignment.Api.Mapper
{
    public class ExcerciseMapper : Profile
    {
        public ExcerciseMapper()
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoCreateDto, ToDo>();
        }
    }
}
