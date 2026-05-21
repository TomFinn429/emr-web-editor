using System;
using System.Text;

namespace zzz;

internal class z0ZzZzdvk : z0ZzZzznk
{
	internal override bool z0fqk(z0ZzZznvk p0, string p1)
	{
		if (base.z0fqk(p0, p1))
		{
			return true;
		}
		if (z0vek != null && p1 == z0vek.z0vak())
		{
			return true;
		}
		return false;
	}

	public override void z0eqk(StringBuilder p0)
	{
		p0.Append(Environment.NewLine);
		base.z0eqk(p0);
	}

	protected override bool z0wqk()
	{
		return false;
	}

	protected override bool z0tqk(string p0)
	{
		return p0 != "p";
	}

	public override string z0vak()
	{
		return "p";
	}

	public override string z0cak()
	{
		return "p";
	}
}
