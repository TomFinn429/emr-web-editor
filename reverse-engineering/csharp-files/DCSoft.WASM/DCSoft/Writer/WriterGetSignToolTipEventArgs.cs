using System;
using System.Text.Json.Serialization;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using zzz;

namespace DCSoft.Writer;

public class WriterGetSignToolTipEventArgs
{
	private DateTime z0eek = z0ZzZzkfh.z0wrk;

	private DCSignValidateState z0rek;

	private XTextDocument z0tek;

	private string z0yek;

	private string z0uek;

	private string z0iek;

	private XTextSignImageElement z0oek;

	private XTextContainerElement z0pek;

	private string z0mek;

	private string z0nek;

	private string z0bek;

	private bool z0vek;

	[NonSerialized]
	private z0ZzZzdbj z0cek;

	public bool Handled
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[JsonIgnore]
	public XTextDocument Document => z0tek;

	public string UserName => z0uek;

	public string ClientName => z0mek;

	[JsonIgnore]
	public z0ZzZzdbj Control => z0cek;

	public DCSignValidateState State => z0rek;

	public string UserID => z0iek;

	public string ProviderName => z0yek;

	public string Description => z0nek;

	public DateTime Time => z0eek;

	[JsonIgnore]
	public XTextContainerElement ContainerElement => z0pek;

	[JsonIgnore]
	public XTextSignImageElement SignImageElement => z0oek;

	public string ResultTooltip
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	public WriterGetSignToolTipEventArgs(z0ZzZzdbj ctl, XTextDocument doc, XTextContainerElement c, XTextSignImageElement img)
	{
		z0cek = ctl;
		z0tek = doc;
		z0pek = c;
		z0oek = img;
		z0rek = img.SignState;
		z0iek = img.SignUserID;
		z0uek = img.SignUserName;
		z0nek = img.SignMessage;
		z0yek = img.SignProviderName;
		z0mek = img.SignClientName;
		z0eek = img.SignTime;
	}
}
