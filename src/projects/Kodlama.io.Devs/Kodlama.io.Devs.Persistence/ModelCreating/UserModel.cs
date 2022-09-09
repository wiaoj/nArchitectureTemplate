namespace Kodlama.io.Devs.Persistence.ModelCreating;

//internal class UserModel : IEntityTypeConfiguration<User> {
//    public void Configure(EntityTypeBuilder<User> x) {
//        x.ToTable("Users").HasKey(k => k.Id);
//        x.Property(p => p.Id).HasColumnName("Id");
//        x.Property(p => p.FirstName).HasColumnName("FirstName");
//        x.Property(p => p.LastName).HasColumnName("LastName");
//        x.Property(p => p.Email).HasColumnName("Email");
//        x.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
//        x.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
//        x.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
//        x.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

//        {
//            x.HasMany(x => x.UserOperationClaims);
//            x.HasMany(x => x.RefreshTokens);

//            //x.HasMany(x => x.SocialLinks);
//        }
//    }
//}