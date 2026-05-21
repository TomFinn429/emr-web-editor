using System;

namespace zzz;

public static class z0ZzZzwnj
{
	public static Type GetControlType(string typeName, Type specifyBaseType)
	{
		Type typeByName = z0ZzZznok.GetTypeByName(typeName);
		if (typeByName != null && specifyBaseType != null && !specifyBaseType.IsAssignableFrom(typeByName))
		{
			return null;
		}
		return typeByName;
	}

	public static string z0eek(Type p0)
	{
		return z0ZzZznok.GetTypeFullName(p0);
	}
}
