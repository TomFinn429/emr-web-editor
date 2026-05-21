namespace System.Xml;

public class NameTable : XmlNameTable
{
	private sealed class Entry
	{
		internal string str;

		internal int hashCode;

		internal Entry next;

		internal Entry(string P_0, int P_1, Entry P_2)
		{
			str = P_0;
			hashCode = P_1;
			next = P_2;
		}
	}

	private Entry[] _entries;

	private int _count;

	private int _mask;

	public NameTable()
	{
		_mask = 31;
		_entries = new Entry[_mask + 1];
	}

	public override string Add(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		if (P_0.Length == 0)
		{
			return string.Empty;
		}
		int num = ComputeHash32(P_0);
		for (Entry entry = _entries[num & _mask]; entry != null; entry = entry.next)
		{
			if (entry.hashCode == num && entry.str.Equals(P_0))
			{
				return entry.str;
			}
		}
		return AddEntry(P_0, num);
	}

	public override string Add(char[] P_0, int P_1, int P_2)
	{
		if (P_2 == 0)
		{
			return string.Empty;
		}
		if (P_1 >= P_0.Length || P_1 < 0 || (long)P_1 + (long)P_2 > P_0.Length)
		{
			throw new IndexOutOfRangeException();
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("len");
		}
		int hashCode = string.GetHashCode(P_0.AsSpan(P_1, P_2));
		for (Entry entry = _entries[hashCode & _mask]; entry != null; entry = entry.next)
		{
			if (entry.hashCode == hashCode && entry.str.AsSpan().SequenceEqual(P_0.AsSpan(P_1, P_2)))
			{
				return entry.str;
			}
		}
		return AddEntry(new string(P_0, P_1, P_2), hashCode);
	}

	public override string? Get(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (P_0.Length == 0)
		{
			return string.Empty;
		}
		int num = ComputeHash32(P_0);
		for (Entry entry = _entries[num & _mask]; entry != null; entry = entry.next)
		{
			if (entry.hashCode == num && entry.str.Equals(P_0))
			{
				return entry.str;
			}
		}
		return null;
	}

	internal string GetOrAddEntry(string P_0, int P_1)
	{
		for (Entry entry = _entries[P_1 & _mask]; entry != null; entry = entry.next)
		{
			if (entry.hashCode == P_1 && entry.str.Equals(P_0))
			{
				return entry.str;
			}
		}
		return AddEntry(P_0, P_1);
	}

	internal static int ComputeHash32(string P_0)
	{
		return string.GetHashCode(P_0.AsSpan());
	}

	private string AddEntry(string P_0, int P_1)
	{
		int num = P_1 & _mask;
		Entry entry = new Entry(P_0, P_1, _entries[num]);
		_entries[num] = entry;
		if (_count++ == _mask)
		{
			Grow();
		}
		return entry.str;
	}

	private void Grow()
	{
		int num = _mask * 2 + 1;
		Entry[] entries = _entries;
		Entry[] array = new Entry[num + 1];
		for (int i = 0; i < entries.Length; i++)
		{
			Entry entry = entries[i];
			while (entry != null)
			{
				int num2 = entry.hashCode & num;
				Entry next = entry.next;
				entry.next = array[num2];
				array[num2] = entry;
				entry = next;
			}
		}
		_entries = array;
		_mask = num;
	}
}
