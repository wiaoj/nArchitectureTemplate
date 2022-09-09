using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;

internal class OperationClaimModel : IEntityTypeConfiguration<OperationClaim> {
    public void Configure(EntityTypeBuilder<OperationClaim> x) {
        x.ToTable("OperationClaims");
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.Name).HasColumnName("Name");

        {
            x.HasMany(x => x.UserOperationClaims);
        }
    }
}