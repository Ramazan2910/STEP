namespace NET_Exceptions;

public class InvalidNumberException  : Exception
{
    public InvalidNumberException (string message) : base(message) { }
}