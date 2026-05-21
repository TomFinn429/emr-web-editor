using System;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzctk
{
	private float z0rek;

	private float z0tek;

	private float z0yek;

	private float z0uek;

	private z0ZzZzpdh z0iek = z0ZzZzpdh.z0yek;

	public void z0eek(z0ZzZzjpk p0, z0ZzZzudh p1, z0ZzZztfh p2, z0ZzZztfh p3)
	{
		if (p0 == null || (p1 == null && p2 == null && p3 == null))
		{
			return;
		}
		z0ZzZzbdh p4 = new z0ZzZzbdh(z0iek.z0rek(), z0iek.z0tek(), z0tek, z0rek);
		float num = (float)((double)z0yek * Math.Cos((double)z0uek * Math.PI / 180.0));
		float num2 = 0f - (float)((double)z0yek * Math.Sin((double)z0uek * Math.PI / 180.0));
		z0ZzZzpdh z0ZzZzpdh2 = new z0ZzZzpdh(z0iek.z0rek() + z0tek, z0iek.z0tek());
		z0ZzZznfh p5 = z0ZzZzkmk.z0eek(z0iek, z0ZzZzpdh2, num, num2);
		z0ZzZznfh p6 = z0ZzZzkmk.z0eek(z0ZzZzpdh2, new z0ZzZzpdh(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek() + z0rek), num, num2);
		if (p1 != null)
		{
			using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(Color.FromArgb(100, p1.z0nek()), p1.z0oek());
			z0ZzZzudh2.z0eek(p1.z0tek());
			p0.z0eek(z0ZzZzudh2, p4.z0oek() + num, p4.z0nek() + num2, p4.z0oek() + num, p4.z0pek() + num2);
			p0.z0eek(z0ZzZzudh2, p4.z0oek() + num, p4.z0nek() + num2, p4.z0oek(), p4.z0nek());
			p0.z0eek(z0ZzZzudh2, p4.z0oek() + num, p4.z0nek() + num2, p4.z0mek() + num, p4.z0nek() + num2);
		}
		if (p3 != null)
		{
			p0.z0eek(p3, p5);
			p0.z0eek(p3, p6);
		}
		if (p2 != null)
		{
			p0.z0rek(p2, p4);
		}
		if (p1 != null)
		{
			p0.z0eek(p1, p5);
			p0.z0eek(p1, p6);
			p0.z0eek(p1, p4.z0oek(), p4.z0pek(), p4.z0uek(), p4.z0iek(), 0f);
		}
	}

	public z0ZzZzctk(z0ZzZzbdh p0, float p1, float p2)
	{
		z0uek = (float)(Math.Atan2(p2, p1) * 180.0 / Math.PI);
		z0iek = p0.z0eek();
		z0tek = p0.z0uek();
		z0rek = p0.z0iek();
		z0yek = (float)Math.Sqrt(p1 * p1 + p2 * p2);
	}
}
