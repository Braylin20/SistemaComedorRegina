using Microsoft.EntityFrameworkCore;
using SistemaComedorRegina.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
