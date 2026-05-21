using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterAfterExecuteEventExpressionEventArgs
{
	private XTextElement z0eek;

	private string z0rek;

	private XTextElement z0tek;

	private XTextDocument z0yek;

	private z0ZzZzdbj z0uek;

	[JsonIgnore]
	public XTextDocument Document => z0yek;

	[JsonIgnore]
	public XTextElement SourceElement => z0tek;

	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0uek;

	public string TargetPropertyName => z0rek;

	[JsonIgnore]
	public XTextElement TargetElement => z0eek;

	public WriterAfterExecuteEventExpressionEventArgs(z0ZzZzdbj ctl, XTextDocument doc, XTextElement sourceElement, XTextElement targetElement, string targetPropertyName)
	{
		z0uek = ctl;
		z0yek = doc;
		z0tek = sourceElement;
		z0eek = targetElement;
		z0rek = targetPropertyName;
	}
}
