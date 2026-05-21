using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

public class z0ZzZzrvj
{
	private bool z0uek;

	private static readonly List<z0ZzZzrvj> z0iek = new List<z0ZzZzrvj>();

	private string z0oek;

	private static readonly List<z0ZzZzrvj> z0pek = new List<z0ZzZzrvj>();

	private readonly List<z0ZzZztvj> z0mek = new List<z0ZzZztvj>();

	private Type z0nek;

	public string z0eek()
	{
		return z0oek;
	}

	private z0ZzZzrvj()
	{
	}

	public Type z0rek()
	{
		return z0nek;
	}

	internal List<z0ZzZztvj> z0tek()
	{
		return z0mek;
	}

	private static z0ZzZzrvj z0eek(Type p0, string p1, bool p2)
	{
		z0ZzZzrvj z0ZzZzrvj2 = new z0ZzZzrvj();
		z0ZzZzrvj2.z0nek = p0;
		z0ZzZzrvj2.z0oek = p1;
		if (string.IsNullOrEmpty(p1))
		{
			z0ZzZztvj z0ZzZztvj2 = new z0ZzZztvj();
			z0ZzZztvj2.z0eek((string)null);
			z0ZzZztvj2.z0eek(p0);
			z0ZzZzrvj2.z0mek.Add(z0ZzZztvj2);
		}
		else if (typeof(z0ZzZzoah).IsAssignableFrom(p0))
		{
			z0ZzZztvj z0ZzZztvj3 = new z0ZzZztvj();
			z0ZzZztvj3.z0eek(p1);
			z0ZzZztvj3.z0eek(p0);
			z0ZzZztvj3.z0eek((z0ZzZzwvj)1);
			z0ZzZzrvj2.z0mek.Add(z0ZzZztvj3);
		}
		else if (typeof(IDictionary).IsAssignableFrom(p0))
		{
			z0ZzZztvj z0ZzZztvj4 = new z0ZzZztvj();
			z0ZzZztvj4.z0eek(p1);
			z0ZzZztvj4.z0eek(p0);
			z0ZzZztvj4.z0eek((z0ZzZzwvj)2);
			z0ZzZzrvj2.z0mek.Add(z0ZzZztvj4);
		}
		else
		{
			string[] array = p1.Split('.');
			Type type = z0ZzZzrvj2.z0nek;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (string.IsNullOrEmpty(text))
				{
					z0ZzZztvj z0ZzZztvj5 = new z0ZzZztvj();
					z0ZzZztvj5.z0eek(type);
					z0ZzZztvj5.z0eek((string)null);
					type = typeof(string);
					z0ZzZzrvj2.z0mek.Add(z0ZzZztvj5);
					continue;
				}
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				bool flag = false;
				PropertyInfo[] array2 = properties;
				foreach (PropertyInfo propertyInfo in array2)
				{
					if (string.Compare(propertyInfo.Name, text, true) == 0)
					{
						z0ZzZztvj z0ZzZztvj6 = new z0ZzZztvj();
						z0ZzZztvj6.z0eek(type);
						z0ZzZztvj6.z0eek(propertyInfo);
						z0ZzZztvj6.z0eek(propertyInfo.Name);
						z0ZzZztvj6.z0eek((z0ZzZzwvj)4);
						z0ZzZzrvj2.z0mek.Add(z0ZzZztvj6);
						type = propertyInfo.PropertyType;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					if (p2)
					{
						throw new NotSupportedException(type.FullName + "." + text);
					}
					return null;
				}
			}
		}
		z0ZzZzrvj2.z0uek = false;
		z0ZzZztvj z0ZzZztvj7 = z0ZzZzrvj2.z0mek[z0ZzZzrvj2.z0mek.Count - 1];
		if (z0ZzZztvj7.z0eek() == (z0ZzZzwvj)4)
		{
			if (z0ZzZztvj7.z0rek() == null)
			{
				z0ZzZzrvj2.z0uek = true;
			}
			else
			{
				z0ZzZzrvj2.z0uek = !z0ZzZztvj7.z0rek().CanWrite;
			}
		}
		else if (z0ZzZztvj7.z0eek() == (z0ZzZzwvj)3 || z0ZzZztvj7.z0eek() == (z0ZzZzwvj)2 || z0ZzZztvj7.z0eek() == (z0ZzZzwvj)1)
		{
			z0ZzZzrvj2.z0uek = false;
		}
		else
		{
			z0ZzZzrvj2.z0uek = true;
		}
		return z0ZzZzrvj2;
	}

	public bool z0yek()
	{
		return z0uek;
	}

	public static z0ZzZzrvj z0rek(Type p0, string p1, bool p2)
	{
		if (p0 == null)
		{
			if (p2)
			{
				throw new ArgumentNullException("rootType");
			}
			return null;
		}
		foreach (z0ZzZzrvj item in z0pek)
		{
			if (item.z0rek().Equals(p0) && string.Compare(item.z0eek(), p1, false) == 0)
			{
				return item;
			}
		}
		foreach (z0ZzZzrvj item2 in z0iek)
		{
			if (item2.z0rek() == p0 && item2.z0eek() == p1)
			{
				if (p2)
				{
					throw new ArgumentOutOfRangeException("Type=" + p0.FullName + " Path=" + p1);
				}
				return null;
			}
		}
		z0ZzZzrvj z0ZzZzrvj2 = z0eek(p0, p1, p2);
		if (z0ZzZzrvj2 != null)
		{
			z0pek.Add(z0ZzZzrvj2);
		}
		else
		{
			z0ZzZzrvj z0ZzZzrvj3 = new z0ZzZzrvj();
			z0ZzZzrvj3.z0nek = p0;
			z0ZzZzrvj3.z0oek = p1;
			z0iek.Add(z0ZzZzrvj3);
		}
		return z0ZzZzrvj2;
	}
}
