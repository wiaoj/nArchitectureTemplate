using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Rules;
internal class SocialLinkBusinessRules {
    private readonly ISocialLinkReadRepository _socialLinkReadRepository;

    public SocialLinkBusinessRules(ISocialLinkReadRepository socialLinkReadRepository) {
        _socialLinkReadRepository = socialLinkReadRepository;
    }

    public async Task SocialLinkNameCanNotBeDuplicatedWhenInserted(String name, String linkUrl) {
        IPaginate<SocialLink> result = await _socialLinkReadRepository.GetListAsync(x => x.Name.ToLower().Equals(name.ToLower()), enableTracking: false);
        if(result.Items.Any()) {
            await SocialLinkLinkUrlCanNotBeDuplicatedWhenInserted(linkUrl);
            throw new BusinessException("Social name exists.");
        }
    }

    public async Task SocialLinkLinkUrlCanNotBeDuplicatedWhenInserted(String linkUrl) {
        IPaginate<SocialLink> result = await _socialLinkReadRepository.GetListAsync(x => x.LinkUrl.ToLower().Equals(linkUrl.ToLower()), enableTracking: false);
        if(result.Items.Any())
            throw new BusinessException("Social link exists.");
    }

    public async Task SocialLinkShouldExistWhenRequestId(Guid id) {
        SocialLink? programmingLanguage = await _socialLinkReadRepository.GetByIdAsync(id, enableTracking: false);
        if(programmingLanguage is null)
            throw new BusinessException("Social link does not exists.");
    }
}