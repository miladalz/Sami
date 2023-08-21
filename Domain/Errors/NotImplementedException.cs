using System;
namespace Domain.Errors
{
    public class NotImplementedException : Exception
    {
        public NotImplementedException(string message) : base(message) { }
    }
}
