using System;
using System.Collections;

namespace zzz;

public class z0ZzZzdok
{
	private object z0tek;

	public static bool z0eek(object p0, string p1, object p2)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 is IDictionary)
		{
			((IDictionary)p0)[p1] = p2;
			return true;
		}
		if (p0 is z0ZzZzoah)
		{
			z0ZzZzoah z0ZzZzoah2 = z0ZzZzzik.z0eek((z0ZzZzoah)p0, p1, 1);
			if (z0ZzZzoah2 != null)
			{
				if (p2 == null || DBNull.Value.Equals(p2))
				{
					z0ZzZzoah2.z0oh(string.Empty);
				}
				else
				{
					z0ZzZzoah2.z0oh(Convert.ToString(p2));
				}
				return true;
			}
			return false;
		}
		if (p0 is z0ZzZzpah)
		{
			z0ZzZzpah z0ZzZzpah2 = (z0ZzZzpah)p0;
			if (z0ZzZzpah2.z0sf() > 0)
			{
				z0ZzZzoah z0ZzZzoah3 = z0ZzZzzik.z0eek(z0ZzZzpah2.z0eek(0), p1, 1);
				if (z0ZzZzoah3 == null)
				{
					return false;
				}
				if (p2 == null || DBNull.Value.Equals(p2))
				{
					z0ZzZzoah3.z0oh(string.Empty);
				}
				else
				{
					z0ZzZzoah3.z0oh(Convert.ToString(p2));
				}
				return true;
			}
		}
		if (p0.GetType().IsArray)
		{
			Array array = (Array)p0;
			if (array.GetLength(0) == 0)
			{
				return false;
			}
			return z0eek(array.GetValue(0), p1, p2);
		}
		throw new NotSupportedException("WriteValue:" + p0.GetType().FullName);
	}

	public z0ZzZzdok(object p0)
	{
		z0tek = p0;
	}

	public z0ZzZzdok()
	{
	}

	public object z0eek()
	{
		return z0tek;
	}

	public static z0ZzZzdok z0eek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is z0ZzZzdok)
		{
			return (z0ZzZzdok)p0;
		}
		return new z0ZzZzdok(p0);
	}

	public void z0rek(object p0)
	{
		z0tek = p0;
	}

	public static object z0eek(object p0, string p1)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is IDictionary)
		{
			IDictionary dictionary = (IDictionary)p0;
			if (dictionary.Contains(p1))
			{
				return dictionary[p1];
			}
			return null;
		}
		if (p0 is z0ZzZzoah)
		{
			return ((z0ZzZzoah)p0).z0eek(p1)?.z0rh();
		}
		if (p0 is z0ZzZzpah)
		{
			z0ZzZzpah z0ZzZzpah2 = (z0ZzZzpah)p0;
			if (z0ZzZzpah2.z0sf() > 0)
			{
				return z0ZzZzpah2.z0eek(0).z0eek(p1)?.z0rh();
			}
		}
		if (p0.GetType().IsArray)
		{
			Array array = (Array)p0;
			if (array.GetLength(0) == 0)
			{
				return null;
			}
			return z0eek(array.GetValue(0), p1);
		}
		throw new NotSupportedException("ReadValue:" + p0.GetType().FullName);
	}

	public object z0eek(string p0)
	{
		return z0eek(z0tek, p0);
	}
}
