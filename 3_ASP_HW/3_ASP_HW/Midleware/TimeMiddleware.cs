using System.Diagnostics;

namespace _3_ASP_HW.Midleware
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimeMiddleware> _logger;

        public TimeMiddleware(RequestDelegate next, ILogger<TimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                await _next(context);
            }
            finally
            {
                stopwatch.Stop();

                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                var method = context.Request.Method;
                var path = context.Request.Path;

                _logger.LogInformation(
                    "HTTP {Method} {Path} executed in {ElapsedMilliseconds} ms",
                    method,
                    path,
                    elapsedMilliseconds);
            }
        }
    }
}
