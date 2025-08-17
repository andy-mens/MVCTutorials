using MongoDB.Driver;
using MVCTutorials.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IMongoClient>(s =>
{
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
    if (settings == null || string.IsNullOrEmpty(settings.ConnectionString))
    {
        throw new InvalidOperationException("MongoDBSettings or ConnectionString is not configured properly.");
    }
    return new MongoClient(settings.ConnectionString);
});
// Configure MongoDB settings from appsettings.json

builder.Services.AddScoped<ItemService>();

//builder.Services.AddSingleton<IMongoClient>(s =>
//{
//    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
//    return new MongoClient(settings.ConnectionString);
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
// This code sets up an ASP.NET Core MVC application with a default route and static asset handling.