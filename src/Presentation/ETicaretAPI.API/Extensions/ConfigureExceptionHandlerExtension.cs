namespace ETicaretAPI.API.Extensions
{
    using Microsoft.AspNetCore.Diagnostics;
    using System.Net;
    using System.Net.Mime;
    using JsonSerializer = System.Text.Json.JsonSerializer;

    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json; //uygulamanin yolunu hatirlamayabiliriz. O yüzden MediaTypeNames kütüphanesinden yararlaniyoruz.

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError((contextFeature.Error.Message));

                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = "Hata alindi!"
                        }));
                    }
                });
            });
        }
    }
}
