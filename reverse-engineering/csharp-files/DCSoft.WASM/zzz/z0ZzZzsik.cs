using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Text;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzsik : ArrayList
{
	public int z0rek;

	public bool z0tek;

	public byte z0uek;

	private static Random z0iek;

	public bool z0pek;

	public bool z0mek;

	public bool z0nek = true;

	public bool z0vek;

	public int z0cek;

	public z0ZzZzsik(byte[] p0)
	{
		z0eek(p0);
	}

	public z0ZzZzsik()
	{
	}

	private object z0eek(BinaryReader p0)
	{
		byte b = p0.ReadByte();
		switch (b)
		{
		case 0:
			return null;
		case 1:
			return string.Empty;
		case 2:
			return p0.ReadString();
		case 3:
			return p0.ReadBoolean();
		case 4:
			return p0.ReadInt32();
		case 5:
			return p0.ReadSingle();
		case 6:
			return p0.ReadDouble();
		case 7:
			return p0.ReadByte();
		case 8:
			return (sbyte)p0.ReadByte();
		case 9:
			return p0.ReadInt16();
		case 10:
			return p0.ReadUInt16();
		case 11:
			return p0.ReadUInt32();
		case 12:
			return p0.ReadInt64();
		case 13:
			return p0.ReadUInt64();
		case 14:
			return p0.ReadDecimal();
		case 15:
			return Color.FromArgb(p0.ReadInt32());
		case 16:
		{
			int num4 = p0.ReadInt32();
			if (num4 > 0)
			{
				return p0.ReadBytes(num4);
			}
			return null;
		}
		case 17:
			return new DateTime(p0.ReadInt64());
		case 18:
			return p0.ReadChar();
		case 19:
			return p0.ReadUInt64();
		case 20:
			return p0.ReadInt32();
		case 21:
			return new object();
		case 22:
			return DBNull.Value;
		case 23:
			return new Guid(p0.ReadBytes(16));
		case 24:
		{
			int num3 = p0.ReadInt32();
			int[] array2 = new int[num3];
			for (int k = 0; k < num3; k++)
			{
				array2[k] = p0.ReadInt32();
			}
			return array2;
		}
		case 25:
		{
			int num2 = p0.ReadInt32();
			object[] array = new object[num2];
			for (int j = 0; j < num2; j++)
			{
				array[j] = z0eek(p0);
			}
			return array;
		}
		case 26:
		{
			Hashtable hashtable = new Hashtable();
			int num = p0.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				object obj = z0eek(p0);
				object obj2 = z0eek(p0);
				hashtable[obj] = obj2;
			}
			return hashtable;
		}
		default:
			throw new NotSupportedException("type=" + b);
		}
	}

	private void z0eek(BinaryWriter p0, object p1)
	{
		if (p1 == null)
		{
			p0.Write((byte)0);
			return;
		}
		if (p1 is string)
		{
			string text = (string)p1;
			if (text.Length == 0)
			{
				if (z0vek)
				{
					p0.Write((byte)0);
				}
				else
				{
					p0.Write((byte)1);
				}
			}
			else
			{
				p0.Write((byte)2);
				p0.Write(text);
			}
			return;
		}
		if (p1 is bool)
		{
			p0.Write((byte)3);
			p0.Write((bool)p1);
			return;
		}
		if (p1 is int)
		{
			p0.Write((byte)4);
			p0.Write((int)p1);
			return;
		}
		if (p1 is float)
		{
			p0.Write((byte)5);
			p0.Write((float)p1);
			return;
		}
		if (p1 is double)
		{
			p0.Write((byte)6);
			p0.Write((double)p1);
			return;
		}
		if (p1 is byte)
		{
			p0.Write((byte)7);
			p0.Write((byte)p1);
			return;
		}
		if (p1 is sbyte)
		{
			p0.Write((byte)8);
			p0.Write((int)p1);
			return;
		}
		if (p1 is short)
		{
			p0.Write((byte)9);
			p0.Write((short)p1);
			return;
		}
		if (p1 is ushort)
		{
			p0.Write((byte)10);
			p0.Write((ushort)p1);
			return;
		}
		if (p1 is uint)
		{
			p0.Write((byte)11);
			p0.Write((uint)p1);
			return;
		}
		if (p1 is long)
		{
			p0.Write((byte)12);
			p0.Write((long)p1);
			return;
		}
		if (p1 is ulong)
		{
			p0.Write((byte)13);
			p0.Write((ulong)p1);
			return;
		}
		if (p1 is decimal)
		{
			p0.Write((byte)14);
			p0.Write((decimal)p1);
			return;
		}
		if (p1 is Color)
		{
			p0.Write((byte)15);
			p0.Write(((Color)p1).ToArgb());
			return;
		}
		if (p1 is byte[])
		{
			p0.Write((byte)16);
			byte[] array = (byte[])p1;
			p0.Write(array.Length);
			if (array.Length != 0)
			{
				p0.Write(array);
			}
			return;
		}
		if (p1 is DateTime)
		{
			p0.Write((byte)17);
			p0.Write(((DateTime)p1).Ticks);
			return;
		}
		if (p1 is char)
		{
			p0.Write((byte)18);
			p0.Write((char)p1);
			return;
		}
		if (p1 is ulong)
		{
			p0.Write((byte)19);
			p0.Write((ulong)p1);
			return;
		}
		if (p1 is Enum)
		{
			p0.Write((byte)20);
			p0.Write(Convert.ToInt32(p1));
			return;
		}
		if (p1.GetType() == typeof(object))
		{
			p0.Write((byte)21);
			return;
		}
		if (DBNull.Value.Equals(p1))
		{
			p0.Write((byte)22);
			return;
		}
		if (p1 is Guid)
		{
			p0.Write((byte)23);
			byte[] array2 = ((Guid)p1).ToByteArray();
			p0.Write(array2);
			return;
		}
		if (p1 is int[])
		{
			p0.Write((byte)24);
			int[] array3 = (int[])p1;
			int num = array3.Length;
			p0.Write(num);
			for (int i = 0; i < num; i++)
			{
				p0.Write(array3[i]);
			}
			return;
		}
		if (p1 is Array)
		{
			p0.Write((byte)25);
			Array array4 = (Array)p1;
			int length = array4.Length;
			p0.Write(length);
			for (int j = 0; j < length; j++)
			{
				z0eek(p0, array4.GetValue(j));
			}
			return;
		}
		if (p1 is IDictionary)
		{
			p0.Write((byte)26);
			IDictionary dictionary = (IDictionary)p1;
			p0.Write(dictionary.Count);
			IDictionaryEnumerator enumerator = dictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				z0eek(p0, enumerator.Key);
				z0eek(p0, enumerator.Value);
			}
			return;
		}
		throw new NotSupportedException(p1.GetType().FullName);
	}

	public int z0eek(byte[] p0, int p1 = 0)
	{
		if (p0 == null || p0.Length < 12)
		{
			return 0;
		}
		int num = p1;
		if (BitConverter.ToInt32(p0, num) != z0cek)
		{
			return 0;
		}
		num += 4;
		int num2 = BitConverter.ToInt32(p0, num);
		num += 4;
		z0pek = (num2 & 4) == 4;
		int num3 = p0.Length - num;
		if (z0pek)
		{
			num3 = BitConverter.ToInt32(p0, p1 + 8);
			num += 4;
		}
		if (num3 < 0 || num3 > p0.Length - num)
		{
			return 0;
		}
		z0mek = (num2 & 1) == 1;
		z0tek = (num2 & 2) == 2;
		byte[] array = new byte[num3];
		Array.Copy(p0, num, array, 0, array.Length);
		if (z0tek)
		{
			for (int num4 = array.Length - 1; num4 > 0; num4--)
			{
				array[num4] ^= array[num4 - 1];
			}
		}
		if (z0rek != 0)
		{
			z0ZzZzeyk.z0eek(array, -z0rek);
		}
		if (z0uek != 0)
		{
			z0ZzZzeyk.z0eek(array, z0uek);
		}
		if (z0mek)
		{
			GZipStream gZipStream = new GZipStream(new MemoryStream(array), CompressionMode.Decompress);
			array = z0ZzZzmuk.z0eek(gZipStream);
			gZipStream.Close();
		}
		int num5 = BitConverter.ToInt32(array, array.Length - 4);
		int num6 = 0;
		int num7 = array.Length - 4;
		for (int i = 0; i < num7; i++)
		{
			num6 = num6 + array[i] + i;
			num6 <<= 1;
		}
		if (num6 != num5)
		{
			return 0;
		}
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(array), Encoding.UTF8);
		binaryReader.ReadInt32();
		int num8 = (Capacity = binaryReader.ReadInt32());
		try
		{
			for (int j = 0; j < num8; j++)
			{
				object obj = z0eek(binaryReader);
				Add(obj);
			}
			if (binaryReader.ReadInt32() != z0cek)
			{
				Clear();
				return 0;
			}
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
			Clear();
			return 0;
		}
		binaryReader.Close();
		return num8;
	}

	public byte[] z0eek()
	{
		if (Count == 0)
		{
			return null;
		}
		int num = 0;
		if (z0mek)
		{
			num |= 1;
		}
		if (z0tek)
		{
			num |= 2;
		}
		if (z0pek)
		{
			num |= 4;
		}
		byte[] array = (z0pek ? new byte[12] : new byte[8]);
		byte[] bytes = BitConverter.GetBytes(z0cek);
		array[0] = bytes[0];
		array[1] = bytes[1];
		array[2] = bytes[2];
		array[3] = bytes[3];
		bytes = BitConverter.GetBytes(num);
		array[4] = bytes[0];
		array[5] = bytes[1];
		array[6] = bytes[2];
		array[7] = bytes[3];
		MemoryStream memoryStream = new MemoryStream(Math.Max(Count * 4, 32));
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8);
		byte[] array2 = new byte[4];
		if (z0nek)
		{
			if (z0iek == null)
			{
				z0iek = new Random();
			}
			z0iek.NextBytes(array2);
		}
		else
		{
			array2[0] = 123;
			array2[1] = 89;
			array2[2] = 23;
			array2[3] = 60;
		}
		binaryWriter.Write(array2);
		int count = Count;
		binaryWriter.Write(count);
		for (int i = 0; i < count; i++)
		{
			object p = this[i];
			z0eek(binaryWriter, p);
		}
		binaryWriter.Write(z0cek);
		binaryWriter.Flush();
		byte[] buffer = memoryStream.GetBuffer();
		int num2 = 0;
		int num3 = (int)memoryStream.Length;
		for (int j = 0; j < num3; j++)
		{
			num2 = num2 + buffer[j] + j;
			num2 <<= 1;
		}
		binaryWriter.Write(num2);
		byte[] array3 = memoryStream.ToArray();
		memoryStream.Close();
		if (z0mek || z0uek != 0 || z0rek != 0 || z0tek)
		{
			if (z0mek)
			{
				memoryStream = new MemoryStream();
				GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress);
				gZipStream.Write(array3, 0, array3.Length);
				gZipStream.Close();
				array3 = memoryStream.ToArray();
			}
			if (z0uek != 0)
			{
				z0ZzZzeyk.z0eek(array3, z0uek);
			}
			if (z0rek != 0)
			{
				z0ZzZzeyk.z0eek(array3, z0rek);
			}
			if (z0tek)
			{
				int num4 = array3.Length - 1;
				for (int k = 0; k < num4; k++)
				{
					array3[k + 1] = (byte)(array3[k + 1] ^ array3[k]);
				}
			}
		}
		if (z0pek)
		{
			byte[] bytes2 = BitConverter.GetBytes(array3.Length);
			array[8] = bytes2[0];
			array[9] = bytes2[1];
			array[10] = bytes2[2];
			array[11] = bytes2[3];
		}
		return z0ZzZzeyk.z0eek(array, array3);
	}
}
