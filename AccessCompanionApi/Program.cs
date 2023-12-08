using AccessCompanionApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Security;
using AccessCompanionApi.Abstractions;
using AccessCompanionApi.Infrastructure;
using Serilog;
using Microsoft.AspNetCore.Builder;


Environment.SetEnvironmentVariable(
    "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", 
    false.ToString()
    );

static IHostBuilder CreateHostBuilder(string[] args) =>Host
    .CreateDefaultBuilder(args)
    .UseSerilog();

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Console()
    .CreateLogger();

Log.Information("USING SERILOG");
// try
// {
//     CreateHostBuilder(args).Build().Run();
// }
// catch (Exception ex)
// {
//     Log.Fatal(ex, "Application start-up failed");
// }
// finally
// {
//     Log.CloseAndFlush();
// }

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{
    options.AddPolicy("AllowXamarin", builder =>{
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var context = builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions => {
        sqlOptions.EnableRetryOnFailure();
    });
});

// builder.Services.AddSingleton<IPermissionRepository, PermissionRepository>();
// builder.Services.AddSingleton<IPermissionTypeRepository, PermissionTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseHttpsRedirection();


app.Run();