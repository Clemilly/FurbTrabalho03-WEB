using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Trabalho03.Models.Requests;
using Trabalho03.Models.Responses;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Controllers;

[ApiController]
[Authorize]
[Route("Materia")]
public class MateriaController(IMateriaService materiaService) : ControllerBase
{
     [HttpPost, Route("/Criar")]
    public async Task<IActionResult> CriarNota(CriarMateriaRequest materiaRequest)
    {
        try
        {
            await materiaService.CriaMateriaAsync(materiaRequest);

            var viewModel = new CriarMateriaViewModel()
            {
                Nome = materiaRequest.Nome,
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

    [HttpGet, Route("/Consultar")]
    public async Task<IActionResult> ObterMaterias()
    {
        try
        {
            var materias = await materiaService.ObterTodasMaterias();
            return Ok(materias);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpGet, Route("/Consultar/{idMateria:guid}")]
    public async Task<IActionResult> ObterNota([FromRoute] Guid idMateria)
    {
        try
        {
            var materia = await materiaService.ObterMateriaId(idMateria);

            if (materia.Equals(Guid.Empty))
            {
                return BadRequest("Aluno não encontrado!");
            }

            return Ok(materia);
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpPatch, Route("/Atualizar/{id:guid}")]
    public async Task<IActionResult> AtualizarMateria([FromRoute] Guid id, [FromBody] CriarMateriaRequest materiaRequest)
    {
        try
        {
            var materia = await materiaService.ObterMateriaId(id);

            if (materia is null)
            {
                return BadRequest("Nota não encontrada!");
            }

            materia.Nome = materiaRequest.Nome;

            await materiaService.AtualizarMateriaAsync(materia);
            
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest("Ocorreu um erro ao processar sua requisição!");
        }
    }

    [HttpDelete, Route("/Delete/{id:guid}")]
    public async Task<IActionResult> ExcluirAluno([FromRoute] Guid id)
    {
        try
        {
            var materia = await materiaService.ObterMateriaId(id);

            if (materia is null)
            {
                return BadRequest("Nota não encontrada!");
            }

            await materiaService.DeletarMateria(materia);
            return Ok(new DeleteResponse { Staus = "OK", Mensagem = "OK" });
        }
        catch (Exception e)
        {
            return BadRequest(new DeleteResponse { Mensagem = e.Message, Staus = "ERRO" });
        }
    }
}