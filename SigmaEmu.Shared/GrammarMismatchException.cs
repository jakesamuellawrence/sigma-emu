namespace SigmaEmu.Models;

public class GrammarMismatchException : Exception
{
    public GrammarMismatchException() : base("Grammar definition does not match Assembler's enums")
    { }
}