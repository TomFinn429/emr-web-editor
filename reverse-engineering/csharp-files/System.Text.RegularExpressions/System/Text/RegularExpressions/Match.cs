namespace System.Text.RegularExpressions;

public class Match : Group
{
	internal GroupCollection _groupcoll;

	internal readonly Regex _regex;

	internal int _textbeg;

	internal int _textpos;

	internal int _textend;

	internal readonly int[][] _matches;

	internal readonly int[] _matchcount;

	internal bool _balancing;

	public static Match Empty { get; } = new Match(null, 1, string.Empty, 0);

	internal bool FoundMatch => _matchcount[0] > 0;

	internal Match(Regex P_0, int P_1, string P_2, int P_3)
		: base(P_2, new int[2], 0, "0")
	{
		_regex = P_0;
		_matchcount = new int[P_1];
		_matches = new int[P_1][];
		_matches[0] = _caps;
		_textend = P_3;
		_balancing = false;
	}

	internal void Reset(string P_0, int P_1)
	{
		base.Text = P_0;
		_textbeg = 0;
		_textend = P_1;
		int[] matchcount = _matchcount;
		for (int i = 0; i < matchcount.Length; i++)
		{
			matchcount[i] = 0;
		}
		_balancing = false;
		_groupcoll?.Reset();
	}

	internal void AddMatch(int P_0, int P_1, int P_2)
	{
		int[][] matches = _matches;
		if (matches[P_0] == null)
		{
			matches[P_0] = new int[2];
		}
		int[][] matches2 = _matches;
		int[] matchcount = _matchcount;
		int num = matchcount[P_0];
		if (num * 2 + 2 > matches2[P_0].Length)
		{
			int[] array = matches2[P_0];
			int[] array2 = new int[num * 8];
			for (int i = 0; i < num * 2; i++)
			{
				array2[i] = array[i];
			}
			matches2[P_0] = array2;
		}
		matches2[P_0][num * 2] = P_1;
		matches2[P_0][num * 2 + 1] = P_2;
		matchcount[P_0] = num + 1;
	}

	internal void Tidy(int P_0, int P_1, RegexRunnerMode P_2)
	{
		int[] matchcount = _matchcount;
		_capcount = matchcount[0];
		_textbeg = P_1;
		_textpos = P_1 + P_0;
		_textend += P_1;
		int[][] matches = _matches;
		int[] array = matches[0];
		base.Length = array[1];
		base.Index = array[0] + P_1;
		if (P_2 != RegexRunnerMode.FullMatchRequired)
		{
			return;
		}
		if (_balancing)
		{
			TidyBalancing();
		}
		if (P_1 == 0)
		{
			return;
		}
		for (int i = 0; i < matches.Length; i++)
		{
			int[] array2 = matches[i];
			if (array2 != null)
			{
				int num = matchcount[i] * 2;
				for (int j = 0; j < num; j += 2)
				{
					array2[j] += P_1;
				}
			}
		}
	}

	private void TidyBalancing()
	{
		int[] matchcount = _matchcount;
		int[][] matches = _matches;
		for (int i = 0; i < matchcount.Length; i++)
		{
			int num = matchcount[i] * 2;
			int[] array = matches[i];
			int j;
			for (j = 0; j < num && array[j] >= 0; j++)
			{
			}
			int num2 = j;
			for (; j < num; j++)
			{
				if (array[j] < 0)
				{
					num2--;
					continue;
				}
				if (j != num2)
				{
					array[num2] = array[j];
				}
				num2++;
			}
			matchcount[i] = num2 / 2;
		}
		_balancing = false;
	}
}
