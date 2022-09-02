using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim : BaseEntity {
	public String Name { get; set; }

	public OperationClaim() { }

	public OperationClaim(Guid id, String name) : base(id) {
		Name = name;
	}
}