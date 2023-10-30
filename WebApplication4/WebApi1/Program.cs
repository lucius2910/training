using Microsoft.EntityFrameworkCore;
using Services.Entities;
using Services.Interfaces;
using Services.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();

// Databse
var connectionString = configuration.GetConnectionString("Database");

// Core
var migrationsAssemblyCore = typeof(WebApplication).GetTypeInfo().Assembly.GetName().Name;
builder.Services.AddDbContext<MyContextContext>(builder =>
{
    builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly("WebApi1"));
    builder.LogTo(Console.WriteLine);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register dependence injection
//builder.Services.AddTransient<ITodoServices, TodoServices>();
//builder.Services.AddSingleton<ITodoServices, TodoServices>();

builder.Services.AddScoped<IGiaovienServices, GiaovienServices>();
builder.Services.AddScoped<IHocsinhServices, HocsinhServices>();
builder.Services.AddScoped<ILopServices, LopServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
