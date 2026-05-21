using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions.Generated;

[GeneratedCode("System.Text.RegularExpressions.Generator", "7.0.10.26716")]
[SkipLocalsInit]
internal sealed class _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__LanguageRegex_2 : Regex
{
	private sealed class RunnerFactory : RegexRunnerFactory
	{
		private sealed class Runner : RegexRunner
		{
			protected override void Scan(ReadOnlySpan<char> P_0)
			{
				if (TryFindNextPossibleStartingPosition(P_0) && !TryMatchAtCurrentPosition(P_0))
				{
					runtextpos = P_0.Length;
				}
			}

			private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> P_0)
			{
				int num = runtextpos;
				if ((uint)num < (uint)P_0.Length && num == 0)
				{
					return true;
				}
				runtextpos = P_0.Length;
				return false;
			}

			private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> P_0)
			{
				int num = runtextpos;
				int num2 = num;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				ReadOnlySpan<char> readOnlySpan = P_0.Slice(num);
				if (num != 0)
				{
					return false;
				}
				num3 = num;
				int i;
				for (i = 0; i < 8 && (uint)i < (uint)readOnlySpan.Length && char.IsAsciiLetter(readOnlySpan[i]); i++)
				{
				}
				if (i == 0)
				{
					return false;
				}
				readOnlySpan = readOnlySpan.Slice(i);
				num += i;
				num4 = num;
				num3++;
				while (true)
				{
					num5 = 0;
					while (true)
					{
						_003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__Utilities.StackPush(ref runstack, ref num6, num);
						num5++;
						if (readOnlySpan.IsEmpty || readOnlySpan[0] != '-')
						{
							break;
						}
						num++;
						readOnlySpan = P_0.Slice(num);
						int j;
						for (j = 0; j < 8 && (uint)j < (uint)readOnlySpan.Length && char.IsAsciiLetterOrDigit(readOnlySpan[j]); j++)
						{
						}
						if (j == 0)
						{
							break;
						}
						readOnlySpan = readOnlySpan.Slice(j);
						num += j;
					}
					while (--num5 >= 0)
					{
						num = runstack[--num6];
						readOnlySpan = P_0.Slice(num);
						if (num >= P_0.Length - 1 && ((uint)num >= (uint)P_0.Length || P_0[num] == '\n'))
						{
							runtextpos = num;
							Capture(0, num2, num);
							return true;
						}
					}
					if (_003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num3 >= num4)
					{
						break;
					}
					num = --num4;
					readOnlySpan = P_0.Slice(num);
				}
				return false;
			}
		}

		protected override RegexRunner CreateInstance()
		{
			return new Runner();
		}
	}

	internal static readonly _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__LanguageRegex_2 Instance = new _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__LanguageRegex_2();

	private _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__LanguageRegex_2()
	{
		pattern = "^([a-zA-Z]{1,8})(-[a-zA-Z0-9]{1,8})*$";
		roptions = RegexOptions.ExplicitCapture;
		Regex.ValidateMatchTimeout(_003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__Utilities.s_defaultTimeout);
		internalMatchTimeout = _003CRegexGenerator_g_003EF6DD43EEA644F37FBD420BF6C4F76D7CBF00A201A3A5DFAA2DE4DAED4B5EFB477__Utilities.s_defaultTimeout;
		factory = new RunnerFactory();
		capsize = 1;
	}
}
