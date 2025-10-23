using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace LoggingDemoNamespace
{

    public class LoggingDemoProgram
    {
        public static void Main()
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt")
                .CreateLogger();

            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddSerilog())
                .AddSingleton<DataProcessingService>()
                .AddSingleton<IDataProcessor, UserInputProcessor>()
                .AddSingleton<ILogger, CustomLogger>()
                .AddSingleton<ExceptionService>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            var dataProcessingService = serviceProvider.GetService<DataProcessingService>();
            var exceptionService = serviceProvider.GetService<ExceptionService>();

            try

            {

                // Example of console and file logging

                dataProcessingService.ProcessAndDisplay("Hello, World!");

                // Example of custom logging

                var customLogger = serviceProvider.GetService<ILogger>();

                customLogger.LogInformation("Custom log entry.");

                // Example of exception logging
                throw new InvalidOperationException("Simulated exception.");
            }
            catch (Exception ex)
            {
                exceptionService.HandleException(ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }

    public class DataProcessingService
    {
        private readonly ILogger<DataProcessingService> _logger;

        public DataProcessingService(ILogger<DataProcessingService> logger)
        {
            _logger = logger;
        }

        public void ProcessAndDisplay(string input)
        {
            _logger.LogInformation("Processing input: {Input}", input.ToUpper());
        }
    }
    
    public interface IDataProcessor
    {
        string ProcessData(string input);
    }

    public class UserInputProcessor : IDataProcessor
    {
        public string ProcessData(string input)
        {
            return input.ToUpper();
        }

    }

    public class CustomLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        }
        public void LogError(Exception ex, string message)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now}: {message}\n{ex}");
        }

        // Implementation of ILogger interface members
        public IDisposable BeginScope<TState>(TState state)
        {
            // No scope support, return dummy disposable
            return new NoopDisposable();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // Enable all log levels
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Information:
                    LogInformation(message);
                    break;
                case LogLevel.Error:
                    LogError(exception, message);
                    break;
                default:
                    Console.WriteLine($"[{logLevel}] {DateTime.Now}: {message}");
                    break;
            }
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose() { }
        }
    }

    public class ExceptionService
    {
        private readonly ILogger<ExceptionService> _logger;
        public ExceptionService(ILogger<ExceptionService> logger)
        {
            _logger = logger;
        }
        public void HandleException(Exception ex)
        {
            _logger.LogError(ex, "An exception occurred.");
        }
    }
}