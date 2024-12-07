using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trabalho03.Services.Interfaces;
using Trabalho03.Views;

namespace Trabalho03.Controllers;

[AllowAnonymous]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpGet]
    [Route("token")]
    public AutenticacaoViewModel AutenticarUsuario(IAuthService authService)
    {
        var (token, expiration) = authService.GerarJwtAuth();

        return new AutenticacaoViewModel
        {
            Token = "Bearer " + token,
            DataExpiracao = expiration,
        };
    }
}