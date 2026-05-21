using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Xml.Schema;

[DefaultMember("Item")]
internal sealed class SymbolsDictionary
{
	private int _last;

	private readonly Dictionary<XmlQualifiedName, int> _names;

	private Dictionary<string, int> _wildcards;

	private readonly ArrayList _particles;

	private object _particleLast;

	private bool _isUpaEnforced = true;

	public int Count => _last + 1;

	public bool IsUpaEnforced
	{
		get
		{
			return _isUpaEnforced;
		}
		set
		{
			_isUpaEnforced = isUpaEnforced;
		}
	}

	public SymbolsDictionary()
	{
		_names = new Dictionary<XmlQualifiedName, int>();
		_particles = new ArrayList();
	}

	public int AddName(XmlQualifiedName P_0, object P_1)
	{
		if (_names.TryGetValue(P_0, out var num))
		{
			if (_particles[num] != P_1)
			{
				_isUpaEnforced = false;
			}
			return num;
		}
		_names.Add(P_0, _last);
		_particles.Add(P_1);
		return _last++;
	}

	public void AddNamespaceList(NamespaceList P_0, object P_1, bool P_2)
	{
		switch (P_0.Type)
		{
		case NamespaceList.ListType.Any:
			_particleLast = P_1;
			break;
		case NamespaceList.ListType.Other:
			AddWildcard(P_0.Excluded, null);
			if (!P_2)
			{
				AddWildcard(string.Empty, null);
			}
			break;
		case NamespaceList.ListType.Set:
		{
			foreach (string item in P_0.Enumerate)
			{
				AddWildcard(item, P_1);
			}
			break;
		}
		}
	}

	private void AddWildcard(string P_0, object P_1)
	{
		if (_wildcards == null)
		{
			_wildcards = new Dictionary<string, int>();
		}
		if (!_wildcards.TryGetValue(P_0, out var num))
		{
			_wildcards.Add(P_0, _last);
			_particles.Add(P_1);
			_last++;
		}
		else if (P_1 != null)
		{
			_particles[num] = P_1;
		}
	}

	public ICollection GetNamespaceListSymbols(NamespaceList P_0)
	{
		ArrayList arrayList = new ArrayList();
		foreach (KeyValuePair<XmlQualifiedName, int> name in _names)
		{
			XmlQualifiedName key = name.Key;
			if (key != XmlQualifiedName.Empty && P_0.Allows(key))
			{
				arrayList.Add(_names[key]);
			}
		}
		if (_wildcards != null)
		{
			foreach (KeyValuePair<string, int> wildcard in _wildcards)
			{
				if (P_0.Allows(wildcard.Key))
				{
					arrayList.Add(wildcard.Value);
				}
			}
		}
		if (P_0.Type == NamespaceList.ListType.Any || P_0.Type == NamespaceList.ListType.Other)
		{
			arrayList.Add(_last);
		}
		return arrayList;
	}

	public bool Exists(XmlQualifiedName P_0)
	{
		return _names.ContainsKey(P_0);
	}

	public object GetParticle(int P_0)
	{
		if (P_0 != _last)
		{
			return _particles[P_0];
		}
		return _particleLast;
	}
}
