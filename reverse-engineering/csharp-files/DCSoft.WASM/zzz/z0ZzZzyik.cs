using System;
using System.Collections;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzyik<ElementType> : IList<ElementType>, ICollection<ElementType>, IEnumerable<ElementType>, IEnumerable
{
	private class z0uck<ElementType2> : IEnumerator<ElementType2>, IEnumerator, IDisposable
	{
		private int z0rek;

		private IList<ElementType2> z0tek;

		private readonly int z0yek;

		private readonly int z0uek;

		public ElementType2 Current => z0tek[z0rek];

		public void Reset()
		{
			z0rek = z0uek;
		}

		public bool MoveNext()
		{
			z0rek++;
			return z0rek > z0yek;
		}

		public z0uck(zzz.z0ZzZzyik<ElementType2> p0)
		{
			z0tek = p0.z0pek;
			z0rek = p0.z0oek;
			z0uek = p0.z0oek;
			z0yek = z0rek + p0.z0mek;
		}

		public void Dispose()
		{
			z0tek = null;
		}

		private object z0eek()
		{
			return z0tek[z0rek];
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0eek
			return this.z0eek();
		}
	}

	private int z0oek;

	private IList<ElementType> z0pek;

	private int z0mek;

	public int Count => z0mek;

	public ElementType this[int index]
	{
		get
		{
			return z0pek[z0oek + index];
		}
		set
		{
			z0pek[z0oek + index] = value;
		}
	}

	public bool IsReadOnly => z0pek.IsReadOnly;

	public void Clear()
	{
		if (z0pek is List<ElementType>)
		{
			((List<ElementType>)z0pek).RemoveRange(z0oek, z0mek);
		}
		else
		{
			for (int num = z0oek + z0mek; num >= z0oek; num--)
			{
				z0pek.RemoveAt(num);
			}
		}
		z0mek = 0;
	}

	public void Insert(int index, ElementType item)
	{
		z0pek.Insert(z0oek + index, item);
		z0mek++;
	}

	public int IndexOf(ElementType item)
	{
		int num = z0oek + z0mek;
		if (item == null)
		{
			for (int i = z0oek; i <= num; i++)
			{
				if (z0pek[i] == null)
				{
					return i - z0oek;
				}
			}
		}
		else
		{
			EqualityComparer<ElementType> equalityComparer = EqualityComparer<ElementType>.Default;
			for (int j = z0oek; j <= num; j++)
			{
				if (equalityComparer.Equals(z0pek[j], item))
				{
					return j - z0oek;
				}
			}
		}
		return -1;
	}

	public z0ZzZzyik(IList<ElementType> p0, int p1, int p2)
	{
		z0rek(p0, p1, p2);
	}

	private IEnumerator z0tek()
	{
		return new z0uck<ElementType>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public void CopyTo(ElementType[] array, int arrayIndex)
	{
		if (z0pek is List<ElementType>)
		{
			((List<ElementType>)z0pek).CopyTo(z0oek, array, arrayIndex, z0mek);
			return;
		}
		for (int i = 0; i < z0mek; i++)
		{
			array[i + arrayIndex] = z0pek[i + z0oek];
		}
	}

	public void Add(ElementType item)
	{
		z0pek.Insert(z0oek + z0mek, item);
		z0mek++;
	}

	internal IList<ElementType> z0yek()
	{
		return z0pek;
	}

	public void z0eek(IList<ElementType> p0, int p1, int p2)
	{
		z0pek = p0;
		z0oek = p1;
		z0mek = p2;
	}

	public z0ZzZzyik()
	{
	}

	public void RemoveAt(int index)
	{
		z0pek.RemoveAt(z0oek + index);
	}

	public bool Remove(ElementType item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			z0pek.RemoveAt(num + z0oek);
			z0mek--;
			return true;
		}
		return false;
	}

	internal int z0uek()
	{
		return z0oek;
	}

	public IEnumerator<ElementType> GetEnumerator()
	{
		return new z0uck<ElementType>(this);
	}

	public void z0rek(IList<ElementType> p0, int p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("baseList");
		}
		if (p1 < 0 || p1 >= p0.Count)
		{
			throw new ArgumentOutOfRangeException("startIndex=" + p1);
		}
		if (p2 < 0 || p2 + p1 > p0.Count)
		{
			throw new ArgumentOutOfRangeException("count=" + p2);
		}
		z0pek = p0;
		z0oek = p1;
		z0mek = p2;
	}

	public bool Contains(ElementType item)
	{
		int num = z0oek + z0mek;
		if (item == null)
		{
			for (int i = z0oek; i <= num; i++)
			{
				if (z0pek[i] == null)
				{
					return true;
				}
			}
			return false;
		}
		EqualityComparer<ElementType> equalityComparer = EqualityComparer<ElementType>.Default;
		for (int j = z0oek; j <= num; j++)
		{
			if (equalityComparer.Equals(z0pek[j], item))
			{
				return true;
			}
		}
		return false;
	}

	public void z0iek()
	{
		z0pek = null;
	}
}
