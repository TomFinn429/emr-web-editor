using System;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
internal class z0ZzZzevk : IDisposable
{
	private int z0oek = -1;

	protected z0ZzZzhbk z0pek;

	public static readonly string[] z0mek;

	public static readonly string[] z0nek;

	private z0ZzZzink z0bek = new z0ZzZzink();

	public static readonly z0ZzZzevk z0vek;

	public static readonly string[] z0cek;

	public string z0eek()
	{
		return z0eek("width");
	}

	public void z0eek(z0ZzZzevk p0, bool p1)
	{
		if (p0 == null || p0 == this || p0.z0bek.Count == 0)
		{
			return;
		}
		int count = z0bek.Count;
		if (count == 0)
		{
			p0.z0bek.z0nek(z0bek);
			return;
		}
		foreach (z0ZzZzunk item in p0.z0iek().z0xrk())
		{
			int num = z0bek.z0eek(item.z0rek(), count);
			if (num < 0)
			{
				z0bek.Add(item);
			}
			else if (p1)
			{
				z0bek[num] = item;
			}
		}
	}

	public bool z0eek(string p0, out string p1)
	{
		if (z0bek != null && z0bek.Count > 0)
		{
			for (int num = z0bek.Count - 1; num >= 0; num--)
			{
				if (z0bek[num].z0rek() == p0)
				{
					string text = z0bek[num].z0yek();
					if (text == null || text.Length <= 0)
					{
						break;
					}
					p1 = text;
					return true;
				}
			}
		}
		p1 = null;
		return false;
	}

	public void z0eek(string p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			z0bek.z0rek(p0);
			return;
		}
		for (int num = z0bek.Count - 1; num >= 0; num--)
		{
			if (z0bek[num].z0rek() == p0)
			{
				z0bek[num] = new z0ZzZzunk(p0, p1);
				return;
			}
		}
		z0bek.Add(new z0ZzZzunk(p0, p1));
	}

	public z0ZzZzhbk z0rek()
	{
		return z0pek;
	}

	static z0ZzZzevk()
	{
		z0nek = new string[11]
		{
			"font", "font-family", "font-size", "font-style", "font-variant", "font-weight", "color", "text-decoration", "text-decoration-color", "text-decoration-style",
			"text-align"
		};
		z0mek = new string[12]
		{
			"logicdeleted", "font", "font-family", "font-size", "font-style", "font-variant", "font-weight", "color", "text-decoration", "text-decoration-color",
			"text-decoration-style", "text-align"
		};
		z0cek = new string[4] { "text-decoration", "text-decoration-color", "text-decoration-style", "text-align" };
		z0vek = new z0ZzZzevk();
		Array.Sort(z0nek);
		Array.Sort(z0mek);
		Array.Sort(z0cek);
	}

	public string z0eek(string p0)
	{
		return z0iek().z0uek(p0);
	}

	public bool z0rek(string p0)
	{
		return z0iek().z0yek(p0);
	}

	public void z0eek(z0ZzZzhbk p0)
	{
		z0pek = p0;
	}

	public void z0eek(z0ZzZzevk p0, bool p1, string[] p2, bool[] p3)
	{
		if (p0 == null || p0 == this || p0.z0bek == null || p0.z0bek.Count == 0 || (p2 == z0nek && !p0.z0tek_jiejie20260327142557()))
		{
			return;
		}
		if (p2 == null || p2.Length == 0)
		{
			if (z0bek.Count == 0)
			{
				z0bek.z0tek(p0.z0bek);
				return;
			}
			int count = z0bek.Count;
			for (int num = p0.z0bek.Count - 1; num >= 0; num--)
			{
				z0ZzZzunk z0ZzZzunk2 = p0.z0bek[num];
				int num2 = z0bek.z0eek(z0ZzZzunk2.z0eek(), count);
				if (num2 < 0)
				{
					z0bek.Add(z0ZzZzunk2);
				}
				else if (p1)
				{
					z0bek[num2] = z0ZzZzunk2;
				}
			}
			return;
		}
		int count2 = z0bek.Count;
		Array.Clear(p3, 0, p2.Length);
		for (int num3 = p0.z0bek.Count - 1; num3 >= 0; num3--)
		{
			z0ZzZzunk z0ZzZzunk3 = p0.z0bek[num3];
			string text = z0ZzZzunk3.z0mek;
			for (int num4 = p2.Length - 1; num4 >= 0; num4--)
			{
				if (!p3[num4] && p2[num4] == text)
				{
					p3[num4] = true;
					if (count2 == 0)
					{
						z0bek.Add(z0ZzZzunk3);
						break;
					}
					int num5 = z0bek.z0eek(text, count2);
					if (num5 < 0)
					{
						z0bek.Add(z0ZzZzunk3);
					}
					else if (p1)
					{
						z0bek.z0ark(num5, z0ZzZzunk3);
					}
					break;
				}
			}
		}
	}

	public void z0tek_jiejie20260327142557(string p0)
	{
		z0eek(p0, (z0ZzZznvk)null);
	}

	public bool z0tek_jiejie20260327142557()
	{
		if (z0oek == -1)
		{
			z0oek = 0;
			for (int num = z0bek.Count - 1; num >= 0; num--)
			{
				string text = z0bek[num].z0rek();
				for (int num2 = z0nek.Length - 1; num2 >= 0; num2--)
				{
					if (z0nek[num2] == text)
					{
						z0oek = 1;
						return true;
					}
				}
			}
		}
		return z0oek > 0;
	}

	public virtual void Dispose()
	{
		if (z0bek != null)
		{
			z0bek.Dispose();
			z0bek = null;
		}
		z0pek = null;
	}

	public z0ZzZzevk z0yek()
	{
		return new z0ZzZzevk
		{
			z0bek = (z0ZzZzink)z0bek.z0htk(),
			z0pek = z0pek,
			z0oek = z0oek
		};
	}

	public string z0yek(string p0)
	{
		return z0eek(p0);
	}

	public string z0uek(string p0)
	{
		return z0iek().z0tek(p0);
	}

	public string z0uek()
	{
		return z0eek("height");
	}

	internal void z0eek(string p0, z0ZzZznvk p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return;
		}
		z0bek.Clear();
		string[] array = z0ZzZzqik.z0eek(p0, ':', ';', p3: false);
		int num = array.Length;
		if (z0ZzZzkbk.z0vek)
		{
			for (int i = 0; i < num; i += 2)
			{
				if (p1 == null)
				{
					string text = array[i].Trim().ToLower();
					z0bek.Add(new z0ZzZzunk(text, text, array[i + 1].Trim()));
				}
				else
				{
					string p2 = p1.z0uek(array[i].Trim().ToLower());
					string p3 = p1.z0uek(array[i + 1].Trim());
					z0bek.Add(p1.z0eek(p2, p3));
				}
			}
		}
		else
		{
			for (int j = 0; j < num; j += 2)
			{
				if (p1 == null)
				{
					z0bek.z0eek(array[j].Trim().ToLower(), array[j + 1].Trim());
				}
				else
				{
					z0bek.z0eek(p1.z0uek(array[j].Trim().ToLower()), p1.z0uek(array[j + 1].Trim()));
				}
			}
		}
		z0ZzZzink.z0pek = true;
	}

	public void z0iek(string p0)
	{
		z0iek().z0rek(p0);
	}

	public z0ZzZzink z0iek()
	{
		return z0bek;
	}
}
