using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzohh
{
	private object z0eek;

	private bool z0rek = true;

	private string z0tek;

	private bool z0yek;

	private z0ZzZzdbj z0uek;

	private bool z0iek = true;

	private bool z0oek;

	private Encoding z0pek;

	private bool z0mek;

	private string z0nek_jiejie20260327142557;

	private bool z0bek;

	private bool z0vek = true;

	private Dictionary<string, string> z0cek_jiejie20260327142557 = new Dictionary<string, string>();

	public string FileName
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

	public object Tag
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

	public bool ForPrint
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

	public Dictionary<string, string> Parameters => z0cek_jiejie20260327142557;

	public string BasePath
	{
		get
		{
			return z0nek_jiejie20260327142557;
		}
		set
		{
			z0nek_jiejie20260327142557 = value;
		}
	}

	public bool Formated
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

	public z0ZzZzdbj WriterControl
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

	public bool SerializeAttachFiles
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

	public bool FastMode
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

	public bool EnableDocumentSetting
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

	public Encoding ContentEncoding
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

	public bool ImportTemplateGenerateParagraph
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

	public bool IncludeSelectionOnly
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

	public z0ZzZzohh Clone()
	{
		z0ZzZzohh obj = (z0ZzZzohh)MemberwiseClone();
		obj.z0cek_jiejie20260327142557 = new Dictionary<string, string>(z0cek_jiejie20260327142557);
		return obj;
	}
}
