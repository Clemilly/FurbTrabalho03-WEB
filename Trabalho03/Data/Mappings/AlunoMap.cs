using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho03.Models.Entities;

namespace Trabalho03.Data.Mappings;

public class AlunoMap : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Aluno");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
        builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired();
        builder.Property(x => x.TurmaId).HasColumnName("TurmaId").IsRequired(false);

        builder
            .HasMany(x => x.Turmas)
            .WithMany(x => x.Alunos);

        builder
            .HasMany(x => x.Materias)
            .WithOne(x => x.Aluno)
            .HasForeignKey(y => y.AlunoId)
            .HasPrincipalKey(x => x.Id);
    }
}