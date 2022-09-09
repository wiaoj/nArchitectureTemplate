using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.WriteRepositories;

public class OperationClaimWriteRepository : EfWriteRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimWriteRepository {
    public OperationClaimWriteRepository(BaseDbContext context) : base(context) { }
}