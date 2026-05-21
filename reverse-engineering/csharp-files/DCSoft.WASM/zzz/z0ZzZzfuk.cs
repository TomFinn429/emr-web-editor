using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace zzz;

public sealed class z0ZzZzfuk
{
	private readonly object z0uek;

	private readonly bool z0iek;

	private readonly string z0oek;

	private readonly PropertyInfo z0pek;

	private static Dictionary<Type, Dictionary<string, z0ZzZzfuk>> z0mek = new Dictionary<Type, Dictionary<string, z0ZzZzfuk>>();

	private readonly bool z0nek;

	private readonly string z0bek;

	private readonly Type z0vek_jiejie20260327142557;

	private readonly bool z0cek;

	private readonly bool z0xek;

	public bool z0eek()
	{
		return z0iek;
	}

	public object z0eek(object p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		return z0pek.GetValue(p0, null);
	}

	public string z0rek()
	{
		return z0bek;
	}

	public bool z0tek()
	{
		return z0cek;
	}

	public static z0ZzZzfuk z0eek(Type p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		if (string.IsNullOrEmpty(p1))
		{
			throw new ArgumentNullException("name");
		}
		p1 = p1.Trim().ToLower();
		Dictionary<string, z0ZzZzfuk> dictionary = z0eek(p0);
		z0ZzZzfuk result = null;
		if (dictionary.TryGetValue(p1, out result))
		{
			return result;
		}
		return null;
	}

	private z0ZzZzfuk(PropertyInfo p0)
	{
		z0bek = p0.Name;
		z0oek = p0.Name.ToLower();
		z0pek = p0;
		z0nek = p0.CanRead;
		z0xek = p0.CanWrite;
		DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)Attribute.GetCustomAttribute(p0, typeof(DefaultValueAttribute), true);
		if (defaultValueAttribute == null)
		{
			z0cek = false;
		}
		else
		{
			z0cek = true;
			z0uek = defaultValueAttribute.Value;
		}
		z0iek = p0.PropertyType.IsEnum;
		z0vek_jiejie20260327142557 = p0.PropertyType;
	}

	public static Dictionary<string, z0ZzZzfuk> z0eek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		Dictionary<string, z0ZzZzfuk> dictionary = null;
		if (!z0mek.TryGetValue(p0, out dictionary))
		{
			dictionary = new Dictionary<string, z0ZzZzfuk>();
			z0mek[p0] = dictionary;
			PropertyInfo[] properties = p0.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!propertyInfo.IsSpecialName)
				{
					dictionary[propertyInfo.Name.ToLower()] = new z0ZzZzfuk(propertyInfo);
				}
			}
		}
		return dictionary;
	}

	public object z0yek()
	{
		return z0uek;
	}
}
