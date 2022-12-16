namespace SigmaEmu.Shared;

public class Listing
{
    private Word _latestAddress = Word.FromInt(0);

    public Listing(int nLines)
    {
        Lines = new ListingLine[nLines];
        for (var i = 0; i < nLines; i++) Lines[i] = new ListingLine();
    }

    public ListingLine[] Lines { get; }
    public Dictionary<string, Label> LabelMap { get; } = new();
    public List<Error> Errors { get; init; } = new();

    public void DefineLabel(string label, int lineNumber)
    {
        if (!LabelMap.ContainsKey(label))
        {
            LabelMap.Add(label, new Label(label, _latestAddress, lineNumber));
            return;
        }

        LabelMap[label].Define(_latestAddress, lineNumber);
        foreach (var usageLine in LabelMap[label].UsedOn)
            Lines[usageLine - 1].PatchRxDisplacement(_latestAddress);
    }

    public void UseLabel(string label, int lineNumber)
    {
        if (!LabelMap.ContainsKey(label)) LabelMap.Add(label, new Label(label));

        LabelMap[label].AddUsage(lineNumber);
    }

    public Word LookupLabel(string label)
    {
        if (!LabelMap.ContainsKey(label)) return Word.FromInt(-1);
        return LabelMap[label].Address ?? Word.FromInt(-1);
    }

    public bool HasLabelBeenDefined(string label)
    {
        return LabelMap.ContainsKey(label) && LabelMap[label].Address is not null;
    }

    public void AddSourceOnLine(int lineNumber, string source)
    {
        Lines[lineNumber - 1].Source = source.TrimEnd();
    }

    public void UpdateAddresses()
    {
        var lastAddress = 0;
        foreach (var line in Lines)
            if (line.Address is not null) lastAddress = line.Address.AsInt();
            else line.Address = Word.FromInt(lastAddress);
    }

    public void AddInstruction(int lineNumber, Word code1, Word? code2 = null)
    {
        Lines[lineNumber - 1].Address = _latestAddress;

        _latestAddress = Word.Increment(_latestAddress);
        if (code2 is not null) _latestAddress = Word.Increment(_latestAddress);

        Lines[lineNumber - 1].Code1 = code1;
        Lines[lineNumber - 1].Code2 = code2;
    }

    public void AddError(string message, int? lineNumber = null)
    {
        Errors.Add(new Error
        {
            Message = message,
            LineNumber = lineNumber
        });
    }
}