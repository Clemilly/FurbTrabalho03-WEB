using Trabalho03.Models.Entities;

namespace Trabalho03.Services.Interfaces;

public interface INotaService
{
    Task CriarNota(Nota nota);
    Task<Nota[]> ObterNotas();
    Task<Nota[]> ObterNotasPorAlunoId(Guid alunoId);
    Task Atualizar();
    Task Deletar(Nota nota);
    Task<Nota?> ObterNotaPorId(Guid id);
}