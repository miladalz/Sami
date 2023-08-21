using System;
namespace Domain.Errors
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message) : base(message) { }
    }
}
