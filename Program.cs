using Microsoft.EntityFrameworkCore;
using AgenciaDeViajes.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using AgenciaDeViajes.Services; // <-- Servicio de clima

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// ✅ Usa la cadena de conexión desde las variables de entorno
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// ✅ Habilita autenticación con cookies y Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Login/Index";
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"] 
        ?? throw new InvalidOperationException("Google ClientId no configurado");
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] 
        ?? throw new InvalidOperationException("Google ClientSecret no configurado");
});

builder.Services.AddAuthorization(); // Roles opcionales

// === REGISTRO DEL SERVICIO DE CLIMA ===
builder.Services.AddHttpClient<WeatherService>(); // <-- Registro del servicio HTTP

var app = builder.Build();

// ✅ Ejecuta migraciones en producción (por ejemplo, Render)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// ✅ Configuración del pipeline HTTP
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
