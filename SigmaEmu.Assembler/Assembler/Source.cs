using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public class Source
{
    private readonly SourceLine[] _lines;

    private Source(SourceLine[] lines)
    {
        _lines = lines;
    }

    public Sigma16Parser.ProgramContext? Tree { get; set; }

    public int NumLines => _lines.Length;

    public SourceLine GetLine(int lineNumber)
    {
        return _lines[lineNumber - 1];
    }

    public void AddError(SourceError error)
    {
        if (error.LineNumber > NumLines) return;
        GetLine(error.LineNumber).AddError(error);
    }

    public void AddErrors(IEnumerable<SourceError> errors)
    {
        foreach (var error in errors) AddError(error);
    }

    public bool HasErrors()
    {
        return _lines.Any(line => line.HasError());
    }

    public static async Task<Source> FromFileStreamAsync(Stream fileStream)
    {
        var lines = new List<SourceLine>();
        var fileReader = new StreamReader(fileStream);

        string? line;
        while ((line = await fileReader.ReadLineAsync()) != null) lines.Add(new SourceLine(line));

        return new Source(lines.ToArray());
    }

    public override string ToString()
    {
        var strings = _lines.Select(line => line.Text);
        return string.Join("\n", strings);
    }
}