using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCSystem_Drawing;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.WASM;

public class TTFontFileHelper
{
	public class z0mck
	{
		public readonly bool z0eek;

		public readonly string z0rek;

		public readonly bool z0tek;

		public readonly string z0yek;

		public readonly bool z0uek;

		public readonly string z0iek;

		internal z0mck(string p0, string p1, bool p2, bool p3, string p4)
		{
			if (p0 == null || p0.Length == 0)
			{
				throw new ArgumentNullException("strKey");
			}
			z0iek = p0;
			z0rek = p1;
			z0tek = p2;
			z0eek = p3;
			z0yek = p4;
			if (z0yek == null)
			{
				z0yek = string.Empty;
			}
			z0uek = TTFontFileHelper.z0rek.ContainsKey(z0iek);
		}
	}

	[CompilerGenerated]
	private sealed class z0yyk
	{
		public static readonly z0yyk z0rek = new z0yyk();

		public static z0ZzZztlj.z0upk z0tek;

		public static z0ZzZzpij.z0snk z0yek;

		internal z0ZzZzzfj z0eek(string p0, FontStyle p1, bool p2)
		{
			bool p3 = (p1 & FontStyle.Bold) == FontStyle.Bold;
			bool p4 = (p1 & FontStyle.Italic) == FontStyle.Italic;
			z0mck z0mck = TTFontFileHelper.z0eek(p0, p3, p4);
			if (z0mck != null && TTFontFileHelper.z0rek.ContainsKey(z0mck.z0iek))
			{
				return TTFontFileHelper.z0rek[z0mck.z0iek];
			}
			return null;
		}

		internal z0ZzZzpij z0eek(string p0, FontStyle p1)
		{
			if (p0 == null || p0.Length == 0)
			{
				p0 = z0ZzZzimk.DefaultFontName;
			}
			bool p2 = (p1 & FontStyle.Bold) == FontStyle.Bold;
			bool p3 = (p1 & FontStyle.Italic) == FontStyle.Italic;
			if (TTFontFileHelper.z0yek != null && TTFontFileHelper.z0yek.Contains(p0))
			{
				return null;
			}
			string text = z0ZzZzroj.z0eek(p0, p2, p3);
			z0ZzZzpij z0ZzZzpij = null;
			if (TTFontFileHelper.z0tek.TryGetValue(text, out z0ZzZzpij))
			{
				return z0ZzZzpij;
			}
			byte[] array = null;
			string text2 = z0ZzZzroj.z0bek(text);
			if (text2 != null && text2.Length > 0)
			{
				float z0trk = 1f;
				int num = text2.LastIndexOf(',');
				if (num > 0)
				{
					z0trk = float.Parse(text2.Substring(num + 1));
					text2 = text2.Substring(0, num);
				}
				array = Convert.FromBase64String(text2);
				z0ZzZzpij = z0ZzZzpij.z0eek(p0, array);
				z0ZzZzpij.z0trk = z0trk;
			}
			else
			{
				if (TTFontFileHelper.z0yek == null)
				{
					TTFontFileHelper.z0yek = new List<string>();
				}
				TTFontFileHelper.z0yek.Add(p0);
			}
			TTFontFileHelper.z0tek[text] = z0ZzZzpij;
			if (z0ZzZzpij != null && z0ZzZzpij.z0wrk == "华文宋体")
			{
				z0ZzZzpij.z0bek = 1.140625f;
			}
			return z0ZzZzpij;
		}
	}

	private static Dictionary<string, z0ZzZzzfj> z0rek = new Dictionary<string, z0ZzZzzfj>();

	private static readonly Dictionary<string, z0ZzZzpij> z0tek = new Dictionary<string, z0ZzZzpij>();

	private static List<string> z0yek = null;

	public static z0mck z0eek(string p0, bool p1, bool p2)
	{
		if (p0 == null || p0.Length == 0)
		{
			p0 = z0ZzZzimk.DefaultFontName;
		}
		string p3 = z0ZzZzroj.z0eek(p0, p1, p2);
		string p4 = z0ZzZzroj.z0yek(p3);
		return new z0mck(p3, p0, p1, p2, p4);
	}

	[JSInvokable]
	public static void SetFontFileContent(string strKey, string strFontName, byte[] bsContent)
	{
		if (bsContent.Length > 100)
		{
			if (bsContent[0] == 0 && bsContent[1] == 1 && bsContent[2] == 0 && bsContent[3] == 0)
			{
				z0ZzZzzfj z0ZzZzzfj = new z0ZzZzzfj(z0ZzZzzfj.z0cek(), bsContent);
				z0rek[strKey] = z0ZzZzzfj;
				z0ZzZzzfj.z0jrk = true;
			}
			else
			{
				z0ZzZzzfj z0ZzZzzfj2 = z0ZzZzhaj.z0eek(bsContent, strFontName);
				z0rek[strKey] = z0ZzZzzfj2;
				z0ZzZzzfj2.z0jrk = true;
			}
		}
	}

	public static void z0eek()
	{
		z0ZzZzpij.z0nek = delegate(string p0, FontStyle p1)
		{
			if (p0 == null || p0.Length == 0)
			{
				p0 = z0ZzZzimk.DefaultFontName;
			}
			bool p2 = (p1 & FontStyle.Bold) == FontStyle.Bold;
			bool p3 = (p1 & FontStyle.Italic) == FontStyle.Italic;
			if (z0yek != null && z0yek.Contains(p0))
			{
				return (z0ZzZzpij)null;
			}
			string text = z0ZzZzroj.z0eek(p0, p2, p3);
			z0ZzZzpij z0ZzZzpij = null;
			if (z0tek.TryGetValue(text, out z0ZzZzpij))
			{
				return z0ZzZzpij;
			}
			byte[] array = null;
			string text2 = z0ZzZzroj.z0bek(text);
			if (text2 != null && text2.Length > 0)
			{
				float z0trk = 1f;
				int num = text2.LastIndexOf(',');
				if (num > 0)
				{
					z0trk = float.Parse(text2.Substring(num + 1));
					text2 = text2.Substring(0, num);
				}
				array = Convert.FromBase64String(text2);
				z0ZzZzpij = z0ZzZzpij.z0eek(p0, array);
				z0ZzZzpij.z0trk = z0trk;
			}
			else
			{
				if (z0yek == null)
				{
					z0yek = new List<string>();
				}
				z0yek.Add(p0);
			}
			z0tek[text] = z0ZzZzpij;
			if (z0ZzZzpij != null && z0ZzZzpij.z0wrk == "华文宋体")
			{
				z0ZzZzpij.z0bek = 1.140625f;
			}
			return z0ZzZzpij;
		};
		z0ZzZztlj.z0yek = delegate(string p0, FontStyle p1, bool p2)
		{
			bool p3 = (p1 & FontStyle.Bold) == FontStyle.Bold;
			bool p4 = (p1 & FontStyle.Italic) == FontStyle.Italic;
			z0mck z0mck = z0eek(p0, p3, p4);
			return (z0mck != null && z0rek.ContainsKey(z0mck.z0iek)) ? z0rek[z0mck.z0iek] : null;
		};
	}
}
