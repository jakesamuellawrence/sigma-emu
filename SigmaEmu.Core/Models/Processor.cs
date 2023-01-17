using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class Processor
{
    public const int MaxRegisters = 16;

    private const int RemainderRegister = 15;

    private readonly Dictionary<RrrInstruction, Action<Register, Register, Register>> _rrrMap;
    private readonly Dictionary<RxInstruction, Action<Register, Register>> _rxMap;
    private readonly Dictionary<XInstruction, Action<Register>> _xMap;

    public Processor()
    {
        for (var i = 0; i < MaxRegisters; i++) RegisterFile[i] = new Register();

        _rrrMap = new Dictionary<RrrInstruction, Action<Register, Register, Register>>
        {
            { RrrInstruction.Add, (d, a, b) => d.Value = a.Value + b.Value },
            { RrrInstruction.Sub, (d, a, b) => d.Value = a.Value - b.Value },
            { RrrInstruction.Mul, (d, a, b) => d.Value = a.Value * b.Value },
            {
                RrrInstruction.Div,
                (d, a, b) =>
                {
                    if (b.Value == Word.FromInt(0))
                    {
                        Halt();
                        return;
                    }

                    d.Value = a.Value / b.Value;
                    RegisterFile[RemainderRegister].Value = a.Value % b.Value;
                }
            },
            { RrrInstruction.CmpLt, (d, a, b) => d.Value = Word.FromBool(a.Value < b.Value) },
            { RrrInstruction.CmpEq, (d, a, b) => d.Value = Word.FromBool(a.Value == b.Value) },
            { RrrInstruction.CmpGt, (d, a, b) => d.Value = Word.FromBool(a.Value > b.Value) },
            { RrrInstruction.Inv, (d, a, b) => d.Value = !a.Value },
            { RrrInstruction.And, (d, a, b) => d.Value = a.Value & b.Value },
            { RrrInstruction.Or, (d, a, b) => d.Value = a.Value | b.Value },
            { RrrInstruction.Xor, (d, a, b) => d.Value = (a.Value | b.Value) & (!a.Value | !b.Value) },
            { RrrInstruction.ShiftL, (d, a, b) => d.Value = a.Value << b.Value },
            { RrrInstruction.ShiftR, (d, a, b) => d.Value = a.Value >> b.Value },
            { RrrInstruction.Trap, (d, a, b) => Halt() }
        };

        _rxMap = new Dictionary<RxInstruction, Action<Register, Register>>
        {
            { RxInstruction.Lea, (d, a) => d.Value = AddressRegister.Value + a.Value },
            {
                RxInstruction.Load, (d, a) =>
                {
                    DataRegister.Value = Memory[AddressRegister.Value + a.Value].Value;
                    d.Value = DataRegister.Value;
                }
            },
            {
                RxInstruction.Store, (d, a) =>
                {
                    DataRegister.Value = d.Value;
                    Memory[AddressRegister.Value + a.Value].Value = DataRegister.Value;
                }
            },
            {
                RxInstruction.Jumpf, (d, a) =>
                {
                    if (!d.Value.AsBool()) ProgramCounter.Value = AddressRegister.Value + a.Value;
                }
            },
            {
                RxInstruction.Jumpt, (d, a) =>
                {
                    if (d.Value.AsBool()) ProgramCounter.Value = AddressRegister.Value + a.Value;
                }
            },
            {
                RxInstruction.Jal, (d, a) =>
                {
                    d.Value = ProgramCounter.Value;
                    ProgramCounter.Value = AddressRegister.Value + a.Value;
                }
            }
        };

        _xMap = new Dictionary<XInstruction, Action<Register>>
        {
            { XInstruction.Jump, offset => ProgramCounter.Value = AddressRegister.Value + offset.Value }
        };
    }

    public ProcessorRunningState ProcessorState { get; private set; } = ProcessorRunningState.Stopped;

    public Register ProgramCounter { get; } = new();
    public Register InstructionRegister { get; } = new();
    public Register AddressRegister { get; } = new();
    public Register DataRegister { get; } = new();

    public Register[] RegisterFile { get; } = new Register[MaxRegisters];

    public Memory Memory { get; } = new();

    public void Reset()
    {
        var zero = Word.FromInt(0);
        ProgramCounter.Value = zero;
        InstructionRegister.Value = zero;
        AddressRegister.Value = zero;
        DataRegister.Value = zero;
        foreach (var register in RegisterFile) register.Value = zero;

        Memory.Reset();

        ProcessorState = ProcessorRunningState.Stopped;
    }

    public void LoadListing(Listing listing)
    {
        Memory.LoadListing(listing);
    }

    public void Ready()
    {
        ProcessorState = ProcessorRunningState.Paused;
    }

    public void Halt()
    {
        ProcessorState = ProcessorRunningState.Stopped;
    }

    private void ResetReadWrite()
    {
        ProgramCounter.ResetReadWrite();
        InstructionRegister.ResetReadWrite();
        AddressRegister.ResetReadWrite();
        DataRegister.ResetReadWrite();

        foreach (var register in RegisterFile) register.ResetReadWrite();

        Memory.ResetReadWrite();
    }

    public void Step()
    {
        if (ProcessorState == ProcessorRunningState.Stopped) return;

        ResetReadWrite();

        // Clear Address and data
        AddressRegister.Value = Word.FromInt(0);
        DataRegister.Value = Word.FromInt(0);

        // Read instruction
        InstructionRegister.Value = Memory[ProgramCounter.Value].Value;
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);

        // Decode and run instruction
        var (opInt, destination, operandA, operandB) = InstructionRegister.Value.AsInstruction();
        var op = (RrrInstruction)opInt;
        if (op == RrrInstruction.ExpandToRx)
            RunRxInstruction((RxInstruction)operandB, RegisterFile[destination], RegisterFile[operandA]);
        else if (op == RrrInstruction.ExpandToX)
            RunXInstruction((XInstruction)operandB, RegisterFile[operandA]);
        else
            RunRrrInstruction(op,
                RegisterFile[destination], RegisterFile[operandA], RegisterFile[operandB]);
    }

    private void RunRxInstruction(RxInstruction op, Register destination, Register offset)
    {
        AddressRegister.Value = Memory[ProgramCounter.Value].Value;
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);

        if (!_rxMap.ContainsKey(op)) throw new UnimplementedInstructionException(op.ToString());
        _rxMap[op](destination, offset);
    }

    private void RunXInstruction(XInstruction op, Register offset)
    {
        AddressRegister.Value = Memory[ProgramCounter.Value].Value;
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);

        if (!_xMap.ContainsKey(op)) throw new UnimplementedInstructionException(op.ToString());
        _xMap[op](offset);
    }

    private void RunRrrInstruction(RrrInstruction op, Register destination, Register operandA, Register operandB)
    {
        if (!_rrrMap.ContainsKey(op)) throw new UnimplementedInstructionException(op.ToString());
        _rrrMap[op](destination, operandA, operandB);
    }

    private class UnimplementedInstructionException : Exception
    {
        public UnimplementedInstructionException(string instruction) : base($"{instruction} was not implemented")
        {
        }
    }
}