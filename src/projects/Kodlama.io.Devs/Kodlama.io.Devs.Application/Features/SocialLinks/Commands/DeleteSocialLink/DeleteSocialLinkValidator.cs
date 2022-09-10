using FluentValidation;
using Kodlama.io.Devs.Application.Features.SocialLinks.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Commands.DeleteSocialLink;
public class DeleteSocialLinkValidator : AbstractValidator<DeleteSocialLinkCommand> {
    public DeleteSocialLinkValidator() {
        RuleFor(x => x.Id).Id();
    }
}