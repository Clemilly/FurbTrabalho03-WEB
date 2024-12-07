using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;
using Trabalho03.Models.Responses;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Controllers;

[ApiController]
[Route("Nota")]
[Authorize]
public class NotaController(INotaService notaService) : ControllerBase
{
    [HttpPost, Route("/Criar/Nota")]
    public async Task<IActionResult> CriarNota(CriarNotaRequest notaRequest)
    {
        try
        {
            var nota = new Nota
            {
                AlunoId = notaRequest.AlunoId,
                MateriaId = notaRequest.MateriaId,
                Peso = notaRequest.Peso
            };

            await notaService.CriarNota(nota);

            var viewModel = new CriarNotaViewModel
            {
                AlunoId = nota.AlunoId,
                MateriaId = nota.MateriaId,
                Peso = nota.Peso
            };

            return Ok(viewModel);
        }
        catch (SqliteException e)
        {
            return BadRequest("Aluno e/ou Materia não cadastrada");
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpGet, Route("/Consultar/Notas")]
    public async Task<IActionResult> ObterNotas()
    {
        try
        {
            var notas = await notaService.ObterNotas();
            return Ok(notas);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpGet, Route("/Consultar/Nota/{idAluno:guid}")]
    public async Task<IActionResult> ObterNota([FromRoute] Guid idAluno)
    {
        try
        {
            var notas = await notaService.ObterNotasPorAlunoId(idAluno);

            if (notas.Length == 0)
            {
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(notas);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpPatch, Route("/Atualizar/Nota/{id:guid}")]
    public async Task<IActionResult> AtualizarAluno([FromRoute] Guid id, [FromBody] CriarNotaRequest criarNotaRequest)
    {
        try
        {
            var nota = await notaService.ObterNotaPorId(id);

            if (nota is null)
            {
                return BadRequest("Nota não encontrada!");
            }

            nota.Peso = criarNotaRequest.Peso;
            nota.AlunoId = criarNotaRequest.AlunoId;
            nota.MateriaId = criarNotaRequest.MateriaId;

            await notaService.Atualizar();
            
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpDelete, Route("/Delete/Nota/{id:guid}")]
    public async Task<IActionResult> ExcluirAluno([FromRoute] Guid id)
    {
        try
        {
            var nota = await notaService.ObterNotaPorId(id);

            if (nota is null)
            {
                return BadRequest("Nota não encontrada!");
            }

            await notaService.Deletar(nota);
            return Ok(new DeleteResponse { Staus = "OK", Mensagem = "OK" });
        }
        catch (Exception e)
        {
            return BadRequest(new DeleteResponse { Mensagem = e.Message, Staus = "ERRO" });
        }
    }
}