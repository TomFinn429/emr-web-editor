using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace zzz;

public static class z0ZzZzmuk
{
	public static string z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		if (!z0rek(p0))
		{
			int num = p0.LastIndexOf('/');
			if (num < 0)
			{
				num = p0.LastIndexOf('\\');
			}
			if (num > 0)
			{
				p0 = p0.Substring(num + 1);
			}
		}
		else
		{
			int num2 = p0.LastIndexOf('?');
			if (num2 >= 0)
			{
				p0 = p0.Substring(num2 + 1);
			}
			num2 = p0.LastIndexOf('\\');
			if (num2 >= 0)
			{
				p0 = p0.Substring(num2 + 1);
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		string text = p0;
		foreach (char c in text)
		{
			if ("\\/:*?\"<>|# ".IndexOf(c) < 0)
			{
				stringBuilder.Append(c);
			}
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString();
		}
		return z0ZzZzuyk.z0rek(z0ZzZzuyk.z0eek());
	}

	public static byte[] z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		MemoryStream memoryStream = new MemoryStream();
		using GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress);
		gZipStream.Write(p0, 0, p0.Length);
		gZipStream.Close();
		return memoryStream.ToArray();
	}

	public static byte[] z0rek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		using GZipStream gZipStream = new GZipStream(new MemoryStream(p0), CompressionMode.Decompress);
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[512];
		while (true)
		{
			int num = gZipStream.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num);
		}
		return memoryStream.ToArray();
	}

	public static byte[] z0eek(Stream p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (p0 is MemoryStream)
		{
			return ((MemoryStream)p0).ToArray();
		}
		byte[] array = null;
		int num = 0;
		int num2 = 0;
		try
		{
			if (p0.CanSeek && p0.Length > 0)
			{
				array = new byte[p0.Length];
				num2 = p0.Read(array, 0, array.Length);
				num = num2;
			}
		}
		catch (Exception)
		{
		}
		if (array == null)
		{
			array = new byte[1024];
		}
		byte[] array2 = new byte[1024];
		while (true)
		{
			int num3 = p0.Read(array2, 0, 1024);
			if (num3 <= 0)
			{
				break;
			}
			if (array.Length < num + num3)
			{
				byte[] array3 = new byte[(int)(1.5 * (double)array.Length + 1024.0)];
				Array.Copy(array, array3, num2);
				array = array3;
			}
			Array.Copy(array2, 0, array, num, num3);
			num += num3;
			num2 += num3;
		}
		if (array.Length > num2)
		{
			byte[] array4 = new byte[num2];
			Array.Copy(array, array4, num2);
			return array4;
		}
		return array;
	}

	public static string z0eek(long p0)
	{
		long num = p0;
		string text = null;
		if (p0 > 1099511627776L)
		{
			num = num * 100 / 1099511627776L;
			text = "PB";
		}
		else if (p0 > 1073741824)
		{
			num = num * 100 / 1073741824;
			text = "GB";
		}
		else if (p0 > 1048576)
		{
			num = num * 100 / 1048576;
			text = "MB";
		}
		else
		{
			if (p0 <= 1024)
			{
				return p0 + "B";
			}
			num = num * 100 / 1024;
			text = "KB";
		}
		int num2 = (int)(num % 100);
		num /= 100;
		if (num > 10)
		{
			num2 /= 10;
		}
		if (num2 == 0)
		{
			return num + text;
		}
		return num + "." + num2 + text;
	}

	public static bool z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return false;
		}
		p0 = p0.Trim();
		if (!p0.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
		{
			return p0.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	public static TextReader z0eek(byte[] p0, Encoding p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		return new StreamReader(new GZipStream(new MemoryStream(p0), CompressionMode.Decompress), p1);
	}

	public static string z0eek(string p0, char p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		if ("\\/:*?\"<>|#".Contains(p1))
		{
			throw new ArgumentNullException("InvalidReplaceChar");
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in p0)
		{
			if ("\\/:*?\"<>|#".Contains(c))
			{
				if (p1 > '\0')
				{
					stringBuilder.Append(p1);
				}
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
