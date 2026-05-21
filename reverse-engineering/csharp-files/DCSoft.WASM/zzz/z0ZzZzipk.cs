using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzipk : List<z0ZzZzupk>
{
	public int z0yek;

	private static readonly z0ZzZzlsh z0uek = z0tek();

	private z0ZzZzupk z0iek;

	public void z0eek(z0ZzZzjpk p0, z0ZzZzndh p1, z0ZzZzsdh p2, float p3, StringAlignment p4)
	{
		if (base.Count == 0)
		{
			return;
		}
		float num = (float)p1.z0mek() + p3;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzupk current = enumerator.Current;
			float num2 = p1.z0iek();
			z0ZzZzsdh z0ZzZzsdh2 = ((current.z0pek == null) ? p2 : current.z0pek);
			if (z0ZzZzsdh2 == null)
			{
				z0ZzZzsdh2 = z0ZzZzimk.z0oek;
			}
			float num3 = p0.z0eek(z0ZzZzsdh2) + 3f;
			string text = current.z0rek();
			if (text != null && text.Length > 0)
			{
				num2 = p0.z0eek(text, z0ZzZzsdh2, 100000, z0uek).z0rek() + 4f;
				if (num2 > (float)p1.z0iek())
				{
					num2 = p1.z0iek();
				}
			}
			float num4 = p1.z0pek();
			current.z0tek = new z0ZzZzbdh(p4 switch
			{
				StringAlignment.Near => p1.z0pek(), 
				StringAlignment.Center => (float)p1.z0pek() + ((float)p1.z0iek() - num2) / 2f, 
				_ => (float)p1.z0nek() - num2, 
			}, num, num2, num3);
			num = num + num3 + p3;
		}
	}

	public void z0eek(z0ZzZzmwh p0, z0ZzZzjpk p1, z0ZzZzbdh p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("g");
		}
		bool flag = false;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzupk current = enumerator.Current;
			if (!current.z0iek)
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh2 = current.z0tek;
			if (!p2.z0bek() && !z0ZzZzbdh2.z0tek(p2))
			{
				continue;
			}
			if (!flag)
			{
				flag = true;
				p1.z0rek();
				p1.z0zek();
				p1.z0eek(GraphicsUnit.Pixel);
			}
			z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzbdh2;
			if (!p2.z0bek())
			{
				z0ZzZzbdh3 = z0ZzZzbdh.z0tek(z0ZzZzbdh3, p2);
			}
			bool num = z0eek() == current;
			if (num)
			{
				p1.z0rek(z0ZzZzyfh.z0iek, z0ZzZzbdh3);
			}
			else if (current.z0nek.A > 0)
			{
				p1.z0rek(z0ZzZzyfh.z0eek(current.z0nek), z0ZzZzbdh3);
			}
			z0ZzZzsdh z0ZzZzsdh2 = ((current.z0pek == null) ? z0ZzZzimk.z0oek : current.z0pek);
			z0ZzZzbdh layoutRectangle = z0ZzZzbdh2;
			layoutRectangle.z0tek(2f, 0f);
			if (num)
			{
				using z0ZzZzsdh font = new z0ZzZzsdh(z0ZzZzsdh2.z0pek(), z0ZzZzsdh2.z0yek(), FontStyle.Underline);
				p1.DrawString(current.z0rek(), font, z0ZzZzyfh.z0krk, layoutRectangle, z0uek);
			}
			else
			{
				p1.DrawString(current.z0rek(), z0ZzZzsdh2, new z0ZzZzzdh(current.z0mek), layoutRectangle, z0uek);
			}
			if (current.z0oek.A > 0)
			{
				using z0ZzZzudh p3 = new z0ZzZzudh(current.z0oek);
				p1.z0eek(p3, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek(), 0f);
			}
		}
	}

	public z0ZzZzupk z0eek()
	{
		return z0iek;
	}

	public void z0rek()
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				enumerator.Current.z0eek();
			}
		}
		Clear();
	}

	private static z0ZzZzlsh z0tek()
	{
		z0ZzZzlsh obj = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		obj.z0eek((z0ZzZzksh)4096);
		obj.z0rek(StringAlignment.Near);
		obj.z0eek(StringAlignment.Center);
		return obj;
	}
}
