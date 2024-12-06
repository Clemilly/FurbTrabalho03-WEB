using System.Text.Json.Serialization;

namespace Trabalho03.Models.Requests;

public class CriarAlunoRequest
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("turmaId")]
    public Guid? TurmaId { get; set; }
}