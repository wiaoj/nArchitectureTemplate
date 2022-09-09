using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Commands;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto> {
    public String Name { get; set; }

    internal class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto> {
        private readonly IOperationClaimWriteRepository _operationClaimWriteRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimWriteRepository operationClaimWriteRepository, IMapper mapper) {
            this._operationClaimWriteRepository = operationClaimWriteRepository;
            this._mapper = mapper;
        }

        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken) {
            OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim createdOperationClaim = await _operationClaimWriteRepository.AddAsync(mappedOperationClaim);
            CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
            return createdOperationClaimDto;
        }
    }
}