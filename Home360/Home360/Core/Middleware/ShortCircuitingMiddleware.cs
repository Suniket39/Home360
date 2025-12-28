namespace Home360.API.Core
{
    public class ShortCircuitingMiddleware
    {
        private readonly RequestDelegate _next;

        public ShortCircuitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("MyCustomeHeader"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Bad Request: Missing MyCustomeHeader");
                return; // Short Circuit the pipeline
            }

            // Call the next midlleware in pipeline
            await _next(context);
        }
    }
}
