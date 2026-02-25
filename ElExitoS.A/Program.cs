using ElExitoS.A_.Services;
using ElExitoS.Models;

var builder = WebApplication.CreateBuilder(args);

// Registro de servicios en memoria
builder.Services.AddSingleton<IProductoService, ProductoService>();
builder.Services.AddSingleton<IFacturaService, FacturaService>();
builder.Services.AddSingleton<IDetalleFacturaService, DetalleFacturaService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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