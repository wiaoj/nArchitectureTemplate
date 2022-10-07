using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialLinks.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Queries.GetListSocialLink;
public class GetListSocialLinkQuery : IRequest<SocialLinkListModel>, ISecuredRequest {
    public PageRequest PageRequest { get; set; }

    public String[] Roles { get; } = { "Admin", "User" };

    internal class GetListSocialLinkHandler : IRequestHandler<GetListSocialLinkQuery, SocialLinkListModel> {
        private readonly ISocialLinkReadRepository _socialLinkReadRepository;
        private readonly IMapper _mapper;

        public GetListSocialLinkHandler(
            ISocialLinkReadRepository socialLinkReadRepository,
            IMapper mapper
            ) {
            _socialLinkReadRepository = socialLinkReadRepository;
            _mapper = mapper;
        }

        public async Task<SocialLinkListModel> Handle(GetListSocialLinkQuery request, CancellationToken cancellationToken) {
            IPaginate<SocialLink> socialLinks = await _socialLinkReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            include: x => x.Include(l => l.User),
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            SocialLinkListModel mappedSocialLinksModel = _mapper.Map<SocialLinkListModel>(socialLinks);

            return mappedSocialLinksModel;
        }
    }
}