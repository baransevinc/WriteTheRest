using Story.Application.DependencyResolver;
using Microsoft.EntityFrameworkCore;
using Story.Data.Context;
using Microsoft.AspNetCore.Mvc;
using WriteTheRest.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Baðýmlýlýklarý ekle
StoryDependencyResolver.ConfigureServices(builder.Services, builder.Configuration);

// DbContext ekle (zaten DependencyResolver içinde ekli deðilse)
builder.Services.AddDbContext<StoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS ayarý ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", policy =>
        policy.WithOrigins(
            "https://localhost:7265" // Web projenin adresini buraya ekle
           
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

// Controller ve API davranýþ ayarlarý
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS'u pipeline'a ekle
app.UseCors("AllowWebApp");

app.UseAuthorization();

app.ConfigureCustomExceptionMiddleware();

app.MapControllers();

app.Run();