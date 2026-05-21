using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzruj
{
	public virtual void z0eek(z0ZzZzhuj p0, z0ZzZztuj p1)
	{
		z0tek(p0, p1);
		p0.z0fjk(p1);
		z0rek(p0, p1);
	}

	public virtual void z0rek(z0ZzZzhuj p0, z0ZzZztuj p1)
	{
		z0ZzZznfh z0ZzZznfh2 = p0.z0ckk();
		if (z0ZzZznfh2 != null)
		{
			z0ZzZzcok z0ZzZzcok2 = p0.z0oek();
			if (z0ZzZzcok2.HasVisibleBorder)
			{
				p1.z0iek().z0eek(z0ZzZzcok2.BorderTopColor, z0ZzZzcok2.BorderWidth, z0ZzZzcok2.BorderStyle, z0ZzZznfh2);
			}
			else if (p1.z0nek().z0cek())
			{
				p1.z0iek().z0eek(p1.z0tek().z0eek(), z0ZzZznfh2);
			}
			z0ZzZznfh2.Dispose();
		}
	}

	public virtual void z0tek(z0ZzZzhuj p0, z0ZzZztuj p1)
	{
		z0ZzZzcok z0ZzZzcok2 = p0.z0oek();
		if (!z0ZzZzcok2.HasVisibleBackground)
		{
			return;
		}
		z0ZzZznfh z0ZzZznfh2 = p0.z0ckk();
		if (z0ZzZznfh2 == null)
		{
			return;
		}
		z0ZzZzpdh z0ZzZzpdh2 = p0.z0nek();
		using (z0ZzZzjdh z0ZzZzjdh2 = new z0ZzZzjdh())
		{
			z0ZzZzjdh2.z0eek(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek());
			z0ZzZznfh2.z0eek(z0ZzZzjdh2);
		}
		using (z0ZzZztfh z0ZzZztfh2 = z0ZzZzcok2.z0eek(p0.z0vkk(), GraphicsUnit.Document))
		{
			if (z0ZzZztfh2 != null)
			{
				p1.z0iek().z0eek(z0ZzZztfh2, z0ZzZznfh2);
			}
		}
		z0ZzZznfh2.Dispose();
	}
}
