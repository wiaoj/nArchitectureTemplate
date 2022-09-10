using FluentValidation;
using Kodlama.io.Devs.Application.Features.SocialLinks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Commands.CreateSocialLink;
public class UpdateSocialLinkValidator : AbstractValidator<CreateSocialLinkCommand> {
    public UpdateSocialLinkValidator() {
        RuleFor(x => x.UserId).UserId();
        RuleFor(x => x.Name).Name();
        RuleFor(x => x.LinkUrl).Link();
    }
}
