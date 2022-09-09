using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;

internal class ProgrammingFrameworkModel : IEntityTypeConfiguration<ProgrammingFramework> {
    public void Configure(EntityTypeBuilder<ProgrammingFramework> x) {
        x.ToTable("ProgrammingFrameworks").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.Name).HasColumnName("Name");
        x.Property(p => p.Version).HasColumnName("Version");
        x.Property(p => p.Tag).HasColumnName("Tag");

        {
            x.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            x.HasOne(x => x.ProgrammingLanguage);
        }
    }
}