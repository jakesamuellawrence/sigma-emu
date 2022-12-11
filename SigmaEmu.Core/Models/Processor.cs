using SigmaEmu.Models;

namespace SigmaEmu.Core.Models;

public class Processor
{
    public const int MaxRegisters = 16;
    
    private const int RemainderRegister = 15;

    public ProcessorRunningState ProcessorState { get; private set; } = ProcessorRunningState.Stopped;
    
    public Register ProgramCounter { get; } = new Register();
    public Register InstructionRegister { get; } = new Register();
    public Register AddressRegister { get; } = new Register();
    public Register DataRegister { get; } = new Register();

    public Register[] RegisterFile { get; } = new Register[MaxRegisters];

    public Memory Memory { get; } = new Memory();

    public Processor()
    {
        for (var i = 0; i < MaxRegisters; i++) RegisterFile[i] = new Register();
    }
    
    public void LoadListing(Listing listing) => Memory.LoadListing(listing);

    public void Ready() => ProcessorState = ProcessorRunningState.Paused;

    public void Halt() => ProcessorState = ProcessorRunningState.Stopped;

    public void Step()
    {
        if (ProcessorState == ProcessorRunningState.Stopped) return;
        
        // Read instruction
        InstructionRegister.Value = Memory[ProgramCounter.Value].Read();
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);
        
        // Decode Instruction
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
        AddressRegister.Value = Memory[ProgramCounter.Value].Read();
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);
        
        Console.WriteLine($"RxInstruction: {op}");
        switch (op)
        {
            case RxInstruction.Lea:
                destination.Value = AddressRegister.Value + offset.Value;
                Console.WriteLine(destination.Value.AsHexString());
                break;
            case RxInstruction.Load:
                DataRegister.Value = Memory[AddressRegister.Value + offset.Value].Read();
                destination.Value = DataRegister.Value;
                break;
            case RxInstruction.Store:
                DataRegister.Value = destination.Value;
                Memory[AddressRegister.Value].Write(DataRegister.Value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(op), op, null);
        }
    }

    private void RunRrrInstruction(RrrInstruction op, Register destination, Register operandA, Register operandB)
    {
        Console.WriteLine($"RrrInstruction: {op}");
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