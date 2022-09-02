using Core.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Application.Services.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;
public class ProgrammingLanguageReadRepository : EfReadRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageReadRepository {
    public ProgrammingLanguageReadRepository(BaseDbContext context) : base(context) { }
}