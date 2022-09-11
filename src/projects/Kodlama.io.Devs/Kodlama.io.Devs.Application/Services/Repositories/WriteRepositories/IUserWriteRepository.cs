using Core.Persistence.Repositories.WriteRepositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;

public interface IUserWriteRepository : IWriteRepository<ApplicationUser> { }