using Dapper;
using Serilog;
using Serilog.Events;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"ContentRootPath:[{builder.Environment.ContentRootPath}]");

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console(
        restrictedToMinimumLevel: LogEventLevel.Information,
        outputTemplate: "[{Timestamp:o}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File(
        restrictedToMinimumLevel: LogEventLevel.Information,
        outputTemplate: "[{Timestamp:o}] [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        path: $"{builder.Environment.ContentRootPath}/log.txt")
    .CreateLogger();

foreach (string key in Environment.GetEnvironmentVariables().Keys)
{
    Log.Logger.Information($"EnvironmentVariable:[{key}]:[{Environment.GetEnvironmentVariable(key)}]");
}

foreach (string argument in Environment.GetCommandLineArgs())
{
    Log.Logger.Information($"CommandLineArg:[{argument}]");
}

builder.Host.UseSerilog(Log.Logger);

var app = builder.Build();

app.MapGet("/", async (context) =>
{
    var result = "";
    try
    {
        //using (var connection = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;Database=DemoNetCore6;"))
        using var connection = new SqlConnection("Server=10.10.95.31;Database=temp;Persist Security Info=false;TrustServerCertificate=true;Encrypt=true;User ID=ards2;Password=!!5/454vu04rup!;MultipleActiveResultSets=true;");
        connection.Open();
        result = await connection.ExecuteScalarAsync<string>("SELECT @@VERSION");
    }
    catch (Exception e)
    {
        result = e.ToString();
    }
    Log.Logger.Information($"Response:{result}");
    await context.Response.WriteAsync(result);
});

app.Run();
