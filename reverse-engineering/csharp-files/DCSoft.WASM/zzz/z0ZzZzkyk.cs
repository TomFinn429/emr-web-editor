using System;
using System.Collections;
using System.Collections.Generic;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzkyk : IDisposable, ICloneable, z0ZzZzxtk
{
	internal struct z0bxk
	{
		private float z0uek;

		private float z0iek;

		private z0ZzZzpdh z0oek_jiejie20260327142557;

		private z0ZzZzpdh z0pek;

		public z0bxk(float p0, float p1, z0ZzZzpdh p2, z0ZzZzpdh p3)
		{
			z0uek = p0;
			z0iek = p1;
			z0oek_jiejie20260327142557 = p2;
			z0pek = p3;
		}

		public float z0eek()
		{
			return z0uek;
		}

		public float z0rek()
		{
			return z0iek;
		}

		public z0ZzZzpdh z0tek_jiejie20260327142557()
		{
			return z0oek_jiejie20260327142557;
		}

		public z0ZzZzpdh z0yek()
		{
			return z0pek;
		}
	}

	private bool z0mrk;

	private z0ZzZztfh z0nrk;

	private Color z0brk = Color.Empty;

	[NonSerialized]
	private z0ZzZzudh z0vrk;

	protected float z0crk;

	private z0ZzZzlyk z0xrk;

	protected z0ZzZzpdh z0zrk;

	private string z0ltk = string.Empty;

	private z0ZzZzndh z0ktk;

	protected z0ZzZzpdh z0jtk;

	[NonSerialized]
	private z0ZzZztfh z0htk;

	[NonSerialized]
	private z0ZzZztfh z0gtk;

	private string z0ftk;

	private float z0dtk;

	protected z0ZzZzpdh z0stk;

	[NonSerialized]
	private List<z0ZzZznfh> z0atk = new List<z0ZzZznfh>(6);

	protected z0ZzZzkmk z0qtk = z0ZzZzkmk.z0yek;

	protected z0ZzZzkmk z0wtk = z0ZzZzkmk.z0yek;

	private float z0etk;

	private string z0rtk;

	protected float z0ttk;

	protected z0ZzZzpdh z0ytk;

	[NonSerialized]
	private z0ZzZztfh z0utk;

	private bool z0itk;

	protected z0ZzZzpdh z0otk;

	protected z0ZzZzpdh z0ptk;

	private float z0mtk = -1f;

	protected double z0ntk;

	public Color z0eek()
	{
		return Color.FromArgb(z0cek(), z0krk());
	}

	internal z0ZzZzndh z0rek_jiejie20260327142557()
	{
		return z0ktk;
	}

	public int z0tek()
	{
		return z0mek().z0oek().z0rek();
	}

	private void z0yek()
	{
		z0eek(p0: true, p1: true);
	}

	internal void z0eek(z0ZzZzjpk p0)
	{
		if (z0rek_jiejie20260327142557().z0iek() > 0 && z0rek_jiejie20260327142557().z0oek() > 0)
		{
			p0.z0eek(z0wrk(), z0rek_jiejie20260327142557().z0yek(), z0rek_jiejie20260327142557().z0uek(), z0rek_jiejie20260327142557().z0iek(), z0rek_jiejie20260327142557().z0oek(), z0trk(), z0pek());
			p0.z0eek(z0yrk(), z0rek_jiejie20260327142557(), z0trk(), z0pek());
			z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
			z0ZzZznfh2.z0rek(z0rek_jiejie20260327142557().z0yek(), z0rek_jiejie20260327142557().z0uek(), z0rek_jiejie20260327142557().z0iek(), z0rek_jiejie20260327142557().z0oek(), z0trk(), z0pek());
			z0iek().Add(z0ZzZznfh2);
		}
	}

	protected z0ZzZzxdh z0eek(float p0, float p1)
	{
		if (p1 == 0f)
		{
			return z0ZzZzxdh.z0yek;
		}
		float p2 = (float)((double)((float)z0mek().z0uek().z0rek() * p1 / 2f) * Math.Cos((double)p0 * Math.PI / 180.0));
		float p3 = (float)((double)((float)z0mek().z0uek().z0tek() * p1 / 2f) * Math.Sin((double)p0 * Math.PI / 180.0));
		return new z0ZzZzxdh(p2, p3);
	}

	public string z0pwk()
	{
		return z0rrk();
	}

	internal void z0uek()
	{
		z0iek().Clear();
		z0frk();
		if (z0rek_jiejie20260327142557().z0iek() > 0 && z0rek_jiejie20260327142557().z0oek() > 0)
		{
			z0urk();
			z0irk();
			float p = z0rek_jiejie20260327142557().z0pek() + z0rek_jiejie20260327142557().z0iek() / 2;
			float num = z0rek_jiejie20260327142557().z0mek() + z0rek_jiejie20260327142557().z0oek() / 2;
			z0jtk = new z0ZzZzpdh(p, num);
			z0zrk = new z0ZzZzpdh(p, num + (float)z0tek());
			z0otk = z0eek(p, num, z0rek_jiejie20260327142557().z0iek() / 2, z0rek_jiejie20260327142557().z0oek() / 2, z0oek());
			z0stk = new z0ZzZzpdh(z0otk.z0rek(), z0otk.z0tek() + (float)z0tek());
			z0ytk = z0eek(p, num, z0rek_jiejie20260327142557().z0iek() / 2, z0rek_jiejie20260327142557().z0oek() / 2, z0oek() + z0xek());
			z0ptk = new z0ZzZzpdh(z0ytk.z0rek(), z0ytk.z0tek() + (float)z0tek());
			z0yek();
		}
	}

	internal List<z0ZzZznfh> z0iek()
	{
		return z0atk;
	}

	internal void z0eek(z0ZzZzndh p0)
	{
		z0ktk = p0;
	}

	public float z0oek()
	{
		return z0etk;
	}

	public float z0pek()
	{
		return z0ttk;
	}

	internal z0ZzZzlyk z0mek()
	{
		return z0xrk;
	}

	internal z0ZzZzpdh z0eek(float p0, float p1, float p2, float p3, float p4)
	{
		double num = (double)p4 * Math.PI / 180.0;
		return new z0ZzZzpdh(p0 + (float)((double)p2 * Math.Cos(num)), p1 + (float)((double)p3 * Math.Sin(num)));
	}

	public float z0nek()
	{
		return (z0trk() + z0pek()) % 360f;
	}

	internal void z0bek()
	{
		float p = z0rek_jiejie20260327142557().z0pek() + z0rek_jiejie20260327142557().z0iek() / 2;
		float num = z0rek_jiejie20260327142557().z0mek() + z0rek_jiejie20260327142557().z0oek() / 2;
		z0jtk = new z0ZzZzpdh(p, num);
		z0zrk = new z0ZzZzpdh(p, num + (float)z0tek());
		z0otk = z0eek(p, num, z0rek_jiejie20260327142557().z0iek() / 2, z0rek_jiejie20260327142557().z0oek() / 2, z0oek());
		z0stk = new z0ZzZzpdh(z0otk.z0rek(), z0otk.z0tek() + (float)z0tek());
		z0ytk = z0eek(p, num, z0rek_jiejie20260327142557().z0iek() / 2, z0rek_jiejie20260327142557().z0oek() / 2, z0oek() + z0xek());
		z0ptk = new z0ZzZzpdh(z0ytk.z0rek(), z0ytk.z0tek() + (float)z0tek());
	}

	public void z0eek(Color p0)
	{
		z0brk = p0;
	}

	protected float z0eek(float p0, z0ZzZzbdh p1)
	{
		double num = (double)p1.z0uek() * Math.Cos((double)p0 * Math.PI / 180.0);
		float num2 = (float)(Math.Atan2((double)p1.z0iek() * Math.Sin((double)p0 * Math.PI / 180.0), num) * 180.0 / Math.PI);
		if (num2 < 0f)
		{
			return num2 + 360f;
		}
		return num2;
	}

	public string z0vek()
	{
		if (z0ltk == string.Empty)
		{
			z0ltk = Guid.NewGuid().ToString();
		}
		return z0ltk;
	}

	public void z0eek(bool p0)
	{
		z0mrk = p0;
	}

	public int z0cek()
	{
		return (int)(z0mek().z0oek().z0yek() * 255.0);
	}

	public float z0xek()
	{
		return z0dtk;
	}

	private z0ZzZztfh z0zek()
	{
		return z0nrk;
	}

	private void z0eek(z0ZzZztfh p0)
	{
		z0nrk = p0;
	}

	private void z0eek(bool p0, bool p1)
	{
		if (p0)
		{
			z0wtk = new z0ZzZzkmk(z0jtk, z0otk, z0stk, z0zrk, z0pek() != 180f);
		}
		else
		{
			z0wtk = z0ZzZzkmk.z0yek;
		}
		if (p1)
		{
			z0qtk = new z0ZzZzkmk(z0jtk, z0ytk, z0ptk, z0zrk, z0pek() != 180f);
		}
		else
		{
			z0qtk = z0ZzZzkmk.z0yek;
		}
	}

	public bool z0lrk()
	{
		return z0mrk;
	}

	public Color z0krk()
	{
		return z0brk;
	}

	internal z0ZzZzkyk[] z0eek(float p0)
	{
		if (z0trk() != p0 && z0nek() != p0)
		{
			float num = z0uek(z0trk());
			float p1 = (p0 - num + 360f) % 360f;
			z0ZzZzkyk z0ZzZzkyk2 = new z0ZzZzkyk();
			z0ZzZzkyk2.z0eek(z0mek());
			z0ZzZzkyk2.z0yek(z0rrk());
			z0ZzZzkyk2.z0eek(z0prk());
			z0ZzZzkyk2.z0eek(z0krk());
			z0ZzZzkyk2.z0yek(z0jrk());
			z0ZzZzkyk2.z0eek(z0lrk());
			z0ZzZzkyk2.z0rek_jiejie20260327142557(z0vek());
			z0ZzZzkyk2.z0eek(z0rek_jiejie20260327142557());
			z0ZzZzkyk2.z0rek_jiejie20260327142557(num);
			z0ZzZzkyk2.z0tek(p1);
			z0ZzZzkyk2.z0urk();
			z0ZzZzkyk2.z0irk();
			z0ZzZzkyk2.z0bek();
			z0ZzZzkyk2.z0eek(p0: true, p1: false);
			p1 = z0uek(z0nek()) - p0;
			z0ZzZzkyk z0ZzZzkyk3 = new z0ZzZzkyk();
			z0ZzZzkyk3.z0eek(z0mek());
			z0ZzZzkyk3.z0yek(z0rrk());
			z0ZzZzkyk3.z0eek(z0prk());
			z0ZzZzkyk3.z0eek(z0krk());
			z0ZzZzkyk3.z0yek(z0jrk());
			z0ZzZzkyk3.z0eek(z0lrk());
			z0ZzZzkyk3.z0rek_jiejie20260327142557(z0vek());
			z0ZzZzkyk3.z0eek(z0rek_jiejie20260327142557());
			z0ZzZzkyk3.z0rek_jiejie20260327142557(p0);
			z0ZzZzkyk3.z0tek(p1);
			z0ZzZzkyk3.z0urk();
			z0ZzZzkyk3.z0irk();
			z0ZzZzkyk3.z0bek();
			z0ZzZzkyk3.z0eek(p0: false, p1: true);
			return new z0ZzZzkyk[2] { z0ZzZzkyk2, z0ZzZzkyk3 };
		}
		return new z0ZzZzkyk[1] { (z0ZzZzkyk)Clone() };
	}

	public float z0jrk()
	{
		if (z0mtk < 0f)
		{
			if (z0mek() != null)
			{
				return z0mek().z0oek().z0tek();
			}
			return 0f;
		}
		return z0mtk;
	}

	public string z0hrk_jiejie20260327142557()
	{
		return z0ZzZzlok.z0eek(z0brk, Color.Empty);
	}

	private z0ZzZztfh z0grk()
	{
		return z0gtk;
	}

	internal void z0eek(z0ZzZzlyk p0)
	{
		z0xrk = p0;
	}

	private void z0rek_jiejie20260327142557(z0ZzZztfh p0)
	{
		z0gtk = p0;
	}

	internal void z0rek_jiejie20260327142557(z0ZzZzjpk p0)
	{
		z0bxk[] array = z0erk();
		for (int i = 0; i < array.Length; i++)
		{
			z0bxk z0bxk = array[i];
			z0eek(p0, z0yrk(), z0utk, z0bxk.z0eek(), z0bxk.z0rek(), z0bxk.z0tek_jiejie20260327142557(), z0bxk.z0yek());
		}
	}

	internal void z0frk()
	{
		float num = z0jrk();
		float num2 = z0jrk();
		if (num > 0f)
		{
			z0ZzZzxdh z0ZzZzxdh2 = z0eek(z0oek() + z0xek() / 2f, z0jrk());
			num = z0ZzZzxdh2.z0rek();
			num2 = z0ZzZzxdh2.z0tek();
		}
		z0ktk = new z0ZzZzndh((int)(z0mek().z0xek().z0oek() + (float)(z0mek().z0iek().z0rek() / 2) + num), (int)((float)(z0mek().z0iek().z0tek() / 2) + num2 + z0mek().z0xek().z0pek()), z0mek().z0uek().z0rek(), z0mek().z0uek().z0tek());
	}

	protected void z0eek(z0ZzZzjpk p0, z0ZzZzudh p1, z0ZzZztfh p2, float p3, float p4, z0ZzZzpdh p5, z0ZzZzpdh p6)
	{
		z0ZzZznfh z0ZzZznfh2 = z0eek(p3, p4, p5, p6);
		p0.z0eek(p2, z0ZzZznfh2);
		p0.z0eek(p1, z0ZzZznfh2);
		z0iek().Add(z0ZzZznfh2);
	}

	internal void z0tek(z0ZzZzjpk p0)
	{
		if (z0rek_jiejie20260327142557().z0iek() > 0 && z0rek_jiejie20260327142557().z0oek() > 0)
		{
			z0oek(p0);
			if (z0trk() > 90f && z0trk() < 270f)
			{
				z0yek(p0);
				z0uek(p0);
			}
			else
			{
				z0uek(p0);
				z0yek(p0);
			}
			z0rek_jiejie20260327142557(p0);
		}
	}

	private z0bxk[] z0drk()
	{
		ArrayList arrayList = new ArrayList();
		if (z0ttk != 0f && (!(z0crk >= 0f) || !(z0crk + z0ttk <= 180f)) && z0crk + z0ttk > 180f)
		{
			float num = z0crk;
			z0ZzZzpdh p = new z0ZzZzpdh(z0otk.z0rek(), z0otk.z0tek());
			float num2 = z0crk + z0ttk;
			z0ZzZzpdh p2 = new z0ZzZzpdh(z0ytk.z0rek(), z0ytk.z0tek());
			if (num < 180f)
			{
				num = 180f;
				p.z0eek(z0ktk.z0pek());
				p.z0rek(z0jtk.z0tek());
			}
			if (num2 > 360f)
			{
				num2 = 360f;
				p2.z0eek(z0ktk.z0nek());
				p2.z0rek(z0jtk.z0tek());
			}
			arrayList.Add(new z0bxk(num, num2, p, p2));
			if (z0crk < 360f && z0crk + z0ttk > 540f)
			{
				num = 180f;
				p = new z0ZzZzpdh(z0ktk.z0pek(), z0jtk.z0tek());
				num2 = z0nek();
				p2 = new z0ZzZzpdh(z0ytk.z0rek(), z0ytk.z0tek());
				arrayList.Add(new z0bxk(num, num2, p, p2));
			}
		}
		return (z0bxk[])arrayList.ToArray(typeof(z0bxk));
	}

	protected virtual z0ZzZztfh z0rek_jiejie20260327142557(Color p0)
	{
		z0ZzZzpfh z0ZzZzpfh2 = new z0ZzZzpfh();
		z0ZzZzpfh2.z0eek(new Color[4]
		{
			z0ZzZzvok.z0eek(p0, -0.6f, 5, 3),
			z0ZzZzvok.z0eek(p0, -0.6f, 5, 1),
			z0ZzZzvok.z0eek(p0, -0.6f, 5, 1),
			z0ZzZzvok.z0eek(p0, -0.6f, 5, 3)
		});
		z0ZzZzpfh2.z0eek(new float[4] { 0f, 0.45f, 0.55f, 1f });
		z0ZzZzxfh obj = new z0ZzZzxfh(z0rek_jiejie20260327142557(), Color.Blue, Color.White, (z0ZzZzzfh)0);
		obj.z0eek(z0ZzZzpfh2);
		return obj;
	}

	public string z0srk()
	{
		return z0ftk;
	}

	protected virtual void z0rek_jiejie20260327142557(bool p0)
	{
		if (!z0itk)
		{
			if (p0)
			{
				z0vrk.Dispose();
				z0qrk();
				z0wtk.Dispose();
				z0qtk.Dispose();
			}
			z0itk = true;
		}
	}

	protected virtual void z0ark()
	{
		try
		{
			z0rek_jiejie20260327142557(p0: false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void z0rek_jiejie20260327142557(float p0)
	{
		z0etk = p0;
	}

	public void z0eek(string p0)
	{
		z0brk = z0ZzZzlok.z0eek(p0, Color.Empty);
	}

	protected void z0qrk()
	{
		z0htk.Dispose();
		z0gtk.Dispose();
		z0nrk.Dispose();
		z0utk.Dispose();
	}

	internal z0ZzZztfh z0wrk()
	{
		return z0htk;
	}

	private z0bxk[] z0erk()
	{
		ArrayList arrayList = new ArrayList();
		if (z0ttk != 0f && (!(z0crk >= 180f) || !(z0crk + z0ttk <= 360f)))
		{
			if (z0trk() < 180f)
			{
				float p = z0crk;
				z0ZzZzpdh p2 = new z0ZzZzpdh(z0otk.z0rek(), z0otk.z0tek());
				float p3 = z0nek();
				z0ZzZzpdh p4 = new z0ZzZzpdh(z0ytk.z0rek(), z0ytk.z0tek());
				if (z0crk + z0ttk > 180f)
				{
					p3 = 180f;
					p4.z0eek(z0ktk.z0yek());
					p4.z0rek(z0jtk.z0tek());
				}
				arrayList.Add(new z0bxk(p, p3, p2, p4));
			}
			if (z0crk + z0ttk > 360f)
			{
				float p5 = 0f;
				z0ZzZzpdh p6 = new z0ZzZzpdh(z0ktk.z0nek(), z0jtk.z0tek());
				float num = z0nek();
				z0ZzZzpdh p7 = new z0ZzZzpdh(z0ytk.z0rek(), z0ytk.z0tek());
				if (num > 180f)
				{
					num = 180f;
					p7.z0eek(z0ktk.z0pek());
					p7.z0rek(z0jtk.z0tek());
				}
				arrayList.Add(new z0bxk(p5, num, p6, p7));
			}
		}
		return (z0bxk[])arrayList.ToArray(typeof(z0bxk));
	}

	private z0ZzZznfh z0eek(float p0, float p1, z0ZzZzpdh p2, z0ZzZzpdh p3)
	{
		z0ZzZznfh obj = new z0ZzZznfh();
		obj.z0eek(z0rek_jiejie20260327142557(), p0, p1 - p0);
		obj.z0tek(p3.z0rek(), p3.z0tek(), p3.z0rek(), p3.z0tek() + (float)z0tek());
		obj.z0eek(z0rek_jiejie20260327142557().z0yek(), z0rek_jiejie20260327142557().z0uek() + z0tek(), z0rek_jiejie20260327142557().z0iek(), z0rek_jiejie20260327142557().z0oek(), p1, p0 - p1);
		obj.z0tek(p2.z0rek(), p2.z0tek() + (float)z0tek(), p2.z0rek(), p2.z0tek());
		return obj;
	}

	public string z0rrk()
	{
		return z0rtk;
	}

	internal void z0yek(z0ZzZzjpk p0)
	{
		if (z0qtk != null && z0qtk != z0ZzZzkmk.z0yek)
		{
			if (z0nek() > 90f && z0nek() < 270f)
			{
				z0qtk.z0eek(p0, z0yrk(), z0zek());
			}
			else
			{
				z0qtk.z0eek(p0, z0yrk(), z0grk());
			}
		}
	}

	public float z0trk()
	{
		return z0crk;
	}

	private z0ZzZzudh z0yrk()
	{
		return z0vrk;
	}

	internal void z0uek(z0ZzZzjpk p0)
	{
		if (z0wtk != null && z0wtk != z0ZzZzkmk.z0yek)
		{
			if (z0trk() > 90f && z0trk() < 270f)
			{
				z0wtk.z0eek(p0, z0yrk(), z0grk());
			}
			else
			{
				z0wtk.z0eek(p0, z0yrk(), z0grk());
			}
		}
	}

	public object Clone()
	{
		z0ZzZzkyk obj = (z0ZzZzkyk)MemberwiseClone();
		obj.z0nrk = null;
		obj.z0utk = null;
		obj.z0gtk = null;
		obj.z0htk = null;
		obj.z0eek(z0mek());
		obj.z0yek(z0rrk());
		obj.z0eek(z0prk());
		obj.z0eek(z0krk());
		obj.z0yek(z0jrk());
		obj.z0eek(z0lrk());
		return obj;
	}

	internal void z0urk()
	{
		z0crk = z0eek(z0etk, z0rek_jiejie20260327142557().z0eek());
		z0ttk = z0dtk;
		if (z0ttk % 180f != 0f)
		{
			z0ttk = z0eek(z0etk + z0dtk, z0rek_jiejie20260327142557().z0eek()) - z0crk;
		}
		if (z0ttk < 0f)
		{
			z0ttk += 360f;
		}
	}

	internal virtual void z0irk()
	{
		Color color = z0eek();
		if (z0lrk())
		{
			color = z0ZzZzvok.z0eek(color, 0.3f);
		}
		if (z0mek().z0oek().z0zek().Color == Color.Transparent)
		{
			z0ZzZznmk z0ZzZznmk2 = z0mek().z0oek().z0zek().z0rek();
			z0ZzZznmk2.Color = color;
			z0vrk = z0ZzZznmk2.z0yek();
		}
		else
		{
			z0vrk = z0mek().z0oek().z0zek().z0yek();
		}
		z0htk = new z0ZzZzzdh(color);
		switch (z0mek().z0oek().z0xek())
		{
		case DrawingStyle.Default:
			z0gtk = (z0nrk = (z0htk = (z0utk = z0rek_jiejie20260327142557(color))));
			break;
		case DrawingStyle.Nomal:
			z0gtk = (z0nrk = (z0utk = new z0ZzZzzdh(z0ZzZzvok.z0eek(color, -0.3f))));
			break;
		}
	}

	internal void z0tek(z0ZzZztfh p0)
	{
		z0htk = p0;
	}

	public void z0rek_jiejie20260327142557(string p0)
	{
		z0ltk = p0;
	}

	internal void z0iek(z0ZzZzjpk p0)
	{
		if (z0rek_jiejie20260327142557().z0iek() > 0 && z0rek_jiejie20260327142557().z0oek() > 0)
		{
			p0.z0eek(z0wrk(), z0rek_jiejie20260327142557().z0yek(), z0rek_jiejie20260327142557().z0uek() + z0tek(), z0rek_jiejie20260327142557().z0iek(), z0rek_jiejie20260327142557().z0oek(), z0trk(), z0pek());
			p0.z0eek(z0yrk(), z0rek_jiejie20260327142557().z0yek(), z0rek_jiejie20260327142557().z0uek() + z0tek(), z0rek_jiejie20260327142557().z0iek(), z0rek_jiejie20260327142557().z0oek(), z0trk(), z0pek());
			z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
			z0ZzZznfh2.z0rek(z0rek_jiejie20260327142557().z0yek(), z0rek_jiejie20260327142557().z0uek() + z0tek(), z0rek_jiejie20260327142557().z0iek(), z0rek_jiejie20260327142557().z0oek(), z0trk(), z0pek());
			z0iek().Add(z0ZzZznfh2);
		}
	}

	public void z0eek(double p0)
	{
		z0ntk = p0;
	}

	internal void z0oek(z0ZzZzjpk p0)
	{
		z0bxk[] array = z0drk();
		for (int i = 0; i < array.Length; i++)
		{
			z0bxk z0bxk = array[i];
			z0eek(p0, z0yrk(), z0wrk(), z0bxk.z0eek(), z0bxk.z0rek(), z0bxk.z0tek_jiejie20260327142557(), z0bxk.z0yek());
		}
	}

	internal virtual z0ZzZzpdh z0ork()
	{
		if (z0pek() >= 180f)
		{
			return z0eek(z0jtk.z0rek(), z0jtk.z0tek(), z0rek_jiejie20260327142557().z0iek() / 3, z0rek_jiejie20260327142557().z0oek() / 3, z0uek(z0trk()) + z0pek() / 2f);
		}
		float num = (z0otk.z0rek() + z0ytk.z0rek()) / 2f;
		float p = (float)(Math.Atan2((z0otk.z0tek() + z0ytk.z0tek()) / 2f - z0jtk.z0tek(), num - z0jtk.z0rek()) * 180.0 / Math.PI);
		return z0eek(z0jtk.z0rek(), z0jtk.z0tek(), z0rek_jiejie20260327142557().z0iek() / 3, z0rek_jiejie20260327142557().z0oek() / 3, z0uek(p));
	}

	public double z0prk()
	{
		return z0ntk;
	}

	public void z0tek(float p0)
	{
		z0dtk = p0;
	}

	public void z0yek(float p0)
	{
		z0mtk = p0;
	}

	public void z0tek(string p0)
	{
		z0ftk = p0;
	}

	public Color z0mwk()
	{
		return z0krk();
	}

	public void Dispose()
	{
		z0rek_jiejie20260327142557(p0: true);
		GC.SuppressFinalize(this);
	}

	public void z0yek(string p0)
	{
		z0rtk = p0;
	}

	internal float z0uek(float p0)
	{
		double num = (double)z0rek_jiejie20260327142557().z0oek() * Math.Cos((double)p0 * Math.PI / 180.0);
		float num2 = (float)(Math.Atan2((double)z0rek_jiejie20260327142557().z0iek() * Math.Sin((double)p0 * Math.PI / 180.0), num) * 180.0 / Math.PI);
		if (num2 < 0f)
		{
			return num2 + 360f;
		}
		return num2;
	}
}
