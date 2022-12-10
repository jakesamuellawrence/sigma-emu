using SigmaEmu.Models;

namespace SigmaEmu.Core.Models;

public class Memory
{
    public const int MaxMemory = 64;
    
    public MemoryUnit[] MemoryArray { get; } = new MemoryUnit[MaxMemory];

    public Memory()
    {
        for (var i = 0; i < MaxMemory; i++)
        {
            MemoryArray[i] = new MemoryUnit();
        }
    }

    public void LoadListing(Listing listing, int offset = 0)
    {
        var i = offset;
        foreach (var line in listing.Lines)
        {
            MemoryArray[i++].Write(line.Code1);
            if (line.Code2 is not null) MemoryArray[i++].Write(line.Code2);
        }
    }
}