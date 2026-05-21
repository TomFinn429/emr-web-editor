using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextCheckBox")]
[DebuggerDisplay("CheckBox:Group={GroupName} , Checked={Checked}")]
public sealed class XTextCheckBoxElement : XTextCheckBoxElementBase
{
	public override void z0pi(object p0, ContentChangedEventArgs p1)
	{
		base.z0pi(p0, p1);
		if (z0jr().z0rik() != null && z0ZzZzxcj.z0eek(189))
		{
			z0jr().z0rik().z0sw(this, z0uek(), "ContentChanged", p1.LoadingDocument);
		}
	}

	public override string z0ge()
	{
		return "CheckBox:" + ID;
	}

	public override CheckBoxControlStyle z0oi()
	{
		return base.z0oi();
	}

	public override void z0ii(CheckBoxControlStyle p0)
	{
		base.z0ii(p0);
	}

	public override string z0pe()
	{
		return "chk";
	}
}
