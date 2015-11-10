using BeiDream.Demo.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BeiDream.Demo.Infrastructure.Mappings
{
    //public class MemoEntityConfiguration : EntityTypeConfiguration<Memo>
    //{
    //    public MemoEntityConfiguration()
    //    {
    //        ToTable("Memos");
    //        HasKey(x => x.Id);
    //        Property(x => x.Id).IsRequired()
    //            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    //        Property(x => x.Content).IsUnicode()
    //            .IsRequired()
    //            .IsMaxLength()
    //            .IsUnicode();
    //        Property(x => x.DateAdded)
    //            .IsRequired();
    //        Property(x => x.DateModified)
    //            .IsOptional();
    //        Property(x => x.Title).IsUnicode()
    //            .HasMaxLength(32)
    //            .IsRequired();
    //    }
    //}
}