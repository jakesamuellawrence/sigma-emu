using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using SigmaEmu.Models;

namespace SigmaEmu.Assembler.Assembler;

public static class Assembler
{
    public static (Listing, List<AssemblerError>) Assemble(string input)
    {
        var stream = CharStreams.fromString(input);
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
        if (syntaxErrors.Count() != 0) return (new Listing(), syntaxErrors);

        var assembler = new AssemblerListener(stream);
        ParseTreeWalker.Default.Walk(assembler, tree);
        return (assembler.Listing, syntaxErrors.Concat(assembler.Errors).ToList());
    }
}