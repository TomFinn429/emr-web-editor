using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterTableRowHeightChangingEventArgs : WriterEventArgs
{
	private bool z0eek;

	private float z0rek;

	[JsonIgnore]
	public XTextTableRowElement RowElement => (XTextTableRowElement)base.Element;

	public bool Cancel
	{
		[JSInvokable]
		get
		{
			return z0eek;
		}
		[JSInvokable]
		set
		{
			z0eek = value;
		}
	}

	public float OldHeight
	{
		[JSInvokable]
		get
		{
			return base.Element.Height;
		}
	}

	public float NewHeight
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
		[JSInvokable]
		set
		{
			z0rek = value;
		}
	}

	internal WriterTableRowHeightChangingEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextTableRowElement row, float newHeight)
		: base(ctl, document, row)
	{
		z0rek = newHeight;
	}
}
