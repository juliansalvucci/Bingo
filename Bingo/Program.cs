using Bingo.Contexts;
using Bingo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//INYECCI?N DE DEPENDENCIAS.
builder.Services.AddScoped<IBingoService, BingoService>();

//EF CONFIGURATION.
builder.Services.AddDbContext<BingoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conection"));
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
