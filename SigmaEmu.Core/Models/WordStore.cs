using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class WordStore
{
    private Word _value = Word.FromInt(0);

    public bool WasWrittenTo { get; private set; }
    public bool WasReadFrom { get; private set; }

    public Word Value
    {
        get
        {
            Console.WriteLine("Value read");
            WasReadFrom = true;
            return _value;
        }
        set
        {
            Console.WriteLine("Value written");
            WasWrittenTo = true;
            _value = value;
        }
    }

    public Word GetValueWithoutReading()
    {
        return _value;
    }

    public void ResetReadWrite()
    {
        WasWrittenTo = false;
        WasReadFrom = false;
    }
}