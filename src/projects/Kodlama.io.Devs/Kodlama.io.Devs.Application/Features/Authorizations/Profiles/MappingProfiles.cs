using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos.Commands;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Profiles;
public class MappingProfiles : Profile{
	public MappingProfiles() {
		CreateMap<User, UserForRegisterDto>().ReverseMap();
		CreateMap<User, UserForLoginDto>().ReverseMap();

		CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
		CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
	}
}