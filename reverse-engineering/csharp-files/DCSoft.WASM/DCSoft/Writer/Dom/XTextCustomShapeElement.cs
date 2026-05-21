using System;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XCustomShape")]
[DebuggerDisplay("CustomShape:{Name}")]
public class XTextCustomShapeElement : XTextObjectElement
{
	[NonSerialized]
	private z0ZzZzjfh z0yek_jiejie20260327142557;

	private new int z0uek;

	private new string z0iek;

	public new int z0eek()
	{
		return z0uek;
	}

	public virtual void z0eek(DocumentPaintEventArgs p0)
	{
	}

	public virtual void z0rek(DocumentPaintEventArgs p0)
	{
	}

	public override string z0ge()
	{
		return "CustomShape:" + ID;
	}

	public override string z0pe()
	{
		return "shape";
	}

	public new z0ZzZzjfh z0rek()
	{
		return z0yek_jiejie20260327142557;
	}

	public void z0eek(string p0)
	{
		z0iek = p0;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0eek(new DocumentPaintEventArgs(p0));
		base.z0mr(p0);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0rek(new DocumentPaintEventArgs(p0));
		WriterDrawShapeContentEventArgs e = new WriterDrawShapeContentEventArgs(z0jr().z0yyk(), z0jr(), this, p0);
		if (z0rek() != null)
		{
			z0rek()(this, e);
			return;
		}
		if (z0jr() != null && !string.IsNullOrEmpty(z0tek()) && z0jr().z0gpk().z0rek(z0tek()) is z0ZzZzjfh z0ZzZzjfh)
		{
			z0ZzZzjfh(this, e);
			return;
		}
		if (z0jr() != null && z0jr().z0yyk() != null)
		{
			z0jr().z0yyk().z0eek(e);
		}
		e.Dispose();
	}

	public new void z0eek(int p0)
	{
		z0uek = p0;
	}

	public new string z0tek()
	{
		return z0iek;
	}

	public void z0eek(z0ZzZzjfh p0)
	{
		z0yek_jiejie20260327142557 = p0;
	}
}
