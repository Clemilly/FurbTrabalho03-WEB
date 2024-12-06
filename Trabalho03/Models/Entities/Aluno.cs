using System.Collections;
using System.Text.Json.Serialization;
using Trabalho03.Data.Mappings;

namespace Trabalho03.Models.Entities;

public class Aluno
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Email { get; set; }
    public Guid? TurmaId { get; set; }
    
    public virtual  IList<Turma> Turmas { get; set; }
    public virtual IList<Materia> Materias { get; set; }
    public Aluno(string nome, string email, Guid? turmaId)
    {
        Nome = nome;
        Email = email;
        TurmaId = turmaId;
    }
}