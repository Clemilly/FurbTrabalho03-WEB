namespace Trabalho03.Models.Requests;

public class CriarNotaRequest
{
    public Guid Id { get; set; }
    public int Peso { get; set; }
    public Guid AlunoId { get; set; }
    public Guid MateriaId { get; set; }
}