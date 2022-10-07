using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaimByDynamic;
public class GetListOperationClaimByDynamicQuery : IRequest<OperationClaimListModel>, ISecuredRequest {
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }

    public String[] Roles { get; } = { "Admin" };

    public class GetListOperationClaimByDynamicQueryHandler : IRequestHandler<GetListOperationClaimByDynamicQuery, OperationClaimListModel> {
        private readonly IOperationClaimReadRepository _operationClaimReadRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimByDynamicQueryHandler(IOperationClaimReadRepository operationClaimReadRepository, IMapper mapper) {
            _operationClaimReadRepository = operationClaimReadRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(GetListOperationClaimByDynamicQuery request, CancellationToken cancellationToken) {
            IPaginate<OperationClaim> operationClaims = await _operationClaimReadRepository.GetListByDynamicAsync(
                 dynamic: request.Dynamic,
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
                 );

            OperationClaimListModel mappedOperationClaims = _mapper.Map<OperationClaimListModel>(operationClaims);
            return mappedOperationClaims;
        }
    }
}
