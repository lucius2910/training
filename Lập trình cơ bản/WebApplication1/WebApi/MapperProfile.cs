using AutoMapper;
using Services.Entires;
using Services.Entities;
using Services.Request;
using Services.Response;

namespace WebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TodoRequest, Todo>()
                .ForMember(x => x.Title, des => des.MapFrom(x => x.head))
                .ForMember(x => x.Content, des => des.MapFrom(x => x.des));

            CreateMap<Todo, TodoResponse>()
                .ForMember(x => x.head1, des => des.MapFrom(x => x.Title))
                .ForMember(x => x.des1, des => des.MapFrom(x => x.Content))
                .ForMember(x => x.StartDate, des => des.MapFrom(x => x.StartDate.HasValue ? x.StartDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""))
                .ForMember(x => x.EndDate, des => des.MapFrom(x => x.EndDate.HasValue ? x.EndDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : ""));

        }
    }
}
