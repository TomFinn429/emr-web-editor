using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzwuj : z0ZzZzeuj
{
	private new z0ZzZzpdh[] z0tek;

	public new void z0eek(string p0)
	{
		z0eek((z0ZzZzpdh[])null);
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		string[] array = p0.Split(',');
		List<z0ZzZzpdh> list = new List<z0ZzZzpdh>();
		for (int i = 0; i < array.Length; i += 2)
		{
			float p1 = 0f;
			if (!float.TryParse(array[i], out p1))
			{
				p1 = 0f / 0f;
			}
			float p2 = 0f;
			if (!float.TryParse(array[i + 1], out p2))
			{
				p2 = 0f / 0f;
			}
			list.Add(new z0ZzZzpdh(p1, p2));
		}
		z0eek(list.ToArray());
	}

	public override z0ZzZznfh z0ckk()
	{
		if (z0rek() == null || z0rek().Length == 0)
		{
			return base.z0ckk();
		}
		z0ZzZzpdh z0ZzZzpdh2 = z0nek();
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzjmk.z0eek(z0rek());
		List<z0ZzZzpdh> list = new List<z0ZzZzpdh>();
		for (int i = 0; i < z0rek().Length; i++)
		{
			float num = z0rek()[i].z0rek();
			float num2 = z0rek()[i].z0tek();
			num = z0mek() * (num - z0ZzZzbdh2.z0tek()) / z0ZzZzbdh2.z0uek();
			num2 = base.z0eek() * (num2 - z0ZzZzbdh2.z0yek()) / z0ZzZzbdh2.z0iek();
			list.Add(new z0ZzZzpdh(num + z0ZzZzpdh2.z0rek(), num2 + z0ZzZzpdh2.z0tek()));
		}
		z0ZzZznfh obj = new z0ZzZznfh();
		obj.z0eek(list.ToArray());
		obj.z0rek();
		return obj;
	}

	public new string z0eek()
	{
		if (z0tek == null || z0tek.Length == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < z0tek.Length; i++)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(z0tek[i].z0rek().ToString());
			stringBuilder.Append(',');
			stringBuilder.Append(z0tek[i].z0tek().ToString());
		}
		return stringBuilder.ToString();
	}

	public new z0ZzZzpdh[] z0rek()
	{
		return z0tek;
	}

	public void z0eek(z0ZzZzpdh[] p0)
	{
		z0tek = p0;
	}
}
