using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Writer;

namespace zzz;

public class z0ZzZzzgh
{
	public List<int> z0eek;

	public byte[] z0rek_jiejie20260327142557;

	public DocumentOptions z0tek;

	public string z0yek;

	public z0ZzZzzgh(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return;
		}
		z0ZzZzeyk.z0eek(p0, (byte)210);
		MemoryStream memoryStream = new MemoryStream(p0);
		BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8);
		z0yek = binaryReader.ReadString();
		if (string.IsNullOrEmpty(z0yek))
		{
			z0yek = null;
		}
		string text = binaryReader.ReadString();
		if (text != null && text.Length > 0)
		{
			z0eek = new List<int>();
			string[] array = text.Split(',');
			foreach (string text2 in array)
			{
				int num = 0;
				if (text2.Length > 0 && int.TryParse(text2, out num))
				{
					z0eek.Add(num);
				}
			}
		}
		string text3 = binaryReader.ReadString();
		if (text3 != null)
		{
			_ = text3.Length;
			_ = 0;
		}
		int num2 = binaryReader.ReadInt32();
		z0rek_jiejie20260327142557 = binaryReader.ReadBytes(num2);
		binaryReader.Close();
		memoryStream.Close();
	}
}
