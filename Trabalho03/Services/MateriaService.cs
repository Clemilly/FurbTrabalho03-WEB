using Microsoft.EntityFrameworkCore;
using Trabalho03.Data;
using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Services;

public class MateriaService(AppDbContext context) : IMateriaService
{
    public async Task<Materia> CriaMateriaAsync(CriarMateriaRequest criarMateriaRequest)
    {
        var criarMateria = new Materia(criarMateriaRequest.Nome);
        await context.Materias.AddAsync(criarMateria);
        await context.SaveChangesAsync();
        return criarMateria;
    }

    public async Task<Materia[]> ObterTodasMaterias()
    {
        return await context.Materias.Where(x => true).ToArrayAsync();
    }

    public async Task<Materia> ObterMateriaId(Guid id)
    {
        return await context.Materias.FirstOrDefaultAsync(x=> x.Id==id);
    }

    public async Task<Materia> AtualizarMateriaAsync(Materia materia)
    {
        var atualizarMateria = new Materia(materia.Nome);
        context.Materias.Update(materia);
        await context.SaveChangesAsync();
        return atualizarMateria;
    }

    public async Task DeletarMateria(Materia materia)
    {
        context.Materias.Remove(materia);
        await context.SaveChangesAsync();
    }
}