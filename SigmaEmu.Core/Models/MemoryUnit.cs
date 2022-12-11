using SigmaEmu.Models;
using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class MemoryUnit
{
    private Word _value = Word.FromInt(0);

    public void Write(Word value)
    {
        _value = value;
    }

    public Word Read()
    {
        return _value;
    }

    public override string ToString()
    {
        return _value.AsHexString();
    }
}