using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzfik : IDisposable
{
	private string[] z0rek;

	private string z0tek;

	private Dictionary<int, string> z0yek;

	public z0ZzZzfik(string p0, bool p1 = false)
	{
		z0tek = p0;
		if (p1)
		{
			z0yek = new Dictionary<int, string>();
		}
	}

	public string z0eek(int p0)
	{
		if (z0yek == null)
		{
			if (z0rek == null || z0rek.Length <= p0)
			{
				string[] array = new string[(int)((double)p0 * 1.5 + 10.0)];
				if (z0rek != null)
				{
					Array.Copy(z0rek, array, z0rek.Length);
					Array.Clear(z0rek, 0, z0rek.Length);
				}
				z0rek = array;
			}
			string text = z0rek[p0];
			if (text == null)
			{
				text = z0cwk(p0);
				z0rek[p0] = text;
			}
			return text;
		}
		string text2 = null;
		if (!z0yek.TryGetValue(p0, out text2))
		{
			text2 = z0cwk(p0);
			z0yek[p0] = text2;
		}
		return text2;
	}

	protected virtual string z0cwk(int p0)
	{
		if (string.IsNullOrEmpty(z0tek))
		{
			return p0.ToString();
		}
		return z0tek + p0;
	}

	public void Dispose()
	{
		z0eek();
		z0yek = null;
	}

	public void z0eek()
	{
		if (z0yek != null)
		{
			z0yek.Clear();
		}
		else if (z0rek != null)
		{
			Array.Clear(z0rek, 0, z0rek.Length);
			z0rek = null;
		}
	}
}
