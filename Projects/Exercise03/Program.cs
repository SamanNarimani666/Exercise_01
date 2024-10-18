using Exercise01; // ���? ��� Middleware
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ����� routing �� ���?� �?���?�
app.UseRouting();

// ����� ���� Middleware �� Pipeline ��� �� UseRouting
app.UseMiddleware<PalindromeCheckMiddleware>();

app.UseEndpoints(endpoints =>
{
    // ���?� ��?� �������? �� ?� ��� �� �� URL ��?��� �?����
    endpoints.MapGet("/checkpalindrome/{number:int}", async context =>
    {
        // ��?��� ��?�� �� HttpContext
        var result = context.Items["PalindromeCheckResult"];

        // ���?� ��?�� �� �����
        await context.Response.WriteAsync($"Result: {result}");
    });
});

app.Run();
