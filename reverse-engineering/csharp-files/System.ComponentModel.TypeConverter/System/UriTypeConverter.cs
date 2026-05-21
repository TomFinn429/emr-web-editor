using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace System;

public class UriTypeConverter : TypeConverter
{
	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2)
	{
		if (P_2 is string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			return new Uri(text, UriKind.RelativeOrAbsolute);
		}
		if (P_2 is Uri uri)
		{
			return new Uri(uri.OriginalString, GetUriKind(uri));
		}
		throw GetConvertFromException(P_2);
	}

	public override object ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		ArgumentNullException.ThrowIfNull(P_3, "destinationType");
		if (P_2 is Uri uri)
		{
			if (P_3 == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = typeof(Uri).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
				{
					typeof(string),
					typeof(UriKind)
				}, null);
				return new InstanceDescriptor(constructor, new object[2]
				{
					uri.OriginalString,
					GetUriKind(uri)
				});
			}
			if (P_3 == typeof(string))
			{
				return uri.OriginalString;
			}
			if (P_3 == typeof(Uri))
			{
				return new Uri(uri.OriginalString, GetUriKind(uri));
			}
		}
		throw GetConvertToException(P_2, P_3);
	}

	private static UriKind GetUriKind(Uri P_0)
	{
		if (!P_0.IsAbsoluteUri)
		{
			return UriKind.Relative;
		}
		return UriKind.Absolute;
	}
}
