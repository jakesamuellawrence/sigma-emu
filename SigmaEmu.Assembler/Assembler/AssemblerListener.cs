using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using SigmaEmu.Models;

namespace SigmaEmu.Assembler.Assembler;

public class AssemblerListener : Sigma16BaseListener
{
    private readonly ICharStream _sourceStream;

    public Listing Listing { get; } = new Listing();

    private int _addressCounter = 0;

    private void addRrrInstruction(Word code1, string source)
    {
        var addressWord = Word.FromInt(_addressCounter);
        _addressCounter += 1;
        Listing.Lines.Add(new ListingLine(addressWord, code1, source));
    }

    public AssemblerListener(ICharStream sourceStream)
    {
        _sourceStream = sourceStream;
    }

    public override void EnterInstruction(Sigma16Parser.InstructionContext context)
    {
        Console.WriteLine("entering instruction");
    }

    public override void EnterRrr_instruction(Sigma16Parser.Rrr_instructionContext context)
    {
        var op = TryParseEnum<RrrInstruction>(context.RRR_COMMAND().GetText());
        var destReg = TryParseEnum<Register>(context.destinationReg.Text);
        var firstOpReg = TryParseEnum<Register>(context.firstOperand.Text);
        var secondOpReg = TryParseEnum<Register>(context.secondOperand.Text);

        if (op == null || destReg == null || firstOpReg == null || secondOpReg == null) throw new Exception();
        
        var code = Word.FromInstruction((int)op, (int)destReg, (int)firstOpReg, (int)secondOpReg);
        addRrrInstruction(code, FindOriginalText(context));
    }

    public override void EnterRx_instruction(Sigma16Parser.Rx_instructionContext context)
    {
        Console.WriteLine(context.GetText());
    }

    private static T? TryParseEnum<T>(string name) where T : struct, Enum
    {
        var success = Enum.TryParse(name, true, out T parsed);
        return success ? parsed : null;
    }

    private string FindOriginalText(ParserRuleContext context)
    {
        var interval = new Interval(context.Start.StartIndex, context.Stop.StopIndex);
        return _sourceStream.GetText(interval);
    }
}