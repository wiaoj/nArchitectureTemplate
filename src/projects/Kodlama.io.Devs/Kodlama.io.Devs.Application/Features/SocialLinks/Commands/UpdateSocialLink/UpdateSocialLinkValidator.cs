using FluentValidation;
using Kodlama.io.Devs.Application.Features.SocialLinks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Commands.UpdateSocialLink;
public class UpdateSocialLinkValidator : AbstractValidator<UpdateSocialLinkCommand> {
    public UpdateSocialLinkValidator() {
        RuleFor(x => x.Id).Id();
        RuleFor(x => x.UserId).UserId();
        RuleFor(x => x.Name).Name();
        RuleFor(x => x.LinkUrl).Link();
    }
}