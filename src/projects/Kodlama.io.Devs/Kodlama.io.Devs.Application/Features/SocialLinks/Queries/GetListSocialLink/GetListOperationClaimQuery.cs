using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.SocialLinks.Models;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Queries.GetListSocialLink;
public class GetListSocialLinkQuery : IRequest<SocialLinkListModel> {
    public PageRequest PageRequest { get; set; }

    internal class GetListSocialLinkHandler : IRequestHandler<GetListSocialLinkQuery, SocialLinkListModel> {
        private readonly ISocialLinkReadRepository _socialLinkReadRepository;
        private readonly IMapper _mapper;

        public GetListSocialLinkHandler(ISocialLinkReadRepository socialLinkReadRepository, IMapper mapper) {
            _socialLinkReadRepository = socialLinkReadRepository;
            _mapper = mapper;
        }

        public async Task<SocialLinkListModel> Handle(GetListSocialLinkQuery request, CancellationToken cancellationToken) {
            var entities = await _socialLinkReadRepository.GetListAsync(
                            index: request.PageRequest.Page,
                            size: request.PageRequest.PageSize,
                            enableTracking: false,
                            cancellationToken: cancellationToken
                            );
            SocialLinkListModel mappedEntitiesModel = _mapper.Map<SocialLinkListModel>(entities);

            return mappedEntitiesModel;
        }
    }
}