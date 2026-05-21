using zzz;

namespace DCSoft.Writer.Dom;

public class ElementStateDetectEventArgs
{
	private string z0yek;

	private ContentProtectedReason z0uek;

	private bool z0iek;

	private bool z0oek = true;

	private bool z0pek = true;

	private bool z0mek;

	private bool z0nek;

	private XTextElement z0bek;

	private ElementStateDetectEventArgs z0vek;

	private z0ZzZzbcj z0cek = (z0ZzZzbcj)255;

	public bool SetMessage
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

	public z0ZzZzbcj Flags
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

	public bool ForContent
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

	public XTextElement Element
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

	public ContentProtectedReason ProtectedReason
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

	public bool ResetLastContentProtectedInfo
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

	public bool Result
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

	public string Message
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

	public ElementStateDetectEventArgs(XTextElement element, z0ZzZzbcj flags)
	{
		z0bek = element;
		z0cek = flags;
	}

	public ElementStateDetectEventArgs(XTextElement element)
	{
		z0bek = element;
	}

	public bool z0eek()
	{
		return z0mek;
	}

	public void z0eek(bool p0)
	{
		z0mek = p0;
	}

	public ElementStateDetectEventArgs z0rek()
	{
		return (ElementStateDetectEventArgs)MemberwiseClone();
	}

	public ElementStateDetectEventArgs z0tek()
	{
		return z0vek;
	}

	public void z0eek(ElementStateDetectEventArgs p0)
	{
		z0vek = p0;
	}
}
