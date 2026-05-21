using System;
using System.Text.Json.Serialization;
using zzz;

namespace DCSoft.Writer.Controls;

public class StatusTextChangedEventArgs : EventArgs
{
	private string z0eek;

	private z0ZzZzdbj z0rek;

	public string StatusText => z0eek;

	[JsonIgnore]
	public z0ZzZzdbj WriterControl => z0rek;

	public StatusTextChangedEventArgs(z0ZzZzdbj ctl, string statusText)
	{
		z0rek = ctl;
		z0eek = statusText;
	}
}
