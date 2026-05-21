using System;
using System.ComponentModel;
using System.Text;
using DCSoft.Writer;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzgbj : z0ZzZzvnj
{
	private bool z0tek = true;

	private bool z0yek;

	private bool z0uek = true;

	[NonSerialized]
	private Encoding z0iek = Encoding.UTF8;

	private bool z0oek = true;

	private bool z0pek = true;

	private bool z0mek;

	private Color z0nek = Color.White;

	private DCBackgroundTextOutputMode z0bek = DCBackgroundTextOutputMode.Output;

	private bool z0vek;

	private int z0cek_jiejie20260327142557 = 20;

	private bool z0xek;

	private bool z0zek;

	private bool z0lrk = true;

	private bool z0krk;

	private bool z0jrk;

	private bool z0hrk = true;

	private DocumentOptions z0grk;

	private bool z0frk = true;

	private bool z0drk;

	public bool z0srk = true;

	private bool z0ark;

	private z0ZzZzfbj z0qrk;

	private string z0wrk = "utf-8";

	private z0ZzZzlgh z0erk = (z0ZzZzlgh)2;

	private bool z0rrk;

	private int z0trk = -2147483648;

	[DefaultValue(false)]
	public bool ForPrint
	{
		get
		{
			return z0rrk;
		}
		set
		{
			z0rrk = value;
		}
	}

	[DefaultValue(false)]
	public bool ExcludeLogicDeleted
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[DefaultValue((z0ZzZzlgh)2)]
	public z0ZzZzlgh ViewStyle
	{
		get
		{
			return z0erk;
		}
		set
		{
			z0erk = value;
		}
	}

	public Color PageBackColor
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

	[DefaultValue(20)]
	public int PixelPageSpacing
	{
		get
		{
			return z0cek_jiejie20260327142557;
		}
		set
		{
			z0cek_jiejie20260327142557 = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowMainDocumentBodyWhenMultiDocument
	{
		get
		{
			return z0hrk;
		}
		set
		{
			z0hrk = value;
		}
	}

	[DefaultValue(true)]
	public bool KeepLineBreak
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

	[DefaultValue("utf-8")]
	public string Chartset
	{
		get
		{
			return z0wrk;
		}
		set
		{
			z0wrk = value;
		}
	}

	[z0ZzZzuqh]
	public Encoding ContentEncoding
	{
		get
		{
			if (z0iek == null)
			{
				if (z0trk != -2147483648)
				{
					z0iek = z0ZzZzqik.z0eek(z0trk);
				}
				else
				{
					z0iek = Encoding.UTF8;
				}
			}
			return z0iek;
		}
		set
		{
			if (value == null)
			{
				z0iek = Encoding.Default;
			}
			else
			{
				z0iek = value;
			}
			z0trk = z0iek.CodePage;
		}
	}

	[DefaultValue(DCBackgroundTextOutputMode.Output)]
	public DCBackgroundTextOutputMode BackgroundTextOutputMode
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

	[DefaultValue(null)]
	public DocumentOptions DocumentOptions
	{
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	[DefaultValue(false)]
	public bool MultiPage
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

	[DefaultValue(true)]
	public bool OutputRowHeight
	{
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableEncryptView
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

	[DefaultValue(true)]
	public bool FixHTMLTableLayout
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

	[DefaultValue(true)]
	public bool OutputHeaderFooter
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
	public bool PrintImgCheckBox
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

	[DefaultValue((z0ZzZzfbj)0)]
	public z0ZzZzfbj ContentRenderMode
	{
		get
		{
			return z0qrk;
		}
		set
		{
			z0qrk = value;
			z0rrk = z0qrk == (z0ZzZzfbj)0 || z0qrk == (z0ZzZzfbj)3;
		}
	}

	[DefaultValue(false)]
	public bool LogUserEditTrack
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

	[DefaultValue(false)]
	public bool UseClassAttribute
	{
		get
		{
			return z0ark;
		}
		set
		{
			z0ark = value;
		}
	}

	[DefaultValue(false)]
	public bool IndentHtmlCode
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoLine
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

	[DefaultValue(false)]
	public bool MultiDocument
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

	[DefaultValue(true)]
	public bool ShowPageBorderLine
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

	[DefaultValue(false)]
	public bool TidyHtmlForPrint
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

	public z0ZzZzgbj z0eek()
	{
		return (z0ZzZzgbj)MemberwiseClone();
	}

	public bool z0rek()
	{
		return !AutoLine;
	}
}
