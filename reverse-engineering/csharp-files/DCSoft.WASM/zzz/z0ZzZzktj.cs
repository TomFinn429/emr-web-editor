using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzlyj))]
public class z0ZzZzktj
{
	private Dictionary<string, string> z0bek = new Dictionary<string, string>();

	private DateTime z0vek_jiejie20260327142557 = DateTime.MinValue;

	private DateTime z0cek = DateTime.MinValue;

	private DateTime z0xek = DateTime.MinValue;

	private DateTime z0zek = DateTime.MinValue;

	public void z0eek(int p0)
	{
		z0bek["edmins"] = p0.ToString();
	}

	public void z0eek(string p0)
	{
		z0bek["author"] = p0;
	}

	public void z0eek(string p0, string p1)
	{
		z0bek[p0] = p1;
	}

	public void z0eek(DateTime p0)
	{
		z0vek_jiejie20260327142557 = p0;
	}

	public void z0rek(DateTime p0)
	{
		z0xek = p0;
	}

	public void z0rek(string p0)
	{
		z0bek["comment"] = p0;
	}

	private string z0tek(string p0)
	{
		string result = null;
		if (z0bek.TryGetValue(p0, out result))
		{
			return result;
		}
		return null;
	}

	public void z0tek(DateTime p0)
	{
		z0zek = p0;
	}

	public void z0eek()
	{
		z0bek.Clear();
		z0zek = DateTime.MinValue;
		z0cek = DateTime.MinValue;
		z0xek = DateTime.MinValue;
		z0vek_jiejie20260327142557 = DateTime.MinValue;
	}

	public string z0rek()
	{
		return z0tek("comment");
	}

	internal string[] z0tek()
	{
		ArrayList arrayList = new ArrayList();
		foreach (string key in z0bek.Keys)
		{
			arrayList.Add(key + "=" + z0bek[key]);
		}
		string text = "yyyy-MM-dd HH:mm:ss";
		if (z0pek() != DateTime.MinValue)
		{
			arrayList.Add("Creatim=" + z0pek().ToString(text));
		}
		if (z0oek() != DateTime.MinValue)
		{
			arrayList.Add("Revtim=" + z0oek().ToString(text));
		}
		if (z0yek() != DateTime.MinValue)
		{
			arrayList.Add("Printim=" + z0yek().ToString(text));
		}
		if (z0iek() != DateTime.MinValue)
		{
			arrayList.Add("Buptim=" + z0iek().ToString(text));
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	public void z0yek(DateTime p0)
	{
		z0cek = p0;
	}

	public DateTime z0yek()
	{
		return z0xek;
	}

	public string z0uek()
	{
		return z0tek("title");
	}

	public DateTime z0iek()
	{
		return z0vek_jiejie20260327142557;
	}

	public void z0yek(string p0)
	{
		z0bek["title"] = p0;
	}

	public DateTime z0oek()
	{
		return z0cek;
	}

	public DateTime z0pek()
	{
		return z0zek;
	}

	public string z0mek()
	{
		return z0tek("author");
	}

	public int z0nek()
	{
		if (z0bek.ContainsKey("edmins"))
		{
			string? text = Convert.ToString(z0bek["edmins"]);
			int result = 0;
			if (int.TryParse(text, out result))
			{
				return result;
			}
		}
		return 0;
	}
}
