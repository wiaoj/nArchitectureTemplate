using Core.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.ReadRepositories;

public interface IProgrammingLanguageReadRepository : IAsyncReadRepository<ProgrammingLanguage>, IReadRepository<ProgrammingLanguage> { }