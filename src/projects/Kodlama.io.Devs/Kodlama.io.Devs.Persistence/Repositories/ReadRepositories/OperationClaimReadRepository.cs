using Core.Persistence.Repositories.ReadRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;

public class OperationClaimReadRepository : EfReadRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimReadRepository {
    public OperationClaimReadRepository(BaseDbContext context) : base(context) { }
}