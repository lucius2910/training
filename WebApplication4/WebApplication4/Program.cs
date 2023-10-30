using Microsoft.EntityFrameworkCore;
using Services.Entities;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<MyContextContext>(options => {
	options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddScoped<IGiaovienServices, GiaovienServices>();
builder.Services.AddScoped<IHocsinhServices, HocsinhServices>();
builder.Services.AddScoped<ILopServices, LopServices>();

// Register dependence injection


//builder.Services.AddTransient<ITodoServices, TodoServices>();
//builder.Services.AddSingleton<ITodoServices, TodoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
