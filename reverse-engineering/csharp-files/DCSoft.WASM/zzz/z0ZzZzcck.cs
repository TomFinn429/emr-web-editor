using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzcck
{
	public bool z0iek;

	public bool z0oek;

	public bool z0pek;

	public bool z0mek_jiejie20260327142557;

	public bool z0nek;

	public override string ToString()
	{
		List<string> list = new List<string>();
		if (z0iek)
		{
			string z0ftk = z0ZzZzkrk.z0ftk;
			byte[] array = Convert.FromBase64String(z0ftk);
			for (int i = 0; i < 12; i++)
			{
				array[i] = (byte)(array[i] ^ (167 + i));
			}
			z0ftk = Encoding.UTF8.GetString(array);
			list.Add(z0ftk);
		}
		if (z0nek)
		{
			string z0trk = z0ZzZzlrk.z0trk;
			byte[] array2 = Convert.FromBase64String(z0trk);
			for (int j = 0; j < 12; j++)
			{
				array2[j] = (byte)(array2[j] ^ (199 + j));
			}
			z0trk = Encoding.UTF8.GetString(array2);
			list.Add(z0trk);
		}
		if (z0pek)
		{
			string z0ftk2 = z0ZzZzzek.z0ftk;
			byte[] array3 = Convert.FromBase64String(z0ftk2);
			for (int k = 0; k < 29; k++)
			{
				array3[k] = (byte)(array3[k] ^ (172 + k));
			}
			z0ftk2 = Encoding.UTF8.GetString(array3);
			list.Add(z0ftk2);
		}
		if (z0mek_jiejie20260327142557)
		{
			string z0yek = z0ZzZzzek.z0yek;
			byte[] array4 = Convert.FromBase64String(z0yek);
			for (int l = 0; l < 36; l++)
			{
				array4[l] = (byte)(array4[l] ^ (194 + l));
			}
			z0yek = Encoding.UTF8.GetString(array4);
			list.Add(z0yek);
		}
		if (z0oek)
		{
			string z0ork = z0ZzZzzek.z0ork;
			byte[] array5 = Convert.FromBase64String(z0ork);
			for (int m = 0; m < 7; m++)
			{
				array5[m] = (byte)(array5[m] ^ (239 + m));
			}
			z0ork = Encoding.UTF8.GetString(array5);
			list.Add(z0ork);
		}
		return z0ZzZzyck.z0eek(list, Convert.ToChar((int)Math.Sqrt(1936.0)).ToString());
	}

	public z0ZzZzcck(int p0)
	{
		z0iek = (p0 & 1) == 1;
		z0nek = (p0 & 2) == 2;
		z0pek = (p0 & 4) == 4;
		z0mek_jiejie20260327142557 = (p0 & 8) == 8;
		z0oek = (p0 & 0x10) == 16;
	}
}
