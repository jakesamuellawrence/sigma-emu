namespace SigmaEmu.Models;

public class ListingLine
{
    public Word Address { get; }
    public Word Code1 { get;  }
    public Word? Code2 { get; private set; }
    public string Source { get; }

    public void PatchRxDisplacement(Word displacement)
    {
        Code2 = displacement;
    }

    public ListingLine(Word address, Word code1, string source, Word? code2 = null)
    {
        Address = address;
        Code1 = code1;
        Code2 = code2;
        Source = source;
    }

    public string Format()
    {
        return $"{Address.ToHexString()} \t {Code1.ToHexString()} {(Code2 != null ? Code2.ToHexString() : '\t')} \t {Source}";
    }
    
}