using ImageApi.Services.Constants;

namespace ImageApi.Services;

public class ImageDelayMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConstants constants;

    public ImageDelayMiddleware(RequestDelegate next, IConstants constants)
    {
        _next = next;
        this.constants = constants;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/images")) 
        {
            await Task.Delay(constants.IntervalTime); 
        }

        await _next(context);
    }
}

