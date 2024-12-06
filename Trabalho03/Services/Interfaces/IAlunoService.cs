using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;

namespace Trabalho03.Services.Interfaces;

public interface IAlunoService
{ 
    Task<Aluno> CriarAlunoAsync(CriarAlunoRequest criarAlunoRequest);
    Task<Aluno[]> ObterTodosAlunosAsync();
    Task<Aluno?> ConsultarPorEmailAsync(string email);
    Task<Aluno?> ConsultarPorIdAsync(Guid id);
    Task<int> AtualizarAlunoAsync();
    Task<int> DeletarAsync(Aluno aluno);
}