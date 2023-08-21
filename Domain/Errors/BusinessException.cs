using System;

namespace Domain.Errors
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
