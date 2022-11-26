using BkVirtual.Application.RegisterServices;
using BkVirtual.Core.RegisterServices;
using BkVirtual.Infrastructure.RegisterServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegistrarServicosCore();
builder.Services.RegistrarServicesApplication();
builder.Services.RegistrarServicosInfrasctructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();