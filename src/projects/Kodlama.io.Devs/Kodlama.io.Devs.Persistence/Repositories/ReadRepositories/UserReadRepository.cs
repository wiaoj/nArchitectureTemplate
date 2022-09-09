using Core.Persistence.Repositories.ReadRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;

public class UserReadRepository : EfReadRepositoryBase<User, BaseDbContext>, IUserReadRepository {
    public UserReadRepository(BaseDbContext context) : base(context) { }
}