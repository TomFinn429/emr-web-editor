namespace zzz;

public class z0ZzZzeuj : z0ZzZzhuj
{
	private new float z0nek;

	private float z0bek = 100f;

	private bool z0vek = true;

	private string z0cek;

	private float z0xek = 100f;

	private float z0zek;

	public new float z0eek()
	{
		return z0xek;
	}

	public void z0eek(float p0)
	{
		z0xek = p0;
	}

	public void z0rek(float p0)
	{
		z0nek = p0;
	}

	public float z0rek()
	{
		return z0zek;
	}

	public override z0ZzZznfh z0ckk()
	{
		z0ZzZznfh obj = new z0ZzZznfh();
		z0ZzZzpdh z0ZzZzpdh2 = z0nek();
		obj.z0eek(new z0ZzZzbdh(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek(), z0mek(), z0eek()));
		return obj;
	}

	public new void z0eek(string p0)
	{
		z0cek = p0;
	}

	public virtual bool z0xkk()
	{
		return z0vek;
	}

	public z0ZzZzbdh z0tek()
	{
		z0ZzZzcok z0ZzZzcok2 = ((z0ZzZzhuj)this).z0oek();
		return new z0ZzZzbdh(z0ZzZzcok2.PaddingLeft, z0ZzZzcok2.PaddingTop, z0mek() - z0ZzZzcok2.PaddingLeft - z0ZzZzcok2.PaddingRight, z0eek() - z0ZzZzcok2.PaddingTop - z0ZzZzcok2.PaddingBottom);
	}

	public override void z0mkk(float p0, float p1)
	{
		z0tek(z0rek() * p0);
		z0rek(z0oek() * p1);
		z0yek(z0mek() * p0);
		z0eek(z0eek() * p1);
	}

	public override void z0bkk(z0ZzZzbdh p0)
	{
		z0tek(p0.z0oek());
		z0rek(p0.z0pek());
		z0yek(p0.z0uek());
		z0eek(p0.z0iek());
	}

	public new float z0yek()
	{
		return z0oek() + z0eek();
	}

	public new float z0uek()
	{
		return z0rek() + z0mek();
	}

	public override z0ZzZzbdh z0vkk()
	{
		return new z0ZzZzbdh(z0rek(), z0oek(), z0mek(), z0eek());
	}

	public new string z0iek()
	{
		return z0pek();
	}

	public new float z0oek()
	{
		return z0nek;
	}

	public virtual void z0zkk(bool p0)
	{
		z0vek = p0;
	}

	public void z0tek(float p0)
	{
		z0zek = p0;
	}

	public void z0yek(float p0)
	{
		z0bek = p0;
	}

	public new string z0pek()
	{
		return z0cek;
	}

	public override void z0fjk(z0ZzZztuj p0)
	{
		string text = z0iek();
		if (text == null || text.Length <= 0)
		{
			return;
		}
		z0ZzZzbdh p1 = ((z0ZzZzhuj)this).z0uek();
		z0ZzZzcok z0ZzZzcok2 = ((z0ZzZzhuj)this).z0oek();
		p1 = z0ZzZzcok2.z0eek(p1);
		using z0ZzZzlsh z0ZzZzlsh2 = z0ZzZzcok2.z0uek();
		z0ZzZzimk font = z0ZzZzcok2.Font;
		if (z0jjk().z0nek() && p0.z0rek() > 0f)
		{
			font.Size /= p0.z0rek();
		}
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0iek().z0eek(text, font, (int)p1.z0uek(), z0ZzZzlsh2);
		if (z0jjk().z0uek().A != 0)
		{
			z0ZzZzbdh p2 = z0ZzZzjmk.z0eek(p1, z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek() + 10f, z0ZzZzlsh2.z0pek(), z0ZzZzlsh2.z0tek());
			p0.z0iek().z0rek(z0jjk().z0uek(), p2);
		}
		p0.z0iek().z0eek(text, font, z0ZzZzcok2.Color, p1, z0ZzZzlsh2);
	}

	public new float z0mek()
	{
		return z0bek;
	}
}
