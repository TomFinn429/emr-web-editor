using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace System.ComponentModel;

public class AttributeCollection : ICollection, IEnumerable
{
	private struct AttributeEntry
	{
		public Type type;

		public int index;
	}

	public static readonly AttributeCollection Empty = new AttributeCollection((Attribute[]?)null);

	private static Dictionary<Type, Attribute> s_defaultAttributes;

	private readonly Attribute[] _attributes;

	private static readonly object s_internalSyncObject = new object();

	private AttributeEntry[] _foundAttributeTypes;

	private int _index;

	protected internal virtual Attribute[] Attributes => _attributes;

	public int Count => Attributes.Length;

	public virtual Attribute? this[[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0]
	{
		get
		{
			ArgumentNullException.ThrowIfNull(P_0, "attributeType");
			lock (s_internalSyncObject)
			{
				if (_foundAttributeTypes == null)
				{
					_foundAttributeTypes = new AttributeEntry[5];
				}
				int i;
				for (i = 0; i < 5; i++)
				{
					if (_foundAttributeTypes[i].type == P_0)
					{
						int index = _foundAttributeTypes[i].index;
						if (index != -1)
						{
							return Attributes[index];
						}
						return GetDefaultAttribute(P_0);
					}
					if (_foundAttributeTypes[i].type == null)
					{
						break;
					}
				}
				i = _index++;
				if (_index >= 5)
				{
					_index = 0;
				}
				_foundAttributeTypes[i].type = P_0;
				int num = Attributes.Length;
				for (int j = 0; j < num; j++)
				{
					Attribute attribute = Attributes[j];
					Type type = attribute.GetType();
					if (type == P_0)
					{
						_foundAttributeTypes[i].index = j;
						return attribute;
					}
				}
				for (int k = 0; k < num; k++)
				{
					Attribute attribute2 = Attributes[k];
					if (P_0.IsInstanceOfType(attribute2))
					{
						_foundAttributeTypes[i].index = k;
						return attribute2;
					}
				}
				_foundAttributeTypes[i].index = -1;
				return GetDefaultAttribute(P_0);
			}
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	int ICollection.Count => Count;

	public AttributeCollection(params Attribute[]? P_0)
	{
		_attributes = P_0 ?? Array.Empty<Attribute>();
		for (int i = 0; i < _attributes.Length; i++)
		{
			ArgumentNullException.ThrowIfNull(_attributes[i], "attributes");
		}
	}

	protected Attribute? GetDefaultAttribute([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "attributeType");
		lock (s_internalSyncObject)
		{
			if (s_defaultAttributes == null)
			{
				s_defaultAttributes = new Dictionary<Type, Attribute>();
			}
			if (s_defaultAttributes.TryGetValue(P_0, out var result))
			{
				return result;
			}
			Attribute attribute = null;
			Type reflectionType = TypeDescriptor.GetReflectionType(P_0);
			FieldInfo field = reflectionType.GetField("Default", BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField);
			if (field != null && field.IsStatic)
			{
				attribute = (Attribute)field.GetValue(null);
			}
			else
			{
				ConstructorInfo constructor = reflectionType.UnderlyingSystemType.GetConstructor(Type.EmptyTypes);
				if (constructor != null)
				{
					attribute = (Attribute)constructor.Invoke(Array.Empty<object>());
					if (!attribute.IsDefaultAttribute())
					{
						attribute = null;
					}
				}
			}
			s_defaultAttributes[P_0] = attribute;
			return attribute;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return Attributes.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void CopyTo(Array P_0, int P_1)
	{
		Array.Copy(Attributes, 0, P_0, P_1, Attributes.Length);
	}
}
