using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho03.Models.Entities;

namespace Trabalho03.Data.Mappings;

public class TurmaMap : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("Turma");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired();
        
        builder
            .HasMany(x => x.Alunos)
            .WithMany(x => x.Turmas);
    }
}