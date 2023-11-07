using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationTurnos.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(300); //5 minutos sesion iniciada
    options.Cookie.HttpOnly = true; //Almacena el cookie solo en el navegador
});

builder.Services.AddControllersWithViews(options => 
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
                ); //Este option nos evita colocar [ValidateAntiForgeryToken] en cada metodo
builder.Services.AddDbContext<TurnosContext>(opciones => opciones.UseSqlServer("name=Connection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
