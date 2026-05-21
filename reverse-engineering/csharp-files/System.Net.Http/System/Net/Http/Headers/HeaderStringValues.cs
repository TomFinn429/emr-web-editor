using System.Collections;
using System.Collections.Generic;

namespace System.Net.Http.Headers;

public readonly struct HeaderStringValues : IReadOnlyCollection<string>, IEnumerable<string>, IEnumerable
{
	public struct Enumerator : IEnumerator<string>, IEnumerator, IDisposable
	{
		private readonly string[] _values;

		private string _current;

		private int _index;

		public string Current => _current;

		object IEnumerator.Current => Current;

		internal Enumerator(object P_0)
		{
			if (P_0 is string current)
			{
				_values = null;
				_current = current;
			}
			else
			{
				_values = P_0 as string[];
				_current = null;
			}
			_index = 0;
		}

		public bool MoveNext()
		{
			int index = _index;
			if (index < 0)
			{
				return false;
			}
			string[] values = _values;
			if (values != null)
			{
				if ((uint)index < (uint)values.Length)
				{
					_index = index + 1;
					_current = values[index];
					return true;
				}
				_index = -1;
				return false;
			}
			_index = -1;
			return _current != null;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private readonly HeaderDescriptor _header;

	private readonly object _value;

	public int Count
	{
		get
		{
			object value = _value;
			if (!(value is string))
			{
				if (value is string[] array)
				{
					return array.Length;
				}
				return 0;
			}
			return 1;
		}
	}

	internal HeaderStringValues(HeaderDescriptor P_0, string P_1)
	{
		_header = P_0;
		_value = P_1;
	}

	internal HeaderStringValues(HeaderDescriptor P_0, string[] P_1)
	{
		_header = P_0;
		_value = P_1;
	}

	public override string ToString()
	{
		object value = _value;
		if (!(value is string result))
		{
			if (value is string[] array)
			{
				HttpHeaderParser parser = _header.Parser;
				return string.Join((parser != null && parser.SupportsMultipleValues) ? parser.Separator : ", ", array);
			}
			return string.Empty;
		}
		return result;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(_value);
	}

	IEnumerator<string> IEnumerable<string>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
