using BoBPo.Components;
using BoBPo.Data;
using BoBPo.Interfaces.Repositories;
using BoBPo.Interfaces.Services;
using BoBPo.Repositories;
using BoBPo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibraryDbContext>
    (options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Service
builder.Services.AddScoped<IBookService, BookService>();
//Repository
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
