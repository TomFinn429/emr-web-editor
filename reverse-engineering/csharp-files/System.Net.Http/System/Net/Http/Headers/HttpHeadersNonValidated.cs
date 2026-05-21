using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Net.Http.Headers;

[DefaultMember("Item")]
public readonly struct HttpHeadersNonValidated : IReadOnlyDictionary<string, HeaderStringValues>, IEnumerable<KeyValuePair<string, HeaderStringValues>>, IEnumerable, IReadOnlyCollection<KeyValuePair<string, HeaderStringValues>>
{
	public struct Enumerator : IEnumerator<KeyValuePair<string, HeaderStringValues>>, IEnumerator, IDisposable
	{
		private readonly HeaderEntry[] _entries;

		private readonly int _numberOfEntries;

		private int _index;

		private KeyValuePair<string, HeaderStringValues> _current;

		public KeyValuePair<string, HeaderStringValues> Current => _current;

		object IEnumerator.Current => _current;

		internal Enumerator(HeaderEntry[] P_0, int P_1)
		{
			_entries = P_0;
			_numberOfEntries = P_1;
			_index = 0;
			_current = default(KeyValuePair<string, HeaderStringValues>);
		}

		public bool MoveNext()
		{
			int index = _index;
			HeaderEntry[] entries = _entries;
			if (entries != null && index < _numberOfEntries && (uint)index < (uint)entries.Length)
			{
				HeaderEntry headerEntry = entries[index];
				_index++;
				HttpHeaders.GetStoreValuesAsStringOrStringArray(headerEntry.Key, headerEntry.Value, out var text, out var array);
				_current = new KeyValuePair<string, HeaderStringValues>(headerEntry.Key.Name, (text != null) ? new HeaderStringValues(headerEntry.Key, text) : new HeaderStringValues(headerEntry.Key, array));
				return true;
			}
			_current = default(KeyValuePair<string, HeaderStringValues>);
			return false;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private readonly HttpHeaders _headers;

	public int Count => _headers?.Count ?? 0;

	internal HttpHeadersNonValidated(HttpHeaders P_0)
	{
		_headers = P_0;
	}

	public bool TryGetValues(string P_0, out HeaderStringValues P_1)
	{
		HttpHeaders headers = _headers;
		if (headers != null && headers.TryGetHeaderDescriptor(P_0, out var headerDescriptor) && headers.TryGetHeaderValue(headerDescriptor, out var obj))
		{
			HttpHeaders.GetStoreValuesAsStringOrStringArray(headerDescriptor, obj, out var text, out var array);
			P_1 = ((text != null) ? new HeaderStringValues(headerDescriptor, text) : new HeaderStringValues(headerDescriptor, array));
			return true;
		}
		P_1 = default(HeaderStringValues);
		return false;
	}

	bool IReadOnlyDictionary<string, HeaderStringValues>.TryGetValue(string P_0, out HeaderStringValues P_1)
	{
		return TryGetValues(P_0, out P_1);
	}

	public Enumerator GetEnumerator()
	{
		HttpHeaders headers = _headers;
		if (headers != null)
		{
			HeaderEntry[] entriesArray = headers.GetEntriesArray();
			if (entriesArray != null)
			{
				return new Enumerator(entriesArray, headers.Count);
			}
		}
		return default(Enumerator);
	}

	IEnumerator<KeyValuePair<string, HeaderStringValues>> IEnumerable<KeyValuePair<string, HeaderStringValues>>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
