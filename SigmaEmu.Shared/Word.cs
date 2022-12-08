namespace SigmaEmu.Models;

public class Word
{
    public int Value { get; init; } = 0;

    public string ToHexString()
    {
        return $"{Value:x4}";
    }

    public static Word FromInstruction(int b1, int b2, int b3, int b4)
    {
        var wordString = $"{b1:X1}{b2:X1}{b3:X1}{b4:X1}";
        var wordValue = int.Parse(wordString, System.Globalization.NumberStyles.HexNumber);
        return new Word() { Value = wordValue };
    }

    public static Word FromInt(int value)
    {
        return new Word() { Value = value };
    }
}