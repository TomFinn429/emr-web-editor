namespace DCSoft.Writer.Dom;

public class ElementEnumerateEventArgs
{
	internal bool z0rek;

	internal XTextContainerElement z0tek;

	private object z0yek;

	private int z0uek;

	internal bool z0iek;

	internal bool z0oek;

	internal XTextElement z0pek;

	internal bool z0mek;

	private bool z0nek;

	public bool ReverseMode
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

	public bool Cancel
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

	public object Parameter
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

	public bool ExcludeParagraphFlag
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

	public int HandlerCount => z0uek;

	public bool ExcludeCharElement
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

	public bool CancelChild
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

	public XTextContainerElement Parent => z0tek;

	public XTextElement Element => z0pek;

	internal void z0eek()
	{
		z0uek++;
	}
}
