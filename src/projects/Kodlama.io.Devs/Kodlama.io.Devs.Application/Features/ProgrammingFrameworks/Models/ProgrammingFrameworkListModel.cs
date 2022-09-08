using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Models;
public class ProgrammingFrameworkListModel : BasePageableModel {
    public IList<ProgrammingFrameworkListDto> Items { get; set; }
}