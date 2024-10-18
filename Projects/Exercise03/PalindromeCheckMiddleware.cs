using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Exercise01
{
    public class PalindromeCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public PalindromeCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // بررسی اینکه آیا عدد در RouteValues موجود است
            if (context.Request.RouteValues.TryGetValue("number", out var numberValue) && int.TryParse(numberValue.ToString(), out int number))
            {
                // بررسی آیینه‌ای بودن عدد
                string result = IsPalindrome(number) ? "Palindrome" : "Not Palindrome";

                // ذخیره نتیجه در HttpContext.Items
                context.Items["PalindromeCheckResult"] = result;
            }
            else
            {
                // در صورت عدم وجود عدد یا غیر معتبر بودن، نتیجه خطا
                context.Items["PalindromeCheckResult"] = "Invalid or missing number.";
            }

            // ادامه پردازش درخواست
            await _next(context);
        }

        // تابع برای بررسی آیینه‌ای بودن عدد
        private bool IsPalindrome(int number)
        {
            var strNumber = number.ToString();
            var reversed = new string(strNumber.Reverse().ToArray());
            return strNumber == reversed;
        }
    }
}
