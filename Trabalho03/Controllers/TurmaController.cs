using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trabalho03.Models.Requests;
using Trabalho03.Models.Responses;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Controllers;

[ApiController]
[Authorize]
public class TurmaController(ITurmaService turmaService) : ControllerBase
{
    [HttpPost, Route("/Criar/Turma")]
    public async Task<IActionResult> CriarTurma(CriarTurmaRequest turmaRequest)
    {
        try
        {
            var turmaCriada = await turmaService.CriarTurmaAsync(turmaRequest);
            var turmaViewModel = new CriarTurmaViewModel()
            {
                Nome = turmaCriada.Nome
            };
            return Ok(turmaViewModel);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }
    
     [HttpGet, Route("/Consultar/Turmas")]
    public async Task<IActionResult> ObterAluno()
    {
        try
        {
            var obterTodasTurmasAsync = await turmaService.ObterTodasTurmasAsync();
            return Ok(obterTodasTurmasAsync);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }
    
    [HttpGet, Route("/Consultar/Turma/{nome}")]
    public async Task<IActionResult> ObterAluno([FromRoute] string nome)
    {
        try
        {
            var turmas = await turmaService.ConsultarPorNomeAsync(nome);

            if (turmas.Length == 0)
            {
                return BadRequest("Aluno não encontrado!");
            }
            
            return Ok(turmas);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpPatch, Route("/Atualizar/Turma/{id:guid}")]
    public async Task<IActionResult> AtualizarAluno([FromRoute] Guid id, [FromBody] CriarAlunoRequest criarAlunoRequest)
    {
        try
        {
            var turma = await turmaService.ConsultarPorIdAsync(id);

            if (turma is null)
            {
                return BadRequest("Aluno não encontrado!");
            }
            
            turma.Nome = criarAlunoRequest.Nome;

            var turmaAtualizada = await turmaService.AtualizarAsync();
            if (turmaAtualizada == 0)
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

    [HttpDelete, Route("/Delete/Turma/{id:guid}")]
    public async Task<IActionResult> ExcluirAluno([FromRoute] Guid id)
    {
        try
        {
            var turma = await turmaService.ConsultarPorIdAsync(id);

            if (turma is null)
            {
                return BadRequest("Aluno não encontrado!");
            }

            await turmaService.DeletarAsync(turma);
            return Ok(new DeleteResponse{ Staus = "OK", Mensagem = "OK"});
        }
        catch (Exception e)
        {
            return BadRequest(new DeleteResponse{ Mensagem = e.Message, Staus = "ERRO" });
        }
    }
}