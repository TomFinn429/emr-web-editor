using System.Collections.Generic;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class PageLabelTextList : List<PageLabelText>
{
	private class z0uxk : IComparer<PageLabelText>
	{
		public int Compare(PageLabelText x, PageLabelText y)
		{
			return x.PageIndex.CompareTo(y.PageIndex);
		}
	}

	private PageLabelText z0eek(int p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PageLabelText current = enumerator.Current;
				if (current.PageIndex == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public string z0eek(int p0, bool p1)
	{
		if (p1)
		{
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					PageLabelText current = enumerator.Current;
					if (current.PageIndex == p0)
					{
						return current.Text;
					}
				}
			}
			return null;
		}
		Sort(new z0uxk());
		PageLabelText pageLabelText = null;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PageLabelText current2 = enumerator.Current;
				if (p0 < current2.PageIndex)
				{
					break;
				}
				pageLabelText = current2;
			}
		}
		return pageLabelText?.Text;
	}

	public PageLabelTextList z0eek()
	{
		PageLabelTextList pageLabelTextList = new PageLabelTextList();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			PageLabelText current = enumerator.Current;
			pageLabelTextList.Add(current.z0eek());
		}
		return pageLabelTextList;
	}

	public void SetPageText(int pageIndex, string text)
	{
		PageLabelText pageLabelText = z0eek(pageIndex);
		if (string.IsNullOrEmpty(text))
		{
			if (pageLabelText != null)
			{
				Remove(pageLabelText);
			}
			return;
		}
		if (pageLabelText == null)
		{
			pageLabelText = new PageLabelText();
			pageLabelText.PageIndex = pageIndex;
			Add(pageLabelText);
		}
		pageLabelText.Text = text;
	}
}
