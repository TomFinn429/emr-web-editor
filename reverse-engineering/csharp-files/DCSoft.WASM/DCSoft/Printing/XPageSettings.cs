using System;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using DCSystem_Drawing.Printing;
using zzz;

namespace DCSoft.Printing;

public class XPageSettings : ICloneable, IDisposable
{
	private bool z0lyk;

	private bool z0kyk;

	[NonSerialized]
	private z0ZzZzsrj z0jyk;

	private float z0hyk;

	private bool z0gyk = true;

	private string z0fyk;

	private float z0dyk;

	private int z0syk;

	[NonSerialized]
	private z0ZzZzsrj z0ayk;

	private z0ZzZzfpk z0qyk;

	private bool z0wyk;

	private int z0eyk = 827;

	private bool z0ryk;

	private bool z0yyk;

	private string z0uyk;

	private int z0iyk = 1;

	private bool z0oyk;

	public static bool z0pyk;

	private z0ZzZzwmk z0myk;

	private PaperKind z0nyk = PaperKind.A4;

	private float z0byk = 1f;

	private int z0vyk = 50;

	private int z0cyk = 1169;

	private DCDuplexType z0xyk_jiejie20260327142557;

	private bool z0zyk = true;

	private float z0luk;

	private bool z0kuk;

	private DCGutterStyle z0juk;

	private int z0huk;

	private int z0guk = 1;

	private z0ZzZzvpk z0fuk;

	private bool z0duk = true;

	private int z0suk = 50;

	private string z0auk;

	private bool z0quk;

	private bool z0wuk;

	[NonSerialized]
	private z0ZzZzsrj z0euk;

	[NonSerialized]
	private z0ZzZzmdh z0ruk;

	private z0ZzZzzej z0tuk;

	private z0ZzZzpmk z0yuk;

	private string z0uuk;

	private string z0iuk;

	[DefaultValue(null)]
	public z0ZzZzzej DocumentGridLine
	{
		get
		{
			return z0tuk;
		}
		set
		{
			z0tuk = value;
		}
	}

	[DefaultValue(100)]
	public int BottomMargin
	{
		get
		{
			if (z0ruk == null)
			{
				return 100;
			}
			return z0ruk.z0eek_jiejie20260327142557();
		}
		set
		{
			z0htk_jiejie20260327142557().z0rek(value);
		}
	}

	[DefaultValue(100)]
	public int LeftMargin
	{
		get
		{
			if (z0ruk == null)
			{
				return 100;
			}
			return z0ruk.z0yek();
		}
		set
		{
			z0htk_jiejie20260327142557().z0tek(value);
		}
	}

	[DefaultValue(null)]
	public z0ZzZzvpk PageBorderBackground
	{
		get
		{
			return z0fuk;
		}
		set
		{
			z0fuk = value;
		}
	}

	[DefaultValue(100)]
	public int TopMargin
	{
		get
		{
			if (z0ruk == null)
			{
				return 100;
			}
			return z0ruk.z0tek();
		}
		set
		{
			z0htk_jiejie20260327142557().z0eek_jiejie20260327142557(value);
		}
	}

	[DefaultValue(100)]
	public int RightMargin
	{
		get
		{
			if (z0ruk == null)
			{
				return 100;
			}
			return z0ruk.z0uek();
		}
		set
		{
			z0htk_jiejie20260327142557().z0yek(value);
		}
	}

	public string z0eek()
	{
		if (string.IsNullOrEmpty(z0uyk))
		{
			return null;
		}
		if (z0yek(256))
		{
			return z0uyk;
		}
		return null;
	}

	public void z0eek(z0ZzZzfpk p0)
	{
		z0qyk = p0;
	}

	public bool z0eek(int p0)
	{
		if (!z0mek())
		{
			return false;
		}
		string text = z0eek();
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (z0ayk == null)
		{
			z0ayk = new z0ZzZzsrj(text);
		}
		if (z0ayk.z0eek(p0))
		{
			return false;
		}
		return true;
	}

	public void z0eek(DCDuplexType p0)
	{
		z0xyk_jiejie20260327142557 = p0;
	}

	public void z0eek(bool p0)
	{
		z0ryk = p0;
	}

	public z0ZzZzwmk z0rek()
	{
		if (z0myk != null)
		{
			if (!z0yek(32768) && z0myk.Type == WatermarkType.Text)
			{
				return null;
			}
			if (!z0yek(65536) && z0myk.Type == WatermarkType.Image)
			{
				return null;
			}
		}
		return z0myk;
	}

	public void z0rek(bool p0)
	{
		z0zyk = p0;
	}

	public bool z0tek()
	{
		return z0duk;
	}

	public void z0rek(int p0)
	{
		z0uek(p0);
		z0cyk = p0;
	}

	public bool z0eek(int p0, bool p1)
	{
		if (p1)
		{
			if (z0jyk == null)
			{
				z0jyk = new z0ZzZzsrj(z0fyk);
			}
			if (z0jyk.z0eek(p0))
			{
				return true;
			}
		}
		else
		{
			if (z0euk == null)
			{
				z0euk = new z0ZzZzsrj(z0uuk);
			}
			if (z0euk.z0eek(p0))
			{
				return true;
			}
		}
		return false;
	}

	public void z0eek(float p0)
	{
		LeftMargin = (int)(z0ZzZzrpk.z0tek(p0, GraphicsUnit.Inch) * 100f);
	}

	public bool z0yek()
	{
		return z0wyk;
	}

	public bool z0uek()
	{
		return z0lyk;
	}

	public float z0iek()
	{
		return z0ZzZzrpk.z0rek((float)RightMargin / 100f, GraphicsUnit.Inch);
	}

	public z0ZzZzudh z0oek()
	{
		return z0ZzZzdpk.z0eek(Color.Black, 1f, DashStyle.Dash);
	}

	public int z0pek()
	{
		return z0vyk;
	}

	public bool z0mek()
	{
		return z0zyk;
	}

	public bool z0nek()
	{
		return z0gyk;
	}

	public float z0bek()
	{
		return (float)TopMargin * 3f;
	}

	public void z0tek(int p0)
	{
		z0guk = p0;
	}

	public bool z0vek()
	{
		return z0ryk;
	}

	public void z0rek(float p0)
	{
		z0luk = p0;
	}

	public string z0cek()
	{
		return z0auk;
	}

	public z0ZzZzfpk z0xek()
	{
		return z0qyk;
	}

	public float z0zek()
	{
		return z0byk;
	}

	public bool z0lrk()
	{
		if (z0kyk)
		{
			return z0yek(1024);
		}
		return false;
	}

	public z0ZzZzvpk z0krk_jiejie20260327142557()
	{
		if (z0fuk != null && z0yek(128))
		{
			return z0fuk;
		}
		return null;
	}

	public z0ZzZzwmk z0jrk()
	{
		return z0myk;
	}

	private bool z0yek(int p0)
	{
		return true;
	}

	public void z0eek(string p0)
	{
		z0uuk = p0;
		z0euk = null;
	}

	public float z0hrk()
	{
		if (z0dyk > 0f && z0yek(1024))
		{
			return z0dyk * 3f;
		}
		return 0f;
	}

	public int z0grk()
	{
		if (z0iyk > 0 && z0iyk < 10)
		{
			return z0iyk;
		}
		return 1;
	}

	public void z0eek(PaperKind p0)
	{
		z0nyk = p0;
	}

	public float z0frk()
	{
		if (z0mek())
		{
			return (float)(BottomMargin - z0suk) * 3f;
		}
		return 0f;
	}

	public float z0drk()
	{
		return (float)(z0oyk ? z0jtk() : z0ntk()) * 3f;
	}

	public void z0tek(bool p0)
	{
		z0lyk = p0;
	}

	public float z0srk()
	{
		return z0luk;
	}

	public z0ZzZzpmk z0ark()
	{
		return z0yuk;
	}

	public float z0qrk()
	{
		return (float)(z0ork() ? z0ntk() : z0jtk()) * 3f;
	}

	public float z0wrk()
	{
		return z0ZzZzrpk.z0rek((float)TopMargin / 100f, GraphicsUnit.Inch);
	}

	public void z0eek(z0ZzZzwmk p0)
	{
		z0myk = p0;
	}

	public float z0erk()
	{
		return z0dyk;
	}

	public bool z0rrk()
	{
		if (z0wuk)
		{
			return z0yek(131072);
		}
		return false;
	}

	public void z0yek(bool p0)
	{
		z0wyk = p0;
	}

	public void z0uek(bool p0)
	{
		z0duk = p0;
	}

	public void z0tek(float p0)
	{
		z0dyk = p0;
	}

	public void z0iek(bool p0)
	{
		z0gyk = p0;
	}

	public z0ZzZzfpk z0trk()
	{
		if (z0qyk != null)
		{
			if (z0qyk.z0oek_jiejie20260327142557() && !z0yek(4096))
			{
				return null;
			}
			if (z0qyk.z0iek() && !z0yek(8192))
			{
				return null;
			}
			if (z0qyk.z0tek() && !z0yek(16384))
			{
				return null;
			}
			if (z0qyk.z0nek() && !z0yek(2048))
			{
				return null;
			}
		}
		return z0qyk;
	}

	public void z0oek(bool p0)
	{
		z0kyk = p0;
	}

	public PaperKind z0yrk()
	{
		return z0nyk;
	}

	public void z0uek(int p0)
	{
		z0syk = p0;
	}

	public string z0urk()
	{
		return z0uyk;
	}

	public string z0irk()
	{
		return z0fyk;
	}

	public void z0iek(int p0)
	{
		z0suk = p0;
	}

	public bool z0ork()
	{
		return z0oyk;
	}

	public float z0prk()
	{
		float num = (float)((z0oyk ? z0jtk() : z0ntk()) - LeftMargin - RightMargin) * 3f;
		float num2 = z0hrk();
		if (num2 > 0f && (z0juk == DCGutterStyle.Left || z0juk == DCGutterStyle.Right))
		{
			num -= num2;
		}
		return num;
	}

	public float z0mrk()
	{
		float num = (float)((z0ork() ? z0ntk() : z0jtk()) - TopMargin - BottomMargin) * 3f;
		float num2 = z0hrk();
		if (num2 > 0f && z0xtk() == DCGutterStyle.Top)
		{
			num -= num2;
		}
		return num;
	}

	public void Dispose()
	{
		if (z0qyk != null)
		{
			z0qyk = null;
		}
		if (z0yuk != null)
		{
			z0yuk.Dispose();
			z0yuk = null;
		}
		if (z0myk != null)
		{
			z0myk.Dispose();
			z0myk = null;
		}
		if (z0fuk != null)
		{
			z0fuk.Dispose();
			z0fuk = null;
		}
		if (z0ayk != null)
		{
			z0ayk.z0eek();
			z0ayk = null;
		}
		if (z0euk != null)
		{
			z0euk.z0eek();
			z0euk = null;
		}
		if (z0jyk != null)
		{
			z0jyk.z0eek();
			z0jyk = null;
		}
	}

	public bool z0nrk()
	{
		return z0iyk > 1;
	}

	public void z0rek(string p0)
	{
		z0auk = p0;
	}

	public int z0brk()
	{
		return z0guk;
	}

	public void z0pek(bool p0)
	{
		z0oyk = p0;
	}

	public void z0eek(DCGutterStyle p0)
	{
		z0juk = p0;
	}

	public string z0vrk()
	{
		return z0iuk;
	}

	public void z0eek(z0ZzZzmdh p0)
	{
		z0ruk = p0;
	}

	public int z0crk()
	{
		return z0syk;
	}

	public void z0yek(float p0)
	{
		BottomMargin = (int)(z0ZzZzrpk.z0tek(p0, GraphicsUnit.Inch) * 100f);
	}

	public void z0uek(float p0)
	{
		TopMargin = (int)(z0ZzZzrpk.z0tek(p0, GraphicsUnit.Inch) * 100f);
	}

	public float z0xrk()
	{
		return (float)RightMargin * 3f;
	}

	public DCDuplexType z0zrk()
	{
		return z0xyk_jiejie20260327142557;
	}

	public bool z0ltk()
	{
		return z0kuk;
	}

	public bool z0ktk()
	{
		return z0wuk;
	}

	public void z0mek(bool p0)
	{
		z0wuk = p0;
	}

	public int z0jtk()
	{
		if (z0nyk != PaperKind.Custom)
		{
			z0ZzZzcdh z0ZzZzcdh = z0ZzZzamk.z0eek(z0nyk);
			if (!z0ZzZzcdh.z0eek())
			{
				return z0ZzZzcdh.z0tek();
			}
		}
		return z0cyk;
	}

	public void z0iek(float p0)
	{
		z0hyk = p0;
	}

	public z0ZzZzmdh z0htk_jiejie20260327142557()
	{
		if (z0ruk == null)
		{
			z0ruk = new z0ZzZzmdh(100, 100, 100, 100);
		}
		return z0ruk;
	}

	public void z0eek(XPageSettings p0)
	{
		if (p0 != null)
		{
			p0.z0eek(z0zrk());
			p0.z0nyk = z0nyk;
			p0.z0eyk = z0eyk;
			p0.z0cyk = z0cyk;
			p0.z0ryk = z0ryk;
			p0.z0ruk = (z0ZzZzmdh)z0htk_jiejie20260327142557().z0rek();
			p0.z0oyk = z0oyk;
			p0.z0auk = z0auk;
			p0.z0iuk = z0iuk;
			p0.z0kuk = z0kuk;
			p0.z0wyk = z0wyk;
			p0.z0vyk = z0vyk;
			p0.z0suk = z0suk;
			p0.z0hyk = z0hyk;
			p0.z0luk = z0luk;
			p0.z0uyk = z0uyk;
			p0.z0ayk = null;
			p0.z0wuk = z0wuk;
			if (z0yuk != null)
			{
				p0.z0yuk = z0yuk.Clone();
			}
			if (z0fuk != null)
			{
				p0.z0fuk = (z0ZzZzvpk)z0fuk.Clone();
			}
			p0.z0uuk = z0uuk;
			p0.z0fyk = z0fyk;
			if (z0myk != null)
			{
				p0.z0myk = z0myk.Clone();
			}
			if (z0qyk != null)
			{
				p0.z0qyk = z0qyk.z0vek();
			}
			p0.z0duk = z0duk;
			if (z0tuk != null)
			{
				p0.z0tuk = z0tuk.z0pek();
			}
			p0.z0zyk = z0zyk;
			p0.z0kyk = z0kyk;
			p0.z0dyk = z0dyk;
			p0.z0juk = z0juk;
			p0.z0yyk = z0yyk;
			p0.z0gyk = z0gyk;
			p0.z0quk = z0quk;
			p0.z0byk = z0byk;
			p0.z0lyk = z0lyk;
			p0.z0iyk = z0iyk;
		}
	}

	public void z0oek(float p0)
	{
		int p1 = (int)((double)p0 / 3.0);
		if (z0ork())
		{
			z0oek(p1);
		}
		else
		{
			z0rek(p1);
		}
	}

	static XPageSettings()
	{
		z0pyk = true;
	}

	public void z0oek(int p0)
	{
		z0nek(p0);
		z0eyk = p0;
	}

	public void z0tek(string p0)
	{
		z0fyk = p0;
		z0jyk = null;
	}

	public float z0gtk()
	{
		return z0hyk;
	}

	public bool z0ftk()
	{
		return z0quk;
	}

	public z0ZzZzzej z0dtk()
	{
		if (z0tuk != null && z0yek(8))
		{
			return z0tuk;
		}
		return null;
	}

	public float z0stk()
	{
		if (z0mek())
		{
			return (float)z0utk() * 3f;
		}
		return 0f;
	}

	public void z0eek(z0ZzZzpmk p0)
	{
		z0yuk = p0;
	}

	public void z0nek(bool p0)
	{
		z0yyk = p0;
	}

	public float z0atk()
	{
		if (z0mek())
		{
			return (float)z0pek() * 3f;
		}
		return 0f;
	}

	public float z0qtk()
	{
		return (float)BottomMargin * 3f;
	}

	public XPageSettings z0wtk()
	{
		return (XPageSettings)((ICloneable)this).Clone();
	}

	public float z0etk()
	{
		return z0ZzZzrpk.z0rek((float)BottomMargin / 100f, GraphicsUnit.Inch);
	}

	public int z0rtk()
	{
		return z0huk;
	}

	public void z0pek(float p0)
	{
		RightMargin = (int)(z0ZzZzrpk.z0tek(p0, GraphicsUnit.Inch) * 100f);
	}

	public float z0ttk()
	{
		if (z0dyk > 0f && z0yek(1024))
		{
			return z0dyk;
		}
		return 0f;
	}

	public z0ZzZzcdh z0ytk()
	{
		if (z0nyk != PaperKind.Custom)
		{
			z0ZzZzcdh result = z0ZzZzamk.z0eek(z0nyk);
			if (!result.z0eek())
			{
				return result;
			}
		}
		return new z0ZzZzcdh(z0eyk, z0cyk);
	}

	public int z0utk()
	{
		return z0suk;
	}

	public bool z0itk()
	{
		return z0kyk;
	}

	public bool z0otk()
	{
		return z0yyk;
	}

	public z0ZzZzxdh z0ptk()
	{
		z0ZzZzcdh z0ZzZzcdh = z0ytk();
		float num = 3f;
		if (z0ork())
		{
			return new z0ZzZzxdh((float)z0ZzZzcdh.z0tek() * num, (float)z0ZzZzcdh.z0rek() * num);
		}
		return new z0ZzZzxdh((float)z0ZzZzcdh.z0rek() * num, (float)z0ZzZzcdh.z0tek() * num);
	}

	public void z0bek(bool p0)
	{
		z0kuk = p0;
	}

	public string z0mtk()
	{
		return z0uuk;
	}

	public void z0yek(string p0)
	{
		z0iuk = p0;
	}

	public int z0ntk()
	{
		if (z0nyk != PaperKind.Custom)
		{
			z0ZzZzcdh z0ZzZzcdh = z0ZzZzamk.z0eek(z0nyk);
			if (!z0ZzZzcdh.z0eek())
			{
				return z0ZzZzcdh.z0rek();
			}
		}
		return z0eyk;
	}

	public void z0pek(int p0)
	{
		if (p0 >= 1 && z0iyk < 10)
		{
			z0iyk = p0;
		}
		else
		{
			z0iyk = 1;
		}
	}

	private object z0btk()
	{
		XPageSettings xPageSettings = new XPageSettings();
		z0eek(xPageSettings);
		return xPageSettings;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0btk
		return this.z0btk();
	}

	public void z0mek(float p0)
	{
		z0byk = p0;
	}

	public void z0mek(int p0)
	{
		z0vyk = p0;
		if (z0vyk < 0)
		{
			z0vyk = 0;
		}
	}

	public float z0vtk()
	{
		return (float)LeftMargin * 3f;
	}

	public float z0ctk()
	{
		return z0ZzZzrpk.z0rek((float)LeftMargin / 100f, GraphicsUnit.Inch);
	}

	public void z0vek(bool p0)
	{
		z0quk = p0;
	}

	public void z0uek(string p0)
	{
		z0uyk = p0;
		z0ayk = null;
	}

	public DCGutterStyle z0xtk()
	{
		return z0juk;
	}

	public void z0eek(int p0, int p1, bool p2)
	{
		z0pek(p2);
		foreach (PaperKind value in Enum.GetValues(typeof(PaperKind)))
		{
			z0ZzZzcdh z0ZzZzcdh = z0ZzZzamk.z0eek(value);
			if (z0ZzZzcdh.z0eek())
			{
				continue;
			}
			if (p2)
			{
				if ((double)Math.Abs(z0ZzZzcdh.z0rek() - p1) < (double)z0ZzZzcdh.z0rek() * 0.02 && (double)Math.Abs(z0ZzZzcdh.z0tek() - p0) < (double)z0ZzZzcdh.z0tek() * 0.02)
				{
					z0eek(value);
					return;
				}
			}
			else if ((double)Math.Abs(z0ZzZzcdh.z0rek() - p0) < (double)z0ZzZzcdh.z0rek() * 0.02 && (double)Math.Abs(z0ZzZzcdh.z0tek() - p1) < (double)z0ZzZzcdh.z0tek() * 0.02)
			{
				z0eek(value);
				return;
			}
		}
		z0eek(PaperKind.Custom);
		if (p2)
		{
			z0oek(p1);
			z0rek(p0);
		}
		else
		{
			z0oek(p0);
			z0rek(p1);
		}
	}

	public float z0ztk()
	{
		z0mek();
		return (float)(TopMargin - z0pek()) * 3f;
	}

	public void z0nek(int p0)
	{
		z0huk = p0;
	}
}
