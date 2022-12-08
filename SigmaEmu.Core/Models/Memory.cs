using SigmaEmu.Models;

namespace SigmaEmu.Core.Models;

public class Memory
{
    public const int MaxMemory = 16383;
    
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
            if (line.Code2 != null) MemoryArray[i++].Write(line.Code2);
        }
    }
}