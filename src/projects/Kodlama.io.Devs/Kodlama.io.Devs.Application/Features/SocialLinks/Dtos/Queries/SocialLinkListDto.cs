namespace Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Queries;

public record SocialLinkListDto {
    public Guid Id { get; set; }
    public String UserName { get; set; }
    public String Name { get; set; }
    public String LinkUrl { get; set; }
}