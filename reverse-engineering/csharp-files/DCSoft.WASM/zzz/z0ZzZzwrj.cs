using System;
using DCSoft.Printing;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzwrj
{
	private bool z0xrk;

	private float z0zrk;

	internal bool z0ltk;

	private bool z0ktk;

	public z0ZzZzarj z0jtk;

	private bool z0htk;

	private float z0ftk;

	public z0ZzZzmdh z0dtk = new z0ZzZzmdh();

	private float z0stk;

	[NonSerialized]
	private z0ZzZzjrj z0atk;

	internal float z0qtk;

	private z0ZzZzerj z0wtk;

	public static readonly z0ZzZzwrj z0etk = new z0ZzZzwrj();

	private XPageSettings z0rtk;

	private z0ZzZzmdh z0ttk;

	private int z0ytk;

	private z0ZzZzbdh z0utk = z0ZzZzbdh.z0xek;

	private float z0itk;

	private bool z0otk;

	private float z0ptk = -1f;

	private XTextElement[] z0mtk;

	public z0ZzZzndh z0ntk = z0ZzZzndh.z0cek;

	private float z0btk;

	internal z0ZzZzndh z0vtk = z0ZzZzndh.z0cek;

	public z0ZzZzbdh z0eek()
	{
		return new z0ZzZzbdh(0f, z0irk(), z0stk, z0itk);
	}

	public void z0rek()
	{
		if (z0mtk != null)
		{
			Array.Clear(z0mtk);
			z0mtk = null;
		}
		z0ttk = null;
		z0jtk = null;
		z0dtk = null;
		z0atk = null;
		z0wtk = null;
		z0rtk = null;
	}

	public void z0eek(int p0, int p1, int p2, int p3)
	{
		z0vtk = new z0ZzZzndh(p0, p1, p2, p3);
	}

	public void z0eek(int p0)
	{
		if (p0 != z0ytk)
		{
			z0ytk = p0;
		}
	}

	public float z0tek()
	{
		return z0ftk;
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0utk = p0;
	}

	public void z0eek(float p0)
	{
		z0ftk = p0;
	}

	public bool z0yek()
	{
		return z0ktk;
	}

	private z0ZzZzwrj()
	{
	}

	public void z0rek(float p0)
	{
		z0zrk = p0;
	}

	public void z0eek(z0ZzZzmdh p0)
	{
		z0ttk = p0;
	}

	public void z0eek(z0ZzZzjrj p0)
	{
		z0atk = p0;
	}

	public void z0eek(z0ZzZzndh p0)
	{
		z0vtk = p0;
	}

	public XTextElement[] z0uek()
	{
		return z0mtk;
	}

	public void z0eek(XPageSettings p0)
	{
		z0rtk = p0;
	}

	private void z0iek()
	{
		if (z0itk < (float)z0wtk.z0rek())
		{
			z0itk = z0wtk.z0rek();
		}
		if (!z0trk().z0vek())
		{
			float num = z0urk();
			if (z0itk > num)
			{
				z0itk = num;
			}
		}
	}

	public float z0oek()
	{
		return z0stk;
	}

	public z0ZzZzwrj z0pek()
	{
		z0ZzZzwrj obj = new z0ZzZzwrj();
		obj.z0xrk = true;
		obj.z0atk = z0atk;
		obj.z0rtk = z0rtk;
		obj.z0ftk = 0f;
		obj.z0iek(z0oek());
		return obj;
	}

	public float z0mek_jiejie20260327142557()
	{
		return (float)z0vrk().z0eek_jiejie20260327142557() * 3f;
	}

	public void z0rek(z0ZzZzndh p0)
	{
		z0vtk = p0;
	}

	private float z0nek()
	{
		float num = z0wtk.z0uek();
		foreach (z0ZzZzwrj item in z0wtk)
		{
			if (item == this)
			{
				break;
			}
			num += item.z0xek();
		}
		return num;
	}

	public void z0eek(z0ZzZzerj p0)
	{
		z0wtk = p0;
		if (z0wtk != null && z0itk < (float)z0wtk.z0rek())
		{
			z0itk = z0wtk.z0rek();
		}
	}

	public float z0bek()
	{
		return 0f;
	}

	public int z0vek()
	{
		return z0ytk;
	}

	public bool z0cek()
	{
		return z0htk;
	}

	public float z0xek()
	{
		return z0itk;
	}

	public z0ZzZzwrj z0zek()
	{
		return (z0ZzZzwrj)MemberwiseClone();
	}

	public void z0lrk()
	{
		z0ptk = z0nek();
	}

	public z0ZzZzbdh z0krk()
	{
		return z0utk;
	}

	public float z0jrk()
	{
		return z0rtk.z0mrk() - z0btk - z0zrk;
	}

	public void z0eek(bool p0)
	{
		z0otk = p0;
	}

	public float z0hrk()
	{
		return (float)z0vrk().z0yek() * 3f;
	}

	public z0ZzZzerj z0grk_jiejie20260327142557()
	{
		return z0wtk;
	}

	public float z0frk()
	{
		return (float)z0vrk().z0tek() * 3f;
	}

	public z0ZzZzmdh z0drk()
	{
		return z0ttk;
	}

	public z0ZzZzjrj z0srk()
	{
		return z0atk;
	}

	public void z0tek(float p0)
	{
		z0itk = p0 - z0ptk;
		z0iek();
	}

	public bool z0ark()
	{
		if (this == z0etk)
		{
			return true;
		}
		return z0xrk;
	}

	public float z0qrk()
	{
		return z0ptk + z0itk;
	}

	public void z0rek(bool p0)
	{
		z0xrk = p0;
	}

	public void z0yek(float p0)
	{
		z0itk = p0;
		z0iek();
	}

	public float z0wrk()
	{
		return z0zrk;
	}

	public void z0uek(float p0)
	{
		z0btk = p0;
	}

	public void z0tek(z0ZzZzndh p0)
	{
		if (!p0.z0vek())
		{
			if (z0ntk.z0vek())
			{
				z0ntk = p0;
			}
			else
			{
				z0ntk = z0ZzZzndh.z0yek(z0ntk, p0);
			}
		}
	}

	public z0ZzZzndh z0erk()
	{
		return z0vtk;
	}

	public float z0rrk()
	{
		return z0rtk.z0drk();
	}

	public XPageSettings z0trk()
	{
		return z0rtk;
	}

	public void z0tek(bool p0)
	{
		z0ktk = p0;
	}

	public float z0yrk()
	{
		XPageSettings xPageSettings = z0trk();
		float num = xPageSettings.z0bek();
		if (xPageSettings.z0mek())
		{
			float num2 = xPageSettings.z0atk() + z0prk();
			return Math.Max(num, num2);
		}
		return num;
	}

	public void z0eek(XTextElement[] p0)
	{
		z0mtk = p0;
	}

	public float z0urk()
	{
		XPageSettings xPageSettings = z0trk();
		float num = xPageSettings.z0mrk();
		if (xPageSettings.z0mek())
		{
			if (z0prk() > xPageSettings.z0ztk())
			{
				num -= z0prk() - xPageSettings.z0ztk();
			}
			if (z0wrk() > xPageSettings.z0frk())
			{
				num -= z0wrk() - xPageSettings.z0frk();
			}
		}
		return num;
	}

	public float z0irk()
	{
		return z0ptk;
	}

	public void z0yek(bool p0)
	{
		z0htk = p0;
	}

	public float z0ork()
	{
		return (float)z0vrk().z0uek() * 3f;
	}

	public float z0prk()
	{
		return z0btk;
	}

	public bool z0mrk()
	{
		return z0otk;
	}

	public bool z0nrk()
	{
		if (z0mtk != null)
		{
			return z0mtk.Length != 0;
		}
		return false;
	}

	public void z0iek(float p0)
	{
		z0stk = p0;
	}

	public int z0brk()
	{
		if (z0wtk == null)
		{
			return -1;
		}
		return z0wtk.IndexOf(this);
	}

	public z0ZzZzmdh z0vrk()
	{
		if (z0ttk != null)
		{
			return z0ttk;
		}
		return z0rtk.z0htk_jiejie20260327142557();
	}

	public z0ZzZzwrj(z0ZzZzjrj p0, XPageSettings p1, z0ZzZzerj p2, float p3, float p4)
	{
		z0atk = p0;
		z0rtk = p1;
		z0wtk = p2;
		z0btk = p3;
		z0zrk = p4;
		z0stk = (int)z0rtk.z0prk();
		z0itk = z0jrk() - 10f;
		z0lrk();
	}

	public float z0crk()
	{
		return z0rtk.z0qrk();
	}

	public void z0oek(float p0)
	{
		z0itk = p0;
	}
}
