using System.Text.Json.Serialization;

namespace Trabalho03.Views;

public class CriarAlunoViewModel
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
}