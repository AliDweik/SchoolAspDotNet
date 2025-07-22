namespace School.MiddleWares
{
    public class RequestHeaderCheck
    {
        public RequestDelegate _next;
        public RequestHeaderCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            if (context.Request.Headers.TryGetValue("hhh", out var value))
            {
                if (value == "sss")
                {
                    await _next(context);
                }
            }
        }
    }

    public static class Extensions
    {
        public static IApplicationBuilder AppHeaderTest(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestHeaderCheck>();
        }
    }
}
