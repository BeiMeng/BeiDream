using BeiDream.Demo.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeiDream.Demo.Infrastructure.Mappings
{
    public class RoleEntityConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityConfiguration()
        {
            ToTable("Roles");
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsUnicode()
                .IsRequired()
                .HasMaxLength(16);
            Property(x => x.Description).IsUnicode()
                .IsOptional()
                .HasMaxLength(256);
        }
    }
}