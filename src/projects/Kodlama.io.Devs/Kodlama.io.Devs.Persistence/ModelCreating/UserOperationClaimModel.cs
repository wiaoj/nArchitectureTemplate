using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;

internal class UserOperationClaimModel : IEntityTypeConfiguration<UserOperationClaim> {
    public void Configure(EntityTypeBuilder<UserOperationClaim> x) {
        x.ToTable("UserOperationClaims");
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
        x.Property(p => p.UserId).HasColumnName("UserId");

        {
            x.HasOne(x => x.User);
            x.HasOne(x => x.OperationClaim);
        }
    }
}