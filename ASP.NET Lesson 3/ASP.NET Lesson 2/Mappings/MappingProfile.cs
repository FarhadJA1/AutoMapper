using ASP.NET_Lesson_2.Dtos.ClientDtos;
using ASP.NET_Lesson_2.Models;
using AutoMapper;

namespace ASP.NET_Lesson_2.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client,ClientDto>();
        CreateMap<Computer, ClientsComputerDto>();
        CreateMap<Client, ClientCreateDto>().ReverseMap();
    }
}
