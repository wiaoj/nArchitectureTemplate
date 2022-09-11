using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.Users.Dtos.Queries;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Users.Profiles;
public class MappingProfiles : Profile {
	public MappingProfiles() {
		CreateMap<User, ApplicationUser>().ReverseMap();
		CreateMap<ApplicationUser, UserGetByIdDto>()
			.ForMember(x => x.SocialLinks, option => option.MapFrom(x => x.SocialLinks))
			.ReverseMap();
	}
}