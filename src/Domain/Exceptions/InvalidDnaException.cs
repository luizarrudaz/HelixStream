namespace Domain.Exceptions;

public class InvalidDnaException : Exception
{
    public InvalidDnaException(string message) : base(message) { }
}
