using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace zzz;

public class z0ZzZzmmk : ICloneable
{
	private float z0rek;

	private float z0tek;

	private float z0yek;

	private float z0uek;

	[DefaultValue(0f)]
	public float Right
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(0f)]
	public float Top
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	[DefaultValue(0f)]
	public float Bottom
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[DefaultValue(0f)]
	public float Left
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public z0ZzZzmmk(float p0)
	{
		z0uek = p0;
		z0yek = p0;
		z0tek = p0;
		z0rek = p0;
	}

	public static bool z0eek(string p0, z0ZzZzmmk p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return false;
		}
		if (p1 == null)
		{
			return false;
		}
		char c = ',';
		string[] array = p0.Split(new char[1] { c });
		List<float> list = new List<float>();
		for (int i = 0; i < array.Length; i++)
		{
			float num = 0f;
			if (float.TryParse(array[i], out num))
			{
				list.Add(num);
			}
		}
		new z0ZzZzmmk();
		switch (list.Count)
		{
		case 0:
			return false;
		case 1:
			p1.Left = list[0];
			p1.Top = list[0];
			p1.Right = list[0];
			p1.Bottom = list[0];
			break;
		case 2:
			p1.Left = list[0];
			p1.Top = list[1];
			p1.Right = list[0];
			p1.Bottom = list[0];
			break;
		case 3:
			p1.Left = list[0];
			p1.Top = list[1];
			p1.Right = list[2];
			p1.Bottom = list[2];
			break;
		default:
			if (list.Count >= 4)
			{
				p1.Left = list[0];
				p1.Top = list[1];
				p1.Right = list[2];
				p1.Bottom = list[3];
			}
			break;
		}
		return true;
	}

	public z0ZzZzmmk()
	{
	}

	public z0ZzZzmmk(float p0, float p1, float p2, float p3)
	{
		z0uek = p0;
		z0yek = p1;
		z0tek = p2;
		z0rek = p3;
	}

	private object z0eek()
	{
		return MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}
}
