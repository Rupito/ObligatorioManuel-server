using LogicaAccesoDatos.EntityFramework.Repositorios;
using LogicaAplicacion.CasosDeUso.CUEquipo;
using LogicaAplicacion.CasosDeUso.CUObjetoCeleste;
using LogicaAplicacion.CasosDeUso.CUObservacion;
using LogicaAplicacion.CasosDeUso.CUPrestamo;
using LogicaAplicacion.CasosDeUso.CUSocio;
using LogicaAplicacion.InterfacesCasoDeUso.Equipos;
using LogicaAplicacion.InterfacesCasoDeUso.ObjetosCelestes;
using LogicaAplicacion.InterfacesCasoDeUso.Observaciones;
using LogicaAplicacion.InterfacesCasoDeUso.Prestamos;
using LogicaAplicacion.InterfacesCasoDeUso.Socios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ObligatorioManuel.InterfacesRepositorios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.

builder.Services.AddDbContext<LogicaAccesoDatos.EntityFramework.ObligatorioContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ObligatorioDB")));

//Inicializamos Repositorios
builder.Services.AddScoped<IRepositorioSocio, RepositorioSocioEF>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipoEF>();
builder.Services.AddScoped<IRepositorioTelescopio, RepositorioTelescopioEF>();
builder.Services.AddScoped<IRepositorioMontura, RepositorioMonturaEF>();
builder.Services.AddScoped<IRepositorioEquipoVisual, RepositorioEquipoVisualEF>();
builder.Services.AddScoped<IRepositorioOcular, RepositorioOcularEF>();
builder.Services.AddScoped<IRepositorioCamara, RepositorioCamaraEF>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamoEF>();
builder.Services.AddScoped<IRepositorioObservacion, RepositorioObservacionEF>();
builder.Services.AddScoped<IRepositorioObjetoCeleste, RepositorioObjetoCelesteEF>();

//Inicializamos Casos de uso
//Socio
builder.Services.AddScoped<IAltaSocioCU, AltaSocioCU>();
builder.Services.AddScoped<IObtenerSociosCU, ObtenerSociosCU>();
builder.Services.AddScoped<ILoginSocioCU, LoginSocioCU>();
builder.Services.AddScoped<IEncontrarSocioPorIdCU, EncontrarSocioPorIdCU>();
//Equipo
builder.Services.AddScoped<IObtenerEquiposCU, ObtenerEquiposCU>();
builder.Services.AddScoped<IAltaTelescopioCU, AltaTelescopioCU>();
builder.Services.AddScoped<IAltaMonturaCU, AltaMonturaCU>();
builder.Services.AddScoped<IAltaCamaraCU, AltaCamaraCU>();
builder.Services.AddScoped<IAltaOcularCU, AltaOcularCU>();
builder.Services.AddScoped<IEncontrarEquipoPorIdCU, EncontrarEquipoPorIdCU>();
builder.Services.AddScoped<IEditarEquipoCU, EditarEquipoCU>();
builder.Services.AddScoped<IBajaEquipo, BajaEquipoCU>();
//Prestamo
builder.Services.AddScoped<IAltaPrestamoCU, AltaPrestamoCU>();
builder.Services.AddScoped<IEncontrarPrestamoPorIdCU, EncontrarPrestamoPorIdCU>();
builder.Services.AddScoped<IObtenerPrestamoCU, ObtenerPrestamoCU>();
builder.Services.AddScoped<IObtenerPrestamosActivosPorSocioCU, ObtenerPrestamosActivosPorSocioCU>();
builder.Services.AddScoped<IObtenerSociosPorTelescopioCU, ObtenerSociosPorTelescopioCU>();
builder.Services.AddScoped<IRegistrarDevolucionPrestamoCU, RegistrarDevolucionPrestamoCU>();
builder.Services.AddScoped<IObtenerPrestamosPorCoordinadorCU, ObtenerPrestamosPorCoordinadorCU>();
//Observacion
builder.Services.AddScoped<IAltaObservacionCU, AltaObservacionCU>();
builder.Services.AddScoped<IEncontrarObservacionPorIdCU, EncontrarObservacionPorIdCU>();
builder.Services.AddScoped<IObtenerObservacionCU, ObtenerObservacionCU>();
builder.Services.AddScoped<IRankingObjetosCelestesCU, RankingObjetosCelestesCU>();
//ObjetoCeleste
builder.Services.AddScoped<IAltaObjetoCelesteCU, AltaObjetoCelesteCU>();
builder.Services.AddScoped<IEncontrarObjetosCelestesPorIdCU, EncontrarObjetosCelestesPorIdCU>();
builder.Services.AddScoped<IObtenerObjetoCelesteCU, ObtenerObjetoCelesteCU>();



//Configuracion Autenticacion con token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Configurar la autorización
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// autorization y authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
