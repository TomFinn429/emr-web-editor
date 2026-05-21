using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzpmk : ICloneable, IDisposable
{
	public class z0ngj
	{
		public void z0eek()
		{
		}
	}

	private class z0wnk
	{
		private class z0qnk
		{
			public bool z0eek = true;

			public byte[] z0rek;

			public z0ZzZzedh z0tek;
		}

		private readonly List<z0qnk> z0yek = new List<z0qnk>();

		private int z0uek;

		private int z0iek = 20971520;

		private int z0oek;

		public bool z0eek(z0ZzZzedh p0)
		{
			if (p0 == null)
			{
				return false;
			}
			for (int num = z0yek.Count - 1; num >= 0; num--)
			{
				z0qnk z0qnk = z0yek[num];
				if (z0qnk.z0tek == p0)
				{
					z0yek.RemoveAt(num);
					z0qnk.z0rek = null;
					z0qnk.z0tek = null;
					return true;
				}
			}
			return false;
		}

		public bool z0rek(z0ZzZzedh p0)
		{
			foreach (z0qnk item in z0yek)
			{
				if (item.z0tek != null && item.z0tek == p0)
				{
					return true;
				}
			}
			return false;
		}

		public void z0eek()
		{
			z0oek++;
			foreach (z0qnk item in z0yek)
			{
				item.z0rek = null;
				item.z0tek = null;
			}
			z0yek.Clear();
			z0uek = 0;
		}

		public byte[] z0eek(byte[] p0)
		{
			int num = z0rek(p0);
			if (num >= 0)
			{
				return z0yek[num].z0rek;
			}
			return null;
		}

		private int z0rek(byte[] p0)
		{
			if (p0 == null || p0.Length == 0)
			{
				return -1;
			}
			for (int i = 0; i < z0yek.Count; i++)
			{
				if (z0ZzZzeyk.z0rek(z0yek[i].z0rek, p0))
				{
					return i;
				}
			}
			z0uek += p0.Length;
			if (z0uek >= z0iek)
			{
				z0eek();
			}
			z0qnk z0qnk = new z0qnk();
			z0qnk.z0rek = p0;
			z0yek.Insert(0, z0qnk);
			z0oek++;
			return 0;
		}

		public bool z0tek(byte[] p0)
		{
			if (p0 == null)
			{
				return false;
			}
			for (int num = z0yek.Count - 1; num >= 0; num--)
			{
				z0qnk z0qnk = z0yek[num];
				if (z0qnk.z0rek == p0)
				{
					z0yek.RemoveAt(num);
					z0qnk.z0rek = null;
					z0qnk.z0tek = null;
					return true;
				}
			}
			return false;
		}
	}

	public delegate string z0dnk(byte[] bs);

	private z0ZzZzcdh z0bek = z0ZzZzcdh.z0yek_jiejie20260327142557;

	[NonSerialized]
	private int z0vek = -2147483648;

	public static string z0cek = "Image";

	public static bool z0xek = true;

	public static Func<byte[], z0ZzZzcdh> z0zek = null;

	private bool z0lrk = true;

	private bool z0krk;

	private static readonly string z0jrk = "data:image/bmp;base64,";

	[NonSerialized]
	private int z0hrk;

	private static readonly string z0grk = "data:image/png;base64,";

	private static z0wnk z0frk = new z0wnk();

	private static readonly string z0drk = "data:image/gif;base64,";

	[NonSerialized]
	private bool z0srk;

	public static z0dnk z0ark = null;

	[NonSerialized]
	private int z0qrk;

	private static readonly string z0wrk = "data:image/jpeg;base64,";

	private static object z0erk = null;

	private byte[] z0rrk;

	[NonSerialized]
	private z0ZzZzedh z0trk;

	public bool HasContent
	{
		get
		{
			if (z0trk != null)
			{
				return true;
			}
			if (z0rrk != null && z0rrk.Length != 0)
			{
				return true;
			}
			return false;
		}
	}

	public z0ZzZzcdh Size
	{
		get
		{
			if (z0trk != null)
			{
				return z0trk.z0oek();
			}
			if (z0bek.z0rek() > 0)
			{
				return z0bek;
			}
			if (Value == null)
			{
				return z0ZzZzcdh.z0yek_jiejie20260327142557;
			}
			return Value.z0oek();
		}
	}

	[z0ZzZzuqh]
	public byte[] ImageData
	{
		get
		{
			if (z0rrk == null && z0trk is z0ZzZzrfh)
			{
				z0rrk = ((z0ZzZzrfh)z0trk).z0eek();
			}
			return z0rrk;
		}
		set
		{
			z0hrk = 0;
			z0vek = -2147483648;
			if (z0trk != null && !z0frk.z0rek(z0trk))
			{
				z0trk.Dispose();
			}
			z0rrk = z0tek(value);
			z0trk = null;
			z0bek = z0uek(z0rrk);
			z0srk = true;
			z0qrk++;
		}
	}

	public int ByteSize
	{
		get
		{
			if (z0hrk == 0 && z0rrk != null && z0rrk.Length != 0)
			{
				return z0rrk.Length;
			}
			if (z0trk != null && !z0rek(z0trk))
			{
				return z0trk.z0iek() * z0trk.z0yek() / 2;
			}
			return z0hrk;
		}
	}

	[z0ZzZzuqh]
	public virtual z0ZzZzedh Value
	{
		get
		{
			if (z0trk == null)
			{
				z0tek();
			}
			return z0trk;
		}
		set
		{
			z0hrk = 0;
			z0vek = -2147483648;
			z0trk = value;
			z0rrk = null;
			z0qrk++;
			z0srk = false;
		}
	}

	public int ContentVersion => z0qrk;

	public int Height => Size.z0tek();

	public int Width => Size.z0rek();

	public z0ZzZzrdh RawFormat
	{
		get
		{
			if (Value != null)
			{
				return Value.z0pek();
			}
			return null;
		}
	}

	[z0ZzZzuqh]
	public bool FormatBase64String
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh]
	public string ImageDataBase64String
	{
		get
		{
			byte[] imageData = ImageData;
			if (imageData != null && imageData.Length != 0)
			{
				string text = Convert.ToBase64String(imageData);
				if (FormatBase64String)
				{
					text = z0ZzZzeik.z0eek(text, 8, 16);
				}
				return text;
			}
			return null;
		}
		set
		{
			z0hrk = 0;
			if (value != null && value.Length > 0)
			{
				try
				{
					ImageData = Convert.FromBase64String(value);
				}
				catch (FormatException)
				{
					byte[] imageData = z0ZzZzqik.z0uek(value);
					ImageData = imageData;
				}
				catch (Exception ex2)
				{
					z0ZzZzqok.z0rek.z0sh(ex2.ToString());
					ImageData = null;
				}
				z0srk = true;
				z0qrk++;
			}
		}
	}

	public z0ZzZzpmk(byte[] p0)
	{
		ImageData = p0;
		z0qrk = GetHashCode();
	}

	public void ChangeImageFormat(z0ZzZzrdh format)
	{
		if (format == null)
		{
			throw new ArgumentNullException("format");
		}
		z0ZzZzedh value = Value;
		if (value != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			value.z0hd(memoryStream, format);
			z0trk.Dispose();
			memoryStream.Close();
			z0trk = null;
			z0rrk = memoryStream.ToArray();
		}
	}

	public z0ZzZzpmk(z0ZzZzedh p0)
	{
		Value = p0;
		z0qrk = GetHashCode();
		z0srk = false;
	}

	public bool z0eek()
	{
		return z0srk;
	}

	public byte[] z0rek()
	{
		if (z0rrk != null && z0rrk.Length != 0 && z0ZzZzpuk.z0uek(z0rrk))
		{
			return z0rrk;
		}
		z0ZzZzedh value = Value;
		if (value != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			value.z0hd(memoryStream, z0ZzZzrdh.z0bek);
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			return result;
		}
		return null;
	}

	public static z0ZzZzomk z0eek(z0ZzZzedh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("img");
		}
		if (p0.z0pek() == null)
		{
			throw new ArgumentNullException("img.RawFormat");
		}
		int num = p0.z0pek().z0yek;
		if (num == z0ZzZzrdh.z0eek.z0yek)
		{
			return (z0ZzZzomk)2;
		}
		if (num == z0ZzZzrdh.z0bek.z0yek)
		{
			return (z0ZzZzomk)0;
		}
		if (num == z0ZzZzrdh.z0nek.z0yek)
		{
			return (z0ZzZzomk)3;
		}
		if (num == z0ZzZzrdh.z0vek.z0yek)
		{
			return (z0ZzZzomk)1;
		}
		if (num == z0ZzZzrdh.z0pek.z0yek)
		{
			return (z0ZzZzomk)4;
		}
		return (z0ZzZzomk)5;
	}

	public static bool z0rek(z0ZzZzedh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("img");
		}
		if (z0erk == null)
		{
			z0erk = typeof(z0ZzZzedh).GetField("nativeImage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (z0erk == null)
			{
				z0erk = new object();
			}
		}
		if (z0erk is FieldInfo && (nint)((FieldInfo)z0erk).GetValue(p0) == IntPtr.Zero)
		{
			return true;
		}
		return false;
	}

	public bool z0eek(z0ZzZzpmk p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == this)
		{
			return true;
		}
		if (p0.z0trk == z0trk)
		{
			return true;
		}
		if (p0.z0rrk == z0rrk)
		{
			return true;
		}
		if (p0.z0rrk != null && z0rrk != null && p0.z0rrk.Length == z0rrk.Length)
		{
			if (p0.z0yek() != z0yek())
			{
				return false;
			}
			for (int num = z0rrk.Length - 1; num >= 0; num--)
			{
				if (z0rrk[num] != p0.z0rrk[num])
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private void z0tek()
	{
		if (z0rrk != null && z0rrk.Length != 0 && z0trk == null)
		{
			z0yek(z0rrk);
			z0trk = new z0ZzZzrfh(z0rrk);
		}
	}

	private int z0yek()
	{
		if (z0vek == -2147483648)
		{
			if (z0rrk == null || z0rrk.Length == 0)
			{
				if (z0trk == null)
				{
					return 0;
				}
			}
			else
			{
				for (int num = z0rrk.Length - 1; num >= 0; num--)
				{
					z0vek += z0rrk[num];
				}
			}
		}
		return z0vek;
	}

	public bool z0uek()
	{
		return z0lrk;
	}

	public void z0iek()
	{
		if (z0xek)
		{
			if (z0rrk != null)
			{
				z0frk.z0tek(z0rrk);
			}
			if (z0trk != null)
			{
				z0frk.z0eek(z0trk);
			}
		}
	}

	public void z0rek(z0ZzZzpmk p0)
	{
		if (p0 != null && p0 != this)
		{
			p0.z0qrk = z0qrk;
			p0.z0krk = z0krk;
			p0.z0rrk = z0rrk;
			p0.z0trk = z0trk;
		}
	}

	public static string StaticGetEmitImageSource(byte[] bs)
	{
		if (bs != null)
		{
			string text = null;
			text = (z0ZzZzpuk.z0tek(bs) ? z0jrk : (z0ZzZzpuk.z0yek(bs) ? z0grk : (z0ZzZzpuk.z0eek(bs) ? z0drk : ((!z0ZzZzpuk.z0uek(bs)) ? z0wrk : z0wrk))));
			char[] array = new char[text.Length + z0ZzZzmpk.z0eek(bs.Length)];
			text.CopyTo(0, array, 0, text.Length);
			Convert.ToBase64CharArray(bs, 0, bs.Length, array, text.Length);
			return new string(array);
		}
		return null;
	}

	public z0ZzZzpmk(Stream p0)
	{
		byte[] array = new byte[1024];
		MemoryStream memoryStream = new MemoryStream();
		while (true)
		{
			int num = p0.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num);
		}
		ImageData = memoryStream.ToArray();
		z0qrk = GetHashCode();
	}

	public static void z0oek()
	{
		if (z0frk != null)
		{
			z0frk.z0eek();
		}
	}

	public z0ZzZzcdh ConvertSize(GraphicsUnit unit)
	{
		return z0ZzZzrpk.z0eek(Size, GraphicsUnit.Pixel, unit);
	}

	public void Dispose()
	{
		if (z0trk != null)
		{
			if (z0xek)
			{
				if (!z0frk.z0rek(z0trk))
				{
					z0trk.Dispose();
				}
			}
			else
			{
				z0trk.Dispose();
			}
			z0trk = null;
		}
		z0rrk = null;
	}

	public z0ZzZzpmk()
	{
		z0qrk = GetHashCode();
	}

	public static string z0eek(byte[] p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			if (z0ZzZzpuk.z0tek(p0))
			{
				return z0jrk;
			}
			if (z0ZzZzpuk.z0yek(p0))
			{
				return z0grk;
			}
			if (z0ZzZzpuk.z0eek(p0))
			{
				return z0drk;
			}
			z0ZzZzpuk.z0uek(p0);
			return z0wrk;
		}
		return null;
	}

	public int LoadBase64String(string base64)
	{
		z0hrk = 0;
		if (string.IsNullOrEmpty(base64))
		{
			z0rrk = null;
			z0trk = null;
			return 0;
		}
		byte[] array = (ImageData = Convert.FromBase64String(base64));
		return array.Length;
	}

	public z0ZzZzpmk Clone()
	{
		z0ZzZzpmk z0ZzZzpmk2 = (z0ZzZzpmk)MemberwiseClone();
		z0ZzZzpmk2.z0trk = null;
		z0ZzZzpmk2.z0rrk = null;
		if (z0rrk != null)
		{
			z0ZzZzpmk2.z0rrk = new byte[z0rrk.Length];
			Array.Copy(z0rrk, 0, z0ZzZzpmk2.z0rrk, 0, z0rrk.Length);
		}
		else if (z0trk != null)
		{
			z0ZzZzpmk2.z0trk = (z0ZzZzedh)z0trk.z0eek();
		}
		z0ZzZzpmk2.z0qrk = z0qrk;
		return z0ZzZzpmk2;
	}

	public static byte[] ParseEmitImageSource(string dataUrl)
	{
		if (string.IsNullOrEmpty(dataUrl))
		{
			return null;
		}
		string text = null;
		if (dataUrl.StartsWith(z0grk, StringComparison.Ordinal))
		{
			text = dataUrl.Substring(z0grk.Length);
		}
		else if (dataUrl.StartsWith(z0wrk, StringComparison.Ordinal))
		{
			text = dataUrl.Substring(z0wrk.Length);
		}
		else if (dataUrl.StartsWith(z0jrk, StringComparison.Ordinal))
		{
			text = dataUrl.Substring(z0jrk.Length);
		}
		else if (dataUrl.StartsWith(z0drk, StringComparison.Ordinal))
		{
			text = dataUrl.Substring(z0drk.Length);
		}
		else if (dataUrl.Length < 1000)
		{
			for (int num = Math.Min(200, dataUrl.Length) - 1; num >= 0; num--)
			{
				if (!char.IsWhiteSpace(dataUrl[num]) && z0ZzZzqik.z0eek(dataUrl[num]) < 0)
				{
					return null;
				}
			}
			text = dataUrl;
		}
		else
		{
			text = dataUrl;
		}
		if (text != null && text.Length > 0)
		{
			try
			{
				return Convert.FromBase64String(text);
			}
			catch (Exception)
			{
			}
		}
		return null;
	}

	public z0ZzZzpmk(string p0)
	{
		if (Load(p0) <= 0)
		{
			throw new Exception("FailToLoadImage:" + p0);
		}
		z0qrk = GetHashCode();
	}

	public void z0eek(bool p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzpmk(int p0, int p1)
	{
		z0trk = new z0ZzZzrfh(p0, p1);
		z0qrk = GetHashCode();
		z0srk = false;
	}

	private static bool z0rek(byte[] p0)
	{
		if (p0 != null && p0.Length > 102400)
		{
			return true;
		}
		return false;
	}

	private static byte[] z0tek(byte[] p0)
	{
		if (z0xek)
		{
			if (p0 == null || p0.Length == 0)
			{
				return p0;
			}
			if (z0rek(p0))
			{
				return p0;
			}
			return z0frk.z0eek(p0);
		}
		return p0;
	}

	private object z0pek()
	{
		z0ZzZzpmk z0ZzZzpmk2 = new z0ZzZzpmk();
		if (z0trk != null)
		{
			z0ZzZzpmk2.z0trk = (z0ZzZzedh)z0trk.z0eek();
		}
		if (z0rrk != null)
		{
			z0ZzZzpmk2.z0rrk = new byte[z0rrk.Length];
			Array.Copy(z0rrk, 0, z0ZzZzpmk2.z0rrk, 0, z0rrk.Length);
		}
		z0ZzZzpmk2.z0qrk = z0qrk;
		return z0ZzZzpmk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0pek
		return this.z0pek();
	}

	public override string ToString()
	{
		z0ZzZzedh value = Value;
		_ = ImageData;
		if (z0rrk == null || z0trk == null)
		{
			return "None";
		}
		if (z0rrk.Length < 1024)
		{
			return z0rrk.Length + "B " + value.z0iek() + "*" + value.z0yek();
		}
		return Convert.ToInt32(z0rrk.Length / 1024) + "KB " + value.z0iek() + "*" + value.z0yek();
	}

	public byte[] z0mek()
	{
		return z0rrk;
	}

	public static z0ZzZzrfh z0eek(object p0)
	{
		if (p0 is z0ZzZzrfh)
		{
			return (z0ZzZzrfh)p0;
		}
		if (p0 is byte[])
		{
			return new z0ZzZzrfh(new MemoryStream((byte[])p0));
		}
		return null;
	}

	private static int z0eek(byte[] p0, int p1)
	{
		return (((p0[p1] << 8) + p0[p1 + 1] << 8) + p0[p1 + 2] << 8) + p0[p1 + 3];
	}

	public bool z0nek()
	{
		if (z0trk != null)
		{
			return z0trk is z0ZzZzrfh;
		}
		if (z0rrk != null && z0rrk.Length != 0)
		{
			return z0ZzZzpuk.z0tek(z0rrk);
		}
		return Value is z0ZzZzrfh;
	}

	public static bool z0yek(byte[] p0)
	{
		if (p0 == null || p0.Length < 5)
		{
			return false;
		}
		if (!z0ZzZzpuk.z0eek(p0) && !z0ZzZzpuk.z0yek(p0) && !z0ZzZzpuk.z0uek(p0))
		{
			return z0ZzZzpuk.z0tek(p0);
		}
		return true;
	}

	public int Load(string strUrl)
	{
		return 0;
	}

	public z0ZzZzpmk(byte[] p0, bool p1)
	{
		z0eek(p1);
		ImageData = p0;
		z0qrk = GetHashCode();
	}

	public bool MakeTransparent(Color c)
	{
		if (c.A > 0)
		{
			z0ZzZzrfh z0ZzZzrfh2 = (z0ZzZzrfh)Value;
			if (z0ZzZzrfh2 != null)
			{
				z0ZzZzrfh2.z0eek(c);
				return true;
			}
		}
		return false;
	}

	public static z0ZzZzcdh z0uek(byte[] p0)
	{
		if (p0 == null)
		{
			return z0ZzZzcdh.z0yek_jiejie20260327142557;
		}
		if (z0ZzZzpuk.z0tek(p0))
		{
			int p1 = BitConverter.ToInt32(p0, 18);
			int p2 = BitConverter.ToInt32(p0, 22);
			return new z0ZzZzcdh(p1, p2);
		}
		if (z0ZzZzpuk.z0yek(p0))
		{
			int p3 = z0eek(p0, 16);
			int p4 = z0eek(p0, 20);
			return new z0ZzZzcdh(p3, p4);
		}
		if (z0ZzZzpuk.z0uek(p0))
		{
			return z0zek(p0);
		}
		if (z0ZzZzpuk.z0eek(p0))
		{
			byte[] obj = new byte[4]
			{
				p0[6],
				p0[7],
				p0[8],
				p0[9]
			};
			short p5 = BitConverter.ToInt16(obj, 0);
			short p6 = BitConverter.ToInt16(obj, 2);
			return new z0ZzZzcdh(p5, p6);
		}
		if (z0ark != null)
		{
			z0ark(p0);
		}
		return z0ZzZzcdh.z0yek_jiejie20260327142557;
	}

	public static z0ZzZzrdh z0iek(byte[] p0)
	{
		if (p0 == null)
		{
			return z0ZzZzrdh.z0vek;
		}
		if (z0ZzZzpuk.z0tek(p0))
		{
			return z0ZzZzrdh.z0vek;
		}
		if (z0ZzZzpuk.z0yek(p0))
		{
			return z0ZzZzrdh.z0eek;
		}
		if (z0ZzZzpuk.z0uek(p0))
		{
			return z0ZzZzrdh.z0bek;
		}
		if (z0ZzZzpuk.z0eek(p0))
		{
			return z0ZzZzrdh.z0nek;
		}
		return z0ZzZzrdh.z0vek;
	}

	public void z0eek(Stream p0, z0ZzZzrdh p1)
	{
		Value.z0hd(p0, p1);
	}
}
