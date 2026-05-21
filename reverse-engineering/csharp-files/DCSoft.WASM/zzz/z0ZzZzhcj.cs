using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzhcj
{
	private ContentProtectedReason z0yek;

	private string z0uek;

	private XTextElement z0iek;

	public void z0eek(ContentProtectedReason p0)
	{
		z0yek = p0;
	}

	public void z0eek(string p0)
	{
		z0uek = p0;
	}

	public z0ZzZzhcj(XTextElement p0, string p1, ContentProtectedReason p2)
	{
		z0iek = p0;
		z0uek = p1;
		z0yek = p2;
	}

	public void z0eek(XTextElement p0)
	{
		z0iek = p0;
	}

	public XTextElement z0eek()
	{
		return z0iek;
	}

	public ContentProtectedReason z0rek()
	{
		return z0yek;
	}

	public string z0tek()
	{
		return z0uek;
	}
}
