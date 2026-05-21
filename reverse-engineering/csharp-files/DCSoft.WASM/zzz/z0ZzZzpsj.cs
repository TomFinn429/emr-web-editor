using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCSoft;

namespace zzz;

internal class z0ZzZzpsj
{
	[CompilerGenerated]
	private sealed class z0guk<T> where T : z0ZzZzfsj
	{
		public DCFunc<z0ZzZzdsj, object, T> z0rek;

		public int z0tek;

		public z0ZzZzdsj z0yek;

		internal T z0eek()
		{
			return z0rek(z0yek, z0yek.z0oek(z0tek));
		}
	}

	[CompilerGenerated]
	private sealed class z0suk<T> where T : z0ZzZzfsj
	{
		public DCFunc<string, T> z0eek;
	}

	[CompilerGenerated]
	private sealed class z0auk<T> where T : z0ZzZzfsj
	{
		public z0suk<T> z0rek;

		public string z0tek;

		internal z0ZzZzfsj z0eek()
		{
			return z0rek.z0eek(z0tek);
		}
	}

	private readonly z0ZzZzmsj z0mek;

	private readonly Dictionary<string, int> z0nek = new Dictionary<string, int>();

	private readonly string z0bek;

	private int z0vek;

	private readonly string z0cek;

	internal void z0eek<T>(z0ZzZzeaj p0, DCFunc<string, T> p1) where T : z0ZzZzfsj
	{
		z0ZzZzdsj z0ZzZzdsj2 = p0.z0tek_jiejie20260327142557();
		foreach (KeyValuePair<string, int> item in z0nek)
		{
			string z0tek = item.Key;
			if (!p0.ContainsKey(z0tek))
			{
				p0.Add(z0tek, z0ZzZzdsj2.z0yek(item.Value, () => p1(z0tek)));
			}
		}
	}

	internal z0ZzZzpsj(z0ZzZzmsj p0, string p1, string p2)
	{
		z0mek = p0;
		z0bek = p1;
		z0cek = p2;
	}

	internal string z0iek(int p0)
	{
		string text = z0oek(p0);
		if (string.IsNullOrEmpty(text))
		{
			text = z0oek();
			z0nek.Add(text, p0);
		}
		return text;
	}

	private string z0iek()
	{
		return z0cek + z0vek++;
	}

	internal string z0oek(int p0)
	{
		foreach (KeyValuePair<string, int> item in z0nek)
		{
			if (item.Value == p0)
			{
				return item.Key;
			}
		}
		return null;
	}

	internal T z0rek<T>(string p0, DCFunc<z0ZzZzdsj, object, T> p1) where T : z0ZzZzfsj
	{
		z0ZzZzdsj z0yek = z0mek.z0uek().z0uek();
		if (!z0nek.TryGetValue(p0, out var z0tek))
		{
			throw new NotSupportedException();
		}
		return z0yek.z0eek(z0tek, () => p1(z0yek, z0yek.z0oek(z0tek)));
	}

	private string z0oek()
	{
		return z0yek(z0iek(), z0pek());
	}

	internal string z0tek<T>(T p0, bool p1) where T : z0ZzZzfsj
	{
		string text = z0oek(p0.z0rek());
		if (string.IsNullOrEmpty(text))
		{
			text = z0oek();
			z0nek.Add(text, z0mek.z0uek().z0uek().z0uek(p0, p1));
		}
		return text;
	}

	private string z0yek(string p0, ICollection<string> p1)
	{
		while (p1.Contains(p0))
		{
			p0 = z0iek();
		}
		return p0;
	}

	internal void z0uek<T>(string p0, DCFunc<string, T> p1) where T : z0ZzZzfsj
	{
	}

	internal ICollection<string> z0pek()
	{
		return new HashSet<string>(z0nek.Keys);
	}
}
