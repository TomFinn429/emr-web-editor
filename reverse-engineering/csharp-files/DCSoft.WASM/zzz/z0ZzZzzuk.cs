using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace zzz;

[DefaultMember("Item")]
public class z0ZzZzzuk : IEnumerable
{
	private bool z0yek = true;

	private readonly List<string> z0uek = new List<string>();

	public bool z0eek()
	{
		return z0yek;
	}

	public void z0eek(bool p0)
	{
		z0yek = p0;
	}

	public int z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return -1;
		}
		for (int i = 0; i < z0uek.Count; i++)
		{
			if (string.Compare(z0uek[i], p0, z0eek()) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public int z0rek(string p0)
	{
		int num = z0eek(p0);
		if (num >= 0)
		{
			return num;
		}
		z0uek.Add(p0);
		return z0uek.Count - 1;
	}

	public z0ZzZzzuk(string p0, char p1)
	{
		z0eek(p0, p1, '\0', '\0');
	}

	public z0ZzZzzuk(string p0)
	{
		z0eek(p0, ',', '\0', '\0');
	}

	public string z0eek(int p0)
	{
		return z0uek[p0];
	}

	public string z0eek(char p0, char p1, char p2)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < z0uek.Count; i++)
		{
			if (p0 > '\0' && stringBuilder.Length > 0)
			{
				stringBuilder.Append(p0);
			}
			if (p1 > '\0')
			{
				stringBuilder.Append(p1);
			}
			stringBuilder.Append(z0uek[i]);
			if (p2 > '\0')
			{
				stringBuilder.Append(p2);
			}
		}
		return stringBuilder.ToString();
	}

	public List<string> z0rek()
	{
		return z0uek;
	}

	public void z0eek(string p0, char p1, char p2, char p3)
	{
		try
		{
			z0uek.Clear();
			if (string.IsNullOrEmpty(p0))
			{
				return;
			}
			string[] array = p0.Split(p1);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (text.Length > 0)
				{
					if (p2 > '\0' && text[0] == p2)
					{
						text = text.Substring(1);
					}
					if (p3 > '\0' && text.Length > 0 && text[text.Length - 1] == p3)
					{
						text = text.Substring(0, text.Length - 1);
					}
					if (text.Length > 0)
					{
						z0rek(text);
					}
				}
			}
		}
		catch
		{
			z0uek.Clear();
		}
	}

	public IEnumerator GetEnumerator()
	{
		if (z0rek() == null)
		{
			return null;
		}
		return z0rek().GetEnumerator();
	}

	public override string ToString()
	{
		return z0eek(',', '\0', '\0');
	}

	public bool z0tek(string p0)
	{
		return z0eek(p0) >= 0;
	}

	public z0ZzZzzuk()
	{
	}

	public int z0tek()
	{
		return z0uek.Count;
	}
}
