using System.Data.Entity.ModelConfiguration;
using DBModels;

namespace EntityFrameworkWrapper
{
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(d => d.Guid);
            Property(d => d.Guid).HasColumnName("ID").IsRequired();
            Property(d => d.Name).HasColumnName("Name").IsRequired();
            Property(d => d.Surname).HasColumnName("Surname").IsRequired();
            Property(d => d.Email).HasColumnName("Email").HasMaxLength(256).IsRequired();
            Property(d => d.Password).HasColumnName("Password").IsRequired();
            Property(d => d.Time).HasColumnName("Last enter time").HasColumnType("datetime2").IsRequired();
            HasIndex(ind => ind.Email).IsUnique(true);
        }
    }
}