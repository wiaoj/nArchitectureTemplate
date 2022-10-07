using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;

internal class RefreshTokenModel : IEntityTypeConfiguration<RefreshToken> {
    public void Configure(EntityTypeBuilder<RefreshToken> x) {
        x.ToTable("RefreshTokens");
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.UserId).HasColumnName("UserId");
        x.Property(p => p.Token).HasColumnName("Token");
        x.Property(p => p.Expires).HasColumnName("Expires");
        x.Property(p => p.Created).HasColumnName("Created");
        x.Property(p => p.Revoked).HasColumnName("Revoked");
        x.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
        x.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
        x.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
        x.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");

        x.Ignore(p => p.CreatedDate);
        x.Ignore(p => p.UpdatedDate);

        {
            x.HasOne(x => x.User);
        }

        x.Ignore("CreatedDate");
        x.Ignore("UpdatedDate");
    }
}