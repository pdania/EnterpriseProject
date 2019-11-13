using System.Data.Entity.ModelConfiguration;
using DBModels;

namespace EntityFrameworkWrapper
{
    public class RequestConfiguration:EntityTypeConfiguration<Request>
    {
        public RequestConfiguration()
        {
            ToTable("Requests");
            HasKey(d => d.Guid);
            Property(d => d.Guid).HasColumnName("ID").IsRequired();
            Property(d => d.StartRange).HasColumnName("Start range").IsRequired();
            Property(d => d.EndRange).HasColumnName("End range").IsRequired();
            Property(d => d.Count).HasColumnName("Count").IsRequired();
            Property(d => d.RequestTime).HasColumnName("Request time").HasColumnType("datetime2").IsRequired();
        }
    }
}