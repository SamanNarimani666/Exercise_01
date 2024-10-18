using Exercise05;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapPost("/storepalindromeand", async (NumberInputModel input) =>
{
    if (input == null)
        return Results.BadRequest();

    // بررسی اینکه آیا عدد وارد شده اول است یا نه
    if (IsPalindrome(input.Number))
    {
        // ذخیره عدد در لیست
        PalindromeStorage.AddPalindromeNumber(input.Number);
        return Results.Ok($"Number {input.Number} is palindromeand has been stored.");
    }
    else
    {
        return Results.BadRequest($"Number {input?.Number} is not palindromeand.");
    }
});

// اندپوینت برای نمایش لیست اعداد اول
app.MapGet("/getpalindromeand", () =>
{
    return Results.Json(PalindromeStorage.GetPalindromeNumbers());
});

bool IsPalindrome(int number)
{
    var strNumber = number.ToString();
    var reversed = new string(strNumber.Reverse().ToArray());
    return strNumber == reversed;
}

app.Run();

record NumberInputModel(int Number);

