using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Models;
public record UserOperationClaimListModel : BasePageableModel {
    public IList<UserOperationClaimListDto> Items { get; set; }
}