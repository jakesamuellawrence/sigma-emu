using System.Text;
using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public class Source
{
    private string _content;
    private List<SourceError> _errors;

    public Source(string fileName, string content)
    {
        _content = content;
        FileName = fileName;

        (Tree, _errors) = Assembler.Parse(_content);
    }

    public string FileName { get; }

    public Sigma16Parser.ProgramContext? Tree { get; private set; }

    public int NumLines => _content.Split("\n").Length;

    public string GetLine(int lineNumber)
    {
        return _content.Split("\n")[lineNumber - 1];
    }

    public void SetContent(string content)
    {
        _content = content;
        (Tree, _errors) = Assembler.Parse(_content);
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

    public override string ToString()
    {
        return _content;
    }

    public Stream AsStream()
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(_content));
    }
}