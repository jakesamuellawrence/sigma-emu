using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using SigmaEmu.Models;

namespace SigmaEmu.Assembler.Assembler;

public class ErrorListener : BaseErrorListener
{
    public List<AssemblerError> Errors { get; } = new();

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        var expectedTokens = GetTokenNames(e.GetExpectedTokens(), recognizer.Vocabulary);
        var actualToken = GetTokenName(offendingSymbol, recognizer.Vocabulary);
        Errors.Add(new AssemblerError()
        {
            Message = $"Encountered {actualToken}, expecting one of [{string.Join(", ", expectedTokens)}]",
            LineNumber = line
        });
    }

    private IEnumerable<string> GetTokenNames(IIntSet set, IVocabulary vocabulary)
    {
        return (from tokenType in set.ToList() select GetTokenName(tokenType, vocabulary)).ToList();
    }

    private string GetTokenName(int tokenType, IVocabulary vocabulary)
    {
        return vocabulary.GetSymbolicName(tokenType);
    }

    private string GetTokenName(IToken token, IVocabulary vocabulary)
    {
        return GetTokenName(token.Type, vocabulary);
    }
}