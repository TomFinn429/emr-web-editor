using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZziaj
{
	private static readonly string z0tek = "X2";

	private static readonly string z0yek = "X4";

	private readonly byte[] z0uek;

	private static readonly string z0iek = "#fontname";

	private static readonly string z0oek = " beginbfchar";

	private static readonly string z0pek = "/CIDInit /ProcSet findresource begin\r\n12 dict begin\r\nbegincmap\r\n/CIDSystemInfo\r\n<<\r\n/Registry (Adobe)\r\n/Ordering (#fontname)\r\n/Supplement 0\r\n>> def\r\n/CMapName /#fontname def\r\n/CMapType 2 def\r\n1 begincodespacerange\r\n<0000> <FFFF>\r\nendcodespacerange";

	private static readonly string z0mek = "endbfrange";

	private static readonly string z0nek = "> <";

	private readonly int z0bek;

	private static readonly string z0vek = "><";

	private static readonly string z0cek = "endcmap\r\nCMapName currentdict /CMap defineresource pop\r\nend\r\nend";

	private static readonly string z0xek = ">]";

	private readonly z0ZzZzhgj z0zek = new z0ZzZzhgj();

	private static readonly string z0lrk = "endbfchar";

	private static readonly string z0krk = "> [<";

	private static readonly string z0jrk = " beginbfrange";

	internal byte[] z0rek()
	{
		return z0uek;
	}

	internal z0ZzZziaj(byte[] p0, IDictionary<byte[], string> p1)
	{
		z0uek = p0;
		foreach (KeyValuePair<byte[], string> item in p1)
		{
			byte[] key = item.Key;
			z0bek = Math.Max(z0bek, key.Length);
			z0zek.z0ask(key, 0, item.Value);
		}
	}

	internal static byte[] z0eek(IDictionary<int, string> p0, string p1, bool p2)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using (StreamWriter streamWriter = new StreamWriter(memoryStream))
		{
			streamWriter.WriteLine(z0pek.Replace(z0iek, p1));
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>(p0.Count);
			List<KeyValuePair<int, string>> list2 = new List<KeyValuePair<int, string>>();
			string text = (p2 ? z0yek : z0tek);
			if (p0.Count > 0)
			{
				foreach (KeyValuePair<int, string> item in p0)
				{
					if (item.Value.Length == 1)
					{
						list.Add(item);
					}
					else if (!string.IsNullOrEmpty(item.Value))
					{
						list2.Add(item);
					}
				}
				if (list.Count > 0)
				{
					streamWriter.Write(Convert.ToString(list.Count));
					streamWriter.WriteLine(z0oek);
					foreach (KeyValuePair<int, string> item2 in list)
					{
						streamWriter.WriteLine("<" + item2.Key.ToString(text) + z0nek + ((ushort)item2.Value[0]).ToString(z0yek) + ">");
					}
					streamWriter.WriteLine(z0lrk);
				}
				if (list2.Count > 0)
				{
					streamWriter.Write(Convert.ToString(list2.Count));
					streamWriter.WriteLine(z0jrk);
					foreach (KeyValuePair<int, string> item3 in list2)
					{
						string text2 = item3.Key.ToString(z0yek);
						streamWriter.Write("<" + text2 + z0vek + text2 + z0krk);
						string value = item3.Value;
						foreach (char c in value)
						{
							ushort num = c;
							streamWriter.Write(num.ToString(z0yek));
						}
						streamWriter.WriteLine(z0xek);
					}
					streamWriter.WriteLine(z0mek);
				}
			}
			streamWriter.WriteLine(z0cek);
		}
		byte[] array = memoryStream.ToArray();
		Encoding.UTF8.GetString(array);
		return array;
	}
}
