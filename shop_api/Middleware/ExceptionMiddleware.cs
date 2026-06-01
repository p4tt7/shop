public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "aplication.json";
            await context.Response.WriteAsJsonAsync(new
            {
                error = "An unexpected error occured",
                statusCode = 500
            });
            
        }

        
    }
    
}