using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OtpAuthenticator : BaseEntity {
	public Guid UserId { get; set; }
	public Byte[] SecretKey { get; set; }
	public Boolean IsVerified { get; set; }

	public virtual User User { get; set; }

	public OtpAuthenticator() { }

	public OtpAuthenticator(Guid id, Guid userId, Byte[] secretKey, Boolean isVerified) : this() {
		Id = id;
		UserId = userId;
		SecretKey = secretKey;
		IsVerified = isVerified;
	}
}