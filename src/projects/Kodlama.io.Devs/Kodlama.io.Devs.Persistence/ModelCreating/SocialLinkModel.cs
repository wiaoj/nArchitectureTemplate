using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;

internal class SocialLinkModel : IEntityTypeConfiguration<SocialLink> {
    public void Configure(EntityTypeBuilder<SocialLink> x) {
        x.ToTable("SocialLinks").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.Name).HasColumnName("Name");
        x.Property(p => p.LinkUrl).HasColumnName("LinkUrl");

        {
            x.Property(p => p.UserId).HasColumnName("UserId");
            x.HasOne(x => x.User);
        }
    }
}