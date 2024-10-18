using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Exercise01
{
    public class PrimeCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public PrimeCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // بررسی اینکه آیا عدد در RouteValues موجود است
            if (context.Request.RouteValues.TryGetValue("number", out var numberValue) && int.TryParse(numberValue.ToString(), out int number))
            {
                // بررسی اول یا مرکب بودن عدد
                string result = IsPrime(number) ? "Prime" : "Composite";

                // ذخیره نتیجه در HttpContext.Items
                context.Items["PrimeCheckResult"] = result;
            }
            else
            {
                // در صورت عدم وجود عدد یا غیر معتبر بودن، نتیجه خطا
                context.Items["PrimeCheckResult"] = "Invalid or missing number.";
            }

            // ادامه پردازش درخواست
            await _next(context);
        }

        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
