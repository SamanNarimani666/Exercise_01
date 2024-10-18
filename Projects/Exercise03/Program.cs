using Exercise01; // ›÷«? ‰«„ Middleware
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// «» œ« routing —«  ‰Ÿ?„ „?ùò‰?„
app.UseRouting();

// «÷«›Â ò—œ‰ Middleware »Â Pipeline »⁄œ «“ UseRouting
app.UseMiddleware<PalindromeCheckMiddleware>();

app.UseEndpoints(endpoints =>
{
    //  ⁄—?› „”?— Å«—«„ —? òÂ ?ò ⁄œœ —« «“ URL œ—?«›  „?ùò‰œ
    endpoints.MapGet("/checkpalindrome/{number:int}", async context =>
    {
        // œ—?«›  ‰ ?ÃÂ «“ HttpContext
        var result = context.Items["PalindromeCheckResult"];

        // ‰„«?‘ ‰ ?ÃÂ »Â ò«—»—
        await context.Response.WriteAsync($"Result: {result}");
    });
});

app.Run();
