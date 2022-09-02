using Core.Persistence.Paging;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
public class ProgrammingLanguageListModel : BasePageableModel {
    public IList<ProgrammingLanguage> Items { get; set; }
}