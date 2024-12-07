namespace Trabalho03.Models.Entities;

public class Turma
{
    public Guid Id { get; init; }
    public string Nome { get; set; }
    public IList<Aluno> Alunos { get; set; }

    public Turma(string nome)
    {
        Nome = nome;
    }
}