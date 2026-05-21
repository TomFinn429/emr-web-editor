using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace zzz;

internal static class z0ZzZzloj
{
	[CompilerGenerated]
	private static class z0nik
	{
		public static z0ZzZzbej.z0njj z0eek;
	}

	public static byte[] z0rek(Stream p0, string p1)
	{
		using (ZipArchive zipArchive = new ZipArchive(p0))
		{
			foreach (ZipArchiveEntry entry in zipArchive.Entries)
			{
				if (!(entry.FullName == p1) || entry.Length <= 0)
				{
					continue;
				}
				Stream stream = entry.Open();
				byte[] array = new byte[entry.Length];
				int num = 0;
				while (true)
				{
					int num2 = stream.Read(array, num, array.Length - num);
					if (num2 <= 0)
					{
						break;
					}
					num += num2;
				}
				stream.Close();
				return array;
			}
		}
		return null;
	}

	public static Dictionary<string, byte[]> z0rek(Stream p0)
	{
		Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
		using ZipArchive zipArchive = new ZipArchive(p0);
		foreach (ZipArchiveEntry entry in zipArchive.Entries)
		{
			if (string.IsNullOrEmpty(entry.Name) || entry.Length <= 0)
			{
				continue;
			}
			Stream stream = entry.Open();
			byte[] array = new byte[entry.Length];
			int num = 0;
			while (true)
			{
				int num2 = stream.Read(array, num, array.Length - num);
				if (num2 <= 0)
				{
					break;
				}
				num += num2;
			}
			stream.Close();
			dictionary[entry.FullName] = array;
		}
		return dictionary;
	}

	internal static byte[] z0eek(Dictionary<string, MemoryStream> p0)
	{
		MemoryStream memoryStream = new MemoryStream();
		using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create))
		{
			List<string> list = new List<string>(p0.Keys);
			list.Sort();
			foreach (string item in list)
			{
				byte[] array = p0[item].ToArray();
				if (array != null && array.Length != 0)
				{
					Stream stream = zipArchive.CreateEntry(item).Open();
					stream.Write(array, 0, array.Length);
					stream.Close();
				}
			}
		}
		byte[] result = memoryStream.ToArray();
		memoryStream.Close();
		return result;
	}

	public static void z0rek()
	{
		z0ZzZzbej.z0tek = z0rek;
	}
}
