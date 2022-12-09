using SigmaEmu.Models;

namespace SigmaEmu.Core.Models;

public class Register
{
    public Word Value { get; set; } = Word.FromInt(0);
}