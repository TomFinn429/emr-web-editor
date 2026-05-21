using System;
using System.Text;

namespace zzz;

internal class z0ZzZzorj : Encoding
{
	public static z0ZzZzorj z0eek = new z0ZzZzorj();

	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
	{
		throw new NotSupportedException();
	}

	public override int GetByteCount(char[] chars, int index, int count)
	{
		throw new NotSupportedException();
	}

	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
	{
		throw new NotSupportedException();
	}

	public override int GetMaxCharCount(int byteCount)
	{
		throw new NotSupportedException();
	}

	public override string GetString(byte[] bytes, int index, int count)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = Math.Min(bytes.Length - 1, index + count - 1);
		for (int i = index; i <= num; i++)
		{
			stringBuilder.Append(Convert.ToChar(bytes[i]));
		}
		return stringBuilder.ToString();
	}

	public override int GetMaxByteCount(int charCount)
	{
		throw new NotSupportedException();
	}

	public override int GetCharCount(byte[] bytes, int index, int count)
	{
		throw new NotSupportedException();
	}
}
