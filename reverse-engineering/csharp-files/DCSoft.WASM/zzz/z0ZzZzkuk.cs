using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace zzz;

[DebuggerTypeProxy(typeof(zzz.z0ZzZzmyk<>))]
[DebuggerDisplay("Count = {Count}")]
public class z0ZzZzkuk<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	internal class z0xmk : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly int z0tek;

		private int z0yek;

		private T[] z0uek;

		public T Current => z0uek[z0yek];

		private IEnumerator z0eek()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0eek
			return this.z0eek();
		}

		public z0xmk(T[] p0, int p1)
		{
			z0uek = p0;
			z0tek = p1;
			z0yek = -1;
		}

		public void Dispose()
		{
			z0uek = null;
		}

		public bool MoveNext()
		{
			return ++z0yek < z0tek;
		}

		public void Reset()
		{
			z0yek = -1;
		}

		private object z0rek()
		{
			return z0uek[z0yek];
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0rek
			return this.z0rek();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}
	}

	public struct z0bpk : IEnumerator<T>, IEnumerator, IDisposable
	{
		private zzz.z0ZzZzkuk<T> z0tek;

		private int z0yek;

		private T z0uek;

		public T Current => z0uek;

		internal z0bpk(zzz.z0ZzZzkuk<T> p0)
		{
			z0tek = p0;
			z0yek = 0;
			z0uek = default(T);
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (z0yek < z0tek.z0wtk)
			{
				z0uek = z0tek.z0atk[z0yek];
				z0yek++;
				return true;
			}
			return false;
		}

		private object z0eek()
		{
			return z0uek;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0eek
			return this.z0eek();
		}

		private void z0rek()
		{
			z0yek = 0;
			z0uek = default(T);
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0rek
			this.z0rek();
		}
	}

	protected T[] z0atk;

	protected static readonly T[] z0qtk = Array.Empty<T>();

	protected int z0wtk;

	public T LastElement
	{
		get
		{
			if (z0wtk > 0)
			{
				return z0atk[z0wtk - 1];
			}
			return default(T);
		}
	}

	public T this[int index]
	{
		get
		{
			if (index >= z0wtk)
			{
				throw new ArgumentOutOfRangeException();
			}
			return z0atk[index];
		}
		set
		{
			if (index >= z0wtk)
			{
				throw new ArgumentOutOfRangeException();
			}
			z0atk[index] = value;
		}
	}

	public int Count => z0wtk;

	public int Capacity
	{
		get
		{
			return z0atk.Length;
		}
		set
		{
			if (value < z0wtk)
			{
				throw new ArgumentOutOfRangeException("value SmallCapacity");
			}
			if (value == z0atk.Length)
			{
				return;
			}
			if (value > 0)
			{
				T[] array = new T[value];
				if (z0wtk > 0)
				{
					Array.Copy(z0atk, 0, array, 0, z0wtk);
					Array.Clear(z0atk, 0, z0wtk);
				}
				z0atk = array;
				z0gtk();
			}
			else
			{
				z0atk = z0qtk;
			}
		}
	}

	public int z0eek(T p0, int p1, int p2)
	{
		if (Count != 0 && p1 < 0)
		{
			throw new ArgumentOutOfRangeException("index,NeedNonNegNum");
		}
		if (Count != 0 && p2 < 0)
		{
			throw new ArgumentOutOfRangeException("count,NeedNonNegNum");
		}
		if (z0wtk == 0)
		{
			return -1;
		}
		if (p1 >= z0wtk)
		{
			throw new ArgumentOutOfRangeException("index,BiggerThanCollection");
		}
		if (p2 > p1 + 1)
		{
			throw new ArgumentOutOfRangeException("count,BiggerThanCollection");
		}
		return Array.LastIndexOf(z0atk, p0, p1, p2);
	}

	public void z0yrk(int p0)
	{
		if (z0atk.Length < p0)
		{
			int num = ((z0atk.Length == 0) ? 4 : (z0atk.Length * 2));
			if (num < p0)
			{
				num = p0;
			}
			Capacity = num;
		}
	}

	public void RemoveAt(int index)
	{
		if ((uint)index >= (uint)z0wtk)
		{
			throw new ArgumentOutOfRangeException();
		}
		z0wtk--;
		if (index < z0wtk)
		{
			Array.Copy(z0atk, index + 1, z0atk, index, z0wtk - index);
		}
		z0atk[z0wtk] = default(T);
	}

	private bool z0yrk()
	{
		return false;
	}

	bool ICollection.get_IsSynchronized()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yrk
		return this.z0yrk();
	}

	private int z0yrk(object p0)
	{
		Add((T)p0);
		return Count - 1;
	}

	int IList.Add(object p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yrk
		return this.z0yrk(p0);
	}

	public T SafeGet(int index)
	{
		if (index >= 0 && index < z0wtk)
		{
			return z0atk[index];
		}
		return default(T);
	}

	public bool z0urk(int p0)
	{
		if (p0 >= 0)
		{
			return p0 < z0wtk;
		}
		return false;
	}

	public void z0rek(T[] p0, int p1)
	{
		z0atk = p0;
		z0wtk = p1;
	}

	public int IndexOf(T item)
	{
		return Array.IndexOf(z0atk, item, 0, z0wtk);
	}

	public Span<T> z0urk()
	{
		return new Span<T>(z0atk, 0, z0wtk);
	}

	private object z0irk()
	{
		return null;
	}

	object ICollection.get_SyncRoot()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0irk
		return this.z0irk();
	}

	public void z0tek(zzz.z0ZzZzkuk<T> p0)
	{
		if (p0 == null || p0.z0wtk <= 0)
		{
			return;
		}
		if (z0wtk == 0)
		{
			if (z0atk.Length < p0.z0wtk)
			{
				z0atk = new T[p0.z0wtk];
			}
			Array.Copy(p0.z0atk, 0, z0atk, 0, p0.z0wtk);
			z0wtk = p0.z0wtk;
		}
		else
		{
			z0yrk(z0wtk + p0.z0wtk);
			Array.Copy(p0.z0atk, 0, z0atk, z0wtk, p0.z0wtk);
			z0wtk += p0.z0wtk;
		}
	}

	public T z0yek(int p0)
	{
		return z0atk[p0];
	}

	public int z0uek(T p0, IComparer<T> p1)
	{
		return z0drk(0, Count, p0, p1);
	}

	public void z0ork()
	{
		z0urk(0, Count);
	}

	internal void z0prk()
	{
		if (z0wtk == 0)
		{
			z0atk = z0qtk;
			return;
		}
		T[] array = new T[z0wtk];
		Array.Copy(z0atk, 0, array, 0, z0wtk);
		z0atk = array;
		z0gtk();
	}

	private IEnumerator z0mrk()
	{
		return new z0bpk(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0mrk
		return this.z0mrk();
	}

	public void z0nrk()
	{
		z0wtk = 0;
	}

	private object z0irk(int p0)
	{
		return this[p0];
	}

	object IList.get_Item(int p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0irk
		return this.z0irk(p0);
	}

	public void z0iek(zzz.z0ZzZzkuk<T> p0, int p1, int p2)
	{
		if (p0 != null && p0 != this && p1 >= 0 && p2 > 0 && p1 + p2 <= p0.z0wtk)
		{
			z0yrk(z0wtk + p2);
			Array.Copy(p0.z0atk, p1, z0atk, z0wtk, p2);
			z0wtk += p2;
		}
	}

	public zzz.z0ZzZzkuk<T> z0yrk(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (z0wtk - p0 < p1)
		{
			throw new ArgumentException("InvalidOffLen");
		}
		zzz.z0ZzZzkuk<T> z0ZzZzkuk2 = (zzz.z0ZzZzkuk<T>)MemberwiseClone();
		if (p1 == 0)
		{
			z0ZzZzkuk2.z0atk = z0qtk;
		}
		else
		{
			z0ZzZzkuk2.z0atk = new T[p1];
			Array.Copy(z0atk, p0, z0ZzZzkuk2.z0atk, 0, p1);
		}
		z0ZzZzkuk2.z0wtk = p1;
		return z0ZzZzkuk2;
	}

	public void z0oek(IComparer<T> p0)
	{
		z0bek(0, Count, p0);
	}

	private void z0yrk(int p0, object p1)
	{
		this[p0] = (T)p1;
	}

	void IList.set_Item(int p0, object p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yrk
		this.z0yrk(p0, p1);
	}

	private bool z0brk()
	{
		return false;
	}

	bool ICollection<T>.get_IsReadOnly()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0brk
		return this.z0brk();
	}

	public void z0vrk()
	{
		if (z0wtk > 0)
		{
			Array.Clear(z0atk, 0, z0wtk);
			z0atk = z0qtk;
			z0wtk = 0;
		}
	}

	public void z0ork(int p0)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("minCount=" + p0);
		}
		if (z0wtk <= p0)
		{
			z0yrk(p0);
			z0wtk = p0;
		}
	}

	public void z0pek(T p0)
	{
		if (z0wtk == z0atk.Length)
		{
			z0yrk(z0wtk + 1);
		}
		z0atk[z0wtk++] = p0;
	}

	public void z0mek(T p0)
	{
		z0atk[z0wtk++] = p0;
	}

	private IEnumerator<T> z0crk()
	{
		return new z0bpk(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0crk
		return this.z0crk();
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			RemoveAt(num);
			return true;
		}
		return false;
	}

	public void z0nek(zzz.z0ZzZzkuk<T> p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("list");
		}
		if (p0 != this)
		{
			p0.z0atk = new T[z0wtk];
			Array.Copy(z0atk, p0.z0atk, z0wtk);
			p0.z0wtk = z0wtk;
		}
	}

	public void z0bek(int p0, int p1, IComparer<T> p2)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("index,NeedNonNegNum");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("count,NeedNonNegNum");
		}
		if (z0wtk - p0 < p1)
		{
			throw new ArgumentException("InvalidOffLen");
		}
		Array.Sort(z0atk, p0, p1, p2);
	}

	public void AddRange(IEnumerable<T> collection)
	{
		if (collection is zzz.z0ZzZzkuk<T>)
		{
			zzz.z0ZzZzkuk<T> z0ZzZzkuk2 = (zzz.z0ZzZzkuk<T>)collection;
			if (z0ZzZzkuk2.z0wtk > 0)
			{
				z0tek(z0ZzZzkuk2);
			}
		}
		else if (collection is zzz.z0ZzZzyik<T>)
		{
			zzz.z0ZzZzyik<T> z0ZzZzyik2 = (zzz.z0ZzZzyik<T>)collection;
			if (z0ZzZzyik2.z0yek() is zzz.z0ZzZzkuk<T>)
			{
				zzz.z0ZzZzkuk<T> z0ZzZzkuk3 = (zzz.z0ZzZzkuk<T>)z0ZzZzyik2.z0yek();
				if (z0atk == z0qtk)
				{
					z0atk = new T[z0ZzZzyik2.Count];
					Array.Copy(z0ZzZzkuk3.z0atk, z0ZzZzyik2.z0uek(), z0atk, 0, z0ZzZzyik2.Count);
					z0wtk = z0ZzZzyik2.Count;
				}
				else
				{
					int count = z0ZzZzyik2.Count;
					z0yrk(z0wtk + count);
					Array.Copy(z0ZzZzkuk3.z0atk, z0ZzZzyik2.z0uek(), z0atk, z0wtk, count);
					z0wtk += count;
				}
			}
			else
			{
				IList<T> list = z0ZzZzyik2.z0yek();
				z0yrk(z0wtk + z0ZzZzyik2.Count);
				int num = z0ZzZzyik2.z0uek() + z0ZzZzyik2.Count;
				for (int i = z0ZzZzyik2.z0uek(); i < num; i++)
				{
					z0atk[z0wtk++] = list[i];
				}
			}
		}
		else if (collection is T[])
		{
			T[] array = (T[])collection;
			if (array.Length != 0)
			{
				if (z0wtk == 0)
				{
					if (z0atk.Length < array.Length)
					{
						z0atk = (T[])array.Clone();
					}
					else
					{
						Array.Copy(array, 0, z0atk, 0, array.Length);
					}
					z0wtk = array.Length;
				}
				else
				{
					z0yrk(z0wtk + array.Length);
					Array.Copy(array, 0, z0atk, z0wtk, array.Length);
					z0wtk += array.Length;
				}
			}
		}
		else
		{
			z0frk(z0wtk, collection);
		}
		z0gtk();
	}

	public void Add(T item)
	{
		if (z0wtk == z0atk.Length)
		{
			z0yrk(z0wtk + 1);
		}
		z0atk[z0wtk++] = item;
	}

	public IEnumerable<T> z0xrk()
	{
		if (z0atk.Length == z0wtk)
		{
			return z0atk;
		}
		return new z0xmk(z0atk, z0wtk);
	}

	private static bool z0urk(object p0)
	{
		if (!(p0 is T))
		{
			if (p0 == null)
			{
				return default(T) == null;
			}
			return false;
		}
		return true;
	}

	public z0ZzZzkuk(int p0)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("capacity,NeedNonNegNum");
		}
		if (p0 == 0)
		{
			z0atk = z0qtk;
		}
		else
		{
			z0atk = new T[p0];
		}
		z0gtk();
	}

	protected T2 z0vek<T2>(int p0) where T2 : T
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex=" + p0);
		}
		int num = z0wtk;
		for (int i = p0; i < num; i++)
		{
			if (z0atk[i] is T2)
			{
				return (T2)(object)z0atk[i];
			}
		}
		return default(T2);
	}

	public int z0cek(T p0)
	{
		if (z0wtk > 0)
		{
			T[] array = z0atk;
			for (int num = z0wtk - 1; num >= 0; num--)
			{
				if ((object)array[num] == (object)p0)
				{
					return num;
				}
			}
		}
		return -1;
	}

	public void z0urk(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("index,NeedNonNegNum");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("count,NeedNonNegNum");
		}
		if (z0wtk - p0 < p1)
		{
			throw new ArgumentException("InvalidOffLen");
		}
		Array.Reverse(z0atk, p0, p1);
	}

	private void z0yrk(Array p0, int p1)
	{
		if (p0 != null && p0.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported");
		}
		Array.Copy(z0atk, 0, p0, p1, z0wtk);
	}

	void ICollection.CopyTo(Array p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yrk
		this.z0yrk(p0, p1);
	}

	public int z0xek(T p0)
	{
		if (z0wtk == 0)
		{
			return -1;
		}
		return z0eek(p0, z0wtk - 1, z0wtk);
	}

	public void z0zek(T[] p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("items");
		}
		if (z0wtk > 0)
		{
			Array.Clear(z0atk, 0, z0wtk);
		}
		z0atk = p0;
		z0wtk = p0.Length;
		z0gtk();
	}

	public T z0lrk(int p0)
	{
		for (int num = z0wtk - 1; num >= 0; num--)
		{
			if (z0atk[num].GetHashCode() == p0)
			{
				return z0atk[num];
			}
		}
		return default(T);
	}

	public virtual void z0zrk()
	{
		if (z0wtk > 0)
		{
			T[] array = z0atk;
			for (int num = z0wtk - 1; num >= 0; num--)
			{
				((IDisposable)(object)array[num]).Dispose();
			}
			Array.Clear(array, 0, z0wtk);
			z0wtk = 0;
			z0atk = z0qtk;
		}
	}

	public T[] ToArray()
	{
		if (z0wtk == 0)
		{
			return z0qtk;
		}
		T[] array = new T[z0wtk];
		Array.Copy(z0atk, 0, array, 0, z0wtk);
		return array;
	}

	public void z0irk(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("index,NeedNonNegNum");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("count,NeedNonNegNum");
		}
		if (z0wtk - p0 < p1)
		{
			throw new ArgumentException("InvalidOffLen");
		}
		if (p1 > 0)
		{
			_ = z0wtk;
			z0wtk -= p1;
			if (p0 < z0wtk)
			{
				Array.Copy(z0atk, p0 + p1, z0atk, p0, z0wtk - p0);
			}
			Array.Clear(z0atk, z0wtk, p1);
		}
	}

	public T[] z0krk()
	{
		return z0atk;
	}

	private int z0irk(object p0)
	{
		if (z0urk(p0))
		{
			return IndexOf((T)p0);
		}
		return -1;
	}

	int IList.IndexOf(object p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0irk
		return this.z0irk(p0);
	}

	public static zzz.z0ZzZzkuk<T> z0jrk(T[] p0, int p1, int p2)
	{
		zzz.z0ZzZzkuk<T> z0ZzZzkuk2 = new zzz.z0ZzZzkuk<T>();
		z0ZzZzkuk2.z0atk = new T[p2];
		Array.Copy(p0, p1, z0ZzZzkuk2.z0atk, 0, p2);
		z0ZzZzkuk2.z0wtk = p2;
		return z0ZzZzkuk2;
	}

	public z0bpk z0ltk()
	{
		return new z0bpk(this);
	}

	public virtual bool Contains(T item)
	{
		if (item == null)
		{
			for (int i = 0; i < z0wtk; i++)
			{
				if (z0atk[i] == null)
				{
					return true;
				}
			}
			return false;
		}
		EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
		for (int j = 0; j < z0wtk; j++)
		{
			if (equalityComparer.Equals(z0atk[j], item))
			{
				return true;
			}
		}
		return false;
	}

	public void z0hrk(zzz.z0ZzZzkuk<T> p0)
	{
		if (p0 != null && p0 != this)
		{
			p0.z0atk = z0atk;
			p0.z0wtk = z0wtk;
		}
	}

	public void z0ktk()
	{
		if (z0atk.Length != 0)
		{
			Array.Clear(z0atk, 0, z0atk.Length);
			z0atk = z0qtk;
			z0wtk = 0;
		}
	}

	protected T z0grk()
	{
		if (z0wtk == 1)
		{
			return z0atk[0];
		}
		return default(T);
	}

	public void z0frk(int p0, IEnumerable<T> p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("collection");
		}
		if ((uint)p0 > (uint)z0wtk)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (p1 is ICollection<T> { Count: var count } collection)
		{
			if (count > 0)
			{
				z0yrk(z0wtk + count);
				if (p0 < z0wtk)
				{
					Array.Copy(z0atk, p0, z0atk, p0 + count, z0wtk - p0);
				}
				if (this == collection)
				{
					Array.Copy(z0atk, 0, z0atk, p0, p0);
					Array.Copy(z0atk, p0 + count, z0atk, p0 * 2, z0wtk - p0);
				}
				else if (collection is zzz.z0ZzZzkuk<T>)
				{
					Array.Copy(((zzz.z0ZzZzkuk<T>)collection).z0atk, 0, z0atk, p0, count);
				}
				else if (collection is T[])
				{
					Array.Copy((T[])collection, 0, z0atk, p0, count);
				}
				else
				{
					T[] array = new T[count];
					collection.CopyTo(array, 0);
					array.CopyTo(z0atk, p0);
				}
				z0wtk += count;
			}
			return;
		}
		using IEnumerator<T> enumerator = p1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Insert(p0++, enumerator.Current);
		}
	}

	private void z0urk(int p0, object p1)
	{
		Insert(p0, (T)p1);
	}

	void IList.Insert(int p0, object p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0urk
		this.z0urk(p0, p1);
	}

	private bool z0jtk()
	{
		return false;
	}

	bool IList.get_IsFixedSize()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0jtk
		return this.z0jtk();
	}

	public z0ZzZzkuk()
	{
		z0atk = z0qtk;
	}

	public zzz.z0ZzZzkuk<T> z0htk()
	{
		zzz.z0ZzZzkuk<T> z0ZzZzkuk2 = (zzz.z0ZzZzkuk<T>)MemberwiseClone();
		if (z0wtk > 0)
		{
			z0ZzZzkuk2.z0atk = new T[z0wtk];
			Array.Copy(z0atk, z0ZzZzkuk2.z0atk, z0wtk);
		}
		return z0ZzZzkuk2;
	}

	public int z0drk(int p0, int p1, T p2, IComparer<T> p3)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("index NeedNonNegNum");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("count NeedNonNegNum");
		}
		if (z0wtk - p0 < p1)
		{
			throw new ArgumentException("InvalidOffLen");
		}
		return Array.BinarySearch(z0atk, p0, p1, p2, p3);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Array.Copy(z0atk, 0, array, arrayIndex, z0wtk);
	}

	public T2 z0srk<T2>() where T2 : T
	{
		int num = z0wtk;
		for (int i = 0; i < num; i++)
		{
			if (z0atk[i] is T2)
			{
				return (T2)(object)z0atk[i];
			}
		}
		return default(T2);
	}

	public void z0ark(int p0, T p1)
	{
		z0atk[p0] = p1;
	}

	public void z0qrk(zzz.z0ZzZzkuk<T> p0, bool p1 = false)
	{
		if (p0 == null || p0 == this)
		{
			return;
		}
		if (p0.z0atk != null && p0.z0wtk > 0)
		{
			Array.Clear(p0.z0atk, 0, p0.z0wtk);
		}
		if (z0wtk == 0)
		{
			p0.z0atk = z0qtk;
			p0.z0wtk = 0;
			return;
		}
		if (p1 && z0wtk != z0atk.Length)
		{
			p0.z0atk = new T[z0wtk];
			Array.Copy(z0atk, p0.z0atk, z0wtk);
			p0.z0wtk = z0wtk;
		}
		else
		{
			p0.z0atk = z0atk;
			p0.z0wtk = z0wtk;
		}
		z0atk = z0qtk;
		z0wtk = 0;
	}

	private void z0ork(object p0)
	{
		if (z0urk(p0))
		{
			Remove((T)p0);
		}
	}

	void IList.Remove(object p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0ork
		this.z0ork(p0);
	}

	public void z0gtk()
	{
	}

	public void Insert(int index, T item)
	{
		if ((uint)index > (uint)z0wtk)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (z0wtk == z0atk.Length)
		{
			z0yrk(z0wtk + 1);
		}
		if (index < z0wtk)
		{
			Array.Copy(z0atk, index, z0atk, index + 1, z0wtk - index);
		}
		z0atk[index] = item;
		z0wtk++;
	}

	public T[] z0wrk(int p0, int p1)
	{
		if (p0 >= 0 && p1 > 0 && p0 + p1 <= z0wtk)
		{
			T[] array = new T[p1];
			Array.Copy(z0atk, p0, array, 0, p1);
			return array;
		}
		return null;
	}

	public int z0erk(T p0, int p1, int p2)
	{
		if (p1 > z0wtk)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (p2 < 0 || p1 > z0wtk - p2)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return Array.IndexOf(z0atk, p0, p1, p2);
	}

	private bool z0ftk()
	{
		return false;
	}

	bool IList.get_IsReadOnly()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0ftk
		return this.z0ftk();
	}

	public z0ZzZzkuk(T[] p0, bool p1)
	{
		if (p0 != null && p0.Length != 0)
		{
			z0wtk = p0.Length;
			if (p1)
			{
				z0atk = p0;
			}
			else
			{
				z0atk = (T[])p0.Clone();
			}
		}
		z0gtk();
	}

	public void Clear()
	{
		if (z0wtk > 0)
		{
			Array.Clear(z0atk, 0, z0wtk);
			z0wtk = 0;
		}
	}

	private bool z0prk(object p0)
	{
		if (z0urk(p0))
		{
			return Contains((T)p0);
		}
		return false;
	}

	bool IList.Contains(object p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0prk
		return this.z0prk(p0);
	}

	public int z0rrk(T p0, int p1)
	{
		if (p1 > z0wtk)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return Array.IndexOf(z0atk, p0, p1, z0wtk - p1);
	}

	internal void z0yrk(bool p0)
	{
		if (z0atk.Length != 0)
		{
			zzz.z0ZzZzgik<T[]>.z0iek.z0tek(z0atk);
			if (p0 || z0wtk == 0)
			{
				z0wtk = 0;
				z0atk = z0qtk;
			}
			else
			{
				T[] array = new T[z0wtk];
				Array.Copy(z0atk, 0, array, 0, z0wtk);
				z0atk = array;
			}
		}
	}

	public void z0dtk()
	{
		z0atk = z0qtk;
		z0wtk = 0;
	}

	public void z0trk(T[] p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (z0atk == z0qtk)
		{
			z0atk = (T[])p0.Clone();
			z0wtk = p0.Length;
			return;
		}
		int num = p0.Length;
		z0yrk(z0wtk + num);
		Array.Copy(p0, 0, z0atk, z0wtk, num);
		z0wtk += num;
	}
}
