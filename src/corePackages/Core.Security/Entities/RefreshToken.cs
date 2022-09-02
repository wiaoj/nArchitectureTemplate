using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class RefreshToken : BaseEntity {
	public Guid UserId { get; set; }
	public String Token { get; set; }
	public DateTime Expires { get; set; }
	public DateTime Created { get; set; }
	public String CreatedByIp { get; set; }
	public DateTime? Revoked { get; set; }
	public String? RevokedByIp { get; set; }
	public String? ReplacedByToken { get; set; }

	public String? ReasonRevoked { get; set; }
	//public Boolean IsExpired => DateTime.UtcNow >= Expires;
	//public Boolean IsRevoked => Revoked != null;
	//public Boolean IsActive => !IsRevoked && !IsExpired;

	public virtual User User { get; set; }

	public RefreshToken() { }

	public RefreshToken(Guid id, 
						String token, 
						DateTime expires, 
						DateTime created, 
						String createdByIp, 
						DateTime? revoked, 
						String revokedByIp, 
						String replacedByToken, 
						String reasonRevoked) {
		Id = id;
		Token = token;
		Expires = expires;
		Created = created;
		CreatedByIp = createdByIp;
		Revoked = revoked;
		RevokedByIp = revokedByIp;
		ReplacedByToken = replacedByToken;
		ReasonRevoked = reasonRevoked;
	}
}