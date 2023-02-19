using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public class ErrorListener : BaseErrorListener
{
    public List<SourceError> Errors { get; } = new();

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line,
        int charPositionInLine,
        string msg, RecognitionException e)
    {
        Errors.Add(new SourceError
        {
            Message = msg,
            StartLine = offendingSymbol.Line,
            EndLine = offendingSymbol.Line,
            StartColumn = charPositionInLine + 1,
            EndColumn = charPositionInLine + offendingSymbol.Text.Length + 1
        });
    }

    private IEnumerable<string> GetTokenNames(IIntSet set, IVocabulary vocabulary)
    {
        return (from tokenType in set.ToList() select GetTokenName(tokenType, vocabulary)).ToList();
    }

    private string GetTokenName(int tokenType, IVocabulary vocabulary)
    {
        return vocabulary.GetDisplayName(tokenType);
    }

    private string GetTokenName(IToken token, IVocabulary vocabulary)
    {
        return GetTokenName(token.Type, vocabulary);
    }
}