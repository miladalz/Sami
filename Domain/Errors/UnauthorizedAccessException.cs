using System;
namespace Domain.Errors
{
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) : base(message) { }
    }
}
