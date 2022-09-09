using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class EmailAuthenticator : BaseEntity {
    public Guid UserId { get; set; }
    public String? ActivationKey { get; set; }
    public Boolean IsVerified { get; set; }

    public virtual User User { get; set; }

    public EmailAuthenticator() { }

    public EmailAuthenticator(Guid id, Guid userId, String? activationKey, Boolean isVerified) : this() {
        Id = id;
        UserId = userId;
        ActivationKey = activationKey;
        IsVerified = isVerified;
    }
}