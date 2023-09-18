using InvolveMINT.API.Core.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvolveMINT.API.Infrastructure.Data.Config
{
  public class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionEntity>
  {
    public void Configure(EntityTypeBuilder<QuestionEntity> builder)
    {
      builder.HasKey(e => e.Id);
      builder.ToTable("Question");

      builder.Property(e => e.Id)
        .HasColumnName("id")
        .HasColumnType("text")
        .HasConversion(
            id => id.ToString(),
            str => Guid.Parse(str)
        )
        .IsRequired();

      builder.Property(e => e.ProjectId)
        .HasColumnName("projectId")
        .HasColumnType("text")
        .HasColumnType("text")
        .HasConversion(
            id => id.ToString(),
            str => str == null ? null : Guid.Parse(str)
        );

      builder.Property(e => e.Text)
        .HasColumnType("character varying")
        .HasColumnName("text");
    }
  }
}
