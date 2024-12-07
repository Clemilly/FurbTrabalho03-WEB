using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;

namespace Trabalho03.Services.Interfaces;

public interface IMateriaService
{
    Task<Materia> CriaMateriaAsync(CriarMateriaRequest criarMateriaRequest);
    Task<Materia[]> ObterTodasMaterias();
    Task<Materia> ObterMateriaId(Guid id);
    Task<Materia> AtualizarMateriaAsync(Materia materia);
    Task DeletarMateria(Materia materia);

}