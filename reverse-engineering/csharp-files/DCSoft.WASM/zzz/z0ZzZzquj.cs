using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzquj : z0ZzZzhuj
{
	private new z0ZzZzpdh[] z0uek;

	public void z0eek(z0ZzZzpdh[] p0)
	{
		z0uek = p0;
	}

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

	public override z0ZzZzbdh z0vkk()
	{
		return z0ZzZzjmk.z0eek(z0tek());
	}

	public new float z0eek()
	{
		float num = 0f;
		for (int i = 0; i < z0tek().Length; i++)
		{
			num = ((i != 0) ? Math.Min(z0tek()[i].z0rek(), num) : z0tek()[i].z0rek());
		}
		return num;
	}

	public string z0rek()
	{
		if (z0uek == null || z0uek.Length == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < z0tek().Length; i++)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(z0tek()[i].z0rek().ToString());
			stringBuilder.Append(',');
			stringBuilder.Append(z0tek()[i].z0tek().ToString());
		}
		return stringBuilder.ToString();
	}

	public override void z0bkk(z0ZzZzbdh p0)
	{
	}

	public override void z0nkk(z0ZzZztuj p0)
	{
		if (z0tek() == null || z0tek().Length <= 1)
		{
			return;
		}
		z0ZzZzpdh z0ZzZzpdh2 = z0nek();
		float num = z0ZzZzpdh2.z0rek() - z0eek();
		float num2 = z0ZzZzpdh2.z0tek() - z0yek();
		z0ZzZzpdh[] array = new z0ZzZzpdh[z0tek().Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i].z0eek(z0tek()[i].z0rek() + num);
			array[i].z0rek(z0tek()[i].z0tek() + num2);
		}
		using z0ZzZzudh p1 = z0ZzZzdpk.z0eek(z0oek().BorderColor, z0oek().BorderWidth, z0oek().BorderStyle);
		p0.z0iek().z0eek(p1, array);
	}

	public override void z0mkk(float p0, float p1)
	{
		for (int i = 0; i < z0tek().Length; i++)
		{
			ref z0ZzZzpdh reference = ref z0tek()[i];
			reference.z0eek(reference.z0rek() * p0);
			ref z0ZzZzpdh reference2 = ref z0tek()[i];
			reference2.z0rek(reference2.z0tek() * p1);
		}
	}

	public z0ZzZzpdh[] z0tek()
	{
		return z0uek;
	}

	public new float z0yek()
	{
		float num = 0f;
		for (int i = 0; i < z0tek().Length; i++)
		{
			num = ((i != 0) ? Math.Min(z0tek()[i].z0tek(), num) : z0tek()[i].z0tek());
		}
		return num;
	}
}
