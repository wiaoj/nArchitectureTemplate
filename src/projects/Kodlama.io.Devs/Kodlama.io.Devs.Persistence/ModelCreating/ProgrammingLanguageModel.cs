using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kodlama.io.Devs.Persistence.ModelCreating;
internal class ProgrammingLanguageModel : IEntityTypeConfiguration<ProgrammingLanguage> {
    public void Configure(EntityTypeBuilder<ProgrammingLanguage> x) {
        x.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("Id");
        x.Property(p => p.Name).HasColumnName("Name");

        {
            x.HasMany(x => x.ProgrammingFrameworks);
        }
    }
}