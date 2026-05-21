using System;
using System.Runtime.CompilerServices;
using DCSoft.WinForms;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzspj : z0ZzZzgpj
{
	protected class z0hck : z0ZzZzypj
	{
		public new z0ZzZzgpj z0eek;

		public new int z0rek;

		public new z0ZzZzndh z0tek = z0ZzZzndh.z0cek;

		public new z0ZzZzndh[] z0yek;

		protected override z0ZzZzrpj z0ah()
		{
			z0ZzZzspj z0ZzZzspj2 = (z0ZzZzspj)z0oek_jiejie20260327142557();
			z0ZzZzrpj z0ZzZzrpj2 = base.z0ah();
			z0ZzZzrpj2.z0rek(z0ZzZzspj2.z0jx().z0eek(z0ZzZzrpj2.z0pek()));
			z0ZzZzrpj2.z0eek(z0ZzZzspj2.z0jx().z0eek(z0ZzZzrpj2.z0yek()));
			return z0ZzZzrpj2;
		}

		public z0hck(z0ZzZzmwh p0)
			: base(p0)
		{
		}
	}

	public delegate void z0ook(z0ZzZzodh[] ps);

	[CompilerGenerated]
	private sealed class z0pik
	{
		public z0hck z0rek;

		public z0ook z0tek;

		public z0ZzZzspj z0yek;

		internal void z0eek(object p0, EventArgs p1)
		{
			z0ZzZzodh p2 = z0rek.z0tek();
			p2 = z0yek.z0jx().z0eek(p2);
			z0ZzZzodh p3 = z0rek.z0hrk();
			p3 = z0yek.z0jx().z0eek(p3);
			z0tek(new z0ZzZzodh[2] { p2, p3 });
		}
	}

	protected bool z0srk;

	protected z0ZzZzqmk z0ark = new z0ZzZzsmk();

	private new z0ZzZzpdh z0qrk = z0ZzZzpdh.z0yek;

	private GraphicsUnit z0wrk = GraphicsUnit.Pixel;

	public z0ZzZzeeh z0erk;

	protected bool z0rrk = true;

	protected z0ZzZzndh z0trk = z0ZzZzndh.z0cek;

	public new z0ZzZzeeh z0yrk;

	private z0ZzZzipj z0urk = new z0ZzZzipj();

	protected float z0irk = 1f;

	public new z0ZzZzeeh z0ork;

	public z0ZzZzeeh z0prk;

	public z0ZzZzeeh z0mrk;

	protected new z0ZzZzodh z0nrk = z0ZzZzodh.z0yek;

	protected z0ZzZzndh z0brk = z0ZzZzndh.z0cek;

	private z0ZzZzcdh z0vrk = new z0ZzZzcdh(20, 20);

	protected bool z0crk;

	protected z0ZzZznwh z0xrk_jiejie20260327142557 = z0ZzZzbwh.z0vek;

	protected float z0zrk = 1f;

	public virtual z0ZzZzodh z0tc(int p0, int p1)
	{
		z0fhk();
		return z0ark.z0jwk(p0, p1);
	}

	public new virtual void z0eek()
	{
		z0urk.z0yek();
	}

	public void z0eek(float p0)
	{
		if (z0irk != p0)
		{
			z0irk = p0;
			z0bek();
			z0hz();
		}
	}

	protected virtual z0ZzZzopk z0eek(z0ZzZzopk p0, z0ZzZzsmk p1, bool p2)
	{
		if (p1 == null)
		{
			return null;
		}
		z0ZzZzndh p3 = p0.z0eek();
		p3.z0rek(-1, -1);
		p3.z0tek(p3.z0iek() + 2);
		p3.z0yek(p3.z0oek() + 2);
		if (p2)
		{
			z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0tek(p1.z0tek_jiejie20260327142557(), p3);
			p3.z0rek(z0ZzZzndh2.z0mek());
			p3.z0yek(z0ZzZzndh2.z0oek());
		}
		z0ZzZzbdh z0ZzZzbdh2 = p1.z0eek((float)p3.z0pek(), (float)p3.z0mek(), (float)p3.z0iek(), (float)p3.z0oek());
		p3.z0eek((int)Math.Floor(z0ZzZzbdh2.z0oek()));
		p3.z0rek((int)Math.Floor(z0ZzZzbdh2.z0pek()));
		p3.z0tek((int)Math.Ceiling(z0ZzZzbdh2.z0mek()) - p3.z0pek());
		p3.z0yek((int)Math.Ceiling(z0ZzZzbdh2.z0nek()) - p3.z0mek());
		p0.z0rek().z0eek(z0cek());
		p0.z0rek().z0zek();
		p0.z0rek().z0eek(z0xek(), z0yek());
		double num = z0pek();
		p0.z0rek().z0rek((float)((double)p1.z0mek().z0oek() * num - (double)p1.z0rek().z0tek()), (float)((double)p1.z0mek().z0pek() * num - (double)p1.z0rek().z0yek()));
		if (p1.z0bek() < 1f)
		{
			p3.z0tek(p3.z0iek() + (int)Math.Ceiling(1f / p1.z0bek()));
		}
		if (p1.z0krk() < 1f)
		{
			p3.z0yek(p3.z0oek() + (int)Math.Ceiling(1f / p1.z0krk()));
		}
		p3.z0yek(p3.z0oek() + 6);
		z0ZzZzopk z0ZzZzopk2 = new z0ZzZzopk(p0.z0rek(), p3);
		z0ZzZzopk2.z0rek().z0rek();
		int num2 = z0ZzZzrpk.z0eek(2, GraphicsUnit.Pixel, z0ZzZzopk2.z0rek().z0vek());
		z0ZzZzopk2.z0rek().z0eek(new z0ZzZzbdh(p3.z0pek() - num2, p3.z0mek() - num2, p3.z0iek() + num2 * 2, p3.z0oek() + num2));
		return z0ZzZzopk2;
	}

	public new void z0rek(float p0)
	{
		if (z0zrk != p0)
		{
			z0zrk = p0;
			z0bek();
			z0hz();
		}
	}

	public new virtual z0ZzZzodh z0rek()
	{
		z0ZzZzodh z0ZzZzodh2 = z0ZzZzmwh.z0cek();
		if (base.z0bek().z0rek(z0ZzZzodh2))
		{
			return z0ZzZzodh2;
		}
		return z0ZzZzodh.z0yek;
	}

	public virtual void z0eek(GraphicsUnit p0)
	{
		z0wrk = p0;
	}

	public new void z0eek(z0ZzZzndh p0)
	{
		if (!z0trk.Equals(p0))
		{
			z0trk = p0;
			z0bek();
		}
	}

	public virtual void z0tek()
	{
		z0urk.z0rek();
	}

	protected virtual void z0eek(z0ZzZzweh p0)
	{
		if (z0erk != null)
		{
			z0erk(this, p0);
		}
	}

	public new float z0yek()
	{
		return z0irk;
	}

	public new void z0uek()
	{
		z0crk = true;
	}

	public new z0ZzZzndh z0iek()
	{
		return z0trk;
	}

	protected override void z0lhk(z0ZzZzweh p0)
	{
		base.z0lhk(p0);
		z0ZzZzodh z0ZzZzodh2 = z0nc(p0.z0rek(), p0.z0tek());
		z0yek(new z0ZzZzweh(p0.z0yek(), p0.z0uek(), z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), p0.z0eek()));
	}

	public virtual z0ZzZzodh z0nc(int p0, int p1)
	{
		z0fhk();
		return z0drk().z0gwk(p0, p1);
	}

	public virtual void z0gc(int p0, int p1, int p2, int p3)
	{
	}

	public new z0ZzZzpdh z0oek()
	{
		return z0qrk;
	}

	protected new virtual z0ZzZzndh z0rek(z0ZzZzndh p0)
	{
		if (z0brk.z0vek())
		{
			z0brk = p0;
		}
		else if (!p0.z0vek())
		{
			z0brk = z0ZzZzndh.z0yek(z0brk, p0);
		}
		if (z0hrk())
		{
			return z0ZzZzndh.z0cek;
		}
		z0ZzZzndh result = z0brk;
		z0brk = z0ZzZzndh.z0cek;
		return result;
	}

	public new double z0pek()
	{
		return z0ZzZzrpk.z0eek(z0cek(), GraphicsUnit.Pixel) / (double)z0zrk;
	}

	public new void z0eek(z0ZzZzcdh p0)
	{
		z0vrk = p0;
	}

	public new virtual z0ZzZzadh z0mek()
	{
		z0ZzZzadh obj = base.z0hrk();
		obj.z0eek(z0cek());
		return obj;
	}

	public virtual void z0fhk()
	{
		if (z0ark is z0ZzZzsmk z0ZzZzsmk2)
		{
			z0ZzZzndh p = base.z0bek();
			z0ZzZzsmk2.z0rek(p);
			float num = (float)z0pek();
			float num2 = (float)z0nek();
			z0ZzZzbdh p2 = new z0ZzZzbdh(0f, 0f, (float)p.z0iek() * num, (float)p.z0oek() * num2);
			p2.z0tek(z0oek());
			z0ZzZzsmk2.z0eek(p2);
		}
	}

	public void z0eek(z0ZzZzpdh p0)
	{
		z0qrk = p0;
	}

	protected new virtual void z0rek(z0ZzZzweh p0)
	{
		if (z0mrk != null)
		{
			z0mrk(this, p0);
		}
	}

	protected virtual z0ZzZzqmk z0jx()
	{
		return z0ark;
	}

	public new double z0nek()
	{
		return z0ZzZzrpk.z0eek(z0cek(), GraphicsUnit.Pixel) / (double)z0irk;
	}

	public new virtual void z0bek()
	{
		if (!z0iek().z0vek())
		{
			z0ZzZzcdh p = new z0ZzZzcdh(z0iek().z0nek() - (int)z0oek().z0rek(), z0iek().z0bek() - (int)z0oek().z0tek());
			z0fhk();
			p = z0ark.z0fwk(p);
			z0hz();
		}
	}

	protected override void z0xjk(z0ZzZzweh p0)
	{
		z0srk = false;
		base.z0xjk(p0);
		if (z0ark.z0hwk(p0.z0rek(), p0.z0tek()))
		{
			z0ZzZzodh z0ZzZzodh2 = z0nc(p0.z0rek(), p0.z0tek());
			z0srk = true;
			z0eek(new z0ZzZzweh(p0.z0yek(), p0.z0uek(), z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), p0.z0eek()));
		}
	}

	protected override void z0jz(z0ZzZzreh p0)
	{
		base.z0jz(p0);
		z0jrk();
		z0fhk();
		z0ZzZzopk z0ZzZzopk2 = z0eek(new z0ZzZzopk(p0.z0eek(), p0.z0tek()), z0drk() as z0ZzZzsmk, p2: true);
		if (z0ZzZzopk2 != null)
		{
			z0eek(z0ZzZzopk2, z0drk() as z0ZzZzsmk);
		}
	}

	protected new int z0vek()
	{
		return base.z0nrk;
	}

	public new virtual GraphicsUnit z0cek()
	{
		return z0wrk;
	}

	public new float z0xek()
	{
		return z0zrk;
	}

	public new z0ZzZzcdh z0zek()
	{
		return z0vrk;
	}

	public virtual void z0ghk(z0ZzZzndh p0)
	{
		if (!z0hrk())
		{
			p0 = z0rek(p0);
			if (!p0.z0vek())
			{
				z0fhk();
				z0ZzZzndh p1 = z0ark.z0eek(p0);
				base.z0eek(p1);
			}
		}
	}

	public bool z0eek(z0ZzZzndh p0, ScrollToViewStyle p1)
	{
		return z0gx(p0.z0pek(), p0.z0mek(), p0.z0iek(), p0.z0oek(), p1);
	}

	public new virtual z0ZzZzodh z0lrk()
	{
		z0ZzZzodh p = z0rek();
		if (!p.z0eek())
		{
			return z0eek(p);
		}
		return z0ZzZzodh.z0yek;
	}

	protected new z0ZzZzjpk z0krk()
	{
		z0ZzZzjpk obj = new z0ZzZzjpk(base.z0hrk());
		obj.z0eek(p0: true);
		return obj;
	}

	protected virtual void z0eek(z0ZzZzopk p0, z0ZzZzsmk p1)
	{
	}

	public bool z0eek(int p0, int p1, int p2, int p3)
	{
		return z0gx(p0, p1, p2, p3, ScrollToViewStyle.Normal);
	}

	protected override void z0khk(EventArgs p0)
	{
		base.z0khk(p0);
		z0ZzZzodh z0ZzZzodh2 = z0lrk();
		z0rek(new z0ZzZzweh(z0ZzZzmwh.z0pek(), 1, z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), 0));
	}

	protected new void z0jrk()
	{
		if (z0zrk <= 0f || z0irk <= 0f)
		{
			throw new InvalidOperationException("Bad zoom rate value");
		}
	}

	protected virtual void z0tek(z0ZzZzweh p0)
	{
		if (z0yrk != null)
		{
			z0yrk(this, p0);
		}
	}

	public virtual z0ZzZzodh[] z0eek(z0ZzZztpj p0, z0ook p1, z0ZzZzndh p2, object p3)
	{
		z0fhk();
		z0hck z0rek = new z0hck(this);
		z0rek.z0rek(p3);
		if (!p2.z0vek())
		{
			p2 = z0ark.z0eek(p2);
			z0rek.z0eek(p2);
		}
		z0rek.z0eek((z0ZzZzupj)4);
		if (p0 != null)
		{
			z0rek.z0rrk = p0;
		}
		if (p1 != null)
		{
			z0rek.z0trk = delegate
			{
				z0ZzZzodh p4 = z0rek.z0tek();
				p4 = z0jx().z0eek(p4);
				z0ZzZzodh p5 = z0rek.z0hrk();
				p5 = z0jx().z0eek(p5);
				p1(new z0ZzZzodh[2] { p4, p5 });
			};
		}
		z0rek.z0lrk();
		return null;
	}

	protected override void z0zjk(z0ZzZzweh p0)
	{
		base.z0zjk(p0);
		if (z0ark.z0hwk(p0.z0rek(), p0.z0tek()))
		{
			z0ZzZzodh z0ZzZzodh2 = z0nc(p0.z0rek(), p0.z0tek());
			z0tek(new z0ZzZzweh(p0.z0yek(), p0.z0uek(), z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), p0.z0eek()));
		}
	}

	public override void z0lz_jiejie20260327142557()
	{
		if (z0ark != null)
		{
			z0ark.z0vqk();
			z0ark = null;
		}
		z0urk = null;
		z0xrk_jiejie20260327142557 = null;
		z0mrk = null;
		z0prk = null;
		z0yrk = null;
		z0erk = null;
		z0ork = null;
	}

	public new bool z0hrk()
	{
		return z0urk.z0uek();
	}

	protected virtual void z0yek(z0ZzZzweh p0)
	{
		if (z0prk != null)
		{
			z0prk(this, p0);
		}
	}

	protected virtual void z0uek(z0ZzZzweh p0)
	{
		if (z0ork != null)
		{
			z0ork(this, p0);
		}
	}

	public virtual bool z0gx(int p0, int p1, int p2, int p3, ScrollToViewStyle p4)
	{
		return false;
	}

	protected override void z0cjk(z0ZzZzweh p0)
	{
		z0nrk = z0ZzZzodh.z0yek;
		if (z0ark.z0hwk(p0.z0rek(), p0.z0tek()))
		{
			z0ZzZzodh z0ZzZzodh2 = z0nc(p0.z0rek(), p0.z0tek());
			z0uek(new z0ZzZzweh(p0.z0yek(), p0.z0uek(), z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), p0.z0eek()));
		}
	}

	protected new void z0grk()
	{
		z0urk.z0tek();
	}

	public virtual z0ZzZzodh z0eek(z0ZzZzodh p0)
	{
		z0fhk();
		return z0drk().z0eek(p0);
	}

	protected new int z0frk()
	{
		return base.z0yrk;
	}

	public z0ZzZzqmk z0drk()
	{
		return z0ark;
	}
}
