using System.Collections.Generic;
using System.Text;
using zzz;

namespace DCSoft.Writer.Dom;

public class SpecifyPageIndexInfoList : List<SpecifyPageIndexInfo>, z0ZzZzcuk
{
	private class z0ack : IComparer<SpecifyPageIndexInfo>
	{
		public int Compare(SpecifyPageIndexInfo x, SpecifyPageIndexInfo y)
		{
			return x.RawPageIndex - y.RawPageIndex;
		}
	}

	public SpecifyPageIndexInfoList z0eek()
	{
		SpecifyPageIndexInfoList specifyPageIndexInfoList = new SpecifyPageIndexInfoList();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			SpecifyPageIndexInfo current = enumerator.Current;
			specifyPageIndexInfoList.Add(current.z0eek());
		}
		return specifyPageIndexInfoList;
	}

	public void z0rek()
	{
		Sort(new z0ack());
	}

	public void DCReadString(string text)
	{
		Clear();
		if (text == null)
		{
			return;
		}
		string[] array = text.Split(';');
		foreach (string text2 in array)
		{
			int num = text2.IndexOf('=');
			if (num <= 0)
			{
				continue;
			}
			int rawPageIndex = 0;
			if (int.TryParse(text2.Substring(0, num), out rawPageIndex))
			{
				int specifyPageIndex = 0;
				if (int.TryParse(text2.Substring(num + 1), out specifyPageIndex))
				{
					SpecifyPageIndexInfo specifyPageIndexInfo = new SpecifyPageIndexInfo();
					specifyPageIndexInfo.RawPageIndex = rawPageIndex;
					specifyPageIndexInfo.SpecifyPageIndex = specifyPageIndex;
					Add(specifyPageIndexInfo);
				}
			}
		}
	}

	public void SetValue(int pageIndex, int specifyPageIndex)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				SpecifyPageIndexInfo current = enumerator.Current;
				if (current.RawPageIndex == pageIndex)
				{
					current.SpecifyPageIndex = specifyPageIndex;
					return;
				}
			}
		}
		SpecifyPageIndexInfo specifyPageIndexInfo = new SpecifyPageIndexInfo();
		specifyPageIndexInfo.RawPageIndex = pageIndex;
		specifyPageIndexInfo.SpecifyPageIndex = specifyPageIndex;
		Add(specifyPageIndexInfo);
	}

	public string DCWriteString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				SpecifyPageIndexInfo current = enumerator.Current;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(current.RawPageIndex + 61 + current.SpecifyPageIndex);
			}
		}
		return stringBuilder.ToString();
	}
}
