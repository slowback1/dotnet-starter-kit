using System;

namespace Common.Models;

public class UseCaseResult<T>
{
    private UseCaseResult()
    {
    }

    public T? Result { get; set; }
    public UseCaseStatus Status { get; set; }
    public string? ErrorMessage { get; set; }
    public Exception? Exception { get; set; }

    public static UseCaseResult<T> Success(T? result = default)
    {
        return new UseCaseResult<T>
        {
            Result = result,
            Status = UseCaseStatus.Success
        };
    }

    public static UseCaseResult<T> Failure(string? errorMessage = null, Exception? exception = null)
    {
        return new UseCaseResult<T>
        {
            Status = UseCaseStatus.Failure,
            ErrorMessage = errorMessage,
            Exception = exception
        };
    }
}

public enum UseCaseStatus
{
    Success,
    Failure
}