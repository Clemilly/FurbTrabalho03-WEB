using System.Text.Json.Serialization;

namespace Trabalho03.Models.Entities;

public record Materia
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }

    public Materia(string nome)
    {
        Nome = nome;
    }
}