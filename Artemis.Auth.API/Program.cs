using Artemis.Auth.Domain.Interfaces;
using Artemis.Auth.Infrastructure.Data;
using Artemis.Auth.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) EF Core + PostgreSQL
builder.Services.AddDbContext<AuthDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("AuthDb")));
    
// 2) Repository kaydı
builder.Services.AddScoped<IUserRepository, UserRepository>();


// 3) CQRS altyapısı (MediatR)
/*builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));*/
    

// 5) Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Artemis Auth API",
        Version = "v1",
        Description = "Authentication endpoints for Artemis"
    });
});

var app = builder.Build();


// 6) Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Artemis Auth API v1");
        // c.RoutePrefix = string.Empty; // if you want UI at root “/”
    });
}


app.UseRouting();

// Eğer JWT Authentication:
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();