using Microsoft.EntityFrameworkCore;
using Trabalho03;
using Trabalho03.Data;
using Trabalho03.Services;
using Trabalho03.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared")
);

builder.Services.AddSwaggerConfiguration();
builder.Services.AddAuthenticationConfiguration();

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();