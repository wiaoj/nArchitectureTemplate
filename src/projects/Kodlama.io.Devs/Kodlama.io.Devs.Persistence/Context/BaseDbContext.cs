using Core.Persistence.Repositories;
using Core.Security.Entities;
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

    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

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

        modelBuilder.Entity<User>(x => {
            x.ToTable("Users").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.FirstName).HasColumnName("FirstName");
            x.Property(p => p.LastName).HasColumnName("LastName");
            x.Property(p => p.Email).HasColumnName("Email");
            x.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
            x.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
            x.Property(p => p.Status).HasColumnName("Status");
            x.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

            {
                x.HasMany(x => x.UserOperationClaims);
                x.HasMany(x => x.RefreshTokens);
            }
        });

        modelBuilder.Entity<OperationClaim>(x => {
            x.ToTable("OperationClaims");
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<UserOperationClaim>(x => {
            x.ToTable("UserOperationClaims");
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            x.Property(p => p.UserId).HasColumnName("UserId");

            {
                x.HasOne(x => x.User);
                x.HasOne(x => x.OperationClaim);
            }
        });

        modelBuilder.Entity<RefreshToken>(x => {
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

            {
                x.HasOne(x => x.User);
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


        OperationClaim[] operationClaimEntitySeeds = {
            new(Guid.NewGuid(), "User"),
        };
        modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);
    }
}