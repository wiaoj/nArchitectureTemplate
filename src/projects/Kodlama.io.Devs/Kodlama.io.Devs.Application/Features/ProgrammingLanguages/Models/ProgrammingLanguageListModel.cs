using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
public class ProgrammingLanguageListModel : BasePageableModel/*<ProgrammingLanguage>*/ {
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}