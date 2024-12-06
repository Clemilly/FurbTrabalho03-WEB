using Microsoft.EntityFrameworkCore;
using Trabalho03.Data.Mappings;
using Trabalho03.Models.Entities;

namespace Trabalho03.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Nota> Notas { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Materia> Materias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
        modelBuilder.Entity<Nota>(new NotaMap().Configure);
        modelBuilder.Entity<Turma>(new TurmaMap().Configure);
        modelBuilder.Entity<Materia>(new MateriaMap().Configure);
        
        base.OnModelCreating(modelBuilder);
    }
}