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
    public DbSet<ProgrammingFramework> ProgrammingFrameworks { get; set; }
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
        modelBuilder.Entity<ProgrammingLanguage>(x => {
            x.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");

            {
                x.HasMany(x => x.ProgrammingFrameworks);
            }
        });

        modelBuilder.Entity<ProgrammingFramework>(x => {
            x.ToTable("ProgrammingFrameworks").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");
            x.Property(p => p.Version).HasColumnName("Version");
            x.Property(p => p.Tag).HasColumnName("Tag");

            {
                x.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                x.HasOne(x => x.ProgrammingLanguage);
            }
        });

        //data seed
        Guid javaDataSeedId = Guid.NewGuid();
        Guid csharpDataSeedId = Guid.NewGuid();
        Guid pythonDataSeedId = Guid.NewGuid();
        Guid javaScriptDataSeedId = Guid.NewGuid();
        ProgrammingLanguage[] programmingLanguageEntitySeeds = {
                new(javaDataSeedId, "Java"),
                new(csharpDataSeedId, "C#"),
                new(pythonDataSeedId, "Python"),
                new(javaScriptDataSeedId, "JavaScript"),
            };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

        ProgrammingFramework[] programmingFrameworkEntitySeeds = {
            new(Guid.NewGuid(), "Spring", 3, "latest", javaDataSeedId),
            new(Guid.NewGuid(), "JSP", 2, "latest", javaDataSeedId),
            new(Guid.NewGuid(), "WPF", 7, "latest", csharpDataSeedId),
            new(Guid.NewGuid(), "ASP.NET", 6, "latest", csharpDataSeedId),
            new(Guid.NewGuid(), "Angular", 14, "latest", javaScriptDataSeedId),
            new(Guid.NewGuid(), "React", 5, "latest", javaScriptDataSeedId),
        };
        modelBuilder.Entity<ProgrammingFramework>().HasData(programmingFrameworkEntitySeeds);

    }
}