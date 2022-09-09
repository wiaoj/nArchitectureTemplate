using Core.Persistence.Repositories.WriteRepositories;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.WriteRepositories;

public class ProgrammingLanguageWriteRepository : EfWriteRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageWriteRepository {
    public ProgrammingLanguageWriteRepository(BaseDbContext context) : base(context) { }
}