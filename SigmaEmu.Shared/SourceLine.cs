namespace SigmaEmu.Shared;

public class SourceLine
{
    public SourceLine(string text)
    {
        Text = text;
    }

    public string Text { get; init; }
    public List<Error> Errors { get; } = new();

    public void AddError(Error error)
    {
        Errors.Add(error);
    }

    public bool HasError()
    {
        return Errors.Count != 0;
    }

    public override string ToString()
    {
        return Text;
    }
}