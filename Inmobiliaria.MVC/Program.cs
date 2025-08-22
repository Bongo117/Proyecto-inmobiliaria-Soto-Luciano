using Microsoft.EntityFrameworkCore;
 using Inmobiliaria.MVC.Data; 

var builder = WebApplication.CreateBuilder(args);

// 👉 Registramos el DbContext usando la cadena de conexión de appsettings.json
 builder.Services.AddDbContext<InmobiliariaContext>(options =>
 {
   var cs = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(cs, ServerVersion.AutoDetect(cs));
 });

// Servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
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
