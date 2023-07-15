using AutoMapper;
using ToDoApp_N_tier.Dtos.WorkDtos;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.Business.Mappings.AutoMapper
{
    public class WorkProfile:Profile
    {
        public WorkProfile()
        {
            CreateMap<Work,WorkListDto>().ReverseMap();
            CreateMap<Work,WorkCreateDto>().ReverseMap();
            CreateMap<Work,WorkUpdateDto>().ReverseMap();
            CreateMap<WorkUpdateDto, WorkListDto>().ReverseMap();
        }
    }
}
