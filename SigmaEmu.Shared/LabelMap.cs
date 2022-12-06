using System.Linq.Expressions;

namespace SigmaEmu.Models;

public class LabelMap
{
    private Dictionary<string, Word> AddressMap { get; } = new();
    private Dictionary<string, List<ListingLine>> ToPatch { get; } = new();

    public void DefineLabel(string label, Word address)
    {
        AddressMap.Add(label, address);
        if (ToPatch.ContainsKey(label))
        {
            PatchAll(ToPatch[label], address);
            ToPatch.Remove(label);
        }
    }

    public bool HasLabel(string label)
    {
        return AddressMap.ContainsKey(label);
    }

    private void PatchAll(List<ListingLine> lines, Word address)
    {
        foreach (var line in lines)
        {
            line.PatchRxDisplacement(address);
        }
    }

    public Word GetAddress(string label)
    {
        return AddressMap.ContainsKey(label) ? AddressMap[label] : Word.FromInt(-1);
    }

    public void RememberLineToPatch(string label, ListingLine line)
    {
        if (!ToPatch.ContainsKey(label)) ToPatch[label] = new List<ListingLine>();
        ToPatch[label].Add(line);
    }

    public bool HasLinesToPatch()
    {
        return ToPatch.Count != 0;
    }

    public List<string> GetUndefinedLabels()
    {
        return ToPatch.Keys.ToList();
    }
    
}