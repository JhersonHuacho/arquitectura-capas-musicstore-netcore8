using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Huachin.MusicStore.AccesoDatos.Contexto;
using Huachin.MusicStore.Repositorios.Implementaciones;
using Huachin.MusicStore.Repositorios.Interfaces;
using Huachin.MusicStore.Servicio.Implementaciones;
using Huachin.MusicStore.Servicio.Interfaces;
using Huachin.MusicStore.UI.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<MusicStoreContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdPedidos"));
});

builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

builder.Services.AddScoped<IGenreRepositorio, GenreRepositorio>();
builder.Services.AddScoped<IGenreServicio, GenreServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
