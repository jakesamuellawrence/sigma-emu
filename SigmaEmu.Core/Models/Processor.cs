using SigmaEmu.Models;

namespace SigmaEmu.Core.Models;

public class Processor
{
    public const int MaxRegisters = 16;
    
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

    public void Step()
    {
        // Read instruction
        InstructionRegister.Value = Memory[ProgramCounter.Value.AsInt()].Read();
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
        AddressRegister.Value = Memory[ProgramCounter.Value.AsInt()].Read();
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);
        
        Console.WriteLine($"RxInstruction: {op}");
    }

    private void RunRrrInstruction(RrrInstruction op, Register destination, Register operandA, Register operandB)
    {
        Console.WriteLine($"RrrInstruction: {op}");
    }
}