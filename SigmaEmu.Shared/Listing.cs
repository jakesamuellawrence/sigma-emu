namespace SigmaEmu.Models;

public class Listing
{
    public List<ListingLine> Lines { get; } = new();
    public List<AssemblerError> Errors { get; init; } = new();

    public int CurrentAddress { get; private set; } = 0;

    public ListingLine AddInstruction(Word code1, string source, Word? code2 = null)
    {
        var addressWord = Word.FromInt(CurrentAddress);
        CurrentAddress += code2 is null ? 1 : 2;

        var newLine = new ListingLine(addressWord, code1, source, code2);
        Lines.Add(newLine);
        return newLine;
    }
}