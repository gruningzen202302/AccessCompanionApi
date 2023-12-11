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
using GraphQL.Server.Ui.Voyager;
using Microsoft.Extensions.Options;
using AccessCompanionApi.GraphQl.TypeDescriptors;

Environment.SetEnvironmentVariable(
    "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", 
    false.ToString()
    );

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate: " 🛜  {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("../logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("USING SERILOG");

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

// var context = builder.Services.AddDbContext<AppDbContext>(options => {
//     options.UseSqlServer(
//         connectionStringFromContainer,
//         //connectionString, 
//         sqlServerOptionsAction: sqlOptions => {
//             sqlOptions.EnableRetryOnFailure();
//     });
// });
// builder.Services.AddScoped<IDbContext, AppDbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<PermissionTypeDescriptor>()
    .AddType<PermissionDescriptor>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    ;

builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
});
builder.Services.AddScoped<IDbContext, AppDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
    endpoints.MapGraphQLVoyager("ui/voyager");
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();