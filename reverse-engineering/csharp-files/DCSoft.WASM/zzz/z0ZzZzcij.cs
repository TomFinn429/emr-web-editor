using System.Runtime.CompilerServices;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZzcij
{
	public class z0npk
	{
		public Color z0eek = Color.Blue;

		public int z0rek;

		public Color z0tek = Color.White;

		public Color z0yek = Color.Blue;

		public string z0uek = z0ZzZzimk.DefaultFontName;

		public float z0iek = 12f;

		public Color z0oek = Color.Black;

		public Color z0pek = Color.DarkBlue;

		public Color z0mek = Color.White;

		public Color z0nek = Color.Black;

		public Color z0bek = Color.Black;

		public Color z0vek = Color.White;
	}

	[CompilerGenerated]
	private static class z0cik
	{
		public static XTextButtonElement.z0smk z0eek;
	}

	public static z0npk z0rek;

	public static void z0eek(string p0)
	{
		string[] array = z0ZzZzvij.z0eek(p0);
		if (array != null && array.Length != 0)
		{
			z0npk z0npk = (z0rek = new z0npk());
			for (int i = 0; i < array.Length; i += 2)
			{
				string text = array[i].ToLower();
				string text2 = array[i + 1];
				switch (text)
				{
				case "fontname":
					z0npk.z0uek = text2;
					break;
				case "fontsize":
					z0npk.z0iek = z0ZzZzzij.z0eek(text2, 12f);
					break;
				case "radius":
					z0npk.z0rek = z0ZzZzzij.z0eek(text2, 0);
					break;
				case "textcolor":
					z0npk.z0yek = z0ZzZzzij.z0eek(text2, z0npk.z0yek);
					break;
				case "backcolor":
					z0npk.z0mek = z0ZzZzzij.z0eek(text2, z0npk.z0mek);
					break;
				case "bordercolor":
					z0npk.z0oek = z0ZzZzzij.z0eek(text2, z0npk.z0oek);
					break;
				case "hovertextcolor":
					z0npk.z0tek = z0ZzZzzij.z0eek(text2, z0npk.z0tek);
					break;
				case "hoverbackcolor":
					z0npk.z0eek = z0ZzZzzij.z0eek(text2, z0npk.z0eek);
					break;
				case "hoverbordercolor":
					z0npk.z0bek = z0ZzZzzij.z0eek(text2, z0npk.z0bek);
					break;
				case "mousedowntextcolor":
					z0npk.z0vek = z0ZzZzzij.z0eek(text2, z0npk.z0vek);
					break;
				case "mousedownbackcolor":
					z0npk.z0pek = z0ZzZzzij.z0eek(text2, z0npk.z0pek);
					break;
				case "mousedownbordercolor":
					z0npk.z0nek = z0ZzZzzij.z0eek(text2, z0npk.z0nek);
					break;
				}
			}
		}
		else
		{
			z0rek = null;
		}
	}

	private static bool z0eek(XTextButtonElement p0, z0ZzZzvxj p1)
	{
		if (z0rek == null)
		{
			return false;
		}
		XTextButtonElement.z0mpk z0mpk = p0.z0uek;
		if (p1.z0byk == (z0ZzZzcxj)3 || p1.z0byk == (z0ZzZzcxj)2 || p1.z0byk == (z0ZzZzcxj)5)
		{
			if (p0.PrintAsText)
			{
				return false;
			}
			z0mpk = XTextButtonElement.z0mpk.z0eek;
		}
		z0ZzZzzdh z0ZzZzzdh2 = null;
		z0ZzZzzdh z0ZzZzzdh3 = null;
		z0ZzZzudh z0ZzZzudh2 = null;
		switch (z0mpk)
		{
		case XTextButtonElement.z0mpk.z0rek:
			z0ZzZzzdh2 = new z0ZzZzzdh(z0rek.z0tek);
			z0ZzZzzdh3 = new z0ZzZzzdh(z0rek.z0eek);
			z0ZzZzudh2 = new z0ZzZzudh(z0rek.z0bek);
			break;
		case XTextButtonElement.z0mpk.z0tek:
			z0ZzZzzdh2 = new z0ZzZzzdh(z0rek.z0vek);
			z0ZzZzzdh3 = new z0ZzZzzdh(z0rek.z0pek);
			z0ZzZzudh2 = new z0ZzZzudh(z0rek.z0nek);
			break;
		default:
			z0ZzZzzdh2 = new z0ZzZzzdh(z0rek.z0yek);
			z0ZzZzzdh3 = new z0ZzZzzdh(z0rek.z0mek);
			z0ZzZzudh2 = new z0ZzZzudh(z0rek.z0oek);
			break;
		}
		z0ZzZzbdh z0gtk = p1.z0gtk;
		z0ZzZzsdh font = new z0ZzZzsdh(z0rek.z0uek, z0rek.z0iek);
		p1.z0gyk.z0eek(z0ZzZzzdh3.z0eek, z0gtk, z0rek.z0rek);
		z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		z0ZzZzlsh2.z0rek(StringAlignment.Center);
		p1.z0gyk.DrawString(p0.Text, font, z0ZzZzzdh2, z0gtk, z0ZzZzlsh2);
		p1.z0gyk.z0eek(z0ZzZzudh2, z0gtk, z0rek.z0rek);
		z0ZzZzlsh2.Dispose();
		z0ZzZzzdh2.Dispose();
		z0ZzZzudh2.Dispose();
		z0ZzZzzdh3.Dispose();
		return true;
	}

	public static void z0eek()
	{
		XTextButtonElement.z0nek = z0eek;
	}
}
