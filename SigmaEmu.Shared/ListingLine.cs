namespace SigmaEmu.Models;

public class ListingLine
{
    public Word Address { get; }
    public Word Code1 { get;  }
    public Word? Code2 { get; private set; }
    public List<string> Labels { get; }
    public string Source { get; }

    public void PatchRxDisplacement(Word displacement)
    {
        Code2 = displacement;
    }

    public ListingLine(Word address, Word code1, string source, List<string> labels, Word? code2 = null)
    {
        Address = address;
        Code1 = code1;
        Code2 = code2;
        Source = source;
        Labels = labels;
    }
    
}