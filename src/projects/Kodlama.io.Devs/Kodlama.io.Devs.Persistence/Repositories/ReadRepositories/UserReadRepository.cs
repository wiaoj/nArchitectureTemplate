using Core.Persistence.Repositories.ReadRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;

public class UserReadRepository : EfReadRepositoryBase<ApplicationUser, BaseDbContext>, IUserReadRepository {
    public UserReadRepository(BaseDbContext context) : base(context) { }
}