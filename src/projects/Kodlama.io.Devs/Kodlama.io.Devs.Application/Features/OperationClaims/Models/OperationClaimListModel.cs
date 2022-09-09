using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.OperationClaims.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Models;
public class OperationClaimListModel : BasePageableModel {
    public IList<OperationClaimListDto> Items { get; set; }
}