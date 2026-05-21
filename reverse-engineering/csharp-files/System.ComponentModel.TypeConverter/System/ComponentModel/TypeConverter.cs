using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class TypeConverter
{
	[DefaultMember("Item")]
	public class StandardValuesCollection : ICollection, IEnumerable
	{
		private readonly ICollection _values;

		private Array _valueArray;

		public int Count
		{
			get
			{
				if (_valueArray != null)
				{
					return _valueArray.Length;
				}
				return _values.Count;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		public StandardValuesCollection(ICollection? P_0)
		{
			if (P_0 == null)
			{
				P_0 = Array.Empty<object>();
			}
			if (P_0 is Array valueArray)
			{
				_valueArray = valueArray;
			}
			_values = P_0;
		}

		public void CopyTo(Array P_0, int P_1)
		{
			_values.CopyTo(P_0, P_1);
		}

		public IEnumerator GetEnumerator()
		{
			return _values.GetEnumerator();
		}
	}

	public virtual object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is InstanceDescriptor instanceDescriptor)
		{
			return instanceDescriptor.Invoke();
		}
		throw GetConvertFromException(P_2);
	}

	public object? ConvertFromInvariantString(string P_0)
	{
		return ConvertFromString(null, CultureInfo.InvariantCulture, P_0);
	}

	public object? ConvertFromString(ITypeDescriptorContext? P_0, CultureInfo? P_1, string P_2)
	{
		return ConvertFrom(P_0, P_1, P_2);
	}

	public virtual object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		ArgumentNullException.ThrowIfNull(P_3, "destinationType");
		if (P_3 == typeof(string))
		{
			if (P_2 == null)
			{
				return string.Empty;
			}
			if (P_1 != null && P_1 != CultureInfo.CurrentCulture && P_2 is IFormattable formattable)
			{
				return formattable.ToString(null, P_1);
			}
			return P_2.ToString();
		}
		throw GetConvertToException(P_2, P_3);
	}

	public string? ConvertToInvariantString(ITypeDescriptorContext? P_0, object? P_1)
	{
		return ConvertToString(P_0, CultureInfo.InvariantCulture, P_1);
	}

	public string? ConvertToString(object? P_0)
	{
		return (string)ConvertTo(null, CultureInfo.CurrentCulture, P_0, typeof(string));
	}

	public string? ConvertToString(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2)
	{
		return (string)ConvertTo(P_0, P_1, P_2, typeof(string));
	}

	protected Exception GetConvertFromException(object? P_0)
	{
		string text = ((P_0 == null) ? "(null)" : P_0.GetType().FullName);
		throw new NotSupportedException(System.SR.Format("ConvertFromException", GetType().Name, text));
	}

	protected Exception GetConvertToException(object? P_0, Type P_1)
	{
		string text = ((P_0 == null) ? "(null)" : P_0.GetType().FullName);
		throw new NotSupportedException(System.SR.Format("ConvertToException", GetType().Name, text, P_1.FullName));
	}

	public virtual StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? P_0)
	{
		return null;
	}

	public virtual bool GetStandardValuesSupported(ITypeDescriptorContext? P_0)
	{
		return false;
	}
}
