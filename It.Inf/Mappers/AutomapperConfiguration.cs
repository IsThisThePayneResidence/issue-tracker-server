using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using It.Data.Dto;
using It.Model.Domain;
using AutoMapper;
using Version = It.Model.Domain.Version;

namespace It.Inf.Mappers
{
    public static class AutomapperConfiguration
    {
        public static readonly IMapper Mapper;

        static AutomapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Issue, IssueDto>()
                    .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id.ToString().ToString()));
                cfg.CreateMap<IssueDto, Issue>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => new Guid(src.Guid)));
                cfg.CreateMap<Project, ProjectDto>()
                    .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id.ToString()));
                cfg.CreateMap<ProjectDto, Project>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => new Guid(src.Guid)));
                cfg.CreateMap<User, UserDto>()
                    .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id.ToString()));
                cfg.CreateMap<UserDto, User>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => new Guid(src.Guid)));
                cfg.CreateMap<Version, VersionDto>()
                    .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id.ToString()));
                cfg.CreateMap<VersionDto, Version>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => new Guid(src.Guid)));
                cfg.CreateMap<Status, StatusDto>()
                    .ForMember(dest => dest.Guid, opts => opts.MapFrom(src => src.Id.ToString()));
                cfg.CreateMap<StatusDto, Status>()
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => new Guid(src.Guid)));
            });

            Mapper = config.CreateMapper();
        }
//
//        public static IMapper GetMapper()
//        {
//            return Mapper;
//        }
    }
}
