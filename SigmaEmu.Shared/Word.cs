namespace SigmaEmu.Shared;

public class Word
{
    private class BadWordFormat : Exception
    {
        public BadWordFormat(string message) : base(message)
        {
        }
    }

    public int Value { private get; init; } = 0;

    public string AsHexString()
    {
        return $"{Value:x4}";
    }

    public int AsInt()
    {
        return Value;
    }

    public (int, int, int, int) AsInstruction()
    {
        var hex = AsHexString();
        if (hex.Length != 4) throw new BadWordFormat("Word did not have 4 characters");
        
        int FromHex(char value) => int.Parse(value.ToString(), System.Globalization.NumberStyles.HexNumber);
        return (FromHex(hex[0]), FromHex(hex[1]), FromHex(hex[2]), FromHex(hex[3]));
    }

    public static Word Increment(Word a, int value = 1) => FromInt(a.Value + 1);

    public static Word operator +(Word a, Word b) => Word.FromInt(a.Value + b.Value);
    public static Word operator -(Word a, Word b) => Word.FromInt(a.Value - b.Value);
    public static Word operator /(Word a, Word b) => Word.FromInt(a.Value / b.Value);
    public static Word operator %(Word a, Word b) => Word.FromInt(a.Value % b.Value);
    public static Word operator *(Word a, Word b) => Word.FromInt(a.Value * b.Value);
    public static bool operator <(Word a, Word b) => a.Value < b.Value;
    public static bool operator >(Word a, Word b) => a.Value > b.Value;
    public static bool operator ==(Word a, Word b) => a.Value == b.Value;
    public static bool operator !=(Word a, Word b) => a.Value != b.Value;
    public static Word operator !(Word a) => Word.FromBool(a.Value == 0);
    public static Word operator &(Word a, Word b) => Word.FromBool(a.Value != 0 && b.Value != 0);
    public static Word operator |(Word a, Word b) => Word.FromBool(a.Value != 0 || b.Value != 0);

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

    public static Word FromBool(bool value)
    {
        return Word.FromInt(value ? 1 : 0);
    }
    
    protected bool Equals(Word other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Word)obj);
    }

    public override int GetHashCode()
    {
        return Value;
    }
}