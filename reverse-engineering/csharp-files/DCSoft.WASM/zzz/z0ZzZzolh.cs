using DCSoft.WinForms;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzolh : XTextElement
{
	private new string z0eek;

	public string Name
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	public void Active()
	{
		z0ZzZzbdh z0ZzZzbdh2 = z0qyk();
		if (z0jr().z0yyk() != null)
		{
			z0jr().z0ryk().z0uek(p0: true);
			z0jr().z0ryk().z0oek(this);
			z0jr().z0yyk().z0ypk().z0gx((int)z0ZzZzbdh2.z0oek(), (int)z0ZzZzbdh2.z0pek(), (int)z0ZzZzbdh2.z0uek(), (int)z0ZzZzbdh2.z0iek(), ScrollToViewStyle.Middle);
		}
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (p0.Style == DocumentEventStyles.MouseMove)
		{
			p0.Cursor = z0ZzZzbwh.z0krk;
			p0.Tooltip = "Bookmark \"" + z0eek + "\"";
		}
		base.z0mu(p0);
	}
}
