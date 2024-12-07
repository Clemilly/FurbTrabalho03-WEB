namespace Trabalho03.Models.Requests;

public class CriarNotaRequest
{
    public int Peso { get; set; }
    public Guid AlunoId { get; set; }
    public Guid MateriaId { get; set; }
}