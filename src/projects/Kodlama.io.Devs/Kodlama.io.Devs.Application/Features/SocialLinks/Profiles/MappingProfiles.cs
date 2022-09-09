using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialLinks.Commands.CreateSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Commands.DeleteSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Commands.UpdateSocialLink;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.SocialLinks.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Profiles;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<SocialLink, CreateSocialLinkCommand>().ReverseMap();
        CreateMap<SocialLink, CreatedSocialLinkDto>().ReverseMap();

        CreateMap<SocialLink, DeleteSocialLinkCommand>().ReverseMap();
        CreateMap<SocialLink, DeletedSocialLinkDto>().ReverseMap();

        CreateMap<SocialLink, UpdateSocialLinkCommand>().ReverseMap();
        CreateMap<SocialLink, UpdatedSocialLinkDto>().ReverseMap();

        CreateMap<SocialLink, SocialLinkListDto>().ReverseMap();
        CreateMap<IPaginate<SocialLink>, SocialLinkListModel>().ReverseMap();
    }
}