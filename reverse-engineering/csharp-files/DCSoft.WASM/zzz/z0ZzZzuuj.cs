using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzuuj : z0ZzZzauj
{
	private new bool z0oek = true;

	private new static z0ZzZzlsh z0pek;

	private new float z0mek = 100f;

	private new string z0nek;

	private bool z0bek;

	private float z0vek = 100f;

	public new void z0eek(bool p0)
	{
		z0bek = p0;
	}

	internal new static z0ZzZzlsh z0eek()
	{
		if (z0pek == null)
		{
			z0pek = new z0ZzZzlsh();
			z0pek.z0rek(StringAlignment.Center);
			z0pek.z0eek(StringAlignment.Center);
			z0pek.z0eek((z0ZzZzksh)4096);
		}
		return z0pek;
	}

	public override void z0bkk(z0ZzZzbdh p0)
	{
		base.z0bkk(p0);
	}

	public new string z0rek()
	{
		return z0nek;
	}

	public new string z0tek()
	{
		return z0rek();
	}

	public new bool z0yek()
	{
		return z0oek;
	}

	public override z0ZzZzbdh z0vkk()
	{
		return z0ZzZzbdh.z0yek(base.z0vkk(), z0iek());
	}

	public override void z0nkk(z0ZzZztuj p0)
	{
		base.z0nkk(p0);
		z0ZzZzpdh p1 = base.z0tek();
		z0ZzZzcok z0ZzZzcok2 = z0oek();
		z0ZzZzpdh z0ZzZzpdh2 = new z0ZzZzpdh(base.z0eek(), base.z0uek());
		z0ZzZzpdh2.z0eek(z0ZzZzpdh2.z0rek() + p1.z0rek());
		z0ZzZzpdh2.z0rek(z0ZzZzpdh2.z0tek() + p1.z0tek());
		using (z0ZzZzzdh p2 = new z0ZzZzzdh(z0ZzZzcok2.BorderColor))
		{
			float num = (float)z0ZzZzrpk.z0tek(10.0, p0.z0iek().z0vek());
			p0.z0iek().z0eek(SmoothingMode.HighQuality);
			p0.z0iek().z0eek(p2, new z0ZzZzbdh(z0ZzZzpdh2.z0rek() - num / 2f, z0ZzZzpdh2.z0tek() - num / 2f, num, num));
		}
		z0ZzZzimk font = z0ZzZzcok2.Font;
		if (z0jjk().z0nek() && p0.z0rek() > 0f)
		{
			font.Size /= p0.z0rek();
		}
		string text = z0tek();
		if (string.IsNullOrEmpty(text))
		{
			z0ZzZzxdh z0ZzZzxdh2 = p0.z0iek().z0eek("__", font, 10000, z0eek());
			z0vek = z0ZzZzxdh2.z0rek();
			z0mek = z0ZzZzxdh2.z0tek();
		}
		else
		{
			z0ZzZzxdh z0ZzZzxdh3 = p0.z0iek().z0eek(text, font, 10000, z0eek());
			z0vek = z0ZzZzxdh3.z0rek();
			z0mek = z0ZzZzxdh3.z0tek();
		}
		z0ZzZzbdh z0ZzZzbdh2 = z0iek();
		z0ZzZzbdh2.z0tek(p1);
		if (!string.IsNullOrEmpty(text))
		{
			z0ZzZzbdh p3 = z0ZzZzbdh2;
			p3 = z0ZzZzcok2.z0eek(p3);
			if (z0jjk().z0uek().A != 0)
			{
				p0.z0iek().z0rek(z0jjk().z0uek(), p3);
			}
			p0.z0iek().z0eek(text, font, z0ZzZzcok2.Color, p3, z0eek());
		}
		p0.z0iek().z0eek(z0ZzZzcok2.BorderColor, z0ZzZzcok2.BorderWidth, z0ZzZzcok2.BorderStyle, base.z0yek() + p1.z0rek(), base.z0rek() + p1.z0tek(), base.z0yek() + p1.z0rek() + (z0uek() ? (0f - z0vek) : z0vek), base.z0rek() + p1.z0tek());
	}

	public new void z0eek(string p0)
	{
		z0nek = p0;
	}

	public new bool z0uek()
	{
		return z0bek;
	}

	public void z0rek(bool p0)
	{
		z0oek = p0;
	}

	private new z0ZzZzbdh z0iek()
	{
		z0ZzZzbdh result = new z0ZzZzbdh(base.z0yek(), base.z0rek(), z0vek, z0mek);
		if (z0uek())
		{
			result.z0eek(result.z0tek() - result.z0uek());
		}
		if (z0yek())
		{
			result.z0rek(result.z0yek() - result.z0iek());
		}
		return result;
	}
}
