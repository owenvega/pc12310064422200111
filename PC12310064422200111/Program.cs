using Microsoft.EntityFrameworkCore;
using PC1.CORE.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TallerMecanicoDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevConnection")
    ));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

app.Run();