using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Models;
public record SocialLinkListModel : BasePageableModel {
    public IList<SocialLinkListDto> Items { get; set; }
}