using System.Text.Json.Serialization;

namespace Trabalho03.Models.Entities;

public record Materia
{
    public Guid Id { get; init; }
    public string Nome { get; set; }
    public Guid AlunoId { get; set; }
    
    [JsonIgnore]
    public virtual Aluno Aluno { get; set; }
}