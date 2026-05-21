using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.ComponentModel;

public class ReferenceConverter : TypeConverter
{
	private struct ReferenceComparer : IComparer<object>
	{
		private readonly ReferenceConverter _converter;

		public ReferenceComparer(ReferenceConverter P_0)
		{
			_converter = P_0;
		}

		public int Compare(object P_0, object P_1)
		{
			string text = _converter.ConvertToString(P_0);
			string text2 = _converter.ConvertToString(P_1);
			return string.Compare(text, text2, StringComparison.InvariantCulture);
		}
	}

	private static readonly string s_none = "(none)";

	private readonly Type _type;

	public ReferenceConverter(Type P_0)
	{
		_type = P_0;
	}

	public override object? ConvertFrom(ITypeDescriptorContext? P_0, CultureInfo? P_1, object P_2)
	{
		if (P_2 is string text)
		{
			string text2 = text.Trim();
			if (!string.Equals(text2, s_none) && P_0 != null)
			{
				if (P_0.GetService(typeof(IReferenceService)) is IReferenceService referenceService)
				{
					object reference = referenceService.GetReference(text2);
					if (reference != null)
					{
						return reference;
					}
				}
				IContainer container = P_0.Container;
				if (container != null)
				{
					object obj = container.Components[text2];
					if (obj != null)
					{
						return obj;
					}
				}
			}
			return null;
		}
		return base.ConvertFrom(P_0, P_1, P_2);
	}

	public override object? ConvertTo(ITypeDescriptorContext? P_0, CultureInfo? P_1, object? P_2, Type P_3)
	{
		if (P_3 == typeof(string))
		{
			if (P_2 != null)
			{
				if (P_0?.GetService(typeof(IReferenceService)) is IReferenceService referenceService)
				{
					string name = referenceService.GetName(P_2);
					if (name != null)
					{
						return name;
					}
				}
				if (!Marshal.IsComObject(P_2) && P_2 is IComponent component)
				{
					string text = component.Site?.Name;
					if (text != null)
					{
						return text;
					}
				}
				return string.Empty;
			}
			return s_none;
		}
		return base.ConvertTo(P_0, P_1, P_2, P_3);
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext? P_0)
	{
		List<object> list = null;
		if (P_0 != null)
		{
			list = new List<object> { null };
			if (P_0.GetService(typeof(IReferenceService)) is IReferenceService referenceService)
			{
				object[] references = referenceService.GetReferences(_type);
				if (references != null)
				{
					for (int i = 0; i < references.Length; i++)
					{
						if (IsValueAllowed(P_0, references[i]))
						{
							list.Add(references[i]);
						}
					}
				}
			}
			else
			{
				IContainer container = P_0.Container;
				if (container != null)
				{
					ComponentCollection components = container.Components;
					foreach (IComponent item in components)
					{
						if (item != null && _type != null && _type.IsInstanceOfType(item) && IsValueAllowed(P_0, item))
						{
							list.Add(item);
						}
					}
				}
			}
			list.Sort(new ReferenceComparer(this));
		}
		return new StandardValuesCollection(list);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext? P_0)
	{
		return true;
	}

	protected virtual bool IsValueAllowed(ITypeDescriptorContext P_0, object P_1)
	{
		return true;
	}
}
