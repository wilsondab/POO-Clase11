
using Ejercicio4Modulo3.Models;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionHandler : IMiddleware
{

    private ILogService logService;
    public GlobalExceptionHandler(ILogService logService)
    {
        this.logService = logService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        var log = new Logs
        {
            Path = context.Request.Path,
            Method = context.Request.Method,
            Fecha = DateTime.Now,
        };

        try
        {
            await next(context);
            log.Success = true;

        }
        catch (Exception ex)
        {

            log.Success = false;

            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var respuesta = new
            {
                error = $"Error de validacion en API: {context.Request.Path.Value} {context.Request.Method} " +
                $"\n Detalle: {ex.Message} "
            };
            await context.Response.WriteAsJsonAsync(respuesta);

        }
        finally
        {
            await logService.saveLog(log);
        }
    }
}
