using System.ComponentModel;
using System.Diagnostics;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextRadioBox")]
[DebuggerDisplay("Radio:Name={Name} , Checked={Checked}")]
public sealed class XTextRadioBoxElement : XTextCheckBoxElementBase
{
	[z0ZzZzuqh]
	[DefaultValue(null)]
	public override string GroupName
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	public override string z0pe()
	{
		return "rdo";
	}

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
		return "Radio:" + ID;
	}

	public override CheckBoxControlStyle z0oi()
	{
		return CheckBoxControlStyle.RadioBox;
	}

	public override void z0ii(CheckBoxControlStyle p0)
	{
	}
}
