using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Data.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPlatformInstanceRepoInterface, PlatformInstanceRepo>();


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
    app.MapOpenApi();
    InitializePlatformDb.InitPopulation(app);
}
app.UseHttpsRedirection();

app.Run();

