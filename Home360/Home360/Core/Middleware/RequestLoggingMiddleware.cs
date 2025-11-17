namespace Home360.API.Core
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request information
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            // Call the next midlleware in pipeline
            await _next(context);

            //Log response information
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}