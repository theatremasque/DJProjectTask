using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TestingHowToUseDJ.TimeServices;

namespace TestingHowToUseDJ;

internal class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();

        
        // Adding services to the collection`s services application
        builder.Services.AddTransient<ITimeService, ShortTimeService>(); // system pass the object of the class 
        builder.Services.AddTransient<ITimeService, LongTimeService>();

        var app = builder.Build();
        
        app.UseMiddleware<TimeServiceMiddleware>();
        
        app.Run(async (context) =>
        {
        });

        app.Run();
    }
}