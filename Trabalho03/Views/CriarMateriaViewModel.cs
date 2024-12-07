using System.Text.Json.Serialization;

namespace Trabalho03.Views;

public class CriarMateriaViewModel
{
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }
}