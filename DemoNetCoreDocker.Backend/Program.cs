using Dapper;
using DemoNetCoreDocker.Backend;
using MySql.Data.MySqlClient;
using Serilog;
using Serilog.Events;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// new EnvironmentInfo();

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
        path: "c:/logs/log.txt")
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
    var result = "Nothing";
    try
    {
        // Sql Server
        // ConnectionString
        // Server=<Server>;Database=<Database>;;User ID=<User ID>;Password=<Password>;
        //using (var connection = new SqlConnection("ConnectionString"))
        //{
        //    connection.Open();
        //    result = await connection.ExecuteScalarAsync<string>("SELECT @@VERSION");
        //    connection.Close();
        //}
        // MySql Server
        // Docker
        // docker run -d -p 3306:3306 --name demo-mysql -e MYSQL_ALLOW_EMPTY_PASSWORD=yes mysql
        // ConnectionString
        // Server=<Server>;Port=<Port>;Database=<Database>;Uid=<Uid>;Pwd=<Pwd>;
        //using (var connection = new MySqlConnection("ConnectionString"))
        //{
        //    connection.Open();
        //    result = await connection.ExecuteScalarAsync<string>("SELECT VERSION()");
        //    connection.Close();
        //}
    }
    catch (Exception e)
    {
        result = e.ToString();
    }
    Log.Logger.Information($"Result:{result}");
    await context.Response.WriteAsync(result);
});

app.Run();
