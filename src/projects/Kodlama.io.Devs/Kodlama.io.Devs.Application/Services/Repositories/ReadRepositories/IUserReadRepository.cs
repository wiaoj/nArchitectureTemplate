using Core.Persistence.Repositories.ReadRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

public interface IUserReadRepository : IAsyncReadRepository<ApplicationUser>, IReadRepository<ApplicationUser> { }