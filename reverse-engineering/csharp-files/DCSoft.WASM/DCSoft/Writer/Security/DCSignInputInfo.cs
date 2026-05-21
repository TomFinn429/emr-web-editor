using System;
using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Security;

public class DCSignInputInfo
{
	private string z0rek;

	private string z0tek;

	private int z0yek = -1;

	private bool z0uek;

	private string z0iek_jiejie20260327142557;

	private z0ZzZzhuk z0oek;

	private string z0pek;

	private string z0mek;

	private string z0nek;

	private float z0bek;

	private float z0vek;

	private DateTime z0cek = DateTime.MinValue;

	private string z0xek;

	private byte[] z0zek;

	private bool z0lrk;

	private string z0krk;

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string RecordID
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

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string UserID
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

	public string ProviderName
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	public int SpecifyInsertElementIndex
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

	public bool InsertSignImageAtCaret
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

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string Description
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

	public float Width
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

	[z0ZzZzyqh]
	public byte[] ImageData
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	public string ElementID
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

	public string ClientName
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

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string UserName
	{
		get
		{
			return z0iek_jiejie20260327142557;
		}
		set
		{
			z0iek_jiejie20260327142557 = value;
		}
	}

	public float Height
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

	public bool ImageInFrontOfText
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

	public string ImageTransparentColor
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

	[z0ZzZztqh]
	public DateTime Time
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

	public void SetAttribute(string name, string Value)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		if (z0oek == null)
		{
			z0oek = new z0ZzZzhuk();
		}
		z0oek.z0eek(name, Value);
	}

	public string GetAttribute(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			throw new ArgumentNullException("name");
		}
		if (z0oek == null)
		{
			return null;
		}
		return z0oek.z0eek(name);
	}

	public void SetImageData(z0ZzZzedh img)
	{
		if (img is z0ZzZzrfh)
		{
			z0zek = ((z0ZzZzrfh)img).z0eek();
		}
		else
		{
			z0zek = null;
		}
	}

	public void SetImageDataByBytes(byte[] imgData)
	{
		z0zek = imgData;
	}

	public z0ZzZzhuk z0eek()
	{
		return z0oek;
	}
}
