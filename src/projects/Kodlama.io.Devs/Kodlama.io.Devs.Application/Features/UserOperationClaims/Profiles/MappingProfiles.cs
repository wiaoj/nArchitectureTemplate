using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Profiles;
public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

        //CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        //CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();

        //CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        //CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();

        CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();
        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
    }
}