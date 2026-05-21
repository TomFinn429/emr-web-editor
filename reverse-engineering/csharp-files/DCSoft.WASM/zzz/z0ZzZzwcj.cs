using System;
using System.Collections.Generic;
using System.Diagnostics;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzwcj : List<DocumentComment>, IDisposable
{
	private class z0spk : IComparer<DocumentComment>
	{
		public int Compare(DocumentComment x, DocumentComment y)
		{
			int num = ((x.z0vrk() != null) ? x.z0vrk().z0jrk() : 0);
			int num2 = ((y.z0vrk() != null) ? y.z0vrk().z0jrk() : 0);
			return num - num2;
		}
	}

	internal bool z0eek()
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.z0oek())
				{
					return true;
				}
			}
		}
		return false;
	}

	public DocumentComment z0eek(int p0)
	{
		if (p0 < 0)
		{
			return null;
		}
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DocumentComment current = enumerator.Current;
				if (current.z0tek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public void z0rek()
	{
		if (base.Count >= 2)
		{
			Sort(new z0spk());
		}
	}

	public z0ZzZzwcj z0eek(bool p0)
	{
		z0ZzZzwcj z0ZzZzwcj2 = new z0ZzZzwcj();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DocumentComment current = enumerator.Current;
			if (p0)
			{
				z0ZzZzwcj2.Add(current.z0yek());
			}
			else
			{
				z0ZzZzwcj2.Add(current);
			}
		}
		return z0ZzZzwcj2;
	}

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

	public int z0tek()
	{
		int num = 0;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			num = Math.Max(enumerator.Current.z0tek(), num);
		}
		return num;
	}

	internal void z0yek()
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DocumentComment current = enumerator.Current;
				current.z0eek((XTextElement)null);
				if (current.z0trk() != null)
				{
					current.z0trk().Clear();
					current.z0eek((XTextElementList)null);
				}
				current.z0pek(null);
				current.z0nek(null);
				current.z0eek((XAttributeList)null);
				current.z0eek((string)null);
				current.z0rek((string)null);
				current.z0tek((XTextDocument)null);
				if (current.z0xek() is z0ZzZztlh)
				{
					((z0ZzZztlh)current.z0xek()).z0bek();
				}
				current.z0eek((object)null);
			}
		}
		Clear();
	}

	public z0ZzZzwcj z0uek()
	{
		z0ZzZzwcj obj = new z0ZzZzwcj();
		obj.AddRange(this);
		return obj;
	}

	internal void z0iek()
	{
		int num = z0tek() + 1;
		List<int> list = new List<int>();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DocumentComment current = enumerator.Current;
			if (list.Contains(current.z0tek()))
			{
				current.z0eek(num++);
			}
			else
			{
				list.Add(current.z0tek());
			}
		}
	}
}
