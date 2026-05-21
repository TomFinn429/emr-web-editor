using System.ComponentModel;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

public class SubDocumentSettings
{
	private Color z0eek_jiejie20260327142557 = Color.Transparent;

	private float z0rek;

	private Color z0tek = Color.Transparent;

	private bool z0yek;

	private bool z0uek;

	private bool z0iek = true;

	private bool z0oek_jiejie20260327142557;

	private bool z0pek;

	[DefaultValue(true)]
	public bool AllowSave
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

	[DefaultValue(false)]
	public bool NewPage
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

	[DefaultValue(0f)]
	public float SubDocumentSpacing
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

	public Color BorderColor
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

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public string BackColorValue
	{
		get
		{
			return z0ZzZzlok.z0eek(BackColor, Color.Transparent);
		}
		set
		{
			BackColor = z0ZzZzlok.z0eek(value, Color.Transparent);
		}
	}

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public string BorderColorValue
	{
		get
		{
			return z0ZzZzlok.z0eek(BorderColor, Color.Transparent);
		}
		set
		{
			BorderColor = z0ZzZzlok.z0eek(value, Color.Transparent);
		}
	}

	[DefaultValue(false)]
	public bool Readonly
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

	[DefaultValue(false)]
	public bool Locked
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

	[DefaultValue(false)]
	public bool EnablePermission
	{
		get
		{
			return z0oek_jiejie20260327142557;
		}
		set
		{
			z0oek_jiejie20260327142557 = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return z0eek_jiejie20260327142557;
		}
		set
		{
			z0eek_jiejie20260327142557 = value;
		}
	}

	public SubDocumentSettings Clone()
	{
		return (SubDocumentSettings)MemberwiseClone();
	}
}
