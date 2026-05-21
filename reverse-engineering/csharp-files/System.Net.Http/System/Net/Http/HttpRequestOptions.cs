using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http;

public sealed class HttpRequestOptions : IDictionary<string, object?>, ICollection<KeyValuePair<string, object?>>, IEnumerable<KeyValuePair<string, object?>>, IEnumerable
{
	private Dictionary<string, object?> Options { get; } = new Dictionary<string, object>();

	object? IDictionary<string, object>.this[string P_0]
	{
		get
		{
			return Options[P_0];
		}
		set
		{
			Options[text] = obj;
		}
	}

	ICollection<string> IDictionary<string, object>.Keys => Options.Keys;

	ICollection<object?> IDictionary<string, object>.Values => Options.Values;

	int ICollection<KeyValuePair<string, object>>.Count => Options.Count;

	bool ICollection<KeyValuePair<string, object>>.IsReadOnly => ((ICollection<KeyValuePair<string, object>>)Options).IsReadOnly;

	void IDictionary<string, object>.Add(string P_0, object P_1)
	{
		Options.Add(P_0, P_1);
	}

	void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> P_0)
	{
		((ICollection<KeyValuePair<string, object>>)Options).Add(P_0);
	}

	void ICollection<KeyValuePair<string, object>>.Clear()
	{
		Options.Clear();
	}

	bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> P_0)
	{
		return ((ICollection<KeyValuePair<string, object>>)Options).Contains(P_0);
	}

	bool IDictionary<string, object>.ContainsKey(string P_0)
	{
		return Options.ContainsKey(P_0);
	}

	void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] P_0, int P_1)
	{
		((ICollection<KeyValuePair<string, object>>)Options).CopyTo(P_0, P_1);
	}

	IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
	{
		return Options.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)Options).GetEnumerator();
	}

	bool IDictionary<string, object>.Remove(string P_0)
	{
		return Options.Remove(P_0);
	}

	bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> P_0)
	{
		return ((ICollection<KeyValuePair<string, object>>)Options).Remove(P_0);
	}

	bool IDictionary<string, object>.TryGetValue(string P_0, out object P_1)
	{
		return Options.TryGetValue(P_0, out P_1);
	}

	public bool TryGetValue<TValue>(HttpRequestOptionsKey<TValue> P_0, [MaybeNullWhen(false)] out TValue P_1)
	{
		if (Options.TryGetValue(P_0.Key, out object obj) && obj is TValue val)
		{
			P_1 = val;
			return true;
		}
		P_1 = default(TValue);
		return false;
	}
}
