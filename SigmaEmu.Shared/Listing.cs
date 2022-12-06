namespace SigmaEmu.Models;

public class Listing
{
    public List<ListingLine> Lines { get; } = new List<ListingLine>();

    private int _addressCounter = 0;

    private List<string> _nextLabels = new();

    public int CurrentAddress => _addressCounter;

    public ListingLine AddInstruction(Word code1, string source, Word? code2 = null)
    {
        var addressWord = Word.FromInt(_addressCounter);
        _addressCounter += code2 == null ? 1 : 2;

        var newLine = new ListingLine(addressWord, code1, source, _nextLabels, code2);
        _nextLabels = new List<string>();
        Lines.Add(newLine);
        return newLine;
    }

    public void AddLabel(string label)
    {
        _nextLabels.Add(label);
    }
}