using BkVirtual.Application.RegisterServices;
using BkVirtual.Core.RegisterServices;
using BkVirtual.Infrastructure.DTOs;
using BkVirtual.Infrastructure.RegisterServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegistrarServicosCore();
builder.Services.RegistrarServicesApplication();
builder.Services.RegistrarServicosInfrasctructure(builder.Configuration);

builder.Services.AddHttpClient();
builder.Services.Configure<PagamentoConfig>(builder.Configuration.GetSection(nameof(PagamentoConfig)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();