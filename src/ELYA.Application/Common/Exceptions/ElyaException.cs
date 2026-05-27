namespace ELYA.Application.Common.Exceptions;

public abstract class ElyaException : Exception
{
    protected ElyaException(string message) : base(message)
    {
    }

    protected ElyaException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

public sealed class ValidationException : ElyaException
{
    public IReadOnlyList<string> Errors { get; }

    public ValidationException(string message, IEnumerable<string>? errors = null)
        : base(message)
    {
        var errorList = errors?.ToList() ?? [message];
        Errors = errorList.AsReadOnly();
    }
}

public sealed class UnauthorizedException : ElyaException
{
    public UnauthorizedException(string message = "Unauthorized.")
        : base(message)
    {
    }
}

public sealed class ForbiddenException : ElyaException
{
    public ForbiddenException(string message = "Forbidden.")
        : base(message)
    {
    }
}

public sealed class NotFoundException : ElyaException
{
    public NotFoundException(string message = "Resource not found.")
        : base(message)
    {
    }
}

public sealed class ConflictException : ElyaException
{
    public ConflictException(string message = "Conflict.")
        : base(message)
    {
    }
}

public sealed class SystemErrorException : ElyaException
{
    public SystemErrorException(string message = "An unexpected error occurred.")
        : base(message)
    {
    }

    public SystemErrorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
