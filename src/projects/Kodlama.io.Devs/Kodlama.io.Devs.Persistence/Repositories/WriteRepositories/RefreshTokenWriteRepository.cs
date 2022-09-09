using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.WriteRepositories;

public class RefreshTokenWriteRepository : EfWriteRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenWriteRepository {
    public RefreshTokenWriteRepository(BaseDbContext context) : base(context) { }
}