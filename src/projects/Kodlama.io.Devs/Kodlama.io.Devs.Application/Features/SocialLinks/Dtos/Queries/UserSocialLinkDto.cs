namespace Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Queries;

public record UserSocialLinkDto {
    public String Name { get; set; }
    public String LinkUrl { get; set; }
}