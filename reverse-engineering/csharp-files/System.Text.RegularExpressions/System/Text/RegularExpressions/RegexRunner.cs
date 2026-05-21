using System.Runtime.CompilerServices;

namespace System.Text.RegularExpressions;

public abstract class RegexRunner
{
	protected internal int runtextbeg;

	protected internal int runtextend;

	protected internal int runtextstart;

	protected internal string? runtext;

	protected internal int runtextpos;

	protected internal int[]? runtrack;

	protected internal int runtrackpos;

	protected internal int[]? runstack;

	protected internal int runstackpos;

	protected internal int[]? runcrawl;

	protected internal int runcrawlpos;

	protected internal int runtrackcount;

	protected internal Match? runmatch;

	protected internal Regex? runregex;

	private protected RegexRunnerMode _mode;

	private int _timeout;

	private bool _checkTimeout;

	private long _timeoutOccursAt;

	protected internal virtual void Scan(ReadOnlySpan<char> P_0)
	{
		string text = runtext;
		text.AsSpan().Overlaps(P_0, out var num);
		if (text == null || P_0 != text.AsSpan(num, P_0.Length))
		{
			throw new NotSupportedException("UsingSpanAPIsWithCompiledToAssembly");
		}
		if (num != 0)
		{
			runtextbeg = num;
			runtextstart += num;
			runtextend += num;
		}
		InternalScan(runregex, num, num + P_0.Length);
	}

	private Match InternalScan(Regex P_0, int P_1, int P_2)
	{
		int num = 1;
		int num2 = P_2;
		if (P_0.RightToLeft)
		{
			num = -1;
			num2 = P_1;
		}
		while (true)
		{
			if (FindFirstChar())
			{
				CheckTimeout();
				Go();
				if (runmatch.FoundMatch)
				{
					return runmatch;
				}
				runtrackpos = runtrack.Length;
				runstackpos = runstack.Length;
				runcrawlpos = runcrawl.Length;
			}
			if (runtextpos == num2)
			{
				break;
			}
			runtextpos += num;
		}
		return Match.Empty;
	}

	internal void InitializeForScan(Regex P_0, ReadOnlySpan<char> P_1, int P_2, RegexRunnerMode P_3)
	{
		_mode = P_3;
		runregex = P_0;
		runtextstart = P_2;
		runtextbeg = 0;
		runtextend = P_1.Length;
		runtextpos = P_2;
		Match match = runmatch;
		if (match == null)
		{
			runmatch = ((runregex.caps == null) ? new Match(runregex, runregex.capsize, runtext, P_1.Length) : new MatchSparse(runregex, runregex.caps, runregex.capsize, runtext, P_1.Length));
		}
		else
		{
			match.Reset(runtext, P_1.Length);
		}
		if (runcrawl != null)
		{
			runtrackpos = runtrack.Length;
			runstackpos = runstack.Length;
			runcrawlpos = runcrawl.Length;
			return;
		}
		InitTrackCount();
		int num2;
		int num = (num2 = runtrackcount * 8);
		if (num < 32)
		{
			num = 32;
		}
		if (num2 < 16)
		{
			num2 = 16;
		}
		runtrack = new int[num];
		runtrackpos = num;
		runstack = new int[num2];
		runstackpos = num2;
		runcrawl = new int[32];
		runcrawlpos = 32;
	}

	internal void InitializeTimeout(TimeSpan P_0)
	{
		_checkTimeout = false;
		if (Regex.InfiniteMatchTimeout != P_0)
		{
			ConfigureTimeout(P_0);
		}
		void ConfigureTimeout(TimeSpan timeSpan)
		{
			_checkTimeout = true;
			_timeout = (int)(timeSpan.TotalMilliseconds + 0.5);
			_timeoutOccursAt = Environment.TickCount64 + _timeout;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected internal void CheckTimeout()
	{
		if (_checkTimeout && Environment.TickCount64 >= _timeoutOccursAt)
		{
			ThrowRegexTimeout();
		}
		void ThrowRegexTimeout()
		{
			throw new RegexMatchTimeoutException(runtext ?? string.Empty, runregex.pattern, TimeSpan.FromMilliseconds(_timeout));
		}
	}

	protected virtual void Go()
	{
		throw new NotImplementedException();
	}

	protected virtual bool FindFirstChar()
	{
		throw new NotImplementedException();
	}

	protected virtual void InitTrackCount()
	{
	}

	protected void DoubleCrawl()
	{
		int[] array = new int[runcrawl.Length * 2];
		Array.Copy(runcrawl, 0, array, runcrawl.Length, runcrawl.Length);
		runcrawlpos += runcrawl.Length;
		runcrawl = array;
	}

	protected void Crawl(int P_0)
	{
		if (runcrawlpos == 0)
		{
			DoubleCrawl();
		}
		runcrawl[--runcrawlpos] = P_0;
	}

	protected void Capture(int P_0, int P_1, int P_2)
	{
		if (P_2 < P_1)
		{
			int num = P_2;
			P_2 = P_1;
			P_1 = num;
		}
		Crawl(P_0);
		runmatch.AddMatch(P_0, P_1, P_2 - P_1);
	}
}
