namespace SigmaEmu.Shared;

public class SourceError : Error
{
    public new int LineNumber { get; set; }
}