using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Data.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IPlatformInstanceRepo, PlatformInstanceRepo>();

//Adding in memory database 
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("PlatformInMemoryDb")
);

//Adding Auto Mapper
//assembly meaning all the dll files, that contains classes,interfaces and etc inotherwords we are passing all the files
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    InitializePlatformDb.InitPopulation(app);
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllers();

app.Run();
