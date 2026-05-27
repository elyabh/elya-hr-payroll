namespace ELYA.Api.Tenancy;

public interface ITenantResolver
{
    bool TryResolve(HttpContext httpContext, out Guid tenantId);
}
