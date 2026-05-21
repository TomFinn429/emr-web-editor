using System;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using DCSystem_Drawing.Printing;

namespace zzz;

public class z0ZzZzvxj : IDisposable
{
	internal z0ZzZzxdh z0srk = z0ZzZzxdh.z0yek;

	public float z0ark;

	internal bool z0qrk;

	public z0ZzZzlsh z0wrk;

	private PageContentPartyStyle z0erk = PageContentPartyStyle.Body;

	public float z0rrk;

	internal bool z0trk;

	public bool z0yrk = true;

	private bool z0urk;

	internal z0ZzZzqxj z0irk;

	private float z0ork = 1f;

	internal bool z0prk;

	public bool z0mrk = true;

	internal bool z0nrk;

	public z0ZzZzplh z0brk;

	internal XTextContainerElement z0vrk;

	private z0ZzZzwrj z0crk;

	internal z0ZzZzqxj z0xrk;

	internal bool z0zrk;

	private bool z0ltk;

	private InterpolationMode z0ktk;

	private z0ZzZzlrj z0jtk;

	public bool z0htk;

	public z0ZzZzbdh z0gtk = z0ZzZzbdh.z0xek;

	private int z0ftk;

	internal bool z0dtk = true;

	public float z0stk;

	internal XTextElement z0atk;

	private z0ZzZzbdh z0qtk = z0ZzZzbdh.z0xek;

	internal bool z0wtk;

	internal XTextElement z0etk;

	public DocumentViewOptions z0rtk;

	private z0ZzZzbdh z0ttk = z0ZzZzbdh.z0xek;

	public bool z0ytk;

	internal z0ZzZzrfh z0utk = z0ZzZzovj.z0iek.BmpParagraphFlagLeftToRight;

	public z0ZzZzadh z0itk_jiejie20260327142557;

	public float z0otk;

	internal bool z0ptk = true;

	internal bool z0mtk;

	public readonly GraphicsUnit z0ntk;

	internal DocumentSecurityOptions z0btk;

	internal z0ZzZzmxj z0vtk;

	private PageViewMode z0ctk;

	public z0ZzZzlcj z0xtk;

	internal z0ZzZzqbj.z0bnk z0ztk;

	private int z0lyk;

	internal z0ZzZzrfh z0kyk = z0ZzZzovj.z0iek.BmpParagraphFlagRightToLeft;

	internal z0ZzZzudh z0jyk;

	public XTextElement z0hyk;

	public z0ZzZzjpk z0gyk;

	private bool z0fyk = true;

	internal bool z0dyk = true;

	private z0ZzZzbdh z0syk = z0ZzZzbdh.z0xek;

	private bool z0ayk;

	internal z0ZzZzqxj z0qyk;

	public readonly bool z0wyk;

	public bool z0eyk = true;

	internal XTextElement z0ryk;

	private z0ZzZzhkh z0tyk;

	public z0ZzZzvlh z0yyk;

	public bool z0uyk;

	internal XTextContentElement z0iyk;

	internal bool z0oyk;

	internal bool z0pyk = true;

	private XTextElement z0myk;

	protected z0ZzZzbdh[] z0nyk;

	public readonly z0ZzZzcxj z0byk;

	private XTextDocumentContentElement z0vyk_jiejie20260327142557;

	public bool z0cyk = true;

	internal z0ZzZzoxj z0xyk;

	protected z0ZzZzbdh z0zyk = z0ZzZzbdh.z0xek;

	public z0ZzZzrzj z0luk;

	public XTextDocument z0kuk;

	private bool z0juk;

	private int[] z0huk;

	public z0ZzZzadh z0guk;

	internal bool z0fuk = true;

	public z0ZzZzbej z0duk;

	public z0ZzZzlsh z0suk;

	public void z0eek(bool p0)
	{
		z0prk = p0;
	}

	public bool z0eek()
	{
		return z0urk;
	}

	public bool z0rek()
	{
		return z0fyk;
	}

	public void z0eek(z0ZzZzlrj p0)
	{
		z0jtk = p0;
		z0ytk = z0jtk != null && z0jtk.z0vek() == PrintRange.Selection;
	}

	public bool z0tek()
	{
		return z0ayk;
	}

	public void z0rek(bool p0)
	{
		z0urk = p0;
	}

	public float z0eek(z0ZzZzrzj p0)
	{
		return p0.z0eek(z0gyk);
	}

	internal bool z0eek(XTextTableCellElement p0)
	{
		if (z0mek() == null)
		{
			return p0.z0lrk();
		}
		if (z0tyk != null)
		{
			return z0tyk.z0tek(p0);
		}
		return false;
	}

	public float z0eek(z0ZzZzimk p0)
	{
		return z0ZzZzlcj.z0rek(z0gyk.z0vek(), p0);
	}

	internal bool z0eek(XTextContainerElement p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (z0vyk_jiejie20260327142557 == null)
		{
			return p0.z0fek();
		}
		if (z0ltk)
		{
			return p0.z0cek(z0vyk_jiejie20260327142557, z0myk);
		}
		return false;
	}

	public void z0eek(z0ZzZzwrj p0)
	{
		z0crk = p0;
		if (p0 != null)
		{
			z0lyk = p0.z0brk();
			z0stk = p0.z0qrk();
		}
	}

	public bool z0yek()
	{
		if (z0bek() != null)
		{
			return z0bek().HasBoundSelection;
		}
		return false;
	}

	public bool z0eek(z0ZzZzbdh p0)
	{
		if (!z0zyk.z0bek())
		{
			return z0zyk.z0tek(p0);
		}
		return true;
	}

	public void z0tek(bool p0)
	{
		z0fyk = p0;
	}

	public void z0eek(PageContentPartyStyle p0)
	{
		z0erk = p0;
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzimk p1)
	{
		return z0ZzZzlcj.z0rek(z0itk_jiejie20260327142557, p0, p1, 100000, z0ZzZzlsh.z0uek());
	}

	public void z0eek(PageViewMode p0)
	{
		z0ctk = p0;
	}

	internal z0ZzZzvxj(z0ZzZzvxj p0, z0ZzZzcxj p1)
	{
		z0xtk = p0.z0xtk;
		z0juk = p0.z0juk;
		z0eyk = p0.z0eyk;
		z0yrk = p0.z0yrk;
		z0qrk = p0.z0qrk;
		z0htk = p0.z0htk;
		z0ark = p0.z0ark;
		z0xyk = p0.z0xyk;
		z0brk = p0.z0brk;
		z0iyk = p0.z0iyk;
		z0kuk = p0.z0kuk;
		z0atk = p0.z0atk;
		z0wrk = p0.z0wrk;
		z0mrk = p0.z0mrk;
		z0hyk = p0.z0hyk;
		z0rrk = p0.z0rrk;
		z0dyk = p0.z0dyk;
		z0dtk = p0.z0dtk;
		z0etk = p0.z0etk;
		z0zrk = p0.z0zrk;
		z0gyk = p0.z0gyk;
		z0duk = p0.z0gyk.z0frk();
		z0ntk = p0.z0ntk;
		z0itk_jiejie20260327142557 = p0.z0itk_jiejie20260327142557;
		z0cyk = p0.z0cyk;
		z0vtk = p0.z0vtk;
		z0trk = p0.z0trk;
		z0erk = p0.z0erk;
		z0oyk = p0.z0oyk;
		z0wyk = p0.z0wyk;
		z0xrk = p0.z0xrk;
		z0zyk = p0.z0zyk;
		z0suk = p0.z0suk;
		z0guk = p0.z0guk;
		z0stk = p0.z0stk;
		z0ytk = p0.z0ytk;
		z0otk = p0.z0otk;
		z0yyk = p0.z0yyk;
		z0byk = p0.z0byk;
		z0btk = p0.z0btk;
		z0tyk = p0.z0tyk;
		z0fuk = p0.z0fuk;
		z0ptk = p0.z0ptk;
		z0wtk = p0.z0wtk;
		z0srk = p0.z0srk;
		z0uyk = p0.z0uyk;
		z0luk = p0.z0luk;
		z0jyk = p0.z0jyk;
		z0gtk = p0.z0gtk;
		z0rtk = p0.z0rtk;
		z0ttk = p0.z0ttk;
		z0urk = p0.z0urk;
		z0prk = p0.z0uek();
		z0syk = p0.z0syk;
		z0myk = p0.z0myk;
		z0vyk_jiejie20260327142557 = p0.z0vyk_jiejie20260327142557;
		z0nyk = p0.z0nyk;
		z0fyk = p0.z0fyk;
		z0ktk = p0.z0vek();
		z0ltk = p0.z0ltk;
		z0ayk = p0.z0ayk;
		z0ryk = p0.z0ryk;
		z0qyk = p0.z0qyk;
		z0jtk = p0.z0jtk;
		z0crk = p0.z0crk;
		z0qtk = p0.z0qtk;
		z0ftk = p0.z0ftk;
		z0lyk = p0.z0lyk;
		z0huk = p0.z0huk;
		z0ork = p0.z0ork;
		z0ctk = p0.z0ctk;
		z0byk = p1;
		if (p1 == (z0ZzZzcxj)2)
		{
			z0htk = false;
		}
		if (p1 == (z0ZzZzcxj)3 || p1 == (z0ZzZzcxj)5)
		{
			z0pyk = DocumentViewOptions.z0ytk;
		}
	}

	public bool z0uek()
	{
		return z0prk;
	}

	public PageContentPartyStyle z0iek()
	{
		return z0erk;
	}

	public int z0oek()
	{
		return z0lyk;
	}

	public int z0pek()
	{
		return z0ftk;
	}

	public void z0eek(int[] p0)
	{
		z0huk = p0;
	}

	public void Dispose()
	{
		z0xtk = null;
		z0duk = null;
		z0utk = null;
		z0kyk = null;
		z0gyk = null;
		z0guk = null;
		z0itk_jiejie20260327142557 = null;
		z0kuk = null;
		z0rtk = null;
		z0yyk = null;
		z0brk = null;
		z0iyk = null;
		z0atk = null;
		z0hyk = null;
		z0luk = null;
		z0btk = null;
		z0xyk = null;
		z0vtk = null;
		z0xrk = null;
		z0ryk = null;
		z0qyk = null;
		z0vrk = null;
		z0irk = null;
		z0etk = null;
		z0vyk_jiejie20260327142557 = null;
		z0myk = null;
		z0tyk = null;
		z0eek((z0ZzZzlrj)null);
		z0ztk = null;
		z0eek((z0ZzZzwrj)null);
		z0nyk = null;
		z0wrk = null;
		z0suk = null;
		z0jyk = null;
	}

	public XTextDocumentContentElement z0mek()
	{
		return z0vyk_jiejie20260327142557;
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0zyk = p0;
	}

	public z0ZzZzbdh z0nek()
	{
		return z0zyk;
	}

	public z0ZzZzlrj z0bek()
	{
		return z0jtk;
	}

	public InterpolationMode z0vek()
	{
		return z0ktk;
	}

	public void z0eek(int p0)
	{
		z0ftk = p0;
	}

	public z0ZzZzvxj z0cek()
	{
		return (z0ZzZzvxj)MemberwiseClone();
	}

	public void z0eek(string p0, z0ZzZzrzj p1, z0ZzZzimk p2, Color p3, z0ZzZzbdh p4, z0ZzZzlsh p5)
	{
		bool flag = false;
		if (p2 != null && p1.z0pek != p2 && (p1.z0wtk != p2.Size || p1.z0gyk != p2.Bold || p1.z0vtk_jiejie20260327142557 != p2.Italic || p1.z0yyk != p2.Strikeout || p1.z0uyk != p2.Underline))
		{
			flag = true;
		}
		if (flag)
		{
			z0gyk.z0eek(p0, p2, p3, p4, p5);
		}
		else
		{
			z0gyk.z0eek(p0, p1.z0pek, p3, p4, p5);
		}
	}

	public float z0xek()
	{
		return z0ork;
	}

	internal void z0eek(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0oyk = p0.z0snk();
		z0dyk = p0.z0bu().EnableElementEvents;
		z0atk = p0.z0wyk();
		try
		{
			z0ZzZzrfh z0ZzZzrfh2 = z0utk;
			if (z0ZzZzrfh2 != null)
			{
				z0srk = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0ZzZzrfh2.z0iek(), ((z0ZzZzedh)z0ZzZzrfh2).z0yek()), GraphicsUnit.Pixel, GraphicsUnit.Document);
			}
		}
		catch
		{
			z0srk = z0ZzZzrpk.z0eek(new z0ZzZzxdh(9f, 12f), GraphicsUnit.Pixel, GraphicsUnit.Document);
		}
		z0btk = p0.z0hi();
		z0kuk = p0;
		z0rtk = p0.z0iu();
		z0zrk = z0rtk.BothBlackWhenPrint && (p0.z0qtk().Printing || p0.z0qtk().PrintPreviewing || z0byk == (z0ZzZzcxj)5);
		z0cyk = z0rtk.HiddenFieldBorderWhenLostFocus;
		z0jyk = null;
		Color newInputContentUnderlineColor = z0rtk.NewInputContentUnderlineColor;
		if (newInputContentUnderlineColor.A > 0)
		{
			z0jyk = z0ZzZzidh.z0eek(newInputContentUnderlineColor);
		}
		z0dtk = z0rtk.EnableEncryptView;
		z0ptk = z0rtk.ShowParagraphFlag;
		z0trk = z0rtk.HighlightProtectedContent;
		z0wtk = p0.z0hi().ShowPermissionMark;
		z0fuk = p0.z0hi().ShowNewContentMarkForFirstHistory;
		z0yyk = p0.z0zok();
		z0vtk = p0.z0htk();
		z0xyk = p0.z0ank();
		if (z0byk == (z0ZzZzcxj)0)
		{
			z0mrk = true;
		}
		else if ((z0byk == (z0ZzZzcxj)3 || z0byk == (z0ZzZzcxj)2 || z0byk == (z0ZzZzcxj)5) && z0rtk.PrintBackgroundText)
		{
			z0mrk = true;
		}
		else
		{
			z0mrk = false;
		}
		z0rrk = p0.z0iu().EmphasisMarkSize;
		z0wrk = p0.z0zok().z0nek();
		z0suk = p0.z0zok().z0tek();
		z0xtk = p0.z0zok().z0uek();
		z0ark = z0xtk.z0tek();
		DocumentBehaviorOptions documentBehaviorOptions = p0.z0bu();
		z0uyk = documentBehaviorOptions.SpecifyDebugMode;
		z0otk = (float)z0ZzZzrpk.z0eek(GraphicsUnit.Document, GraphicsUnit.Pixel);
	}

	public bool z0zek()
	{
		return z0juk;
	}

	public z0ZzZzwrj z0lrk()
	{
		return z0crk;
	}

	public void z0yek(bool p0)
	{
		z0juk = p0;
	}

	public PageViewMode z0krk()
	{
		return z0ctk;
	}

	public void z0eek(InterpolationMode p0)
	{
		z0gyk.z0eek(p0);
		z0ktk = p0;
	}

	internal z0ZzZzvxj(XTextDocument p0, z0ZzZzjpk p1, z0ZzZzbdh p2, z0ZzZzcxj p3 = (z0ZzZzcxj)0)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("g");
		}
		z0guk = p1.z0lrk();
		z0ntk = p1.z0vek();
		z0itk_jiejie20260327142557 = p1.z0oek();
		z0ktk = p1.z0nek_jiejie20260327142557();
		z0byk = p3;
		z0wyk = z0byk == (z0ZzZzcxj)3 || z0byk == (z0ZzZzcxj)2 || z0byk == (z0ZzZzcxj)5;
		z0gyk = p1;
		z0duk = p1.z0frk();
		z0zyk = p2;
		z0gtk = p2;
		z0nyk = new z0ZzZzbdh[1] { p2 };
		if (p0 != null)
		{
			z0eek(p0);
		}
		if (p3 == (z0ZzZzcxj)3 || p3 == (z0ZzZzcxj)5)
		{
			z0pyk = DocumentViewOptions.z0ytk;
		}
	}

	public z0ZzZzbdh[] z0jrk()
	{
		return z0nyk;
	}

	public void z0rek(int p0)
	{
		z0lyk = p0;
	}

	public float z0eek(z0ZzZzsdh p0)
	{
		return z0ZzZzlcj.z0rek(z0gyk.z0vek(), p0);
	}

	public z0ZzZzbdh z0hrk()
	{
		return z0qtk;
	}

	public bool z0eek(RenderVisibility p0)
	{
		if (p0 == RenderVisibility.All)
		{
			return true;
		}
		if (z0byk == (z0ZzZzcxj)3 && (p0 & RenderVisibility.Print) != RenderVisibility.Print)
		{
			return false;
		}
		return true;
	}

	public static bool z0eek(RenderVisibility p0, z0ZzZzcxj p1)
	{
		if (p0 == RenderVisibility.All)
		{
			return true;
		}
		if (p1 == (z0ZzZzcxj)3 && (p0 & RenderVisibility.Print) != RenderVisibility.Print)
		{
			return false;
		}
		return true;
	}

	public z0ZzZzbdh z0grk()
	{
		return z0ttk;
	}

	public int[] z0frk()
	{
		return z0huk;
	}

	internal void z0eek(XTextDocumentContentElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("dce");
		}
		z0vyk_jiejie20260327142557 = p0;
		z0myk = p0.z0zek();
		z0ltk = z0kuk.z0vek(p0);
		z0brk = p0.z0frk();
		z0tyk = p0.z0oek();
		z0qrk = false;
		if (z0byk == (z0ZzZzcxj)0 && z0vyk_jiejie20260327142557 is XTextDocumentBodyElement && z0ZzZzccj.z0rek(149) && z0kuk.z0lrk(p0: false))
		{
			z0qrk = true;
		}
		if (z0byk != 0 && z0byk != (z0ZzZzcxj)2)
		{
			z0eyk = false;
		}
		z0htk = z0eyk && z0byk == (z0ZzZzcxj)0 && z0vtk != null;
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzimk p1, int p2, z0ZzZzlsh p3)
	{
		return z0ZzZzlcj.z0rek(z0gyk, p0, p1, p2, p3);
	}

	public z0ZzZzxdh z0eek(string p0, z0ZzZzrzj p1, int p2, z0ZzZzlsh p3)
	{
		return z0ZzZzlcj.z0rek(z0itk_jiejie20260327142557, p0, p1, p2, p3);
	}

	public void z0eek(z0ZzZzbdh[] p0)
	{
		z0nyk = p0;
	}

	public void z0uek(bool p0)
	{
		z0ayk = p0;
	}

	public void z0tek(z0ZzZzbdh p0)
	{
		z0syk = p0;
	}

	public z0ZzZzbdh z0drk()
	{
		return z0syk;
	}

	public void z0yek(z0ZzZzbdh p0)
	{
		z0ttk = p0;
	}

	internal void z0rek(InterpolationMode p0)
	{
		if (z0ktk != p0)
		{
			z0gyk.z0eek(p0);
			z0ktk = p0;
		}
	}

	public void z0uek(z0ZzZzbdh p0)
	{
		z0qtk = p0;
	}

	public void z0eek(float p0)
	{
		z0ork = p0;
	}
}
