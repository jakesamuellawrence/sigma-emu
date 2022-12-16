using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public class AssemblerListener : Sigma16BaseListener
{
    private const int RxExpansionOp = 15;
    private const int XExpansionOp = 14;

    private readonly Listing _listing;

    public AssemblerListener(Listing listing)
    {
        _listing = listing;
    }

    public override void EnterLabel_def(Sigma16Parser.Label_defContext context)
    {
        var labelName = context.label().GetText();

        if (_listing.HasLabelBeenDefined(labelName))
        {
            _listing.AddError($"duplicate definition of label '{labelName}'", context.Start.Line);
            return;
        }

        _listing.DefineLabel(labelName, context.Start.Line);
    }

    public override void ExitData_instruction(Sigma16Parser.Data_instructionContext context)
    {
        var value = int.Parse(context.NUM().GetText());
        var code1 = Word.FromInt(value);
        _listing.AddInstruction(context.Start.Line, code1);
    }

    public override void ExitRrr_instruction(Sigma16Parser.Rrr_instructionContext context)
    {
        var op = TryParseEnum<RrrInstruction>(context.mnemonic.GetText());
        var destReg = TryParseEnum<Register>(context.destinationReg.Text);
        var firstOpReg = TryParseEnum<Register>(context.firstOperand.Text);
        var secondOpReg = TryParseEnum<Register>(context.secondOperand.Text);

        if (op == null || destReg == null || firstOpReg == null || secondOpReg == null)
            throw new GrammarMismatchException();

        var code = Word.FromInstruction((int)op, (int)destReg, (int)firstOpReg, (int)secondOpReg);
        _listing.AddInstruction(context.Start.Line, code);
    }

    public override void ExitRx_instruction(Sigma16Parser.Rx_instructionContext context)
    {
        var op = TryParseEnum<RxInstruction>(context.mnemonic.GetText());
        var destReg = TryParseEnum<Register>(context.destinationReg.Text);
        var offsetReg = TryParseEnum<Register>(context.offsetReg.Text);

        if (op == null || destReg == null || offsetReg == null) throw new GrammarMismatchException();

        var displacementWord = GetWordFromDisplacement(context.displacement());

        var code1 = Word.FromInstruction(RxExpansionOp, (int)destReg, (int)offsetReg, (int)op);
        _listing.AddInstruction(context.Start.Line, code1, displacementWord);
    }


    public override void ExitX_instruction(Sigma16Parser.X_instructionContext context)
    {
        var op = TryParseEnum<XInstruction>(context.mnemonic.GetText());
        var offsetReg = TryParseEnum<Register>(context.offsetReg.Text);

        if (op == null || offsetReg == null) return;

        var displacementWord = GetWordFromDisplacement(context.displacement());

        var code1 = Word.FromInstruction(XExpansionOp, 0, (int)offsetReg, (int)op);
        _listing.AddInstruction(context.Start.Line, code1, displacementWord);
    }

    private Word GetWordFromDisplacement(Sigma16Parser.DisplacementContext displacement)
    {
        if (displacement.num != null) return Word.FromInt(int.Parse(displacement.num.Text));

        var label = displacement.label().GetText();
        _listing.UseLabel(label, displacement.Start.Line);
        return _listing.LookupLabel(label);
    }

    public override void ExitProgram(Sigma16Parser.ProgramContext context)
    {
        foreach (var label in _listing.LabelMap.Values.Where(label => label.Address is null))
            _listing.AddError($"label '{label.Name}' was never defined");
    }

    private static T? TryParseEnum<T>(string text) where T : struct, Enum
    {
        var success = Enum.TryParse(text, true, out T parsed);

        return success ? parsed : null;
    }

    private static string FindOriginalText(ParserRuleContext context)
    {
        var interval = new Interval(context.Start.StartIndex, context.Stop.StopIndex);
        return context.Start.InputStream.GetText(interval);
    }
}