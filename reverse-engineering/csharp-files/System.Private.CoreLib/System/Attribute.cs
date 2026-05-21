using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System;

[Serializable]
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public abstract class Attribute
{
	public virtual object TypeId => GetType();

	private static Attribute GetAttr(ICustomAttributeProvider P_0, Type P_1, bool P_2)
	{
		ArgumentNullException.ThrowIfNull(P_1, "attributeType");
		if (!P_1.IsSubclassOf(typeof(Attribute)) && !P_1.IsInterface && P_1 != typeof(Attribute) && P_1 != typeof(CustomAttribute))
		{
			throw new ArgumentException("Argument_MustHaveAttributeBaseClass" + " " + P_1.FullName);
		}
		object[] customAttributes = CustomAttribute.GetCustomAttributes(P_0, P_1, P_2);
		if (customAttributes == null || customAttributes.Length == 0)
		{
			return null;
		}
		if (customAttributes.Length != 1)
		{
			throw new AmbiguousMatchException();
		}
		return (Attribute)customAttributes[0];
	}

	public static Attribute? GetCustomAttribute(MemberInfo P_0, Type P_1)
	{
		return GetAttr(P_0, P_1, true);
	}

	public static Attribute? GetCustomAttribute(MemberInfo P_0, Type P_1, bool P_2)
	{
		return GetAttr(P_0, P_1, P_2);
	}

	public static Attribute[] GetCustomAttributes(MemberInfo P_0, Type P_1, bool P_2)
	{
		return (Attribute[])CustomAttribute.GetCustomAttributes(P_0, P_1, P_2);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Unused fields don't make a difference for equality")]
	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (GetType() != P_0.GetType())
		{
			return false;
		}
		Type type = GetType();
		while (type != typeof(Attribute))
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			for (int i = 0; i < fields.Length; i++)
			{
				object value = fields[i].GetValue(this);
				object value2 = fields[i].GetValue(P_0);
				if (!AreFieldValuesEqual(value, value2))
				{
					return false;
				}
			}
			type = type.BaseType;
		}
		return true;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075:UnrecognizedReflectionPattern", Justification = "Unused fields don't make a difference for hashcode quality")]
	public override int GetHashCode()
	{
		Type type = GetType();
		while (type != typeof(Attribute))
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			object obj = null;
			for (int i = 0; i < fields.Length; i++)
			{
				object value = fields[i].GetValue(this);
				if (value != null && !value.GetType().IsArray)
				{
					obj = value;
				}
				if (obj != null)
				{
					break;
				}
			}
			if (obj != null)
			{
				return obj.GetHashCode();
			}
			type = type.BaseType;
		}
		return type.GetHashCode();
	}

	private static bool AreFieldValuesEqual(object P_0, object P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		Type type = P_0.GetType();
		if (type.IsArray)
		{
			if (!type.Equals(P_1.GetType()))
			{
				return false;
			}
			Array array = (Array)P_0;
			Array array2 = (Array)P_1;
			if (array.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!AreFieldValuesEqual(array.GetValue(i), array2.GetValue(i)))
				{
					return false;
				}
			}
		}
		else if (!P_0.Equals(P_1))
		{
			return false;
		}
		return true;
	}

	public virtual bool IsDefaultAttribute()
	{
		return false;
	}
}
