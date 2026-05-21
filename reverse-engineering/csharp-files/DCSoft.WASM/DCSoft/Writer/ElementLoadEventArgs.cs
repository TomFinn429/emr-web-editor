using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer;

public class ElementLoadEventArgs : ElementEventArgs
{
	private bool z0eek = true;

	public bool z0rek;

	private bool z0tek = true;

	public readonly bool z0yek;

	public readonly bool z0uek;

	private string z0iek;

	public string Format
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

	public bool UpdateExpression
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

	public bool UpdateValueBinding
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

	public ElementLoadEventArgs(XTextElement element, string format)
		: base(element)
	{
		z0iek = format;
		z0yek = z0ZzZzccj.z0rek(127);
		z0uek = z0ZzZzccj.z0rek(126);
	}
}
