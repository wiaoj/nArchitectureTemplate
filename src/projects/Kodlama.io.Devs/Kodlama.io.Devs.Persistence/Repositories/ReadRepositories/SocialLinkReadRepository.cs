using Core.Persistence.Repositories.ReadRepositories;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.ReadRepositories;

public class SocialLinkReadRepository : EfReadRepositoryBase<SocialLink, BaseDbContext>, ISocialLinkReadRepository {
    public SocialLinkReadRepository(BaseDbContext context) : base(context) { }
}