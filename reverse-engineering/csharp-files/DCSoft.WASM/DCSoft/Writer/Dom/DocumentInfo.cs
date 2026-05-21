using System;
using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

public class DocumentInfo : z0ZzZzcuk
{
	private string z0brk;

	private string z0vrk;

	private int z0crk;

	private SubDocumentSettings z0xrk;

	private string z0zrk;

	private DateTime z0ltk = z0ZzZzkfh.z0wrk;

	private DCBooleanValue z0ktk = DCBooleanValue.Inherit;

	private string z0jtk;

	private string z0htk;

	private string z0gtk;

	private bool z0ftk;

	private int z0dtk;

	private static readonly string z0stk = "DCSoft.Writer Version:" + typeof(DocumentInfo).Assembly.GetName().Version;

	private int z0atk;

	private bool z0qtk;

	private int z0wtk;

	private string z0etk;

	private string z0rtk;

	private bool z0ttk;

	private int z0ytk;

	private bool z0utk;

	private string z0itk;

	private float z0otk = 1f;

	private DateTime z0ptk = z0ZzZzkfh.z0wrk;

	[NonSerialized]
	private string z0mtk;

	private string z0ntk = z0stk;

	private int z0btk;

	private bool z0vtk = true;

	private string z0ctk;

	private int z0xtk;

	private DateTime z0ztk = z0ZzZzkfh.z0wrk;

	private string z0lyk;

	private int z0kyk;

	private bool z0jyk;

	private int z0hyk;

	private string z0gyk;

	private string z0fyk;

	[DefaultValue(DCBooleanValue.Inherit)]
	public DCBooleanValue ShowHeaderBottomLine
	{
		get
		{
			return z0ktk;
		}
		set
		{
			z0ktk = value;
			z0ttk = true;
		}
	}

	public int z0eek()
	{
		return z0btk;
	}

	public void z0eek(string p0)
	{
		z0jtk = p0;
	}

	public void z0eek(int p0)
	{
		z0atk = p0;
	}

	public float z0rek()
	{
		return z0otk;
	}

	public void z0rek(string p0)
	{
		z0zrk = p0;
	}

	public void z0tek(string p0)
	{
		z0vrk = p0;
	}

	public void z0rek(int p0)
	{
		z0wtk = p0;
	}

	public void z0yek(string p0)
	{
		z0brk = p0;
	}

	public int z0tek()
	{
		return z0dtk;
	}

	public DocumentInfo z0yek()
	{
		DocumentInfo documentInfo = (DocumentInfo)MemberwiseClone();
		if (z0xrk != null)
		{
			documentInfo.z0xrk = z0xrk.Clone();
		}
		return documentInfo;
	}

	public int z0uek()
	{
		return z0kyk;
	}

	public bool z0iek_jiejie20260327142557()
	{
		return z0vtk;
	}

	public DateTime z0oek()
	{
		return z0ztk;
	}

	public void z0eek(DateTime p0)
	{
		z0ztk = p0;
	}

	public void z0eek(bool p0)
	{
		z0ftk = p0;
	}

	public bool z0pek()
	{
		return z0ftk;
	}

	public string z0mek()
	{
		return z0rtk;
	}

	public string z0nek()
	{
		return z0gyk;
	}

	public void z0rek(bool p0)
	{
		z0ttk = p0;
	}

	public void z0tek(int p0)
	{
		z0dtk = p0;
	}

	public void z0uek(string p0)
	{
		z0itk = p0;
	}

	public string z0bek()
	{
		return z0lyk;
	}

	public void z0tek(bool p0)
	{
		z0jyk = p0;
	}

	public void z0iek_jiejie20260327142557(string p0)
	{
		z0fyk = p0;
	}

	public void z0oek(string p0)
	{
		z0mtk = p0;
	}

	public int z0vek()
	{
		return z0xtk;
	}

	public string z0cek()
	{
		return z0itk;
	}

	public void z0yek(int p0)
	{
		z0crk = p0;
	}

	public void z0pek(string p0)
	{
		z0htk = p0;
	}

	public string z0xek()
	{
		return z0fyk;
	}

	public string z0zek()
	{
		return z0mtk;
	}

	public void z0mek(string p0)
	{
		z0gtk = p0;
	}

	public bool z0lrk()
	{
		return z0jyk;
	}

	public void z0rek(DateTime p0)
	{
		z0ltk = p0;
	}

	public int z0krk()
	{
		return z0ytk;
	}

	public void z0nek(string p0)
	{
		z0gyk = p0;
	}

	public void z0yek(bool p0)
	{
		z0qtk = p0;
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public void z0bek(string p0)
	{
		z0etk = p0;
	}

	public string z0jrk()
	{
		return z0zrk;
	}

	public void z0vek(string p0)
	{
		z0rtk = p0;
	}

	public string z0hrk()
	{
		return z0brk;
	}

	public string z0grk()
	{
		return z0htk;
	}

	public void z0cek(string p0)
	{
		z0ctk = p0;
	}

	public void z0uek(bool p0)
	{
		z0vtk = p0;
	}

	public SubDocumentSettings z0frk()
	{
		return z0xrk;
	}

	public void z0uek(int p0)
	{
		z0btk = p0;
	}

	public bool z0drk()
	{
		return z0utk;
	}

	public string z0srk()
	{
		return z0vrk;
	}

	public void z0eek(SubDocumentSettings p0)
	{
		z0xrk = p0;
	}

	public string z0ark()
	{
		return z0gtk;
	}

	public int z0qrk()
	{
		return z0wtk;
	}

	public void z0iek_jiejie20260327142557(int p0)
	{
		z0hyk = p0;
	}

	public DateTime z0wrk()
	{
		return z0ltk;
	}

	public void z0oek(int p0)
	{
		z0xtk = p0;
	}

	public string z0erk()
	{
		return z0jtk;
	}

	public bool z0rrk()
	{
		return z0qtk;
	}

	public string z0trk()
	{
		return z0etk;
	}

	public void z0xek(string p0)
	{
		z0ntk = p0;
	}

	public int z0yrk()
	{
		return z0atk;
	}

	public void z0eek(float p0)
	{
		z0otk = p0;
		z0qtk = true;
	}

	public override string ToString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public int z0urk()
	{
		return z0hyk;
	}

	public int z0irk()
	{
		return z0crk;
	}

	public string z0ork()
	{
		return z0ntk;
	}

	public bool z0prk()
	{
		return z0ttk;
	}

	public void z0iek_jiejie20260327142557(bool p0)
	{
		z0utk = p0;
	}

	public void z0zek(string p0)
	{
		z0lyk = p0;
	}

	public string z0mrk()
	{
		return z0ctk;
	}

	public void z0pek(int p0)
	{
		z0kyk = p0;
	}

	public string DCWriteString()
	{
		return ToString();
	}

	public DateTime z0nrk()
	{
		return z0ptk;
	}

	public void z0mek(int p0)
	{
		z0ytk = p0;
	}

	public void z0tek(DateTime p0)
	{
		z0ptk = p0;
	}
}
