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
        var assembler = new AssemblerListener(stream);
        ParseTreeWalker.Default.Walk(assembler, parser.program());
        return (assembler.Listing, assembler.Errors);
    }
}