using ELYA.Api.Middleware;

namespace ELYA.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseElyaPipeline(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();
        app.UseMiddleware<TenantMiddleware>();

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        return app;
    }
}
