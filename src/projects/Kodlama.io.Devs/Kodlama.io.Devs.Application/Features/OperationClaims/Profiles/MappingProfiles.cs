using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Profiles;
public class MappingProfiles : Profile {
	public MappingProfiles() {
		CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
		CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();

		//CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
		//CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();

		//CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
		//CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();

		CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
		CreateMap<IPaginate<OperationClaim>, UserOperationClaimListModel>().ReverseMap();
	}
}