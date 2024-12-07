using Microsoft.EntityFrameworkCore;
using Trabalho03.Data;
using Trabalho03.Models.Entities;
using Trabalho03.Services.Interfaces;

namespace Trabalho03.Services;

public class NotaService(AppDbContext context) : INotaService
{
    public async Task CriarNota(Nota nota)
    {
        await context.Notas.AddAsync(nota);
        await context.SaveChangesAsync();
    }

    public async Task<Nota[]> ObterNotas()
    {
        return await context.Notas.Where(x => true).ToArrayAsync();
    }

    public async Task<Nota[]> ObterNotasPorAlunoId(Guid alunoId)
    {
        return await context.Notas.Where(x => x.AlunoId == alunoId).ToArrayAsync();
    }
    
    public async Task<Nota?> ObterNotaPorId(Guid id)
    {
        return await context.Notas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Atualizar()
    {
        await context.SaveChangesAsync();
    }

    public async Task Deletar(Nota nota)
    {
        context.Remove(nota);
        await context.SaveChangesAsync();
    }
}