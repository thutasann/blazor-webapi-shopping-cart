using System.Diagnostics;

namespace Cart.Api.Middlewares
{
    public class ResponseTimeMiddleware(RequestDelegate next, ILogger<ResponseTimeMiddleware> logger)
    {
        private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));
        private readonly ILogger<ResponseTimeMiddleware> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var requestUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}";

            await _next(context);

            stopwatch.Stop();
            var responseTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"--> (Middleware) {requestUrl} took  {responseTime} ms");
        }
    }
}