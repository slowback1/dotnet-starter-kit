using System;

namespace Logic.User;

public class TokenInvalidException : Exception
{
    public TokenInvalidException(string? message = null, Exception? inner = null) : base(message, inner)
    {
    }
}

public class TokenExpiredException : Exception
{
    public TokenExpiredException(string? message = null, Exception? inner = null) : base(message, inner)
    {
    }
}