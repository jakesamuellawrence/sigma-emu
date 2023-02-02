namespace SigmaEmu.Shared;

public class Listing
{
    private readonly List<Error> _errors = new();
    private readonly Dictionary<string, Label> _labelMap = new();
    private readonly ListingLine[] _lines;
    private Word _latestAddress = Word.FromInt(0);

    public Listing(int nLines)
    {
        _lines = new ListingLine[nLines];
        for (var i = 0; i < nLines; i++) _lines[i] = new ListingLine();
    }

    public IEnumerable<Label> Labels => _labelMap.Values;
    public IEnumerable<ListingLine> Lines => _lines;
    public IEnumerable<Error> Errors => _errors;

    public int NumLines => _lines.Length;

    public IEnumerable<Error> GetLinelessErrors()
    {
        return _errors.Where(error => error.LineNumber is null);
    }

    public IEnumerable<Error> GetErrorsForLine(int lineNumber)
    {
        return _errors.Where(error => error.LineNumber == lineNumber);
    }

    public ListingLine GetLine(int lineNumber)
    {
        return _lines[lineNumber - 1];
    }

    public void DefineLabel(string label, int lineNumber)
    {
        if (!_labelMap.ContainsKey(label))
        {
            _labelMap.Add(label, new Label(label, _latestAddress, lineNumber));
            return;
        }

        _labelMap[label].Define(_latestAddress, lineNumber);
        foreach (var usageLine in _labelMap[label].UsedOn)
            _lines[usageLine - 1].PatchRxDisplacement(_latestAddress);
    }

    public void UseLabel(string label, int lineNumber)
    {
        if (!_labelMap.ContainsKey(label)) _labelMap.Add(label, new Label(label));

        _labelMap[label].AddUsage(lineNumber);
    }

    public IEnumerable<Label> GetUndefinedLabels()
    {
        return _labelMap.Values.Where(label => label.DefinedOn is null);
    }

    public Word LookupLabel(string label)
    {
        if (!_labelMap.ContainsKey(label)) return Word.FromInt(-1);
        return _labelMap[label].Address ?? Word.FromInt(-1);
    }

    public bool HasLabelBeenDefined(string label)
    {
        return _labelMap.ContainsKey(label) && _labelMap[label].Address is not null;
    }

    public void AddSourceOnLine(int lineNumber, string source)
    {
        _lines[lineNumber - 1].Source = source.TrimEnd();
    }

    public void UpdateAddresses()
    {
        var lastAddress = 0;
        foreach (var line in _lines)
            if (line.Address is not null) lastAddress = line.Address.AsInt();
            else line.Address = Word.FromInt(lastAddress);
    }

    public void AddInstruction(int lineNumber, Word code1, Word? code2 = null)
    {
        _lines[lineNumber - 1].Address = _latestAddress;

        _latestAddress = Word.Increment(_latestAddress);
        if (code2 is not null) _latestAddress = Word.Increment(_latestAddress);

        _lines[lineNumber - 1].Code1 = code1;
        _lines[lineNumber - 1].Code2 = code2;
    }

    public void AddError(string message, int? lineNumber = null)
    {
        _errors.Add(new Error
        {
            Message = message,
            LineNumber = lineNumber
        });
    }

    public bool HasErrors()
    {
        return _errors.Count != 0;
    }

    public HashSet<Word> GetBreakpointAddresses()
    {
        var set = new HashSet<Word>();

        foreach (var line in _lines)
            if (line.HasBreakpoint && line.Address is not null)
                set.Add(line.Address);

        return set;
    }
}