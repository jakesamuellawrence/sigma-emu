﻿namespace SigmaEmu.Models;

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
    Trap = 13,
    ExpandToRx = 15
}