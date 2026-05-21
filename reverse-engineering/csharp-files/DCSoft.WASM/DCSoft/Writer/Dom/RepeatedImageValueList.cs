using System;
using System.Collections.Generic;
using zzz;

namespace DCSoft.Writer.Dom;

public class RepeatedImageValueList : List<RepeatedImageValue>, IDisposable
{
	internal static bool z0rek;

	[z0ZzZztqh]
	public int ItemCount => base.Count;

	public void Dispose()
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.Dispose();
			}
		}
		Clear();
	}

	public RepeatedImageValue GetByValueIndex(int index)
	{
		if (index < 0)
		{
			return null;
		}
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RepeatedImageValue current = enumerator.Current;
				if (current.ValueIndex == index)
				{
					return current;
				}
			}
		}
		return null;
	}

	private int z0eek(z0ZzZzpmk p0)
	{
		if (p0 == null || !p0.HasContent)
		{
			return -1;
		}
		for (int i = 0; i < base.Count; i++)
		{
			if (base[i].z0eek(p0))
			{
				return base[i].ValueIndex;
			}
		}
		RepeatedImageValue repeatedImageValue = new RepeatedImageValue(p0);
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RepeatedImageValue current = enumerator.Current;
				repeatedImageValue.ValueIndex = Math.Max(repeatedImageValue.ValueIndex, current.ValueIndex + 1);
			}
		}
		Add(repeatedImageValue);
		return repeatedImageValue.ValueIndex;
	}

	public void z0eek(XTextDocument p0)
	{
		if (!z0rek)
		{
			return;
		}
		XTextElementList xTextElementList = p0.z0nek<XTextImageElement>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextImageElement xTextImageElement = (XTextImageElement)z0bpk.Current;
				if (xTextImageElement.z0mrk() && xTextImageElement.z0frk() != null && xTextImageElement.z0frk().HasContent)
				{
					xTextImageElement.z0rek(z0eek(xTextImageElement.z0frk()));
					xTextImageElement.z0rek((z0ZzZzpmk)null);
				}
			}
		}
		foreach (RepeatedImageValue item in p0.z0nmk())
		{
			item.ReferenceCount = 0;
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextImageElement xTextImageElement2 = (XTextImageElement)z0bpk.Current;
				if (xTextImageElement2.z0mrk() && xTextImageElement2.z0cek() == item.ValueIndex)
				{
					item.ReferenceCount++;
				}
			}
		}
		for (int num = p0.z0nmk().Count - 1; num >= 0; num--)
		{
			RepeatedImageValue repeatedImageValue = p0.z0nmk()[num];
			if (repeatedImageValue.ReferenceCount == 0)
			{
				p0.z0nmk().RemoveAt(num);
				repeatedImageValue.Dispose();
			}
		}
	}

	public RepeatedImageValueList z0eek()
	{
		RepeatedImageValueList repeatedImageValueList = new RepeatedImageValueList();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			RepeatedImageValue current = enumerator.Current;
			repeatedImageValueList.Add((RepeatedImageValue)current.Clone());
		}
		return repeatedImageValueList;
	}
}
