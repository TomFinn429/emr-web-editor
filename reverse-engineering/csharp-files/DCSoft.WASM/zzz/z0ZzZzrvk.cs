using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzrvk : z0ZzZzhbk
{
	private new List<z0ZzZzlvk> z0rek = new List<z0ZzZzlvk>();

	private new string z0tek;

	public override string z0cak()
	{
		return "style";
	}

	public override void z0kqk(string p0)
	{
		z0tek = p0;
	}

	public override void z0sqk(string p0)
	{
		z0kqk(p0);
	}

	internal override bool z0dqk(z0ZzZznvk p0)
	{
		z0rek.Clear();
		z0tek = p0.z0yek(z0vak());
		if (z0tek != null)
		{
			z0tek = z0tek.Replace("<!--", string.Empty);
			z0tek = z0tek.Replace("-->", string.Empty);
			int num = 0;
			for (int num2 = z0tek.IndexOf('{'); num2 >= 0; num2 = z0tek.IndexOf("{", num))
			{
				int num3 = z0tek.IndexOf('}', num2);
				if (num3 > num2)
				{
					string text = z0tek.Substring(num, num2 - num);
					string p1 = z0tek.Substring(num2 + 1, num3 - num2 - 1);
					z0ZzZzlvk z0ZzZzlvk2 = new z0ZzZzlvk();
					z0ZzZzlvk2.z0eek(text.Trim());
					z0ZzZzlvk2.z0eek(p1, p0);
					z0rek.Add(z0ZzZzlvk2);
				}
				num = num3 + 1;
			}
		}
		return true;
	}

	public override string z0zak()
	{
		return z0tek;
	}

	public new List<z0ZzZzlvk> z0eek()
	{
		return z0rek;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0tek = null;
		if (z0rek == null)
		{
			return;
		}
		foreach (z0ZzZzlvk item in z0rek)
		{
			item.Dispose();
		}
		z0rek.Clear();
		z0rek = null;
	}

	protected override bool z0gqk()
	{
		return true;
	}

	public override string z0vak()
	{
		return "style";
	}

	public override string z0jqk()
	{
		return z0zak();
	}
}
