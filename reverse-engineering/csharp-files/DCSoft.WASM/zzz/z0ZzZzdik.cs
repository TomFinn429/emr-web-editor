using System;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

public static class z0ZzZzdik
{
	private class z0aok
	{
		public string z0eek;

		public Type z0rek;

		public PropertyInfo z0tek;
	}

	private static readonly List<z0aok> z0rek = new List<z0aok>();

	private static PropertyInfo z0eek(object p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (string.IsNullOrEmpty(p1))
		{
			throw new ArgumentNullException("propertyName");
		}
		p1 = p1.Trim().ToLower();
		Type type = p0.GetType();
		foreach (z0aok item in z0rek)
		{
			if (item.z0rek == type && item.z0eek == p1)
			{
				return item.z0tek;
			}
		}
		PropertyInfo propertyInfo = type.GetProperty(p1, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
		if (propertyInfo != null)
		{
			z0aok z0aok = new z0aok();
			z0aok.z0rek = type;
			z0aok.z0eek = p1;
			ParameterInfo[] indexParameters = propertyInfo.GetIndexParameters();
			if (indexParameters != null && indexParameters.Length != 0)
			{
				propertyInfo = null;
			}
			z0aok.z0tek = propertyInfo;
			z0rek.Add(z0aok);
		}
		return propertyInfo;
	}

	public static bool z0eek(object p0, string p1, object p2, bool p3)
	{
		PropertyInfo propertyInfo = z0eek(p0, p1);
		if (propertyInfo == null)
		{
			if (p3)
			{
				throw new ArgumentOutOfRangeException(p1);
			}
			return false;
		}
		object obj = p2;
		if (p2 != null && !propertyInfo.PropertyType.IsInstanceOfType(obj))
		{
			if (p3)
			{
				obj = Convert.ChangeType(obj, propertyInfo.PropertyType);
			}
			else
			{
				try
				{
					if (propertyInfo.PropertyType.IsEnum)
					{
						obj = ((!(obj is string)) ? Enum.ToObject(propertyInfo.PropertyType, obj) : Enum.Parse(propertyInfo.PropertyType, (string)obj));
					}
					obj = Convert.ChangeType(obj, propertyInfo.PropertyType);
				}
				catch (Exception)
				{
					return false;
				}
			}
		}
		if (p3)
		{
			propertyInfo.SetValue(p0, obj, null);
			return true;
		}
		try
		{
			propertyInfo.SetValue(p0, obj, null);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool z0eek(object p0, string p1, out object p2)
	{
		PropertyInfo propertyInfo = z0eek(p0, p1);
		if (propertyInfo != null && propertyInfo.CanRead)
		{
			try
			{
				p2 = propertyInfo.GetValue(p0, null);
				return true;
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.Message);
				p2 = null;
				return false;
			}
		}
		p2 = null;
		return false;
	}
}
