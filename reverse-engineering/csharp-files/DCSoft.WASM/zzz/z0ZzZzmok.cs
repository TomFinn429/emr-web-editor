using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzmok : IComparer<Type>
{
	public static string z0eek(Type p0)
	{
		if (p0.IsNested)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(p0.Name);
			Type declaringType = p0.DeclaringType;
			while (declaringType != null)
			{
				stringBuilder.Insert(0, declaringType.Name + ".");
				declaringType = declaringType.DeclaringType;
			}
			return stringBuilder.ToString();
		}
		return p0.Name;
	}

	public int Compare(Type x, Type y)
	{
		return string.Compare(z0eek(x), z0eek(y), true);
	}
}
