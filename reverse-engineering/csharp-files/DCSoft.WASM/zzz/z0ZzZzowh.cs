using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace zzz;

internal static class z0ZzZzowh
{
	[CompilerGenerated]
	private sealed class z0wyk
	{
		public static SpanAction<char, (string input, int idxOfFirstSurrogate)> z0rek;

		public static readonly z0wyk z0tek = new z0wyk();

		internal void z0eek(Span<char> p0, (string input, int idxOfFirstSurrogate) p1)
		{
			p1.input.CopyTo(p0);
			for (int i = p1.idxOfFirstSurrogate; i < p0.Length; i++)
			{
				char c = p0[i];
				if (char.IsLowSurrogate(c))
				{
					p0[i] = '\ufffd';
				}
				else if (char.IsHighSurrogate(c))
				{
					if (i + 1 < p0.Length && char.IsLowSurrogate(p0[i + 1]))
					{
						i++;
					}
					else
					{
						p0[i] = '\ufffd';
					}
				}
			}
		}
	}

	internal static string z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		int num = -1;
		for (int i = 0; i < p0.Length; i++)
		{
			if (char.IsSurrogate(p0[i]))
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return p0;
		}
		return string.Create(p0.Length, (p0, num), delegate(Span<char> span, (string input, int idxOfFirstSurrogate) tuple)
		{
			tuple.input.CopyTo(span);
			for (int j = tuple.idxOfFirstSurrogate; j < span.Length; j++)
			{
				char c = span[j];
				if (char.IsLowSurrogate(c))
				{
					span[j] = '\ufffd';
				}
				else if (char.IsHighSurrogate(c))
				{
					if (j + 1 < span.Length && char.IsLowSurrogate(span[j + 1]))
					{
						j++;
					}
					else
					{
						span[j] = '\ufffd';
					}
				}
			}
		});
	}
}
