using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using _1er_Parcial.Data;
//creamos la injeccion del contexto y sus respectiva BLL
var builder = WebApplication.CreateBuilder(args);
var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(Options=>Options.UseSqlite(ConStr));
builder.Services.AddScoped<LibrosBLL>();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
