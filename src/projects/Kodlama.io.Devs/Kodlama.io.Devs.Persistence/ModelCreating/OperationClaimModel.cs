using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;

internal class OperationClaimModel : IEntityTypeConfiguration<OperationClaim> {
    public void Configure(EntityTypeBuilder<OperationClaim> x) {
        x.ToTable("OperationClaims");
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.Name).HasColumnName("Name");

        x.Ignore(p => p.CreatedDate);
        x.Ignore(p => p.UpdatedDate);
        {
            x.HasMany(x => x.UserOperationClaims);
        }

        //OperationClaim[] operationClaimEntitySeeds = {
        //    new(Guid.NewGuid(), "Admin"),
        //    new(Guid.NewGuid(), "User"),
        //};
        //x.HasData(operationClaimEntitySeeds);
    }
}