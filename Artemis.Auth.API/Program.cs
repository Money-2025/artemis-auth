using Artemis.Auth.Domain.Interfaces;
using Artemis.Auth.Infrastructure.Data;
using Artemis.Auth.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1) EF Core + PostgreSQL
builder.Services.AddDbContext<AuthDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("AuthDb")));
    
// 2) Repository kaydı
builder.Services.AddScoped<IUserRepository, UserRepository>();


// 3) CQRS altyapısı (MediatR)
/*builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));*/
    
    
// 4) Validation pipeline (FluentValidation)
/*builder.Services
    .AddControllers()
    .AddFluentValidation(cfg =>
        cfg.RegisterValidatorsFromAssemblyContaining<Program>());*/
        
        
// 5) Swagger/OpenAPI
/*builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();*/

var app = builder.Build();


// 6) Middleware pipeline
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

// Eğer JWT Authentication:
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();