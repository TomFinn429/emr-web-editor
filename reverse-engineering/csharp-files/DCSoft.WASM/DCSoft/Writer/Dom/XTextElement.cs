using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("Element")]
public abstract class XTextElement : IDisposable
{
	public sealed class z0ygj
	{
		public bool z0yek = true;

		public bool z0uek;

		private StringBuilder z0iek;

		public bool z0oek;

		public bool z0pek;

		public override string ToString()
		{
			return z0iek.ToString();
		}

		public int z0eek()
		{
			return z0iek.Length;
		}

		public void z0eek(string p0)
		{
			if (p0 != null && p0.Length > 0)
			{
				z0iek.Append(p0);
			}
		}

		internal StringBuilder z0rek_jiejie20260327142557()
		{
			return z0iek;
		}

		public z0ygj(XTextDocument p0, bool p1 = false, bool p2 = false, int p3 = 0)
		{
			z0pek = p1;
			z0oek = p2;
			z0uek = p0?.z0vtk().BehaviorOptions.OutputFieldBorderTextToContentText ?? true;
			if (p3 > 0)
			{
				z0iek = new StringBuilder(p3);
			}
			else
			{
				z0iek = new StringBuilder();
			}
		}

		public void z0tek()
		{
			z0iek.AppendLine();
		}

		public void z0eek(char p0)
		{
			z0iek.Append(p0);
		}
	}

	[CompilerGenerated]
	private sealed class z0myk
	{
		public static Action<XTextTableCellElement> z0rek;

		public static readonly z0myk z0tek_jiejie20260327142557 = new z0myk();

		internal void z0eek(XTextTableCellElement p0)
		{
			p0.z0gu();
			p0.Width = 0f;
			p0.Height = 0f;
			p0.z0au(z0oik);
		}
	}

	[CompilerGenerated]
	private sealed class z0sik
	{
		public bool z0rek;

		internal void z0eek(XTextTableCellElement p0)
		{
			if (!p0.z0yi())
			{
				return;
			}
			IList<XTextElement> list = p0.z0xe();
			if (list == null)
			{
				return;
			}
			foreach (XTextElement item in list)
			{
				z0yek(item, z0rek);
			}
		}
	}

	private static readonly int z0wuk = Color.White.ToArgb();

	internal static bool z0euk = false;

	[NonSerialized]
	internal z0ZzZzrzj z0ruk;

	[NonSerialized]
	internal int z0tuk = -1;

	[NonSerialized]
	internal int z0muk = -1;

	protected internal int z0buk = -1;

	[NonSerialized]
	protected internal bool z0cuk = true;

	[NonSerialized]
	internal int z0xuk = -1;

	internal static readonly XTextElement[] z0zuk = Array.Empty<XTextElement>();

	[NonSerialized]
	internal z0ZzZzzlh z0kik;

	internal float z0fik;

	[NonSerialized]
	protected DocumentContentStyle z0sik;

	protected internal float z0aik;

	[NonSerialized]
	internal float z0wik;

	[NonSerialized]
	protected XTextDocument z0rik;

	[NonSerialized]
	internal XTextContainerElement z0uik;

	private int z0iik = 3;

	private static XTextContentElement.z0lgj z0oik = null;

	[NonSerialized]
	internal float z0xik;

	public static readonly string z0lok = "$dc$";

	internal static int z0fok = 0;

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[z0ZzZzuqh]
	public virtual string FormulaValue
	{
		get
		{
			return Text;
		}
		set
		{
			Text = z0uek(value);
		}
	}

	[z0ZzZzuqh]
	public virtual string InnerText
	{
		get
		{
			return Text;
		}
		set
		{
			Text = value;
		}
	}

	[z0ZzZzuqh]
	public virtual float Width
	{
		get
		{
			return z0fik;
		}
		set
		{
			if (value >= 0f)
			{
				z0fik = value;
			}
		}
	}

	public virtual bool Visible
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public virtual float Height
	{
		get
		{
			return z0aik;
		}
		set
		{
			z0aik = value;
		}
	}

	[z0ZzZzuqh]
	public virtual z0ZzZzxdh EditorSize
	{
		get
		{
			return new z0ZzZzxdh(Width, Height);
		}
		set
		{
			Width = value.z0rek();
			Height = value.z0tek();
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Attribute", typeof(XAttribute))]
	public virtual XAttributeList Attributes
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public virtual string Text
	{
		get
		{
			return ToString();
		}
		set
		{
		}
	}

	public virtual string ID
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool Modified
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool z0gek()
	{
		return false;
	}

	public bool z0yek()
	{
		return (z0iik & 0x10000000) != 0;
	}

	public void z0yek(int p0)
	{
	}

	public virtual void z0ye(ElementEventArgs p0)
	{
		z0cu()?.z0eek(p0);
	}

	public virtual void z0mr(z0ZzZzvxj p0)
	{
	}

	public virtual void z0nu(XTextContainerElement p0)
	{
		if (z0uik != p0)
		{
			z0uik = p0;
			if (z0uik != null)
			{
				z0bt(z0uik.z0jr());
			}
		}
	}

	protected void z0yek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 2) : (z0iik & -3));
	}

	public virtual string z0ti()
	{
		return Text;
	}

	public virtual void z0fy(z0ZzZzdxj p0)
	{
		p0.z0eek(Text);
	}

	protected bool z0uek()
	{
		return (z0iik & 0x8000000) != 0;
	}

	public virtual DocumentBehaviorOptions z0bu()
	{
		return z0rik?.z0bu();
	}

	public virtual XTextSectionElement z0iek()
	{
		return z0rek_jiejie20260327142557<XTextSectionElement>();
	}

	internal void z0oek()
	{
		z0rik?.z0wik();
	}

	public virtual bool z0xu()
	{
		if (z0rik != null)
		{
			return z0rik.z0xu();
		}
		return false;
	}

	public virtual void z0ko(ElementEventArgs p0)
	{
	}

	public virtual bool z0hr()
	{
		z0xek();
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return false;
		}
		if (z0jr().z0jrk() != xTextDocumentContentElement)
		{
			xTextDocumentContentElement.z0sr();
		}
		int num = xTextDocumentContentElement.z0frk().IndexOf(this);
		if (num >= 0)
		{
			z0jr().z0btk();
			xTextDocumentContentElement.z0frk().z0tek(num, 1);
			return true;
		}
		return false;
	}

	public virtual void z0lo()
	{
	}

	public void z0yek(XTextContainerElement p0)
	{
		z0uik = p0;
	}

	public virtual int z0pek()
	{
		return z0buk;
	}

	public float z0mek()
	{
		return z0xik + z0fik;
	}

	public virtual void z0bt(XTextDocument p0)
	{
		z0rik = p0;
		z0ruk = null;
	}

	protected bool z0nek()
	{
		return (z0iik & 2) != 0;
	}

	public z0ZzZzxdh z0bek()
	{
		return new z0ZzZzxdh(Width, Height);
	}

	public virtual int z0kek()
	{
		return 0;
	}

	public virtual XTextDocumentContentElement z0qek()
	{
		return z0rek_jiejie20260327142557<XTextDocumentContentElement>();
	}

	protected void z0uek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x80) : (z0iik & -129));
	}

	public virtual XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		if (z0jr() == null)
		{
			return null;
		}
		if (p0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			xTextElementList.Add(z0lr(p0: true));
			return z0ZzZzafh.z0yek(z0jr(), xTextElementList, p2: true);
		}
		return null;
	}

	protected void z0iek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x10000) : (z0iik & -65537));
	}

	public virtual float z0si()
	{
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj == null)
		{
			return Height;
		}
		return Height - z0ZzZzrzj.z0quk - z0ZzZzrzj.z0xrk;
	}

	internal void z0yek(z0ZzZzzlh p0)
	{
		z0kik = p0;
	}

	public bool z0vek()
	{
		return Height > 100000f;
	}

	internal bool z0yek(bool p0, bool p1)
	{
		if (z0cu() != null && z0cu().z0jyk())
		{
			return false;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		XTextContentElement xTextContentElement = z0jy();
		if (xTextDocumentContentElement == null || xTextContentElement == null)
		{
			return false;
		}
		int num = xTextDocumentContentElement.z0frk().z0lrk(this);
		int num2 = xTextContentElement.z0trk().z0vek(this);
		if (num >= 0 && num2 < 0)
		{
			for (XTextElement xTextElement = z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (xTextElement is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement;
					if (xTextInputFieldElementBase.z0tek() < 0f && xTextInputFieldElementBase.z0eek(this, p0, p1))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	protected void z0oek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x80000) : (z0iik & -524289));
	}

	public virtual void z0sr()
	{
		if (!z0ar(z0jr(), p1: false))
		{
			return;
		}
		z0xek();
		z0cu()?.z0cok();
		XTextElement xTextElement = z0ie();
		if (xTextElement == null)
		{
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return;
		}
		if (z0jr().z0jrk() != xTextDocumentContentElement)
		{
			xTextDocumentContentElement.z0sr();
		}
		int num = -1;
		XTextElement xTextElement2;
		for (xTextElement2 = xTextElement; xTextElement2 != null; xTextElement2 = xTextElement2.z0ji())
		{
			num = xTextDocumentContentElement.z0frk().z0bek(xTextElement2);
			if (num >= 0)
			{
				break;
			}
		}
		if (num >= 0)
		{
			xTextDocumentContentElement.z0uek(num, 0);
			if (xTextDocumentContentElement.z0frk().z0bek(xTextElement2) != num)
			{
				xTextDocumentContentElement.z0uek(xTextDocumentContentElement.z0frk().z0bek(xTextElement2), 0);
			}
			if (z0cu() != null && z0cu().z0dpk())
			{
				z0cu().z0syk();
			}
		}
	}

	public int z0cek()
	{
		if (z0kik != null)
		{
			return z0kik.IndexOf(this) + 1;
		}
		return -1;
	}

	protected void z0pek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x400) : (z0iik & -1025));
	}

	protected void z0xek()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement != null && xTextDocumentContentElement != z0rik.z0jrk())
		{
			xTextDocumentContentElement.z0sr();
		}
	}

	protected void z0mek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x2000000) : (z0iik & -33554433));
	}

	protected bool z0zek()
	{
		return (z0iik & 4) != 0;
	}

	public virtual object z0lek()
	{
		return null;
	}

	internal virtual z0ZzZznwh z0ni()
	{
		return null;
	}

	public virtual string z0iy()
	{
		return null;
	}

	public virtual bool z0lrk()
	{
		return true;
	}

	public bool z0krk()
	{
		for (XTextElement xTextElement = z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextSectionElement && ((XTextSectionElement)xTextElement).z0rek())
			{
				return true;
			}
		}
		return false;
	}

	public virtual void z0mt(float p0)
	{
	}

	public virtual DocumentEditOptions z0pu_jiejie20260327142557()
	{
		return z0rik?.z0pu_jiejie20260327142557();
	}

	public virtual DocumentSecurityOptions z0hi()
	{
		return z0rik?.z0hi();
	}

	public void z0yek(z0ZzZzbdh p0)
	{
		p0.z0uek();
		_ = 0f;
		z0xik = p0.z0oek();
		z0wik = p0.z0pek();
		z0fik = p0.z0uek();
		z0aik = p0.z0iek();
	}

	public virtual string z0xr()
	{
		return "[" + z0tuk + "]" + GetType().Name + "(" + ID + ")";
	}

	public int z0jrk()
	{
		return z0tuk;
	}

	internal virtual z0ZzZznwh z0hrk()
	{
		if (z0jr() != null)
		{
			for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				z0ZzZzrzj z0ZzZzrzj = xTextElement.z0aek();
				if (z0ZzZzrzj != null && z0ZzZzrzj.z0yuk != null)
				{
					return z0ZzZzrzj.z0yuk;
				}
			}
		}
		return z0ni();
	}

	public void z0yek(float p0)
	{
		Width = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Pixel, GraphicsUnit.Document);
	}

	protected void z0nek(bool p0)
	{
		if (z0ptk() != null)
		{
			z0ptk().z0tek(p0: true);
		}
		bool flag = XTextContentElement.z0ytk;
		XTextContentElement.z0ytk = false;
		try
		{
			if (this is XTextTableCellElement)
			{
				((XTextTableCellElement)this).z0nek(p0: true);
				XTextContentElement xTextContentElement = z0ji().z0jy();
				z0jo();
				int p1 = xTextContentElement.z0trk().IndexOf(z0ji()?.z0ji());
				xTextContentElement.z0eek(p1);
			}
			else if (this is XTextSectionElement xTextSectionElement)
			{
				xTextSectionElement.z0nek(p0: true);
				XTextContentElement xTextContentElement2 = z0ji().z0jy();
				z0jo();
				int p2 = xTextContentElement2.z0trk().IndexOf(this);
				xTextContentElement2.z0eek(p2);
			}
			else
			{
				if (this is XTextTableElement)
				{
					((XTextTableElement)this).z0jyk = true;
				}
				XTextContentElement xTextContentElement3 = z0jy();
				z0jo();
				int num = xTextContentElement3.z0trk().IndexOf(this);
				if (num < 0)
				{
					num = xTextContentElement3.z0trk().IndexOf(z0ie());
				}
				if (num < 0)
				{
					num = -10000;
				}
				if (this is XTextContainerElement)
				{
					z0ZzZzzlh z0ZzZzzlh = z0ie()?.z0ptk();
					z0ZzZzzlh z0ZzZzzlh2 = z0dek()?.z0ptk();
					if (z0ZzZzzlh != null && z0ZzZzzlh2 != null)
					{
						z0ZzZzzlh[] array = xTextContentElement3.z0zek();
						int num2 = array.z0iek(z0ZzZzzlh);
						int num3 = array.z0iek(z0ZzZzzlh2);
						if (num2 >= 0 && num3 >= num2)
						{
							for (int i = num2; i <= num3; i++)
							{
								array[i].z0tek(p0: true);
							}
						}
						else
						{
							if (num2 >= 0)
							{
								array[num2].z0tek(p0: true);
							}
							if (num3 >= 0)
							{
								array[num3].z0tek(p0: true);
							}
						}
					}
				}
				xTextContentElement3.z0eek(num);
			}
		}
		finally
		{
			XTextContentElement.z0ytk = flag;
		}
		z0jr().z0qtk().Layouted = true;
		z0jo();
		if (p0)
		{
			z0jr().Modified = true;
			ContentChangedEventArgs e = new ContentChangedEventArgs();
			e.EventSource = ContentChangedEventSource.UndoRedo;
			e.Document = z0jr();
			XTextContainerElement xTextContainerElement = this as XTextContainerElement;
			if (xTextContainerElement == null)
			{
				xTextContainerElement = z0ji();
			}
			e.Element = xTextContainerElement;
			xTextContainerElement.z0zi(e);
			z0jr().OnDocumentContentChanged();
		}
	}

	public virtual bool z0qr(string p0)
	{
		return false;
	}

	protected bool z0grk()
	{
		return (z0iik & 0x10) != 0;
	}

	public virtual void z0qi(bool p0)
	{
		_ = z0cuk;
		z0cuk = p0;
	}

	protected void z0bek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x10) : (z0iik & -17));
	}

	public virtual void z0li()
	{
	}

	public virtual void z0yek(DocumentContentStyle p0)
	{
		this.z0sik = p0;
		if (this.z0sik != null)
		{
			((z0ZzZzvik)this.z0sik).z0mek = true;
		}
	}

	public virtual XTextElement z0yek(Type p0, bool p1)
	{
		for (XTextElement xTextElement = (p1 ? this : z0ji()); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			Type type = xTextElement.GetType();
			if (type.Equals(p0) || type.IsSubclassOf(p0))
			{
				return xTextElement;
			}
		}
		return null;
	}

	public virtual float z0yt()
	{
		return z0wik;
	}

	public virtual void z0ir(int p0)
	{
		z0muk = p0;
	}

	public virtual bool z0ky()
	{
		return false;
	}

	public float z0frk()
	{
		if (z0jr() == null)
		{
			return z0ZzZzrpk.z0eek(z0ork(), GraphicsUnit.Document, GraphicsUnit.Pixel);
		}
		return z0jr().z0krk(z0ork());
	}

	public virtual ParentType z0eek<ParentType>(bool p0) where ParentType : XTextElement
	{
		for (XTextElement xTextElement = (p0 ? this : z0ji()); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is ParentType)
			{
				return (ParentType)xTextElement;
			}
		}
		return null;
	}

	protected internal XTextDocument z0drk()
	{
		return z0rik;
	}

	internal int z0srk()
	{
		return z0xuk;
	}

	public virtual bool z0zy(z0ZzZzzhh p0)
	{
		if (z0ptk() == null)
		{
			return false;
		}
		return z0ptk().z0oek();
	}

	protected void z0vek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 8) : (z0iik & -9));
	}

	public virtual z0ZzZzonj z0qt()
	{
		int num = z0aek().z0nrk;
		int num2 = z0aek().z0jyk;
		if (num < 0 && num2 < 0)
		{
			return null;
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return null;
		}
		if (xTextDocument.z0vu().SecurityOptions.ShowPermissionTip)
		{
			StringBuilder stringBuilder = new StringBuilder();
			z0ZzZzyhh z0ZzZzyhh = xTextDocument.z0syk().z0tek(num);
			if (z0ZzZzyhh != null)
			{
				z0yek(stringBuilder, z0ZzZzyhh, p2: true);
			}
			z0ZzZzyhh = xTextDocument.z0syk().z0tek(num2);
			if (z0ZzZzyhh != null)
			{
				z0yek(stringBuilder, z0ZzZzyhh, p2: false);
			}
			if (stringBuilder.Length > 0)
			{
				return z0yek(stringBuilder.ToString());
			}
		}
		return null;
	}

	public virtual float z0bi()
	{
		return z0fik;
	}

	protected void z0cek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x20000) : (z0iik & -131073));
	}

	public virtual XTextElementList z0be()
	{
		return null;
	}

	public void z0xek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x40000000) : (z0iik & -1073741825));
	}

	public bool z0ark()
	{
		return z0nek();
	}

	public string z0qrk()
	{
		return GetType().Name;
	}

	protected bool z0wrk()
	{
		return (z0iik & 0x1000) != 0;
	}

	protected void z0zek(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x100) : (z0iik & -257));
	}

	public virtual string z0erk()
	{
		if (z0jr() == null)
		{
			return null;
		}
		using XTextDocument xTextDocument = z0ee_jiejie20260327142557(p0: true);
		if (xTextDocument == null)
		{
			return null;
		}
		xTextDocument.z0eu();
		return xTextDocument.z0dmk();
	}

	protected void z0yek(string p0, z0ZzZzvxj p1)
	{
		if (p0 != null && p0.Length > 0)
		{
			using (z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh())
			{
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				p1.z0gyk.z0rek(z0ZzZzyfh.z0iek, p1.z0gtk);
				p1.z0gyk.DrawString(p0, z0ZzZzimk.z0oek, z0ZzZzyfh.z0oek, p1.z0gtk, z0ZzZzlsh);
			}
		}
	}

	public virtual XTextElement z0ku()
	{
		return null;
	}

	public virtual void z0rrk()
	{
		for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextContainerElement)
			{
				((XTextContainerElement)xTextElement).z0qtk++;
			}
			else if (xTextElement is XTextObjectElement)
			{
				((XTextObjectElement)xTextElement).z0hrk++;
			}
		}
	}

	public virtual void z0yek(ElementKeyEventArgs p0)
	{
	}

	public virtual float z0lu()
	{
		return z0fik;
	}

	protected bool z0trk()
	{
		return (z0iik & 0x80) != 0;
	}

	protected bool z0yrk()
	{
		return (z0iik & 0x20) != 0;
	}

	protected bool z0urk()
	{
		return (z0iik & 8) != 0;
	}

	public virtual bool z0ar(XTextDocument p0, bool p1)
	{
		if (p0 == null)
		{
			return false;
		}
		if (this is XTextCharElement && z0ji() is XTextInputFieldElementBase)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)z0ji();
			if (xTextInputFieldElementBase.z0tek(this))
			{
				return xTextInputFieldElementBase.z0ar(p0, p1);
			}
		}
		XTextElement xTextElement = this;
		while (xTextElement != null)
		{
			if (p1 && xTextElement.z0aek().z0jyk >= 0)
			{
				return false;
			}
			if (xTextElement == p0)
			{
				return true;
			}
			XTextContainerElement xTextContainerElement = xTextElement.z0ji();
			if (xTextContainerElement != null && xTextContainerElement.z0qe(xTextElement))
			{
				xTextElement = xTextContainerElement;
				continue;
			}
			return false;
		}
		return false;
	}

	public virtual z0ZzZznnj z0irk()
	{
		return null;
	}

	protected void z0lrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x200000) : (z0iik & -2097153));
	}

	public void z0krk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x20000000) : (z0iik & -536870913));
	}

	protected void z0jrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x40000) : (z0iik & -262145));
	}

	public virtual void z0sy(ElementMouseEventArgs p0)
	{
		if (p0 != null)
		{
			if (z0jr() == null)
			{
				p0.CancelBubble = true;
			}
			else
			{
				z0cu()?.z0eek(p0);
			}
		}
	}

	internal void z0uek(XTextContainerElement p0)
	{
		XTextDocument xTextDocument = z0jr();
		if (z0ji() != null)
		{
			z0ji().z0ai(this);
		}
		if (xTextDocument != null && xTextDocument != p0.z0jr() && p0.z0jr() != null)
		{
			p0.z0jr().z0lrk(this);
		}
		z0nu(p0);
		z0bt(p0.z0jr());
	}

	public virtual XTextElement z0dek()
	{
		return this;
	}

	public virtual float z0ork()
	{
		if (z0buk < 0)
		{
			return Width;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj == null)
		{
			return Width;
		}
		return Width - z0ZzZzrzj.z0ryk - z0ZzZzrzj.z0ptk;
	}

	internal void z0prk()
	{
		z0ruk = null;
	}

	public virtual float z0mrk()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return 0f;
		}
		float num = z0he();
		z0ZzZzwrj z0ZzZzwrj = xTextDocument.z0suk().z0rek(z0je());
		if (z0ZzZzwrj == null)
		{
			return new z0ZzZzarj(xTextDocument.PageSettings, p1: true, p2: false).z0bek() + num;
		}
		return new z0ZzZzarj(z0ZzZzwrj, p1: true).z0bek() + num;
	}

	internal ElementType z0rek_jiejie20260327142557<ElementType>() where ElementType : XTextElement
	{
		for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is ElementType)
			{
				return (ElementType)xTextElement;
			}
			if (xTextElement is XTextDocument)
			{
				return null;
			}
		}
		return null;
	}

	public virtual bool z0de()
	{
		if (z0qek() == null)
		{
			return false;
		}
		return z0qek().z0rek(this);
	}

	public virtual void z0mu(DocumentEventArgs p0)
	{
		z0ZzZzdfh.z0rek().z0ed(this, p0);
	}

	internal z0ZzZzbdh z0nrk()
	{
		z0ZzZzzlh z0ZzZzzlh = z0ptk();
		if (z0ZzZzzlh != null)
		{
			return new z0ZzZzbdh(z0ZzZzzlh.z0stk() + z0it(), z0ZzZzzlh.z0zrk(), Width + z0pt(), Math.Max(Height, z0ZzZzzlh.z0ytk()));
		}
		z0ZzZzbdh result = z0pyk();
		for (XTextElement xTextElement = z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			z0ZzZzrzj z0ZzZzrzj = xTextElement.z0aek();
			result.z0tek(xTextElement.z0it() + z0ZzZzrzj.z0ryk, xTextElement.z0yt() + z0ZzZzrzj.z0quk);
			if (xTextElement is XTextContentElement)
			{
				break;
			}
		}
		return result;
	}

	public virtual XTextTableCellElement z0brk()
	{
		return z0rek_jiejie20260327142557<XTextTableCellElement>();
	}

	public virtual z0ZzZzrzj z0aek()
	{
		if (this.z0sik != null)
		{
			z0drk(p0: false);
		}
		if (z0ruk == null)
		{
			z0ruk = z0rik?.z0nzk?.z0eek(z0buk);
		}
		return z0ruk;
	}

	protected bool z0vrk()
	{
		return (z0iik & 0x8000) != 0;
	}

	public int z0crk()
	{
		return 0;
	}

	public virtual z0ZzZzpmk z0ny()
	{
		if (Width <= 0f || Height <= 0f)
		{
			return null;
		}
		z0ZzZzxdh p = new z0ZzZzxdh(Width, Height);
		p = z0ZzZzrpk.z0eek(p, GraphicsUnit.Document, GraphicsUnit.Pixel);
		z0ZzZzrfh p2 = new z0ZzZzrfh((int)Math.Ceiling(p.z0rek()), (int)Math.Ceiling(p.z0tek()));
		using (z0ZzZzadh z0ZzZzadh = z0ZzZzadh.z0eek(p2))
		{
			z0ZzZzadh.z0eek(Color.White);
			z0ZzZzadh.z0eek(GraphicsUnit.Document);
			z0ZzZzbdh p3 = z0qyk();
			z0ZzZzvxj z0ZzZzvxj = z0jr().z0bek(new z0ZzZzjpk(z0ZzZzadh), (z0ZzZzcxj)1);
			z0ZzZzvxj.z0gyk.z0eek();
			z0ZzZzvxj.z0gyk.z0rek(0f - p3.z0oek(), 0f - p3.z0pek());
			z0ZzZzvxj.z0gyk.z0rek();
			z0ZzZzvxj.z0uek(z0ZzZzndh.z0rek(p3));
			z0ZzZzvxj.z0luk = z0aek();
			z0ZzZzvxj.z0eek(z0qek().z0fu());
			z0ZzZzvxj.z0gtk = p3;
			z0ZzZzvxj.z0tek(z0aek().z0eek(p3));
			z0ZzZzvxj.z0eyk = true;
			z0ZzZzvxj.z0yek(p3);
			z0ZzZzvxj.z0hyk = this;
			z0ZzZzvxj.z0yek(p0: true);
			z0ZzZzvxj.z0rek(z0ZzZzvxj.z0gtk);
			z0tt(z0ZzZzvxj);
		}
		return new z0ZzZzpmk(p2);
	}

	public virtual void z0yek(ElementMouseEventArgs p0)
	{
		z0cu()?.z0uek(p0);
	}

	public virtual DocumentOptions z0vu()
	{
		return z0rik?.z0vu();
	}

	public virtual void z0uu(bool p0)
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			throw new Exception(z0ZzZziok.z0pok());
		}
		z0xi(p0: true);
		z0li();
		if (this is XTextContainerElement)
		{
			((XTextContainerElement)this).z0jrk(p0: true);
		}
		else
		{
			z0cuk = Visible && xTextDocument.z0cek(this);
		}
		if (xTextDocument.z0dtk() != (z0ZzZzzcj)3)
		{
			return;
		}
		if (z0cu() != null && z0cu().z0jyk())
		{
			xTextDocument.z0grk(this);
		}
		else
		{
			if (z0jy() == null)
			{
				return;
			}
			if (!p0)
			{
				ElementLoadEventArgs e = new ElementLoadEventArgs(this, null);
				e.UpdateValueBinding = false;
				z0rt(e);
			}
			bool z0mzk = xTextDocument.z0mzk;
			xTextDocument.z0qrk(p0);
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			object obj = xTextDocumentContentElement?.z0oek().z0yrk();
			z0drk(p0: false);
			z0jy().z0bek(p0: true);
			z0jo();
			xTextDocument.z0htk()?.z0co(this);
			using (z0ZzZzjpk p1 = z0ru())
			{
				z0ZzZzvxj z0ZzZzvxj = xTextDocument.z0bek(p1, (z0ZzZzcxj)0);
				z0ZzZzvxj.z0eyk = false;
				z0ZzZzvxj.z0hyk = this;
				if (p0)
				{
					z0ZzZzvxj.z0eek(p0: true);
				}
				z0mr(z0ZzZzvxj);
			}
			bool z0bpk = z0ZzZzdbj.z0bpk;
			bool z0yxk = XTextDocument.z0yxk;
			z0ZzZzdbj.z0bpk = true;
			XTextDocument.z0yxk = true;
			try
			{
				XTextContentElement xTextContentElement = z0jy();
				if (this is XTextContentElement && !(this is XTextDocumentContentElement) && !(xTextContentElement is XTextDocumentContentElement))
				{
					xTextContentElement = xTextContentElement.z0ji().z0jy();
				}
				xTextContentElement.z0bek(p0: true);
				if (this is XTextTableCellElement)
				{
					z0yek(((XTextTableCellElement)this).z0gr(), !p0);
				}
				else if (this is XTextSectionElement || this is XTextTableRowElement)
				{
					z0yek(z0ji(), !p0);
				}
				else
				{
					z0yek(this, !p0);
				}
				xTextDocumentContentElement.z0tek(p0: false);
				if (obj == null)
				{
					xTextDocumentContentElement.z0oek().z0erk();
				}
				else
				{
					xTextDocumentContentElement.z0oek().z0rek(obj);
				}
				z0nek(p0: false);
				xTextDocument.z0qrk(z0mzk);
			}
			finally
			{
				z0ZzZzdbj.z0bpk = z0bpk;
				XTextDocument.z0yxk = z0yxk;
			}
		}
	}

	public void z0hrk(bool p0)
	{
		z0yek(p0);
	}

	public virtual int z0je()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return -1;
		}
		XTextElement xTextElement = z0ie();
		if (xTextElement != null)
		{
			z0ZzZzzlh z0ZzZzzlh = xTextElement.z0ptk();
			if (z0ZzZzzlh != null && z0ZzZzzlh.z0dtk() != null)
			{
				return xTextDocument?.z0suk().IndexOf(z0ZzZzzlh.z0dtk()) ?? z0ZzZzzlh.z0dtk().z0brk();
			}
		}
		return -1;
	}

	public virtual void z0te(XTextElementList p0)
	{
	}

	public virtual DocumentContentStyle z0xrk()
	{
		if (this.z0sik == null)
		{
			if (z0ruk != null)
			{
				this.z0sik = (DocumentContentStyle)z0ruk.z0jrk.Clone();
				((z0ZzZzvik)this.z0sik).z0mek = false;
			}
			else
			{
				z0ZzZzcok z0ZzZzcok = z0jr()?.z0gnk()?.GetStyle(z0buk);
				if (z0ZzZzcok != null)
				{
					this.z0sik = (DocumentContentStyle)z0ZzZzcok.Clone();
				}
				else
				{
					this.z0sik = new DocumentContentStyle();
				}
			}
			((z0ZzZzvik)this.z0sik).z0mek = false;
		}
		return this.z0sik;
	}

	public float z0zrk()
	{
		return z0he();
	}

	public float z0ltk()
	{
		return z0cw();
	}

	internal z0ZzZzbdh z0yek(float p0, float p1)
	{
		return new z0ZzZzbdh(p0 + z0xik, p1 + z0wik, z0fik, z0aik);
	}

	internal void z0ktk()
	{
		if (z0rik != null)
		{
			z0rik.z0srk(p0: true);
		}
	}

	protected bool z0jtk()
	{
		return (z0iik & 0x200) != 0;
	}

	protected bool z0htk()
	{
		return (z0iik & 0x100) != 0;
	}

	public override string ToString()
	{
		return string.Empty;
	}

	public int z0gtk()
	{
		if (z0aek() == null || z0jr() == null)
		{
			return -2147483648;
		}
		int p = z0aek().z0jyk;
		return z0jr().z0syk().z0eek(p);
	}

	public virtual XTextElement z0ie()
	{
		return this;
	}

	internal void z0grk(bool p0)
	{
	}

	public virtual bool z0zu(XTextElement p0)
	{
		if (z0uik == p0.z0uik && z0uik != null)
		{
			return false;
		}
		for (XTextElement xTextElement = z0uik; xTextElement != null; xTextElement = xTextElement.z0uik)
		{
			if (xTextElement == p0)
			{
				return true;
			}
			if (xTextElement is XTextDocument)
			{
				break;
			}
		}
		return false;
	}

	internal void z0yek(StringBuilder p0, z0ZzZzyhh p1, bool p2)
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return;
		}
		if (p2)
		{
			if (p0.Length > 0)
			{
				p0.Append(Environment.NewLine);
			}
			QueryUserHistoryDisplayTextEventArgs e = new QueryUserHistoryDisplayTextEventArgs(z0cu(), xTextDocument, this, p1, forLogicDelete: false);
			string text = xTextDocument.z0hi().CreatorTipFormatString;
			if (string.IsNullOrEmpty(text))
			{
				text = z0ZzZziok.z0kok();
			}
			p1.z0rek(xTextDocument.z0luk());
			e.Result = z0ZzZzeik.z0eek(text, p1);
			if (z0cu() != null)
			{
				z0cu().z0eek(e);
			}
			if (!string.IsNullOrEmpty(e.Result))
			{
				p0.Append(e.Result);
			}
		}
		else
		{
			if (p0.Length > 0)
			{
				p0.Append(Environment.NewLine);
			}
			QueryUserHistoryDisplayTextEventArgs e2 = new QueryUserHistoryDisplayTextEventArgs(z0cu(), xTextDocument, this, p1, forLogicDelete: true);
			string text2 = xTextDocument.z0hi().DeleterTipFormatString;
			if (string.IsNullOrEmpty(text2))
			{
				text2 = z0ZzZziok.z0ktk();
			}
			p1.z0rek(xTextDocument.z0luk());
			e2.Result = z0ZzZzeik.z0eek(text2, p1);
			if (z0cu() != null)
			{
				z0cu().z0eek(e2);
			}
			p0.Append(e2.Result);
		}
	}

	public virtual bool z0hek(bool p0)
	{
		return z0yi();
	}

	internal void z0ftk()
	{
		if (this.z0sik != null && ((z0ZzZzvik)this.z0sik).z0mek)
		{
			XTextDocument xTextDocument = z0rik;
			if (xTextDocument != null)
			{
				z0buk = xTextDocument.z0gnk().GetStyleIndex(this.z0sik);
				this.z0sik.z0eek();
				z0ruk = null;
				this.z0sik = null;
			}
		}
	}

	public virtual float z0pt()
	{
		return 0f;
	}

	protected void z0frk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x4000) : (z0iik & -16385));
	}

	protected bool z0dtk()
	{
		return (z0iik & 0x800000) != 0;
	}

	public float z0stk()
	{
		if (z0jr() == null)
		{
			return z0ZzZzrpk.z0eek(z0si(), GraphicsUnit.Document, GraphicsUnit.Pixel);
		}
		return z0jr().z0krk(z0si());
	}

	public virtual XTextContentElement z0jy()
	{
		return z0rek_jiejie20260327142557<XTextContentElement>();
	}

	public void z0iek(XTextContainerElement p0)
	{
		z0uik = p0;
		z0rik = p0.z0rik;
	}

	public virtual XTextTableElement z0gr()
	{
		return z0rek_jiejie20260327142557<XTextTableElement>();
	}

	public virtual XTextElement z0hy()
	{
		return z0ie();
	}

	public virtual bool z0vy(float p0, float p1, bool p2, bool p3)
	{
		if (p0 <= 0f)
		{
			throw new ArgumentOutOfRangeException("width:" + p0);
		}
		if (p1 <= 0f)
		{
			throw new ArgumentOutOfRangeException("height:" + p1);
		}
		if (Width == p0 && Height == p1)
		{
			return false;
		}
		z0ZzZzxdh z0ZzZzxdh = new z0ZzZzxdh(Width, Height);
		if (p2)
		{
			z0jo();
		}
		Width = p0;
		Height = p1;
		z0xi(p0: false);
		if (p3 && z0jr().z0ytk())
		{
			z0ZzZzhlh z0ZzZzhlh = new z0ZzZzhlh();
			z0ZzZzhlh.z0eek((z0ZzZzqlh)1);
			z0ZzZzhlh.z0eek(this);
			z0ZzZzhlh.z0eek(z0ZzZzxdh);
			z0ZzZzhlh.z0rek(new z0ZzZzxdh(Width, Height));
			z0jr().z0bek(z0ZzZzhlh);
			z0jr().z0nuk();
		}
		if (p2)
		{
			z0nek(p0: true);
		}
		return true;
	}

	public virtual void Dispose()
	{
		z0rik = null;
		z0kik = null;
		z0uik = null;
		z0ruk = null;
		this.z0sik = null;
	}

	internal bool z0yek(XTextElement p0)
	{
		return z0uik == p0.z0uik;
	}

	public PageContentPartyStyle z0atk()
	{
		return z0qek()?.z0du() ?? PageContentPartyStyle.Body;
	}

	public virtual string z0qtk()
	{
		if (z0jr() == null)
		{
			return null;
		}
		using XTextDocument xTextDocument = z0ee_jiejie20260327142557(p0: false);
		if (xTextDocument == null)
		{
			return null;
		}
		xTextDocument.z0eu();
		return xTextDocument.z0dmk();
	}

	public virtual void z0rt(ElementLoadEventArgs p0)
	{
		z0ftk();
	}

	public virtual float z0vi()
	{
		return z0aik;
	}

	internal void z0uek(int p0)
	{
		z0tuk = p0;
	}

	public virtual void z0uek(ElementKeyEventArgs p0)
	{
	}

	internal bool z0uek(float p0, float p1)
	{
		if (z0xik != p0 || z0wik != p1)
		{
			z0xik = p0;
			z0wik = p1;
			return true;
		}
		return false;
	}

	public virtual ElementZOrderStyle z0ci()
	{
		return ElementZOrderStyle.Normal;
	}

	public virtual string z0zwk(string p0)
	{
		return null;
	}

	public void z0uek(float p0)
	{
		Height = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Pixel, GraphicsUnit.Document);
	}

	public void z0yek(XTextDocument p0, XTextContainerElement p1)
	{
		z0rik = p0;
		z0uik = p1;
		z0ruk = null;
	}

	public bool z0wtk()
	{
		if (z0jr() == null)
		{
			return false;
		}
		for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement.z0aek() != null && xTextElement.z0aek().z0jyk >= 0)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool z0etk()
	{
		if (z0jr() == null)
		{
			throw new NullReferenceException(z0ZzZziok.z0cik());
		}
		return z0drk(p0: false);
	}

	protected internal bool z0drk(bool p0)
	{
		if (this.z0sik != null && ((z0ZzZzvik)this.z0sik).z0mek)
		{
			XTextDocument xTextDocument = z0rik;
			if (xTextDocument != null)
			{
				int p1 = z0buk;
				z0buk = xTextDocument.z0gnk().GetStyleIndex(this.z0sik);
				this.z0sik.z0eek();
				if (p0 && xTextDocument.z0uik())
				{
					xTextDocument.z0imk().z0eek(this, p1, z0buk);
				}
				z0ruk = null;
				this.z0sik = null;
				return true;
			}
		}
		return false;
	}

	public virtual string z0ge()
	{
		return GetType().Name + ":" + ID;
	}

	protected void z0srk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x8000000) : (z0iik & -134217729));
	}

	protected bool z0rtk()
	{
		return (z0iik & 0x2000) != 0;
	}

	protected bool z0ttk()
	{
		return (z0iik & 0x2000000) != 0;
	}

	internal void z0ytk()
	{
		this.z0sik = null;
		z0ruk = null;
	}

	public float z0utk()
	{
		return z0ZzZzrpk.z0eek(Height, GraphicsUnit.Document, GraphicsUnit.Pixel);
	}

	protected void z0ark(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x2000) : (z0iik & -8193));
	}

	public virtual void z0tu(string p0)
	{
	}

	public virtual bool z0itk()
	{
		if (z0jr() == null)
		{
			throw new NullReferenceException(z0ZzZziok.z0cik());
		}
		return z0drk(p0: true);
	}

	public virtual XTextElement z0xt()
	{
		return z0dek();
	}

	protected bool z0otk()
	{
		return (z0iik & 0x200000) != 0;
	}

	public z0ZzZzzlh z0ptk()
	{
		return z0kik;
	}

	internal bool z0mtk()
	{
		if (z0ruk != null)
		{
			if (z0ruk.z0nrk < 0)
			{
				return z0ruk.z0jyk >= 0;
			}
			return true;
		}
		return false;
	}

	public virtual XTextElement z0xw()
	{
		XTextContainerElement xTextContainerElement = z0ji();
		if (xTextContainerElement != null)
		{
			int num = xTextContainerElement.z0be().z0bek(this);
			if (num < xTextContainerElement.z0be().Count - 1)
			{
				return xTextContainerElement.z0be()[num + 1];
			}
		}
		return null;
	}

	public virtual bool z0or(bool p0, bool p1, bool p2)
	{
		bool result = false;
		bool visible = Visible;
		if (visible != p0)
		{
			Visible = p0;
			z0qi(Visible && z0jr().z0cek(this));
			if (z0jr() == null || z0jr().z0dtk() != (z0ZzZzzcj)3)
			{
				return false;
			}
			if (z0xu() && this is XTextContainerElement)
			{
				((XTextContainerElement)this).z0jrk(p0: true);
				return true;
			}
			if (Visible == p0)
			{
				if (p1 && z0jr().z0ytk())
				{
					z0jr().z0imk().z0eek(this, visible, Visible);
					z0jr().z0nuk();
				}
				z0jo();
				if (z0jr().z0htk() != null)
				{
					if (p0)
					{
						z0jr().z0htk().z0co(this);
					}
					else
					{
						z0jr().z0htk().z0qp(this);
					}
				}
				result = true;
				XTextElement xTextElement = z0ie();
				XTextContentElement xTextContentElement = z0jy();
				int p3 = 0;
				XTextElement xTextElement2 = xTextContentElement.z0trk().z0pek(xTextElement);
				if (visible)
				{
					p3 = xTextContentElement.z0trk().IndexOf(xTextElement);
				}
				z0rrk();
				XTextDocumentContentElement xTextDocumentContentElement = z0qek();
				XTextElement xTextElement3 = xTextDocumentContentElement.z0zek();
				xTextContentElement.z0bek(p0: true);
				if (!visible)
				{
					p3 = xTextContentElement.z0trk().IndexOf(xTextElement);
				}
				else if (xTextElement2 != null && xTextContentElement.z0trk().Contains(xTextElement2))
				{
					p3 = xTextContentElement.z0trk().IndexOf(xTextElement2);
				}
				xTextContentElement.z0eek(p3, -1, p2);
				if (!p2 && xTextElement3 != null)
				{
					xTextDocumentContentElement.z0frk().IndexOf(xTextElement3);
					_ = 0;
				}
				z0jr().Modified = true;
				z0jr().OnSelectionChanged();
				if (z0jr().z0yyk() != null)
				{
					z0jr().z0yyk().z0vik();
				}
			}
		}
		return result;
	}

	public int z0ntk()
	{
		if (z0aek() == null || z0jr() == null)
		{
			return -2147483648;
		}
		int p = z0aek().z0nrk;
		return z0jr().z0syk().z0eek(p);
	}

	internal void z0yek(XTextDocument p0)
	{
		if (z0rik != p0)
		{
			z0rik = p0;
			z0ruk = null;
		}
	}

	protected void z0qrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x100000) : (z0iik & -1048577));
	}

	public virtual z0ZzZzbdh z0py()
	{
		z0ZzZzpdh z0ZzZzpdh = z0zw();
		return new z0ZzZzbdh(z0ZzZzpdh.z0rek(), z0ZzZzpdh.z0tek(), Width, Height);
	}

	public virtual void z0nt(float p0)
	{
		z0wik = p0;
	}

	protected void z0wrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x400000) : (z0iik & -4194305));
	}

	public virtual void z0fr()
	{
		if (z0uik != null)
		{
			z0uik.z0ai(this);
		}
		z0uik = null;
		z0rik = null;
		z0kik = null;
	}

	public virtual z0ZzZzjpk z0ru()
	{
		return z0rik.z0ru();
	}

	public virtual z0ZzZzpdh z0zw()
	{
		float num = 0f;
		float num2 = 0f;
		if (z0kik == null)
		{
			if (z0ji() == null)
			{
				num = z0xik;
				num2 = z0wik;
			}
			else
			{
				z0ZzZzpdh z0ZzZzpdh = z0ji().z0zw();
				num = z0xik + z0ZzZzpdh.z0rek();
				num2 = z0wik + z0ZzZzpdh.z0tek();
			}
			return new z0ZzZzpdh(num, num2);
		}
		z0ZzZzpdh z0ZzZzpdh2 = z0kik.z0yek();
		return new z0ZzZzpdh(z0xik + z0ZzZzpdh2.z0rek(), z0wik + z0ZzZzpdh2.z0tek());
	}

	internal void z0iek(int p0)
	{
		z0buk = p0;
		z0xi(p0: true);
		z0ruk = null;
		this.z0sik = null;
	}

	public virtual void z0ei(ElementEventArgs p0)
	{
	}

	internal void z0btk()
	{
		if (this.z0sik != null)
		{
			z0drk(p0: false);
		}
		if (z0ruk == null)
		{
			z0ruk = z0rik?.z0nzk?.z0eek(z0buk);
		}
	}

	public virtual void z0wi(string p0)
	{
		Text = p0;
	}

	protected bool z0vtk()
	{
		return (z0iik & 0x80000) != 0;
	}

	public virtual void z0ri()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument != null && !xTextDocument.z0snk())
		{
			xTextDocument.z0htk()?.z0co(this);
		}
	}

	internal int z0ctk()
	{
		return z0tuk;
	}

	public virtual void z0iek(float p0)
	{
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj == null)
		{
			Width = p0;
		}
		else
		{
			Width = p0 + z0ZzZzrzj.z0ryk + z0ZzZzrzj.z0ptk;
		}
	}

	public virtual bool z0ao()
	{
		return z0kuk();
	}

	public virtual float z0he()
	{
		if (z0kik == null)
		{
			if (z0ji() == null)
			{
				return z0xik;
			}
			return z0xik + z0ji().z0it();
		}
		return z0xik + z0kik.z0xtk();
	}

	public float z0xtk()
	{
		return z0wik + z0aik;
	}

	public virtual bool z0mi()
	{
		return true;
	}

	public virtual z0ZzZzdbj z0cu()
	{
		return z0rik?.z0cu();
	}

	public virtual string z0pe()
	{
		return "element";
	}

	protected void z0erk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x800) : (z0iik & -2049));
	}

	public virtual string z0ztk()
	{
		if (z0jr() == null)
		{
			return null;
		}
		using XTextDocument xTextDocument = z0ee_jiejie20260327142557(p0: true);
		return xTextDocument?.z0dmk();
	}

	public virtual bool z0yi()
	{
		return z0cuk;
	}

	protected bool z0lyk()
	{
		return (z0iik & 0x1000000) != 0;
	}

	public virtual void z0ot(float p0)
	{
		z0xik = p0;
	}

	public virtual float z0cw()
	{
		if (z0kik == null)
		{
			if (z0ji() == null)
			{
				return z0wik;
			}
			return z0wik + z0ji().z0cw();
		}
		return z0wik + z0kik.z0xrk();
	}

	public virtual PropertyExpressionInfoList z0jek()
	{
		return null;
	}

	protected bool z0kyk_jiejie20260327142557()
	{
		return (z0iik & 0x4000000) != 0;
	}

	public virtual void z0uek(ElementMouseEventArgs p0)
	{
		z0cu()?.z0rek(p0);
	}

	public virtual float z0it()
	{
		return z0xik;
	}

	internal z0ZzZzrzj z0jyk()
	{
		z0ftk();
		if (z0ruk == null)
		{
			XTextDocument xTextDocument = z0rik;
			if (xTextDocument != null)
			{
				z0ruk = xTextDocument.z0gnk().z0eek(z0pek());
			}
		}
		return z0ruk;
	}

	public string z0hyk()
	{
		return z0ZzZzafh.z0uek(GetType());
	}

	protected void z0rrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 1) : (z0iik & -2));
	}

	protected void z0trk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 4) : (z0iik & -5));
	}

	public virtual void z0xwk()
	{
		z0drk(p0: false);
	}

	public bool z0gyk()
	{
		return (z0iik & 0x40000000) != 0;
	}

	internal DocumentContentStyle z0fyk()
	{
		return this.z0sik;
	}

	public z0ZzZzbdh z0dyk()
	{
		if (z0ptk() == null)
		{
			return new z0ZzZzbdh(z0he(), z0cw(), z0lu() + z0pt(), Height);
		}
		return new z0ZzZzbdh(z0he(), z0cw(), z0lu() + z0pt(), z0ptk().z0ytk());
	}

	public virtual z0ZzZzhxj z0vt()
	{
		return null;
	}

	internal z0ZzZzonj z0yek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		z0ZzZzonj z0ZzZzonj = new z0ZzZzonj();
		string titleForToolTip = z0jr().z0bu().TitleForToolTip;
		if (string.IsNullOrEmpty(titleForToolTip))
		{
			z0ZzZzonj.z0eek(z0ZzZziok.z0xuk());
		}
		else
		{
			z0ZzZzonj.z0eek(titleForToolTip);
		}
		z0ZzZzonj.z0eek(this);
		z0ZzZzonj.z0rek(p0);
		z0ZzZzonj.z0eek((z0ZzZzjbj)0);
		z0ZzZzonj.z0eek((z0ZzZzkbj)0);
		z0ZzZzonj.z0eek(ToolTipContentType.UserTrack);
		z0ZzZzonj.z0eek(p0: true);
		return z0ZzZzonj;
	}

	public virtual bool z0dr(string p0, string p1)
	{
		return false;
	}

	protected static void z0yek(XTextElement p0, bool p1)
	{
		if (!p0.z0yi())
		{
			return;
		}
		if (p1)
		{
			p0.z0xi(p0: true);
		}
		if (p0 is XTextTableElement xTextTableElement)
		{
			XTextContainerElement.z0kgj.z0iek = new XTextContainerElement.z0kgj(p0.z0jr(), p1: true);
			z0oik = new XTextContentElement.z0lgj();
			z0oik.z0tek(p0: false);
			z0oik.z0uek(p0: false);
			z0oik.z0eek(p0: true);
			xTextTableElement.z0uek(delegate(XTextTableCellElement xTextTableCellElement)
			{
				xTextTableCellElement.z0gu();
				xTextTableCellElement.Width = 0f;
				xTextTableCellElement.Height = 0f;
				xTextTableCellElement.z0au(z0oik);
			});
			z0oik = null;
			XTextContainerElement.z0kgj.z0iek = null;
			xTextTableElement.z0vek(p0: false);
			xTextTableElement.z0uek(delegate(XTextTableCellElement xTextTableCellElement)
			{
				if (xTextTableCellElement.z0yi())
				{
					IList<XTextElement> list2 = xTextTableCellElement.z0xe();
					if (list2 != null)
					{
						foreach (XTextElement item in list2)
						{
							z0yek(item, p1);
						}
					}
				}
			});
		}
		else
		{
			if (p0 is XTextSectionElement xTextSectionElement)
			{
				((XTextElement)xTextSectionElement).z0drk(p0: false);
				xTextSectionElement.z0bek(p0: false);
				if (p1)
				{
					xTextSectionElement.z0xi(p0: true);
				}
				xTextSectionElement.z0ct();
				IList<XTextElement> list = xTextSectionElement.z0xe();
				if (list == null)
				{
					return;
				}
				{
					foreach (XTextElement item2 in list)
					{
						z0yek(item2, p1);
					}
					return;
				}
			}
			if (p0 is XTextDocumentContentElement xTextDocumentContentElement)
			{
				((XTextElement)xTextDocumentContentElement).z0drk(p0: false);
				xTextDocumentContentElement.z0bek(p0: false);
				if (p1)
				{
					xTextDocumentContentElement.z0xi(p0: true);
				}
				xTextDocumentContentElement.z0ork();
			}
		}
	}

	public virtual void z0oe()
	{
		z0uu(p0: false);
	}

	internal z0ZzZzimk z0oek(float p0)
	{
		z0drk(p0: false);
		if (z0ruk != null)
		{
			return z0ruk.z0eek(p0);
		}
		z0ZzZzcok style = z0jr().z0gnk().GetStyle(z0buk);
		z0ZzZzimk z0ZzZzimk = new z0ZzZzimk();
		if (style != null)
		{
			z0ZzZzimk.Name = style.FontName;
			z0ZzZzimk.Size = style.FontSize * p0;
		}
		return z0ZzZzimk;
	}

	protected void z0yrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x20) : (z0iik & -33));
	}

	protected bool z0syk()
	{
		return (z0iik & 0x20000) != 0;
	}

	internal void z0yek(XTextContainerElement p0, XTextDocument p1, int p2)
	{
		z0uik = p0;
		z0rik = p1;
		z0buk = p2;
	}

	public virtual int z0tr()
	{
		return z0muk;
	}

	public virtual void z0oy(ElementEventArgs p0)
	{
		z0cu()?.z0rek(p0);
	}

	public virtual void z0oek(int p0)
	{
		if (z0buk != p0)
		{
			z0buk = p0;
			z0xi(p0: true);
			z0ruk = null;
			this.z0sik = null;
		}
	}

	public bool z0ayk()
	{
		return (z0iik & 0x20000000) != 0;
	}

	public z0ZzZzbdh z0qyk()
	{
		return z0py();
	}

	protected void z0urk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x1000000) : (z0iik & -16777217));
	}

	public string z0wyk()
	{
		return ID;
	}

	public virtual string z0eyk()
	{
		if (z0jr() == null)
		{
			return null;
		}
		using XTextDocument xTextDocument = z0ee_jiejie20260327142557(p0: false);
		return xTextDocument?.z0dmk();
	}

	protected bool z0ryk()
	{
		return (z0iik & 0x10000) != 0;
	}

	public virtual void z0iek(ElementMouseEventArgs p0)
	{
		z0cu()?.z0yek(p0);
	}

	protected void z0irk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x200) : (z0iik & -513));
	}

	public bool z0tyk()
	{
		if (z0ruk != null)
		{
			return z0ruk.z0jyk >= 0;
		}
		if (this.z0sik != null)
		{
			return this.z0sik.DeleterIndex >= 0;
		}
		if (z0buk >= 0)
		{
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0jr().z0gnk().GetStyle(z0buk);
			if (documentContentStyle != null)
			{
				return documentContentStyle.DeleterIndex >= 0;
			}
		}
		return false;
	}

	protected void z0ork(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x8000) : (z0iik & -32769));
	}

	protected bool z0yyk()
	{
		return (z0iik & 0x4000) != 0;
	}

	public z0ZzZzqbj z0uyk()
	{
		return z0cu()?.z0ypk();
	}

	public virtual XTextElement z0ke()
	{
		XTextContainerElement xTextContainerElement = z0ji();
		if (xTextContainerElement != null)
		{
			int num = xTextContainerElement.z0be().z0bek(this);
			if (num > 0)
			{
				return xTextContainerElement.z0be()[num - 1];
			}
		}
		return null;
	}

	public virtual XTextParagraphFlagElement z0dy()
	{
		return z0jr()?.z0jrk(this);
	}

	public virtual bool z0fek()
	{
		if (z0uik == null)
		{
			return false;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return false;
		}
		return xTextDocumentContentElement.z0zek() == this;
	}

	protected bool z0iyk()
	{
		return (z0iik & 0x100000) != 0;
	}

	internal bool z0oyk()
	{
		return false;
	}

	public virtual float z0ut()
	{
		return z0fik;
	}

	protected void z0prk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x800000) : (z0iik & -8388609));
	}

	public virtual XTextContainerElement z0ji()
	{
		return z0uik;
	}

	public virtual ParentType z0tek<ParentType>(bool p0) where ParentType : XTextElement
	{
		for (XTextElement xTextElement = (p0 ? this : z0ji()); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is ParentType)
			{
				return (ParentType)xTextElement;
			}
		}
		return null;
	}

	protected void z0mrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x1000) : (z0iik & -4097));
	}

	public virtual XTextDocument z0jr()
	{
		return z0rik;
	}

	public z0ZzZzbdh z0pyk()
	{
		return new z0ZzZzbdh(z0xik, z0wik, z0fik, z0aik);
	}

	public virtual DocumentViewOptions z0iu()
	{
		return z0rik?.z0iu();
	}

	public virtual z0ZzZzbdh z0myk_jiejie20260327142557()
	{
		z0ZzZzbdh z0ZzZzbdh = z0py();
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj != null)
		{
			z0ZzZzbdh = z0ZzZzrzj.z0eek(z0ZzZzbdh);
		}
		return z0ZzZzbdh;
	}

	public void z0nrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | -2147483648) : (z0iik & 0x7FFFFFFF));
	}

	public virtual void z0vw(z0ZzZzvxj p0)
	{
	}

	public bool z0brk(bool p0)
	{
		return z0or(p0, p1: true, p2: false);
	}

	internal DocumentContentStyle z0nyk()
	{
		DocumentContentStyle documentContentStyle = z0ruk?.z0jrk;
		if (documentContentStyle == null)
		{
			documentContentStyle = (DocumentContentStyle)(z0jr()?.z0gnk()?.GetStyle(z0buk));
		}
		return documentContentStyle;
	}

	public virtual string z0gy()
	{
		return ToString();
	}

	internal XTextElement z0byk()
	{
		return z0ptk()?.z0urk().z0xek(this);
	}

	protected bool z0vyk()
	{
		return (z0iik & 0x400) != 0;
	}

	internal void z0uek(XTextElement p0)
	{
		if (p0 != null && p0 != this)
		{
			this.z0sik = p0.z0sik;
			z0buk = p0.z0buk;
			z0ruk = p0.z0ruk;
		}
	}

	protected bool z0cyk()
	{
		return (z0iik & 0x800) != 0;
	}

	public virtual void z0oek(ElementMouseEventArgs p0)
	{
		z0cu()?.z0tek(p0);
	}

	public bool z0iek(XTextElement p0)
	{
		if (p0 != null && p0.z0uik == z0uik)
		{
			return true;
		}
		return false;
	}

	public float z0xyk()
	{
		return z0ZzZzrpk.z0eek(Width, GraphicsUnit.Document, GraphicsUnit.Pixel);
	}

	public Color z0yek(Color p0)
	{
		if (p0.A == 0 || p0.ToArgb() == z0wuk)
		{
			return p0;
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument != null && xTextDocument.z0iu().BothBlackWhenPrint && (xTextDocument.z0qtk().Printing || xTextDocument.z0qtk().PrintPreviewing))
		{
			return Color.Black;
		}
		return p0;
	}

	public virtual XTextElement z0lr(bool p0)
	{
		XTextElement obj = (XTextElement)MemberwiseClone();
		obj.z0sik = null;
		obj.z0kik = null;
		obj.z0uik = null;
		obj.z0xi(p0: true);
		obj.z0tuk = -1;
		obj.z0hrk(p0: true);
		return obj;
	}

	public virtual void z0nw(z0ZzZzuzj p0)
	{
		if (p0.z0tek == z0ZzZzuzj.z0yhj.z0eek)
		{
			p0.z0eek(ID);
		}
	}

	public virtual void z0bw_jiejie20260327142557(z0ygj p0)
	{
		p0.z0eek(Text);
	}

	protected bool z0zyk()
	{
		return (z0iik & 0x400000) != 0;
	}

	public bool z0luk()
	{
		return (z0iik & -2147483648) != 0;
	}

	public bool z0vrk(bool p0)
	{
		if (z0jr() != null)
		{
			DocumentContentStyle documentContentStyle = z0xrk();
			if (documentContentStyle.DeleterIndex != -1 || documentContentStyle.CreatorIndex != z0jr().z0syk().z0yek())
			{
				documentContentStyle.DeleterIndex = -1;
				documentContentStyle.CreatorIndex = z0jr().z0syk().z0yek();
				z0drk(p0);
				return true;
			}
		}
		return false;
	}

	protected bool z0kuk()
	{
		return (z0iik & 1) != 0;
	}

	public string z0yek(z0ZzZzdxj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		p0.z0eek(z0jr());
		z0fy(p0);
		return p0.ToString();
	}

	public virtual void z0jo()
	{
		if (z0cuk)
		{
			z0rik?.z0krk(this);
		}
	}

	public virtual void z0di(float p0)
	{
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj == null)
		{
			Height = p0;
		}
		else
		{
			Height = p0 + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk;
		}
	}

	public virtual int z0juk()
	{
		if (z0jr() == null)
		{
			return -1;
		}
		float num = z0ltk() + Height;
		return z0jr().z0suk().z0eek(num - 0.5f, -1);
	}

	public void z0crk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x10000000) : (z0iik & -268435457));
	}

	protected void z0xrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x4000000) : (z0iik & -67108865));
	}

	public int z0huk()
	{
		return z0tuk;
	}

	public void z0oek(XTextElement p0)
	{
		if (p0 != null)
		{
			z0rik = p0.z0rik;
			z0uik = p0.z0uik;
			z0ruk = null;
		}
	}

	protected string z0uek(string p0)
	{
		if (p0 != null)
		{
			p0 = p0.Replace("\\r\\n", Environment.NewLine);
		}
		return p0;
	}

	protected bool z0guk()
	{
		return (z0iik & 0x40000) != 0;
	}

	public bool z0uek(bool p0, bool p1)
	{
		if (z0jr() == null)
		{
			throw new NullReferenceException("this.OwnerDocument");
		}
		if (z0aek().z0jyk >= 0)
		{
			return false;
		}
		XTextDocument xTextDocument = z0jr();
		DocumentContentStyle documentContentStyle = z0aek().z0yek();
		documentContentStyle.z0eek(p0: false);
		documentContentStyle.DeleterIndex = xTextDocument.z0syk().z0yek();
		int styleIndex = xTextDocument.z0gnk().GetStyleIndex(documentContentStyle);
		if (p0)
		{
			if (xTextDocument.z0uik())
			{
				xTextDocument.z0imk().z0eek(this, z0pek(), styleIndex);
				xTextDocument.z0imk().z0eek(z0jy(), 0);
			}
			else if (xTextDocument.z0ytk())
			{
				xTextDocument.z0imk().z0eek(this, z0pek(), styleIndex);
				xTextDocument.z0imk().z0eek(z0jy(), 0);
				xTextDocument.z0nuk();
			}
		}
		z0oek(styleIndex);
		if (this is XTextFieldElementBase)
		{
			((XTextFieldElementBase)this).z0vek();
		}
		if (p1)
		{
			z0uu(p0: false);
		}
		return true;
	}

	public virtual bool z0uek(DocumentContentStyle p0)
	{
		if (z0rik == null)
		{
			throw new NullReferenceException(z0ZzZziok.z0cik());
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("style");
		}
		z0oek(z0jr().z0gnk().GetStyleIndex(p0));
		return true;
	}

	protected void z0zrk(bool p0)
	{
		z0iik = (p0 ? (z0iik | 0x40) : (z0iik & -65));
	}

	public virtual void z0iek(ElementKeyEventArgs p0)
	{
	}

	public virtual float z0fuk()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return 0f;
		}
		float num = z0cw();
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return 0f;
		}
		PageContentPartyStyle pageContentPartyStyle = xTextDocumentContentElement.z0fu();
		XPageSettings pageSettings = xTextDocument.PageSettings;
		switch (pageContentPartyStyle)
		{
		case PageContentPartyStyle.Header:
		case PageContentPartyStyle.HeaderForFirstPage:
			num = new z0ZzZzarj(pageSettings, p1: true, p2: false).z0vek() + num;
			break;
		case PageContentPartyStyle.Footer:
		case PageContentPartyStyle.FooterForFirstPage:
		{
			z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(pageSettings, p1: true, p2: false);
			float num2 = z0ZzZzarj2.z0nek() - z0ZzZzarj2.z0tek() - xTextDocumentContentElement.Height;
			num += num2;
			break;
		}
		default:
		{
			z0ZzZzwrj z0ZzZzwrj = xTextDocument.z0suk().z0rek(z0je());
			if (z0ZzZzwrj != null)
			{
				z0ZzZzarj z0ZzZzarj = new z0ZzZzarj(z0ZzZzwrj, p1: true);
				num = Math.Max(z0ZzZzarj.z0pek(), z0ZzZzarj.z0vek() + z0ZzZzwrj.z0prk()) + num - z0ZzZzwrj.z0irk();
			}
			break;
		}
		}
		return num;
	}

	public virtual void z0tt(z0ZzZzvxj p0)
	{
		z0vw(p0);
	}

	public virtual void z0xi(bool p0)
	{
		z0rrk(p0);
	}

	protected bool z0duk()
	{
		return (z0iik & 0x40) != 0;
	}
}
