using FluentValidation;
using Kodlama.io.Devs.Application.Features.Users.Common.ValidationRulesExtension;

namespace Kodlama.io.Devs.Application.Features.Users.Queries.GetByIdUser;
public class GetByIdUserValidator : AbstractValidator<GetByIdUserQuery> {
    public GetByIdUserValidator() {
        RuleFor(x => x.Id).Id();
    }
}