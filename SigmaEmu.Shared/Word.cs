using System.Globalization;

namespace SigmaEmu.Shared;

public class Word
{
    public int Value { private get; init; }

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

        int FromHex(char value)
        {
            return int.Parse(value.ToString(), NumberStyles.HexNumber);
        }

        return (FromHex(hex[0]), FromHex(hex[1]), FromHex(hex[2]), FromHex(hex[3]));
    }

    public static Word Increment(Word a, int value = 1)
    {
        return FromInt(a.Value + 1);
    }

    public static Word operator +(Word a, Word b)
    {
        return FromInt(a.Value + b.Value);
    }

    public static Word operator -(Word a, Word b)
    {
        return FromInt(a.Value - b.Value);
    }

    public static Word operator /(Word a, Word b)
    {
        return FromInt(a.Value / b.Value);
    }

    public static Word operator %(Word a, Word b)
    {
        return FromInt(a.Value % b.Value);
    }

    public static Word operator *(Word a, Word b)
    {
        return FromInt(a.Value * b.Value);
    }

    public static bool operator <(Word a, Word b)
    {
        return a.Value < b.Value;
    }

    public static bool operator >(Word a, Word b)
    {
        return a.Value > b.Value;
    }

    public static bool operator ==(Word a, Word b)
    {
        return a.Value == b.Value;
    }

    public static bool operator !=(Word a, Word b)
    {
        return a.Value != b.Value;
    }

    public static Word operator !(Word a)
    {
        return FromBool(a.Value == 0);
    }

    public static Word operator &(Word a, Word b)
    {
        return FromBool(a.Value != 0 && b.Value != 0);
    }

    public static Word operator |(Word a, Word b)
    {
        return FromBool(a.Value != 0 || b.Value != 0);
    }

    public static Word FromInstruction(int b1, int b2, int b3, int b4)
    {
        var wordString = $"{b1:X1}{b2:X1}{b3:X1}{b4:X1}";
        var wordValue = int.Parse(wordString, NumberStyles.HexNumber);
        return new Word { Value = wordValue };
    }

    public static Word FromInt(int value)
    {
        return new Word { Value = value };
    }

    public static Word FromBool(bool value)
    {
        return FromInt(value ? 1 : 0);
    }

    public static Word FromHex(string hex)
    {
        var wordValue = int.Parse(hex, NumberStyles.HexNumber);
        return FromInt(wordValue);
    }

    protected bool Equals(Word other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Word)obj);
    }

    public override int GetHashCode()
    {
        return Value;
    }

    private class BadWordFormat : Exception
    {
        public BadWordFormat(string message) : base(message)
        {
        }
    }
}