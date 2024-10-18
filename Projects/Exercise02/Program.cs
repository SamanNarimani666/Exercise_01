using Exercise01; // فضای نام Middleware
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();


// اضافه کردن Middleware به Pipeline
app.UseMiddleware<PrimeCheckMiddleware>();


app.UseEndpoints(endpoints =>
{
    // تعریف مسیر پارامتری که یک عدد را از URL دریافت می‌کند
    endpoints.MapGet("/checkprime/{number:int}", async context =>
    {
        // دریافت نتیجه از HttpContext
        var result = context.Items["PrimeCheckResult"];

        // نمایش نتیجه به کاربر
        await context.Response.WriteAsync($"Result: {result}");
    });
});

app.Run();
