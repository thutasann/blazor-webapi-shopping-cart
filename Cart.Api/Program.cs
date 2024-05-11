using Cart.Api.Data;
using Cart.Api.Middlewares;
using Cart.Api.Repositories.Contracts;
using Cart.Api.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

string[] allowedOrigin = ["http://localhost:5158"];
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!);
});


// Regigster Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// ------ Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseMiddleware<ResponseTimeMiddleware>();


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("myAppCors");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

