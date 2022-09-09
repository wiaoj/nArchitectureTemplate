using Core.Security.Entities;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Domain.Entities;
public class ApplicationUser : User {
    public ICollection<SocialLink> SocialLinks { get; set; }

    public ApplicationUser() : base() { }
    public ApplicationUser(Guid id, String firstName, String lastName, String email, Byte[] passwordSalt, Byte[] passwordHash, Boolean status, AuthenticatorType authenticatorType) : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType) {
    }
}