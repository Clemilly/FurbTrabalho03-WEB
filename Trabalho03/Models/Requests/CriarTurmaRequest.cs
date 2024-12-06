using System.Text.Json.Serialization;

namespace Trabalho03.Models.Requests;

public class CriarTurmaRequest
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
}