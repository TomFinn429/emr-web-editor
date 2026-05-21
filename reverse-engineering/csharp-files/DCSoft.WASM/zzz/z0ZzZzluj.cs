using System;
using System.IO;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzluj : z0ZzZzxyj
{
	private z0ZzZzzyj z0xek = new z0ZzZzzyj();

	private z0ZzZzouj z0zek = new z0ZzZzouj();

	private bool z0lrk = true;

	private bool z0krk;

	private z0ZzZzimk z0jrk = new z0ZzZzimk();

	private bool z0hrk = true;

	[NonSerialized]
	private float z0grk = 1f;

	private Color z0frk = Color.Transparent;

	public new bool z0eek()
	{
		return z0krk;
	}

	public new z0ZzZzimk z0rek()
	{
		return z0jrk;
	}

	public new bool z0tek()
	{
		if (z0yek() != null)
		{
			return z0yek().Count > 0;
		}
		return false;
	}

	public new void z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			z0eek(Color.Transparent);
		}
		else
		{
			z0eek(z0ZzZzifh.z0eek(p0));
		}
	}

	public override z0ZzZzhuj z0gjk(bool p0)
	{
		z0ZzZzluj obj = (z0ZzZzluj)base.z0gjk(p0);
		obj.z0xek = (z0ZzZzzyj)z0xek.z0eek();
		((z0ZzZzxyj)obj).z0eek();
		return obj;
	}

	public override void z0hjk(z0ZzZzluj p0)
	{
	}

	public void z0eek(z0ZzZzouj p0)
	{
		z0zek = p0;
	}

	public void z0eek(Color p0)
	{
		z0frk = p0;
	}

	public new z0ZzZzguj z0yek()
	{
		return z0djk();
	}

	public override z0ZzZzluj z0jjk()
	{
		return this;
	}

	public override void z0kjk(z0ZzZzxyj p0)
	{
	}

	public new Color z0uek()
	{
		return z0frk;
	}

	public void z0eek(z0ZzZzzyj p0)
	{
		z0xek = p0;
		_ = z0xek;
	}

	public new z0ZzZzouj z0iek()
	{
		if (z0zek == null)
		{
			z0zek = new z0ZzZzouj();
		}
		return z0zek;
	}

	public new void z0eek(float p0)
	{
		z0grk = p0;
	}

	public new string z0oek()
	{
		if (z0uek() == Color.Transparent)
		{
			return null;
		}
		return z0ZzZzifh.z0eek(z0uek());
	}

	public new void z0pek()
	{
		z0ZzZzguj z0ZzZzguj2 = ((z0ZzZzxyj)this).z0eek(p0: true);
		int[] array = new int[z0bek().Styles.Count];
		foreach (z0ZzZzhuj item in z0ZzZzguj2)
		{
			if (item.z0eek() >= 0 && item.z0eek() < array.Length)
			{
				array[item.z0eek()]++;
			}
		}
		z0ZzZzzok styles = z0bek().Styles;
		int count = styles.Count;
		int[] array2 = new int[count];
		foreach (z0ZzZzhuj item2 in z0ZzZzguj2)
		{
			int num = item2.z0eek();
			if (num >= 0 && num < count)
			{
				array2[num]++;
			}
		}
		bool flag = false;
		for (int i = 0; i < count; i++)
		{
			if (array2[i] == 0)
			{
				flag = true;
			}
			else if (styles[i].IsEmpty)
			{
				flag = true;
				array2[i] = 0;
			}
		}
		if (!flag)
		{
			return;
		}
		z0bek().z0nn();
		z0ZzZzcok z0ZzZzcok2 = new z0ZzZzcok();
		z0ZzZzcok2.FontName = "悲剧啊";
		int num2 = 0;
		for (int j = 0; j < count; j++)
		{
			if (array2[j] == 0)
			{
				num2++;
				array2[j] = -1;
				styles[j].Dispose();
				styles[j] = z0ZzZzcok2;
				continue;
			}
			if (styles[j] == z0ZzZzcok2)
			{
				num2++;
				continue;
			}
			z0ZzZzcok z0ZzZzcok3 = styles[j];
			if (z0ZzZzcok3 == z0ZzZzcok2)
			{
				continue;
			}
			array2[j] = j - num2;
			for (int k = j + 1; k < count; k++)
			{
				if (styles[k] != z0ZzZzcok2 && z0ZzZzcok3.z0tek(styles[k]))
				{
					array2[k] = array2[j];
					styles[k].Dispose();
					styles[k] = z0ZzZzcok2;
				}
			}
		}
		foreach (z0ZzZzhuj item3 in z0ZzZzguj2)
		{
			int num3 = item3.z0eek();
			if (num3 >= 0 && num3 < count)
			{
				item3.z0eek(array2[num3]);
			}
			else
			{
				item3.z0eek(-1);
			}
		}
		for (int num4 = styles.Count - 1; num4 >= 0; num4--)
		{
			if (styles[num4] == z0ZzZzcok2)
			{
				styles.RemoveAt(num4);
			}
		}
	}

	public new z0ZzZzjuj z0mek()
	{
		if (z0yek().Count > 0)
		{
			return (z0ZzZzjuj)z0yek()[0];
		}
		return null;
	}

	public new void z0eek(bool p0)
	{
		z0krk = p0;
	}

	public new bool z0nek()
	{
		return z0hrk;
	}

	public void z0rek(bool p0)
	{
		z0hrk = p0;
	}

	public virtual bool z0eek(TextReader p0)
	{
		throw new NotSupportedException();
	}

	public bool z0tek(bool p0)
	{
		if (z0eek() != p0)
		{
			z0eek(p0);
			if (p0)
			{
				foreach (z0ZzZzhuj item in ((z0ZzZzxyj)this).z0eek(p0: false))
				{
					item.z0eek(item.z0oek());
				}
			}
			else
			{
				foreach (z0ZzZzhuj item2 in ((z0ZzZzxyj)this).z0eek(p0: false))
				{
					if (item2.z0pek() != null)
					{
						item2.z0eek(z0bek().GetStyleIndex(item2.z0pek()));
					}
				}
			}
			return true;
		}
		return false;
	}

	public void z0yek(bool p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzzyj z0bek()
	{
		if (z0xek == null)
		{
			z0xek = new z0ZzZzzyj();
		}
		return z0xek;
	}

	public override z0ZzZzxyj z0ljk()
	{
		return null;
	}

	public float z0vek()
	{
		return z0grk;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		if (z0jrk != p0 && p0 != null)
		{
			z0jrk = p0;
			z0xek.Default.Font = p0;
		}
	}

	public bool z0cek()
	{
		return z0lrk;
	}
}
