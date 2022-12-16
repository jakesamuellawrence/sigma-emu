namespace SigmaEmu.Shared;

public class ListingLine
{
    // public ListingLine(Word address, Word code1, string source, Word? code2 = null)
    // {
    //     Address = address;
    //     Code1 = code1;
    //     Code2 = code2;
    //     Source = source;
    // }

    public Word? Address { get; set; }
    public Word? Code1 { get; set; }
    public Word? Code2 { get; set; }
    public string Source { get; set; } = "";

    public void PatchRxDisplacement(Word displacement)
    {
        Code2 = displacement;
    }
}