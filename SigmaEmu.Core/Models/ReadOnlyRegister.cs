using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class ReadOnlyRegister : Register
{
    public override Word Value
    {
        get
        {
            WasReadFrom = true;
            return _value;
        }
        set
        {
            // intentionally blank. Attempting to write should do nothing
        }
    }
}