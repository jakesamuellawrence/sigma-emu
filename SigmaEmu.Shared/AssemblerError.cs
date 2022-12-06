namespace SigmaEmu.Models;

public class AssemblerError
{
    public string? Message { get; init; }
    public int? LineNumber { get; init; }

    public override string ToString()
    {
        if (Message == null) return "Blank Error";
        return LineNumber != null ? $"{Message} on line {LineNumber}" : Message;
    }
}