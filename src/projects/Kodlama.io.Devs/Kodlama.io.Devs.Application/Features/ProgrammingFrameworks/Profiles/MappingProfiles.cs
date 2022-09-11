using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.CreateProgrammingFramework;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.DeleteProgrammingFramework;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Commands.UpdateProgrammingFramework;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Profiles;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<ProgrammingFramework, CreateProgrammingFrameworkCommand>().ReverseMap();
        CreateMap<ProgrammingFramework, CreatedProgrammingFrameworkDto>().ReverseMap();

        CreateMap<ProgrammingFramework, UpdateProgrammingFrameworkCommand>().ReverseMap();
        CreateMap<ProgrammingFramework, UpdatedProgrammingFrameworkDto>().ReverseMap();

        CreateMap<ProgrammingFramework, DeleteProgrammingFrameworkCommand>().ReverseMap();
        CreateMap<ProgrammingFramework, DeletedProgrammingFrameworkDto>().ReverseMap();

        CreateMap<ProgrammingFramework, ProgrammingFrameworkListDto>()
            .ForMember(x => x.ProgrammingLanguageName, option => option.MapFrom(x => x.ProgrammingLanguage.Name))
            .ReverseMap();
        CreateMap<IPaginate<ProgrammingFramework>, ProgrammingFrameworkListModel>().ReverseMap();

        CreateMap<ProgrammingFramework, ProgrammingFrameworkGetByIdDto>()
            .ForMember(x => x.ProgrammingLanguageName, option => option.MapFrom(x => x.ProgrammingLanguage.Name))
            .ReverseMap();

        CreateMap<ProgrammingFramework, ProgrammingFrameworkGetByProgrammingLanguageDto>().ReverseMap();
    }
}