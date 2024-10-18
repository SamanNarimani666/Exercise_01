using Exercise04;
var builder = WebApplication.CreateBuilder(args);

// اضافه کردن سرویس‌های Swagger به Container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// تنظیم routing
app.UseRouting();

// اندپوینت برای ذخیره عدد
app.MapPost("/storeprime", async (NumberInputModel input) =>
{
    if (input == null)
        return Results.BadRequest();

    // بررسی اینکه آیا عدد وارد شده اول است یا نه
    if (IsPrime(input.Number))
    {
        // ذخیره عدد در لیست
        PrimeNumberStorage.AddPrimeNumber(input.Number);
        return Results.Ok($"Number {input.Number} is prime and has been stored.");
    }
    else
    {
        return Results.BadRequest($"Number {input?.Number} is not prime.");
    }
});
    
// اندپوینت برای نمایش لیست اعداد اول
app.MapGet("/getprimes", () =>
{
    return Results.Json(PrimeNumberStorage.GetPrimeNumbers());
});

// تابع بررسی اول بودن عدد
static bool IsPrime(int number)
{
    if (number <= 1) return false;
    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0) return false;
    }
    return true;
}



app.Run();


record NumberInputModel(int Number);
