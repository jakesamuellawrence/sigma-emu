namespace SigmaEmu.Shared;

public class Source
{
    private Source(SourceLine[] lines)
    {
        Lines = lines;
    }

    public SourceLine[] Lines { get; init; }
    public Sigma16Parser.ProgramContext Tree { get; set; }

    public void AddError(SourceError error)
    {
        if (error.LineNumber >= Lines.Length) return;
        Lines[error.LineNumber - 1].AddError(error);
    }

    public void AddErrors(IEnumerable<SourceError> errors)
    {
        foreach (var error in errors) AddError(error);
    }

    public bool HasErrors()
    {
        return Lines.Any(line => line.HasError());
    }

    public static async Task<Source> FromFileStreamAsync(Stream fileStream)
    {
        var lines = new List<SourceLine>();
        var fileReader = new StreamReader(fileStream);

        string? line;
        while ((line = await fileReader.ReadLineAsync()) != null)
            lines.Add(new SourceLine(line));

        return new Source(lines.ToArray());
    }

    public override string ToString()
    {
        var strings = Lines.Select(line => line.Text);
        return string.Join("\n", strings);
    }
}