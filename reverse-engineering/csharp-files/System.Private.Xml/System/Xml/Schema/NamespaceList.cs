using System.Collections;
using System.Text;

namespace System.Xml.Schema;

internal class NamespaceList
{
	public enum ListType
	{
		Any,
		Other,
		Set
	}

	private ListType _type;

	private Hashtable _set;

	private readonly string _targetNamespace;

	public ListType Type => _type;

	public string Excluded => _targetNamespace;

	public ICollection Enumerate
	{
		get
		{
			ListType type = _type;
			if ((uint)type > 1u && type == ListType.Set)
			{
				return _set.Keys;
			}
			throw new InvalidOperationException();
		}
	}

	public NamespaceList()
	{
	}

	public NamespaceList(string P_0, string P_1)
	{
		_targetNamespace = P_1;
		P_0 = P_0.Trim();
		if (P_0 == "##any" || P_0.Length == 0)
		{
			_type = ListType.Any;
			return;
		}
		if (P_0 == "##other")
		{
			_type = ListType.Other;
			return;
		}
		_type = ListType.Set;
		_set = new Hashtable();
		string[] array = XmlConvert.SplitString(P_0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == "##local")
			{
				_set[string.Empty] = string.Empty;
				continue;
			}
			if (array[i] == "##targetNamespace")
			{
				_set[P_1] = P_1;
				continue;
			}
			XmlConvert.ToUri(array[i]);
			_set[array[i]] = array[i];
		}
	}

	public virtual bool Allows(string P_0)
	{
		switch (_type)
		{
		case ListType.Any:
			return true;
		case ListType.Other:
			if (P_0 != _targetNamespace)
			{
				return P_0.Length != 0;
			}
			return false;
		case ListType.Set:
			return _set[P_0] != null;
		default:
			return false;
		}
	}

	public bool Allows(XmlQualifiedName P_0)
	{
		return Allows(P_0.Namespace);
	}

	public override string ToString()
	{
		switch (_type)
		{
		case ListType.Any:
			return "##any";
		case ListType.Other:
			return "##other";
		case ListType.Set:
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (string key in _set.Keys)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(' ');
				}
				if (key == _targetNamespace)
				{
					stringBuilder.Append("##targetNamespace");
				}
				else if (key.Length == 0)
				{
					stringBuilder.Append("##local");
				}
				else
				{
					stringBuilder.Append(key);
				}
			}
			return stringBuilder.ToString();
		}
		default:
			return string.Empty;
		}
	}
}
