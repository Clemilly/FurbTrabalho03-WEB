using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;

namespace Trabalho03.Services.Interfaces;

public interface ITurmaService
{
    Task<Turma> CriarTurmaAsync(CriarTurmaRequest request);
    Task<Turma[]> ObterTodosTurmasAsync();
    Task<Turma?> ConsultarPorIdAsync(Guid id);
}