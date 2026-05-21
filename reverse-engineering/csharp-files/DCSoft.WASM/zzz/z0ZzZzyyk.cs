using System;
using System.Collections;
using System.IO;
using System.Text;

namespace zzz;

public sealed class z0ZzZzyyk
{
	private readonly z0ZzZzkeh z0vek;

	public z0ZzZzyyk(z0ZzZzkeh p0)
	{
		z0vek = p0;
	}

	public string z0eek()
	{
		if (z0vek == null)
		{
			return null;
		}
		string text = z0vek.z0fj(z0ZzZzvwh.z0eek) as string;
		if (text == null)
		{
			text = z0vek.z0fj(z0ZzZzvwh.z0iek) as string;
		}
		return text;
	}

	public string z0rek()
	{
		string[] array = z0pek();
		if (array != null && array.Length != 0)
		{
			return array[0];
		}
		return null;
	}

	public bool z0tek()
	{
		if (z0vek == null)
		{
			return false;
		}
		return z0vek.z0jj(z0ZzZzvwh.z0yek);
	}

	public void z0eek(z0ZzZzedh p0)
	{
		if (z0vek != null)
		{
			z0vek.z0gj(z0ZzZzvwh.z0rek, p0);
		}
	}

	public string z0yek()
	{
		if (z0vek == null)
		{
			return null;
		}
		try
		{
			object obj = z0vek.z0fj("Html Format");
			byte[] array = null;
			if (obj is MemoryStream)
			{
				array = ((MemoryStream)obj).ToArray();
			}
			else
			{
				obj = z0vek.z0fj("text/html");
				if (obj is MemoryStream)
				{
					array = ((MemoryStream)obj).ToArray();
				}
			}
			if (array != null && array.Length != 0)
			{
				return Encoding.UTF8.GetString(array);
			}
		}
		catch (Exception)
		{
		}
		return z0vek.z0fj(z0ZzZzvwh.z0uek) as string;
	}

	public bool z0uek()
	{
		if (z0vek == null)
		{
			return false;
		}
		if (!z0vek.z0jj(z0ZzZzvwh.z0eek))
		{
			return z0vek.z0jj(z0ZzZzvwh.z0iek);
		}
		return true;
	}

	public z0ZzZzedh z0iek()
	{
		if (z0vek == null)
		{
			return null;
		}
		object obj = null;
		if (z0vek.z0jj(z0ZzZzvwh.z0rek))
		{
			obj = z0vek.z0fj(z0ZzZzvwh.z0rek);
		}
		else if (z0vek.z0jj("PNG"))
		{
			obj = z0vek.z0fj("PNG");
		}
		else if (z0vek.z0jj("GIF"))
		{
			obj = z0vek.z0fj("GIF");
		}
		if (obj is Stream)
		{
			return z0ZzZzedh.z0eek((Stream)obj);
		}
		if (obj is z0ZzZzedh)
		{
			return (z0ZzZzedh)obj;
		}
		return null;
	}

	public bool z0oek()
	{
		if (z0vek == null)
		{
			return false;
		}
		return z0vek.z0jj(z0ZzZzvwh.z0uek);
	}

	public string[] z0pek()
	{
		if (z0vek == null)
		{
			return null;
		}
		object obj = null;
		if (z0vek.z0jj(z0ZzZzvwh.z0tek))
		{
			obj = z0vek.z0fj(z0ZzZzvwh.z0tek);
		}
		else if (z0vek.z0jj("FileNameW"))
		{
			obj = z0vek.z0fj("FileNameW");
		}
		if (obj is IEnumerable enumerable)
		{
			ArrayList arrayList = new ArrayList();
			foreach (string item in enumerable)
			{
				if (item != null && item.Length > 0)
				{
					arrayList.Add(item);
				}
			}
			if (arrayList.Count > 0)
			{
				return (string[])arrayList.ToArray(typeof(string));
			}
		}
		return null;
	}

	public string z0mek()
	{
		if (z0vek == null)
		{
			return null;
		}
		return z0vek.z0fj(z0ZzZzvwh.z0yek) as string;
	}

	public void z0eek(string p0)
	{
		if (z0vek == null)
		{
			z0vek.z0gj(z0ZzZzvwh.z0yek, p0);
		}
	}

	public z0ZzZzyyk(z0ZzZzleh p0)
	{
		z0vek = p0.z0uek();
	}

	public bool z0nek()
	{
		if (z0vek == null)
		{
			return false;
		}
		if (z0vek.z0jj(z0ZzZzvwh.z0rek))
		{
			return true;
		}
		if (z0vek.z0jj("PNG"))
		{
			return true;
		}
		if (z0vek.z0jj("GIF"))
		{
			return true;
		}
		return false;
	}

	public bool z0rek(string p0)
	{
		if (z0vek != null)
		{
			string[] array = z0vek.z0kj();
			if (array != null && array.Length != 0)
			{
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i] == p0)
					{
						return true;
					}
				}
				array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i].EndsWith(p0))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool z0bek()
	{
		if (z0vek == null)
		{
			return false;
		}
		if (z0vek.z0jj(z0ZzZzvwh.z0tek))
		{
			return true;
		}
		return z0vek.z0jj("FileNameW");
	}

	public void z0tek(string p0)
	{
		if (z0vek == null)
		{
			z0vek.z0gj(z0ZzZzvwh.z0uek, p0);
		}
	}

	public void z0yek(string p0)
	{
		if (z0vek == null)
		{
			z0vek.z0gj(z0ZzZzvwh.z0eek, p0);
		}
	}
}
