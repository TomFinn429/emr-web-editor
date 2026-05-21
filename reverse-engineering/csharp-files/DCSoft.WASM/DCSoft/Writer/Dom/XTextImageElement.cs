using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XImage")]
public sealed class XTextImageElement : XTextObjectElement, IDisposable
{
	private new z0ZzZzpmk z0xrk;

	[NonSerialized]
	private new z0ZzZzpmk z0zrk;

	private new string z0ltk;

	internal new z0ZzZzdzj z0ktk;

	[NonSerialized]
	private new string z0jtk;

	[NonSerialized]
	internal new int z0htk = -1;

	[NonSerialized]
	private new int z0gtk;

	[ThreadStatic]
	internal new static object z0ftk;

	private new bool z0dtk = true;

	private new string z0stk;

	private new int z0atk = -1;

	private new z0ZzZzluj z0qtk;

	[NonSerialized]
	private new object z0wtk;

	public new static z0ZzZztyk z0etk;

	private new VerticalAlignStyle z0rtk = VerticalAlignStyle.Bottom;

	private new string z0ttk;

	private new ResizeableType z0ytk = ResizeableType.WidthAndHeight;

	[NonSerialized]
	private new z0ZzZzpmk z0utk;

	private new string z0itk;

	protected new z0ZzZzevj z0otk;

	[NonSerialized]
	[z0ZzZzuqh]
	private new z0ZzZzpmk z0ptk;

	private new byte[] z0mtk;

	private new Color z0ntk = Color.Transparent;

	private new string z0btk;

	private new float z0vtk;

	[z0ZzZzuqh]
	public z0ZzZzedh ImageValue
	{
		get
		{
			if (z0xrk == null)
			{
				return null;
			}
			return z0xrk.Value;
		}
		set
		{
			if (z0xrk == null)
			{
				z0xrk = new z0ZzZzpmk();
				z0xrk.z0eek(p0: false);
			}
			z0xrk.Value = value;
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override z0ZzZzxdh EditorSize
	{
		get
		{
			return base.EditorSize;
		}
		set
		{
			base.EditorSize = value;
			z0zek();
			z0qrk();
		}
	}

	[DefaultValue(true)]
	public bool EnableEditImageAdditionShape
	{
		get
		{
			return z0dtk;
		}
		set
		{
			z0dtk = value;
		}
	}

	[DefaultValue(VerticalAlignStyle.Bottom)]
	public VerticalAlignStyle VAlign
	{
		get
		{
			return z0rtk;
		}
		set
		{
			z0rtk = value;
		}
	}

	[DefaultValue(true)]
	public bool SaveContentInFile
	{
		get
		{
			return z0ryk();
		}
		set
		{
			base.z0iek(value);
		}
	}

	[DefaultValue(null)]
	public string TransparentColorValue
	{
		get
		{
			return z0ZzZzlok.z0eek(z0rek(), Color.Transparent);
		}
		set
		{
			z0eek(z0ZzZzlok.z0eek(value, Color.Transparent));
		}
	}

	[DefaultValue(null)]
	public z0ZzZzevj ValueBinding
	{
		get
		{
			return z0otk;
		}
		set
		{
			z0otk = value;
		}
	}

	[DefaultValue(true)]
	public bool SmoothZoom
	{
		get
		{
			return z0syk();
		}
		set
		{
			z0cek(value);
		}
	}

	[DefaultValue(true)]
	public bool KeepWidthHeightRate
	{
		get
		{
			return base.z0vrk();
		}
		set
		{
			z0ork(value);
			z0vek();
		}
	}

	public bool z0eek(string p0, bool p1)
	{
		if (z0xrk == null)
		{
			z0xrk = new z0ZzZzpmk();
		}
		z0xrk.z0eek(p0: false);
		if (z0xrk.Load(p0) > 0)
		{
			if (p1)
			{
				z0eek(p0: false);
			}
			return true;
		}
		return false;
	}

	public override string z0gy()
	{
		return string.Empty;
	}

	public void z0eek(int p0, z0ZzZzedh p1)
	{
		z0hrk().z0eek(p0, new z0ZzZzpmk(p1));
	}

	public new bool z0eek()
	{
		z0ZzZzluj z0ZzZzluj = z0brk();
		if (z0ZzZzluj != null && z0ZzZzluj.z0yek().Count > 0 && z0ZzZzluj.z0yek()[0].z0djk().Count > 0)
		{
			return true;
		}
		return false;
	}

	public override float z0xy()
	{
		return z0yek();
	}

	public new Color z0rek()
	{
		return z0ntk;
	}

	public void z0eek(string p0)
	{
		z0itk = p0;
	}

	public new string z0tek()
	{
		return z0btk;
	}

	public void z0eek(z0ZzZzpmk p0)
	{
		z0ptk = p0;
	}

	public void z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			z0qtk = null;
		}
		else
		{
			StringReader p1 = new StringReader(p0);
			z0qtk = new z0ZzZzluj();
			z0qtk.z0eek(p1);
			z0qtk.z0yek(p0: false);
		}
		z0qrk();
	}

	public new void z0eek(int p0)
	{
		z0htk = p0;
	}

	public override string z0pe()
	{
		return "image";
	}

	public new float z0yek()
	{
		return z0vtk;
	}

	public new void z0eek(bool p0)
	{
		if (z0frk().HasContent)
		{
			z0ZzZzxdh z0ZzZzxdh = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0xrk.Width, z0xrk.Height), GraphicsUnit.Pixel, GraphicsUnit.Document);
			if (z0ZzZzxdh.z0eek())
			{
				z0ZzZzxdh = new z0ZzZzxdh(100f, 100f);
			}
			bool flag = z0vek();
			if (p0 && flag)
			{
				return;
			}
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			if (p0)
			{
				if (z0oek() && (double)z0yek() > 0.01)
				{
					float num = 0f;
					num = ((z0ZzZzrzj != null) ? (((XTextElement)this).z0ork() / z0yek() + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk) : (Width / z0yek()));
					if (num != Height)
					{
						EditorSize = new z0ZzZzxdh(Width, num);
					}
				}
			}
			else if (z0ZzZzrzj == null)
			{
				EditorSize = new z0ZzZzxdh(z0ZzZzxdh.z0rek(), z0ZzZzxdh.z0tek());
			}
			else
			{
				EditorSize = new z0ZzZzxdh(z0ZzZzxdh.z0rek() + z0ZzZzrzj.z0ryk + z0ZzZzrzj.z0ptk, z0ZzZzxdh.z0tek() + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk);
			}
		}
		else
		{
			EditorSize = new z0ZzZzxdh(100f, 100f);
		}
	}

	private new bool z0uek()
	{
		return z0yyk();
	}

	public void z0rek(bool p0)
	{
		z0oek(p0);
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0fik);
		p0.z0eek(z0aik);
		p0.z0eek(z0btk);
		p0.z0eek(z0itk);
		p0.z0eek(z0ltk);
	}

	public override string ToString()
	{
		string text = "[IMG]";
		if (ID != null && ID.Length > 0)
		{
			text = text + "[ID:" + ID + "]";
		}
		if (z0frk() == null)
		{
			return text + "[NULL]";
		}
		return text + "[" + z0frk().ToString() + "]";
	}

	private void z0tek(bool p0)
	{
		z0zek(p0);
	}

	public new int z0iek()
	{
		return z0htk;
	}

	public new void z0yek(bool p0)
	{
		z0erk(p0);
	}

	public override VerticalAlignStyle z0ay()
	{
		return VAlign;
	}

	public new bool z0oek()
	{
		return KeepWidthHeightRate;
	}

	public void z0rek(z0ZzZzpmk p0)
	{
		z0xrk = p0;
		if (z0ptk != null)
		{
			z0ZzZzpmk z0ZzZzpmk = z0ptk;
			z0ptk = null;
			z0ZzZzpmk.Dispose();
		}
	}

	public new void z0uek(bool p0)
	{
		base.z0uek(p0);
	}

	public void z0tek(string p0)
	{
		z0ltk = p0;
		if (!string.IsNullOrEmpty(p0))
		{
			XTextTableElement.z0xtk = true;
		}
		if (z0zrk != null)
		{
			z0zrk.Dispose();
			z0zrk = null;
		}
		z0rrk();
		z0qrk();
		z0tek(p0: false);
		z0iek(p0: false);
	}

	public new void z0yek(string p0)
	{
		z0jtk = p0;
	}

	private bool z0pek_jiejie20260327142557()
	{
		return z0htk();
	}

	public new string z0mek()
	{
		return z0ltk;
	}

	public new z0ZzZzjuj z0nek()
	{
		return z0brk()?.z0mek();
	}

	public new z0ZzZzpmk z0bek()
	{
		if (SaveContentInFile)
		{
			return null;
		}
		return z0zrk;
	}

	private new bool z0vek()
	{
		float num = 0f;
		num = ((!z0oek() || z0xrk == null || z0xrk.Value == null || z0xrk.Height <= 0) ? 0f : ((float)z0xrk.Width / (float)z0xrk.Height));
		if (z0yek() != num)
		{
			z0eek(num);
			return true;
		}
		return false;
	}

	public new void z0uek(string p0)
	{
		z0btk = p0;
	}

	private new void z0iek(bool p0)
	{
		z0irk(p0);
	}

	public new int z0cek()
	{
		return z0atk;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0eek("[图片]");
	}

	public bool z0eek(z0ZzZzedh p0, bool p1)
	{
		if (p0 != null)
		{
			if (z0xrk == null)
			{
				z0xrk = new z0ZzZzpmk(p0);
			}
			else
			{
				z0xrk.Value = p0;
			}
			if (p1)
			{
				z0eek(p0: false);
			}
			return true;
		}
		return false;
	}

	public bool z0eek(z0ZzZzedh p0, bool p1, bool p2)
	{
		XTextDocument xTextDocument = z0jr();
		if (p2)
		{
			if (xTextDocument.z0ytk())
			{
				xTextDocument.z0imk().z0eek("ImageValue", p0, ImageValue, this);
				xTextDocument.z0imk().z0eek((z0ZzZzbzj)5);
			}
			ImageValue = p0;
		}
		if (p1)
		{
			z0jo();
		}
		return true;
	}

	public new void z0xek()
	{
		if (z0pek_jiejie20260327142557())
		{
			return;
		}
		string text = z0lrk();
		if (text == null || text.Length <= 0)
		{
			return;
		}
		byte[] array = z0ZzZzpmk.ParseEmitImageSource(text);
		if (array != null)
		{
			z0zrk = new z0ZzZzpmk(array);
			if (SaveContentInFile)
			{
				z0xrk = z0zrk;
			}
		}
		else if (z0cu()?.z0lh() != null)
		{
			z0tek(p0: true);
			z0iek(p0: true);
			z0cu().z0lh().z0alk(z0ltk, z0eek);
		}
	}

	public override void z0sy(ElementMouseEventArgs p0)
	{
		base.z0sy(p0);
		if (!p0.Handled && p0.Button == (z0ZzZzqeh)1 && !((XTextObjectElement)this).z0yek())
		{
			object obj = z0jr().z0yyk().z0eek("EditImageAdditionShape", p1: true, this);
			if (obj is bool && (bool)obj)
			{
				p0.Handled = true;
			}
		}
	}

	private new void z0zek()
	{
		float num = ((XTextElement)this).z0ork();
		float num2 = z0si();
		if (z0qtk == null || z0qtk.z0yek().Count <= 0)
		{
			return;
		}
		z0ZzZzjuj z0ZzZzjuj = (z0ZzZzjuj)z0qtk.z0yek()[0];
		if (z0ZzZzjuj.z0mek() != num || ((z0ZzZzeuj)z0ZzZzjuj).z0eek() != num2)
		{
			if (z0ZzZzjuj.z0mek() > 0f && ((z0ZzZzeuj)z0ZzZzjuj).z0eek() > 0f)
			{
				float p = num / z0ZzZzjuj.z0mek();
				float p2 = num2 / ((z0ZzZzeuj)z0ZzZzjuj).z0eek();
				z0ZzZzjuj.z0mkk(p, p2);
			}
			z0ZzZzjuj.z0yek(num);
			z0ZzZzjuj.z0eek(num2);
		}
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (z0stk != null && z0stk.Length > 0)
		{
			z0yek(z0stk, p0);
			return;
		}
		if (z0trk() && (z0xrk == null || !z0xrk.HasContent))
		{
			z0yek("正在下载图片 " + z0ltk, p0);
			return;
		}
		z0ZzZzpmk z0ZzZzpmk = null;
		z0ZzZzdzj z0ZzZzdzj = z0ktk;
		if (z0ZzZzdzj != null && z0ZzZzdzj.Count > 0)
		{
			z0ZzZzpmk z0ZzZzpmk2 = z0ZzZzdzj.z0rek(p0.z0oek());
			if (z0ZzZzpmk2 == null)
			{
				z0ZzZzpmk2 = z0prk();
			}
			if (z0ZzZzpmk2 != null)
			{
				z0ZzZzpmk = z0ZzZzpmk2;
			}
		}
		z0ZzZzbdh z0ZzZzbdh = p0.z0drk();
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh;
		z0ZzZzbdh2.z0rek(p0.z0nek());
		if (z0jr().z0qbk != null)
		{
			z0ZzZzpdh[] array = z0ZzZzdpk.z0eek(p0.z0gyk, z0ZzZzbdh);
			z0jr().z0qbk[this] = array;
		}
		if (z0ZzZzpmk != null)
		{
			z0eek(p0, z0ZzZzpmk);
			if (z0eek())
			{
				z0eek(p0);
			}
			return;
		}
		z0ZzZzpmk z0ZzZzpmk3 = z0prk();
		if (z0ZzZzpmk3.HasContent)
		{
			z0ZzZzpmk p1 = z0ZzZzpmk3;
			if (z0grk())
			{
				p0.z0guk?.z0eek(p0: true);
				z0eek(p0, p1);
				p0.z0guk?.z0eek(p0: false);
			}
			else
			{
				InterpolationMode p2 = p0.z0vek();
				z0ZzZzfdh p3 = p0.z0gyk.z0tek();
				p0.z0eek(InterpolationMode.NearestNeighbor);
				p0.z0gyk.z0eek((z0ZzZzfdh)4);
				z0eek(p0, p1);
				p0.z0eek(p2);
				p0.z0gyk.z0eek(p3);
			}
		}
		else
		{
			bool flag = true;
			if ((p0.z0byk == (z0ZzZzcxj)3 || p0.z0byk == (z0ZzZzcxj)2) && !z0iu().PrintImageAltText)
			{
				flag = false;
			}
			if (flag)
			{
				z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				string p4 = z0ZzZziok.z0qrk();
				if (!string.IsNullOrEmpty(z0tek()))
				{
					p4 = z0tek();
				}
				p0.z0gyk.z0eek(p4, new z0ZzZzimk(), Color.Red, z0ZzZzbdh, z0ZzZzlsh);
			}
		}
		if (z0eek())
		{
			z0eek(p0);
		}
	}

	public new string z0lrk()
	{
		return z0mek();
	}

	public override z0ZzZzonj z0qt()
	{
		z0ZzZzonj z0ZzZzonj = base.z0qt();
		if (z0ZzZzonj == null && !string.IsNullOrEmpty(z0vrk()))
		{
			z0ZzZzonj = new z0ZzZzonj(this, z0vrk());
			z0ZzZzonj.z0eek(ToolTipContentType.ElementToolTip);
		}
		return z0ZzZzonj;
	}

	public new byte[] z0krk()
	{
		return z0mtk;
	}

	public void z0eek(Color p0)
	{
		z0ntk = p0;
		z0rrk();
		z0qrk();
	}

	public new bool z0jrk()
	{
		return base.z0trk();
	}

	public new z0ZzZzdzj z0hrk()
	{
		return z0ktk;
	}

	public override void z0cy()
	{
		z0vek();
		base.z0cy();
	}

	public new bool z0grk()
	{
		return SmoothZoom;
	}

	public override bool z0vy(float p0, float p1, bool p2, bool p3)
	{
		bool num = base.z0vy(p0, p1, p2, p3);
		if (num)
		{
			z0zek();
			z0qrk();
		}
		return num;
	}

	public new z0ZzZzpmk z0frk()
	{
		if (z0ftk != null && z0htk >= 0)
		{
			return null;
		}
		if (z0xrk == null)
		{
			z0xrk = new z0ZzZzpmk();
			z0xrk.z0eek(p0: false);
		}
		if (z0jr() != null)
		{
			z0xrk.FormatBase64String = z0bu().OutputFormatedXMLSource;
		}
		return z0xrk;
	}

	public bool z0eek(byte[] p0, bool p1)
	{
		if (p0 != null && p0.Length != 0)
		{
			if (z0xrk == null)
			{
				z0xrk = new z0ZzZzpmk();
			}
			z0xrk.z0eek(p0: false);
			z0xrk.ImageData = p0;
			if (p1)
			{
				z0eek(p0: false);
			}
			return true;
		}
		return false;
	}

	private void z0eek(z0ZzZzdck p0)
	{
		z0iek(p0: false);
		z0zrk = null;
		if (string.IsNullOrEmpty(p0.z0eek))
		{
			z0stk = null;
		}
		else
		{
			z0stk = p0.z0eek;
		}
		if (p0.z0rek != null && p0.z0rek.Length != 0 && z0stk == null)
		{
			if (z0ZzZzrfh.z0eek(p0.z0rek, p1: false))
			{
				z0zrk = new z0ZzZzpmk(p0.z0rek);
				if (SaveContentInFile)
				{
					z0xrk = z0zrk;
				}
			}
			else
			{
				z0stk = "文件格式不对";
			}
		}
		z0jo();
	}

	public override z0ZzZzpmk z0by()
	{
		if (z0gtk != z0frk().ContentVersion)
		{
			z0qrk();
			z0gtk = z0frk().ContentVersion;
		}
		if (z0utk == null)
		{
			bool flag = false;
			if (z0eek())
			{
				flag = true;
			}
			else
			{
				z0ZzZzpmk z0ZzZzpmk = z0prk();
				if (z0ZzZzpmk != null && z0ZzZzpmk.HasContent && z0rek().A != 0)
				{
					flag = true;
				}
			}
			if (flag)
			{
				z0utk = z0ny();
				if (z0rek().A != 0 && z0utk.z0nek())
				{
					z0utk.MakeTransparent(z0rek());
				}
			}
		}
		return z0utk;
	}

	public new object z0drk()
	{
		return z0wtk;
	}

	public override void Dispose()
	{
		z0wtk = null;
		if (z0xrk != null)
		{
			if (z0xrk.ByteSize > 512000)
			{
				z0xrk.z0iek();
			}
			z0xrk.Dispose();
			z0xrk = null;
		}
		z0rrk();
		z0qrk();
	}

	public void z0eek(byte[] p0)
	{
		z0mtk = p0;
	}

	public override z0ZzZzpmk z0ny()
	{
		return z0prk()?.Clone();
	}

	public void z0eek(z0ZzZzdzj p0)
	{
		z0ktk = p0;
	}

	private void z0eek(z0ZzZzvxj p0)
	{
		z0ZzZzluj z0ZzZzluj = z0brk();
		if (z0ZzZzluj == null || z0ZzZzluj.z0yek().Count == 0)
		{
			return;
		}
		z0ZzZzjuj z0ZzZzjuj = (z0ZzZzjuj)z0ZzZzluj.z0yek()[0];
		z0ZzZzluj.z0sjk(p0.z0gyk);
		z0ZzZztuj z0ZzZztuj = new z0ZzZztuj();
		z0ZzZztuj.z0eek(p0.z0nek());
		z0ZzZztuj.z0eek(p0: false);
		z0ZzZztuj.z0eek(z0ZzZzluj);
		z0ZzZztuj.z0eek(z0ZzZzjuj);
		z0ZzZztuj.z0eek(p0.z0gyk);
		z0ZzZztuj.z0eek(new z0ZzZzruj());
		z0ZzZztuj.z0eek((z0ZzZzyuj)0);
		z0ZzZztuj.z0eek(z0ZzZzluj.z0iek().z0eek());
		z0ZzZztuj.z0eek(1f);
		object p1 = z0ZzZztuj.z0iek().z0bek();
		try
		{
			z0ZzZzjuj.z0tek(z0zrk());
			z0ZzZzjuj.z0rek(z0ltk());
			if (z0ZzZzjuj.z0djk() != null && z0ZzZzjuj.z0djk().Count > 0)
			{
				if (!z0jrk())
				{
					if (Width != z0ZzZzjuj.z0mek() || Height != ((z0ZzZzeuj)z0ZzZzjuj).z0eek())
					{
						z0ZzZztuj.z0iek().z0eek(Width / z0ZzZzjuj.z0mek(), Height / ((z0ZzZzeuj)z0ZzZzjuj).z0eek());
					}
					z0ZzZzjuj.z0fjk(z0ZzZztuj);
				}
				else
				{
					z0ZzZzjuj.z0fjk(z0ZzZztuj);
				}
			}
		}
		finally
		{
			if (z0ZzZzjuj is z0ZzZzkuj)
			{
				((z0ZzZzkuj)z0ZzZzjuj).z0eek(null);
			}
			z0ZzZzjuj.z0tek(0f);
			z0ZzZzjuj.z0rek(0f);
		}
		z0ZzZztuj.z0iek().z0eek(p1);
		z0ZzZzluj.Dispose();
	}

	public new string z0srk()
	{
		return z0jtk;
	}

	public override string z0ge()
	{
		return "Image:" + ID;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
	}

	public XTextImageElement()
	{
		KeepWidthHeightRate = true;
		SaveContentInFile = true;
		SmoothZoom = true;
	}

	public override void z0tu(string p0)
	{
		if (z0xrk == null)
		{
			z0xrk = z0ptk;
		}
		if (z0qtk != null)
		{
			z0qtk.z0pek();
		}
	}

	public new string z0ark()
	{
		return null;
	}

	private new void z0qrk()
	{
		if (z0utk != null)
		{
			z0utk.Dispose();
			z0utk = null;
		}
	}

	private void z0eek(z0ZzZzvxj p0, z0ZzZzpmk p1)
	{
		if (p1 != null)
		{
			z0ZzZzbdh p2 = p0.z0drk();
			z0ZzZzbdh p3 = z0ZzZzbdh.z0tek(p2, p0.z0nek());
			if (z0ci() == ElementZOrderStyle.Normal && z0aek().z0xyk == ContentLayoutAlign.EmbedInText)
			{
				p3.z0rek(z0ptk().z0krk());
			}
			z0ZzZzpdh p4 = p3.z0eek();
			p3.z0eek(p3.z0tek() - p2.z0tek());
			p3.z0rek(p3.z0yek() - p2.z0yek());
			z0ZzZzbdh z0ZzZzbdh = new z0ZzZzbdh(0f, 0f, p1.Width, p1.Height);
			z0ZzZzbdh p5 = new z0ZzZzbdh((float)Math.Round(z0ZzZzbdh.z0uek() * p3.z0tek() / p2.z0uek(), 3), (float)Math.Round(z0ZzZzbdh.z0iek() * p3.z0yek() / p2.z0iek(), 3), (float)Math.Round(z0ZzZzbdh.z0uek() * p3.z0uek() / p2.z0uek(), 3), (float)Math.Round(z0ZzZzbdh.z0iek() * p3.z0iek() / p2.z0iek(), 3));
			p3.z0eek(p4);
			InterpolationMode imageInterpolationMode = p0.z0rtk.ImageInterpolationMode;
			if (imageInterpolationMode != InterpolationMode.Invalid)
			{
				p0.z0rek(imageInterpolationMode);
			}
			p0.z0gyk.z0eek(p1, p3, p5, GraphicsUnit.Pixel);
		}
	}

	public new bool z0wrk()
	{
		return z0uek();
	}

	public void z0eek(int p0, string p1)
	{
		z0ZzZzpmk z0ZzZzpmk = new z0ZzZzpmk();
		z0ZzZzpmk.z0eek(p0: false);
		z0ZzZzpmk.LoadBase64String(p1);
		z0hrk().z0eek(p0, z0ZzZzpmk);
	}

	public override string z0xr()
	{
		return ToString();
	}

	public void z0eek(z0ZzZzluj p0)
	{
		z0qtk = p0;
		z0qrk();
	}

	public new string z0erk()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (z0ktk != null)
		{
			foreach (z0ZzZzfzj item in z0ktk)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.AppendLine();
				}
				stringBuilder.Append(item.z0tek() + "=" + item.z0eek());
			}
		}
		return stringBuilder.ToString();
	}

	public void z0iek(string p0)
	{
		z0ttk = p0;
	}

	private new void z0rrk()
	{
		if (z0ptk != null)
		{
			z0ptk.Dispose();
			z0ptk = null;
		}
	}

	public void z0rek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			if (z0xrk != null)
			{
				z0xrk.Dispose();
				z0xrk = null;
			}
			return;
		}
		if (z0xrk == null)
		{
			z0xrk = new z0ZzZzpmk();
			z0xrk.z0eek(p0: false);
		}
		z0xrk.ImageData = p0;
	}

	private new bool z0trk()
	{
		return z0jtk();
	}

	public void z0eek(int p0, z0ZzZzpmk p1)
	{
		z0hrk().z0eek(p0, p1);
	}

	public new string z0yrk()
	{
		return z0ttk;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		z0xek();
		float num = 20000f;
		float num2 = 20000f;
		XPageSettings xPageSettings = z0jr()?.PageSettings;
		if (xPageSettings != null)
		{
			num = xPageSettings.z0drk() * 5f;
			num2 = xPageSettings.z0qrk() * 5f;
		}
		if (!(Width > num) && !(Height > num2))
		{
			return;
		}
		if (z0frk() != null && z0frk().HasContent)
		{
			float num3 = (float)z0frk().Width / (float)z0frk().Height;
			if (Width < num)
			{
				Height = Width / num3;
			}
			else if (Height < num2)
			{
				Width = Height * num3;
			}
		}
		else
		{
			if (Width > num)
			{
				Width = num;
			}
			if (Height > num2)
			{
				Height = num2;
			}
		}
	}

	public new bool z0urk()
	{
		return z0cyk();
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextImageElement xTextImageElement = (XTextImageElement)base.z0lr(p0);
		if (z0qtk != null)
		{
			xTextImageElement.z0qtk = (z0ZzZzluj)z0qtk.z0gjk(p0: true);
		}
		if (z0utk != null)
		{
			xTextImageElement.z0utk = z0utk.Clone();
		}
		if (z0ptk != null)
		{
			xTextImageElement.z0ptk = z0ptk.Clone();
		}
		if (z0ktk != null)
		{
			xTextImageElement.z0ktk = z0ktk.z0eek();
		}
		if (z0xrk != null)
		{
			xTextImageElement.z0xrk = z0xrk.Clone();
		}
		return xTextImageElement;
	}

	internal new bool z0irk()
	{
		if (z0mrk() && z0cek() >= 0)
		{
			XTextDocument xTextDocument = z0jr();
			if (xTextDocument != null && xTextDocument.z0nmk() != null && xTextDocument.z0nmk().Count > 0)
			{
				RepeatedImageValue byValueIndex = xTextDocument.z0nmk().GetByValueIndex(z0cek());
				if (byValueIndex != null && byValueIndex.HasContent)
				{
					z0rek(byValueIndex.Clone());
					z0pek_jiejie20260327142557(p0: false);
					z0rek(-1);
					return true;
				}
			}
		}
		z0pek_jiejie20260327142557(p0: false);
		z0rek(-1);
		return false;
	}

	public new void z0eek(object p0)
	{
		z0wtk = p0;
	}

	public new byte[] z0ork()
	{
		if (z0xrk == null)
		{
			return null;
		}
		return z0xrk.ImageData;
	}

	public new z0ZzZzpmk z0prk()
	{
		if (z0mrk())
		{
			z0ZzZzpmk byValueIndex = z0jr().z0nmk().GetByValueIndex(z0cek());
			if (byValueIndex != null)
			{
				if (byValueIndex.z0nek() && z0rek().A != 0)
				{
					if (z0ptk == null)
					{
						byValueIndex = byValueIndex.Clone();
						byValueIndex.MakeTransparent(z0rek());
						z0ptk = byValueIndex;
					}
					return z0ptk;
				}
				return byValueIndex;
			}
		}
		if (z0ptk == null)
		{
			z0ZzZzpmk z0ZzZzpmk = z0bek();
			if (z0ZzZzpmk == null)
			{
				z0ZzZzpmk = z0frk();
			}
			if (z0rek().A != 0)
			{
				if (z0ptk == null && z0ZzZzpmk.z0nek())
				{
					z0ZzZzpmk = z0ZzZzpmk.Clone();
					z0ZzZzpmk.MakeTransparent(z0rek());
					z0ptk = z0ZzZzpmk;
				}
				else
				{
					z0ptk = z0ZzZzpmk;
				}
				return z0ptk;
			}
			return z0ZzZzpmk;
		}
		return z0ptk;
	}

	public new bool z0mrk()
	{
		return z0rtk();
	}

	public override ResizeableType z0wt()
	{
		if (((XTextObjectElement)this).z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0ytk;
	}

	public new int z0nrk()
	{
		if (z0xrk == null)
		{
			return 0;
		}
		return z0xrk.ByteSize;
	}

	private new void z0oek(bool p0)
	{
		z0frk(p0);
	}

	public override void z0et(ResizeableType p0)
	{
		z0ytk = p0;
	}

	public new z0ZzZzluj z0brk()
	{
		if (z0qtk != null)
		{
			((z0ZzZzxyj)z0qtk).z0eek();
			z0qtk.z0tek(p0: true);
		}
		if (z0qtk != null && z0qtk.z0yek().Count > 0 && z0qtk.z0yek()[0] is z0ZzZzkuj)
		{
			((z0ZzZzkuj)z0qtk.z0yek()[0]).z0eek(null);
		}
		return z0qtk;
	}

	public void z0rek(int p0)
	{
		if (z0atk != p0)
		{
			z0atk = p0;
			z0rrk();
			z0qrk();
		}
	}

	public new string z0vrk()
	{
		return z0itk;
	}

	public void z0eek(float p0)
	{
		z0vtk = p0;
	}

	public bool z0rek(string p0, bool p1)
	{
		if (p0 != null && p0.Length > 0)
		{
			if (z0xrk == null)
			{
				z0xrk = new z0ZzZzpmk();
			}
			z0xrk.z0eek(p0: false);
			z0xrk.LoadBase64String(p0);
			if (p1)
			{
				z0eek(p0: false);
			}
			return true;
		}
		return false;
	}

	internal new string z0crk()
	{
		if (z0stk != null && z0stk.Length > 0)
		{
			return z0stk;
		}
		return z0itk;
	}

	public void z0pek_jiejie20260327142557(bool p0)
	{
		z0ark(p0);
		if (p0)
		{
			RepeatedImageValueList.z0rek = true;
		}
	}
}
