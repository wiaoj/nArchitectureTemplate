using Core.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Application.Services.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;

public class ProgrammingFrameworkReadRepository : EfReadRepositoryBase<ProgrammingFramework, BaseDbContext>, IProgrammingFrameworkReadRepository {
    public ProgrammingFrameworkReadRepository(BaseDbContext context) : base(context) { }
}