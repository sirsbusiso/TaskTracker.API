using AutoMapper;
using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Profiles
{
    public class TaskTrackerProfile : Profile
    {
        public TaskTrackerProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskEntity, TaskAddDto>().ReverseMap();
            CreateMap<TaskEntity, TaskUpdateDto>().ReverseMap()
                .ForAllMembers(opts =>
                      opts.Condition((src, dest, srcMember) =>
                          srcMember != null && !(srcMember is string str && string.IsNullOrWhiteSpace(str))
                      )
         );

        }

    }
}
