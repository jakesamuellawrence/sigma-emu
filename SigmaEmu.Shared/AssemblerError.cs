namespace SigmaEmu.Models;

public class AssemblerError
{
    public string? Message { get; init; }
    public int? LineNumber { get; init; }

    public string Format()
    {
        if (Message == null) return "Blank Error";
        return LineNumber != null ? $"line {LineNumber}: {Message} " : Message;
    }
}