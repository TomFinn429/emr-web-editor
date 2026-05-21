using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class Filter : AstNode
{
	private readonly AstNode _input;

	private readonly AstNode _condition;

	public override AstType Type => AstType.Filter;

	public override XPathResultType ReturnType => XPathResultType.NodeSet;

	public AstNode Input => _input;

	public AstNode Condition => _condition;

	public Filter(AstNode P_0, AstNode P_1)
	{
		_input = P_0;
		_condition = P_1;
	}
}
