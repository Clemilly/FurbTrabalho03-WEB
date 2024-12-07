namespace Trabalho03.Services.Interfaces;

public interface IAuthService
{
    (string, DateTime) GerarJwtAuth();
}