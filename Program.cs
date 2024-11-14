using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; // Para DbContext e UseSqlServer
using Just.Data; 

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Server=localhost\\SQLEXPRESS;Database=Rafaela;Trusted_Connection=True";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
/* builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));*/

// Adiciona serviços ao contêiner.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configura o pipeline de requisições.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuração das rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "playlists",
    pattern: "Playlists/{action=Index}/{id?}",
    defaults: new { controller = "Playlist" });

app.MapControllerRoute(
    name: "criadores",
    pattern: "Criadores/{action=Index}/{id?}",
    defaults: new { controller = "Criador" });

app.MapControllerRoute(
    name: "conteudos",
    pattern: "Conteudos/{action=Index}/{id?}",
    defaults: new { controller = "Conteudo" });

/* app.MapControllerRoute(
    name: "usuarios",
    pattern: "Usuarios/{action=Index}/{id?}",
    defaults: new { controller = "Usuario" });*/

  app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { controller = "Usuario", action = "Index" });
    

app.Run();