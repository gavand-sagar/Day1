
internal class SecondMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Headers.ContainsKey("username")
            && context.Request.Headers["username"] == "admin"
            )
            return next(context);

        return Task.CompletedTask;
    }
}