using SigmaEmu.Models;
using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class Processor
{
    public const int MaxRegisters = 16;

    private const int RemainderRegister = 15;

    public Processor()
    {
        for (var i = 0; i < MaxRegisters; i++) RegisterFile[i] = new Register();
    }

    public ProcessorRunningState ProcessorState { get; private set; } = ProcessorRunningState.Stopped;

    public Register ProgramCounter { get; } = new();
    public Register InstructionRegister { get; } = new();
    public Register AddressRegister { get; } = new();
    public Register DataRegister { get; } = new();

    public Register[] RegisterFile { get; } = new Register[MaxRegisters];

    public Memory Memory { get; } = new();

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
        else
            RunRrrInstruction(op,
                RegisterFile[destination], RegisterFile[operandA], RegisterFile[operandB]);
    }

    private void RunRxInstruction(RxInstruction op, Register destination, Register offset)
    {
        AddressRegister.Value = Memory[ProgramCounter.Value].Value;
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);

        switch (op)
        {
            case RxInstruction.Lea:
                destination.Value = AddressRegister.Value + offset.Value;
                break;
            case RxInstruction.Load:
                DataRegister.Value = Memory[AddressRegister.Value + offset.Value].Value;
                destination.Value = DataRegister.Value;
                break;
            case RxInstruction.Store:
                DataRegister.Value = destination.Value;
                Memory[AddressRegister.Value].Value = DataRegister.Value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(op), op, null);
        }
    }

    private void RunRrrInstruction(RrrInstruction op, Register destination, Register operandA, Register operandB)
    {
        switch (op)
        {
            case RrrInstruction.Add:
                destination.Value = operandA.Value + operandB.Value;
                break;
            case RrrInstruction.Sub:
                destination.Value = operandA.Value - operandB.Value;
                break;
            case RrrInstruction.Mul:
                destination.Value = operandA.Value * operandB.Value;
                break;
            case RrrInstruction.Div:
                destination.Value = operandA.Value / operandB.Value;
                RegisterFile[RemainderRegister].Value = operandA.Value % operandB.Value;
                break;
            case RrrInstruction.Trap:
                Halt();
                break;
            case RrrInstruction.ExpandToRx:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(op), op, null);
        }
    }
}