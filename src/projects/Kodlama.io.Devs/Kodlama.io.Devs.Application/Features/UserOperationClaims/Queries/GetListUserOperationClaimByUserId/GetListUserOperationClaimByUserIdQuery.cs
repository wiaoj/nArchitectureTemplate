using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaimByUserId;
public class GetListUserOperationClaimByUserIdQuery : IRequest<UserOperationClaimListModel>, ISecuredRequest {
    public Guid UserId { get; set; }
    public PageRequest PageRequest { get; set; }

    public String[] Roles { get; } = { "Admin" };

    public class GetListUserOperationClaimByUserIdQueryHandler : IRequestHandler<GetListUserOperationClaimByUserIdQuery, UserOperationClaimListModel> {
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimByUserIdQueryHandler(
            IUserOperationClaimReadRepository userOperationClaimReadRepository,
            IMapper mapper
            ) {
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimByUserIdQuery request, CancellationToken cancellationToken) {
            IPaginate<UserOperationClaim> socialLinks = await _userOperationClaimReadRepository.GetListAsync(
                predicate: x => x.UserId.Equals(request.UserId),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            UserOperationClaimListModel mappedSocialLinksModel = _mapper.Map<UserOperationClaimListModel>(socialLinks);
            return mappedSocialLinksModel;
        }
    }
}
