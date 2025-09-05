
internal class FirstMiddleware : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Inside first Middleware");
        return next(context);
    }
}