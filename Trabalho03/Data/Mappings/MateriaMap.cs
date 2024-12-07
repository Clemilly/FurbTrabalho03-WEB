using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trabalho03.Models.Entities;

namespace Trabalho03.Data.Mappings;

public class MateriaMap: IEntityTypeConfiguration<Materia>
{
    public void Configure(EntityTypeBuilder<Materia> builder)
    {
        builder.ToTable("Materia");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).HasColumnName("Nome").IsRequired();
    }
}