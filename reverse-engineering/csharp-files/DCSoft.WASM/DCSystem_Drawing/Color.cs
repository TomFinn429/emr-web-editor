using System;
using System.Diagnostics;
using zzz;

namespace DCSystem_Drawing;

[DebuggerDisplay("{NameAndARGBValue}")]
public readonly struct Color : IEquatable<Color>
{
	public static readonly Color Empty = new Color(0u);

	public static readonly Color Transparent = new Color(16777215u);

	public static readonly Color AliceBlue = new Color(4293982463u);

	public static readonly Color Black = new Color(4278190080u);

	public static readonly Color Blue = new Color(4278190335u);

	public static readonly Color Coral = new Color(4294934352u);

	public static readonly Color DarkBlue = new Color(4278190219u);

	public static readonly Color DarkGray = new Color(4289309097u);

	public static readonly Color Gray = new Color(4286611584u);

	public static readonly Color Green = new Color(4278222848u);

	public static readonly Color LightBlue = new Color(4289583334u);

	public static readonly Color LightCoral = new Color(4293951616u);

	public static readonly Color LightGray = new Color(4292072403u);

	public static readonly Color LightYellow = new Color(4294967264u);

	public static readonly Color Red = new Color(4294901760u);

	public static readonly Color White = new Color(4294967295u);

	public static readonly Color Yellow = new Color(4294967040u);

	internal const int ARGBAlphaShift = 24;

	internal const int ARGBRedShift = 16;

	internal const int ARGBGreenShift = 8;

	internal const int ARGBBlueShift = 0;

	internal const uint ARGBAlphaMask = 4278190080u;

	internal readonly uint _value;

	private string NameAndARGBValue => _value.ToString("X8");

	public bool IsEmpty => _value == 0;

	public bool IsBlack => _value == Black._value;

	public byte R => (byte)(_value >> 16);

	public byte G => (byte)(_value >> 8);

	public byte B => (byte)_value;

	public byte A => (byte)(_value >> 24);

	internal Color(uint v)
	{
		_value = v;
	}

	public string ToHtmlString()
	{
		return z0ZzZzifh.z0eek(this);
	}

	private static void CheckByte(int value, string name)
	{
		if ((uint)value > 255u)
		{
			ThrowOutOfByteRange(value, name);
		}
		static void ThrowOutOfByteRange(int v, string n)
		{
			throw new ArgumentException("InvalidEx2BoundArgument");
		}
	}

	public static Color FromArgb(int argb)
	{
		return new Color((uint)argb);
	}

	public static Color FromArgb(int alpha, int red, int green, int blue)
	{
		CheckByte(alpha, "alpha");
		CheckByte(red, "red");
		CheckByte(green, "green");
		CheckByte(blue, "blue");
		return FromArgb((alpha << 24) | (red << 16) | (green << 8) | blue);
	}

	public static Color FromArgb(int alpha, Color baseColor)
	{
		CheckByte(alpha, "alpha");
		return FromArgb((alpha << 24) | (int)(baseColor._value & 0xFFFFFF));
	}

	public static Color FromArgb(int red, int green, int blue)
	{
		return FromArgb(255, red, green, blue);
	}

	public int ToArgb()
	{
		return (int)_value;
	}

	public override string ToString()
	{
		return $"{"Color"} [A={A}, R={R}, G={G}, B={B}]";
	}

	public static bool operator ==(Color left, Color right)
	{
		return left._value == right._value;
	}

	public static bool operator !=(Color left, Color right)
	{
		return left._value != right._value;
	}

	public override bool Equals(object obj)
	{
		if (obj is Color other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Color other)
	{
		return _value == other._value;
	}

	public override int GetHashCode()
	{
		return (int)_value;
	}
}
