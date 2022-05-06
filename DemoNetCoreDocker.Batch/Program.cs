using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .WriteTo.Console(
        restrictedToMinimumLevel: LogEventLevel.Information,
        outputTemplate: "[{Timestamp:o}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File(
        restrictedToMinimumLevel: LogEventLevel.Information,
        outputTemplate: "[{Timestamp:o}] [{Level:u3}] {Message:lj}{NewLine}{Exception}",
        path: "c:/logs/batch.txt")
    .CreateLogger();

foreach (string key in Environment.GetEnvironmentVariables().Keys)
{
    Log.Logger.Information($"EnvironmentVariable:[{key}]:[{Environment.GetEnvironmentVariable(key)}]");
}

foreach (string argument in Environment.GetCommandLineArgs())
{
    Log.Logger.Information($"CommandLineArg:[{argument}]");
}

//while (true)
//{
//    //Console.WriteLine($"{DateTime.Now}");
//    Thread.Sleep(TimeSpan.FromMilliseconds(1_000));
//}

Thread.Sleep(TimeSpan.FromMilliseconds(30_000));
