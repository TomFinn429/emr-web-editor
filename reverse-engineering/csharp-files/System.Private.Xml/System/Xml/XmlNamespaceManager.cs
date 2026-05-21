using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Xml;

public class XmlNamespaceManager : IXmlNamespaceResolver, IEnumerable
{
	private struct NamespaceDeclaration
	{
		public string prefix;

		public string uri;

		public int scopeId;

		public int previousNsIndex;

		public void Set(string P_0, string P_1, int P_2, int P_3)
		{
			prefix = P_0;
			uri = P_1;
			scopeId = P_2;
			previousNsIndex = P_3;
		}
	}

	private NamespaceDeclaration[] _nsdecls;

	private int _lastDecl;

	private readonly XmlNameTable _nameTable;

	private int _scopeId;

	private Dictionary<string, int> _hashTable;

	private bool _useHashtable;

	private readonly string _xml;

	private readonly string _xmlNs;

	public virtual XmlNameTable? NameTable => _nameTable;

	public virtual string DefaultNamespace
	{
		get
		{
			string text = LookupNamespace(string.Empty);
			return text ?? string.Empty;
		}
	}

	internal XmlNamespaceManager()
	{
	}

	public XmlNamespaceManager(XmlNameTable P_0)
	{
		_nameTable = P_0;
		_xml = P_0.Add("xml");
		_xmlNs = P_0.Add("xmlns");
		_nsdecls = new NamespaceDeclaration[8];
		string text = P_0.Add(string.Empty);
		_nsdecls[0].Set(text, text, -1, -1);
		_nsdecls[1].Set(_xmlNs, P_0.Add("http://www.w3.org/2000/xmlns/"), -1, -1);
		_nsdecls[2].Set(_xml, P_0.Add("http://www.w3.org/XML/1998/namespace"), 0, -1);
		_lastDecl = 2;
		_scopeId = 1;
	}

	public virtual void PushScope()
	{
		_scopeId++;
	}

	public virtual bool PopScope()
	{
		int num = _lastDecl;
		if (_scopeId == 1)
		{
			return false;
		}
		while (_nsdecls[num].scopeId == _scopeId)
		{
			if (_useHashtable)
			{
				_hashTable[_nsdecls[num].prefix] = _nsdecls[num].previousNsIndex;
			}
			num--;
		}
		_lastDecl = num;
		_scopeId--;
		return true;
	}

	public virtual void AddNamespace(string P_0, [StringSyntax("Uri")] string P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "prefix");
		ArgumentNullException.ThrowIfNull(P_1, "uri");
		P_0 = _nameTable.Add(P_0);
		P_1 = _nameTable.Add(P_1);
		if (Ref.Equal(_xml, P_0) && !P_1.Equals("http://www.w3.org/XML/1998/namespace"))
		{
			throw new ArgumentException("Xml_XmlPrefix");
		}
		if (Ref.Equal(_xmlNs, P_0))
		{
			throw new ArgumentException("Xml_XmlnsPrefix");
		}
		int num = LookupNamespaceDecl(P_0);
		int num2 = -1;
		if (num != -1)
		{
			if (_nsdecls[num].scopeId == _scopeId)
			{
				_nsdecls[num].uri = P_1;
				return;
			}
			num2 = num;
		}
		if (_lastDecl == _nsdecls.Length - 1)
		{
			NamespaceDeclaration[] array = new NamespaceDeclaration[_nsdecls.Length * 2];
			Array.Copy(_nsdecls, array, _nsdecls.Length);
			_nsdecls = array;
		}
		_nsdecls[++_lastDecl].Set(P_0, P_1, _scopeId, num2);
		if (_useHashtable)
		{
			_hashTable[P_0] = _lastDecl;
		}
		else if (_lastDecl >= 16)
		{
			_hashTable = new Dictionary<string, int>(_lastDecl);
			for (int i = 0; i <= _lastDecl; i++)
			{
				_hashTable[_nsdecls[i].prefix] = i;
			}
			_useHashtable = true;
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(_lastDecl + 1);
		for (int i = 0; i <= _lastDecl; i++)
		{
			if (_nsdecls[i].uri != null)
			{
				dictionary[_nsdecls[i].prefix] = _nsdecls[i].prefix;
			}
		}
		return dictionary.Keys.GetEnumerator();
	}

	public virtual string? LookupNamespace(string P_0)
	{
		int num = LookupNamespaceDecl(P_0);
		if (num != -1)
		{
			return _nsdecls[num].uri;
		}
		return null;
	}

	private int LookupNamespaceDecl(string P_0)
	{
		if (_useHashtable)
		{
			if (_hashTable.TryGetValue(P_0, out var previousNsIndex))
			{
				while (previousNsIndex != -1 && _nsdecls[previousNsIndex].uri == null)
				{
					previousNsIndex = _nsdecls[previousNsIndex].previousNsIndex;
				}
				return previousNsIndex;
			}
			return -1;
		}
		for (int num = _lastDecl; num >= 0; num--)
		{
			if ((object)_nsdecls[num].prefix == P_0 && _nsdecls[num].uri != null)
			{
				return num;
			}
		}
		for (int num2 = _lastDecl; num2 >= 0; num2--)
		{
			if (string.Equals(_nsdecls[num2].prefix, P_0) && _nsdecls[num2].uri != null)
			{
				return num2;
			}
		}
		return -1;
	}

	public virtual string? LookupPrefix([StringSyntax("Uri")] string P_0)
	{
		for (int num = _lastDecl; num >= 0; num--)
		{
			if (string.Equals(_nsdecls[num].uri, P_0))
			{
				string prefix = _nsdecls[num].prefix;
				if (string.Equals(LookupNamespace(prefix), P_0))
				{
					return prefix;
				}
			}
		}
		return null;
	}
}
