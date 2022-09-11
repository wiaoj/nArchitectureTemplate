namespace Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Commands;

public record UpdatedSocialLinkDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String LinkUrl { get; set; }
}