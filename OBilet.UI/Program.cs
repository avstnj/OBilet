using OBilet.Domain.Models.Configuration;
using OBilet.UI.Service.Abstract;
using OBilet.UI.Service.Concreate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

#region Get OBilet Outsource Api Info
builder.Services.Configure<OBiletUIConfigurationModel>(builder.Configuration.GetSection("OBiletUIConfigurationModel"));
#endregion

#region Dependency Injection
builder.Services.AddScoped<IOBiletServiceManager, OBiletServiceManager>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
