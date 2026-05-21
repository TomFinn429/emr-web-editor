using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzgej : z0ZzZzrqj
{
	private readonly z0ZzZzoaj z0oek;

	private readonly z0ZzZzcaj z0mek;

	private readonly int z0bek;

	private readonly string z0vek;

	private IDictionary<int, double> z0xek = new Dictionary<int, double>();

	internal void z0eek(IDictionary<int, double> p0)
	{
		z0xek = p0;
	}

	protected internal override string z0cdk()
	{
		return "Type0";
	}

	protected virtual z0ZzZzeaj z0ksk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.z0yek("Type", "Font");
		z0ZzZzeaj2.z0yek("Subtype", z0xdk());
		z0ZzZzeaj2.Add("BaseFont", new z0ZzZzhwj(z0vek));
		z0ZzZzeaj2.z0tek_jiejie20260327142557("FontDescriptor", z0yek());
		z0ZzZzeaj2.z0tek_jiejie20260327142557("CIDSystemInfo", z0oek);
		z0ZzZzeaj2.Add("DW", z0bek);
		if (z0xek != null && z0xek.Count > 0)
		{
			List<object> list = new List<object>();
			int num = -1;
			List<object> list2 = new List<object>();
			KeyValuePair<int, double>[] array = z0ZzZzlxk.z0eek(z0xek);
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<int, double> keyValuePair = array[i];
				if (num < 0)
				{
					num = keyValuePair.Key;
					list.Add(num);
					list2.Add(keyValuePair.Value);
				}
				else if (keyValuePair.Key == ++num)
				{
					list2.Add(keyValuePair.Value);
				}
				else
				{
					list.Add(list2);
					num = keyValuePair.Key;
					list.Add(num);
					list2 = new List<object>();
					list2.Add(keyValuePair.Value);
				}
			}
			list.Add(list2);
			z0ZzZzeaj2.Add("W", list);
		}
		return z0ZzZzeaj2;
	}

	protected internal override z0ZzZzfqj z0zdk_jiejie20260327142557()
	{
		return z0mek;
	}

	protected abstract string z0xdk();

	protected internal override IEnumerable<double> z0vdk()
	{
		return z0tek().Values;
	}

	internal new short[] z0rek()
	{
		return null;
	}

	protected override z0ZzZzeaj z0lsk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0lsk(p0);
		z0ZzZzeaj2.Add("DescendantFonts", new object[1] { p0.z0uek(z0ksk(p0)) });
		return z0ZzZzeaj2;
	}

	internal new IDictionary<int, double> z0tek()
	{
		return z0xek;
	}

	protected z0ZzZzgej(string p0, z0ZzZzvaj p1)
		: base(p0, p1)
	{
		z0mek = z0ZzZzvqj.z0rek();
		z0vek = p0;
		z0oek = new z0ZzZzoaj("Adobe", "Identity", 0);
		z0bek = 1000;
	}
}
