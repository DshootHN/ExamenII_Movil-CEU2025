using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AppWebAPI.Data;
using AppWebAPI.Models;
using AppWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

//Configurar conexion a DB 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Examen II BackEnd",
        Version = "v1.0",
        Description = "Examen II de Programacion Movil 2025"
    });
}
    );

builder.Services.AddScoped<TareasService>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.Run();
