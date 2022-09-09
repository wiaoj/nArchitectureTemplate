using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialLinks.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Queries.GetListSocialLinkByDynamic;
public class GetListSocialLinkByDynamicQuery : IRequest<SocialLinkListModel> {
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }

    public class GetListSocialLinkByDynamicQueryHandler : IRequestHandler<GetListSocialLinkByDynamicQuery, SocialLinkListModel> {
        private readonly ISocialLinkReadRepository _socialLinkReadRepository;
        private readonly IMapper _mapper;

        public GetListSocialLinkByDynamicQueryHandler(ISocialLinkReadRepository socialLinkReadRepository, IMapper mapper) {
            _socialLinkReadRepository = socialLinkReadRepository;
            _mapper = mapper;
        }

        public async Task<SocialLinkListModel> Handle(GetListSocialLinkByDynamicQuery request, CancellationToken cancellationToken) {
            IPaginate<SocialLink> socialLinks = await _socialLinkReadRepository.GetListByDynamicAsync(
                 dynamic: request.Dynamic,
                 index: request.PageRequest.Page,
                 size: request.PageRequest.PageSize
                 );

            SocialLinkListModel mappedSocialLinks = _mapper.Map<SocialLinkListModel>(socialLinks);
            return mappedSocialLinks;
        }
    }
}
