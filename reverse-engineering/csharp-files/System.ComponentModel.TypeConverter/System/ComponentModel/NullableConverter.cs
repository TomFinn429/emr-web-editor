using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace System.ComponentModel;

public class NullableConverter : TypeConverter
{
	private static readonly ConstructorInfo s_nullableConstructor = typeof(Nullable<>).GetConstructor(typeof(Nullable<>).GetGenericArguments());

	public Type NullableType { get; }

	public Type UnderlyingType { get; }

	public TypeConverter UnderlyingTypeConverter { get; }

	[RequiresUnreferencedCode("The UnderlyingType cannot be statically discovered.")]
	public NullableConverter(Type P_0)
	{
		NullableType = P_0;
		UnderlyingType = Nullable.GetUnderlyingType(P_0);
		if (UnderlyingType == null)
		{
			throw new ArgumentException("NullableConverterBadCtorArg", "type");
		}
		UnderlyingTypeConverter = TypeDescriptor.GetConverter(UnderlyingType);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2)
	{
		if (P_2 == null || P_2.GetType() == UnderlyingType)
		{
			return P_2;
		}
		if (P_2 is string && string.IsNullOrEmpty(P_2 as string))
		{
			return null;
		}
		if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.ConvertFrom(P_0, P_1, P_2);
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		ArgumentNullException.ThrowIfNull(P_3, "destinationType");
		if (P_3 == UnderlyingType && P_2 != null && NullableType.IsInstanceOfType(P_2))
		{
			return P_2;
		}
		if (P_3 == typeof(InstanceDescriptor))
		{
			ConstructorInfo constructorInfo = (ConstructorInfo)NullableType.GetMemberWithSameMetadataDefinitionAs(s_nullableConstructor);
			return new InstanceDescriptor(constructorInfo, new object[1] { P_2 }, true);
		}
		if (P_2 == null)
		{
			if (P_3 == typeof(string))
			{
				return string.Empty;
			}
		}
		else if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.ConvertTo(P_0, P_1, P_2, P_3);
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}

	public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? P_0)
	{
		if (UnderlyingTypeConverter != null)
		{
			StandardValuesCollection standardValues = UnderlyingTypeConverter.GetStandardValues(P_0);
			if (GetStandardValuesSupported(P_0) && standardValues != null)
			{
				object[] array = new object[standardValues.Count + 1];
				int num = 0;
				array[num++] = null;
				foreach (object item in standardValues)
				{
					array[num++] = item;
				}
				return new StandardValuesCollection(array);
			}
		}
		return base.GetStandardValues(P_0);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext? P_0)
	{
		if (UnderlyingTypeConverter != null)
		{
			return UnderlyingTypeConverter.GetStandardValuesSupported(P_0);
		}
		return base.GetStandardValuesSupported(P_0);
	}
}
