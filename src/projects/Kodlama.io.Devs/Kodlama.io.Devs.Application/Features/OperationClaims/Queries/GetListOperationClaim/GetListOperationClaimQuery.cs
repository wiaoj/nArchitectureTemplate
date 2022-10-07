using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest {
    public PageRequest? PageRequest { get; set; }

    public String[] Roles { get; } = { "Admin" };

    internal class GetListOperationClaimHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel> {
        private readonly IOperationClaimReadRepository _operationClaimReadRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimHandler(IOperationClaimReadRepository operationClaimReadRepository, IMapper mapper) {
            _operationClaimReadRepository = operationClaimReadRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken) {
            var entities = await _operationClaimReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            OperationClaimListModel mappedEntitiesModel = _mapper.Map<OperationClaimListModel>(entities);

            return mappedEntitiesModel;
        }
    }
}