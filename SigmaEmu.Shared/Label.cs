namespace SigmaEmu.Shared;

public class Label
{
    public Label(string name, Word? address = null, int? definedOn = null)
    {
        Name = name;
        Address = address;
        DefinedOn = definedOn;
    }

    public string Name { get; }
    public Word? Address { get; private set; }
    public int? DefinedOn { get; private set; }
    public List<int> UsedOn { get; } = new();

    public void Define(Word address, int lineNumber)
    {
        Address = address;
        DefinedOn = lineNumber;
    }

    public void AddUsage(int line)
    {
        UsedOn.Add(line);
    }
}