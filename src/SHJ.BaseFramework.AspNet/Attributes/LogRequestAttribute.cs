using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Diagnostics;

namespace Microsoft.AspNetCore.Mvc;


public class LogRequestAttribute : ActionFilterAttribute, IExceptionFilter
{
    private readonly Stopwatch _stopwatch = new();

    private Serilog.Core.Logger _log = new LoggerConfiguration().WriteTo
                .File($"Logs/LogRequestAttribute-{DateTime.Now}.txt", rollingInterval: RollingInterval.Year)
                .WriteTo.Console()
                .CreateLogger();
    public LogRequestAttribute()
    {
        Log.Information($"##################  LogRequestAttribute - {DateTime.Now}  ####################");
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        _log.Information($"OnActionExecuting: ");
        _log.Information("************* Executing ***************");
        _log.Information($"start executing : {_stopwatch.ElapsedMilliseconds}");
        _log.Information($"{context.ActionDescriptor.DisplayName}-" + $"time : {DateTime.Now}");

        if (context.RouteData.Values.Count > 0)
        {
            _log.Information("- Rout Info : ");
            var paramsList = context.RouteData.Values;
            foreach (var param in paramsList)
            {
                _log.Information(param.Key + ":" + param.Value);
            }

        }

        if (context.ModelState.Count > 0)
        {
            _log.Information("Model state  info: ");
            var models = context.ModelState;
            foreach (var model in models)
            {
                _log.Information(model.Key + " : " + model.Value.AttemptedValue);

            }

        }
        _log.Information($"End executing : {_stopwatch.ElapsedMilliseconds} time : {DateTime.Now}");
        _log.Information("************* Executing ***************");
        base.OnActionExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        _log.Information($"OnActionExecuted: ");
        _log.Information("************* Executed ***************");
        _log.Information($"start executed : {_stopwatch.ElapsedMilliseconds}");
        _log.Information($"{context.ActionDescriptor.DisplayName}-" + $"time : {DateTime.Now}");
        if (context.ModelState.ErrorCount > 0)
        {
            var models = context.ModelState;
            foreach (var model in models)
            {
                foreach (var error in model.Value.Errors)
                {
                    _log.Error(model.Key + " : " + error.ErrorMessage);
                }


            }
        }
        _log.Information($"End executed : {_stopwatch.ElapsedMilliseconds}");
        _log.Information("************* Executed ***************");
        base.OnActionExecuted(context);
    }

    public void OnException(ExceptionContext context)
    {
        _log.Information($"OnException: ");
        Console.ForegroundColor = ConsoleColor.Red;
        _log.Information("************* Exception ***************");
        _log.Information($"{context.ActionDescriptor.DisplayName}- time : {_stopwatch.ElapsedMilliseconds}");
        _log.Information($"{context.Exception}:{DateTime.Now.ToString()}");
        if (context.RouteData.Values.Count > 0)
        {
            var paramsList = context.RouteData.Values;
            foreach (var param in paramsList)
            {
                _log.Error(param.Key + ":" + param.Value);
            }
        }
        _log.Information($"Exception message : {context.Exception.Message}");
        _log.Information("************* Exception ***************");

    }


}
