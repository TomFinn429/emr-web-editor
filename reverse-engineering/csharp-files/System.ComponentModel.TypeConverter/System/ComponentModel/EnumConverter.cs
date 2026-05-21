using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public class EnumConverter : TypeConverter
{
	[CompilerGenerated]
	private StandardValuesCollection _003CValues_003Ek__BackingField;

	[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	protected Type EnumType { get; }

	protected StandardValuesCollection? Values
	{
		[CompilerGenerated]
		get
		{
			return _003CValues_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CValues_003Ek__BackingField = standardValuesCollection;
		}
	}

	protected virtual IComparer Comparer => InvariantComparer.Default;

	public EnumConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0)
	{
		EnumType = P_0;
	}

	private static long GetEnumValue(bool P_0, object P_1, CultureInfo P_2)
	{
		if (!P_0)
		{
			return Convert.ToInt64(P_1, P_2);
		}
		return (long)Convert.ToUInt64(P_1, P_2);
	}

	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			try
			{
				if (text.Contains(','))
				{
					bool flag = Enum.GetUnderlyingType(EnumType) == typeof(ulong);
					long num = 0L;
					string[] array = text.Split(',');
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						num |= GetEnumValue(flag, Enum.Parse(EnumType, text2, true), P_1);
					}
					return Enum.ToObject(EnumType, num);
				}
				return Enum.Parse(EnumType, text, true);
			}
			catch (Exception ex)
			{
				throw new FormatException(System.SR.Format("ConvertInvalidPrimitive", (string)P_2, EnumType.Name), ex);
			}
		}
		if (P_2 is Enum[])
		{
			bool flag2 = Enum.GetUnderlyingType(EnumType) == typeof(ulong);
			long num2 = 0L;
			Enum[] array3 = (Enum[])P_2;
			foreach (Enum obj in array3)
			{
				num2 |= GetEnumValue(flag2, obj, P_1);
			}
			return Enum.ToObject(EnumType, num2);
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		ArgumentNullException.ThrowIfNull(P_3, "destinationType");
		if (P_3 == typeof(string) && P_2 != null)
		{
			if (!EnumType.IsDefined(typeof(FlagsAttribute), false) && !Enum.IsDefined(EnumType, P_2))
			{
				throw new ArgumentException(System.SR.Format("EnumConverterInvalidValue", P_2, EnumType.Name));
			}
			return Enum.Format(EnumType, P_2, "G");
		}
		if (P_3 == typeof(InstanceDescriptor) && P_2 != null)
		{
			string text = ConvertToInvariantString(P_0, P_2);
			if (EnumType.IsDefined(typeof(FlagsAttribute), false) && text.Contains(','))
			{
				Type underlyingType = Enum.GetUnderlyingType(EnumType);
				if (P_2 is IConvertible)
				{
					object obj = ((IConvertible)P_2).ToType(underlyingType, P_1);
					MethodInfo method = typeof(Enum).GetMethod("ToObject", new Type[2]
					{
						typeof(Type),
						underlyingType
					});
					if (method != null)
					{
						return new InstanceDescriptor(method, new object[2] { EnumType, obj });
					}
				}
			}
			else
			{
				FieldInfo field = EnumType.GetField(text);
				if (field != null)
				{
					return new InstanceDescriptor(field, null);
				}
			}
		}
		if (P_3 == typeof(Enum[]) && P_2 != null)
		{
			if (EnumType.IsDefined(typeof(FlagsAttribute), false))
			{
				bool flag = Enum.GetUnderlyingType(EnumType) == typeof(ulong);
				List<Enum> list = new List<Enum>();
				Array valuesAsUnderlyingType = Enum.GetValuesAsUnderlyingType(EnumType);
				long[] array = new long[valuesAsUnderlyingType.Length];
				for (int i = 0; i < valuesAsUnderlyingType.Length; i++)
				{
					array[i] = GetEnumValue(flag, valuesAsUnderlyingType.GetValue(i), P_1);
				}
				long num = GetEnumValue(flag, P_2, P_1);
				bool flag2 = true;
				while (flag2)
				{
					flag2 = false;
					long[] array2 = array;
					foreach (long num2 in array2)
					{
						if ((num2 != 0L && (num2 & num) == num2) || num2 == num)
						{
							list.Add((Enum)Enum.ToObject(EnumType, num2));
							flag2 = true;
							num &= ~num2;
							break;
						}
					}
					if (num == 0L)
					{
						break;
					}
				}
				if (!flag2 && num != 0L)
				{
					list.Add((Enum)Enum.ToObject(EnumType, num));
				}
				return list.ToArray();
			}
			return new Enum[1] { (Enum)Enum.ToObject(EnumType, P_2) };
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? P_0)
	{
		if (Values == null)
		{
			Type type = TypeDescriptor.GetReflectionType(EnumType) ?? EnumType;
			FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
			ArrayList arrayList = null;
			if (fields != null && fields.Length != 0)
			{
				arrayList = new ArrayList(fields.Length);
			}
			if (arrayList != null)
			{
				FieldInfo[] array = fields;
				foreach (FieldInfo fieldInfo in array)
				{
					BrowsableAttribute browsableAttribute = null;
					object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(BrowsableAttribute), false);
					for (int j = 0; j < customAttributes.Length; j++)
					{
						Attribute attribute = (Attribute)customAttributes[j];
						browsableAttribute = null;
					}
					if (browsableAttribute != null && !browsableAttribute.Browsable)
					{
						continue;
					}
					object obj = null;
					try
					{
						if (fieldInfo.Name != null)
						{
							obj = Enum.Parse(EnumType, fieldInfo.Name);
						}
					}
					catch (ArgumentException)
					{
					}
					if (obj != null)
					{
						arrayList.Add(obj);
					}
				}
				IComparer comparer = Comparer;
				if (comparer != null)
				{
					arrayList.Sort(comparer);
				}
			}
			Array array2 = arrayList?.ToArray();
			Values = new StandardValuesCollection(array2);
		}
		return Values;
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext? P_0)
	{
		return true;
	}
}
