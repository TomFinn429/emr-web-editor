using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzylh : List<z0ZzZztlh>
{
	private class z0cnk : IComparer<z0ZzZztlh>
	{
		public int Compare(z0ZzZztlh x, z0ZzZztlh y)
		{
			if (x.z0yek() != null && y.z0yek() != null)
			{
				return z0ZzZzafh.z0uek(x.z0yek(), y.z0yek());
			}
			return 0;
		}
	}

	public void z0eek()
	{
		Sort(new z0cnk());
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 1;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZztlh current = enumerator.Current;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(Environment.NewLine);
				}
				stringBuilder.Append(Convert.ToString(num) + ".");
				num++;
				stringBuilder.Append(current.z0uek());
			}
		}
		return stringBuilder.ToString();
	}
}
