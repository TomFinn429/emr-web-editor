using System;
using System.Collections.Generic;

namespace zzz;

public abstract class z0ZzZzpyk : IDisposable
{
	private static readonly List<z0ZzZzpyk> z0yek = new List<z0ZzZzpyk>();

	private static z0ZzZzpyk z0uek = null;

	public virtual string z0eek()
	{
		return "DCSoft.VritualProvider";
	}

	public virtual bool z0eek(z0ZzZzoyk p0)
	{
		byte[] array = p0.z0oek();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)(array[i] + i + 1);
		}
		byte[] array2 = z0ZzZzeyk.z0eek(array);
		p0.SetAttribute("DCVPContentMD5", Convert.ToBase64String(array2));
		return true;
	}

	public virtual bool z0rek()
	{
		return true;
	}

	public static z0ZzZzpyk z0eek(string p0)
	{
		if (z0yek != null && z0yek.Count > 0)
		{
			foreach (z0ZzZzpyk item in z0yek)
			{
				if (item.z0eek() == p0)
				{
					return item;
				}
			}
		}
		return z0uek;
	}

	public static void z0eek(z0ZzZzpyk p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("provider");
		}
		bool flag = false;
		foreach (z0ZzZzpyk item in z0yek)
		{
			if (item.GetType() == p0.GetType())
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			z0yek.Add(p0);
		}
	}

	public static z0ZzZzpyk z0tek()
	{
		if (z0uek == null && z0yek.Count > 0)
		{
			return z0yek[0];
		}
		return z0uek;
	}

	public virtual bool z0rek(z0ZzZzoyk p0)
	{
		if (p0.InputContent != null)
		{
			byte[] array = p0.z0oek();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				array[i] = (byte)(array[i] + i + 1);
			}
			string text = Convert.ToBase64String(z0ZzZzeyk.z0eek(array));
			string attribute = p0.GetAttribute("DCVPContentMD5");
			if (text == attribute)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Dispose()
	{
	}

	public static void z0rek(z0ZzZzpyk p0)
	{
		z0uek = p0;
	}
}
