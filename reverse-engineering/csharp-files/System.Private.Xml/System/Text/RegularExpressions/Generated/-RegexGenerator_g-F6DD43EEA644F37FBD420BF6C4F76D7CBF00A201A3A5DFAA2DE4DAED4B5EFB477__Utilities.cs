using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "7.0.10.26716")]
internal static class _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__Utilities
{
	internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

	internal static readonly bool s_hasTimeout = s_defaultTimeout != Timeout.InfiniteTimeSpan;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void StackPush(ref int[] P_0, ref int P_1, int P_2)
	{
		int[] array = P_0;
		int num = P_1;
		if ((uint)num < (uint)array.Length)
		{
			array[num] = P_2;
			P_1++;
		}
		else
		{
			WithResize(ref P_0, ref P_1, P_2);
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		static void WithResize(ref int[] reference, ref int reference2, int num2)
		{
			Array.Resize(ref reference, reference2 * 2);
			StackPush(ref reference, ref reference2, num2);
		}
	}
}
