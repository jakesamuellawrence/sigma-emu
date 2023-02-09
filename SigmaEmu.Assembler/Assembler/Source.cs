using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public class Source
{
    private readonly List<SourceError> _errors;
    private readonly string _text;

    private Source(string text)
    {
        _text = text;

        (Tree, _errors) = Assembler.Parse(_text);
    }

    public Sigma16Parser.ProgramContext? Tree { get; }

    public int NumLines => _text.Split("\n").Length;

    public string GetLine(int lineNumber)
    {
        return _text.Split("\n")[lineNumber - 1];
    }

    public void AddError(SourceError error)
    {
        _errors.Add(error);
    }

    public void AddErrors(IEnumerable<SourceError> errors)
    {
        foreach (var error in errors) AddError(error);
    }

    public bool HasErrors()
    {
        return _errors.Count != 0;
    }

    public static async Task<Source> FromFileStreamAsync(Stream fileStream)
    {
        var fileReader = new StreamReader(fileStream);

        return new Source(await fileReader.ReadToEndAsync());
    }

    public static Source FromString(string text)
    {
        return new Source(text);
    }

    public override string ToString()
    {
        return _text;
    }
}