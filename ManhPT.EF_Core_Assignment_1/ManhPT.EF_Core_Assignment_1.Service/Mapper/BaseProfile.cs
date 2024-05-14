using AutoMapper;

namespace ManhPT.EF_Core_Assignment_1.Service.Mapper
{
    public abstract class BaseProfile<TEntity, TEntityDto, TEntityCreateDto> : Profile where TEntity : class
    {
        public BaseProfile()
        {
            CreateMap<TEntity, TEntityDto>();
            CreateMap<TEntityDto, TEntity>();
            CreateMap<TEntityCreateDto, TEntity>();
        }
    }
}
