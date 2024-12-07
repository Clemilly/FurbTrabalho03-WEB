using Microsoft.EntityFrameworkCore;
using Trabalho03.Data;
using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;

namespace Trabalho03.Services.Interfaces;

public class TurmaService(AppDbContext _context) : ITurmaService
{
    public async Task<Turma> CriarTurmaAsync(CriarTurmaRequest turmaRequest)
    {
        var turma = new Turma(turmaRequest.Nome);
        await _context.Turmas.AddAsync(turma);
        await _context.SaveChangesAsync();
        return turma;
    }

    public async Task<Turma[]> ObterTodasTurmasAsync()
    {
        return await _context.Turmas.Include(x => x.Alunos).Where(x => true).ToArrayAsync();
    }

    public async Task<Turma[]> ConsultarPorNomeAsync(string nome)
    {
        return await _context.Turmas.Where(x => x.Nome == nome).ToArrayAsync();
    }

    public async Task<Turma?> ConsultarPorIdAsync(Guid id)
    {
        return await _context.Turmas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> AtualizarAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeletarAsync(Turma turma)
    {
        _context.Turmas.Remove(turma);
        return await _context.SaveChangesAsync();
    }
}