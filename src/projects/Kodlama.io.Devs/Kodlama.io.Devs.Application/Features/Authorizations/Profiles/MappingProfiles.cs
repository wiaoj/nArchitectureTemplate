using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Authorizations.Dtos;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Authorizations.Profiles;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        //CreateMap<ApplicationUser, UserForRegisterDto>().ReverseMap();
        //CreateMap<ApplicationUser, UserForLoginDto>().ReverseMap();

        //CreateMap<AccessToken, AccessTokenDto>().ReverseMap();
        //CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
    }
}