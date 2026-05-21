using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace zzz;

internal abstract class z0ZzZzmdj : z0ZzZzvdj
{
	public class z0shj : IDictionary<int, string>, ICollection<KeyValuePair<int, string>>, IEnumerable<KeyValuePair<int, string>>, IEnumerable
	{
		public readonly string z0vek;

		public readonly int z0cek;

		private void z0uek(int p0, string p1)
		{
			throw new NotImplementedException();
		}

		void IDictionary<int, string>.Add(int p0, string p1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0uek
			this.z0uek(p0, p1);
		}

		private ICollection<int> z0uek()
		{
			throw new NotImplementedException();
		}

		ICollection<int> IDictionary<int, string>.get_Keys()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0uek
			return this.z0uek();
		}

		private bool z0iek()
		{
			throw new NotImplementedException();
		}

		bool ICollection<KeyValuePair<int, string>>.get_IsReadOnly()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0iek
			return this.z0iek();
		}

		private bool z0eek(KeyValuePair<int, string> p0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<KeyValuePair<int, string>>.Contains(KeyValuePair<int, string> p0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0eek
			return this.z0eek(p0);
		}

		private IEnumerator<KeyValuePair<int, string>> z0oek()
		{
			throw new NotImplementedException();
		}

		IEnumerator<KeyValuePair<int, string>> IEnumerable<KeyValuePair<int, string>>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0oek
			return this.z0oek();
		}

		private IEnumerator z0pek()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0pek
			return this.z0pek();
		}

		private bool z0rek(KeyValuePair<int, string> p0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<KeyValuePair<int, string>>.Remove(KeyValuePair<int, string> p0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0rek
			return this.z0rek(p0);
		}

		private bool z0uek(int p0, out string p1)
		{
			throw new NotImplementedException();
		}

		bool IDictionary<int, string>.TryGetValue(int p0, out string p1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0uek
			return this.z0uek(p0, out p1);
		}

		private string z0uek(int p0)
		{
			throw new NotImplementedException();
		}

		string IDictionary<int, string>.get_Item(int p0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0uek
			return this.z0uek(p0);
		}

		private bool z0iek(int p0)
		{
			throw new NotImplementedException();
		}

		bool IDictionary<int, string>.ContainsKey(int p0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0iek
			return this.z0iek(p0);
		}

		private int z0mek()
		{
			throw new NotImplementedException();
		}

		int ICollection<KeyValuePair<int, string>>.get_Count()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0mek
			return this.z0mek();
		}

		public z0shj(int p0, string p1)
		{
			z0cek = p0;
			z0vek = p1;
		}

		private ICollection<string> z0nek()
		{
			throw new NotImplementedException();
		}

		ICollection<string> IDictionary<int, string>.get_Values()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0nek
			return this.z0nek();
		}

		private void z0iek(int p0, string p1)
		{
			throw new NotImplementedException();
		}

		void IDictionary<int, string>.set_Item(int p0, string p1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0iek
			this.z0iek(p0, p1);
		}

		private void z0tek(KeyValuePair<int, string> p0)
		{
			throw new NotImplementedException();
		}

		void ICollection<KeyValuePair<int, string>>.Add(KeyValuePair<int, string> p0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0tek
			this.z0tek(p0);
		}

		private bool z0oek(int p0)
		{
			throw new NotImplementedException();
		}

		bool IDictionary<int, string>.Remove(int p0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0oek
			return this.z0oek(p0);
		}

		private void z0yek(KeyValuePair<int, string>[] p0, int p1)
		{
			throw new NotImplementedException();
		}

		void ICollection<KeyValuePair<int, string>>.CopyTo(KeyValuePair<int, string>[] p0, int p1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0yek
			this.z0yek(p0, p1);
		}

		private void z0bek()
		{
			throw new NotImplementedException();
		}

		void ICollection<KeyValuePair<int, string>>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0bek
			this.z0bek();
		}
	}

	[CompilerGenerated]
	private sealed class z0mik
	{
		public bool z0rek;

		internal int z0eek(z0ZzZzjfj p0, z0ZzZzjfj p1)
		{
			return z0ZzZzmdj.z0eek(p0, z0rek) - z0ZzZzmdj.z0eek(p1, z0rek);
		}
	}

	private readonly z0ZzZzchj z0rek;

	private readonly List<z0ZzZzjfj> z0tek;

	private readonly Dictionary<int, int> z0yek = new Dictionary<int, int>();

	private readonly z0ZzZzzfj z0uek;

	private static readonly z0ZzZzndj[] z0iek = new z0ZzZzndj[1];

	private readonly double z0oek;

	protected z0ZzZzxdj z0eek(string p0, z0ZzZzcdj p1)
	{
		int num = p0?.Length ?? 0;
		if (num == 1)
		{
			char c = p0[0];
			int p2 = c;
			if (z0tek != null && !z0eek(c))
			{
				p2 = z0edk(c);
			}
			z0ZzZzndj z0ZzZzndj2 = z0tdk(p2, c, z0uek.z0uek(p2), 0.0);
			IDictionary<int, string> p3 = new z0shj(z0ZzZzndj2.z0eek(), p0);
			z0iek[0] = z0ZzZzndj2;
			return new z0ZzZzxdj(z0ydk(z0iek), p3);
		}
		List<int> list = new List<int>(num);
		List<int> list2 = new List<int>();
		for (int i = 0; i < num; i++)
		{
			char c2 = p0[i];
			if (char.IsHighSurrogate(c2) && i < num - 1)
			{
				int num2 = char.ConvertToUtf32(c2, p0[i + 1]);
				list.Add(z0edk(num2));
				list2.Add(num2);
				i++;
			}
			else if (!z0eek(c2))
			{
				list.Add(z0edk(c2));
				list2.Add(c2);
			}
		}
		IDictionary<int, string> dictionary = new Dictionary<int, string>(num);
		IList<z0ZzZzndj> list3 = new List<z0ZzZzndj>(num);
		num = list.Count;
		_ = new byte[num * 2];
		z0ZzZzsdj z0ZzZzsdj2 = z0uek.z0zek();
		bool flag = (p1 & (z0ZzZzcdj)1) != 0 && z0ZzZzsdj2 != null && list != null;
		num = list2.Count;
		for (int j = 0; j < num; j++)
		{
			int num3 = list2[j];
			int num4 = list?[j] ?? num3;
			double p4 = 0.0;
			if (flag && j > 0)
			{
				p4 = (double)(-z0ZzZzsdj2.z0eek(list[j - 1], num4)) * z0oek;
			}
			z0ZzZzndj z0ZzZzndj3 = z0tdk(num4, num3, z0uek.z0uek(num4), p4);
			if (!dictionary.ContainsKey(z0ZzZzndj3.z0eek()))
			{
				if (num3 > 65535)
				{
					string text = char.ConvertFromUtf32(num3);
					dictionary.Add(z0ZzZzndj3.z0eek(), text);
				}
				else
				{
					dictionary.Add(z0ZzZzndj3.z0eek(), new string((char)num3, 1));
				}
			}
			list3.Add(z0ZzZzndj3);
		}
		return new z0ZzZzxdj(z0ydk(list3), dictionary);
	}

	protected abstract z0ZzZzzdj z0ydk(IList<z0ZzZzndj> p0);

	internal override int z0edk(int p0)
	{
		int num = 0;
		if (z0yek.TryGetValue(p0, out num))
		{
			return num;
		}
		foreach (z0ZzZzjfj item in z0tek)
		{
			num = item.z0qdk(p0);
			if (num != 0)
			{
				break;
			}
		}
		z0yek.Add(p0, num);
		return num;
	}

	protected z0ZzZzmdj(z0ZzZzzfj p0, z0ZzZzchj p1)
	{
		z0uek = p0;
		z0oek = 1000.0 / (double)((p0.z0lrk() == null) ? 2048 : p0.z0lrk().z0eek());
		this.z0rek = p1;
		List<z0ZzZzjfj> list = ((p0.z0vek() == null) ? null : p0.z0vek().z0eek());
		if (list != null)
		{
			z0tek = new List<z0ZzZzjfj>(list);
			bool z0rek = p0.z0uek() != null && p0.z0uek().z0uek();
			z0tek.Sort((z0ZzZzjfj p2, z0ZzZzjfj p3) => z0eek(p2, z0rek) - z0eek(p3, z0rek));
		}
	}

	protected abstract z0ZzZzndj z0tdk(int p0, int p1, double p2, double p3);

	protected static bool z0eek(char p0)
	{
		if (p0 >= '\u202a')
		{
			return p0 <= '\u202e';
		}
		return false;
	}

	internal override z0ZzZzxdj z0rdk(string p0, z0ZzZzcdj p1)
	{
		return z0eek(p0, p1);
	}

	protected override void z0ygk(bool p0)
	{
		base.z0ygk(p0);
		if (p0 && z0rek != null)
		{
			z0rek.Dispose();
		}
	}

	public z0ZzZzzfj z0eek()
	{
		return z0uek;
	}

	private static int z0eek(z0ZzZzjfj p0, bool p1)
	{
		int num = 0;
		num = p0.z0tek() switch
		{
			(z0ZzZzudj)3 => 0, 
			(z0ZzZzudj)2 => 100, 
			_ => 200, 
		};
		num = p0.z0rek() switch
		{
			(z0ZzZzxfj)1 => num + (p1 ? 10 : 0), 
			(z0ZzZzxfj)0 => num + ((!p1) ? 10 : 0), 
			_ => num + 20, 
		};
		if (!(p0 is z0ZzZzrfj))
		{
			num++;
		}
		return num;
	}
}
