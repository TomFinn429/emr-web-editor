using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using Microsoft.JSInterop;
using zzz;

namespace DCSoft.Writer;

public class WriterTableRowHeightChangedEventArgs : WriterEventArgs
{
	private float z0eek;

	private float z0rek;

	public float NewHeight
	{
		[JSInvokable]
		get
		{
			return z0eek;
		}
	}

	[JsonIgnore]
	public XTextTableRowElement RowElement => (XTextTableRowElement)base.Element;

	public float OldHeight
	{
		[JSInvokable]
		get
		{
			return z0rek;
		}
	}

	internal WriterTableRowHeightChangedEventArgs(z0ZzZzdbj ctl, XTextDocument document, XTextTableRowElement row, float oldHeight, float newHeight)
		: base(ctl, document, row)
	{
		z0rek = oldHeight;
		z0eek = newHeight;
	}
}
