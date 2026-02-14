namespace Domain.Exceptions;

public class InvalidDnaOperationException : Exception
{
    public InvalidDnaOperationException(string message) : base(message) { }
}
