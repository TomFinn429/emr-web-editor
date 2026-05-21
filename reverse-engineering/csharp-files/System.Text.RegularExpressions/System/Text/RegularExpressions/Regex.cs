using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Threading;

namespace System.Text.RegularExpressions;

public class Regex : ISerializable
{
	[StringSyntax("Regex")]
	protected internal string? pattern;

	protected internal RegexOptions roptions;

	protected internal RegexRunnerFactory? factory;

	protected internal Hashtable? caps;

	protected internal int capsize;

	private volatile RegexRunner _runner;

	public static readonly TimeSpan InfiniteMatchTimeout = Timeout.InfiniteTimeSpan;

	internal static readonly TimeSpan s_defaultMatchTimeout = InitDefaultMatchTimeout();

	protected internal TimeSpan internalMatchTimeout;

	public bool RightToLeft => (roptions & RegexOptions.RightToLeft) != 0;

	protected Regex()
	{
		internalMatchTimeout = s_defaultMatchTimeout;
	}

	protected internal static void ValidateMatchTimeout(TimeSpan P_0)
	{
		long ticks = P_0.Ticks;
		if (ticks != -10000 && (ulong)(ticks - 1) >= 21474836460000uL)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.matchTimeout);
		}
	}

	void ISerializable.GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		throw new PlatformNotSupportedException();
	}

	public override string ToString()
	{
		return pattern;
	}

	internal Match RunSingleMatch(RegexRunnerMode P_0, int P_1, string P_2, int P_3, int P_4, int P_5)
	{
		if ((uint)P_5 > (uint)P_2.Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startat, ExceptionResource.BeginIndexNotNegative);
		}
		if ((uint)P_4 > (uint)P_2.Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length, ExceptionResource.LengthNotNegative);
		}
		RegexRunner regexRunner = Interlocked.Exchange(ref _runner, null) ?? CreateRunner();
		try
		{
			regexRunner.InitializeTimeout(internalMatchTimeout);
			regexRunner.runtext = P_2;
			ReadOnlySpan<char> readOnlySpan = P_2.AsSpan(P_3, P_4);
			regexRunner.InitializeForScan(this, readOnlySpan, P_5 - P_3, P_0);
			if (P_1 == 0)
			{
				int num = readOnlySpan.Length;
				int num2 = 1;
				if (RightToLeft)
				{
					num = 0;
					num2 = -1;
				}
				if (regexRunner.runtextstart == num)
				{
					return Match.Empty;
				}
				regexRunner.runtextpos += num2;
			}
			return ScanInternal(P_0, P_0 == RegexRunnerMode.ExistenceRequired, P_2, P_3, regexRunner, readOnlySpan, true);
		}
		finally
		{
			regexRunner.runtext = null;
			_runner = regexRunner;
		}
	}

	private static Match ScanInternal(RegexRunnerMode P_0, bool P_1, string P_2, int P_3, RegexRunner P_4, ReadOnlySpan<char> P_5, bool P_6)
	{
		P_4.Scan(P_5);
		Match runmatch = P_4.runmatch;
		if (runmatch.FoundMatch)
		{
			if (!P_1)
			{
				runmatch.Text = P_2;
				P_4.runmatch = null;
			}
			else if (P_6)
			{
				runmatch.Text = null;
				return null;
			}
			runmatch.Tidy(P_4.runtextpos, P_3, P_0);
			return runmatch;
		}
		runmatch.Text = null;
		return Match.Empty;
	}

	private RegexRunner CreateRunner()
	{
		return factory.CreateInstance();
	}

	public bool IsMatch(string P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.input);
		}
		return RunSingleMatch(RegexRunnerMode.ExistenceRequired, -1, P_0, 0, P_0.Length, RightToLeft ? P_0.Length : 0) == null;
	}

	private static TimeSpan InitDefaultMatchTimeout()
	{
		object data = AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT");
		if (!(data is TimeSpan timeSpan))
		{
			if (data == null)
			{
				return InfiniteMatchTimeout;
			}
			throw new InvalidCastException(System.SR.Format("IllegalDefaultRegexMatchTimeoutInAppDomain", "REGEX_DEFAULT_MATCH_TIMEOUT", data));
		}
		try
		{
			ValidateMatchTimeout(timeSpan);
			return timeSpan;
		}
		catch (ArgumentOutOfRangeException)
		{
			throw new ArgumentOutOfRangeException(System.SR.Format("IllegalDefaultRegexMatchTimeoutInAppDomain", "REGEX_DEFAULT_MATCH_TIMEOUT", timeSpan));
		}
	}
}
