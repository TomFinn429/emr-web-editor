using System.Collections.Generic;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Data;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class LinkListProviderList : List<LinkListProvider>
{
	public string[] Names
	{
		get
		{
			string[] array = new string[base.Count];
			for (int i = 0; i < base.Count; i++)
			{
				array[i] = base[i].Name;
			}
			return array;
		}
	}

	public bool RemoveByName(string name)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				LinkListProvider current = enumerator.Current;
				if (string.Compare(current.Name, name, true) == 0)
				{
					Remove(current);
					return true;
				}
			}
		}
		return false;
	}

	public LinkListProvider GetEnabledProvider(string name)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				LinkListProvider current = enumerator.Current;
				if (current.Enabled && string.Compare(current.Name, name, true) == 0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public bool ContainsName(string name)
	{
		return GetEnabledProvider(name) != null;
	}
}
