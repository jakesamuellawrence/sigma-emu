namespace SigmaEmu.Shared;

public class ListingLine
{
    public bool HasBreakpoint = false;

    public Word? Address { get; set; }
    public Word? Code1 { get; set; }
    public Word? Code2 { get; set; }
    public string Source { get; set; } = "";

    public void PatchRxDisplacement(Word displacement)
    {
        Code2 = displacement;
    }
}