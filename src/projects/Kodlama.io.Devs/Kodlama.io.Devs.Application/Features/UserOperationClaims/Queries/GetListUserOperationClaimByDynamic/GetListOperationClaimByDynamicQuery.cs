using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaimByDynamic;
public class GetListUserOperationClaimByDynamicQuery : IRequest<UserOperationClaimListModel> {
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }

    public class GetListUserOperationClaimByDynamicQueryHandler : IRequestHandler<GetListUserOperationClaimByDynamicQuery, UserOperationClaimListModel> {
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimByDynamicQueryHandler(
            IUserOperationClaimReadRepository userOperationClaimReadRepository,
            IMapper mapper) {
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimByDynamicQuery request, CancellationToken cancellationToken) {
            IPaginate<UserOperationClaim> socialLinks = await _userOperationClaimReadRepository.GetListByDynamicAsync(
                 dynamic: request.Dynamic,
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
                 );

            UserOperationClaimListModel mappedSocialLinks = _mapper.Map<UserOperationClaimListModel>(socialLinks);
            return mappedSocialLinks;
        }
    }
}
