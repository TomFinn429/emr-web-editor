using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace zzz;

public class z0ZzZzspk
{
	private static Dictionary<Type, FieldInfo> z0rek = new Dictionary<Type, FieldInfo>();

	public static int z0eek(object p0)
	{
		if (p0 == null)
		{
			return 1;
		}
		Type type = p0.GetType();
		if (z0rek.ContainsKey(type))
		{
			if (z0rek[type] == null)
			{
				return 1;
			}
			return (int)z0rek[type].GetValue(p0);
		}
		string text = "3Ozp6sT45v/xxfnk8e3z9PI=";
		byte[] array = Convert.FromBase64String(text);
		for (int i = 0; i < 17; i++)
		{
			array[i] = (byte)(array[i] ^ (140 + i));
		}
		text = Encoding.UTF8.GetString(array);
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.FieldType.Name == text)
			{
				z0rek[type] = fieldInfo;
				return (int)fieldInfo.GetValue(p0);
			}
		}
		z0rek[type] = null;
		return 1;
	}
}
