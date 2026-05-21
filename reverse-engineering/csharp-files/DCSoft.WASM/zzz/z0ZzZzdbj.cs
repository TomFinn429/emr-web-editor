using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzdbj : z0ZzZzmwh
{
	public class z0cxk
	{
		public XTextElement z0eek;

		public XTextContainerElement z0rek;

		public XTextElement z0tek;

		public string z0yek;
	}

	private class z0xhj : z0ZzZzrmj
	{
		private new readonly z0ZzZzdbj z0eek;

		public override void z0iz(z0ZzZzomj p0)
		{
			z0eek.z0tek(p0);
		}

		public z0xhj(z0ZzZzdbj p0)
		{
			z0eek = p0;
		}
	}

	public delegate void z0cjj(z0ZzZzjeh parentWindow, string message, string details);

	internal static bool z0bpk = false;

	private z0ZzZzenj z0vpk;

	public static readonly string z0lmk = z0ZzZzook.z0eek();

	private static z0ZzZznwh z0kmk = null;

	private static z0ZzZznwh z0jmk = z0ZzZzbwh.z0krk;

	private static z0ZzZznwh z0hmk = z0ZzZzbwh.z0tek;

	private static int z0smk = 0;

	private z0ZzZzqbj z0imk;

	private float z0bmk = 1f;

	internal z0ZzZzynj z0xmk;

	internal z0ZzZzynj z0knk;

	private bool z0dnk;

	internal static long z0ank = 0L;

	private float z0qnk_jiejie20260327142557 = 1f;

	private static z0ZzZznwh z0tnk = null;

	private z0ZzZzbnj z0pnk;

	internal static string z0lbk = null;

	private z0ZzZzsbj z0jbk;

	private static z0ZzZznwh z0fbk = z0ZzZzbwh.z0mek;

	protected z0ZzZzlfh z0sbk;

	private bool z0qbk = true;

	private bool z0wbk;

	internal z0ZzZzoeh z0tbk;

	internal Color z0ybk = Color.Yellow;

	private bool z0ubk;

	public static z0cjj z0ibk = null;

	[DefaultValue(WriterDataFormats.All)]
	public WriterDataFormats AcceptDataFormats
	{
		get
		{
			return z0ypk().z0wtk();
		}
		set
		{
			z0ypk().z0tek(value);
		}
	}

	[DefaultValue(false)]
	public override bool AllowDrop
	{
		get
		{
			return z0ypk().AllowDrop;
		}
		set
		{
			z0ypk().AllowDrop = value;
		}
	}

	[DefaultValue(WriterDataFormats.All)]
	public WriterDataFormats CreationDataFormats
	{
		get
		{
			return z0ypk().z0tek();
		}
		set
		{
			z0ypk().z0yek(value);
		}
	}

	[DefaultValue(false)]
	public bool AllowDragContent
	{
		get
		{
			return z0ypk().z0prk();
		}
		set
		{
			z0ypk().z0oek(value);
		}
	}

	public new bool z0eek()
	{
		return z0ypk().z0ctk();
	}

	public virtual void z0eek(InsertObjectEventArgs p0)
	{
		z0bj("EventInsertObject", p0);
		if (!p0.Handled)
		{
			z0erk().z0en(p0);
		}
	}

	public new void z0eek(bool p0)
	{
		z0ypk().z0hrk(p0);
	}

	public new WriterControlExtViewMode z0rek()
	{
		return z0ypk().z0urk();
	}

	public virtual bool z0eek(string p0, string p1)
	{
		if (z0ypk() == null)
		{
			return false;
		}
		return z0ruk().z0cek(p0, p1);
	}

	public new void z0rek(bool p0)
	{
		z0wbk = p0;
	}

	public DocumentContentStyle z0tek()
	{
		return z0ruk()?.z0onk().z0tek();
	}

	public new string z0yek()
	{
		if (z0tbk != null)
		{
			string result = z0tbk.z0yek();
			z0tbk = null;
			return result;
		}
		return null;
	}

	public bool z0eek(XTextElement p0)
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0oek(p0);
	}

	public new bool z0uek()
	{
		return z0ypk().z0yuk();
	}

	public void z0tek(bool p0)
	{
		z0ypk().z0kik = p0;
	}

	public void z0yek(bool p0)
	{
		z0qbk = p0;
	}

	public void z0eek(z0ZzZzweh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0tek(p0);
		}
		z0imk.z0iek(p0);
	}

	public virtual void z0eek(FilterValueEventArgs p0)
	{
		z0crk().z0bx(p0);
	}

	public new byte[] z0iek()
	{
		z0ZzZzwmk z0ZzZzwmk2 = z0ruk().PageSettings.z0rek();
		if (z0ZzZzwmk2 != null && z0ZzZzwmk2.z0rek())
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8);
			z0ZzZzwmk2.z0eek(binaryWriter);
			z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(z0ruk().PageSettings, p1: false, p2: false);
			z0ZzZzarj2.z0eek(GraphicsUnit.Pixel);
			binaryWriter.Write((int)z0ZzZzarj2.z0xek());
			binaryWriter.Write((int)z0ZzZzarj2.z0nek());
			binaryWriter.Close();
			byte[] p = memoryStream.ToArray();
			memoryStream.Close();
			return z0ZzZzmuk.z0eek(p);
		}
		return null;
	}

	public void z0uek(bool p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0vek(p0);
		}
	}

	public new bool z0oek()
	{
		return z0ypk().z0fuk();
	}

	public new z0ZzZzlfh z0pek()
	{
		if (z0sbk != null)
		{
			return z0sbk;
		}
		return z0ZzZzlfh.z0iek();
	}

	public new string[] z0mek()
	{
		Hashtable hashtable = z0ruk()?.z0yuk();
		if (hashtable != null && hashtable.Count > 0)
		{
			List<string> list = new List<string>();
			foreach (string key in hashtable.Keys)
			{
				list.Add(key);
				list.Add((string)hashtable[key]);
			}
			return list.ToArray();
		}
		return null;
	}

	public new int z0nek()
	{
		if (z0ruk() == null)
		{
			return 0;
		}
		return z0ruk().z0qrk();
	}

	public void z0eek(z0ZzZzlfh p0)
	{
		z0sbk = p0;
	}

	public virtual void z0eek(WriterAfterExecuteEventExpressionEventArgs p0)
	{
		z0bj("EventAfterExecuteEventExpression", p0);
	}

	public new bool z0bek()
	{
		if (z0ruk() == null)
		{
			return false;
		}
		return z0ruk().z0wyk() is XTextSignImageElement;
	}

	public new DocumentViewOptions z0vek()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0crk().ViewOptions;
	}

	public new int z0cek()
	{
		if (z0ruk() == null)
		{
			return 0;
		}
		return z0ruk().z0qrk();
	}

	public void z0iek(bool p0)
	{
		z0ubk = p0;
	}

	public z0ZzZzdbj()
	{
		z0ZzZzopj.z0eek(this);
		z0urk();
		z0knk.z0eek(this);
		z0xmk.z0eek(this);
		z0rrk(p0: true);
		z0ZzZzsdh p = new z0ZzZzsdh(((z0ZzZzmwh)this).z0xek().z0pek(), 9f);
		z0knk.z0eek(p);
		z0xmk.z0eek(p);
		z0rrk(p0: false);
		z0imk.z0ax(z0qx());
		z0ZzZzqok.z0rek.z0sh("Create " + GetType().Name + " :" + Convert.ToString(z0smk++));
	}

	public new virtual void z0eek(string p0)
	{
		z0ypk().z0mek(p0);
	}

	public new static z0ZzZznwh z0xek()
	{
		if (z0tnk == null)
		{
			z0tnk = z0ZzZzppj.z0pek();
		}
		return z0tnk;
	}

	public virtual DateTime z0wj()
	{
		return z0ZzZzuyk.z0eek();
	}

	public virtual void z0oj()
	{
	}

	public new z0ZzZzyhh z0zek()
	{
		return z0ruk()?.z0muk();
	}

	public void z0eek(XPageSettings p0)
	{
		z0ypk().z0tek(p0);
	}

	public void z0oek(bool p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0nek(p0);
		}
	}

	public override void z0hz()
	{
		z0imk?.z0hz();
	}

	public void z0pek(bool p0)
	{
		((z0ZzZzspj)z0imk).z0eek();
		z0imk.z0qtk().z0xek(p0);
	}

	public string z0rek(string p0)
	{
		return z0ruk().z0gpk().z0tek_jiejie20260327142557(p0);
	}

	public new z0ZzZzwrj z0lrk()
	{
		return ((z0ZzZzqrj)z0imk)?.z0xek();
	}

	public void z0mek(bool p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0grk(p0);
		}
	}

	public new DataSourceBindingDescriptionList z0krk()
	{
		return z0ruk()?.z0ctk();
	}

	public new string z0jrk()
	{
		return z0ypk().z0ruk();
	}

	public void z0eek(z0ZzZzleh p0)
	{
		z0imk.z0uek(p0);
	}

	public new bool z0hrk()
	{
		return z0ypk().z0btk();
	}

	public virtual void z0bj(string p0, object p1)
	{
	}

	public void z0eek(z0ZzZzwrj p0)
	{
		if (z0imk != null)
		{
			z0imk.z0rek(p0);
		}
	}

	public XTextTableElement z0tek(string p0)
	{
		return z0srk(p0) as XTextTableElement;
	}

	public new bool z0grk()
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0trk();
	}

	public void z0eek(XTextSubDocumentElement p0, bool p1)
	{
		z0ruk().z0bek(p0, p1);
	}

	public new void z0frk()
	{
		z0tbk = z0ZzZzoeh.z0uek();
	}

	public XTextElementList z0eek(Type p0)
	{
		return z0ruk()?.z0me(p0);
	}

	public string z0drk()
	{
		return z0ruk()?.z0erk();
	}

	public void z0srk()
	{
		if (z0ruk() != null)
		{
			z0ruk().z0mrk();
			z0ruk().z0imk().Clear();
			if (z0imk != null)
			{
				z0imk.z0xek("Undo");
				z0imk.z0xek("Redo");
			}
		}
	}

	public virtual void z0eek(z0ZzZzomj p0)
	{
		z0bj("AfterExecuteCommand", p0);
	}

	public virtual void z0zj(XTextElementList p0, bool p1)
	{
	}

	public void z0ark()
	{
		if (z0imk != null)
		{
			z0imk.z0bek();
		}
	}

	public void z0yek(string p0)
	{
		z0tek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public new WriterDataObjectRange z0qrk()
	{
		return z0cuk().BehaviorOptions.DataObjectRange;
	}

	public string z0wrk()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0juk();
	}

	public z0ZzZzpxj z0erk()
	{
		if (z0ypk() == null)
		{
			return null;
		}
		return z0ypk().z0byk();
	}

	public string z0rrk()
	{
		return z0ruk()?.z0dpk();
	}

	public z0ZzZzerj z0trk()
	{
		return z0imk.z0rek();
	}

	public new PageTitlePosition z0yrk()
	{
		return z0ypk().z0muk();
	}

	private void z0urk()
	{
		z0imk = new z0ZzZzqbj(this);
		z0knk = new z0ZzZzynj();
		z0xmk = new z0ZzZzynj();
		z0knk.z0ax(z0ZzZzynj.z0grk);
		z0knk.z0eek(new z0ZzZzcdh(100000, 24));
		z0knk.z0eek("hrule");
		z0xmk.z0ax(z0ZzZzynj.z0grk);
		z0xmk.z0frk = (z0ZzZzunj)0;
		z0xmk.z0eek(new z0ZzZzcdh(24, 100000));
		z0xmk.z0eek("vrule");
	}

	public virtual void z0eek(WriterEventArgs p0, XTextElement p1, XTextElement p2)
	{
		z0bj("HoverElementChanged", p0);
	}

	public bool z0irk()
	{
		if (base.z0rek())
		{
			return true;
		}
		if (z0imk == null || ((z0ZzZzmwh)z0imk).z0rek())
		{
			return true;
		}
		return false;
	}

	public new bool z0ork()
	{
		if (z0ypk() != null)
		{
			return z0ypk().z0ork();
		}
		return false;
	}

	public void z0prk()
	{
		z0ZzZzplh z0ZzZzplh2 = z0imk?.z0qtk()?.z0ryk();
		if (z0ZzZzplh2 != null)
		{
			z0ZzZzplh2.z0uek(p0: true);
			z0ZzZzplh2.z0tek();
		}
	}

	public void z0nek(bool p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0rik = p0;
		}
	}

	public bool z0rek(string p0, string p1)
	{
		return z0ruk().z0vek(p0, p1);
	}

	public void z0eek(DocumentOptions p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public override void z0vjk(string p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0vjk(p0);
		}
	}

	public void z0bek(bool p0)
	{
		z0ypk().z0cek(p0);
	}

	public void z0vek(bool p0)
	{
		z0ypk().z0frk(p0);
	}

	public int z0eek(int p0, float p1)
	{
		if (z0imk == null)
		{
			return 0;
		}
		return z0imk.z0tek(p0, p1);
	}

	public static z0ZzZznwh z0mrk()
	{
		if (z0kmk == null)
		{
			z0kmk = z0ZzZzppj.z0eek();
		}
		return z0kmk;
	}

	internal virtual void z0eek(WriterTableRowHeightChangingEventArgs p0)
	{
		z0bj("EventTableRowHeightChanging", p0);
	}

	public virtual bool z0rj()
	{
		return false;
	}

	public bool z0eek(XTextElement p0, bool p1, bool p2)
	{
		return z0ypk().z0tek(p0, p1, p2);
	}

	public virtual void z0nj(XTextInputFieldElement p0, z0ZzZzdvj p1, Action<string, string> p2)
	{
	}

	public new int z0nrk()
	{
		if (z0imk == null)
		{
			return 0;
		}
		return z0imk.z0mtk();
	}

	public void z0eek(HeaderFooterFlagVisible p0)
	{
		z0imk.z0eek(p0);
	}

	public void z0uek(string p0)
	{
		z0ypk().z0oek(p0);
	}

	public void z0cek(bool p0)
	{
		z0ypk().z0rek(p0);
	}

	public DocumentContentAlignment z0brk()
	{
		return z0ruk().z0onk().z0uek().Align;
	}

	internal virtual void z0eek(StatusTextChangedEventArgs p0)
	{
		z0bj("StatusTextChanged", p0.StatusText);
	}

	public void z0eek(int p0, int p1, int p2, int p3, int p4, int p5)
	{
		z0ank = new DateTime(p0, p1, p2, p3, p4, p5).Ticks - z0ZzZzuyk.z0eek().Ticks;
	}

	public virtual void z0eek(WriterEventArgs p0)
	{
		z0bj("DocumentLoad", p0);
		p0.Dispose();
		z0ZzZzafh.z0uek("WriterControl.OnDocumentLoad");
	}

	public int z0vrk()
	{
		if (z0imk == null)
		{
			return 0;
		}
		return z0imk.z0otk();
	}

	public virtual void z0eek(WriterSectionElementCancelEventArgs p0)
	{
		z0bj("EventBeforeCollapseSection", p0);
	}

	public z0ZzZzsbj z0crk()
	{
		if (z0jbk == null)
		{
			z0jbk = z0ZzZzuok.z0eek<z0ZzZzsbj>();
			if (z0jbk != null)
			{
				z0jbk.z0eek(this);
			}
		}
		return z0jbk;
	}

	public virtual void z0eek(WriterLinkEventArgs p0)
	{
		z0crk().z0vx(p0);
	}

	public static void z0eek(z0ZzZznwh p0)
	{
		z0kmk = p0;
	}

	public bool z0xrk()
	{
		if (z0ypk() == null)
		{
			return true;
		}
		return z0ypk().z0tyk();
	}

	public bool z0zrk_jiejie20260327142557()
	{
		return z0dnk;
	}

	public bool z0ltk()
	{
		return z0ubk;
	}

	private XTextElement z0ktk()
	{
		XTextDocument xTextDocument = z0ruk();
		if (xTextDocument != null)
		{
			XTextElement xTextElement = xTextDocument.z0wyk();
			if (xTextElement is XTextSignImageElement)
			{
				return xTextElement;
			}
			return xTextDocument.z0itk();
		}
		return null;
	}

	public z0ZzZzylh z0jtk()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0qtk().z0ymk();
	}

	public bool z0eek(DCStdImageKey p0, string p1)
	{
		if (z0vyk().SetBitmapByBase64String(p0, p1))
		{
			z0ypk().z0mrk()?.z0uek();
			z0ypk().z0hz();
			return true;
		}
		return false;
	}

	public void z0eek(MoveTarget p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public virtual string z0iek(string p0)
	{
		return z0ruk()?.z0zek(p0);
	}

	public virtual void z0eek(WriterEditElementValueEventArgs p0)
	{
		z0bj("EventEditElementValue", p0);
	}

	public void z0htk()
	{
		z0wik();
		if (z0imk != null)
		{
			z0imk.z0yek();
		}
	}

	public DocumentSecurityOptions z0gtk()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0crk().SecurityOptions;
	}

	public void z0eek(bool p0, bool p1)
	{
		z0imk.z0tek(p0, p1);
	}

	public void z0xek(bool p0)
	{
		z0ypk().z0pek(p0);
	}

	public void z0zek(bool p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0ypk = p0;
		}
	}

	public bool z0eek(string p0, string p1, int p2)
	{
		return z0ypk().z0tek(p0, p1, p2);
	}

	public void z0oek(string p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public void z0rek(z0ZzZzweh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0rek(p0);
		}
		z0imk.z0uek(p0);
	}

	public void z0ftk()
	{
		if (z0knk.z0grk())
		{
			z0knk.z0eek(p0: true);
			z0knk.z0hz();
			z0xmk.z0eek(p0: true);
			z0xmk.z0hz();
		}
	}

	public byte[] z0eek(string p0, int p1, int p2)
	{
		z0ZzZzynj z0ZzZzynj2 = z0lrk(p0);
		if (z0ZzZzynj2 == z0knk)
		{
			z0ZzZzynj2.z0nrk = p1;
			z0ZzZzynj2.z0drk = 0;
		}
		else
		{
			z0ZzZzynj2.z0nrk = 0;
			z0ZzZzynj2.z0drk = p1;
		}
		z0ZzZzadh z0ZzZzadh2 = new z0ZzZzadh();
		z0ZzZzadh2.z0rek(z0ZzZzynj2.z0nrk, z0ZzZzynj2.z0drk);
		z0ZzZzynj2.z0eek(z0ZzZzadh2, new z0ZzZzndh(0, 0, ((z0ZzZzmwh)z0ZzZzynj2).z0mek(), z0ZzZzynj2.z0frk()));
		byte[] result = z0ZzZzadh2.z0iek();
		z0ZzZzadh2.Dispose();
		return result;
	}

	public void z0pek(string p0)
	{
		z0ypk().z0iek(p0);
	}

	internal virtual void z0eek(WriterSectionElementEventArgs p0)
	{
		z0bj("EventAfterCollapseSection", p0);
	}

	public void z0rek(z0ZzZzleh p0)
	{
		z0imk.z0tek(p0);
	}

	public bool z0rek(XTextElement p0)
	{
		return z0ZzZzdfh.z0rek().z0od(p0, DCCASignMode.Default);
	}

	public XTextInputFieldElement z0dtk()
	{
		return z0rek(typeof(XTextInputFieldElement)) as XTextInputFieldElement;
	}

	public virtual void z0cj(z0ZzZzrmj p0, z0ZzZzomj p1, Exception p2)
	{
		z0crk().z0cx(p0, p1, p2);
	}

	public bool z0stk()
	{
		return z0ruk().z0onk().z0tek().Italic;
	}

	public new void z0eek(int p0)
	{
		if (z0imk != null)
		{
			z0imk.z0eek(p0);
		}
	}

	public void z0tek(XTextElement p0)
	{
		if (z0imk != null)
		{
			z0imk.z0mek(p0);
		}
	}

	internal Dictionary<string, object> z0mek(string p0)
	{
		return z0ypk().z0yek(p0);
	}

	public void z0atk()
	{
		((z0ZzZzspj)z0imk).z0tek();
	}

	public PageViewMode z0qtk()
	{
		if (z0imk == null)
		{
			return PageViewMode.Page;
		}
		return ((z0ZzZzqrj)z0imk).z0uek();
	}

	public string z0wtk()
	{
		return z0ypk().z0iyk();
	}

	public int z0nek(string p0)
	{
		XTextDocument xTextDocument = z0ruk();
		if (xTextDocument == null)
		{
			return 0;
		}
		int num = 0;
		z0atk();
		try
		{
			num = xTextDocument.z0yrk(p0);
			if (num > 0 && xTextDocument.z0imk() != null)
			{
				xTextDocument.z0imk().Clear();
			}
		}
		finally
		{
			z0cyk();
		}
		if (num > 0 && xTextDocument.z0qtk().Layouted)
		{
			z0yrk(p0: false);
			xTextDocument.OnSelectionChanged();
		}
		return num;
	}

	public new void z0eek(z0ZzZzndh p0)
	{
		z0ypk().z0tek(p0);
	}

	public virtual void z0rek(z0ZzZzomj p0)
	{
		z0bj("BeforeExecuteCommand", p0);
	}

	public override Color z0qx()
	{
		return base.z0qx();
	}

	public bool z0etk()
	{
		XTextElement xTextElement = z0ktk();
		if (xTextElement != null)
		{
			return z0ZzZzdfh.z0rek().z0od(xTextElement, DCCASignMode.Default);
		}
		return false;
	}

	public string z0lrk(bool p0)
	{
		return z0ruk()?.z0wrk(p0);
	}

	public virtual z0ZzZzbnj z0lh()
	{
		return z0pnk;
	}

	public void z0tek(z0ZzZzleh p0)
	{
		z0imk.z0yek(p0);
	}

	public z0ZzZzxbj z0rtk()
	{
		if (z0ypk() == null)
		{
			return null;
		}
		return z0ypk().z0ktk();
	}

	public bool z0ttk()
	{
		return z0ypk().z0vtk();
	}

	public bool z0ytk()
	{
		return z0ruk().z0onk().z0tek().Underline;
	}

	public virtual void z0uj(WriterEventArgs p0)
	{
		z0bj("DocumentNavigateContentChanged", p0);
	}

	public void z0krk(bool p0)
	{
		z0ypk().z0mek(p0);
	}

	public bool z0utk()
	{
		if (z0ypk() != null)
		{
			return z0ypk().z0ypk;
		}
		return true;
	}

	public XTextParagraphFlagElement z0itk()
	{
		return z0ruk().z0mtk();
	}

	public void z0jrk(bool p0)
	{
		((z0ZzZzxnj)z0ypk()).z0tek(p0);
	}

	public void z0otk()
	{
		z0ypk().z0irk();
	}

	public z0ZzZzrmj z0ptk()
	{
		return new z0xhj(this);
	}

	public void z0eek(PageTitlePosition p0)
	{
		z0ypk().z0tek(p0);
	}

	public void z0eek(z0ZzZzvej p0)
	{
		z0ypk().z0tek(p0);
	}

	internal virtual void z0eek(ElementMouseEventArgs p0)
	{
		z0bj("EventElementMouseDblClick", p0);
	}

	public void GCCollect()
	{
		GC.Collect();
	}

	public static DateTime z0eek(DateTime p0)
	{
		return p0.AddTicks(z0ank);
	}

	public z0ZzZzznj z0mtk()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0ryk();
	}

	internal z0ZzZzlfh z0ntk()
	{
		if (z0sbk != null)
		{
			return z0sbk;
		}
		return z0ZzZzlfh.z0uek();
	}

	public PageContentPartyStyle z0btk()
	{
		if (z0imk == null)
		{
			return PageContentPartyStyle.Body;
		}
		return z0imk.z0kuk();
	}

	public bool z0eek(string p0, bool p1)
	{
		return z0ypk().z0tek(p0, p1);
	}

	public void z0eek(z0ZzZzkeh p0)
	{
		z0ypk().z0tek(p0);
	}

	public string z0bek(string p0)
	{
		return z0ruk()?.z0urk(p0);
	}

	public void z0hrk(bool p0)
	{
		z0ypk()?.z0zek(p0);
	}

	public XTextElementList z0vek(string p0)
	{
		return ((XTextContainerElement)z0ruk())?.z0jrk(p0);
	}

	internal virtual void z0eek(z0ZzZztzj p0)
	{
		z0bj("SelectionChanging", p0);
	}

	public float z0vtk()
	{
		return z0bmk;
	}

	public XTextTableElement z0ctk()
	{
		return z0rek(typeof(XTextTableElement)) as XTextTableElement;
	}

	public int z0xtk()
	{
		return (z0ruk()?.z0ryk()?.z0lrk())?.z0otk() ?? (-1);
	}

	public void z0eek(WriterControlExtViewMode p0)
	{
		z0ypk().z0tek(p0);
	}

	public string z0ztk()
	{
		return z0ypk().z0fpk;
	}

	public void z0eek(z0ZzZzerj p0)
	{
		z0imk.z0eek(p0);
	}

	public new void z0eek(Color p0)
	{
		z0knk.z0ax(p0);
		z0xmk.z0ax(p0);
	}

	public XTextElement z0eek(int p0, int p1)
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0tek(p0, p1);
	}

	public void z0eek(WriterGetSignToolTipEventArgs p0)
	{
		z0bj("EventGetSignToolTip", p0);
	}

	public string z0lyk()
	{
		return z0ypk().z0iek();
	}

	public virtual void z0eek(CanInsertObjectEventArgs p0)
	{
		if (z0imk.z0eyk() != DragOperationState.DragingSelection)
		{
			z0bj("EventCanInsertObject", p0);
			if (p0.Result || p0.Handled)
			{
				return;
			}
		}
		z0erk().z0zm(p0);
	}

	public static void z0rek(z0ZzZznwh p0)
	{
		z0jmk = p0;
	}

	public void z0eek(float p0)
	{
		z0bmk = p0;
	}

	public bool z0tek(string p0, string p1)
	{
		return z0ypk().z0tek(p0, p1);
	}

	public int z0cek(string p0)
	{
		return z0ruk()?.z0gnk().GetStyleIndexByString(p0) ?? (-1);
	}

	public Color z0kyk()
	{
		return ((z0ZzZzqrj)z0imk).z0jrk();
	}

	public object z0eek(string p0, z0ZzZzomj p1)
	{
		return z0ypk().z0tek(p0, p1);
	}

	public bool z0jyk()
	{
		if (z0imk == null)
		{
			return true;
		}
		return ((z0ZzZzspj)z0imk).z0hrk();
	}

	public XTextElement z0hyk()
	{
		XTextElementList xTextElementList = z0kok()?.z0grk();
		if (xTextElementList != null && xTextElementList.Count == 1)
		{
			return xTextElementList[0];
		}
		return null;
	}

	public z0ZzZzvej z0gyk()
	{
		return z0ypk().z0lyk();
	}

	public XTextInputFieldElement z0xek(string p0)
	{
		return z0srk(p0) as XTextInputFieldElement;
	}

	internal virtual void z0eek(ElementEventArgs p0)
	{
		z0bj("EventElementGotFocus", p0);
	}

	private static z0ZzZzsik z0fyk()
	{
		return new z0ZzZzsik
		{
			z0cek = 20230219,
			z0rek = 5,
			z0tek = true,
			z0nek = true,
			z0uek = 129
		};
	}

	public void z0zek(string p0)
	{
		z0ypk().z0fpk = p0;
	}

	public new byte[] z0rek(int p0)
	{
		return z0imk.z0uek(p0);
	}

	public void z0rek(float p0)
	{
		z0ypk().z0tek(p0);
	}

	public bool z0dyk()
	{
		bool result = z0imk.z0iok;
		z0imk.z0iok = false;
		return result;
	}

	public void z0grk(bool p0)
	{
		z0ypk().z0tek(p0, (DocumentEventArgs)null);
	}

	public void z0syk()
	{
		if (z0imk != null)
		{
			z0imk.z0huk();
		}
	}

	public int z0ayk()
	{
		return ((z0ZzZzqrj)z0imk).z0iek();
	}

	public bool z0tek(int p0)
	{
		return ((z0ZzZzqrj)z0imk).z0yek(p0);
	}

	public int z0qyk()
	{
		return z0nek(null);
	}

	public bool z0wyk()
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0htk();
	}

	public int z0eyk()
	{
		if (z0tbk == null)
		{
			return 0;
		}
		return z0tbk.z0rek();
	}

	public bool z0ryk()
	{
		return ((z0ZzZzqrj)z0imk).z0vek();
	}

	public bool z0tyk()
	{
		return z0knk.z0zek();
	}

	public void z0yek(int p0)
	{
		z0imk?.z0tek(p0);
	}

	public XTextTableRowElement z0yyk()
	{
		return z0rek(typeof(XTextTableRowElement)) as XTextTableRowElement;
	}

	public bool z0uyk()
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0stk();
	}

	public override void z0lz_jiejie20260327142557()
	{
		base.z0lz_jiejie20260327142557();
		if (z0knk != null)
		{
			z0knk.z0tek();
			z0knk.z0lz_jiejie20260327142557();
			z0knk = null;
		}
		if (z0xmk != null)
		{
			z0xmk.z0tek();
			z0xmk.z0lz_jiejie20260327142557();
			z0xmk = null;
		}
		if (z0imk != null)
		{
			z0imk.z0aik = true;
		}
		z0wik();
		if (z0utk() && z0imk != null)
		{
			z0imk.z0wyk();
		}
		if (z0imk != null)
		{
			z0imk.z0lz_jiejie20260327142557();
			z0imk = null;
		}
		z0sbk = null;
		z0fik();
	}

	public void z0iyk()
	{
		try
		{
			z0imk.z0xyk();
		}
		catch (Exception ex)
		{
			z0ZzZzfeh.z0eek(ex.ToString());
		}
	}

	private z0ZzZzynj z0lrk(string p0)
	{
		if (p0 == "hrule")
		{
			return z0knk;
		}
		return z0xmk;
	}

	public virtual void z0yj()
	{
	}

	public void z0eek(FormViewMode p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public void z0eek(z0ZzZzpxj p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public FunctionControlVisibility z0oyk()
	{
		return z0ypk().z0itk();
	}

	internal virtual void z0rek(ElementMouseEventArgs p0)
	{
		z0bj("EventElementMouseDown", p0);
	}

	public void z0eek(z0ZzZzheh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0eek(p0);
		}
		z0imk.z0uek(p0);
	}

	public DocumentComment z0pyk()
	{
		return z0imk?.z0drk()?.CurrentComment;
	}

	internal virtual void z0eek(ContentChangedEventArgs p0)
	{
		if (z0ruk().z0puk())
		{
			z0bj("EventContentChanged", p0);
		}
	}

	public bool z0myk()
	{
		return z0wbk;
	}

	public string z0nyk()
	{
		return z0ruk()?.z0nrk();
	}

	public bool z0yek(string p0, string p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		return z0cuk().z0eek(p0, p1);
	}

	public virtual void z0eek(z0ZzZzbnj p0)
	{
		((z0ZzZzmwh)z0imk).z0rek(1);
		((z0ZzZzmwh)z0imk).z0eek(1);
		z0eek(new z0ZzZzymj());
		z0muk().Start();
		z0imk.z0vyk();
		z0imk.z0uek(p0: false);
		z0imk.z0eek(base.z0nek());
		z0pnk = p0;
		z0ZzZzhbj.SetJSProivder(p0);
	}

	public void z0tek(float p0)
	{
		z0ypk().z0yek(p0);
	}

	public bool z0eek(string p0, string p1, string p2)
	{
		return z0ruk().z0vek(p0, p1, p2);
	}

	public bool z0rek(int p0, int p1)
	{
		if (z0ruk() == null)
		{
			return false;
		}
		return z0ruk().z0bek(p0, p1);
	}

	public bool z0byk()
	{
		return z0ZzZzdfh.z0rek().z0md_jiejie20260327142557(this);
	}

	public void z0eek(MoveFocusHotKeys p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public z0ZzZzovj z0vyk()
	{
		return z0ypk().z0vek();
	}

	public void z0cyk()
	{
		((z0ZzZzspj)z0imk).z0eek();
		z0imk.z0qtk().z0xek(p0: false);
	}

	internal virtual void z0eek(WriterTableRowHeightChangedEventArgs p0)
	{
		z0bj("EventTableRowHeightChanged", p0);
	}

	public void z0frk(bool p0)
	{
		z0imk.z0bek(p0);
	}

	public string z0xyk()
	{
		return GetType().FullName;
	}

	public new virtual void z0eek(EventArgs p0)
	{
		XTextDocument xTextDocument = z0ruk();
		z0knk.z0eek(xTextDocument.z0mtk());
		z0bj("SelectionChanged", p0);
		if (z0muk() != null)
		{
			z0muk().EditControl = this;
			z0ypk()?.z0ouk();
		}
	}

	public bool z0zyk()
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0ztk();
	}

	public void z0eek(string p0, object p1)
	{
		z0ruk().z0gpk().z0eek(p0, p1);
	}

	public XTextElementList z0luk()
	{
		return z0ruk()?.z0eyk();
	}

	public static z0ZzZznwh z0kuk()
	{
		if (z0fbk == null)
		{
			z0fbk = z0ZzZzbwh.z0mek;
		}
		return z0fbk;
	}

	public static z0ZzZznwh z0juk()
	{
		if (z0jmk == null)
		{
			z0jmk = z0ZzZzbwh.z0krk;
		}
		return z0jmk;
	}

	public bool z0huk()
	{
		return z0ruk().z0onk().z0tek().Superscript;
	}

	public bool z0drk(bool p0)
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0krk(p0);
	}

	public void z0yek(float p0)
	{
		z0qnk_jiejie20260327142557 = p0;
	}

	public Color z0guk()
	{
		return ((z0ZzZzqrj)z0imk).z0drk();
	}

	public void z0eek(FunctionControlVisibility p0)
	{
		z0ypk().z0tek(p0);
	}

	public int z0fuk()
	{
		if (z0imk == null)
		{
			return 0;
		}
		return z0imk.z0etk();
	}

	public void z0krk(string p0)
	{
		z0yek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public void z0rek(WriterEventArgs p0)
	{
		z0bj("EventTableAddNewRowWhenPressTabKey", p0);
	}

	public virtual bool z0duk()
	{
		return ((z0ZzZzxnj)z0imk).z0iek();
	}

	public string z0eek(string p0, z0ZzZzweh p1, z0ZzZzepj p2)
	{
		z0ZzZzynj z0ZzZzynj2 = z0lrk(p0);
		p1.z0eek(p1.z0rek() - z0ZzZzynj2.z0nrk);
		p1.z0rek(p1.z0tek() - z0ZzZzynj2.z0drk);
		if (p2 == (z0ZzZzepj)0)
		{
			z0ZzZzynj2.z0eek(p1, p2);
			if (z0ZzZzynj2.z0prk != null)
			{
				return "capturemouse";
			}
		}
		else
		{
			string text = z0ZzZzynj2.z0mrk;
			string text2 = z0ZzZzynj2.z0dx().z0eek();
			z0ZzZzynj2.z0eek(p1, p2);
			if (text != z0ZzZzynj2.z0mrk || text2 != z0ZzZzynj2.z0dx().z0eek())
			{
				return z0ZzZzynj2.z0mrk + "," + z0ZzZzynj2.z0dx().z0eek();
			}
		}
		return null;
	}

	public bool z0jrk(string p0)
	{
		if (!(z0srk(p0) is XTextCheckBoxElementBase xTextCheckBoxElementBase))
		{
			return false;
		}
		return xTextCheckBoxElementBase.Checked;
	}

	public virtual void z0eek(QueryUserHistoryDisplayTextEventArgs p0)
	{
		z0bj("QueryUserHistoryDisplayText", p0);
	}

	public virtual z0ZzZzenj z0suk()
	{
		return z0vpk;
	}

	public void z0eek(FormatListItemsEventArgs p0)
	{
		z0bj("EventFormatListItems", p0);
	}

	public static bool z0auk()
	{
		long ticks = DateTime.Now.Ticks;
		Type type = typeof(z0ZzZzdbj).Assembly.GetType("__DC20211119.JIEJIEPerformanceCounter", false, true);
		ticks = DateTime.Now.Ticks - ticks;
		if (type != null)
		{
			MethodInfo method = type.GetMethod("PublicStart", BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public);
			if (method != null)
			{
				method.Invoke(null, null);
				return true;
			}
		}
		return false;
	}

	public string z0quk()
	{
		return z0ZzZzifh.z0eek(z0kyk());
	}

	public z0ZzZzwcj z0wuk()
	{
		return z0ruk()?.Comments;
	}

	public XTextElement z0rek(Type p0)
	{
		return z0ruk()?.z0bek(p0, p1: true);
	}

	internal virtual void z0tek(WriterEventArgs p0)
	{
		z0bj("EventReadonlyChanged", p0);
	}

	public bool z0euk()
	{
		return z0ruk().z0qnk();
	}

	public XTextDocument z0ruk()
	{
		return z0imk?.z0qtk();
	}

	public z0ZzZzzlh z0tuk()
	{
		return z0ruk()?.z0jrk()?.z0uek();
	}

	public XPageSettings z0yuk()
	{
		return z0ypk().z0myk();
	}

	public object z0hrk(string p0)
	{
		return z0ypk().z0pek(p0);
	}

	public float z0uuk()
	{
		return z0ypk().z0tuk();
	}

	public void z0eek(WriterAfterFieldContentEditEventArgs p0)
	{
		z0bj("EventAfterFieldContentEdit", p0);
	}

	internal virtual void z0tek(z0ZzZzomj p0)
	{
		z0bj("EventUnknowCommand", p0);
	}

	public bool z0uek(string p0, string p1)
	{
		return z0ypk().z0yek(p0, p1);
	}

	public void z0iuk()
	{
		z0imk?.z0ark();
	}

	public bool z0eek(UserLoginInfo p0, bool p1)
	{
		return z0ypk().z0tek(p0, p1);
	}

	public void z0grk(string p0)
	{
		z0ypk().z0vik = p0;
	}

	public virtual void z0qj(string p0, object p1)
	{
	}

	public bool z0yek(XTextElement p0)
	{
		if (z0cuk().BehaviorOptions.FastInputMode && p0 is XTextInputFieldElementBase && base.z0eek())
		{
			z0eek((object)p0, (EventArgs)null);
			return true;
		}
		return false;
	}

	public bool EditLabelPageText(XTextLabelElement lbl)
	{
		return z0ZzZzdfh.z0rek().z0rek(this, lbl);
	}

	public void z0eek(PageContentPartyStyle p0)
	{
		if (z0imk != null)
		{
			z0imk.z0tek(p0);
		}
	}

	public bool z0eek(string p0, int p1, string p2, string p3, bool p4)
	{
		return z0ruk().z0bek(p0, p1, p2, p3, p4);
	}

	public string z0ouk()
	{
		return z0ruk()?.z0onk().z0tek().FontName;
	}

	public void z0puk_jiejie20260327142557()
	{
		if (z0imk != null)
		{
			z0imk.z0guk();
		}
	}

	public z0ZzZzymj z0muk()
	{
		return z0imk?.z0nyk();
	}

	public virtual void z0nuk()
	{
		WriterEventArgs e = new WriterEventArgs(this, z0ruk(), null);
		z0bj("EventOutlineTreeChanged", e);
		e.Dispose();
	}

	protected override void z0ec(z0ZzZzheh p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public float z0buk()
	{
		return z0ruk().z0onk().z0tek().FontSize;
	}

	public bool z0vuk()
	{
		return z0ruk().z0onk().z0tek().Bold;
	}

	public string z0eek(string p0, bool p1, bool p2, bool p3, bool p4)
	{
		if (z0ruk() == null)
		{
			return null;
		}
		return z0ruk().z0bek(p0, p1, p2, p3, p4);
	}

	public byte[] z0eek(int p0, bool p1)
	{
		return z0imk.z0yek(z0apk().z0rek(p0), p1);
	}

	public DocumentOptions z0cuk()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0crk();
	}

	public void z0uek(int p0)
	{
		z0ypk().z0yek(p0);
	}

	public bool z0eek(DCCASignMode p0)
	{
		XTextElement xTextElement = z0ktk();
		if (xTextElement != null)
		{
			return z0ZzZzdfh.z0rek().z0od(xTextElement, p0);
		}
		return false;
	}

	public override void z0ax(Color p0)
	{
		base.z0ax(Color.FromArgb(255, p0));
		z0imk.z0ax(p0);
	}

	public static void z0tek(z0ZzZznwh p0)
	{
		z0tnk = p0;
	}

	public string z0xuk()
	{
		Hashtable hashtable = z0ruk()?.z0yuk();
		if (hashtable != null && hashtable.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in hashtable.Keys)
			{
				string p = (string)hashtable[key];
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('&');
				}
				stringBuilder.Append(z0ZzZztwh.z0yek(key));
				stringBuilder.Append('=');
				stringBuilder.Append(z0ZzZztwh.z0yek(p));
			}
			return stringBuilder.ToString();
		}
		return null;
	}

	public z0ZzZzygh z0zuk()
	{
		return z0ruk().z0kpk();
	}

	protected override void z0sx(z0ZzZzgeh p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0);
		}
	}

	public bool z0eek(XTextElement p0, DCSignInputInfo p1)
	{
		return z0ZzZzdfh.z0rek().z0td(p0, p1);
	}

	public string z0lik()
	{
		if (z0ypk() == null)
		{
			return null;
		}
		return z0ypk().z0yrk();
	}

	public static string z0iek(string p0, string p1)
	{
		p0 = z0ZzZzafh.z0yek(p0);
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzsik obj = z0fyk();
		obj.Add(122);
		obj.Add(p1);
		obj.Add(z0ZzZzook.z0rek());
		obj.Add(z0pik().Ticks);
		string text = z0ZzZzqik.z0eek(obj.z0eek());
		return p0 + "?wasm=" + text;
	}

	internal bool z0kik()
	{
		return true;
	}

	public bool z0tek(int p0, int p1)
	{
		if (z0ypk() == null)
		{
			return false;
		}
		return z0ypk().z0uek(p0, p1);
	}

	public MoveFocusHotKeys z0jik()
	{
		if (z0ypk() == null)
		{
			return MoveFocusHotKeys.None;
		}
		return z0ypk().z0gyk();
	}

	public bool z0hik()
	{
		return z0imk.z0utk();
	}

	public static void z0yek(z0ZzZznwh p0)
	{
		z0fbk = p0;
	}

	internal void z0gik()
	{
	}

	protected virtual void z0fik()
	{
		if (z0jbk != null)
		{
			z0jbk.Dispose();
			z0jbk = null;
		}
		if (z0knk != null)
		{
			z0knk.z0tek();
			z0knk = null;
		}
		if (z0xmk != null)
		{
			z0xmk.z0tek();
			z0xmk = null;
		}
		z0wik();
		if (z0utk() && z0ypk() != null)
		{
			z0ypk().z0wyk();
		}
		z0vpk = null;
		z0imk = null;
		z0knk = null;
		z0xmk = null;
		z0ubk = false;
		if (z0imk != null)
		{
			z0imk.z0qtk().Dispose();
			z0imk.z0lz_jiejie20260327142557();
		}
		z0imk = null;
		z0knk = null;
		z0xmk = null;
		z0sbk = null;
	}

	public void z0srk(bool p0)
	{
		z0imk.z0lrk(p0);
	}

	public XTextElementList z0dik()
	{
		return z0eek(typeof(XTextCheckBoxElement));
	}

	public DocumentBehaviorOptions z0sik()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0crk().BehaviorOptions;
	}

	public bool z0aik()
	{
		if (z0imk != null && !((z0ZzZzmwh)z0imk).z0rek())
		{
			return true;
		}
		return false;
	}

	public object z0eek(string p0, bool p1, object p2)
	{
		return z0ypk().z0tek(p0, p1, p2);
	}

	public void z0eek(string p0, ref bool p1, ref bool p2, ref bool p3)
	{
		z0ZzZzrmj command = z0muk().GetCommand(p0);
		if (command == null)
		{
			p1 = false;
			return;
		}
		p1 = true;
		z0ZzZzomj z0ZzZzomj2 = new z0ZzZzomj(this, z0ruk(), (z0ZzZzmmj)2, z0muk());
		z0ZzZzomj2.ShowUI = true;
		command.z0iz(z0ZzZzomj2);
		p3 = z0ZzZzomj2.Checked;
		p2 = z0ZzZzomj2.Enabled;
	}

	public void z0eek(z0ZzZzymj p0)
	{
		z0imk.z0tek(p0);
		if (p0 != null)
		{
			p0.EditControl = this;
		}
	}

	public float z0qik()
	{
		return z0qnk_jiejie20260327142557;
	}

	internal void z0wik()
	{
		z0ruk()?.z0htk()?.z0sp();
		if (z0erk() != null)
		{
			z0erk().z0jm();
		}
		if (z0knk != null)
		{
			z0knk.z0nek();
		}
		if (z0xmk != null)
		{
			z0xmk.z0nek();
		}
	}

	internal void z0eek(XTextDocumentContentElement p0)
	{
		z0imk?.z0tek(p0);
	}

	public XTextElement z0eik()
	{
		return z0imk?.z0ltk();
	}

	public XTextSubDocumentElement z0rik()
	{
		return z0ruk().z0ayk();
	}

	public z0ZzZzoxj z0tik()
	{
		return z0imk?.z0drk();
	}

	public virtual void z0ij(string p0)
	{
	}

	public void z0eek(WriterDataObjectRange p0)
	{
		z0cuk().BehaviorOptions.DataObjectRange = p0;
	}

	internal virtual void z0eek(GetLinkListItemsEventArgs p0)
	{
		z0bj("EventGetLinkListItems", p0);
	}

	public string z0yik()
	{
		return z0ZzZzifh.z0eek(z0guk());
	}

	public XTextElement z0frk(string p0)
	{
		return z0ruk()?.z0ork(p0);
	}

	public object z0eek(string p0, bool p1, object p2, bool p3)
	{
		return z0ypk().z0tek(p0, p1, p2, p3);
	}

	public Color z0uik()
	{
		return z0knk.z0qx();
	}

	internal virtual void z0tek(ElementMouseEventArgs p0)
	{
		z0bj("EventElementMouseMove", p0);
	}

	public bool z0drk(string p0)
	{
		XTextElement xTextElement = z0srk(p0);
		if (xTextElement != null)
		{
			xTextElement.z0sr();
			return true;
		}
		return false;
	}

	public void z0eek(XTextElement p0, JumpPrintPositionMode p1, XTextElement p2, JumpPrintPositionMode p3)
	{
		if (z0imk != null)
		{
			JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
			jumpPrintInfo.Enabled = true;
			jumpPrintInfo.Mode = JumpPrintMode.Normal;
			jumpPrintInfo.z0rek(p0);
			jumpPrintInfo.StartPositionMode = p1;
			jumpPrintInfo.z0eek(p2);
			jumpPrintInfo.EndPositionMode = p3;
			z0eek(jumpPrintInfo);
			z0ruk().z0bek(jumpPrintInfo);
			z0imk.z0hz();
			z0imk.z0xek("JumpPrintMode");
		}
	}

	public z0ZzZzyrj z0iik()
	{
		return z0ypk().z0yyk();
	}

	public bool z0rek(string p0, string p1, int p2)
	{
		return z0ypk().z0yek(p0, p1, p2);
	}

	public XTextElement z0srk(string p0)
	{
		return z0ruk()?.z0ki(p0);
	}

	public bool z0eek(XTextElement p0, bool p1, ValueEditorActiveMode p2, bool p3, bool p4)
	{
		if (z0imk == null)
		{
			return false;
		}
		return z0imk.z0tek(p0, p1, p2, p3, p4);
	}

	public virtual string z0mj()
	{
		if (typeof(z0ZzZzqbj.z0dgj).Name == "WASMClientPosInfo")
		{
			return "都昌内部版本 V" + z0ZzZzook.z0tek();
		}
		return null;
	}

	public virtual void z0ark(bool p0)
	{
		((z0ZzZzxnj)z0imk).z0yek(p0);
	}

	internal bool z0rek(XTextElement p0, bool p1, ValueEditorActiveMode p2, bool p3, bool p4)
	{
		if (z0imk == null)
		{
			return false;
		}
		if (z0mtk().z0wx())
		{
			z0mtk().z0tx();
			return false;
		}
		return z0imk.z0tek(p0, p1, p2, p3, p4);
	}

	public bool z0oik()
	{
		if (z0ypk() == null)
		{
			return false;
		}
		return z0ypk().z0rik;
	}

	public void z0rek(EventArgs p0)
	{
		z0imk.z0tek(p0);
	}

	public static DateTime z0pik()
	{
		DateTime dateTime = z0ZzZzuyk.z0eek().AddTicks(z0ank);
		return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
	}

	public bool z0mik()
	{
		return z0imk.z0ttk();
	}

	public DocumentEditOptions z0nik()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0crk().EditOptions;
	}

	public virtual object z0pj(string p0, object[] p1)
	{
		return null;
	}

	public void z0bik()
	{
		if (z0imk != null)
		{
			z0imk.z0vrk();
		}
	}

	public void z0vik()
	{
		if (z0imk != null)
		{
			z0imk.z0nek();
		}
	}

	public bool z0cik()
	{
		if (z0ypk() == null)
		{
			return false;
		}
		return z0ypk().z0oyk();
	}

	public string z0xik()
	{
		return z0ypk().z0vik;
	}

	public void z0eek(PageViewMode p0)
	{
		z0rek(p0);
	}

	public XTextElementList z0zik()
	{
		return z0ruk().z0hik();
	}

	public void z0lok()
	{
		z0ZzZzplh z0ZzZzplh2 = z0imk?.z0qtk()?.z0ryk();
		if (z0ZzZzplh2 != null)
		{
			z0ZzZzplh2.z0uek(p0: true);
			z0ZzZzplh2.z0grk();
		}
	}

	public z0ZzZzsmk z0eek(float p0, float p1)
	{
		return z0imk?.z0tek(p0, p1);
	}

	public z0ZzZzhkh z0kok()
	{
		return z0imk?.z0qtk()?.z0cuk();
	}

	public bool z0jok()
	{
		return z0ruk().z0onk().z0tek().Subscript;
	}

	public Color z0hok()
	{
		return ((z0ZzZzqrj)z0ypk()).z0mek();
	}

	public float z0gok()
	{
		return z0ypk().z0qyk();
	}

	public void z0rek(Color p0)
	{
		((z0ZzZzqrj)z0imk).z0tek(p0);
	}

	public HeaderFooterFlagVisible z0fok()
	{
		return ((z0ZzZzqrj)z0imk).z0nek();
	}

	public int z0dok()
	{
		if (z0imk == null)
		{
			return 0;
		}
		return z0imk.z0mek();
	}

	public bool z0sok()
	{
		if (z0ypk() == null)
		{
			return false;
		}
		return z0ypk().z0ntk();
	}

	public void z0ark(string p0)
	{
		z0ypk().z0lrk(p0);
	}

	public new void z0qrk(bool p0)
	{
		((z0ZzZzqrj)z0imk).z0eek(p0);
	}

	public new void z0qrk(string p0)
	{
		z0rek(z0ZzZzlok.z0eek(p0, z0ZzZzhsh.z0tek));
	}

	internal virtual void z0eek(PromptProtectedContentEventArgs p0)
	{
		z0bj("EventPromptProtectedContent", p0);
	}

	public int z0aok()
	{
		return z0nek(null);
	}

	protected override void z0hx(z0ZzZzheh p0)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0yek(p0);
		}
	}

	public bool z0eek(XTextContainerElement p0, string p1, string p2, bool p3)
	{
		return z0ruk().z0bek(p0, p1, p2, p3);
	}

	public bool z0qok()
	{
		XTextDocument xTextDocument = z0ruk();
		if (xTextDocument.z0iik() != 0f)
		{
			xTextDocument.z0bek(0f);
			z0eek(p0: false, p1: true);
			return true;
		}
		return false;
	}

	public virtual void z0eek(string p0, string p1, string p2, XTextElement p3)
	{
		z0bj("EventElementCheckedChanged", new string[3] { p0, p1, p2 });
	}

	public void z0eek(bool p0, string p1)
	{
		z0ypk().z0tek(p0, p1);
	}

	public static z0ZzZznwh z0wok()
	{
		if (z0hmk == null)
		{
			z0hmk = z0ZzZzbwh.z0tek;
		}
		return z0hmk;
	}

	public static void z0uek(z0ZzZznwh p0)
	{
		z0hmk = p0;
	}

	public void z0rek(z0ZzZzheh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0rek(p0);
		}
		z0imk.z0iek(p0);
	}

	public void z0eek(z0ZzZzyrj p0)
	{
		z0ypk().z0tek(p0);
	}

	public bool z0wrk(string p0)
	{
		return z0ruk().z0grk(p0);
	}

	public virtual bool z0eek(string p0, int p1, int p2, string p3)
	{
		if (z0ruk() == null)
		{
			return false;
		}
		return z0ruk().z0bek(p0, p1, p2, p3);
	}

	public bool z0erk(string p0)
	{
		return z0ypk().z0vek(p0);
	}

	public string z0oek(string p0, string p1)
	{
		return z0ruk().z0krk(p0, p1);
	}

	public bool z0eok()
	{
		return z0ypk().z0zek();
	}

	public virtual void z0rek(WriterSectionElementEventArgs p0)
	{
		z0bj("EventAfterExpandSection", p0);
	}

	public void z0rok()
	{
		z0ZzZzplh z0ZzZzplh2 = z0imk?.z0qtk()?.z0ryk();
		if (z0ZzZzplh2 != null)
		{
			z0ZzZzplh2.z0uek(p0: true);
			z0ZzZzplh2.z0wrk();
		}
	}

	public int z0tok()
	{
		return (z0imk?.z0qtk()?.z0ryk()?.z0lrk())?.z0mrk() ?? (-1);
	}

	public XTextTableCellElement z0yok()
	{
		return z0rek(typeof(XTextTableCellElement)) as XTextTableCellElement;
	}

	public void z0uok()
	{
		z0ZzZzplh z0ZzZzplh2 = z0imk?.z0qtk()?.z0ryk();
		if (z0ZzZzplh2 != null)
		{
			z0ZzZzplh2.z0uek(p0: true);
			z0ZzZzplh2.z0bek();
		}
	}

	public string z0iok()
	{
		return z0ZzZzifh.z0eek(z0qx());
	}

	public override z0ZzZznwh z0dx()
	{
		return z0imk.z0dx();
	}

	internal virtual void z0rek(ElementEventArgs p0)
	{
		z0bj("EventElementLostFocus", p0);
	}

	public virtual void z0eek(XTextElement p0, XTextElement p1)
	{
		z0ypk().z0tek(p0, p1);
	}

	public FormViewMode z0ook()
	{
		if (z0ypk() == null || z0ypk().z0uek() == FormViewMode.Disable)
		{
			return FormViewMode.Disable;
		}
		if (z0ypk() == null)
		{
			return FormViewMode.Disable;
		}
		return z0ypk().z0uek();
	}

	private void z0eek(object p0, EventArgs p1)
	{
		z0ypk().z0kx();
		XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0;
		if (xTextInputFieldElementBase == null)
		{
			return;
		}
		z0ZzZzplh z0ZzZzplh2 = xTextInputFieldElementBase.z0qek().z0frk();
		switch (xTextInputFieldElementBase.z0rek())
		{
		case DCFastInputMode.AfterFieldBegin:
		{
			int num = z0ZzZzplh2.IndexOf(((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk());
			if (num >= 0)
			{
				z0ZzZzplh2.z0tek(num + 1, p1: false);
			}
			break;
		}
		case DCFastInputMode.AfterFieldEnd:
		{
			int num3 = z0ZzZzplh2.IndexOf(((XTextFieldElementBase)xTextInputFieldElementBase).z0tek());
			if (num3 >= 0)
			{
				z0ZzZzplh2.z0tek(num3 + 1, p1: false);
			}
			break;
		}
		case DCFastInputMode.BeforeFieldBegin:
		{
			int num4 = z0ZzZzplh2.IndexOf(((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk());
			if (num4 >= 0)
			{
				z0ZzZzplh2.z0tek(num4, p1: false);
			}
			break;
		}
		case DCFastInputMode.BeforeFieldEnd:
		{
			int num2 = z0ZzZzplh2.IndexOf(((XTextFieldElementBase)xTextInputFieldElementBase).z0tek());
			if (num2 >= 0)
			{
				z0ZzZzplh2.z0tek(num2, p1: false);
			}
			break;
		}
		case DCFastInputMode.NextField:
			xTextInputFieldElementBase.z0xek()?.z0sr();
			break;
		case DCFastInputMode.None:
			break;
		}
	}

	public string z0pok()
	{
		return z0ZzZzifh.z0eek(z0hok());
	}

	public string z0rrk(string p0)
	{
		return z0ZzZzafh.z0pek(p0);
	}

	public bool z0mok()
	{
		bool num = z0ruk().z0ztk();
		if (num)
		{
			z0eek(p0: false, p1: true);
			z0tek((EventArgs)null);
			z0eek((EventArgs)null);
		}
		return num;
	}

	public void z0eek(WriterBeforeFieldContentEditEventArgs p0)
	{
		z0bj("EventBeforeFieldContentEdit", p0);
	}

	public void z0pek(string p0, string p1)
	{
		z0ruk().z0gpk().z0eek(p0, p1);
	}

	public bool z0nok()
	{
		return true;
	}

	internal virtual void z0eek(ElementValidatingEventArgs p0)
	{
		z0bj("EventElementValidating", p0);
	}

	public void z0bok()
	{
		z0ZzZzplh z0ZzZzplh2 = z0imk?.z0qtk()?.z0ryk();
		if (z0ZzZzplh2 != null)
		{
			z0ZzZzplh2.z0uek(p0: true);
			z0ZzZzplh2.z0iek();
		}
	}

	public void z0wrk(bool p0)
	{
		if (z0imk != null)
		{
			z0imk.z0tek(p0);
		}
	}

	public void z0eek(ScrollToViewStyle p0)
	{
		if (z0imk != null)
		{
			z0imk.z0tek(p0);
		}
	}

	public void z0tek(z0ZzZzweh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0yek(p0);
		}
		z0imk.z0oek(p0);
	}

	public void z0eek(JumpPrintInfo p0)
	{
		z0ypk().z0tek(p0);
	}

	public void z0trk(string p0)
	{
		z0ypk().z0zek(p0);
	}

	internal virtual void z0yek(ElementMouseEventArgs p0)
	{
		z0bj("EventElementMouseUp", p0);
	}

	public bool z0rek(string p0, bool p1)
	{
		if (!(z0srk(p0) is XTextCheckBoxElementBase xTextCheckBoxElementBase))
		{
			return false;
		}
		xTextCheckBoxElementBase.InnerEditorChecked = p1;
		return true;
	}

	public bool z0rek(XTextElement p0, bool p1, bool p2)
	{
		return z0ypk().z0yek(p0, p1, p2);
	}

	public static string z0iek(int p0)
	{
		Type type = typeof(z0ZzZzdbj).Assembly.GetType("__DC20211119.JIEJIEPerformanceCounter", false, true);
		if (type != null)
		{
			MethodInfo method = type.GetMethod("AnalyseSimple", BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public);
			if (method != null)
			{
				return (string)method.Invoke(null, new object[2] { p0, 1 });
			}
		}
		return null;
	}

	public void z0vok()
	{
		z0ypk().z0pyk();
	}

	public override void z0fx(z0ZzZznwh p0)
	{
		z0imk.z0fx(p0);
	}

	public bool z0cok()
	{
		if (z0ypk() == null)
		{
			return false;
		}
		return z0ypk().z0kx();
	}

	public virtual string z0rek(string p0, int p1, int p2)
	{
		if (z0ruk() == null)
		{
			return null;
		}
		return z0ruk().z0bek(p0, p1, p2);
	}

	public z0ZzZzylh z0xok()
	{
		if (z0imk == null)
		{
			return null;
		}
		return z0imk.z0qtk().z0stk();
	}

	public void z0yek(z0ZzZzweh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0uek(p0);
		}
		z0imk.z0tek(p0);
	}

	public string z0zok()
	{
		return z0ypk().z0nuk();
	}

	public void z0erk(bool p0)
	{
		z0ypk().z0yek(p0);
	}

	public void z0eek(z0ZzZzgeh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0eek(p0);
		}
		z0imk.z0yek(p0);
	}

	public void z0rrk(bool p0)
	{
		if (z0dnk != p0)
		{
			z0dnk = p0;
		}
	}

	public string z0lpk()
	{
		return z0imk?.z0qtk()?.z0cuk()?.z0wrk();
	}

	public void z0kpk()
	{
		z0ypk()?.z0iek(500);
	}

	public virtual XTextElement z0tek(string p0, bool p1)
	{
		return z0ruk()?.z0cek(p0, p1);
	}

	public void z0eek(z0ZzZzzlh p0, PageContentPartyStyle p1)
	{
		z0imk?.z0tek(p0, p1);
	}

	public int z0jpk()
	{
		if (z0imk == null)
		{
			return 1;
		}
		return ((z0ZzZzqrj)z0imk).z0oek();
	}

	public void z0uek(z0ZzZzweh p0)
	{
		if (z0tbk != null)
		{
			z0tbk.z0eek(p0);
		}
		z0imk.z0yek(p0);
	}

	public override string z0jhk()
	{
		if (z0ypk() == null)
		{
			return null;
		}
		return z0ypk().z0jhk();
	}

	public int z0hpk()
	{
		return z0ypk().z0euk();
	}

	internal virtual void z0eek(ContentChangingEventArgs p0)
	{
		if (z0ruk().z0puk())
		{
			z0bj("EventContentChanging", p0);
		}
	}

	public void z0trk(bool p0)
	{
		z0knk.z0tek_jiejie20260327142557(p0);
		z0knk.z0tek_jiejie20260327142557(p0);
	}

	public bool z0yek(string p0, bool p1)
	{
		return z0ruk().z0vek(p0, p1);
	}

	public new void z0yrk(bool p0)
	{
		XTextDocument xTextDocument = z0imk?.z0qtk();
		if (!base.z0eek() || xTextDocument == null)
		{
			return;
		}
		try
		{
			z0ZzZzdbj.z0bpk = true;
			xTextDocument.z0wck = ((z0ZzZzqrj)z0ypk()).z0uek() == PageViewMode.CompressPage;
			xTextDocument.z0vek(p0);
			if (xTextDocument.z0qtk().Printing || xTextDocument.z0qtk().PrintPreviewing)
			{
				JumpPrintInfo jumpPrintInfo = z0qpk();
				if (jumpPrintInfo != null && (jumpPrintInfo.z0tek() != null || jumpPrintInfo.z0rek() != null))
				{
					xTextDocument.z0bek(jumpPrintInfo);
				}
			}
			z0fpk();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					((XTextDocumentContentElement)z0bpk.Current).z0frk();
				}
			}
			z0imk.z0hz();
		}
		finally
		{
			z0ZzZzdbj.z0bpk = false;
		}
	}

	public bool z0gpk()
	{
		return z0ypk().z0eek();
	}

	public void z0fpk()
	{
		z0imk.z0sc();
		z0ftk();
	}

	public bool z0eek(byte[] p0, string p1)
	{
		return z0ypk().z0tek(p0, p1);
	}

	public bool z0eek(XTextContainerElement p0)
	{
		return z0ypk().z0tek(p0);
	}

	public bool z0dpk()
	{
		return ((z0ZzZzxnj)z0ypk()).z0uek();
	}

	public new string z0yrk(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		return z0cuk().z0eek(p0);
	}

	public bool z0rek(XTextElement p0, XTextElement p1)
	{
		if (z0ruk() == null)
		{
			return false;
		}
		return z0ruk().z0cek(p0, p1);
	}

	public virtual void z0ej(string p0)
	{
	}

	public void z0tek(Color p0)
	{
		z0imk.z0eek(p0);
	}

	public virtual void z0tek(EventArgs p0)
	{
		z0crk().z0xx(p0);
	}

	public void z0eek(z0ZzZzbdh p0, PageContentPartyStyle p1)
	{
		z0imk?.z0tek(p0, p1);
	}

	public XTextElement z0urk(string p0)
	{
		return ((XTextContainerElement)z0ruk())?.z0lrk(p0);
	}

	public virtual void z0eek(z0ZzZzenj p0)
	{
		z0vpk = p0;
	}

	public void z0yek(Color p0)
	{
		z0ypk().z0rek(p0);
	}

	public virtual void z0rek(WriterSectionElementCancelEventArgs p0)
	{
		z0bj("EventBeforeExpandSection", p0);
	}

	public XTextElementList z0irk(string p0)
	{
		return z0ruk()?.z0yu(p0);
	}

	public z0cxk z0spk()
	{
		z0ZzZzplh z0ZzZzplh2 = z0ruk().z0ryk();
		StringBuilder stringBuilder = new StringBuilder();
		XTextContainerElement xTextContainerElement = null;
		XTextElement xTextElement = null;
		for (int num = z0ZzZzplh2.z0erk() - 1; num >= 0; num--)
		{
			XTextElement xTextElement2 = z0ZzZzplh2[num];
			if (!(xTextElement2 is XTextCharElement))
			{
				break;
			}
			if (xTextContainerElement == null)
			{
				xTextContainerElement = xTextElement2.z0ji();
			}
			else if (xTextContainerElement != xTextElement2.z0ji())
			{
				break;
			}
			char c = ((XTextCharElement)xTextElement2).z0mek();
			if (!char.IsLetterOrDigit(c) && !z0ZzZzwik.z0eek(c))
			{
				break;
			}
			stringBuilder.Insert(0, c);
			xTextElement = xTextElement2;
		}
		if (stringBuilder.Length > 0)
		{
			return new z0cxk
			{
				z0yek = stringBuilder.ToString(),
				z0tek = xTextElement,
				z0eek = z0ZzZzplh2[z0ZzZzplh2.z0erk() - 1],
				z0rek = xTextContainerElement
			};
		}
		return null;
	}

	public z0ZzZzerj z0apk()
	{
		return ((z0ZzZzqrj)z0imk).z0frk();
	}

	public JumpPrintInfo z0qpk()
	{
		return z0ypk().z0syk();
	}

	public virtual string z0tj()
	{
		return null;
	}

	public new void z0ork(string p0)
	{
		z0ax(z0ZzZzlok.z0eek(p0, z0ZzZzhsh.z0uek));
	}

	public string z0wpk()
	{
		return z0ypk().z0srk();
	}

	internal virtual void z0eek(WriterDrawShapeContentEventArgs p0)
	{
		z0bj("EventDrawShapeContent", p0);
	}

	public virtual void z0eek(WriterBeforeUIKeyboardInputStringEventArgs p0)
	{
		z0bj("EventBeforeUIKeyboardInputString", p0);
	}

	public void z0epk()
	{
		z0ZzZzplh z0ZzZzplh2 = z0imk?.z0qtk()?.z0ryk();
		if (z0ZzZzplh2 != null)
		{
			z0ZzZzplh2.z0uek(p0: true);
			z0ZzZzplh2.z0nek();
		}
	}

	public virtual bool z0vj()
	{
		return false;
	}

	public XTextElementList z0rpk()
	{
		return z0eek(typeof(XTextRadioBoxElement));
	}

	public virtual void z0xj(XTextObjectElement p0, DocumentEventArgs p1)
	{
	}

	public void z0eek(z0ZzZzimk p0, Color p1, bool p2)
	{
		if (z0ypk() != null)
		{
			z0ypk().z0tek(p0, p1, p2);
		}
	}

	public bool z0eek(DCSignInputInfo p0)
	{
		return z0ZzZzdfh.z0rek().z0ud(this, p0);
	}

	public string z0tpk()
	{
		return z0ypk().z0jtk();
	}

	private void z0rek(PageViewMode p0)
	{
	}

	public z0ZzZzqbj z0ypk()
	{
		return z0imk;
	}

	public bool z0eek(z0ZzZzcah p0, string p1)
	{
		return z0ypk().z0tek(p0, p1);
	}

	public bool z0upk()
	{
		return z0ypk().z0kik;
	}

	public XTextElement z0ipk()
	{
		return z0ruk()?.z0itk();
	}

	public void z0eek(XTextSubDocumentElement p0)
	{
		z0ruk().z0bek(p0);
	}

	public string z0opk()
	{
		return z0ruk()?.z0vuk();
	}

	public bool z0ppk()
	{
		return z0qbk;
	}

	internal virtual void z0uek(ElementMouseEventArgs p0)
	{
		z0bj("EventElementMouseClick", p0);
	}

	public z0ZzZzodh z0mpk()
	{
		if (z0imk == null)
		{
			return z0ZzZzodh.z0yek;
		}
		return z0imk.z0dyk();
	}

	public void z0eek(XTextDocument p0)
	{
		if (z0imk != null)
		{
			z0imk.z0yek(p0);
		}
	}
}
