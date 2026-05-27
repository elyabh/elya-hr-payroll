using ELYA.Shared.Constants;

namespace ELYA.Api.Tenancy;

public sealed class TenantResolver : ITenantResolver
{
    public bool TryResolve(HttpContext httpContext, out Guid tenantId)
    {
        tenantId = default;

        if (!httpContext.Request.Headers.TryGetValue(TenantHeaders.TenantId, out var headerValue))
        {
            return false;
        }

        var raw = headerValue.FirstOrDefault();
        return !string.IsNullOrWhiteSpace(raw) && Guid.TryParse(raw, out tenantId);
    }
}
