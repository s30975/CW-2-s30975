namespace ConsoleApp2_s30975;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}