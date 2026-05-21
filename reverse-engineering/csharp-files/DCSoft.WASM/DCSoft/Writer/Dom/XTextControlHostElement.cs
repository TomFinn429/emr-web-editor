using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using DCSoft.Drawing;
using DCSoft.WASM;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Host:{TypeFullName}")]
[z0ZzZziqh("XTextControlHost")]
public class XTextControlHostElement : XTextObjectElement
{
	private new bool z0oek;

	private new string z0pek;

	private new ResizeableType z0mek = ResizeableType.WidthAndHeight;

	internal bool z0nek_jiejie20260327142557;

	private new string z0bek;

	private new VerticalAlignStyle z0vek;

	private new byte[] z0cek;

	private new z0ZzZzrxj z0xek;

	private new z0ZzZzgzj z0zek = (z0ZzZzgzj)2;

	private string z0lrk_jiejie20260327142557;

	[NonSerialized]
	private new int z0krk = z0grk++;

	private new ObjectParameterList z0jrk;

	private new bool z0hrk;

	private new static int z0grk;

	private new string z0frk;

	private new static bool z0drk;

	[DefaultValue(ResizeableType.WidthAndHeight)]
	public virtual ResizeableType AllowUserResize
	{
		get
		{
			return base.z0wt();
		}
		set
		{
			base.z0et(value);
		}
	}

	[DefaultValue(VerticalAlignStyle.Top)]
	public virtual VerticalAlignStyle VAlign
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.ContentElementLayout)]
	public virtual string TypeFullName
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

	[z0ZzZzrqh("Parameter", typeof(ObjectParameter))]
	[DefaultValue(null)]
	public virtual ObjectParameterList Parameters
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

	[z0ZzZzyqh]
	[DefaultValue(false)]
	public virtual bool DelayLoadControl
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public override string Text
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(null)]
	public string ValuePropertyName
	{
		get
		{
			return z0lrk_jiejie20260327142557;
		}
		set
		{
			z0lrk_jiejie20260327142557 = value;
		}
	}

	public new void z0eek(int p0)
	{
		z0krk = p0;
	}

	public override void z0et(ResizeableType p0)
	{
		z0mek = p0;
	}

	public override VerticalAlignStyle z0ay()
	{
		return VAlign;
	}

	public virtual void z0ey(z0ZzZzrxj p0)
	{
		z0xek = p0;
	}

	public new static bool z0eek()
	{
		return z0drk;
	}

	public new int z0rek()
	{
		return z0krk;
	}

	public void z0eek(byte[] p0)
	{
		z0cek = p0;
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (p0.Style == DocumentEventStyles.MouseClick)
		{
			WriterControlForWASM writerControlForWASM = (WriterControlForWASM)z0cu().z0lh();
			if (p0.Button == (z0ZzZzqeh)1 && writerControlForWASM != null && !z0bu().DesignMode && !z0nek_jiejie20260327142557)
			{
				z0nek_jiejie20260327142557 = true;
				writerControlForWASM.z0jlk();
				return;
			}
		}
		base.z0mu(p0);
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		using z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
		z0ZzZzlsh.z0rek(StringAlignment.Near);
		z0ZzZzlsh.z0eek(StringAlignment.Center);
		p0.z0gyk.DrawString("承载控件[" + z0ry().ToString() + ":" + TypeFullName + "]", z0ZzZzimk.z0oek, z0ZzZzyfh.z0uek, p0.z0gtk, z0ZzZzlsh);
	}

	public override string z0ge()
	{
		if (string.IsNullOrEmpty(TypeFullName))
		{
			return "Host:" + ID + " " + TypeFullName;
		}
		return "Host:" + ID;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)base.z0lr(p0);
		if (z0jrk != null)
		{
			xTextControlHostElement.z0jrk = z0jrk.Clone();
		}
		xTextControlHostElement.z0cek = null;
		return xTextControlHostElement;
	}

	public virtual string z0ty()
	{
		return TypeFullName;
	}

	public new virtual void z0eek(bool p0)
	{
		z0hrk = p0;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		p0.z0eek(z0bek);
	}

	public new byte[] z0tek()
	{
		if (z0yek())
		{
			if (z0cek == null && z0by() != null)
			{
				MemoryStream memoryStream = new MemoryStream();
				z0by().z0eek(memoryStream, z0ZzZzrdh.z0eek);
				z0cek = memoryStream.ToArray();
				memoryStream.Close();
			}
			return z0cek;
		}
		return null;
	}

	public virtual void z0eek(z0ZzZzgzj p0)
	{
		z0zek = p0;
	}

	public XTextControlHostElement()
	{
		z0drk = true;
		PrintVisibility = ElementVisibility.None;
	}

	public override ResizeableType z0wt()
	{
		if (((XTextObjectElement)this).z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0mek;
	}

	public void z0eek(string p0)
	{
		z0frk = p0;
	}

	public new virtual bool z0yek()
	{
		return z0hrk;
	}

	public new virtual z0ZzZzgzj z0uek()
	{
		return z0zek;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0cek = null;
	}

	public new string z0iek()
	{
		return z0frk;
	}

	public virtual z0ZzZzrxj z0ry()
	{
		return z0xek;
	}
}
