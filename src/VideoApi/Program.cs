using Microsoft.OpenApi.Models;
using VideoApi.Services;

namespace VideoApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });
        
        builder.Services.AddTransient<VideoInfoService>();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        var app = builder.Build();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseExceptionHandler("/error"); 
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}