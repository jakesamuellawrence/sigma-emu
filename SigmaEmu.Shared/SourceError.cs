namespace SigmaEmu.Shared;

public struct SourceError
{
    public int StartLine { get; init; }
    public int EndLine { get; init; }
    public int StartColumn { get; init; }
    public int EndColumn { get; init; }
    public string Message { get; init; }
}