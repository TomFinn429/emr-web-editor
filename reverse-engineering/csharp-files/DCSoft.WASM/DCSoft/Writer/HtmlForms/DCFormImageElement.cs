using System;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormImageElement : DCFormElement
{
	private new float z0pek;

	private new static readonly string z0mek = "data:image/bmp;base64,";

	private new static readonly string z0nek = "data:image/jpeg;base64,";

	private new string z0bek;

	private new z0ZzZzpmk z0vek;

	private new string z0cek;

	private new static readonly string z0xek = "data:image/png;base64,";

	private new float z0zek;

	private new static readonly string z0lrk = "data:image/gif;base64,";

	public new z0ZzZzedh z0eek()
	{
		return z0vek?.Value;
	}

	public DCFormImageElement(XTextImageElement element)
		: base(element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		z0vek = element.z0frk();
		if (element.z0eek())
		{
			z0vek = element.z0ny();
		}
		z0zek = element.z0xyk();
		z0pek = element.z0utk();
		z0cek = element.z0mek();
		z0bek = element.z0tek();
		z0tek(element.z0vrk());
	}

	public void z0eek(float p0)
	{
		z0zek = p0;
	}

	public new string z0rek()
	{
		if (!string.IsNullOrEmpty(z0cek))
		{
			return z0cek;
		}
		if (z0vek != null && z0vek.HasContent)
		{
			return z0rek(z0vek.ImageData);
		}
		return null;
	}

	public DCFormImageElement()
	{
	}

	public new byte[] z0tek()
	{
		return z0vek?.ImageData;
	}

	public string z0yek_jiejie20260327142557()
	{
		return z0cek;
	}

	public new void z0eek(string p0)
	{
		z0bek = p0;
	}

	public override int z0oq(string p0, XTextDocument p1)
	{
		if (!(z0qrk is XTextImageElement xTextImageElement) || !xTextImageElement.z0rek(p0, p1: true))
		{
			return 0;
		}
		return 1;
	}

	public new float z0uek()
	{
		return z0zek;
	}

	public void z0eek(z0ZzZzedh p0)
	{
		if (p0 == null)
		{
			z0vek = null;
		}
		else
		{
			z0vek = new z0ZzZzpmk(p0);
		}
	}

	public new string z0iek()
	{
		return z0bek;
	}

	public void z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			z0vek = null;
		}
		else
		{
			z0vek = new z0ZzZzpmk(p0);
		}
	}

	private string z0rek(byte[] p0)
	{
		if (p0 != null)
		{
			if (z0ZzZzpuk.z0tek(p0))
			{
				return z0mek + Convert.ToBase64String(p0);
			}
			if (z0ZzZzpuk.z0yek(p0))
			{
				return z0xek + Convert.ToBase64String(p0);
			}
			if (z0ZzZzpuk.z0eek(p0))
			{
				return z0lrk + Convert.ToBase64String(p0);
			}
			z0ZzZzpuk.z0uek(p0);
			return z0nek + Convert.ToBase64String(p0);
		}
		return null;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("PixelWidth", z0uek().ToString());
		p0.Add("PixelHeight", z0oek().ToString());
		p0.Add("ImageSource", z0yek_jiejie20260327142557());
		p0.Add("Alt", z0iek());
		p0.Add("RuntimeImageSource", z0rek());
	}

	public new float z0oek()
	{
		return z0pek;
	}

	public void z0rek(float p0)
	{
		z0pek = p0;
	}

	public new void z0rek(string p0)
	{
		z0cek = p0;
	}
}
