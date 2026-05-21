using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Text.Unicode;

public static class UnicodeRanges
{
	private static UnicodeRange _all;

	private static UnicodeRange _u0000;

	public static UnicodeRange All => _all ?? CreateRange(ref _all, '\0', '\uffff');

	public static UnicodeRange BasicLatin => _u0000 ?? CreateRange(ref _u0000, '\0', '\u007f');

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static UnicodeRange CreateRange([NotNull] ref UnicodeRange P_0, char P_1, char P_2)
	{
		Volatile.Write(ref P_0, UnicodeRange.Create(P_1, P_2));
		return P_0;
	}
}
