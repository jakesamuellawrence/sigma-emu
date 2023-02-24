using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class WordStore
{
    protected Word _value = Word.FromInt(0);

    public bool WasWrittenTo { get; protected set; }
    public bool WasReadFrom { get; protected set; }

    public virtual Word Value
    {
        get
        {
            WasReadFrom = true;
            return _value;
        }
        set
        {
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