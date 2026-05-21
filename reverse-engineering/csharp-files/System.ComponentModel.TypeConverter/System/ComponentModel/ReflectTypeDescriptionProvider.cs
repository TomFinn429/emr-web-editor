using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.ComponentModel;

internal sealed class ReflectTypeDescriptionProvider : TypeDescriptionProvider
{
	private sealed class IntrinsicTypeConverterData
	{
		private readonly Func<Type, TypeConverter> _constructionFunc;

		private readonly bool _cacheConverterInstance;

		private TypeConverter _converterInstance;

		public IntrinsicTypeConverterData(Func<Type, TypeConverter> P_0, bool P_1 = true)
		{
			_constructionFunc = P_0;
			_cacheConverterInstance = P_1;
		}

		public TypeConverter GetOrCreateConverterInstance(Type P_0)
		{
			if (!_cacheConverterInstance)
			{
				return _constructionFunc(P_0);
			}
			if (_converterInstance == null)
			{
				_converterInstance = _constructionFunc(P_0);
			}
			return _converterInstance;
		}
	}

	private sealed class ReflectedTypeData
	{
		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
		private readonly Type _type;

		private AttributeCollection _attributes;

		private EventDescriptorCollection _events;

		private PropertyDescriptorCollection _properties;

		private TypeConverter _converter;

		private object[] _editors;

		private Type[] _editorTypes;

		private int _editorCount;

		internal bool IsPopulated => (_attributes != null) | (_events != null) | (_properties != null);

		internal ReflectedTypeData([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0)
		{
			_type = P_0;
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2062:UnrecognizedReflectionPattern", Justification = "_type is annotated as preserve All members, so any Types returned from GetInterfaces should be preserved as well once https://github.com/mono/linker/issues/1731 is fixed.")]
		internal AttributeCollection GetAttributes()
		{
			if (_attributes == null)
			{
				List<Attribute> list = new List<Attribute>(ReflectGetAttributes(_type));
				Type baseType = _type.BaseType;
				while (baseType != null && baseType != typeof(object))
				{
					list.AddRange(ReflectGetAttributes(baseType));
					baseType = baseType.BaseType;
				}
				int count = list.Count;
				Type[] interfaces = _type.GetInterfaces();
				foreach (Type type in interfaces)
				{
					if ((type.Attributes & TypeAttributes.NestedPrivate) != TypeAttributes.NotPublic)
					{
						list.AddRange(TypeDescriptor.GetAttributes(type).Attributes);
					}
				}
				if (list.Count != 0)
				{
					HashSet<object> hashSet = new HashSet<object>(list.Count);
					int num = 0;
					for (int j = 0; j < list.Count; j++)
					{
						Attribute attribute = list[j];
						bool flag = true;
						if (j >= count)
						{
							for (int k = 0; k < s_skipInterfaceAttributeList.Length; k++)
							{
								if (s_skipInterfaceAttributeList[k].IsInstanceOfType(attribute))
								{
									flag = false;
									break;
								}
							}
						}
						if (flag && hashSet.Add(attribute.TypeId))
						{
							list[num++] = list[j];
						}
					}
					list.RemoveRange(num, list.Count - num);
				}
				_attributes = new AttributeCollection(list.ToArray());
			}
			return _attributes;
		}

		[RequiresUnreferencedCode("NullableConverter's UnderlyingType cannot be statically discovered. The Type of instance cannot be statically discovered.")]
		internal TypeConverter GetConverter(object P_0)
		{
			TypeConverterAttribute typeConverterAttribute = null;
			if (P_0 != null)
			{
				typeConverterAttribute = (TypeConverterAttribute)TypeDescriptor.GetAttributes(_type)[typeof(TypeConverterAttribute)];
				TypeConverterAttribute typeConverterAttribute2 = (TypeConverterAttribute)TypeDescriptor.GetAttributes(P_0)[typeof(TypeConverterAttribute)];
				if (typeConverterAttribute != typeConverterAttribute2)
				{
					Type typeFromName = GetTypeFromName(typeConverterAttribute2.ConverterTypeName);
					if (typeFromName != null && typeof(TypeConverter).IsAssignableFrom(typeFromName))
					{
						return (TypeConverter)CreateInstance(typeFromName, _type);
					}
				}
			}
			if (_converter == null)
			{
				if (typeConverterAttribute == null)
				{
					typeConverterAttribute = (TypeConverterAttribute)TypeDescriptor.GetAttributes(_type)[typeof(TypeConverterAttribute)];
				}
				if (typeConverterAttribute != null)
				{
					Type typeFromName2 = GetTypeFromName(typeConverterAttribute.ConverterTypeName);
					if (typeFromName2 != null && typeof(TypeConverter).IsAssignableFrom(typeFromName2))
					{
						_converter = (TypeConverter)CreateInstance(typeFromName2, _type);
					}
				}
				if (_converter == null)
				{
					_converter = GetIntrinsicTypeConverter(_type);
				}
			}
			return _converter;
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Calling _type.Assembly.GetType on a non-assembly qualified type will still work. See https://github.com/mono/linker/issues/1895")]
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2057:TypeGetType", Justification = "Using the non-assembly qualified type name will still work.")]
		private Type GetTypeFromName([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return null;
			}
			int num = P_0.IndexOf(',');
			Type type = null;
			if (num == -1)
			{
				type = _type.Assembly.GetType(P_0);
			}
			if ((object)type == null)
			{
				type = Type.GetType(P_0);
			}
			if (type == null && num != -1)
			{
				type = Type.GetType(P_0.Substring(0, num));
			}
			return type;
		}

		internal void Refresh()
		{
			_attributes = null;
			_events = null;
			_properties = null;
			_converter = null;
			_editors = null;
			_editorTypes = null;
			_editorCount = 0;
		}
	}

	private Hashtable _typeData;

	private static readonly Type[] s_typeConstructor = new Type[1] { typeof(Type) };

	private static Dictionary<object, IntrinsicTypeConverterData> s_intrinsicTypeConverters;

	private static readonly object s_intrinsicReferenceKey = new object();

	private static readonly object s_intrinsicNullableKey = new object();

	private static readonly object s_dictionaryKey = new object();

	private static Hashtable s_attributeCache;

	private static readonly Guid s_extenderPropertiesKey = Guid.NewGuid();

	private static readonly Guid s_extenderProviderPropertiesKey = Guid.NewGuid();

	private static readonly Type[] s_skipInterfaceAttributeList = InitializeSkipInterfaceAttributeList();

	[CompilerGenerated]
	private static readonly Guid _003CExtenderProviderKey_003Ek__BackingField = Guid.NewGuid();

	private static readonly object s_internalSyncObject = new object();

	private static Dictionary<object, IntrinsicTypeConverterData> IntrinsicTypeConverters
	{
		[RequiresUnreferencedCode("NullableConverter's UnderlyingType cannot be statically discovered.")]
		get
		{
			return LazyInitializer.EnsureInitialized(ref s_intrinsicTypeConverters, () => new Dictionary<object, IntrinsicTypeConverterData>(27)
			{
				[typeof(bool)] = new IntrinsicTypeConverterData((Type P_0) => new BooleanConverter()),
				[typeof(byte)] = new IntrinsicTypeConverterData((Type P_0) => new ByteConverter()),
				[typeof(sbyte)] = new IntrinsicTypeConverterData((Type P_0) => new SByteConverter()),
				[typeof(char)] = new IntrinsicTypeConverterData((Type P_0) => new CharConverter()),
				[typeof(double)] = new IntrinsicTypeConverterData((Type P_0) => new DoubleConverter()),
				[typeof(string)] = new IntrinsicTypeConverterData((Type P_0) => new StringConverter()),
				[typeof(int)] = new IntrinsicTypeConverterData((Type P_0) => new Int32Converter()),
				[typeof(Int128)] = new IntrinsicTypeConverterData((Type P_0) => new Int128Converter()),
				[typeof(short)] = new IntrinsicTypeConverterData((Type P_0) => new Int16Converter()),
				[typeof(long)] = new IntrinsicTypeConverterData((Type P_0) => new Int64Converter()),
				[typeof(float)] = new IntrinsicTypeConverterData((Type P_0) => new SingleConverter()),
				[typeof(Half)] = new IntrinsicTypeConverterData((Type P_0) => new HalfConverter()),
				[typeof(UInt128)] = new IntrinsicTypeConverterData((Type P_0) => new UInt128Converter()),
				[typeof(ushort)] = new IntrinsicTypeConverterData((Type P_0) => new UInt16Converter()),
				[typeof(uint)] = new IntrinsicTypeConverterData((Type P_0) => new UInt32Converter()),
				[typeof(ulong)] = new IntrinsicTypeConverterData((Type P_0) => new UInt64Converter()),
				[typeof(object)] = new IntrinsicTypeConverterData((Type P_0) => new TypeConverter()),
				[typeof(CultureInfo)] = new IntrinsicTypeConverterData((Type P_0) => new CultureInfoConverter()),
				[typeof(DateOnly)] = new IntrinsicTypeConverterData((Type P_0) => new DateOnlyConverter()),
				[typeof(DateTime)] = new IntrinsicTypeConverterData((Type P_0) => new DateTimeConverter()),
				[typeof(DateTimeOffset)] = new IntrinsicTypeConverterData((Type P_0) => new DateTimeOffsetConverter()),
				[typeof(decimal)] = new IntrinsicTypeConverterData((Type P_0) => new DecimalConverter()),
				[typeof(TimeOnly)] = new IntrinsicTypeConverterData((Type P_0) => new TimeOnlyConverter()),
				[typeof(TimeSpan)] = new IntrinsicTypeConverterData((Type P_0) => new TimeSpanConverter()),
				[typeof(Guid)] = new IntrinsicTypeConverterData((Type P_0) => new GuidConverter()),
				[typeof(Uri)] = new IntrinsicTypeConverterData((Type P_0) => new UriTypeConverter()),
				[typeof(Version)] = new IntrinsicTypeConverterData((Type P_0) => new VersionConverter()),
				[typeof(Array)] = new IntrinsicTypeConverterData((Type P_0) => new ArrayConverter()),
				[typeof(ICollection)] = new IntrinsicTypeConverterData((Type P_0) => new CollectionConverter()),
				[typeof(Enum)] = new IntrinsicTypeConverterData((Type P_0) => CreateEnumConverter(P_0), false),
				[s_intrinsicNullableKey] = new IntrinsicTypeConverterData((Type P_0) => CreateNullableConverter(P_0), false),
				[s_intrinsicReferenceKey] = new IntrinsicTypeConverterData((Type P_0) => new ReferenceConverter(P_0), false)
			});
		}
	}

	private static Hashtable AttributeCache => LazyInitializer.EnsureInitialized(ref s_attributeCache, () => new Hashtable());

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2045:AttributeRemoval", Justification = "The ComVisibleAttribute is marked for removal and it's referenced here. Since this arraycontains only attributes which are going to be ignored, removing such attributewill not break the functionality in any way.")]
	private static Type[] InitializeSkipInterfaceAttributeList()
	{
		return new Type[3]
		{
			typeof(GuidAttribute),
			typeof(InterfaceTypeAttribute),
			typeof(ComVisibleAttribute)
		};
	}

	internal ReflectTypeDescriptionProvider()
	{
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "IntrinsicTypeConverters is marked with RequiresUnreferencedCode. It is the only place that should call this.")]
	private static NullableConverter CreateNullableConverter(Type P_0)
	{
		return new NullableConverter(P_0);
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067:UnrecognizedReflectionPattern", Justification = "Trimmer does not trim enums")]
	private static EnumConverter CreateEnumConverter(Type P_0)
	{
		return new EnumConverter(P_0);
	}

	private static object CreateInstance([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type P_0, Type P_1)
	{
		return P_0.GetConstructor(s_typeConstructor)?.Invoke(new object[1] { P_1 }) ?? Activator.CreateInstance(P_0);
	}

	internal AttributeCollection GetAttributes([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0)
	{
		ReflectedTypeData typeData = GetTypeData(P_0, true);
		return typeData.GetAttributes();
	}

	public override IDictionary GetCache(object P_0)
	{
		if (P_0 is IComponent { Site: not null } component && component.Site.GetService(typeof(IDictionaryService)) is IDictionaryService dictionaryService)
		{
			IDictionary dictionary = dictionaryService.GetValue(s_dictionaryKey) as IDictionary;
			if (dictionary == null)
			{
				dictionary = new Hashtable();
				dictionaryService.SetValue(s_dictionaryKey, dictionary);
			}
			return dictionary;
		}
		return null;
	}

	[RequiresUnreferencedCode("NullableConverter's UnderlyingType cannot be statically discovered. The Type of instance cannot be statically discovered.")]
	internal TypeConverter GetConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, object P_1)
	{
		ReflectedTypeData typeData = GetTypeData(P_0, true);
		return typeData.GetConverter(P_1);
	}

	internal static AttributeCollection GetExtendedAttributes(object P_0)
	{
		return AttributeCollection.Empty;
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered. NullableConverter's UnderlyingType cannot be statically discovered.")]
	internal TypeConverter GetExtendedConverter(object P_0)
	{
		return GetConverter(P_0.GetType(), P_0);
	}

	[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
	public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object P_0)
	{
		return null;
	}

	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public override Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0, object P_1)
	{
		return P_0;
	}

	private ReflectedTypeData GetTypeData([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, bool P_1)
	{
		ReflectedTypeData reflectedTypeData = null;
		if (_typeData != null)
		{
			reflectedTypeData = (ReflectedTypeData)_typeData[P_0];
			if (reflectedTypeData != null)
			{
				return reflectedTypeData;
			}
		}
		lock (s_internalSyncObject)
		{
			if (_typeData != null)
			{
				reflectedTypeData = (ReflectedTypeData)_typeData[P_0];
			}
			if (reflectedTypeData == null && P_1)
			{
				reflectedTypeData = new ReflectedTypeData(P_0);
				if (_typeData == null)
				{
					_typeData = new Hashtable();
				}
				_typeData[P_0] = reflectedTypeData;
			}
		}
		return reflectedTypeData;
	}

	public override ICustomTypeDescriptor GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, object P_1)
	{
		return null;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067:UnrecognizedReflectionPattern", Justification = "ReflectedTypeData is not being created here, just checking if was already created.")]
	internal bool IsPopulated(Type P_0)
	{
		return GetTypeData(P_0, false)?.IsPopulated ?? false;
	}

	internal static Attribute[] ReflectGetAttributes(Type P_0)
	{
		Hashtable attributeCache = AttributeCache;
		Attribute[] array = (Attribute[])attributeCache[P_0];
		if (array != null)
		{
			return array;
		}
		lock (s_internalSyncObject)
		{
			array = (Attribute[])attributeCache[P_0];
			if (array == null)
			{
				array = (Attribute[])(attributeCache[P_0] = Attribute.GetCustomAttributes(P_0, typeof(Attribute), false));
			}
		}
		return array;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2067:UnrecognizedReflectionPattern", Justification = "ReflectedTypeData is not being created here, just checking if was already created.")]
	internal void Refresh(Type P_0)
	{
		GetTypeData(P_0, false)?.Refresh();
	}

	[RequiresUnreferencedCode("NullableConverter's UnderlyingType cannot be statically discovered.")]
	private static TypeConverter GetIntrinsicTypeConverter(Type P_0)
	{
		lock (IntrinsicTypeConverters)
		{
			if (!IntrinsicTypeConverters.TryGetValue(P_0, out var intrinsicTypeConverterData))
			{
				if (P_0.IsEnum)
				{
					intrinsicTypeConverterData = IntrinsicTypeConverters[typeof(Enum)];
				}
				else if (P_0.IsArray)
				{
					intrinsicTypeConverterData = IntrinsicTypeConverters[typeof(Array)];
				}
				else if (P_0.IsGenericType && P_0.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					intrinsicTypeConverterData = IntrinsicTypeConverters[s_intrinsicNullableKey];
				}
				else if (typeof(ICollection).IsAssignableFrom(P_0))
				{
					intrinsicTypeConverterData = IntrinsicTypeConverters[typeof(ICollection)];
				}
				else if (P_0.IsInterface)
				{
					intrinsicTypeConverterData = IntrinsicTypeConverters[s_intrinsicReferenceKey];
				}
				else
				{
					Type type = null;
					Type baseType = P_0.BaseType;
					while (baseType != null && baseType != typeof(object))
					{
						if (baseType == typeof(Uri) || baseType == typeof(CultureInfo))
						{
							type = baseType;
							break;
						}
						baseType = baseType.BaseType;
					}
					if ((object)type == null)
					{
						type = typeof(object);
					}
					intrinsicTypeConverterData = IntrinsicTypeConverters[type];
				}
			}
			return intrinsicTypeConverterData.GetOrCreateConverterInstance(P_0);
		}
	}
}
