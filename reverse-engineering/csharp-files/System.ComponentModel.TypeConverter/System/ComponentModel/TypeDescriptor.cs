using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.ComponentModel;

public sealed class TypeDescriptor
{
	private sealed class FilterCacheItem
	{
		private readonly ITypeDescriptorFilterService _filterService;

		internal readonly ICollection FilteredMembers;

		internal FilterCacheItem(ITypeDescriptorFilterService P_0, ICollection P_1)
		{
			_filterService = P_0;
			FilteredMembers = P_1;
		}

		internal bool IsValid(ITypeDescriptorFilterService P_0)
		{
			if (_filterService != P_0)
			{
				return false;
			}
			return true;
		}
	}

	private sealed class MemberDescriptorComparer : IComparer
	{
		public static readonly MemberDescriptorComparer Instance = new MemberDescriptorComparer();

		public int Compare(object P_0, object P_1)
		{
			return CultureInfo.InvariantCulture.CompareInfo.Compare(((MemberDescriptor)null)?.Name, ((MemberDescriptor)null)?.Name);
		}
	}

	[TypeDescriptionProvider(typeof(ComNativeDescriptorProxy))]
	private sealed class TypeDescriptorComObject
	{
	}

	private sealed class ComNativeDescriptorProxy : TypeDescriptionProvider
	{
		private readonly TypeDescriptionProvider _comNativeDescriptor;

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2072:UnrecognizedReflectionPattern", Justification = "The trimmer can't find the ComNativeDescriptor type when System.Windows.Forms isn't available. When System.Windows.Forms is available, the type will be seen by the trimmer and the ctor will be preserved.")]
		public ComNativeDescriptorProxy()
		{
			Type type = Type.GetType("System.Windows.Forms.ComponentModel.Com2Interop.ComNativeDescriptor, System.Windows.Forms", true);
			_comNativeDescriptor = (TypeDescriptionProvider)Activator.CreateInstance(type);
		}

		[return: NotNullIfNotNull("instance")]
		public override ICustomTypeDescriptor GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, object P_1)
		{
			return _comNativeDescriptor.GetTypeDescriptor(P_0, P_1);
		}
	}

	private sealed class MergedTypeDescriptor : ICustomTypeDescriptor
	{
		private readonly ICustomTypeDescriptor _primary;

		private readonly ICustomTypeDescriptor _secondary;

		internal MergedTypeDescriptor(ICustomTypeDescriptor P_0, ICustomTypeDescriptor P_1)
		{
			_primary = P_0;
			_secondary = P_1;
		}

		AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return _primary.GetAttributes() ?? _secondary.GetAttributes();
		}

		[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return _primary.GetConverter() ?? _secondary.GetConverter();
		}
	}

	private sealed class TypeDescriptionNode : TypeDescriptionProvider
	{
		private readonly struct DefaultExtendedTypeDescriptor : ICustomTypeDescriptor
		{
			private readonly TypeDescriptionNode _node;

			private readonly object _instance;

			[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
			internal DefaultExtendedTypeDescriptor(TypeDescriptionNode P_0, object P_1)
			{
				_node = P_0;
				_instance = P_1;
			}

			[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor of this Type has RequiresUnreferencedCode.")]
			AttributeCollection ICustomTypeDescriptor.GetAttributes()
			{
				TypeDescriptionProvider provider = _node.Provider;
				if (provider is ReflectTypeDescriptionProvider)
				{
					return ReflectTypeDescriptionProvider.GetExtendedAttributes(_instance);
				}
				ICustomTypeDescriptor extendedTypeDescriptor = provider.GetExtendedTypeDescriptor(_instance);
				if (extendedTypeDescriptor == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetExtendedTypeDescriptor"));
				}
				AttributeCollection attributes = extendedTypeDescriptor.GetAttributes();
				if (attributes == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetAttributes"));
				}
				return attributes;
			}

			[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
			TypeConverter ICustomTypeDescriptor.GetConverter()
			{
				TypeDescriptionProvider provider = _node.Provider;
				if (provider is ReflectTypeDescriptionProvider reflectTypeDescriptionProvider)
				{
					return reflectTypeDescriptionProvider.GetExtendedConverter(_instance);
				}
				ICustomTypeDescriptor extendedTypeDescriptor = provider.GetExtendedTypeDescriptor(_instance);
				if (extendedTypeDescriptor == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetExtendedTypeDescriptor"));
				}
				TypeConverter converter = extendedTypeDescriptor.GetConverter();
				if (converter == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetConverter"));
				}
				return converter;
			}
		}

		internal TypeDescriptionNode Next;

		internal TypeDescriptionProvider Provider;

		internal TypeDescriptionNode(TypeDescriptionProvider P_0)
		{
			Provider = P_0;
		}

		public override IDictionary GetCache(object P_0)
		{
			ArgumentNullException.ThrowIfNull(P_0, "instance");
			return Provider.GetCache(P_0);
		}

		[RequiresUnreferencedCode("The Type of instance cannot be statically discovered.")]
		public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object P_0)
		{
			ArgumentNullException.ThrowIfNull(P_0, "instance");
			return new DefaultExtendedTypeDescriptor(this, P_0);
		}

		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
		public override Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0, object P_1)
		{
			ArgumentNullException.ThrowIfNull(P_0, "objectType");
			return Provider.GetReflectionType(P_0, P_1);
		}

		public override ICustomTypeDescriptor GetTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, object P_1)
		{
			ArgumentNullException.ThrowIfNull(P_0, "objectType");
			if (P_1 != null && !P_0.IsInstanceOfType(P_1))
			{
				throw new ArgumentException("instance");
			}
			return new DefaultTypeDescriptor(this, P_0, P_1);
		}

		internal DefaultTypeDescriptor GetDefaultTypeDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0)
		{
			return new DefaultTypeDescriptor(this, P_0, null);
		}
	}

	private readonly struct DefaultTypeDescriptor : ICustomTypeDescriptor
	{
		private readonly TypeDescriptionNode _node;

		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
		private readonly Type _objectType;

		private readonly object _instance;

		internal DefaultTypeDescriptor(TypeDescriptionNode P_0, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_1, object P_2)
		{
			_node = P_0;
			_objectType = P_1;
			_instance = P_2;
		}

		public AttributeCollection GetAttributes()
		{
			TypeDescriptionProvider provider = _node.Provider;
			AttributeCollection attributes;
			if (provider is ReflectTypeDescriptionProvider reflectTypeDescriptionProvider)
			{
				attributes = reflectTypeDescriptionProvider.GetAttributes(_objectType);
			}
			else
			{
				ICustomTypeDescriptor typeDescriptor = provider.GetTypeDescriptor(_objectType, _instance);
				if (typeDescriptor == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetTypeDescriptor"));
				}
				attributes = typeDescriptor.GetAttributes();
				if (attributes == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetAttributes"));
				}
			}
			return attributes;
		}

		[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
		public TypeConverter GetConverter()
		{
			TypeDescriptionProvider provider = _node.Provider;
			TypeConverter converter;
			if (provider is ReflectTypeDescriptionProvider reflectTypeDescriptionProvider)
			{
				converter = reflectTypeDescriptionProvider.GetConverter(_objectType, _instance);
			}
			else
			{
				ICustomTypeDescriptor typeDescriptor = provider.GetTypeDescriptor(_objectType, _instance);
				if (typeDescriptor == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetTypeDescriptor"));
				}
				converter = typeDescriptor.GetConverter();
				if (converter == null)
				{
					throw new InvalidOperationException(System.SR.Format("TypeDescriptorProviderError", _node.Provider.GetType().FullName, "GetConverter"));
				}
			}
			return converter;
		}
	}

	private sealed class TypeDescriptorInterface
	{
	}

	private static readonly WeakHashtable s_providerTable = new WeakHashtable();

	private static readonly Hashtable s_providerTypeTable = new Hashtable();

	private static readonly Hashtable s_defaultProviders = new Hashtable();

	private static int s_metadataVersion;

	private static int s_collisionIndex;

	private static readonly Guid[] s_pipelineInitializeKeys = new Guid[3]
	{
		Guid.NewGuid(),
		Guid.NewGuid(),
		Guid.NewGuid()
	};

	private static readonly Guid[] s_pipelineMergeKeys = new Guid[3]
	{
		Guid.NewGuid(),
		Guid.NewGuid(),
		Guid.NewGuid()
	};

	private static readonly Guid[] s_pipelineFilterKeys = new Guid[3]
	{
		Guid.NewGuid(),
		Guid.NewGuid(),
		Guid.NewGuid()
	};

	private static readonly Guid[] s_pipelineAttributeFilterKeys = new Guid[3]
	{
		Guid.NewGuid(),
		Guid.NewGuid(),
		Guid.NewGuid()
	};

	private static readonly object s_internalSyncObject = new object();

	[CompilerGenerated]
	private static RefreshEventHandler Refreshed;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static Type InterfaceType
	{
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
		get
		{
			return typeof(TypeDescriptorInterface);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static Type ComObjectType
	{
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
		get
		{
			return typeof(TypeDescriptorComObject);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static void AddProvider(TypeDescriptionProvider P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "provider");
		ArgumentNullException.ThrowIfNull(P_1, "type");
		lock (s_providerTable)
		{
			TypeDescriptionNode next = NodeFor(P_1, true);
			TypeDescriptionNode typeDescriptionNode = new TypeDescriptionNode(P_0)
			{
				Next = next
			};
			s_providerTable[P_1] = typeDescriptionNode;
			s_providerTypeTable.Clear();
		}
		Refresh(P_1);
	}

	private static void CheckDefaultProvider(Type P_0)
	{
		if (s_defaultProviders.ContainsKey(P_0))
		{
			return;
		}
		lock (s_internalSyncObject)
		{
			if (s_defaultProviders.ContainsKey(P_0))
			{
				return;
			}
			s_defaultProviders[P_0] = null;
		}
		object[] customAttributes = P_0.GetCustomAttributes(typeof(TypeDescriptionProviderAttribute), false);
		bool flag = false;
		for (int num = customAttributes.Length - 1; num >= 0; num--)
		{
			TypeDescriptionProviderAttribute typeDescriptionProviderAttribute = (TypeDescriptionProviderAttribute)customAttributes[num];
			Type type = Type.GetType(typeDescriptionProviderAttribute.TypeName);
			if (type != null && typeof(TypeDescriptionProvider).IsAssignableFrom(type))
			{
				TypeDescriptionProvider typeDescriptionProvider = (TypeDescriptionProvider)Activator.CreateInstance(type);
				AddProvider(typeDescriptionProvider, P_0);
				flag = true;
			}
		}
		if (!flag)
		{
			Type baseType = P_0.BaseType;
			if (baseType != null && baseType != P_0)
			{
				CheckDefaultProvider(baseType);
			}
		}
	}

	public static AttributeCollection GetAttributes([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0)
	{
		if (P_0 == null)
		{
			return new AttributeCollection((Attribute[]?)null);
		}
		return GetDescriptor(P_0, "componentType").GetAttributes();
	}

	[RequiresUnreferencedCode("The Type of component cannot be statically discovered.")]
	public static AttributeCollection GetAttributes(object P_0)
	{
		return GetAttributes(P_0, false);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[RequiresUnreferencedCode("The Type of component cannot be statically discovered.")]
	public static AttributeCollection GetAttributes(object P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return new AttributeCollection((Attribute[]?)null);
		}
		ICustomTypeDescriptor descriptor = GetDescriptor(P_0, P_1);
		ICollection collection = descriptor.GetAttributes();
		if (P_0 is ICustomTypeDescriptor)
		{
			if (P_1)
			{
				ICustomTypeDescriptor extendedDescriptor = GetExtendedDescriptor(P_0);
				if (extendedDescriptor != null)
				{
					ICollection attributes = extendedDescriptor.GetAttributes();
					collection = PipelineMerge(0, collection, attributes, P_0, null);
				}
			}
			else
			{
				collection = PipelineFilter(0, collection, P_0, null);
			}
		}
		else
		{
			IDictionary cache = GetCache(P_0);
			collection = PipelineInitialize(0, collection, cache);
			ICustomTypeDescriptor extendedDescriptor2 = GetExtendedDescriptor(P_0);
			if (extendedDescriptor2 != null)
			{
				ICollection attributes2 = extendedDescriptor2.GetAttributes();
				collection = PipelineMerge(0, collection, attributes2, P_0, cache);
			}
			collection = PipelineFilter(0, collection, P_0, cache);
		}
		AttributeCollection attributeCollection = collection as AttributeCollection;
		if (attributeCollection == null)
		{
			Attribute[] array = new Attribute[collection.Count];
			collection.CopyTo(array, 0);
			attributeCollection = new AttributeCollection(array);
		}
		return attributeCollection;
	}

	internal static IDictionary GetCache(object P_0)
	{
		return NodeFor(P_0).GetCache(P_0);
	}

	[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
	public static TypeConverter GetConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0)
	{
		return GetDescriptor(P_0, "type").GetConverter();
	}

	[RequiresUnreferencedCode("Generic TypeConverters may require the generic types to be annotated. For example, NullableConverter requires the underlying type to be DynamicallyAccessedMembers All.")]
	private static object ConvertFromInvariantString([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type type, string stringValue)
	{
		return GetConverter(type).ConvertFromInvariantString(stringValue);
	}

	private static DefaultTypeDescriptor GetDescriptor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type P_0, string P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, P_1);
		return NodeFor(P_0).GetDefaultTypeDescriptor(P_0);
	}

	[RequiresUnreferencedCode("The Type of component cannot be statically discovered.")]
	internal static ICustomTypeDescriptor GetDescriptor(object P_0, bool P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentException("component");
		}
		ICustomTypeDescriptor customTypeDescriptor = NodeFor(P_0).GetTypeDescriptor(P_0);
		ICustomTypeDescriptor customTypeDescriptor2 = P_0 as ICustomTypeDescriptor;
		if (!P_1 && customTypeDescriptor2 != null)
		{
			customTypeDescriptor = new MergedTypeDescriptor(customTypeDescriptor2, customTypeDescriptor);
		}
		return customTypeDescriptor;
	}

	[RequiresUnreferencedCode("The Type of component cannot be statically discovered.")]
	internal static ICustomTypeDescriptor GetExtendedDescriptor(object P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentException("component");
		}
		return NodeFor(P_0).GetExtendedTypeDescriptor(P_0);
	}

	private static string GetExtenderCollisionSuffix(MemberDescriptor P_0)
	{
		string result = null;
		IExtenderProvider extenderProvider = ((P_0.Attributes[typeof(ExtenderProvidedPropertyAttribute)] is ExtenderProvidedPropertyAttribute extenderProvidedPropertyAttribute) ? extenderProvidedPropertyAttribute.Provider : null);
		if (extenderProvider != null)
		{
			string text = null;
			if (extenderProvider is IComponent { Site: not null } component)
			{
				text = component.Site.Name;
			}
			if (text == null || text.Length == 0)
			{
				text = (Interlocked.Increment(ref s_collisionIndex) - 1).ToString(CultureInfo.InvariantCulture);
			}
			result = "_" + text;
		}
		return result;
	}

	private static Type GetNodeForBaseType(Type P_0)
	{
		if (P_0.IsInterface)
		{
			return InterfaceType;
		}
		if (P_0 == InterfaceType)
		{
			return null;
		}
		return P_0.BaseType;
	}

	internal static TypeDescriptionProvider GetProviderRecursive(Type P_0)
	{
		return NodeFor(P_0, false);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)]
	public static Type GetReflectionType([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "type");
		return NodeFor(P_0).GetReflectionType(P_0);
	}

	private static TypeDescriptionNode NodeFor(Type P_0)
	{
		return NodeFor(P_0, false);
	}

	private static TypeDescriptionNode NodeFor(Type P_0, bool P_1)
	{
		CheckDefaultProvider(P_0);
		TypeDescriptionNode typeDescriptionNode = null;
		Type type = P_0;
		while (typeDescriptionNode == null)
		{
			typeDescriptionNode = ((TypeDescriptionNode)s_providerTypeTable[type]) ?? ((TypeDescriptionNode)s_providerTable[type]);
			if (typeDescriptionNode != null)
			{
				continue;
			}
			Type nodeForBaseType = GetNodeForBaseType(type);
			if (type == typeof(object) || nodeForBaseType == null)
			{
				lock (s_providerTable)
				{
					typeDescriptionNode = (TypeDescriptionNode)s_providerTable[type];
					if (typeDescriptionNode == null)
					{
						typeDescriptionNode = new TypeDescriptionNode(new ReflectTypeDescriptionProvider());
						s_providerTable[type] = typeDescriptionNode;
					}
				}
			}
			else if (P_1)
			{
				typeDescriptionNode = new TypeDescriptionNode(new DelegatingTypeDescriptionProvider(nodeForBaseType));
				lock (s_providerTable)
				{
					s_providerTypeTable[type] = typeDescriptionNode;
				}
			}
			else
			{
				type = nodeForBaseType;
			}
		}
		return typeDescriptionNode;
	}

	private static TypeDescriptionNode NodeFor(object P_0)
	{
		return NodeFor(P_0, false);
	}

	private static TypeDescriptionNode NodeFor(object P_0, bool P_1)
	{
		TypeDescriptionNode typeDescriptionNode = (TypeDescriptionNode)s_providerTable[P_0];
		if (typeDescriptionNode == null)
		{
			Type type = P_0.GetType();
			if (type.IsCOMObject)
			{
				type = ComObjectType;
			}
			typeDescriptionNode = ((!P_1) ? NodeFor(type) : new TypeDescriptionNode(new DelegatingTypeDescriptionProvider(type)));
		}
		return typeDescriptionNode;
	}

	private static ICollection PipelineFilter(int P_0, ICollection P_1, object P_2, IDictionary P_3)
	{
		IComponent component = P_2 as IComponent;
		ITypeDescriptorFilterService typeDescriptorFilterService = null;
		ISite site = component?.Site;
		if (site != null)
		{
			typeDescriptorFilterService = site.GetService(typeof(ITypeDescriptorFilterService)) as ITypeDescriptorFilterService;
		}
		IList list = P_1 as ArrayList;
		if (typeDescriptorFilterService == null)
		{
			return P_1;
		}
		if (P_3 != null && (list == null || list.IsReadOnly) && P_3[s_pipelineFilterKeys[P_0]] is FilterCacheItem filterCacheItem && filterCacheItem.IsValid(typeDescriptorFilterService))
		{
			return filterCacheItem.FilteredMembers;
		}
		OrderedDictionary orderedDictionary = new OrderedDictionary(P_1.Count);
		bool flag;
		switch (P_0)
		{
		case 0:
			foreach (Attribute item in P_1)
			{
				orderedDictionary[item.TypeId] = item;
			}
			flag = typeDescriptorFilterService.FilterAttributes(component, orderedDictionary);
			break;
		case 1:
		case 2:
			foreach (MemberDescriptor item2 in P_1)
			{
				string name = item2.Name;
				if (orderedDictionary.Contains(name))
				{
					string extenderCollisionSuffix = GetExtenderCollisionSuffix(item2);
					if (extenderCollisionSuffix != null)
					{
						orderedDictionary[name + extenderCollisionSuffix] = item2;
					}
					MemberDescriptor memberDescriptor2 = (MemberDescriptor)orderedDictionary[name];
					extenderCollisionSuffix = GetExtenderCollisionSuffix(memberDescriptor2);
					if (extenderCollisionSuffix != null)
					{
						orderedDictionary.Remove(name);
						orderedDictionary[memberDescriptor2.Name + extenderCollisionSuffix] = memberDescriptor2;
					}
				}
				else
				{
					orderedDictionary[name] = item2;
				}
			}
			flag = ((P_0 != 1) ? typeDescriptorFilterService.FilterEvents(component, orderedDictionary) : typeDescriptorFilterService.FilterProperties(component, orderedDictionary));
			break;
		default:
			flag = false;
			break;
		}
		if (list == null || list.IsReadOnly)
		{
			list = new ArrayList(orderedDictionary.Values);
		}
		else
		{
			list.Clear();
			foreach (object value in orderedDictionary.Values)
			{
				list.Add(value);
			}
		}
		if (flag && P_3 != null)
		{
			ICollection collection;
			switch (P_0)
			{
			case 0:
			{
				Attribute[] array2 = new Attribute[list.Count];
				try
				{
					list.CopyTo(array2, 0);
				}
				catch (InvalidCastException)
				{
					throw new ArgumentException(System.SR.Format("TypeDescriptorExpectedElementType", typeof(Attribute).FullName));
				}
				collection = new AttributeCollection(array2);
				break;
			}
			case 1:
			{
				PropertyDescriptor[] array3 = new PropertyDescriptor[list.Count];
				try
				{
					list.CopyTo(array3, 0);
				}
				catch (InvalidCastException)
				{
					throw new ArgumentException(System.SR.Format("TypeDescriptorExpectedElementType", typeof(PropertyDescriptor).FullName));
				}
				collection = new PropertyDescriptorCollection(array3, true);
				break;
			}
			case 2:
			{
				EventDescriptor[] array = new EventDescriptor[list.Count];
				try
				{
					list.CopyTo(array, 0);
				}
				catch (InvalidCastException)
				{
					throw new ArgumentException(System.SR.Format("TypeDescriptorExpectedElementType", typeof(EventDescriptor).FullName));
				}
				collection = new EventDescriptorCollection(array, true);
				break;
			}
			default:
				collection = null;
				break;
			}
			FilterCacheItem filterCacheItem2 = new FilterCacheItem(typeDescriptorFilterService, collection);
			P_3[s_pipelineFilterKeys[P_0]] = filterCacheItem2;
			P_3.Remove(s_pipelineAttributeFilterKeys[P_0]);
		}
		return list;
	}

	private static ICollection PipelineInitialize(int P_0, ICollection P_1, IDictionary P_2)
	{
		if (P_2 != null)
		{
			bool flag = true;
			if (P_2[s_pipelineInitializeKeys[P_0]] is ICollection collection && collection.Count == P_1.Count)
			{
				IEnumerator enumerator = collection.GetEnumerator();
				IEnumerator enumerator2 = P_1.GetEnumerator();
				while (enumerator.MoveNext() && enumerator2.MoveNext())
				{
					if (enumerator.Current != enumerator2.Current)
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				P_2.Remove(s_pipelineMergeKeys[P_0]);
				P_2.Remove(s_pipelineFilterKeys[P_0]);
				P_2.Remove(s_pipelineAttributeFilterKeys[P_0]);
				P_2[s_pipelineInitializeKeys[P_0]] = P_1;
			}
		}
		return P_1;
	}

	private static ICollection PipelineMerge(int P_0, ICollection P_1, ICollection P_2, object P_3, IDictionary P_4)
	{
		if (P_2 == null || P_2.Count == 0)
		{
			return P_1;
		}
		if (P_4?[s_pipelineMergeKeys[P_0]] is ICollection collection && collection.Count == P_1.Count + P_2.Count)
		{
			IEnumerator enumerator = collection.GetEnumerator();
			IEnumerator enumerator2 = P_1.GetEnumerator();
			bool flag = true;
			while (enumerator2.MoveNext() && enumerator.MoveNext())
			{
				if (enumerator2.Current != enumerator.Current)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				IEnumerator enumerator3 = P_2.GetEnumerator();
				while (enumerator3.MoveNext() && enumerator.MoveNext())
				{
					if (enumerator3.Current != enumerator.Current)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				return collection;
			}
		}
		ArrayList arrayList = new ArrayList(P_1.Count + P_2.Count);
		foreach (object item in P_1)
		{
			arrayList.Add(item);
		}
		foreach (object item2 in P_2)
		{
			arrayList.Add(item2);
		}
		if (P_4 != null)
		{
			ICollection collection2;
			switch (P_0)
			{
			case 0:
			{
				Attribute[] array3 = new Attribute[arrayList.Count];
				arrayList.CopyTo(array3, 0);
				collection2 = new AttributeCollection(array3);
				break;
			}
			case 1:
			{
				PropertyDescriptor[] array2 = new PropertyDescriptor[arrayList.Count];
				arrayList.CopyTo(array2, 0);
				collection2 = new PropertyDescriptorCollection(array2, true);
				break;
			}
			case 2:
			{
				EventDescriptor[] array = new EventDescriptor[arrayList.Count];
				arrayList.CopyTo(array, 0);
				collection2 = new EventDescriptorCollection(array, true);
				break;
			}
			default:
				collection2 = null;
				break;
			}
			P_4[s_pipelineMergeKeys[P_0]] = collection2;
			P_4.Remove(s_pipelineFilterKeys[P_0]);
			P_4.Remove(s_pipelineAttributeFilterKeys[P_0]);
		}
		return arrayList;
	}

	private static void RaiseRefresh(Type P_0)
	{
		Volatile.Read(ref Refreshed)?.Invoke(new RefreshEventArgs(P_0));
	}

	public static void Refresh(Type P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		bool flag = false;
		lock (s_providerTable)
		{
			IDictionaryEnumerator enumerator = s_providerTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DictionaryEntry entry = enumerator.Entry;
				Type type = entry.Key as Type;
				if ((!(type != null) || !P_0.IsAssignableFrom(type)) && !(type == typeof(object)))
				{
					continue;
				}
				TypeDescriptionNode typeDescriptionNode = (TypeDescriptionNode)entry.Value;
				while (typeDescriptionNode != null && !(typeDescriptionNode.Provider is ReflectTypeDescriptionProvider))
				{
					flag = true;
					typeDescriptionNode = typeDescriptionNode.Next;
				}
				if (typeDescriptionNode != null)
				{
					ReflectTypeDescriptionProvider reflectTypeDescriptionProvider = (ReflectTypeDescriptionProvider)typeDescriptionNode.Provider;
					if (reflectTypeDescriptionProvider.IsPopulated(P_0))
					{
						flag = true;
						reflectTypeDescriptionProvider.Refresh(P_0);
					}
				}
			}
		}
		if (flag)
		{
			Interlocked.Increment(ref s_metadataVersion);
			RaiseRefresh(P_0);
		}
	}

	public static void SortDescriptorArray(IList P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "infos");
		ArrayList.Adapter(P_0).Sort(MemberDescriptorComparer.Instance);
	}
}
