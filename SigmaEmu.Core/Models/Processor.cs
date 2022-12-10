using SigmaEmu.Models;

namespace SigmaEmu.Core.Models;

public class Processor
{
    public Register ProgramCounter { get; } = new Register();
    public Register InstructionRegister { get; } = new Register();
    public Register AddressRegister { get; } = new Register();
    public Register DataRegister { get; } = new Register();

    public Register[] RegisterFile { get; } = new Register[16];

    public Memory Memory { get; } = new Memory();

    public void LoadListing(Listing listing) => Memory.LoadListing(listing);

    public void Step()
    {
        ProgramCounter.Value = Word.Increment(ProgramCounter.Value);
    }
}