using Antlr4.Runtime;

namespace SigmaEmu.Assembler.Assembler;

public static class Assembler
{
    public static void Parse(string input)
    {
        var stream = CharStreams.fromString(input);
        var lexer = new Sigma16Lexer(stream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new Sigma16Parser(tokens)
        {
            BuildParseTree = true
        };
        Console.WriteLine(parser.program());
    }
}