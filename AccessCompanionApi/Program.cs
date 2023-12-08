using AccessCompanionApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Security;
using AccessCompanionApi.Abstractions;
using AccessCompanionApi.Infrastructure;
using Serilog;
using Microsoft.AspNetCore.Builder;
using AccessCompanionApi.GraphQl;


Environment.SetEnvironmentVariable(
    "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", 
    false.ToString()
    );

// static IHostBuilder CreateHostBuilder(string[] args) =>Host
//     .CreateDefaultBuilder(args)
//     .UseSerilog();



var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("../log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("USING SERILOG");

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddCors(options=>{
    options.AddPolicy("AllowXamarin", builder =>{
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var connectionStringFromContainer = builder.Configuration.GetConnectionString("ContainerConnection");

var context = builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(
        connectionStringFromContainer,
        //connectionString, 
        sqlServerOptionsAction: sqlOptions => {
            sqlOptions.EnableRetryOnFailure();
    });
});
builder.Services.AddScoped<IDbContext, AppDbContext>();
// builder.Services.AddSingleton<IPermissionRepository, PermissionRepository>();
// builder.Services.AddSingleton<IPermissionTypeRepository, PermissionTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapGraphQL());

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();