using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Context;
public class BaseDbContext : DbContext {
    protected readonly IConfiguration Configuration;

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions) {
        Configuration = configuration;
    }

    #region Entities
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    #endregion


    public override async Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default) {
        //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach(var data in datas) {
            _ = data.State switch {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow,
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //if (!optionsBuilder.IsConfigured)
        //    base.OnConfiguring(
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ProgrammingLanguage>(a => {
            a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            a.Property(x => x.Id).HasColumnName("Id");
            a.Property(x => x.Name).HasColumnName("Name");
        });

        //data seed
        ProgrammingLanguage[] programmingLanguageEntitySeeds = {
                new(Guid.NewGuid(), "Java"),
                new(Guid.NewGuid(), "C#"),
                new(Guid.NewGuid(), "Python"),
            };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

    }
}