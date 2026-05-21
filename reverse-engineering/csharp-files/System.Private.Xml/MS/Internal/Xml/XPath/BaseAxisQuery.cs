using System.Xml.XPath;
using System.Xml.Xsl;

namespace MS.Internal.Xml.XPath;

internal abstract class BaseAxisQuery : Query
{
	internal Query qyInput;

	private readonly bool _nameTest;

	private readonly string _name;

	private readonly string _prefix;

	private string _nsUri;

	private readonly XPathNodeType _typeTest;

	protected XPathNavigator currentNode;

	protected int position;

	protected string Name => _name;

	protected string Namespace => _nsUri;

	protected bool NameTest => _nameTest;

	protected XPathNodeType TypeTest => _typeTest;

	public override int CurrentPosition => position;

	public override XPathNavigator Current => currentNode;

	public override XPathResultType StaticType => XPathResultType.NodeSet;

	protected BaseAxisQuery(Query P_0)
	{
		_name = string.Empty;
		_prefix = string.Empty;
		_nsUri = string.Empty;
		qyInput = P_0;
	}

	protected BaseAxisQuery(Query P_0, string P_1, string P_2, XPathNodeType P_3)
	{
		qyInput = P_0;
		_name = P_1;
		_prefix = P_2;
		_typeTest = P_3;
		_nameTest = P_2.Length != 0 || P_1.Length != 0;
		_nsUri = string.Empty;
	}

	protected BaseAxisQuery(BaseAxisQuery P_0)
		: base(P_0)
	{
		qyInput = Query.Clone(P_0.qyInput);
		_name = P_0._name;
		_prefix = P_0._prefix;
		_nsUri = P_0._nsUri;
		_typeTest = P_0._typeTest;
		_nameTest = P_0._nameTest;
		position = P_0.position;
		currentNode = P_0.currentNode;
	}

	public override void Reset()
	{
		position = 0;
		currentNode = null;
		qyInput.Reset();
	}

	public override void SetXsltContext(XsltContext P_0)
	{
		_nsUri = P_0.LookupNamespace(_prefix);
		qyInput.SetXsltContext(P_0);
	}

	public virtual bool matches(XPathNavigator P_0)
	{
		if (TypeTest == P_0.NodeType || TypeTest == XPathNodeType.All || (TypeTest == XPathNodeType.Text && (P_0.NodeType == XPathNodeType.Whitespace || P_0.NodeType == XPathNodeType.SignificantWhitespace)))
		{
			if (!NameTest)
			{
				return true;
			}
			if ((_name.Equals(P_0.LocalName) || _name.Length == 0) && _nsUri.Equals(P_0.NamespaceURI))
			{
				return true;
			}
		}
		return false;
	}

	public override object Evaluate(XPathNodeIterator P_0)
	{
		ResetCount();
		Reset();
		qyInput.Evaluate(P_0);
		return this;
	}
}
