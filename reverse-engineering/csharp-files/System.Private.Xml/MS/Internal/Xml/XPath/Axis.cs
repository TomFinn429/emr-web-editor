using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal class Axis : AstNode
{
	public enum AxisType
	{
		Ancestor,
		AncestorOrSelf,
		Attribute,
		Child,
		Descendant,
		DescendantOrSelf,
		Following,
		FollowingSibling,
		Namespace,
		Parent,
		Preceding,
		PrecedingSibling,
		Self,
		None
	}

	private readonly AxisType _axisType;

	private AstNode _input;

	private readonly string _prefix;

	private readonly string _name;

	private readonly XPathNodeType _nodeType;

	protected bool abbrAxis;

	private string _urn = string.Empty;

	public override AstType Type => AstType.Axis;

	public override XPathResultType ReturnType => XPathResultType.NodeSet;

	public AstNode Input => _input;

	public string Prefix => _prefix;

	public string Name => _name;

	public XPathNodeType NodeType => _nodeType;

	public AxisType TypeOfAxis => _axisType;

	public bool AbbrAxis => abbrAxis;

	public Axis(AxisType P_0, AstNode P_1, string P_2, string P_3, XPathNodeType P_4)
	{
		_axisType = P_0;
		_input = P_1;
		_prefix = P_2;
		_name = P_3;
		_nodeType = P_4;
	}

	public Axis(AxisType P_0, AstNode P_1)
		: this(P_0, P_1, string.Empty, string.Empty, XPathNodeType.All)
	{
		abbrAxis = true;
	}
}
