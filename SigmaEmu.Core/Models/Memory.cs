using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class Memory
{
    public const int MaxMemory = 128;

    public Memory()
    {
        for (var i = 0; i < MaxMemory; i++) MemoryArray[i] = new MemoryUnit();
    }

    private MemoryUnit[] MemoryArray { get; } = new MemoryUnit[MaxMemory];

    public MemoryUnit this[int key]
    {
        get => MemoryArray[key];
        set => MemoryArray[key] = value;
    }

    public MemoryUnit this[Word key]
    {
        get => MemoryArray[key.AsInt()];
        set => MemoryArray[key.AsInt()] = value;
    }

    public void Reset()
    {
        var zero = Word.FromInt(0);
        foreach (var unit in MemoryArray) unit.Value = zero;
    }

    public void LoadListing(Listing listing, int offset = 0)
    {
        var i = offset;
        foreach (var line in listing.Lines)
        {
            if (line.Code1 is not null) MemoryArray[i++].Value = line.Code1;
            if (line.Code2 is not null) MemoryArray[i++].Value = line.Code2;
        }
    }

    public void ResetReadWrite()
    {
        foreach (var unit in MemoryArray) unit.ResetReadWrite();
    }
}