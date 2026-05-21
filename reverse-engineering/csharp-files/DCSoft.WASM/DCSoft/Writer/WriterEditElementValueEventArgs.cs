using System.Text.Json.Serialization;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class WriterEditElementValueEventArgs : WriterEventArgs
{
	private ElementValueEditResult z0eek;

	private bool z0rek;

	private z0ZzZznnj z0tek;

	public bool Handled
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[JsonIgnore]
	public XTextInputFieldElement FieldElement => base.Element as XTextInputFieldElement;

	public ElementValueEditResult Result
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	[JsonIgnore]
	public z0ZzZznnj Editor => z0tek;

	public WriterEditElementValueEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextElement element, z0ZzZznnj editor)
		: base(ctl, document, element)
	{
		z0tek = editor;
	}
}
