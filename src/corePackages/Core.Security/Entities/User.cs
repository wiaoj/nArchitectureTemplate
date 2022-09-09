using Core.Persistence.Repositories;
using Core.Security.Enums;

namespace Core.Security.Entities;

public class User : BaseEntity {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
    public Byte[] PasswordSalt { get; set; }
    public Byte[] PasswordHash { get; set; }
    public Boolean Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    public User() {
        UserOperationClaims = new HashSet<UserOperationClaim>();
        RefreshTokens = new HashSet<RefreshToken>();
    }

    public User(Guid id,
                String firstName,
                String lastName,
                String email,
                Byte[] passwordSalt,
                Byte[] passwordHash,
                Boolean status,
                AuthenticatorType authenticatorType) : this() {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
        AuthenticatorType = authenticatorType;
    }
}