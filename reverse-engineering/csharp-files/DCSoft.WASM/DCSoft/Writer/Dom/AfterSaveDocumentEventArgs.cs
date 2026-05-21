using System.Text;

namespace DCSoft.Writer.Dom;

public class AfterSaveDocumentEventArgs
{
	private bool z0iek;

	private object z0oek;

	private Encoding z0pek;

	private string z0mek;

	private string z0nek;

	internal AfterSaveDocumentEventArgs(object output, string fileName, string format, bool backgroundMode, Encoding contentEncoding)
	{
		z0oek = output;
		z0mek = fileName;
		z0nek = format;
		z0iek = backgroundMode;
		z0pek = contentEncoding;
	}

	public object z0eek()
	{
		return z0oek;
	}

	public string z0rek()
	{
		return z0nek;
	}

	public string z0tek()
	{
		return z0mek;
	}

	public Encoding z0yek()
	{
		return z0pek;
	}

	public bool z0uek()
	{
		return z0iek;
	}
}
