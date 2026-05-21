using System;
using System.ComponentModel;
using System.Text;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XSignImage")]
public sealed class XTextSignImageElement : XTextObjectElement, IDisposable
{
	private new bool z0pek = true;

	private new string z0mek;

	private new string z0nek;

	[NonSerialized]
	private new int z0bek = -1;

	private new static z0ZzZzrfh z0vek;

	private new byte[] z0cek;

	private new DCSignValidateState z0xek;

	private new z0ZzZzpmk z0zek;

	private new string z0lrk;

	private new DCCASignMode z0krk = DCCASignMode.Normal;

	private new bool z0jrk;

	private new string z0hrk;

	private new byte[] z0grk;

	private new string z0frk;

	private new DateTime z0drk = z0ZzZzkfh.z0wrk;

	private byte[] z0srk_jiejie20260327142557;

	private new ResizeableType z0ark = ResizeableType.WidthAndHeight;

	private new static bool z0qrk;

	private DCSignRange z0wrk_jiejie20260327142557 = DCSignRange.Parent;

	private new string z0erk;

	private new string z0rrk;

	public override float Height
	{
		get
		{
			return base.Height;
		}
		set
		{
			base.Height = value;
			z0ktk();
		}
	}

	[DefaultValue(DCCASignMode.Normal)]
	[z0ZzZztqh]
	public DCCASignMode DefaultSignMode
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[z0ZzZztqh]
	public DateTime SignTime
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = z0ZzZzuyk.z0eek(value);
		}
	}

	[DefaultValue(true)]
	public bool SmoothZoom
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	public override float Width
	{
		get
		{
			return base.Width;
		}
		set
		{
			_ = base.Width;
			base.Width = value;
			z0ktk();
		}
	}

	[DefaultValue(null)]
	public string SignUserID
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string SignErrorMessage
	{
		get
		{
			return z0hrk;
		}
		set
		{
			z0hrk = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(DCSignRange.Parent)]
	public DCSignRange SignRange
	{
		get
		{
			return z0wrk_jiejie20260327142557;
		}
		set
		{
			z0wrk_jiejie20260327142557 = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string SignProviderName
	{
		get
		{
			return z0erk;
		}
		set
		{
			z0erk = value;
		}
	}

	public byte[] ImageData
	{
		get
		{
			return z0srk_jiejie20260327142557;
		}
		set
		{
			LoadImageDataUseTransparentColor(value, Color.Empty);
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string SignUserName
	{
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string SignClientName
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	public byte[] DataForSelfCheck
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	public DCSignValidateState SignState
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	[DefaultValue(null)]
	public byte[] LastVerifyResult
	{
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	[z0ZzZzuqh]
	public z0ZzZzpmk ImageValue
	{
		get
		{
			if (z0zek == null && z0srk_jiejie20260327142557 != null && z0srk_jiejie20260327142557.Length != 0)
			{
				z0zek = new z0ZzZzpmk(z0srk_jiejie20260327142557);
			}
			return z0zek;
		}
	}

	[DefaultValue(false)]
	[z0ZzZztqh]
	public bool UseInnerSignProvider
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	[DefaultValue(null)]
	public string Title
	{
		get
		{
			return z0rrk;
		}
		set
		{
			z0rrk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string SignMessage
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextSignImageElement xTextSignImageElement = (XTextSignImageElement)base.z0lr(p0);
		if (z0zek != null)
		{
			xTextSignImageElement.z0zek = z0zek.Clone();
		}
		if (z0srk_jiejie20260327142557 != null)
		{
			xTextSignImageElement.z0srk_jiejie20260327142557 = new byte[z0srk_jiejie20260327142557.Length];
			Array.Copy(z0srk_jiejie20260327142557, xTextSignImageElement.z0srk_jiejie20260327142557, z0srk_jiejie20260327142557.Length);
		}
		if (z0cek != null)
		{
			xTextSignImageElement.z0cek = new byte[z0cek.Length];
			Array.Copy(z0cek, xTextSignImageElement.z0cek, z0cek.Length);
		}
		if (z0grk != null)
		{
			xTextSignImageElement.z0grk = new byte[z0grk.Length];
			Array.Copy(z0grk, xTextSignImageElement.z0grk, z0grk.Length);
		}
		return xTextSignImageElement;
	}

	private new bool z0eek()
	{
		XTextContainerElement xTextContainerElement = z0yek();
		if (xTextContainerElement != null && xTextContainerElement.z0kek() != z0iek())
		{
			if (SignState == DCSignValidateState.Validate || SignState == DCSignValidateState.ValidateBySoftOnly)
			{
				SignState = DCSignValidateState.Invalidate;
			}
			else
			{
				SignState = DCSignValidateState.NotDetect;
			}
			return false;
		}
		return true;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
	}

	public void ClearSign()
	{
		XTextContainerElement xTextContainerElement = z0yek();
		if (xTextContainerElement != null)
		{
			z0bek = xTextContainerElement.z0kek();
		}
		z0mek = null;
		z0hrk = null;
		z0nek = null;
		z0erk = null;
		z0xek = DCSignValidateState.NotDetect;
		z0drk = z0ZzZzkfh.z0wrk;
		z0lrk = null;
		z0frk = null;
		z0jrk = false;
		z0grk = null;
		z0cek = null;
		z0tek();
		z0srk_jiejie20260327142557 = null;
	}

	public new void z0rek()
	{
		if (ImageValue != null)
		{
			z0ZzZzpmk imageValue = ImageValue;
			if (z0jr() == null)
			{
				z0ZzZzcdh z0ZzZzcdh = imageValue.ConvertSize(GraphicsUnit.Document);
				Width = z0ZzZzcdh.z0rek();
				Height = z0ZzZzcdh.z0tek();
			}
			else
			{
				z0ZzZzcdh z0ZzZzcdh2 = imageValue.ConvertSize(GraphicsUnit.Document);
				Width = z0ZzZzcdh2.z0rek();
				Height = z0ZzZzcdh2.z0tek();
			}
		}
	}

	public override string z0ge()
	{
		return "SignImage:" + ID;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		if (!p0.z0rek)
		{
			base.z0rt(p0);
			z0ZzZzdfh.z0rek().z0ad(this);
			if (ImageValue != null)
			{
				z0oek();
			}
		}
	}

	public XTextSignImageElement()
	{
		z0qrk = true;
	}

	public bool HasImageContent()
	{
		if (z0srk_jiejie20260327142557 != null)
		{
			return z0srk_jiejie20260327142557.Length != 0;
		}
		return false;
	}

	public override void z0et(ResizeableType p0)
	{
		z0ark = p0;
	}

	private new void z0tek()
	{
		if (z0zek != null)
		{
			z0zek.Dispose();
			z0zek = null;
		}
	}

	public override ResizeableType z0wt()
	{
		if (((XTextObjectElement)this).z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0ark;
	}

	public new void z0eek(int p0)
	{
		z0bek = p0;
	}

	public override string ToString()
	{
		if (z0srk_jiejie20260327142557 == null || z0srk_jiejie20260327142557.Length == 0)
		{
			return "[SignIMG Null]";
		}
		return "[SignIMG" + z0srk_jiejie20260327142557.Length + " B]";
	}

	public new XTextContainerElement z0yek()
	{
		if (SignRange == DCSignRange.Document)
		{
			return z0jr();
		}
		if (SignRange == DCSignRange.None)
		{
			return null;
		}
		if (SignRange == DCSignRange.Parent)
		{
			return z0ji();
		}
		for (XTextContainerElement xTextContainerElement = z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
		{
			switch (SignRange)
			{
			case DCSignRange.Body:
				if (xTextContainerElement is XTextDocumentBodyElement)
				{
					return xTextContainerElement;
				}
				break;
			case DCSignRange.InputField:
				if (xTextContainerElement is XTextInputFieldElement)
				{
					return xTextContainerElement;
				}
				break;
			case DCSignRange.Section:
				if (xTextContainerElement is XTextSectionElement)
				{
					return xTextContainerElement;
				}
				break;
			case DCSignRange.Table:
				if (xTextContainerElement is XTextTableElement)
				{
					return xTextContainerElement;
				}
				break;
			case DCSignRange.TableCell:
				if (xTextContainerElement is XTextTableCellElement)
				{
					return xTextContainerElement;
				}
				break;
			case DCSignRange.TableRow:
				if (xTextContainerElement is XTextTableRowElement)
				{
					return xTextContainerElement;
				}
				break;
			}
		}
		return null;
	}

	public bool LoadImageData(byte[] bs)
	{
		return LoadImageDataUseTransparentColor(bs, Color.Empty);
	}

	internal new static bool z0uek()
	{
		return z0qrk;
	}

	public bool LoadImageBase64(string base64)
	{
		if (string.IsNullOrEmpty(base64))
		{
			return LoadImageDataUseTransparentColor(null, Color.Empty);
		}
		byte[] bs = Convert.FromBase64String(base64);
		return LoadImageDataUseTransparentColor(bs, Color.Empty);
	}

	public bool LoadImageBase64UseTransparentColor(string base64, Color transparentColor)
	{
		if (string.IsNullOrEmpty(base64))
		{
			return LoadImageDataUseTransparentColor(null, Color.Empty);
		}
		byte[] bs = Convert.FromBase64String(base64);
		return LoadImageDataUseTransparentColor(bs, transparentColor);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ZzZzbdh z0ZzZzbdh = p0.z0drk();
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh;
		z0ZzZzbdh2.z0rek(p0.z0nek());
		if (z0jr().z0qbk != null)
		{
			z0ZzZzpdh[] array = z0ZzZzdpk.z0eek(p0.z0gyk, z0ZzZzbdh);
			z0jr().z0qbk[this] = array;
		}
		if (z0yek() == null)
		{
			using (z0ZzZzzdh p1 = new z0ZzZzzdh(Color.FromArgb(80, Color.Red)))
			{
				p0.z0gyk.z0rek(p1, p0.z0drk());
			}
			using (z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh())
			{
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				p0.z0gyk.z0rek("空白签名图片", new z0ZzZzimk(), Color.Yellow, p0.z0drk(), z0ZzZzlsh);
				p0.z0gyk.z0eek("空白签名图片", new z0ZzZzimk(), Color.Black, p0.z0drk(), z0ZzZzlsh);
			}
			p0.z0gyk.z0rek(z0ZzZzidh.z0iek, p0.z0drk());
			return;
		}
		if (!z0eek())
		{
			if (z0cu() == null || string.IsNullOrEmpty(SignProviderName) || !z0ZzZzdfh.z0rek().z0pd(SignProviderName))
			{
				z0ZzZzdfh.z0rek().z0ad(this);
			}
			else
			{
				z0ZzZzdfh.z0rek().z0ad(this);
				z0jo();
			}
		}
		DocumentSecurityOptions documentSecurityOptions = z0hi();
		z0ZzZzpmk z0ZzZzpmk = null;
		bool flag = documentSecurityOptions.CAMode == DCCAMode.Disabled;
		z0ZzZzpmk = ((SignState != DCSignValidateState.NotDetect || flag) ? ImageValue : null);
		if (z0ZzZzpmk != null)
		{
			z0ZzZzbdh p2 = p0.z0drk();
			float num = (float)z0ZzZzpmk.Width / (float)z0ZzZzpmk.Height;
			if (num > p2.z0uek() / p2.z0iek())
			{
				float num2 = p2.z0uek() / num;
				p2.z0rek(p2.z0yek() + (p2.z0iek() - num2) / 2f);
				p2.z0yek(num2);
			}
			else
			{
				float num3 = p2.z0iek() * num;
				p2.z0eek(p2.z0tek() + (p2.z0uek() - num3) / 2f);
				p2.z0tek(num3);
			}
			_ = z0ZzZzbdh.z0xek;
			InterpolationMode p3 = p0.z0vek();
			z0ZzZzfdh p4 = p0.z0gyk.z0tek();
			p0.z0eek(InterpolationMode.NearestNeighbor);
			p0.z0gyk.z0eek((z0ZzZzfdh)4);
			bool p5 = p0.z0gyk.z0pek();
			p0.z0gyk.z0rek(p0: false);
			try
			{
				z0eek(p0, z0ZzZzpmk, p2);
			}
			finally
			{
				p0.z0gyk.z0rek(p5);
			}
			if (flag)
			{
				return;
			}
			p0.z0eek(p3);
			p0.z0gyk.z0eek(p4);
			if (SignState == DCSignValidateState.ValidateBySoftOnly && documentSecurityOptions.ShowFlagForOnlySoftwareSign)
			{
				if (z0vek == null)
				{
					z0vek = z0ZzZzpmk.z0eek((object)z0ZzZzgfh.z0rek);
				}
				p0.z0gyk.z0eek(z0vek, p0.z0drk().z0oek(), p0.z0drk().z0pek());
			}
		}
		if (SignState == DCSignValidateState.Invalidate || SignState == DCSignValidateState.NotDetect || SignState == DCSignValidateState.NotSupportFormat || flag)
		{
			p0.z0gyk.z0eek(z0ZzZzgfh.z0eek, p0.z0drk().z0oek(), p0.z0drk().z0pek());
		}
	}

	public bool Resign()
	{
		return z0ZzZzdfh.z0rek().z0yd(this, DCCASignMode.Default);
	}

	public new int z0iek()
	{
		return z0bek;
	}

	public override z0ZzZzonj z0qt()
	{
		if (z0jr() != null && z0hi().CAMode == DCCAMode.Disabled)
		{
			z0ZzZzonj z0ZzZzonj = new z0ZzZzonj();
			z0ZzZzonj.z0rek(z0ZzZziok.z0vrk());
			return z0ZzZzonj;
		}
		z0ZzZzonj z0ZzZzonj2 = new z0ZzZzonj();
		bool flag = false;
		if (z0cu() != null)
		{
			WriterGetSignToolTipEventArgs e = new WriterGetSignToolTipEventArgs(z0cu(), z0jr(), z0yek(), this);
			z0cu().z0eek(e);
			if (e.Handled)
			{
				z0ZzZzonj2.z0rek(e.ResultTooltip);
				flag = true;
			}
		}
		if (!flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (SignState == DCSignValidateState.ValidateBySoftOnly)
			{
				stringBuilder.AppendLine("通过软件验证，未经硬件验证。");
			}
			if (string.IsNullOrEmpty(Title))
			{
				stringBuilder.AppendLine("ID:" + SignUserID);
				stringBuilder.AppendLine("Name:" + SignUserName);
				stringBuilder.AppendLine("Time:" + SignTime.ToString(z0ZzZzkfh.z0qrk));
				stringBuilder.AppendLine("Client:" + SignClientName);
			}
			else
			{
				stringBuilder.Append(Title);
			}
			z0ZzZzonj2.z0rek(stringBuilder.ToString().Trim());
		}
		return z0ZzZzonj2;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0tek();
		z0grk = null;
		z0mek = null;
		z0hrk = null;
		z0nek = null;
		z0erk = null;
		z0lrk = null;
		z0frk = null;
		z0rrk = null;
		z0srk_jiejie20260327142557 = null;
		z0cek = null;
	}

	private z0ZzZzbdh z0eek(z0ZzZzvxj p0, z0ZzZzpmk p1, z0ZzZzbdh p2)
	{
		if (p2.z0bek())
		{
			p2 = p0.z0drk();
		}
		z0ZzZzbdh p3 = z0ZzZzbdh.z0tek(p2, p0.z0nek());
		if (z0ci() == ElementZOrderStyle.Normal && z0aek().z0xyk == ContentLayoutAlign.EmbedInText)
		{
			p3.z0rek(z0ptk().z0krk());
		}
		z0ZzZzpdh p4 = p3.z0eek();
		p3.z0eek(p3.z0tek() - p2.z0tek());
		p3.z0rek(p3.z0yek() - p2.z0yek());
		z0ZzZzbdh z0ZzZzbdh = new z0ZzZzbdh(0f, 0f, p1.Width, p1.Height);
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh((float)Math.Round(z0ZzZzbdh.z0uek() * p3.z0tek() / p2.z0uek(), 3), (float)Math.Round(z0ZzZzbdh.z0iek() * p3.z0yek() / p2.z0iek(), 3), (float)Math.Round(z0ZzZzbdh.z0uek() * p3.z0uek() / p2.z0uek(), 3), (float)Math.Round(z0ZzZzbdh.z0iek() * p3.z0iek() / p2.z0iek(), 3));
		p3.z0eek(p4);
		InterpolationMode imageInterpolationMode = z0iu().ImageInterpolationMode;
		if (imageInterpolationMode != InterpolationMode.Invalid)
		{
			p0.z0eek(imageInterpolationMode);
		}
		if (z0pek)
		{
			p0.z0guk?.z0eek(p0: true);
		}
		p0.z0gyk.z0eek(p1, p3, z0ZzZzbdh2, GraphicsUnit.Pixel);
		if (z0pek)
		{
			p0.z0guk?.z0eek(p0: false);
		}
		return z0ZzZzbdh2;
	}

	public new void z0oek()
	{
	}

	public bool LoadImageDataUseTransparentColor(byte[] bs, Color transparentColor)
	{
		z0tek();
		z0srk_jiejie20260327142557 = bs;
		if (transparentColor.A == 0)
		{
			z0srk_jiejie20260327142557 = bs;
		}
		else if (bs != null && bs.Length != 0)
		{
			z0ZzZzpmk z0ZzZzpmk = new z0ZzZzpmk(bs);
			if (z0ZzZzpmk.z0nek())
			{
				z0ZzZzpmk.MakeTransparent(transparentColor);
			}
			z0zek = z0ZzZzpmk;
		}
		return true;
	}

	public override string z0pe()
	{
		return "signImage";
	}
}
