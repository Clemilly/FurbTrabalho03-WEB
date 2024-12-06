using Microsoft.AspNetCore.Mvc;
using Trabalho03.Models.Requests;
using Trabalho03.Models.Responses;
using Trabalho03.Services;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Controllers;

[ApiController]
[Route("Aluno")]
public class AlunoController(IAlunoService alunoService) : ControllerBase
{
    [HttpPost, Route("/Criar")]
    public async Task<IActionResult> CriarAluno([FromBody] CriarAlunoRequest criarAlunoRequest)
    {
        try
        {
            var alunoCriado = await alunoService.CriarAlunoAsync(criarAlunoRequest);
            var alunoViewModel = new CriarAlunoViewModel
            {
                Nome = alunoCriado.Nome,
                Email = alunoCriado.Email
            };
            return Ok(alunoViewModel);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpGet, Route("/Consultar")]
    public async Task<IActionResult> ObterAluno()
    {
        try
        {
            var obterAlunos = await alunoService.ObterTodosAlunosAsync();
            return Ok(obterAlunos);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }
    
    [HttpGet, Route("/Consultar/{email}")]
    public async Task<IActionResult> ObterAluno([FromRoute] string email)
    {
        try
        {
            var aluno = await alunoService.ConsultarPorEmailAsync(email);

            if (aluno is null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            
            return Ok(aluno);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpPatch, Route("/Atualizar/{id:guid}")]
    public async Task<IActionResult> AtualizarAluno([FromRoute] Guid id, [FromBody] CriarAlunoRequest criarAlunoRequest)
    {
        try
        {
            var aluno = await alunoService.ConsultarPorIdAsync(id);

            if (aluno is null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            
            aluno.Nome = criarAlunoRequest.Nome;
            aluno.Email = criarAlunoRequest.Email;
            aluno.TurmaId = criarAlunoRequest.TurmaId;

            var clienteAtualizado = await alunoService.AtualizarAlunoAsync();
            if (clienteAtualizado == 0)
            {
                return Problem("Nenhum campo modificado", statusCode: 304);
            }
            
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    //TODO: Criar endpoint para atribuir turma ao aluno
    
    [HttpDelete, Route("/Delete/{id:guid}")]
    public async Task<IActionResult> ExcluirAluno([FromRoute] Guid id)
    {
        try
        {
            var aluno = await alunoService.ConsultarPorIdAsync(id);

            if (aluno is null)
            {
                return BadRequest("Aluno não encontrado!");
            }

            await alunoService.DeletarAsync(aluno);
            
            return Ok(new DeleteResponse{ Staus = "OK", Mensagem = "OK"});
        }
        catch (Exception e)
        {
            return BadRequest(new DeleteResponse{ Mensagem = e.Message, Staus = "ERRO" });
        }
    }
}