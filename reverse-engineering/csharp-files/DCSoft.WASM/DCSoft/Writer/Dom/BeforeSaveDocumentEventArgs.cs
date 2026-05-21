using System.Text;

namespace DCSoft.Writer.Dom;

public class BeforeSaveDocumentEventArgs
{
	private bool z0oek;

	private bool z0pek;

	private string z0mek;

	private object z0nek;

	private string z0bek;

	private Encoding z0vek;

	public object z0eek()
	{
		return z0nek;
	}

	public string z0rek()
	{
		return z0mek;
	}

	public bool z0tek()
	{
		return z0oek;
	}

	public Encoding z0yek()
	{
		return z0vek;
	}

	public void z0eek(bool p0)
	{
		z0pek = p0;
	}

	public string z0uek()
	{
		return z0bek;
	}

	internal BeforeSaveDocumentEventArgs(object output, string fileName, string format, bool backgroundMode, Encoding contentEncoding)
	{
		z0nek = output;
		z0bek = fileName;
		z0mek = format;
		z0oek = backgroundMode;
		z0vek = contentEncoding;
	}

	public bool z0iek()
	{
		return z0pek;
	}
}
