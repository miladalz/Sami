using System;

namespace Domain.Errors
{
    public class BusinessException : Exception
    {
        public string ErrorDescription { get; set; } = null!;
        public int StatusCode { get; set; }

        public BusinessException(string errorDescription, int statusCode)
        {
            ErrorDescription = errorDescription;
            StatusCode = statusCode;
        }
    }
}
