using System;
using DCSoft.Drawing;

namespace zzz;

public class z0ZzZzdmj
{
	private float z0nek;

	private ParagraphListStyle z0bek;

	private int z0vek = -1;

	private float z0cek;

	private float z0xek;

	private float z0zek;

	private LineSpacingStyle z0lrk;

	private float z0krk;

	private bool z0jrk;

	public bool z0eek()
	{
		return z0jrk;
	}

	public void z0eek(bool p0)
	{
		z0jrk = p0;
	}

	public float z0rek()
	{
		return z0zek;
	}

	public LineSpacingStyle z0tek()
	{
		return z0lrk;
	}

	public void z0eek(z0ZzZzcok p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("style");
		}
		z0uek(p0.LineSpacing);
		z0rek(p0.LeftIndent);
		z0eek(p0.LineSpacingStyle);
		z0tek(p0.SpacingAfterParagraph);
		z0yek(p0.SpacingBeforeParagraph);
		z0eek(p0.FirstLineIndent);
		z0eek(p0.ParagraphOutlineLevel);
		z0eek(p0.ParagraphMultiLevel);
		z0eek(p0.ParagraphListStyle);
	}

	public float z0yek()
	{
		return z0xek;
	}

	public void z0eek(float p0)
	{
		z0krk = p0;
	}

	public void z0rek(z0ZzZzcok p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("style");
		}
		p0.FirstLineIndent = z0mek();
		p0.LeftIndent = z0pek();
		p0.LineSpacing = z0rek();
		p0.LineSpacingStyle = z0tek();
		p0.SpacingAfterParagraph = z0iek();
		p0.SpacingBeforeParagraph = z0yek();
		p0.ParagraphOutlineLevel = z0uek();
		p0.ParagraphMultiLevel = z0eek();
		p0.ParagraphListStyle = z0oek();
	}

	public void z0eek(LineSpacingStyle p0)
	{
		z0lrk = p0;
	}

	public void z0rek(float p0)
	{
		z0cek = p0;
	}

	public int z0uek()
	{
		return z0vek;
	}

	public void z0tek(float p0)
	{
		z0nek = p0;
	}

	public void z0yek(float p0)
	{
		z0xek = p0;
	}

	public float z0iek()
	{
		return z0nek;
	}

	public ParagraphListStyle z0oek()
	{
		return z0bek;
	}

	public void z0eek(ParagraphListStyle p0)
	{
		z0bek = p0;
	}

	public void z0eek(int p0)
	{
		z0vek = p0;
	}

	public void z0uek(float p0)
	{
		z0zek = p0;
	}

	public float z0pek()
	{
		return z0cek;
	}

	public float z0mek()
	{
		return z0krk;
	}
}
