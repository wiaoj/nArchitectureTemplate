using Core.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.ReadRepositories;

public interface IProgrammingFrameworkReadRepository : IAsyncReadRepository<ProgrammingFramework>, IReadRepository<ProgrammingFramework> { }