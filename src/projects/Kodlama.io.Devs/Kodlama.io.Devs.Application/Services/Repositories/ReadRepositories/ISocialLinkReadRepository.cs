using Core.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;

public interface ISocialLinkReadRepository : IAsyncReadRepository<SocialLink>, IReadRepository<SocialLink> { }