﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using SigmaEmu.Models;
using SigmaEmu.Shared;

namespace SigmaEmu.Assembler.Assembler;

public class AssemblerListener : Sigma16BaseListener
{
    private const int RxExpansionOp = 15;
    private const int XExpansionOp = 14;

    private readonly LabelMap _labelMap = new();

    private readonly ICharStream _sourceStream;

    public AssemblerListener(ICharStream sourceStream)
    {
        _sourceStream = sourceStream;
    }

    public Listing Listing { get; } = new();

    public override void EnterLabel_def(Sigma16Parser.Label_defContext context)
    {
        var labelName = context.GetText();

        if (_labelMap.HasLabel(labelName))
        {
            Listing.Errors.Add(new AssemblerError
            {
                Message = $"Duplicate label '{labelName}'",
                LineNumber = context.Start.Line
            });
            return;
        }

        _labelMap.DefineLabel(labelName, Word.FromInt(Listing.CurrentAddress));
    }

    public override void ExitData_instruction(Sigma16Parser.Data_instructionContext context)
    {
        var value = int.Parse(context.NUM().GetText());
        var code1 = Word.FromInt(value);
        Listing.AddInstruction(code1, FindOriginalText(context));
    }

    public override void ExitRrr_instruction(Sigma16Parser.Rrr_instructionContext context)
    {
        var op = TryParseEnum<RrrInstruction>(context.RRR_COMMAND().GetText());
        var destReg = TryParseEnum<Register>(context.destinationReg.Text);
        var firstOpReg = TryParseEnum<Register>(context.firstOperand.Text);
        var secondOpReg = TryParseEnum<Register>(context.secondOperand.Text);

        if (op == null || destReg == null || firstOpReg == null || secondOpReg == null)
            throw new GrammarMismatchException();

        var code = Word.FromInstruction((int)op, (int)destReg, (int)firstOpReg, (int)secondOpReg);
        Listing.AddInstruction(code, FindOriginalText(context));
    }

    public override void ExitRx_instruction(Sigma16Parser.Rx_instructionContext context)
    {
        var op = TryParseEnum<RxInstruction>(context.RX_COMMAND().GetText());
        var destReg = TryParseEnum<Register>(context.destinationReg.Text);
        var offsetReg = TryParseEnum<Register>(context.offsetReg.Text);

        if (op == null || destReg == null || offsetReg == null) throw new GrammarMismatchException();

        var displacementWord = GetWordFromDisplacement(context.displacement());

        var code1 = Word.FromInstruction(RxExpansionOp, (int)destReg, (int)offsetReg, (int)op);
        var line = Listing.AddInstruction(code1, FindOriginalText(context), displacementWord);

        if (displacementWord.AsInt() == -1) _labelMap.RememberLineToPatch(context.displacement().GetText(), line);
    }

    private Word GetWordFromDisplacement(Sigma16Parser.DisplacementContext displacement)
    {
        if (displacement.num != null) return Word.FromInt(int.Parse(displacement.num.Text));
        return _labelMap.GetAddress(displacement.label.Text);
    }

    public override void ExitX_instruction(Sigma16Parser.X_instructionContext context)
    {
        var op = TryParseEnum<XInstruction>(context.X_COMMAND().GetText());
        var offsetReg = TryParseEnum<Register>(context.offsetReg.Text);

        if (op == null || offsetReg == null) throw new GrammarMismatchException();

        var displacementWord = GetWordFromDisplacement(context.displacement());

        var code1 = Word.FromInstruction(XExpansionOp, 0, (int)offsetReg, (int)op);
        var line = Listing.AddInstruction(code1, FindOriginalText(context), displacementWord);

        if (displacementWord.AsInt() == -1) _labelMap.RememberLineToPatch(context.displacement().GetText(), line);
    }

    public override void ExitProgram(Sigma16Parser.ProgramContext context)
    {
        if (_labelMap.HasLinesToPatch())
            Listing.Errors.Add(new AssemblerError
            {
                Message = $"Labels [{string.Join(", ", _labelMap.GetUndefinedLabels())}] were never defined"
            });
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