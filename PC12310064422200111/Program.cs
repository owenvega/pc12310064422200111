using Microsoft.EntityFrameworkCore;
using PC1.CORE.Infrastructure.Data;
using PC1.CORE.Core.Interfaces;
using PC1.CORE.Core.Services;
using PC1.CORE.Infrastructure.Repositories;
using PC1.CORE.Core.DTOs;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TallerMecanicoDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevConnection")
    ));

builder.Services.AddTransient<IOrdenServicioService, OrdenServicioService>();
builder.Services.AddTransient<IOrdenServicioRepository, OrdenServicioRepository>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

app.Run();