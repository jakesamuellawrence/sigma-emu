namespace SigmaEmu.Shared;

public enum RrrInstruction
{
    Add = 0,
    Sub = 1,
    Mul = 2,
    Div = 3,
    CmpLt = 4,
    CmpEq = 5,
    CmpGt = 6,
    Inv = 7,
    And = 8,
    Or = 9,
    Xor = 10,
    ShiftL = 11,
    ShiftR = 12,
    Trap = 13,
    ExpandToX = 14,
    ExpandToRx = 15
}