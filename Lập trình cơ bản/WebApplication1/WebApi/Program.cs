using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Services.Entities;
using Services.Interfaces;
using Services.Services;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MyContextContext>(options => {
	options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddAutoMapper(typeof(MapperProfile));

//builder.Services.AddScoped<IValidator<TodoRequest>, TodoRequestValidator>();
builder.Services.AddFluentValidationAutoValidation(c =>
{
    c.DisableDataAnnotationsValidation = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoServices, TodoServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IVehicleServices, VehicleServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
