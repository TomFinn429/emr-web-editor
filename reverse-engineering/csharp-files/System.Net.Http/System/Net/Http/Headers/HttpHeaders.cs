using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Net.Http.Headers;

public abstract class HttpHeaders : IEnumerable<KeyValuePair<string, IEnumerable<string>>>, IEnumerable
{
	internal sealed class InvalidValue
	{
		private readonly string _value;

		public InvalidValue(string P_0)
		{
			_value = P_0;
		}

		public override string ToString()
		{
			return _value;
		}
	}

	internal sealed class HeaderStoreItemInfo
	{
		internal object RawValue;

		internal object ParsedAndInvalidValues;

		public bool IsEmpty
		{
			get
			{
				if (RawValue == null)
				{
					return ParsedAndInvalidValues == null;
				}
				return false;
			}
		}

		internal HeaderStoreItemInfo()
		{
		}

		public bool CanAddParsedValue(HttpHeaderParser P_0)
		{
			if (!P_0.SupportsMultipleValues)
			{
				return ParsedAndInvalidValues == null;
			}
			return true;
		}

		public object GetSingleParsedValue()
		{
			if (ParsedAndInvalidValues != null)
			{
				if (ParsedAndInvalidValues is List<object> list)
				{
					foreach (object item in list)
					{
						if (!(item is InvalidValue))
						{
							return item;
						}
					}
				}
				else if (!(ParsedAndInvalidValues is InvalidValue))
				{
					return ParsedAndInvalidValues;
				}
			}
			return null;
		}
	}

	private object _headerStore;

	private int _count;

	private readonly HttpHeaderType _allowedHeaderTypes;

	private readonly HttpHeaderType _treatAsCustomHeaderTypes;

	private static bool s_dictionaryGetValueRefOrAddDefaultExistsDummy;

	public HttpHeadersNonValidated NonValidated => new HttpHeadersNonValidated(this);

	internal int Count => _count;

	private bool EntriesAreLiveView => _headerStore is HeaderEntry[];

	internal HttpHeaders(HttpHeaderType P_0, HttpHeaderType P_1)
	{
		_allowedHeaderTypes = P_0 & ~HttpHeaderType.NonTrailing;
		_treatAsCustomHeaderTypes = P_1 & ~HttpHeaderType.NonTrailing;
	}

	public bool TryAddWithoutValidation(string P_0, string? P_1)
	{
		if (TryGetHeaderDescriptor(P_0, out var headerDescriptor))
		{
			return TryAddWithoutValidation(headerDescriptor, P_1);
		}
		return false;
	}

	internal bool TryAddWithoutValidation(HeaderDescriptor P_0, string P_1)
	{
		if (P_1 == null)
		{
			P_1 = string.Empty;
		}
		ref object valueRefOrAddDefault = ref GetValueRefOrAddDefault(P_0);
		object obj = valueRefOrAddDefault;
		if (obj == null)
		{
			valueRefOrAddDefault = P_1;
		}
		else
		{
			HeaderStoreItemInfo headerStoreItemInfo = obj as HeaderStoreItemInfo;
			if (headerStoreItemInfo == null)
			{
				HeaderStoreItemInfo obj2 = new HeaderStoreItemInfo
				{
					RawValue = obj
				};
				headerStoreItemInfo = obj2;
				valueRefOrAddDefault = obj2;
			}
			AddRawValue(headerStoreItemInfo, P_1);
		}
		return true;
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[512];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		ReadOnlySpan<HeaderEntry> entries = GetEntries();
		for (int i = 0; i < entries.Length; i++)
		{
			HeaderEntry headerEntry = entries[i];
			valueStringBuilder.Append(headerEntry.Key.Name);
			valueStringBuilder.Append(": ");
			GetStoreValuesAsStringOrStringArray(headerEntry.Key, headerEntry.Value, out var text, out var array);
			if (text != null)
			{
				valueStringBuilder.Append(text);
			}
			else
			{
				HttpHeaderParser parser = headerEntry.Key.Parser;
				string text2 = ((parser != null && parser.SupportsMultipleValues) ? parser.Separator : ", ");
				valueStringBuilder.Append(array[0]);
				for (int j = 1; j < array.Length; j++)
				{
					valueStringBuilder.Append(text2);
					valueStringBuilder.Append(array[j]);
				}
			}
			valueStringBuilder.Append("\n");
		}
		return valueStringBuilder.ToString();
	}

	public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
	{
		if (_count != 0)
		{
			return GetEnumeratorCore();
		}
		return ((IEnumerable<KeyValuePair<string, IEnumerable<string>>>)Array.Empty<KeyValuePair<string, IEnumerable<string>>>()).GetEnumerator();
	}

	private IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumeratorCore()
	{
		HeaderEntry[] entries = GetEntriesArray();
		for (int i = 0; i < _count; i++)
		{
			HeaderEntry headerEntry = entries[i];
			HeaderStoreItemInfo headerStoreItemInfo = headerEntry.Value as HeaderStoreItemInfo;
			if (headerStoreItemInfo == null)
			{
				headerStoreItemInfo = new HeaderStoreItemInfo
				{
					RawValue = headerEntry.Value
				};
				if (EntriesAreLiveView)
				{
					entries[i].Value = headerStoreItemInfo;
				}
				else
				{
					((Dictionary<HeaderDescriptor, object>)_headerStore)[headerEntry.Key] = headerStoreItemInfo;
				}
			}
			ParseRawHeaderValues(headerEntry.Key, headerStoreItemInfo);
			string[] storeValuesAsStringArray = GetStoreValuesAsStringArray(headerEntry.Key, headerStoreItemInfo);
			yield return new KeyValuePair<string, IEnumerable<string>>(headerEntry.Key.Name, storeValuesAsStringArray);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal void AddParsedValue(HeaderDescriptor P_0, object P_1)
	{
		HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(P_0);
		AddParsedValue(orCreateHeaderInfo, P_1);
	}

	internal void SetParsedValue(HeaderDescriptor P_0, object P_1)
	{
		HeaderStoreItemInfo orCreateHeaderInfo = GetOrCreateHeaderInfo(P_0);
		orCreateHeaderInfo.ParsedAndInvalidValues = null;
		orCreateHeaderInfo.RawValue = null;
		AddParsedValue(orCreateHeaderInfo, P_1);
	}

	internal bool RemoveParsedValue(HeaderDescriptor P_0, object P_1)
	{
		if (TryGetAndParseHeaderInfo(P_0, out var headerStoreItemInfo))
		{
			object parsedAndInvalidValues = headerStoreItemInfo.ParsedAndInvalidValues;
			if (parsedAndInvalidValues == null)
			{
				return false;
			}
			bool result = false;
			IEqualityComparer comparer = P_0.Parser.Comparer;
			if (!(parsedAndInvalidValues is List<object> list))
			{
				if (!(parsedAndInvalidValues is InvalidValue) && AreEqual(P_1, parsedAndInvalidValues, comparer))
				{
					headerStoreItemInfo.ParsedAndInvalidValues = null;
					result = true;
				}
			}
			else
			{
				foreach (object item in list)
				{
					if (!(item is InvalidValue) && AreEqual(P_1, item, comparer))
					{
						result = list.Remove(item);
						break;
					}
				}
				if (list.Count == 0)
				{
					headerStoreItemInfo.ParsedAndInvalidValues = null;
				}
			}
			if (headerStoreItemInfo.IsEmpty)
			{
				bool flag = Remove(P_0);
			}
			return result;
		}
		return false;
	}

	internal bool ContainsParsedValue(HeaderDescriptor P_0, object P_1)
	{
		if (TryGetAndParseHeaderInfo(P_0, out var headerStoreItemInfo))
		{
			object parsedAndInvalidValues = headerStoreItemInfo.ParsedAndInvalidValues;
			if (parsedAndInvalidValues == null)
			{
				return false;
			}
			List<object> list = parsedAndInvalidValues as List<object>;
			IEqualityComparer comparer = P_0.Parser.Comparer;
			if (list != null)
			{
				foreach (object item in list)
				{
					if (!(item is InvalidValue) && AreEqual(P_1, item, comparer))
					{
						return true;
					}
				}
				return false;
			}
			if (!(parsedAndInvalidValues is InvalidValue))
			{
				return AreEqual(P_1, parsedAndInvalidValues, comparer);
			}
		}
		return false;
	}

	internal virtual void AddHeaders(HttpHeaders P_0)
	{
		if (_count == 0 && P_0._headerStore is HeaderEntry[] array)
		{
			_count = P_0._count;
			HeaderEntry[] array2 = _headerStore as HeaderEntry[];
			if (array2 == null || array2.Length < _count)
			{
				array2 = (HeaderEntry[])(_headerStore = new HeaderEntry[array.Length]);
			}
			for (int i = 0; i < _count && i < array.Length; i++)
			{
				HeaderEntry headerEntry = array[i];
				if (headerEntry.Value is HeaderStoreItemInfo headerStoreItemInfo)
				{
					headerEntry.Value = CloneHeaderInfo(headerEntry.Key, headerStoreItemInfo);
				}
				array2[i] = headerEntry;
			}
			return;
		}
		ReadOnlySpan<HeaderEntry> entries = P_0.GetEntries();
		for (int j = 0; j < entries.Length; j++)
		{
			HeaderEntry headerEntry2 = entries[j];
			ref object valueRefOrAddDefault = ref GetValueRefOrAddDefault(headerEntry2.Key);
			if (valueRefOrAddDefault == null)
			{
				object value = headerEntry2.Value;
				if (value is HeaderStoreItemInfo headerStoreItemInfo2)
				{
					valueRefOrAddDefault = CloneHeaderInfo(headerEntry2.Key, headerStoreItemInfo2);
				}
				else
				{
					valueRefOrAddDefault = value;
				}
			}
		}
	}

	private static HeaderStoreItemInfo CloneHeaderInfo(HeaderDescriptor P_0, HeaderStoreItemInfo P_1)
	{
		lock (P_1)
		{
			HeaderStoreItemInfo headerStoreItemInfo = new HeaderStoreItemInfo
			{
				RawValue = CloneStringHeaderInfoValues(P_1.RawValue)
			};
			if (P_0.Parser == null)
			{
				headerStoreItemInfo.ParsedAndInvalidValues = CloneStringHeaderInfoValues(P_1.ParsedAndInvalidValues);
			}
			else if (P_1.ParsedAndInvalidValues != null)
			{
				if (!(P_1.ParsedAndInvalidValues is List<object> list))
				{
					CloneAndAddValue(headerStoreItemInfo, P_1.ParsedAndInvalidValues);
				}
				else
				{
					foreach (object item in list)
					{
						CloneAndAddValue(headerStoreItemInfo, item);
					}
				}
			}
			return headerStoreItemInfo;
		}
	}

	private static void CloneAndAddValue(HeaderStoreItemInfo P_0, object P_1)
	{
		if (P_1 is ICloneable cloneable)
		{
			AddParsedValue(P_0, cloneable.Clone());
		}
		else
		{
			AddParsedValue(P_0, P_1);
		}
	}

	[return: NotNullIfNotNull("source")]
	private static object CloneStringHeaderInfoValues(object P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (!(P_0 is List<object> list))
		{
			return P_0;
		}
		return new List<object>(list);
	}

	private HeaderStoreItemInfo GetOrCreateHeaderInfo(HeaderDescriptor P_0)
	{
		if (TryGetAndParseHeaderInfo(P_0, out var result))
		{
			return result;
		}
		return CreateAndAddHeaderToStore(P_0);
	}

	private HeaderStoreItemInfo CreateAndAddHeaderToStore(HeaderDescriptor P_0)
	{
		HeaderStoreItemInfo headerStoreItemInfo = new HeaderStoreItemInfo();
		AddEntryToStore(new HeaderEntry(P_0, headerStoreItemInfo));
		return headerStoreItemInfo;
	}

	internal bool TryGetHeaderValue(HeaderDescriptor P_0, [NotNullWhen(true)] out object P_1)
	{
		ref object valueRefOrNullRef = ref GetValueRefOrNullRef(P_0);
		if (Unsafe.IsNullRef(ref valueRefOrNullRef))
		{
			P_1 = null;
			return false;
		}
		P_1 = valueRefOrNullRef;
		return true;
	}

	private bool TryGetAndParseHeaderInfo(HeaderDescriptor P_0, [NotNullWhen(true)] out HeaderStoreItemInfo P_1)
	{
		ref object valueRefOrNullRef = ref GetValueRefOrNullRef(P_0);
		if (!Unsafe.IsNullRef(ref valueRefOrNullRef))
		{
			object obj = valueRefOrNullRef;
			if (obj is HeaderStoreItemInfo headerStoreItemInfo)
			{
				P_1 = headerStoreItemInfo;
			}
			else
			{
				HeaderStoreItemInfo obj2 = new HeaderStoreItemInfo
				{
					RawValue = obj
				};
				HeaderStoreItemInfo headerStoreItemInfo2 = obj2;
				P_1 = obj2;
				valueRefOrNullRef = headerStoreItemInfo2;
			}
			ParseRawHeaderValues(P_0, P_1);
			return true;
		}
		P_1 = null;
		return false;
	}

	private static void ParseRawHeaderValues(HeaderDescriptor P_0, HeaderStoreItemInfo P_1)
	{
		lock (P_1)
		{
			if (P_1.RawValue == null)
			{
				return;
			}
			if (P_1.RawValue is List<string> list)
			{
				foreach (string item in list)
				{
					ParseSingleRawHeaderValue(P_1, P_0, item);
				}
			}
			else
			{
				string text = P_1.RawValue as string;
				ParseSingleRawHeaderValue(P_1, P_0, text);
			}
			P_1.RawValue = null;
		}
	}

	private static void ParseSingleRawHeaderValue(HeaderStoreItemInfo P_0, HeaderDescriptor P_1, string P_2)
	{
		if (P_1.Parser == null)
		{
			if (HttpRuleParser.ContainsNewLine(P_2))
			{
				if (NetEventSource.Log.IsEnabled())
				{
				}
				AddInvalidValue(P_0, P_2);
			}
			else
			{
				AddParsedValue(P_0, P_2);
			}
		}
		else if (!TryParseAndAddRawHeaderValue(P_1, P_0, P_2, true) && !NetEventSource.Log.IsEnabled())
		{
		}
	}

	private static bool TryParseAndAddRawHeaderValue(HeaderDescriptor P_0, HeaderStoreItemInfo P_1, string P_2, bool P_3)
	{
		if (!P_1.CanAddParsedValue(P_0.Parser))
		{
			if (P_3)
			{
				AddInvalidValue(P_1, P_2 ?? string.Empty);
			}
			return false;
		}
		int num = 0;
		if (P_0.Parser.TryParseValue(P_2, P_1.ParsedAndInvalidValues, ref num, out var obj))
		{
			if (P_2 == null || num == P_2.Length)
			{
				if (obj != null)
				{
					AddParsedValue(P_1, obj);
				}
				else if (P_3 && P_1.ParsedAndInvalidValues == null)
				{
					AddInvalidValue(P_1, P_2 ?? string.Empty);
				}
				return true;
			}
			List<object> list = new List<object>();
			if (obj != null)
			{
				list.Add(obj);
			}
			while (num < P_2.Length)
			{
				if (P_0.Parser.TryParseValue(P_2, P_1.ParsedAndInvalidValues, ref num, out obj))
				{
					if (obj != null)
					{
						list.Add(obj);
					}
					continue;
				}
				if (P_3)
				{
					AddInvalidValue(P_1, P_2);
				}
				return false;
			}
			foreach (object item in list)
			{
				AddParsedValue(P_1, item);
			}
			if (list.Count == 0 && P_3 && P_1.ParsedAndInvalidValues == null)
			{
				AddInvalidValue(P_1, P_2);
			}
			return true;
		}
		if (P_3)
		{
			AddInvalidValue(P_1, P_2 ?? string.Empty);
		}
		return false;
	}

	private static void AddParsedValue(HeaderStoreItemInfo P_0, object P_1)
	{
		AddValueToStoreValue(P_1, ref P_0.ParsedAndInvalidValues);
	}

	private static void AddInvalidValue(HeaderStoreItemInfo P_0, string P_1)
	{
		AddValueToStoreValue((object)new InvalidValue(P_1), ref P_0.ParsedAndInvalidValues);
	}

	private static void AddRawValue(HeaderStoreItemInfo P_0, string P_1)
	{
		AddValueToStoreValue(P_1, ref P_0.RawValue);
	}

	private static void AddValueToStoreValue<T>(T P_0, ref object P_1) where T : class
	{
		if (P_1 == null)
		{
			P_1 = P_0;
			return;
		}
		List<T> list = P_1 as List<T>;
		if (list == null)
		{
			list = new List<T>(2);
			list.Add((T)P_1);
			P_1 = list;
		}
		list.Add(P_0);
	}

	internal object GetSingleParsedValue(HeaderDescriptor P_0)
	{
		if (!TryGetAndParseHeaderInfo(P_0, out var headerStoreItemInfo))
		{
			return null;
		}
		return headerStoreItemInfo.GetSingleParsedValue();
	}

	internal bool TryGetHeaderDescriptor(string P_0, out HeaderDescriptor P_1)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			P_1 = default(HeaderDescriptor);
			return false;
		}
		if (HeaderDescriptor.TryGet(P_0, out P_1))
		{
			HttpHeaderType headerType = P_1.HeaderType;
			if ((headerType & _allowedHeaderTypes) != HttpHeaderType.None)
			{
				return true;
			}
			if ((headerType & _treatAsCustomHeaderTypes) != HttpHeaderType.None)
			{
				P_1 = P_1.AsCustomHeader();
				return true;
			}
		}
		return false;
	}

	internal static void CheckContainsNewLine(string P_0)
	{
		if (P_0 == null || !HttpRuleParser.ContainsNewLine(P_0))
		{
			return;
		}
		throw new FormatException("net_http_headers_no_newlines");
	}

	internal static string[] GetStoreValuesAsStringArray(HeaderDescriptor P_0, HeaderStoreItemInfo P_1)
	{
		GetStoreValuesAsStringOrStringArray(P_0, P_1, out var text, out var array);
		return array ?? new string[1] { text };
	}

	internal static void GetStoreValuesAsStringOrStringArray(HeaderDescriptor P_0, object P_1, out string P_2, out string[] P_3)
	{
		if (!(P_1 is HeaderStoreItemInfo headerStoreItemInfo))
		{
			P_2 = (string)P_1;
			P_3 = null;
			return;
		}
		lock (headerStoreItemInfo)
		{
			int valueCount = GetValueCount(headerStoreItemInfo);
			P_2 = null;
			Span<string> span;
			if (valueCount == 1)
			{
				P_3 = null;
				span = new Span<string>(ref P_2);
			}
			else
			{
				span = (P_3 = new string[valueCount]);
			}
			int num = 0;
			ReadStoreValues<object>(span, headerStoreItemInfo.ParsedAndInvalidValues, P_0.Parser, ref num);
			ReadStoreValues<string>(span, headerStoreItemInfo.RawValue, null, ref num);
		}
	}

	private static int GetValueCount(HeaderStoreItemInfo P_0)
	{
		return Count<object>(P_0.ParsedAndInvalidValues) + Count<string>(P_0.RawValue);
		static int Count<T>(object obj)
		{
			if (obj != null)
			{
				if (!(obj is List<T> list))
				{
					return 1;
				}
				return list.Count;
			}
			return 0;
		}
	}

	private static void ReadStoreValues<T>(Span<string> P_0, object P_1, HttpHeaderParser P_2, ref int P_3)
	{
		if (P_1 == null)
		{
			return;
		}
		if (!(P_1 is List<T> list))
		{
			P_0[P_3] = ((P_2 == null || P_1 is InvalidValue) ? P_1.ToString() : P_2.ToString(P_1));
			P_3++;
			return;
		}
		foreach (T item in list)
		{
			object obj = item;
			P_0[P_3] = ((P_2 == null || obj is InvalidValue) ? obj.ToString() : P_2.ToString(obj));
			P_3++;
		}
	}

	private static bool AreEqual(object P_0, object P_1, IEqualityComparer P_2)
	{
		return P_2?.Equals(P_0, P_1) ?? P_0.Equals(P_1);
	}

	internal HeaderEntry[] GetEntriesArray()
	{
		object headerStore = _headerStore;
		if (headerStore == null)
		{
			return null;
		}
		if (headerStore is HeaderEntry[] result)
		{
			return result;
		}
		return GetEntriesFromDictionary();
		HeaderEntry[] GetEntriesFromDictionary()
		{
			Dictionary<HeaderDescriptor, object> dictionary = (Dictionary<HeaderDescriptor, object>)_headerStore;
			HeaderEntry[] array = new HeaderEntry[dictionary.Count];
			int num = 0;
			foreach (KeyValuePair<HeaderDescriptor, object> item in dictionary)
			{
				array[num++] = new HeaderEntry
				{
					Key = item.Key,
					Value = item.Value
				};
			}
			return array;
		}
	}

	internal ReadOnlySpan<HeaderEntry> GetEntries()
	{
		return new ReadOnlySpan<HeaderEntry>(GetEntriesArray(), 0, _count);
	}

	private ref object GetValueRefOrNullRef(HeaderDescriptor P_0)
	{
		ref object result = ref Unsafe.NullRef<object>();
		object headerStore = _headerStore;
		if (headerStore is HeaderEntry[] array)
		{
			for (int i = 0; i < _count && i < array.Length; i++)
			{
				if (P_0.Equals(array[i].Key))
				{
					result = ref array[i].Value;
					break;
				}
			}
		}
		else if (headerStore != null)
		{
			result = ref CollectionsMarshal.GetValueRefOrNullRef(Unsafe.As<Dictionary<HeaderDescriptor, object>>(headerStore), P_0);
		}
		return ref result;
	}

	private ref object GetValueRefOrAddDefault(HeaderDescriptor P_0)
	{
		object headerStore = _headerStore;
		if (headerStore is HeaderEntry[] array)
		{
			for (int i = 0; i < _count && i < array.Length; i++)
			{
				if (P_0.Equals(array[i].Key))
				{
					return ref array[i].Value;
				}
			}
			int count = _count;
			_count++;
			if ((uint)count < (uint)array.Length)
			{
				array[count].Key = P_0;
				return ref array[count].Value;
			}
			return ref GrowEntriesAndAddDefault(P_0);
		}
		if (headerStore == null)
		{
			_count++;
			ref HeaderEntry arrayDataReference = ref MemoryMarshal.GetArrayDataReference((HeaderEntry[])(_headerStore = new HeaderEntry[4]));
			arrayDataReference.Key = P_0;
			return ref arrayDataReference.Value;
		}
		return ref DictionaryGetValueRefOrAddDefault(P_0);
		ref object ConvertToDictionaryAndAddDefault(HeaderDescriptor headerDescriptor)
		{
			HeaderEntry[] array2 = (HeaderEntry[])_headerStore;
			Dictionary<HeaderDescriptor, object> dictionary = (Dictionary<HeaderDescriptor, object>)(_headerStore = new Dictionary<HeaderDescriptor, object>(64));
			HeaderEntry[] array3 = array2;
			for (int j = 0; j < array3.Length; j++)
			{
				HeaderEntry headerEntry = array3[j];
				dictionary.Add(headerEntry.Key, headerEntry.Value);
			}
			return ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, headerDescriptor, out s_dictionaryGetValueRefOrAddDefaultExistsDummy);
		}
		ref object DictionaryGetValueRefOrAddDefault(HeaderDescriptor headerDescriptor)
		{
			Dictionary<HeaderDescriptor, object> dictionary = (Dictionary<HeaderDescriptor, object>)_headerStore;
			ref object valueRefOrAddDefault = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, headerDescriptor, out s_dictionaryGetValueRefOrAddDefaultExistsDummy);
			if (valueRefOrAddDefault == null)
			{
				_count++;
			}
			return ref valueRefOrAddDefault;
		}
		ref object GrowEntriesAndAddDefault(HeaderDescriptor headerDescriptor)
		{
			HeaderEntry[] array2 = (HeaderEntry[])_headerStore;
			if (array2.Length == 64)
			{
				return ref ConvertToDictionaryAndAddDefault(headerDescriptor);
			}
			Array.Resize(ref array2, array2.Length << 1);
			_headerStore = array2;
			ref HeaderEntry reference = ref array2[array2.Length >> 1];
			reference.Key = headerDescriptor;
			return ref reference.Value;
		}
	}

	private void AddEntryToStore(HeaderEntry P_0)
	{
		if (_headerStore is HeaderEntry[] array)
		{
			int count = _count;
			if ((uint)count < (uint)array.Length)
			{
				array[count] = P_0;
				_count++;
				return;
			}
		}
		GetValueRefOrAddDefault(P_0.Key) = P_0.Value;
	}

	internal bool Remove(HeaderDescriptor P_0)
	{
		bool flag = false;
		object headerStore = _headerStore;
		if (headerStore is HeaderEntry[] array)
		{
			for (int i = 0; i < _count && i < array.Length; i++)
			{
				if (P_0.Equals(array[i].Key))
				{
					for (; i + 1 < _count && (uint)(i + 1) < (uint)array.Length; i++)
					{
						array[i] = array[i + 1];
					}
					array[i] = default(HeaderEntry);
					flag = true;
					break;
				}
			}
		}
		else if (headerStore != null)
		{
			flag = Unsafe.As<Dictionary<HeaderDescriptor, object>>(headerStore).Remove(P_0);
		}
		if (flag)
		{
			_count--;
		}
		return flag;
	}
}
