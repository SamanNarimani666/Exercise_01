using Exercise01;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

// اضافه کردن Middleware به Pipeline
app.UseMiddleware<PathCharacterMiddleware>();


app.UseEndpoints(endpoints =>
{
    // تعریف مسیر پارامتری با نام 'path'
    endpoints.MapGet("/checkpath/{*path}", async context =>
    {
        // دریافت اطلاعات ذخیره‌شده در HttpContext
        var characterCount = context.Items["CharacterCount"];
        var characterType = context.Items["CharacterType"];

        // نمایش اطلاعات مسیر به کاربر
        await context.Response.WriteAsync($"Path has {characterCount} characters and is of type {characterType}");
    });
});

app.Run();
