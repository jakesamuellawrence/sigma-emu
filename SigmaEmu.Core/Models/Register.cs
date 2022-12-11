using SigmaEmu.Models;
using SigmaEmu.Shared;

namespace SigmaEmu.Core.Models;

public class Register
{
    public Word Value { get; set; } = Word.FromInt(0);
}