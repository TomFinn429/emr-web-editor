using System.Collections.Generic;
using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzwpk
{
	private static Dictionary<FormButtonStyle, z0ZzZzrfh> z0rek;

	private static Dictionary<FormButtonStyle, z0ZzZzrfh> z0yek;

	public static z0ZzZzrfh z0eek(FormButtonStyle p0, bool p1)
	{
		if (z0yek == null)
		{
			z0yek = new Dictionary<FormButtonStyle, z0ZzZzrfh>();
			z0ZzZzrfh z0ZzZzrfh2 = z0ZzZzpmk.z0eek((object)z0ZzZzapk.z0eek);
			z0yek[FormButtonStyle.Button] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzpmk.z0eek((object)z0ZzZzapk.z0cek);
			z0yek[FormButtonStyle.FloatButton] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzpmk.z0eek((object)z0ZzZzapk.z0xek);
			z0yek[FormButtonStyle.DateTimePicker] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzpmk.z0eek((object)z0ZzZzapk.z0jrk);
			z0yek[FormButtonStyle.ComboBoxButton] = z0ZzZzrfh2;
			z0rek = new Dictionary<FormButtonStyle, z0ZzZzrfh>();
			z0ZzZzrfh2 = z0ZzZzpmk.z0eek((object)z0ZzZzapk.z0nek);
			z0rek[FormButtonStyle.ComboBoxButton] = z0ZzZzrfh2;
		}
		if (p1 && z0rek.TryGetValue(p0, out var result))
		{
			return result;
		}
		if (z0yek.TryGetValue(p0, out var result2))
		{
			return result2;
		}
		return null;
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, FormButtonStyle p2, bool p3)
	{
		switch (p2)
		{
		case FormButtonStyle.Button:
		{
			z0ZzZzrfh p7 = z0eek(FormButtonStyle.Button, p3);
			z0ZzZzdpk.z0eek(p0, p7, p1);
			break;
		}
		case FormButtonStyle.FloatButton:
		{
			z0ZzZzrfh p8 = z0eek(FormButtonStyle.FloatButton, p3);
			z0ZzZzdpk.z0eek(p0, p8, p1);
			break;
		}
		case FormButtonStyle.ComboBoxButton:
		{
			if (p3)
			{
				using z0ZzZzudh p5 = new z0ZzZzudh(Color.FromArgb(60, 127, 177));
				p0.z0eek(p5, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), 0f);
			}
			z0ZzZzpdh[] array = new z0ZzZzpdh[4]
			{
				new z0ZzZzpdh(p1.z0oek() + p1.z0uek() * 0.1875f, p1.z0pek() + p1.z0iek() * 0.25f),
				new z0ZzZzpdh(p1.z0oek() + p1.z0uek() * 0.75f, p1.z0pek() + p1.z0iek() * 0.25f),
				new z0ZzZzpdh(p1.z0oek() + p1.z0uek() * (15f / 32f), p1.z0pek() + p1.z0iek() * 0.6875f),
				new z0ZzZzpdh(0f, 0f)
			};
			array[3] = array[0];
			SmoothingMode p6 = p0.z0mek();
			p0.z0eek(SmoothingMode.AntiAlias);
			p0.z0eek(z0ZzZzyfh.z0uek, array);
			p0.z0eek(p6);
			break;
		}
		case FormButtonStyle.DateTimePicker:
		{
			z0ZzZzrfh p4 = z0eek(FormButtonStyle.DateTimePicker, p3);
			z0ZzZzdpk.z0eek(p0, p4, p1);
			break;
		}
		}
	}
}
