using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise01
{
    public class PathCharacterMiddleware
    {
        private readonly RequestDelegate _next;

        public PathCharacterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // دریافت مقدار path از RouteValues
            var path = (string)context.Request.RouteValues["path"];  // فقط پارامتر مسیر، مثلا abc123

            if (!string.IsNullOrEmpty(path))
            {
                var characterCount = path.Length;            // محاسبه تعداد کاراکترها
                var characterType = GetCharacterType(path);  // محاسبه نوع کاراکترها (حروف، اعداد، یا مخلوط)

                // ذخیره اطلاعات در HttpContext.Items
                context.Items["CharacterCount"] = characterCount;
                context.Items["CharacterType"] = characterType;
            }

            // ادامه پردازش درخواست
            await _next(context);
        }

        private string GetCharacterType(string path)
        {
            if (path.All(char.IsLetter))
            {
                return "Alphabet";  // اگر تمام کاراکترها حرف باشند
            }
            else if (path.All(char.IsDigit))
            {
                return "Numeric";   // اگر تمام کاراکترها عدد باشند
            }
            else
            {
                return "Mixed";     // در غیر اینصورت، مخلوط از حروف و اعداد
            }
        }
    }
}
