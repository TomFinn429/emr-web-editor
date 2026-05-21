using System.Xml.XPath;

namespace MS.Internal.Xml.XPath;

internal sealed class Variable : AstNode
{
	private readonly string _localname;

	private readonly string _prefix;

	public override AstType Type => AstType.Variable;

	public override XPathResultType ReturnType => XPathResultType.Any;

	public string Localname => _localname;

	public string Prefix => _prefix;

	public Variable(string P_0, string P_1)
	{
		_localname = P_0;
		_prefix = P_1;
	}
}
