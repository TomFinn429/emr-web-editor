using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class Group : AstNode
{
	private readonly AstNode _groupNode;

	public override AstType Type => AstType.Group;

	public override XPathResultType ReturnType => XPathResultType.NodeSet;

	public AstNode GroupNode => _groupNode;

	public Group(AstNode P_0)
	{
		_groupNode = P_0;
	}
}
