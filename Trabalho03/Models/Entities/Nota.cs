using System.Text.Json.Serialization;

namespace Trabalho03.Models.Entities;

public record Nota
{
    public Guid Id { get; set; }
    public int Peso { get; set; }
    public Guid AlunoId { get; set; }
    
    [JsonIgnore]
    public virtual Aluno Aluno { get; set; }
    
    public Guid MateriaId { get; set; }
    [JsonIgnore]
    public virtual Materia Materia { get; set; }
}