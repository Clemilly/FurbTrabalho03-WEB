using Microsoft.EntityFrameworkCore;
using Trabalho03.Data;
using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;
using Trabalho03.Services.Interfaces;

namespace Trabalho03.Services;

public class AlunoService(AppDbContext context) : IAlunoService
{
    public async Task<Aluno> CriarAlunoAsync(CriarAlunoRequest criarAlunoRequest)
    {
        var aluno = new Aluno(criarAlunoRequest.Nome, criarAlunoRequest.Email, criarAlunoRequest.TurmaId);
        await context.Alunos.AddAsync(aluno);
        await context.SaveChangesAsync();

        return aluno;   
    }

    public async Task<Aluno[]> ObterTodosAlunosAsync()
    {
        return await context.Alunos.Where(x => true).ToArrayAsync();
    }

    public async Task<Aluno?> ConsultarPorEmailAsync(string email)
    {
        return await context.Alunos.FirstOrDefaultAsync(x => x.Email == email);
    }
    
    public async Task<Aluno?> ConsultarPorIdAsync(Guid id)
    {
        return await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> AtualizarAlunoAsync()
    {
        return await context.SaveChangesAsync();
    }
    
    public async Task<int> DeletarAsync(Aluno aluno)
    {
        context.Alunos.Remove(aluno);
        return await context.SaveChangesAsync();
    }
    
}