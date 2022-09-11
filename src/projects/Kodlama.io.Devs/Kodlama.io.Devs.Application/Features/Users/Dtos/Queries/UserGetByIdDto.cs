using Core.Security.Enums;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.Users.Dtos.Queries;

public record UserGetByIdDto {
    public Guid Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public Byte[] PasswordSalt { get; set; }
    public Byte[] PasswordHash { get; set; }
    public Boolean Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public ICollection<UserSocialLinkDto> SocialLinks { get; set; }
}