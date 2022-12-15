using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public static class Assembler
{
    public static async Task<Source> ParseAsync(Stream fileStream)
    {
        var source = await Source.FromFileStreamAsync(fileStream);

        var stream = CharStreams.fromString(source.ToString());
        var lexer = new Sigma16Lexer(stream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new Sigma16Parser(tokens)
        {
            BuildParseTree = true
        };

        var errorListener = new ErrorListener();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(errorListener);

        var tree = parser.program();

        var syntaxErrors = errorListener.Errors;
        source.AddErrors(syntaxErrors);
        source.Tree = tree;

        return source;
    }

    public static Listing Assemble(Sigma16Parser.ProgramContext tree)
    {
        var assembler = new AssemblerListener();
        ParseTreeWalker.Default.Walk(assembler, tree);
        return assembler.Listing;
    }
}