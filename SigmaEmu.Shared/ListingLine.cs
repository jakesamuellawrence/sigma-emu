namespace SigmaEmu.Models;

public class ListingLine
{
    public Word Address { get; }
    public Word Code1 { get;  }
    public Word? Code2 { get; }
    public string Source { get; }

    public ListingLine(Word address, Word code1, string source, Word? code2 = null)
    {
        Address = address;
        Code1 = code1;
        Code2 = code2;
        Source = source;
    }
}