using System;
using System.Collections.Generic;
using System.Diagnostics;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Comment:{Text}")]
[z0ZzZziqh("Comment")]
public class DocumentComment : IDisposable
{
	private DateTime z0crk = z0ZzZzkfh.z0wrk;

	private bool z0xrk;

	private Color z0zrk = z0qtk;

	[NonSerialized]
	private float z0ltk;

	private Color z0ktk_jiejie20260327142557 = Color.Black;

	[NonSerialized]
	private object z0jtk;

	private Color z0htk = Color.Red;

	private string z0gtk;

	[NonSerialized]
	private bool z0ftk;

	private string z0dtk;

	private string z0stk;

	private string z0atk;

	private static readonly Color z0qtk = Color.FromArgb(255, 213, 213);

	[NonSerialized]
	private XTextElement z0wtk;

	[NonSerialized]
	private int z0etk = -1;

	[NonSerialized]
	private float z0rtk;

	[NonSerialized]
	private float z0ttk_jiejie20260327142557;

	private string z0ytk;

	[NonSerialized]
	private float z0utk = -1f;

	private XAttributeList z0itk = new XAttributeList();

	[NonSerialized]
	internal bool z0otk;

	private bool z0ptk = true;

	private int z0mtk = -1;

	[NonSerialized]
	private float z0ntk;

	private int z0btk;

	[NonSerialized]
	private XTextElementList z0vtk;

	[NonSerialized]
	private XTextDocument z0ctk;

	[NonSerialized]
	private float z0xtk;

	private string z0ztk;

	private string z0lyk;

	[NonSerialized]
	private float z0kyk;

	internal bool z0jyk;

	[NonSerialized]
	private bool z0hyk = true;

	[NonSerialized]
	private int z0gyk = -1;

	[NonSerialized]
	private float z0fyk = -1f;

	public void z0eek(string p0)
	{
		if (z0gtk != p0)
		{
			z0gtk = p0;
			z0fyk = -1f;
			z0yek(p0: true);
		}
	}

	public string z0eek()
	{
		return z0dtk;
	}

	public float z0rek()
	{
		return z0fyk;
	}

	public int z0tek()
	{
		return z0btk;
	}

	public DocumentComment z0yek()
	{
		return (DocumentComment)MemberwiseClone();
	}

	public void z0eek(bool p0)
	{
		z0xrk = p0;
	}

	public bool z0uek()
	{
		return z0otk;
	}

	public string z0iek()
	{
		return z0ZzZzlok.z0eek(z0ktk_jiejie20260327142557, Color.Black);
	}

	public bool z0oek()
	{
		return z0hyk;
	}

	public void z0eek(XAttributeList p0)
	{
		z0itk = p0;
	}

	public void z0rek(string p0)
	{
		if (z0dtk != p0)
		{
			z0dtk = p0;
			z0yek(p0: true);
		}
	}

	public void z0eek(float p0)
	{
		z0xtk = p0;
	}

	public z0ZzZzwrj z0pek()
	{
		XTextElement xTextElement = z0vrk();
		if (xTextElement == null || !z0oek())
		{
			return null;
		}
		return xTextElement.z0ptk()?.z0dtk();
	}

	public float z0mek()
	{
		return z0utk;
	}

	public void z0eek(out int p0, out int p1)
	{
		p0 = -1;
		p1 = -1;
		z0ZzZzplh z0ZzZzplh = z0ctk.z0xyk().z0frk();
		if (z0otk)
		{
			if (z0vtk == null)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0vtk.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				int num = z0ZzZzplh.z0lrk(current);
				if (num >= 0)
				{
					if (p0 == -1 || p0 > num)
					{
						p0 = num;
					}
					if (p1 == -1 || p1 < num)
					{
						p1 = num;
					}
				}
			}
			return;
		}
		List<int> list = new List<int>();
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk2 = z0nrk().z0gnk().Styles.z0ltk())
		{
			while (z0bpk2.MoveNext())
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk2.Current;
				if (documentContentStyle.CommentIndex == z0tek())
				{
					list.Add(z0nrk().z0gnk().Styles.IndexOf(documentContentStyle));
				}
			}
		}
		int count = z0ZzZzplh.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzplh).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (xTextElement.z0buk >= 0 && list.Contains(xTextElement.z0buk))
			{
				if (p0 == -1 || p0 > i)
				{
					p0 = i;
				}
				if (p1 == -1 || p1 < i)
				{
					p1 = i;
				}
			}
		}
	}

	public string z0nek()
	{
		return z0ztk;
	}

	public string z0bek()
	{
		return z0lyk;
	}

	public Color z0vek()
	{
		return z0ktk_jiejie20260327142557;
	}

	public float z0cek()
	{
		return z0ntk;
	}

	public object z0xek()
	{
		return z0jtk;
	}

	public void z0rek(float p0)
	{
		if (z0fyk != p0)
		{
			z0fyk = p0;
			z0ftk = true;
		}
	}

	public bool z0zek()
	{
		return z0ftk;
	}

	public void z0eek(int p0)
	{
		z0btk = p0;
	}

	public XAttributeList z0lrk()
	{
		if (z0itk == null)
		{
			z0itk = new XAttributeList();
		}
		return z0itk;
	}

	public string z0krk()
	{
		return z0gtk;
	}

	public void z0tek(float p0)
	{
		if (z0rtk != p0)
		{
			z0rtk = p0;
			z0yek(p0: true);
		}
	}

	public void z0eek(Color p0)
	{
		if (z0htk != p0)
		{
			z0htk = p0;
			z0yek(p0: true);
		}
	}

	public bool z0jrk()
	{
		return z0xrk;
	}

	public void z0eek(object p0)
	{
		z0jtk = p0;
	}

	public override string ToString()
	{
		return z0tek() + " " + z0krk() + ":" + z0nek();
	}

	public float z0hrk()
	{
		return z0xtk;
	}

	public string z0eek(XTextDocument p0)
	{
		string text = z0grk();
		if (string.IsNullOrEmpty(text))
		{
			try
			{
				text = z0mrk().ToString(z0ZzZzkfh.z0qrk);
				if (p0 != null && !string.IsNullOrEmpty(p0.z0iu().CommentDateFormatString))
				{
					text = z0mrk().ToString(p0.z0iu().CommentDateFormatString);
				}
			}
			catch (Exception ex)
			{
				text = string.Empty;
				z0ZzZzqok.z0rek.z0dh(ex.Message);
			}
		}
		if (!string.IsNullOrEmpty(z0krk()))
		{
			text = z0krk() + "," + text;
		}
		return text;
	}

	public string z0grk()
	{
		return z0atk;
	}

	public Color z0frk()
	{
		return z0zrk;
	}

	public void z0eek(XTextElementList p0)
	{
		z0vtk = p0;
	}

	public float z0drk()
	{
		return z0kyk;
	}

	public string z0srk()
	{
		return z0ZzZzlok.z0eek(z0zrk, z0qtk);
	}

	public void z0rek(Color p0)
	{
		if (z0zrk != p0)
		{
			z0zrk = p0;
			z0yek(p0: true);
		}
	}

	public string z0ark()
	{
		return z0stk;
	}

	public float z0qrk()
	{
		return z0ttk_jiejie20260327142557;
	}

	public void z0yek(float p0)
	{
		if (z0ttk_jiejie20260327142557 != p0)
		{
			z0ttk_jiejie20260327142557 = p0;
			z0yek(p0: true);
		}
	}

	public void z0tek(string p0)
	{
		z0htk = z0ZzZzlok.z0eek(p0, Color.Red);
	}

	public void z0rek(XTextDocument p0)
	{
		if (p0 != null && p0.z0bu().InsertCommentBindingUserTrack && z0urk() >= 0 && z0urk() < p0.z0syk().Count)
		{
			int level = p0.z0syk()[z0urk()].z0rek();
			_ = Color.Transparent;
			_ = p0.z0hi().GetTrackVisibleConfig(level)?.BackgroundColor;
		}
	}

	public float z0wrk()
	{
		return z0ltk;
	}

	public float z0erk()
	{
		return z0rtk;
	}

	public void z0yek(string p0)
	{
		z0zrk = z0ZzZzlok.z0eek(p0, z0qtk);
	}

	public void z0uek(string p0)
	{
		z0ktk_jiejie20260327142557 = z0ZzZzlok.z0eek(p0, Color.Black);
	}

	public bool z0rek(int p0)
	{
		if (p0 < 0)
		{
			return false;
		}
		if (z0gyk < 0)
		{
			XTextElementList xTextElementList = z0trk();
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				z0gyk = xTextElementList[0].z0jrk();
				z0etk = xTextElementList[xTextElementList.Count - 1].z0jrk();
			}
			if (z0wtk != null && z0wtk.z0jrk() >= 0)
			{
				z0gyk = z0wtk.z0jrk();
			}
		}
		if (p0 >= z0gyk)
		{
			return p0 <= z0etk;
		}
		return false;
	}

	public void z0rrk()
	{
		if (z0ctk != null && z0ctk.z0ank() != null)
		{
			z0ctk.z0ank().CurrentComment = this;
			if (z0wtk != null)
			{
				z0wtk.z0sr();
			}
			int p = 0;
			int p2 = 0;
			z0eek(out p, out p2);
			if (p >= 0 && p2 >= p)
			{
				z0ctk.z0xyk().z0frk().z0tek(p, p2 - p + 1);
			}
			if (z0ctk.z0cu() != null)
			{
				z0ctk.z0cu().z0zx(p0: true);
			}
			z0ctk.z0ank().z0qb(this, ScrollToViewStyle.Normal);
		}
	}

	public void z0rek(bool p0)
	{
		z0ptk = p0;
	}

	public void z0eek(DateTime p0)
	{
		if (z0crk != p0)
		{
			z0crk = p0;
			z0yek(p0: true);
		}
	}

	public void z0iek(string p0)
	{
		z0lyk = p0;
	}

	public void z0uek(float p0)
	{
		if (z0kyk != p0)
		{
			z0kyk = p0;
			z0yek(p0: true);
		}
	}

	public XTextElementList z0trk()
	{
		if (z0otk)
		{
			return z0vtk;
		}
		if (z0nrk() == null)
		{
			return null;
		}
		if (z0vtk == null)
		{
			z0gyk = -1;
			z0etk = -1;
			z0vtk = new XTextElementList();
			List<int> list = new List<int>();
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0nrk().z0gnk().Styles.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
					if (documentContentStyle.CommentIndex == z0tek())
					{
						list.Add(z0nrk().z0gnk().Styles.IndexOf(documentContentStyle));
					}
				}
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = z0nrk().z0xyk().z0frk().z0ltk();
			while (z0bpk2.MoveNext())
			{
				XTextElement current = z0bpk2.Current;
				if (current.z0pek() >= 0 && list.Contains(current.z0pek()))
				{
					z0vtk.Add(current);
				}
			}
		}
		return z0vtk;
	}

	public void z0tek(Color p0)
	{
		if (z0ktk_jiejie20260327142557 != p0)
		{
			z0ktk_jiejie20260327142557 = p0;
			z0yek(p0: true);
		}
	}

	public void z0tek(bool p0)
	{
		z0hyk = p0;
	}

	public void z0yek(bool p0)
	{
		z0ftk = p0;
	}

	public void z0iek(float p0)
	{
		if (z0ltk != p0)
		{
			z0ltk = p0;
			z0yek(p0: true);
		}
	}

	public bool z0yrk()
	{
		return z0ptk;
	}

	public void z0tek(int p0)
	{
		if (z0mtk != p0)
		{
			z0mtk = p0;
			z0yek(p0: true);
		}
	}

	public void z0oek(string p0)
	{
		z0ytk = p0;
	}

	public void z0oek(float p0)
	{
		if (z0utk != p0)
		{
			z0utk = p0;
			z0ftk = true;
		}
	}

	public void z0tek(XTextDocument p0)
	{
		z0ctk = p0;
	}

	public int z0urk()
	{
		return z0mtk;
	}

	public void z0pek(string p0)
	{
		if (z0ztk != p0)
		{
			z0ztk = p0;
			z0fyk = -1f;
			z0yek(p0: true);
		}
	}

	public void z0eek(XTextElement p0)
	{
		z0wtk = p0;
		z0gyk = -1;
		z0etk = -1;
	}

	public string z0irk()
	{
		return z0ytk;
	}

	public void z0mek(string p0)
	{
		z0stk = p0;
	}

	public string z0ork()
	{
		if (z0vrk() == null)
		{
			return string.Empty;
		}
		return z0vrk().Text;
	}

	public string z0prk()
	{
		return z0ZzZzlok.z0eek(z0htk, Color.Red);
	}

	public DateTime z0mrk()
	{
		return z0crk;
	}

	public XTextDocument z0nrk()
	{
		return z0ctk;
	}

	public void z0nek(string p0)
	{
		z0atk = p0;
	}

	public bool z0eek(z0ZzZzwrj p0)
	{
		if (z0vrk()?.z0jr() == null || p0 == null)
		{
			return false;
		}
		return z0pek() == p0;
	}

	public Color z0brk()
	{
		return z0htk;
	}

	public XTextElement z0vrk()
	{
		return z0wtk;
	}

	public void z0pek(float p0)
	{
		z0ntk = p0;
	}

	public void Dispose()
	{
		z0wtk = null;
		z0itk = null;
		z0gtk = null;
		z0dtk = null;
		z0jtk = null;
		z0ctk = null;
		z0stk = null;
		z0ytk = null;
		if (z0vtk != null)
		{
			z0vtk.Clear();
			z0vtk = null;
		}
		z0ztk = null;
		z0atk = null;
		z0lyk = null;
	}
}
