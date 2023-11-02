using Microsoft.AspNetCore.Http;

namespace TestingHowToUseDJ.TimeServices;

public class TimeServiceMiddleware
{
    private readonly IEnumerable<ITimeService> _time;
    private readonly RequestDelegate _next;

    public TimeServiceMiddleware(IEnumerable<ITimeService> time, RequestDelegate next)
    {
        _time = time;
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var services = _time.ToList();

        await context.Response.WriteAsync("Start services..\n");

        foreach (var timeService in services)
        {
            await context.Response.WriteAsync($"Time - {timeService.GetType().Name} : {timeService.GetTime()} \n");
            
            await _next.Invoke(context);
        }
    }
}