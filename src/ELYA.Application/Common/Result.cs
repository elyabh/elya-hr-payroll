namespace ELYA.Application.Common;

public class Result
{
    public bool IsSuccess { get; init; }

    public string? Message { get; init; }

    public IReadOnlyList<string> Errors { get; init; } = [];

    public static Result Success(string? message = null) =>
        new() { IsSuccess = true, Message = message };

    public static Result Failure(IEnumerable<string> errors, string? message = null) =>
        new() { IsSuccess = false, Message = message, Errors = errors.ToList().AsReadOnly() };

    public static Result Failure(string error, string? message = null) =>
        Failure([error], message);
}

public class Result<T> : Result
{
    public T? Value { get; init; }

    public static Result<T> Success(T value, string? message = null) =>
        new() { IsSuccess = true, Value = value, Message = message };

    public new static Result<T> Failure(IEnumerable<string> errors, string? message = null) =>
        new() { IsSuccess = false, Message = message, Errors = errors.ToList().AsReadOnly() };

    public new static Result<T> Failure(string error, string? message = null) =>
        Failure([error], message);
}
