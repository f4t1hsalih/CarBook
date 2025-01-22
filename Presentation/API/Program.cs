using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Interfaces;
using Persistence.Context;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<AddAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();

builder.Services.AddControllers();

// OpenAPI'yi ekleyin
builder.Services.AddEndpointsApiExplorer(); // API keþfi için
builder.Services.AddSwaggerGen(); // Swagger'ý ekleyin (OpenAPI dokümantasyonunu kullanacak)
builder.Services.AddOpenApi(); // OpenAPI'yi eklemeye devam edin

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger'ý etkinleþtir
    app.UseSwaggerUI(); // Swagger UI'yý etkinleþtir
    app.MapOpenApi(); // OpenAPI'yi de harici olarak sunmaya devam edin
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
