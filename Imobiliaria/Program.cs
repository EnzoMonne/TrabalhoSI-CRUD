using Imobiliaria.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<FakeDbContext>();

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.Run();
