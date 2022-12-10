namespace SigmaEmu.Models;

public class Listing
{
    public List<ListingLine> Lines { get; } = new();
    public List<AssemblerError> Errors { get; init; } = new();

    private int _addressCounter = 0;

    public int CurrentAddress => _addressCounter;

    public ListingLine AddInstruction(Word code1, string source, Word? code2 = null)
    {
        var addressWord = Word.FromInt(_addressCounter);
        _addressCounter += code2 is null ? 1 : 2;

        var newLine = new ListingLine(addressWord, code1, source, code2);
        Lines.Add(newLine);
        return newLine;
    }
}