using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

public class SocialLink : BaseEntity {
    public String Name { get; set; }
    public String LinkUrl { get; set; }

    public Guid UserId { get; set; }
    public virtual ApplicationUser? User { get; set; }

    public SocialLink() { }
    public SocialLink(Guid id, String name, String likUrl, Guid userId) : this() {
        Id = id;
        Name = name;
        LinkUrl = likUrl;
        UserId = userId;
    }
}