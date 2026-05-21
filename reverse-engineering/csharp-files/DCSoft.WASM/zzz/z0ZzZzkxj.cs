using System.Collections;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzkxj : z0ZzZzoik
{
	private new bool z0eek = true;

	private new bool z0rek = true;

	public bool ExcludeParagraphFlag
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

	public bool ExcludeCharElement
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

	public override object GetParent(object instance)
	{
		return ((XTextElement)instance).z0ji();
	}

	public z0ZzZzkxj(XTextElement p0, bool p1 = false)
	{
		if (p1)
		{
			z0mek = new XTextElement[1] { p0 };
		}
		else
		{
			z0mek = p0.z0be();
			z0tek = p0;
		}
	}

	public override IEnumerable GetChildNodes(object instance)
	{
		return ((XTextElement)instance).z0be();
	}

	public z0ZzZzkxj(XTextElementList p0)
	{
		z0mek = p0;
	}

	public override bool z0wp(object p0)
	{
		if (z0rek && p0 is XTextCharElement)
		{
			return false;
		}
		if (z0eek && p0 is XTextParagraphFlagElement)
		{
			return false;
		}
		return true;
	}
}
