using Core.Persistence.Repositories.ReadRepositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

public interface IOperationClaimReadRepository : IAsyncReadRepository<OperationClaim>, IReadRepository<OperationClaim> { }