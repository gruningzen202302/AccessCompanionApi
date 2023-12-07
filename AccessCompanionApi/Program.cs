using AccessCompanionApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.SqlServer;

// void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
// {
//     // other code...

//     DbInitializer.Seed(context);
// }

Environment.SetEnvironmentVariable(
    "DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", 
    false.ToString()
    );

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
    //options.EnableSensitiveDataLogging();
    //options.EnableDetailedErrors();

});

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
