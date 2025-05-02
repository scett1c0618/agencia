using Microsoft.EntityFrameworkCore;
using appAgencia.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Usa cadena desde variables de entorno
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Ejecuta migraciones automáticamente en producción
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();  // 👈 Esto crea/modifica tablas en Render
}

/* Reemplazar esto para trabajar con base de datos local en el archivo de appsetings.json - Jean Estrada */
/* "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TrabajoFinalProgra;Username=postgres;Password=posgresjeanestrada;"
  }, */


// Configuración del pipeline HTTP
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();