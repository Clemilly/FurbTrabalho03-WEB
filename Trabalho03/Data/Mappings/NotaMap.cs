using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho03.Models.Entities;

namespace Trabalho03.Data.Mappings;

public class NotaMap: IEntityTypeConfiguration<Nota>
{
    public void Configure(EntityTypeBuilder<Nota> builder)
    {
        builder.ToTable("Nota");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Peso).HasColumnName("Peso").IsRequired();
        builder.Property(x => x.MateriaId).HasColumnName("MateriaId").IsRequired();
        builder.Property(x => x.AlunoId).HasColumnName("AlunoId").IsRequired();

        builder
            .HasOne(e => e.Materia)
            .WithMany()
            .HasForeignKey(x => x.MateriaId);
        
        builder
            .HasOne(e => e.Aluno)
            .WithMany()
            .HasForeignKey(x => x.AlunoId);
    }
}