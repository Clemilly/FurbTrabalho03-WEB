using Microsoft.AspNetCore.Mvc;
using Trabalho03.Models.Entities;
using Trabalho03.Models.Requests;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Controllers;

[ApiController]
[Route("Turma")]
public class TurmaController(ITurmaService turmaService) : ControllerBase
{
    [HttpPost, Route("")]
    public async Task<IActionResult> CriarTurma(CriarTurmaRequest turmaRequest)
    {
        // try
        // {
        //     var turmaCriada = await _turmaService.CriarTurmaAsync(turmaRequest);
        //     var turmaViewModel = new CriarTurmaViewModel()
        //     {
        //         Nome = turmaCriada.Nome
        //     };
        //     return Ok(turmaViewModel);
        // }
        // catch (Exception e)
        // {
        //     return BadRequest("Ocorreu um erro ao processar sua requisição!");
        // }
        return null;
    }
}