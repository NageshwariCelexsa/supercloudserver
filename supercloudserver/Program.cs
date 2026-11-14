using Microsoft.AspNetCore.DataProtection;
using supercloudserver.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Data Protection to use a local App_Data folder in workspace
var keysFolder = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataProtection-Keys");
Directory.CreateDirectory(keysFolder);
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysFolder))
    .SetApplicationName("SuperCloudServer");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ICloudDataService, CloudDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
