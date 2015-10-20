using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Infrastructure.Mappings
{
    public class AccountEntityConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountEntityConfiguration()
        {
            ToTable("Accounts");
            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DateCreated).IsRequired();
            Property(x => x.DateLastLogon).IsOptional();
            Property(x => x.DisplayName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(32);
            Property(x => x.Email)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(64);
            Property(x => x.IsDeleted).IsOptional();
            Property(x => x.Name).IsRequired()
                .IsUnicode()
                .HasMaxLength(16);
            Property(x => x.Password).IsRequired()
                .IsUnicode()
                .HasMaxLength(4096);
        }
    }
}