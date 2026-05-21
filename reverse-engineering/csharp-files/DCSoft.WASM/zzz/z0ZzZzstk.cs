using System;
using System.Collections.Generic;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzstk : ICloneable
{
	private double z0ark = 100.0;

	[NonSerialized]
	private z0ZzZzbdh z0qrk = z0ZzZzbdh.z0xek;

	private Color z0wrk = Color.Black;

	private bool z0erk;

	[NonSerialized]
	private double z0rrk;

	private float z0trk = 100f;

	[NonSerialized]
	private double z0yrk = 100.0;

	private double z0urk = 10.0;

	private RangeCalculateStyle z0irk;

	private z0ZzZzimk z0ork = new z0ZzZzimk();

	private string z0prk;

	internal List<string> z0mrk;

	private string z0nrk;

	private bool z0brk = true;

	private double z0vrk;

	private ContentAlignment z0crk = ContentAlignment.MiddleCenter;

	internal double z0eek()
	{
		return z0rrk;
	}

	internal double z0rek()
	{
		return z0yrk;
	}

	public z0ZzZzbdh z0tek()
	{
		return z0qrk;
	}

	private z0ZzZzbmk z0yek()
	{
		return new z0ZzZzbmk
		{
			Font = z0vek(),
			Alignment = z0nek(),
			Color = z0frk()
		};
	}

	public void z0eek(RangeCalculateStyle p0)
	{
		z0irk = p0;
	}

	internal z0ZzZzbdh z0uek()
	{
		return new z0ZzZzbdh(z0qrk.z0oek(), z0qrk.z0pek(), z0qrk.z0uek(), z0qrk.z0iek());
	}

	public void z0eek(double p0)
	{
		z0ark = p0;
	}

	public string z0iek()
	{
		return z0nrk;
	}

	public RangeCalculateStyle z0oek()
	{
		return z0irk;
	}

	public void z0eek(string p0)
	{
		z0prk = p0;
	}

	public void z0eek(ContentAlignment p0)
	{
		z0crk = p0;
	}

	public void z0rek(double p0)
	{
		z0vrk = p0;
	}

	public double z0pek()
	{
		return z0urk;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		z0ork = p0;
	}

	public string z0mek()
	{
		return z0prk;
	}

	public void z0rek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0mrk = new List<string>();
			string[] array = p0.Split(',');
			if (array.Length != 0)
			{
				string[] array2 = array;
				foreach (string text in array2)
				{
					z0mrk.Add(text);
				}
			}
			else
			{
				z0mrk.Add(p0);
			}
		}
		else
		{
			z0mrk = null;
		}
	}

	public ContentAlignment z0nek()
	{
		return z0crk;
	}

	public bool z0bek()
	{
		if (z0erk)
		{
			return z0trk > 0f;
		}
		return false;
	}

	public z0ZzZzimk z0vek()
	{
		return z0ork;
	}

	public double z0cek()
	{
		return z0ark;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		z0yek().z0rek(p0, z0iek(), z0uek());
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0qrk = p0;
	}

	public bool z0xek()
	{
		return z0brk;
	}

	public bool z0zek()
	{
		if (z0nrk != null)
		{
			return z0nrk.Length > 0;
		}
		return false;
	}

	public z0ZzZzstk z0lrk()
	{
		return (z0ZzZzstk)((ICloneable)this).Clone();
	}

	public string z0krk()
	{
		return z0ZzZzlok.z0eek(z0frk(), Color.Black);
	}

	public bool z0jrk()
	{
		return z0erk;
	}

	public void z0rek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		z0yek().z0eek(p0, z0iek(), z0uek());
	}

	public void z0eek(Color p0)
	{
		z0wrk = p0;
	}

	public void z0eek(bool p0)
	{
		z0erk = p0;
	}

	public double z0hrk()
	{
		return z0vrk;
	}

	public void z0tek(double p0)
	{
		z0urk = p0;
	}

	internal void z0yek(double p0)
	{
		z0yrk = p0;
	}

	internal void z0uek(double p0)
	{
		z0rrk = p0;
	}

	private object z0grk()
	{
		z0ZzZzstk obj = new z0ZzZzstk();
		obj.z0erk = z0erk;
		obj.z0trk = z0trk;
		obj.z0crk = z0crk;
		obj.z0wrk = z0wrk;
		obj.z0ork = z0ork.Clone();
		obj.z0nrk = z0nrk;
		obj.z0urk = z0urk;
		obj.z0brk = z0brk;
		obj.z0irk = z0irk;
		obj.z0ark = z0ark;
		obj.z0vrk = z0vrk;
		obj.z0prk = z0prk;
		obj.z0rek(z0srk());
		return obj;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0grk
		return this.z0grk();
	}

	public Color z0frk()
	{
		return z0wrk;
	}

	public float z0drk()
	{
		return z0trk;
	}

	public string z0srk()
	{
		if (z0mrk == null || z0mrk.Count == 0)
		{
			return string.Empty;
		}
		string text = string.Empty;
		for (int i = 0; i < z0mrk.Count; i++)
		{
			text = ((i != z0mrk.Count - 1) ? (text + z0mrk[i] + ",") : (text + z0mrk[i]));
		}
		return text;
	}

	public void z0rek(bool p0)
	{
		z0brk = p0;
	}

	public void z0eek(float p0)
	{
		z0trk = p0;
	}

	public void z0tek(string p0)
	{
		z0nrk = p0;
	}

	public z0ZzZzbdh z0rek(z0ZzZzbdh p0)
	{
		if (z0bek())
		{
			z0qrk = new z0ZzZzbdh(p0.z0oek(), p0.z0pek(), p0.z0uek(), z0drk());
			return new z0ZzZzbdh(p0.z0oek(), p0.z0pek() + z0drk(), p0.z0uek(), p0.z0iek() - z0drk());
		}
		return p0;
	}

	public void z0yek(string p0)
	{
		z0wrk = z0ZzZzlok.z0eek(p0, Color.Black);
	}
}
