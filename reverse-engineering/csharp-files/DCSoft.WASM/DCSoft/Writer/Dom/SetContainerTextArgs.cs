using zzz;

namespace DCSoft.Writer.Dom;

public class SetContainerTextArgs
{
	private ContentChangedEventSource z0rek;

	private bool z0tek;

	private string z0yek;

	private z0ZzZzbcj z0uek;

	private string z0iek;

	private bool z0oek = true;

	private bool z0pek;

	private bool z0mek;

	private DocumentContentStyle z0nek;

	private bool z0bek;

	private DocumentContentStyle z0vek;

	private bool z0cek = true;

	private bool z0xek = true;

	private bool z0zek;

	private bool z0lrk = true;

	public bool RaiseDocumentContentChangedEvent
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public DocumentContentStyle NewParagraphStyle
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

	public bool FocusContainer
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

	public bool RaiseEvent
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	public bool DisablePermission
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	public ContentChangedEventSource EventSource
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

	public string NewInnerValue
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public string NewText
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	public bool ShowUI
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	public bool IgnoreDisplayFormat
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	public bool UpdateContent
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	public DocumentContentStyle NewTextStyle
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public z0ZzZzbcj AccessFlags
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public bool LogUndo
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	public bool z0eek_jiejie20260327142557()
	{
		return z0zek;
	}

	public void z0eek_jiejie20260327142557(bool p0)
	{
		z0zek = p0;
	}
}
