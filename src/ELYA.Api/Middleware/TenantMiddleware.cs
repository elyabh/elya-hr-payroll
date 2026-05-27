using ELYA.Api.Tenancy;

namespace ELYA.Api.Middleware;

public sealed class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(
        HttpContext context,
        ITenantResolver tenantResolver,
        TenantContext tenantContext)
    {
        if (tenantResolver.TryResolve(context, out var tenantId))
        {
            tenantContext.SetTenant(tenantId);
        }

        await _next(context);
    }
}
