using Microsoft.EntityFrameworkCore;
using Trabalho03.Data;
using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;

namespace Trabalho03.Services.Interfaces;

public class TurmaService(AppDbContext _context) : ITurmaService
{
    public async Task<Turma> CriarTurmaAsync(CriarTurmaRequest turmaRequest)
    {
        var turmaCriada = new Turma(turmaRequest.Nome);
        _context.Turmas.Add(turmaCriada);
        _context.SaveChanges();
        return turmaCriada;
    }

    public async Task<Turma[]> ObterTodosTurmasAsync()
    {
        return await _context.Turmas.Where(x => true).ToArrayAsync();
    }

    public async Task<Turma?> ConsultarPorIdAsync(Guid id)
    {
        return await _context.Turmas.FirstOrDefaultAsync(x => x.Id == id);
    }
}