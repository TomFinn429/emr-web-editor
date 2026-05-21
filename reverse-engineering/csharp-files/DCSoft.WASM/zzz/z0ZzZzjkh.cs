using System.Diagnostics;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Remark:{ID}")]
[z0ZzZziqh("Remark")]
public class z0ZzZzjkh : XTextObjectElement
{
	private string z0eek_jiejie20260327142557;

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[z0ZzZzyqh]
	public override string Text
	{
		get
		{
			return z0eek_jiejie20260327142557;
		}
		set
		{
			z0eek_jiejie20260327142557 = value;
		}
	}

	public override z0ZzZzonj z0qt()
	{
		z0ZzZzonj obj = new z0ZzZzonj();
		obj.z0rek(Text);
		obj.z0eek((z0ZzZzjbj)0);
		obj.z0eek((z0ZzZzkbj)0);
		return obj;
	}

	public override void z0et(ResizeableType p0)
	{
	}

	public override ResizeableType z0wt()
	{
		return ResizeableType.FixSize;
	}
}
