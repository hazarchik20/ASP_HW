using System.Text;

namespace _3_ASP_HW.Midleware
{
    public class SignatureMiddleware
    {
        private readonly RequestDelegate _next;

        public SignatureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

            responseBody += "\n\n P.S. Copyright by YourName";

            var modifiedBytes = Encoding.UTF8.GetBytes(responseBody);

            context.Response.ContentLength = modifiedBytes.Length;

            context.Response.Body = originalBodyStream;
            await context.Response.Body.WriteAsync(modifiedBytes, 0, modifiedBytes.Length);
        }
    }
}
