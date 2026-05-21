using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace zzz;

internal abstract class z0ZzZzegj<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : z0ZzZzfsj
{
	[CompilerGenerated]
	private sealed class z0jok : IEnumerator<T>, IEnumerator, IDisposable
	{
		private int z0uek;

		private int z0iek;

		public zzz.z0ZzZzegj<T> z0oek;

		private int z0pek;

		private T z0mek;

		[DebuggerHidden]
		private void z0rek()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0rek
			this.z0rek();
		}

		[DebuggerHidden]
		public z0jok(int p0)
		{
			z0pek = p0;
		}

		[DebuggerHidden]
		private void z0tek()
		{
			z0pek = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0tek
			this.z0tek();
		}

		private bool MoveNext()
		{
			int num = z0pek;
			zzz.z0ZzZzegj<T> z0ZzZzegj2 = z0oek;
			switch (num)
			{
			default:
				return false;
			case 0:
				z0pek = -1;
				z0iek = z0ZzZzegj2.Count;
				z0uek = 0;
				goto IL_00e9;
			case 1:
				z0pek = -1;
				goto IL_00d7;
			case 2:
				{
					z0pek = -1;
					goto IL_00d7;
				}
				IL_00e9:
				if (z0uek < z0iek)
				{
					if (z0uek < z0ZzZzegj2.z0yek.Count)
					{
						z0mek = z0ZzZzegj2.z0yek[z0uek];
						z0pek = 1;
						return true;
					}
					if (z0ZzZzegj2.z0uek != null && z0ZzZzegj2.z0uek.MoveNext())
					{
						object current = z0ZzZzegj2.z0uek.Current;
						T val = z0ZzZzegj2.z0aj(current);
						z0ZzZzegj2.z0tek--;
						z0ZzZzegj2.z0yek.Add(val);
						z0mek = val;
						z0pek = 2;
						return true;
					}
					goto IL_00d7;
				}
				if (z0ZzZzegj2.z0uek != null)
				{
					z0ZzZzegj2.z0uek.Dispose();
					z0ZzZzegj2.z0uek = null;
				}
				return false;
				IL_00d7:
				z0uek++;
				goto IL_00e9;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private object z0yek()
		{
			return z0mek;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0yek
			return this.z0yek();
		}

		[DebuggerHidden]
		private T z0eek()
		{
			return z0mek;
		}

		T IEnumerator<T>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in z0eek
			return this.z0eek();
		}
	}

	private int z0tek;

	private readonly List<T> z0yek = new List<T>();

	private IEnumerator<object> z0uek;

	public bool IsReadOnly => false;

	public int Count => z0tek + z0yek.Count;

	public T this[int index]
	{
		get
		{
			z0eek(index);
			return z0yek[index];
		}
		set
		{
			z0eek(index);
			z0yek[index] = value;
		}
	}

	private void z0eek(int p0)
	{
		using IEnumerator<T> enumerator = GetEnumerator();
		while (z0yek.Count <= p0 && enumerator.MoveNext())
		{
		}
	}

	private void z0eek()
	{
		z0eek(2147483647);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		z0eek();
		z0yek.CopyTo(array, arrayIndex);
	}

	private IEnumerator z0rek()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}

	public void Add(T item)
	{
		z0eek();
		z0yek.Add(item);
	}

	public int IndexOf(T item)
	{
		z0eek();
		return z0yek.IndexOf(item);
	}

	protected z0ZzZzegj(IEnumerator<object> p0, int p1)
	{
		z0tek = p1;
		z0uek = p0;
	}

	public void Insert(int index, T item)
	{
		if (index >= z0yek.Count)
		{
			z0eek();
		}
		z0yek.Insert(index, item);
	}

	protected z0ZzZzegj()
	{
		z0uek = new List<object>().GetEnumerator();
	}

	public void RemoveAt(int index)
	{
		z0eek(index);
		z0yek.RemoveAt(index);
	}

	public bool Contains(T item)
	{
		z0eek();
		return z0yek.Contains(item);
	}

	public void Clear()
	{
		z0yek.Clear();
		if (z0uek != null)
		{
			z0uek.Dispose();
			z0uek = null;
		}
	}

	protected abstract T z0aj(object p0);

	[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__20))]
	public IEnumerator<T> GetEnumerator()
	{
		//yield-return decompiler failed: Could not find currentField
		return new z0jok(0)
		{
			z0oek = this
		};
	}

	public bool Remove(T item)
	{
		z0eek();
		return z0yek.Remove(item);
	}
}
