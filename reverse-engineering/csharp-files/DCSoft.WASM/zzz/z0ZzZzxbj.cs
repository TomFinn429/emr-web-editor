using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzxbj
{
	private static Dictionary<string, z0ZzZzdvj> z0tek = new Dictionary<string, z0ZzZzdvj>();

	private Dictionary<string, z0ZzZzdvj> z0yek = new Dictionary<string, z0ZzZzdvj>();

	public void z0eek()
	{
		if (z0yek == null)
		{
			return;
		}
		foreach (z0ZzZzdvj value in z0yek.Values)
		{
			value.Clear();
		}
		z0yek = null;
	}

	private void z0rek()
	{
		if (z0yek == null)
		{
			z0yek = new Dictionary<string, z0ZzZzdvj>();
		}
		if (z0tek == null)
		{
			z0tek = new Dictionary<string, z0ZzZzdvj>();
		}
	}

	public string[] GetItemsName()
	{
		z0rek();
		List<string> list = new List<string>();
		list.AddRange(z0tek.Keys);
		list.AddRange(z0yek.Keys);
		return list.ToArray();
	}

	public void AddItems(string name, z0ZzZzdvj items, bool globalItems)
	{
		z0rek();
		if (string.IsNullOrEmpty(name))
		{
			name = string.Empty;
		}
		if (globalItems)
		{
			z0tek[name] = items;
		}
		else
		{
			z0yek[name] = items;
		}
	}

	public z0ZzZzdvj GetItems(string name)
	{
		try
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			if (z0tek != null && z0tek.ContainsKey(name))
			{
				return z0tek[name];
			}
			if (z0yek != null && z0yek.ContainsKey(name))
			{
				return z0yek[name];
			}
			return null;
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
			return null;
		}
	}
}
