using System;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzdjh
{
	public bool z0rek;

	public Color z0tek = Color.Black;

	public bool z0yek;

	public Color z0uek_jiejie20260327142557 = Color.Black;

	public Color z0iek = Color.Black;

	public DashStyle z0oek;

	public float z0pek;

	public bool z0mek;

	public bool z0nek;

	public Color z0bek = Color.Black;

	public void z0eek(DocumentContentStyle p0)
	{
		p0?.z0eek(z0yek, z0nek, z0mek, z0rek, z0tek, z0iek, z0bek, z0uek_jiejie20260327142557, z0pek, z0oek);
	}

	public static z0ZzZzdjh z0eek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		z0ZzZzdjh z0ZzZzdjh2 = null;
		p0 = z0ZzZzrjh.z0tek(p0);
		string[] array = p0.Split('|');
		if (array.Length >= 3)
		{
			z0ZzZzdjh2 = new z0ZzZzdjh();
			string[] array2 = array[0].Split(',');
			if (array2.Length == 1)
			{
				z0ZzZzdjh2.z0tek = z0ZzZzlok.z0eek(array2[0], Color.Black);
				z0ZzZzdjh2.z0iek = z0ZzZzdjh2.z0tek;
				z0ZzZzdjh2.z0bek = z0ZzZzdjh2.z0tek;
				z0ZzZzdjh2.z0uek_jiejie20260327142557 = z0ZzZzdjh2.z0tek;
			}
			else
			{
				z0ZzZzdjh2.z0tek = z0ZzZzlok.z0eek(array2[0], Color.Black);
				z0ZzZzdjh2.z0iek = z0ZzZzlok.z0eek(array2[1], Color.Black);
				z0ZzZzdjh2.z0bek = z0ZzZzlok.z0eek(array2[2], Color.Black);
				z0ZzZzdjh2.z0uek_jiejie20260327142557 = z0ZzZzlok.z0eek(array2[3], Color.Black);
			}
			string text = array[1];
			if (text.Length >= 4)
			{
				if (text[0] == '1')
				{
					z0ZzZzdjh2.z0yek = true;
				}
				if (text[1] == '1')
				{
					z0ZzZzdjh2.z0nek = true;
				}
				if (text[2] == '1')
				{
					z0ZzZzdjh2.z0mek = true;
				}
				if (text[3] == '1')
				{
					z0ZzZzdjh2.z0rek = true;
				}
			}
			float num = float.Parse(array[2]);
			float num2 = ((num == 1f) ? 1f : z0ZzZzrpk.z0eek(num, GraphicsUnit.Pixel, GraphicsUnit.Document));
			if (num2 != 0f)
			{
				z0ZzZzdjh2.z0pek = num2;
			}
			if (array.Length == 4 && array[3] != null && array[3].Length > 0)
			{
				DashStyle dashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), array[3]);
				if (dashStyle != DashStyle.Solid)
				{
					z0ZzZzdjh2.z0oek = dashStyle;
				}
			}
		}
		return z0ZzZzdjh2;
	}
}
