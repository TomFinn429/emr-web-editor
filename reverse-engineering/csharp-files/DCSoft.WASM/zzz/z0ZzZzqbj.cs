using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzqbj : z0ZzZzxnj
{
	public interface z0bnk : IDisposable
	{
		void z0plk(string p0);

		void z0clk(int p0);

		void z0olk(XTextDocument p0);

		int z0lkk();

		int[] z0xlk(int p0, int p1, z0ZzZzclh p2);

		string z0mlk();

		void z0gkk(JumpPrintInfo p0);

		int z0nlk();

		string z0jkk();

		z0ZzZzlrj z0zlk();

		void z0ulk(int p0);

		bool z0blk();

		void z0kkk(bool p0);

		void z0tlk(bool p0);

		bool z0vlk();

		bool z0ylk();

		void z0hkk(string p0);

		JumpPrintInfo z0ilk();
	}

	internal class z0dgj
	{
		public int z0eek;

		public z0ZzZzwrj z0rek;

		public int z0tek;

		public int z0yek;

		public int z0uek;

		public int z0iek;
	}

	private class z0qgj
	{
		public z0ZzZzndh z0eek = z0ZzZzndh.z0cek;

		public int z0rek = -1;

		public z0ZzZzwrj z0tek;
	}

	[CompilerGenerated]
	private sealed class z0uuk
	{
		public z0ZzZzdbj.z0cxk z0rek;

		internal void z0eek(z0ZzZzezj p0)
		{
			p0.z0tek(p0.z0uek() - z0rek.z0yek.Length);
			p0.z0rek(z0rek.z0yek.Length);
		}
	}

	private bool z0buk = true;

	private z0ZzZzdbj z0vuk;

	internal JumpPrintInfo z0cuk_jiejie20260327142557;

	private static z0ZzZzkeh z0xuk = null;

	private List<z0ZzZzndh> z0zuk;

	private int z0lik;

	internal bool z0kik;

	private DocumentOptions z0jik;

	internal bool z0gik = true;

	internal int z0fik;

	private int z0dik_jiejie20260327142557;

	private static int z0sik = 0;

	internal bool z0aik;

	private z0ZzZzymj z0qik;

	internal bool z0wik;

	private bool z0eik = true;

	internal bool z0rik;

	private z0ZzZzzwh z0tik;

	private bool z0yik;

	private Dictionary<string, Dictionary<string, object>> z0iik = new Dictionary<string, Dictionary<string, object>>();

	internal static bool z0oik = false;

	private z0ZzZzsmk z0pik;

	private long z0mik;

	internal static bool z0nik = false;

	private z0ZzZzznj z0bik;

	internal string z0vik;

	private z0ZzZzueh z0cik;

	private long z0xik;

	private object z0zik;

	private bool z0lok;

	private static readonly z0ZzZzsdh z0kok = new z0ZzZzsdh(z0ZzZzimk.DefaultFontName, 13f, FontStyle.Bold);

	private bool z0jok;

	public bool z0hok;

	private int z0gok;

	public z0ZzZzdcj z0fok;

	private z0ZzZzxbj z0dok;

	private PageTitlePosition z0sok = PageTitlePosition.TopLeft;

	public bool z0aok;

	private XTextElement z0qok;

	private bool z0wok = true;

	private List<z0qgj> z0eok = new List<z0qgj>();

	private long z0rok;

	internal bool z0tok = true;

	private int z0yok;

	private string z0uok = Guid.NewGuid().ToString();

	internal bool z0iok;

	private new bool z0ook;

	private z0ZzZzpxj z0pok;

	private DragOperationState z0mok;

	private bool z0nok;

	internal JumpPrintInfo z0bok = new JumpPrintInfo();

	private static readonly byte[] z0vok = new byte[1] { 254 };

	internal z0bnk z0cok;

	internal bool z0xok = true;

	private z0ZzZzonj z0zok;

	internal bool z0lpk;

	private z0ZzZzyrj z0kpk;

	internal z0ZzZzypj z0jpk;

	private z0ZzZzkeh z0hpk;

	public z0ZzZzclh z0gpk;

	public string z0fpk;

	private List<z0ZzZzymj> z0dpk;

	private bool z0spk;

	public bool z0apk;

	private static readonly string z0qpk = Guid.NewGuid().ToString();

	private bool z0wpk;

	public static long z0epk = 0L;

	[NonSerialized]
	private XTextElement z0rpk;

	private z0ZzZzpnj z0tpk = new z0ZzZzpnj();

	internal bool z0ypk = true;

	internal z0ZzZzndh z0upk = z0ZzZzndh.z0cek;

	internal z0ZzZzerj z0ipk;

	internal int[] z0opk;

	private z0ZzZzgxj z0ppk;

	private readonly string z0mpk;

	private XTextDocument z0npk;

	public bool z0bpk;

	private z0ZzZzoxj z0vpk;

	private bool z0cpk;

	internal bool z0xpk = true;

	internal bool z0zpk = true;

	protected override void z0cjk(z0ZzZzweh p0)
	{
		if (!z0xtk())
		{
			return;
		}
		base.z0cjk(p0);
		if (z0npk != null)
		{
			z0npk.z0bek((z0ZzZzhzj)null);
		}
		if (((z0ZzZzmwh)this).z0vek())
		{
			((z0ZzZzmwh)this).z0rek(p0: false);
		}
		z0qrk();
		if (z0npk == null || z0urk() == WriterControlExtViewMode.BoundsSelection || z0urk() != WriterControlExtViewMode.Normal || z0htk())
		{
			return;
		}
		if (p0.z0yek() == (z0ZzZzqeh)1)
		{
			int num = z0ZzZzwpj.z0rek().z0eek(p0.z0rek(), p0.z0tek());
			if (num == 1)
			{
				if (z0fok != null)
				{
					z0frk();
					return;
				}
				if (z0lpk)
				{
					z0tek(p0, DocumentEventStyles.MouseUp);
					z0lpk = false;
				}
			}
			if (num != 2 && num == 3)
			{
				XTextElement xTextElement = z0tek(p0.z0rek(), p0.z0tek());
				if (!(xTextElement is z0ZzZzlzj) && (xTextElement == null || xTextElement.z0mi()) && z0crk().BehaviorOptions.ThreeClickToSelectParagraph)
				{
					z0npk.z0ryk().z0yek();
				}
			}
		}
		else
		{
			z0tek(p0, DocumentEventStyles.MouseUp);
		}
	}

	public override bool z0gx(int p0, int p1, int p2, int p3, ScrollToViewStyle p4)
	{
		if (!z0wpk)
		{
			return false;
		}
		if (((z0ZzZzspj)this).z0crk)
		{
			((z0ZzZzspj)this).z0crk = false;
			return false;
		}
		z0ZzZzndh z0ZzZzndh2 = ((z0ZzZzspj)this).z0drk().z0eek(p0, p1, p2, p3);
		z0dgj z0dgj = z0tek(PageContentPartyStyle.Body, p0, p1);
		if (z0dgj != null)
		{
			z0ayk()?.z0dlk(z0dgj.z0iek, z0dgj.z0eek, z0dgj.z0yek, (int)((float)z0ZzZzndh2.z0iek() * z0kyk()), (int)((float)z0ZzZzndh2.z0oek() * z0kyk()), p4);
		}
		return false;
	}

	public new void z0tek(int p0)
	{
		if (z0npk != null)
		{
			z0npk.z0ryk().z0uek(p0: true);
			z0npk.z0ryk().z0tek(p0, p1: false);
		}
	}

	internal new WriterDataFormats z0tek()
	{
		return z0crk().BehaviorOptions.CreationDataFormats;
	}

	public new void z0yek()
	{
		z0opk = null;
		z0uyk();
		if (z0rik)
		{
			z0zek(p0: false);
		}
		if (z0npk != null)
		{
			z0npk.z0rpk();
			z0xyk();
			z0hz();
		}
	}

	public void z0tek(string p0)
	{
		z0crk().BehaviorOptions.ExcludeKeywords = p0;
	}

	public new FormViewMode z0uek()
	{
		return z0crk().BehaviorOptions.FormView;
	}

	public new void z0tek(bool p0)
	{
		z0byk().z0hn(p0);
	}

	public override void z0vjk(string p0)
	{
		z0puk();
		if (z0qtk() != null)
		{
			z0qtk().Text = p0;
		}
		z0xyk();
		z0oek();
		z0hz();
	}

	public new void z0yek(bool p0)
	{
		z0crk().BehaviorOptions.DoubleClickToEditComment = p0;
	}

	internal new string z0iek()
	{
		if (z0qtk() == null)
		{
			return null;
		}
		return z0qtk().z0dmk();
	}

	public static bool z0tek(XTextDocument p0, z0ZzZzadh p1, int p2, int p3, float p4)
	{
		z0ZzZzedh z0ZzZzedh2 = p0.PageSettings.z0ark()?.Value;
		z0ZzZzwmk z0ZzZzwmk2 = p0.PageSettings.z0rek();
		if (z0ZzZzedh2 != null || (z0ZzZzwmk2 != null && z0ZzZzwmk2.z0rek()))
		{
			if (z0ZzZzwmk2 != null && z0ZzZzwmk2.z0rek() && z0ZzZzwmk2.Type == WatermarkType.Image)
			{
				z0ZzZzedh2 = null;
			}
			if (z0ZzZzedh2 is z0ZzZzrfh && z0ZzZzedh2.z0iek() > 0 && z0ZzZzedh2.z0yek() > 0)
			{
				for (int i = 0; i < p2; i += z0ZzZzedh2.z0iek())
				{
					for (int j = 0; j < p3; j += z0ZzZzedh2.z0yek())
					{
						p1.z0eek(z0ZzZzedh2, i, j, z0ZzZzedh2.z0iek(), z0ZzZzedh2.z0yek());
					}
				}
			}
			if (z0ZzZzwmk2 != null && z0ZzZzwmk2.z0rek())
			{
				z0ZzZzwmk2 = z0ZzZzwmk2.z0iek();
				if (z0ZzZzwmk2.Font != null)
				{
					z0ZzZzwmk2.Font.Size *= p4;
				}
				int num = (int)Math.Sqrt(p2 * p2 + p3 * p3);
				double num2 = Math.Sqrt(num * num * 2) / 2.0;
				float num3 = 45f - z0ZzZzwmk2.Angle;
				double num4 = (double)(p2 / 2) - num2 * Math.Sin((double)num3 * Math.PI / 180.0);
				double num5 = (double)(p3 / 2) - num2 * Math.Cos((double)num3 * Math.PI / 180.0);
				p1.z0eek((int)num4, (int)num5);
				p1.z0rek(z0ZzZzwmk2.Angle);
				z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(0f, 0f, num, num);
				if (z0ZzZzwmk2.Angle == 0f)
				{
					z0ZzZzbdh2 = new z0ZzZzbdh(0f, 0f, p2, p3);
					p1.z0krk();
				}
				z0ZzZzwmk2.Angle = 0f;
				z0ZzZzwmk2.z0eek(z0ZzZzbdh2, new z0ZzZzjpk(p1), z0ZzZzbdh2);
				p1.z0krk();
			}
			return true;
		}
		return false;
	}

	private new void z0oek()
	{
		z0qtk().z0qmk();
	}

	protected override void z0hx(z0ZzZzheh p0)
	{
		z0xek(p0: false);
		if (z0npk != null)
		{
			z0npk.z0mu(DocumentEventArgs.z0eek(z0npk, p0));
		}
	}

	public bool z0tek(XTextElement p0, bool p1, bool p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0.z0qek() != z0npk?.z0xyk())
		{
			return false;
		}
		float p3 = z0qtk().z0bek(p0, p2);
		z0pek(p0: true);
		z0tek(p3);
		if (p1)
		{
			int num = z0syk().PageIndex;
			if (z0syk().Position < 300f)
			{
				num--;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (base.z0bek() != num)
			{
				z0rek(num);
				z0sc();
			}
			else
			{
				z0hz();
			}
		}
		else
		{
			z0hz();
		}
		return true;
	}

	public XTextElement z0tek(Type p0)
	{
		return z0npk?.z0bek(p0, p1: true);
	}

	public new bool z0pek()
	{
		return z0eik;
	}

	public void z0uek(bool p0)
	{
		z0eik = p0;
	}

	public z0ZzZzkeh z0iek(bool p0)
	{
		z0ZzZzkeh z0ZzZzkeh2 = z0quk().z0xk(z0xek());
		if (z0ZzZzkeh2 != null && z0ZzZzkeh2.z0kj().Length != 0)
		{
			z0hyk();
		}
		WriterDataObjectRange dataObjectRange = z0crk().BehaviorOptions.DataObjectRange;
		InsertDocumentWithCheckMRIDType insertDocumentWithCheckMRID = z0crk().BehaviorOptions.InsertDocumentWithCheckMRID;
		switch (dataObjectRange)
		{
		case WriterDataObjectRange.Application:
			if (z0hpk != null)
			{
				return z0hpk;
			}
			if (z0xuk != null)
			{
				return z0xuk;
			}
			if (p0 && z0luk_jiejie20260327142557() && insertDocumentWithCheckMRID != InsertDocumentWithCheckMRIDType.ForbitWhenFail)
			{
				z0ZzZzfpj.z0tek(this, z0ZzZziok.z0uok());
			}
			return null;
		case WriterDataObjectRange.SingleWriterControl:
			if (z0hpk != null)
			{
				return z0hpk;
			}
			if (p0 && z0luk_jiejie20260327142557() && insertDocumentWithCheckMRID != InsertDocumentWithCheckMRIDType.ForbitWhenFail)
			{
				z0ZzZzfpj.z0tek(this, z0ZzZziok.z0uok());
			}
			return null;
		default:
			if (z0hpk != null)
			{
				return z0hpk;
			}
			if (z0xuk != null)
			{
				return z0xuk;
			}
			return z0quk().z0xk(z0xek());
		}
	}

	internal void z0tek(z0ZzZzkeh p0)
	{
		switch (z0crk().BehaviorOptions.DataObjectRange)
		{
		case WriterDataObjectRange.Application:
			z0hpk = null;
			z0xuk = p0;
			z0ZzZzpwh.z0rek();
			break;
		case WriterDataObjectRange.SingleWriterControl:
			z0hpk = p0;
			z0ZzZzpwh.z0rek();
			break;
		default:
			z0xuk = null;
			z0hpk = null;
			z0quk().z0zk();
			z0quk().z0vk(p0, z0crk().BehaviorOptions.PreserveClipbardDataWhenExit);
			break;
		}
	}

	public void z0tek(z0ZzZzqxj p0)
	{
		XTextDocument xTextDocument = z0qtk();
		if (xTextDocument.z0htk() == null || z0ZzZzqxj.z0eek(xTextDocument.z0htk().z0hp(), p0))
		{
			return;
		}
		bool flag = xTextDocument.z0kyk();
		if (flag && xTextDocument.z0htk().z0lp() != null)
		{
			foreach (z0ZzZzqxj item in xTextDocument.z0htk().z0lp())
			{
				xTextDocument.z0bek(item.z0rek());
			}
		}
		xTextDocument.z0htk().z0jp(p0);
		if (!flag || xTextDocument.z0htk().z0hp() == null)
		{
			return;
		}
		foreach (z0ZzZzqxj item2 in xTextDocument.z0htk().z0lp())
		{
			xTextDocument.z0bek(item2.z0rek());
		}
	}

	public new int z0mek()
	{
		return (z0npk?.z0ryk()?.z0ork())?.z0cek() ?? (-1);
	}

	public new void z0tek(z0ZzZzweh p0)
	{
		z0ZzZzmwh.z0qrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
		z0ZzZzmwh.z0ork = p0.z0yek();
		if (z0jpk != null)
		{
			z0jpk.z0rek(p0);
			z0jpk = null;
			z0ayk().z0qlk();
		}
		else
		{
			z0cjk(p0);
		}
	}

	protected override z0ZzZzqmk z0jx()
	{
		if (z0pik == null)
		{
			return ((z0ZzZzspj)this).z0drk();
		}
		return z0pik;
	}

	public void z0oek(bool p0)
	{
		z0crk().BehaviorOptions.AllowDragContent = p0;
	}

	public new void z0nek()
	{
		if (!z0apk && z0npk != null && z0npk.z0frk() && z0npk.z0ryk() != null && z0pok != null && z0npk.z0xek() != null && !z0cpk && z0npk.z0qtk().Layouted)
		{
			try
			{
				z0cpk = true;
				z0npk.z0ryk().z0hrk();
			}
			finally
			{
				z0cpk = false;
			}
			z0uek(z0npk.z0itk());
		}
	}

	public void z0tek(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (z0gpk == null)
		{
			z0gpk = new z0ZzZzclh();
			if (z0npk != null)
			{
				z0npk.Dispose();
				z0npk = null;
			}
		}
		if (!z0gpk.Contains(p0))
		{
			z0gpk.Add(p0);
			z0npk = z0gpk.z0rek();
		}
	}

	public new void z0yek(int p0)
	{
		if (z0kpk != null)
		{
			z0kpk.Position = p0;
		}
	}

	public new void z0bek()
	{
		if (z0npk != null)
		{
			z0npk.z0ryk().z0urk();
			z0nek();
		}
	}

	public new z0ZzZzovj z0vek()
	{
		return z0qtk().z0mnk();
	}

	public new void z0cek()
	{
	}

	public XTextElement z0tek(int p0, int p1)
	{
		z0ZzZzsmk z0ZzZzsmk2 = base.z0lrk().z0eek(p0, p1, p2: true, p3: false, p4: true);
		if (z0ZzZzsmk2 != null)
		{
			XTextDocument obj = (XTextDocument)z0ZzZzsmk2.z0eek();
			z0ZzZzpdh p2 = new z0ZzZzpdh(p0, p1);
			p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk2.z0mek());
			if (p2.z0tek() == (float)z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek())
			{
				p2.z0rek(z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek() - 2);
			}
			p2 = z0ZzZzsmk2.z0bqk(p2.z0rek(), p2.z0tek());
			return obj.z0bek(p2.z0rek(), p2.z0tek(), p2: true);
		}
		return null;
	}

	internal new z0ZzZzdbj z0xek()
	{
		return z0vuk;
	}

	public new bool z0zek()
	{
		return z0crk().BehaviorOptions.ShowTooltip;
	}

	public void z0pek(bool p0)
	{
		if (p0)
		{
			z0tek(WriterControlExtViewMode.JumpPrint);
		}
		else
		{
			z0tek(WriterControlExtViewMode.Normal);
		}
	}

	public bool z0tek(string p0, bool p1)
	{
		InsertObjectEventArgs e = new InsertObjectEventArgs(z0qtk());
		e.DataObject = z0iek(p1);
		if (e.DataObject == null)
		{
			return false;
		}
		e.SpecifyFormat = p0;
		e.ShowUI = p1;
		WriterDataFormats allowDataFormats = z0wtk();
		e.AllowDataFormats = allowDataFormats;
		e.WriterControl = z0xek();
		e.InputSource = InputValueSource.Clipboard;
		e.CheckMaxTextLengthForCopyPaste = true;
		z0xek().z0eek(e);
		if (!e.Result && e.RejectFormats.Count > 0 && p1 && z0crk().BehaviorOptions.PromptForRejectFormat)
		{
			string p2 = string.Format(z0ZzZziok.z0tik(), z0ZzZzafh.z0yek(e.RejectFormats, ','));
			z0ZzZzfpj.z0rek(this, p2);
		}
		return e.Result;
	}

	internal z0ZzZzsmk z0tek(float p0, float p1)
	{
		if (z0eek() != null && z0eek().z0rek().z0eek(p0, p1))
		{
			return z0eek();
		}
		return ((z0ZzZznpk)base.z0lrk()).z0eek(p0, p1);
	}

	internal string z0tek(XTextElementList p0, bool p1)
	{
		List<z0ZzZzbdh> list = new List<z0ZzZzbdh>();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current.z0yi())
				{
					z0ZzZzbdh z0ZzZzbdh2 = current.z0qyk();
					if (z0ZzZzbdh2.z0uek() > 0f && z0ZzZzbdh2.z0iek() > 0f)
					{
						list.Add(current.z0qyk());
					}
				}
			}
		}
		z0ZzZzbdh[] array = z0ZzZzjmk.z0eek(list.ToArray());
		if (array.Length == 0)
		{
			return null;
		}
		z0ZzZzbdh p2 = z0ZzZzbdh.z0xek;
		z0ZzZzbdh[] array2 = array;
		foreach (z0ZzZzbdh z0ZzZzbdh3 in array2)
		{
			p2 = ((!p2.z0bek()) ? z0ZzZzbdh.z0yek(p2, z0ZzZzbdh3) : z0ZzZzbdh3);
		}
		if (p1)
		{
			z0eek(new z0ZzZzndh((int)p2.z0oek(), (int)p2.z0pek(), (int)p2.z0uek(), (int)p2.z0iek()), ScrollToViewStyle.Normal);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			z0ZzZzbdh z0ZzZzbdh4 = array2[i];
			z0dgj z0dgj = null;
			z0dgj = ((p0[0].z0atk() != z0kuk()) ? z0tek(p0[0].z0atk(), (int)z0ZzZzbdh4.z0oek(), (int)z0ZzZzbdh4.z0pek(), (int)z0ZzZzbdh4.z0uek(), (int)z0ZzZzbdh4.z0iek(), p5: true) : z0tek(PageContentPartyStyle.Body, (int)z0ZzZzbdh4.z0oek(), (int)z0ZzZzbdh4.z0pek(), (int)z0ZzZzbdh4.z0uek(), (int)z0ZzZzbdh4.z0iek()));
			if (z0dgj != null)
			{
				if (stringBuilder.Length > 1)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append("{\"PageIndex\":" + z0dgj.z0iek + ",\"Left\":" + z0dgj.z0eek + ",\"Top\":" + z0dgj.z0yek + ",\"Width\":" + z0dgj.z0tek + ",\"Height\":" + z0dgj.z0uek + "}");
			}
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	public new string z0lrk()
	{
		z0sc();
		z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
		if (!z0apk)
		{
			z0npk.z0qtk().Printing = false;
			z0npk.z0qtk().PrintPreviewing = false;
		}
		List<byte> list = new List<byte>();
		for (int i = 0; i < z0ZzZzerj2.Count; i++)
		{
			z0ZzZzwrj z0ZzZzwrj2 = z0ZzZzerj2[i];
			base.z0vrk = false;
			z0ZzZzadh z0ZzZzadh2 = new z0ZzZzadh();
			z0ZzZzadh2.z0rek(-z0ZzZzwrj2.z0erk().z0pek(), -z0ZzZzwrj2.z0erk().z0mek());
			z0ZzZzreh p = new z0ZzZzreh(z0ZzZzadh2, z0ZzZzwrj2.z0erk());
			z0zpk = false;
			try
			{
				z0upk = z0ZzZzndh.z0cek;
				z0oik = true;
				z0jz(p);
				z0ZzZzwrj2.z0ntk = z0upk;
			}
			finally
			{
				z0oik = false;
				z0zpk = true;
			}
			z0ZzZzadh2.z0eek(GraphicsUnit.Document);
			byte[] p2 = z0ZzZzadh2.z0iek();
			z0ZzZzadh2.Dispose();
			byte[] array = z0ZzZzeyk.z0eek(p2);
			list.AddRange(array);
		}
		return z0ZzZzqik.z0eek(z0ZzZzeyk.z0eek(list.ToArray()));
	}

	public override bool z0kx()
	{
		z0guk();
		return base.z0kx();
	}

	protected override void z0jz(z0ZzZzreh p0)
	{
		z0tek(new z0ZzZzopk(p0.z0eek(), p0.z0tek()));
	}

	public void z0tek(z0ZzZzpxj p0)
	{
		z0pok = p0;
		if (z0pok != null)
		{
			z0pok.z0yn(z0npk);
			z0pok.z0mn(z0xek());
			z0pok.z0pp(z0ook);
		}
	}

	private new void z0krk()
	{
		if (!z0wpk || z0apk)
		{
			return;
		}
		z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
		bool flag = false;
		bool flag2 = false;
		if (z0opk == null)
		{
			flag = true;
			flag2 = true;
		}
		else if (z0opk.Length != z0ZzZzerj2.Count * 2)
		{
			flag = true;
			flag2 = true;
		}
		else
		{
			for (int i = 0; i < z0ZzZzerj2.Count; i++)
			{
				if (z0opk[i * 2] != z0ZzZzerj2[i].z0erk().z0iek() || z0opk[i * 2 + 1] != z0ZzZzerj2[i].z0erk().z0oek())
				{
					flag = true;
					flag2 = true;
					break;
				}
			}
		}
		if (flag)
		{
			z0opk = new int[z0ZzZzerj2.Count * 2];
			for (int j = 0; j < z0ZzZzerj2.Count; j++)
			{
				z0opk[j * 2] = z0ZzZzerj2[j].z0erk().z0iek();
				z0opk[j * 2 + 1] = z0ZzZzerj2[j].z0erk().z0oek();
			}
		}
		if (flag2 && z0ayk() != null)
		{
			z0xek().z0ij(z0yek((z0ZzZzerj)null, p1: false));
		}
	}

	public new z0ZzZzndh z0jrk()
	{
		return z0ZzZzndh.z0cek;
	}

	public bool z0tek(string p0, string p1, int p2)
	{
		UserLoginInfo userLoginInfo = new UserLoginInfo();
		userLoginInfo.ID = p0;
		userLoginInfo.Name = p1;
		userLoginInfo.PermissionLevel = p2;
		return z0yek(userLoginInfo, p1: true);
	}

	public void z0tek(bool p0, DocumentEventArgs p1)
	{
		if (!z0zek())
		{
			return;
		}
		z0lik++;
		z0ftk().z0eek(z0lik);
		z0ZzZzonj z0ZzZzonj2 = null;
		XTextElement xTextElement;
		for (xTextElement = z0ltk(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			z0ZzZzonj2 = z0ftk().z0eek(xTextElement);
			if (z0ZzZzonj2 != null)
			{
				break;
			}
		}
		if (z0ZzZzonj2 == null)
		{
			for (xTextElement = z0ltk(); xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				z0ZzZzonj2 = xTextElement.z0qt();
				if (z0ZzZzonj2 != null)
				{
					break;
				}
			}
		}
		if (p1 != null && !string.IsNullOrEmpty(p1.Tooltip))
		{
			z0ZzZzonj2 = new z0ZzZzonj(xTextElement, p1.Tooltip);
		}
		else if (z0zok != null)
		{
			z0ZzZzonj2 = z0zok;
		}
		z0ZzZzueh z0ZzZzueh2 = z0cyk();
		z0ZzZzonj p2 = z0ZzZzueh2.z0yek_jiejie20260327142557() as z0ZzZzonj;
		if (z0ZzZzonj2 == null)
		{
			z0ZzZzueh2.z0eek(this, null);
			z0ZzZzueh2.z0eek((object)null);
			return;
		}
		if (z0ZzZzonj2.z0eek(p2))
		{
			if (p0)
			{
				return;
			}
		}
		else
		{
			z0ZzZzueh2.z0tek();
			z0ZzZzueh2.z0eek((object)null);
		}
		if (z0ZzZzonj2.z0rek() == (z0ZzZzjbj)0)
		{
			if (z0ZzZzonj2.z0uek() == (z0ZzZzkbj)0)
			{
				z0ZzZzueh2.z0eek((z0ZzZzieh)1);
			}
			else if (z0ZzZzonj2.z0uek() == (z0ZzZzkbj)1)
			{
				z0ZzZzueh2.z0eek((z0ZzZzieh)2);
			}
			else if (z0ZzZzonj2.z0uek() == (z0ZzZzkbj)2)
			{
				z0ZzZzueh2.z0eek((z0ZzZzieh)3);
			}
			z0ZzZzonj2.z0iek();
			if (string.IsNullOrEmpty(z0ZzZzonj2.z0tek()))
			{
				string titleForToolTip = z0crk().BehaviorOptions.TitleForToolTip;
				if (string.IsNullOrEmpty(titleForToolTip))
				{
					z0ZzZzueh2.z0eek(z0ZzZziok.z0xuk());
				}
				else
				{
					z0ZzZzueh2.z0eek(titleForToolTip);
				}
			}
			else
			{
				z0cyk().z0eek(z0ZzZzonj2.z0tek());
			}
			if (z0ryk() != null && z0ryk().z0ux())
			{
				z0ZzZzueh2.z0eek((object)null);
				z0ZzZzueh2.z0eek(this, null);
			}
			else
			{
				z0ZzZzueh2.z0eek(z0ZzZzonj2);
				if (z0ZzZzueh2.z0eek(this) != z0ZzZzonj2.z0yek())
				{
					z0ZzZzueh2.z0eek(this, z0ZzZzonj2.z0yek());
				}
			}
		}
		z0ftk().z0eek(z0lik);
	}

	internal new bool z0hrk()
	{
		return z0wok;
	}

	public void z0tek(bool p0, string p1)
	{
	}

	public void z0mek(bool p0)
	{
		z0crk().BehaviorOptions.ShowTooltip = p0;
		if (!p0)
		{
			z0cyk().z0eek(this, null);
		}
	}

	public void z0tek(XTextElement p0, XTextElement p1)
	{
		XTextDocument xTextDocument = z0qtk();
		if (xTextDocument.z0htk() != null)
		{
			z0ZzZzqxj z0ZzZzqxj2 = xTextDocument.z0htk().z0zo(p0, null);
			if (z0ZzZzqxj2 != null && z0ZzZzqxj2.z0tek() == HighlightActiveStyle.Hover)
			{
				z0tek(z0ZzZzqxj2.z0rek());
			}
			z0ZzZzqxj2 = xTextDocument.z0htk().z0zo(p1, null);
			if (z0ZzZzqxj2 != null && z0ZzZzqxj2.z0tek() == HighlightActiveStyle.Hover)
			{
				z0tek(z0ZzZzqxj2.z0rek());
			}
		}
		WriterEventArgs e = new WriterEventArgs(z0xek(), xTextDocument, null);
		z0xek().z0eek(e, p0, p1);
		e.Dispose();
	}

	private new void z0grk()
	{
		z0ZzZzodh z0ZzZzodh2 = z0ZzZzmwh.z0cek();
		z0ZzZzweh p = new z0ZzZzweh(z0ZzZzmwh.z0pek(), 0, z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), 0);
		z0xjk(p);
	}

	internal bool z0tek(XTextElement p0, bool p1, ValueEditorActiveMode p2, bool p3, bool p4)
	{
		if (!z0hrk())
		{
			return false;
		}
		if (z0ork())
		{
			return false;
		}
		DocumentBehaviorOptions behaviorOptions = z0crk().BehaviorOptions;
		if (behaviorOptions.DesignMode)
		{
			return false;
		}
		if (!behaviorOptions.EnableEditElementValue)
		{
			if (behaviorOptions.SpecifyDebugMode)
			{
				z0ZzZzfeh.z0eek(this, "EnableEditElementValue=false");
			}
			return false;
		}
		if (z0ryk().z0wx())
		{
			if (behaviorOptions.SpecifyDebugMode)
			{
				z0ZzZzfeh.z0eek(this, "EditorHost.EditingValue=true");
			}
			return false;
		}
		z0ZzZzaik.z0eek();
		if (p0 == null)
		{
			return false;
		}
		if (((z0ZzZzmwh)this).z0vek())
		{
			if (behaviorOptions.SpecifyDebugMode)
			{
				z0ZzZzfeh.z0eek(this, "Capture=true");
			}
			((z0ZzZzmwh)this).z0rek(p0: false);
		}
		XTextDocument xTextDocument = z0qtk();
		xTextDocument.z0bek((z0ZzZzhzj)null);
		z0ZzZznnj z0ZzZznnj2 = null;
		XTextElement xTextElement = p0;
		while (p0 != null)
		{
			if (!p0.z0wtk())
			{
				z0ZzZznnj2 = z0ZzZzdfh.z0rek().z0nd(p0);
				if (z0ZzZznnj2 != null)
				{
					if (!(p0 is XTextInputFieldElement))
					{
						break;
					}
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0;
					if (((XTextFieldElementBase)xTextInputFieldElement).z0jrk() == xTextElement && p0.z0qek()?.z0zek() == xTextElement)
					{
						p0 = p0.z0ji();
						continue;
					}
					if (!p3 || (p2 & xTextInputFieldElement.z0srk()) == p2)
					{
						break;
					}
				}
			}
			p0 = p0.z0ji();
		}
		if (p0 == null)
		{
			return false;
		}
		z0ZzZzbcj z0ZzZzbcj2 = (z0ZzZzbcj)255;
		z0ZzZzbcj2 &= (z0ZzZzbcj)(-3);
		z0ZzZzbcj2 &= (z0ZzZzbcj)(-129);
		if (!z0byk().z0am(p0, z0ZzZzbcj2))
		{
			return false;
		}
		if (p1)
		{
			if (z0ZzZznnj2 != null)
			{
				return z0byk().z0pm(p0, (z0ZzZzbcj)0);
			}
			return false;
		}
		if (z0ZzZznnj2 != null)
		{
			if (!z0byk().z0pm(p0, (z0ZzZzbcj)0))
			{
				return false;
			}
			bool flag = true;
			if (z0fyk() != null && z0ZzZzafh.z0iek(z0fyk()).Contains(p0))
			{
				flag = false;
			}
			if (flag)
			{
				xTextDocument.z0ryk().z0uek(p0: true);
				xTextDocument.z0ryk().z0tek(p0.z0hy().z0jrk(), 0);
			}
			if (z0ryk().z0yx() != null)
			{
				z0ryk().z0tx();
			}
			z0ryk().z0ix(p0: false);
			if (z0ryk().z0ox(p0, z0ZzZznnj2) == ElementValueEditResult.UserAccept)
			{
				z0xek().z0yek(p0);
			}
			return true;
		}
		return false;
	}

	protected override void z0lx(object p0, z0ZzZzjpk p1, z0ZzZzndh p2, bool p3)
	{
		if (p0 != null && p1 != null)
		{
			base.z0lx(p0, p1, p2, p3);
			z0ZzZzwrj z0ZzZzwrj2 = (z0ZzZzwrj)p0;
			if (base.z0hrk())
			{
				base.z0frk().z0iek();
			}
		}
	}

	internal new void z0frk()
	{
		z0ZzZzdcj z0ZzZzdcj2 = z0fok;
		z0fok = null;
		XTextDocument xTextDocument = z0qtk();
		XTextElementList xTextElementList = z0ZzZztnj.z0eek(xTextDocument, p1: true, p2: true, p3: true, xTextDocument.z0xek());
		if (xTextElementList != null && xTextElementList.Count != 0)
		{
			xTextDocument.z0ytk();
			bool num = z0ZzZzhkh.z0rek(z0ZzZzdcj2.z0tek(), z0ZzZzdcj2.z0uek(), z0ZzZzdcj2.z0eek(), xTextDocument, xTextElementList, p5: true, "FormatBrush", p7: true);
			xTextDocument.z0nuk();
			if (num)
			{
				xTextDocument.OnSelectionChanged();
				xTextDocument.OnDocumentContentChanged();
				z0ouk();
			}
		}
	}

	public new void z0nek(bool p0)
	{
		if (z0lok != p0)
		{
			z0lok = p0;
			WriterEventArgs p1 = new WriterEventArgs(z0xek(), z0qtk(), null);
			z0xek().z0tek(p1);
		}
	}

	public new z0ZzZzoxj z0drk()
	{
		if (z0itk() == FunctionControlVisibility.Hide)
		{
			return null;
		}
		if (z0vpk == null && !z0aik)
		{
			z0vpk = z0ZzZzuok.z0eek<z0ZzZzoxj>();
			if (z0vpk != null)
			{
				z0vpk.z0rb(z0npk);
			}
		}
		if (z0vpk != null)
		{
			if (z0vpk.z0hb() == null)
			{
				z0ZzZzgpk z0ZzZzgpk2 = new z0ZzZzgpk();
				z0ZzZzgpk2.z0eek(p0: true);
				z0ZzZzgpk2.z0rek(z0ZzZzrpk.z0eek((int)z0ZzZzgpk2.z0tek_jiejie20260327142557(), ((z0ZzZzspj)this).z0cek(), GraphicsUnit.Pixel));
				z0vpk.z0db(z0ZzZzgpk2);
			}
			z0vpk.z0rb(z0npk);
		}
		return z0vpk;
	}

	protected override void z0zc(z0ZzZzweh p0)
	{
		if (z0xtk())
		{
			base.z0zc(p0);
			if (z0npk != null && z0urk() != WriterControlExtViewMode.BoundsSelection && z0urk() != WriterControlExtViewMode.JumpPrint && z0urk() != WriterControlExtViewMode.OffsetJumpPrint)
			{
				z0npk.z0bek((z0ZzZzhzj)null);
				z0tek(p0, DocumentEventStyles.MouseClick);
			}
		}
	}

	internal new string z0srk()
	{
		z0hrk(p0: true);
		return z0iek();
	}

	public new void z0bek(bool p0)
	{
		z0qtk().Modified = p0;
	}

	public void z0tek(z0ZzZzndh p0)
	{
		if (z0zuk == null)
		{
			return;
		}
		for (int num = z0zuk.Count - 1; num >= 0; num--)
		{
			z0ZzZzndh z0ZzZzndh2 = z0zuk[num];
			if (z0ZzZzndh2.z0eek(p0))
			{
				return;
			}
			z0ZzZzndh z0ZzZzndh3 = z0ZzZzndh.z0tek(z0ZzZzndh2, p0);
			if (!z0ZzZzndh3.z0vek())
			{
				if (z0ZzZzndh3.Equals(z0ZzZzndh2))
				{
					z0zuk.RemoveAt(num);
				}
				else
				{
					if (z0ZzZzndh3.Equals(p0))
					{
						return;
					}
					if (z0ZzZzndh3.z0mek() == z0ZzZzndh2.z0mek() && z0ZzZzndh3.z0oek() == z0ZzZzndh2.z0oek())
					{
						if (z0ZzZzndh3.z0pek() == z0ZzZzndh2.z0pek())
						{
							z0ZzZzndh2.z0tek(z0ZzZzndh2.z0nek() - z0ZzZzndh3.z0nek());
							z0ZzZzndh2.z0eek(z0ZzZzndh3.z0nek());
							z0zuk[num] = z0ZzZzndh2;
						}
						else if (z0ZzZzndh3.z0nek() == z0ZzZzndh2.z0nek())
						{
							z0ZzZzndh2.z0tek(z0ZzZzndh3.z0pek() - z0ZzZzndh2.z0pek());
							z0zuk[num] = z0ZzZzndh2;
						}
					}
					else if (z0ZzZzndh3.z0pek() == z0ZzZzndh2.z0pek() && z0ZzZzndh3.z0iek() == z0ZzZzndh2.z0iek())
					{
						if (z0ZzZzndh3.z0mek() == z0ZzZzndh2.z0mek())
						{
							z0ZzZzndh2.z0yek(z0ZzZzndh2.z0bek() - z0ZzZzndh3.z0bek());
							z0ZzZzndh2.z0rek(z0ZzZzndh3.z0bek());
							z0zuk[num] = z0ZzZzndh2;
						}
						else if (z0ZzZzndh3.z0bek() == z0ZzZzndh2.z0bek())
						{
							z0ZzZzndh2.z0yek(z0ZzZzndh3.z0mek() - z0ZzZzndh2.z0mek());
							z0zuk[num] = z0ZzZzndh2;
						}
					}
					else if (z0ZzZzndh3.z0mek() == p0.z0mek() && z0ZzZzndh3.z0oek() == p0.z0oek())
					{
						if (z0ZzZzndh3.z0pek() == p0.z0pek())
						{
							p0.z0tek(p0.z0nek() - z0ZzZzndh3.z0nek());
							p0.z0eek(z0ZzZzndh3.z0nek());
						}
						else if (z0ZzZzndh3.z0nek() == p0.z0nek())
						{
							p0.z0tek(z0ZzZzndh3.z0pek() - p0.z0pek());
						}
					}
					else if (z0ZzZzndh3.z0pek() == p0.z0pek() && z0ZzZzndh3.z0iek() == p0.z0iek())
					{
						if (z0ZzZzndh3.z0mek() == p0.z0mek())
						{
							p0.z0yek(p0.z0bek() - z0ZzZzndh3.z0bek());
							p0.z0rek(z0ZzZzndh3.z0bek());
						}
						else if (z0ZzZzndh3.z0bek() == p0.z0bek())
						{
							p0.z0yek(z0ZzZzndh3.z0mek() - p0.z0mek());
						}
					}
				}
			}
		}
		if (!p0.z0vek())
		{
			z0zuk.Add(p0);
		}
	}

	public new void z0ark()
	{
		z0fok = null;
		z0fx(z0ZzZzbwh.z0qrk);
		z0xek("FormatBrush");
	}

	public new bool z0qrk()
	{
		z0ayk().z0slk();
		return false;
	}

	public bool z0yek(XTextElement p0, bool p1, bool p2)
	{
		if (p0.z0qek() != z0npk?.z0xyk())
		{
			return false;
		}
		float p3 = z0qtk().z0bek(p0, p2);
		z0pek(p0: true);
		z0yek(p3);
		if (p1)
		{
			int num = z0syk().PageIndex;
			if (z0syk().Position < 300f && num > 0)
			{
				num--;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (base.z0krk() != num)
			{
				base.z0uek(num);
				z0sc();
			}
			else
			{
				z0hz();
			}
		}
		else
		{
			z0hz();
		}
		return true;
	}

	private void z0tek(z0ZzZzweh p0, DocumentEventStyles p1)
	{
		z0qok = null;
		z0iok = false;
		if (z0lpk && p1 == DocumentEventStyles.MouseUp)
		{
			z0lpk = false;
			z0fhk();
			z0ZzZzsmk z0ZzZzsmk2 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, p3: true, p4: true);
			z0ZzZzodh p2 = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
			p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk2.z0tek_jiejie20260327142557());
			if (p2.z0tek() == z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek())
			{
				p2.z0rek(z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek() - 2);
			}
			p2 = z0ZzZzsmk2.z0gwk(p2.z0rek(), p2.z0tek());
			((XTextDocument)z0ZzZzsmk2.z0eek()).z0ryk().z0tek((float)p2.z0rek(), (float)p2.z0tek());
		}
		else
		{
			if (z0urk() == WriterControlExtViewMode.JumpPrint)
			{
				return;
			}
			if (p1 == DocumentEventStyles.MouseMove)
			{
				p0.z0yek();
				_ = 1;
				z0uek((string)null);
			}
			z0mik = 0L;
			z0fhk();
			if (base.z0lrk() == null)
			{
				return;
			}
			if (!z0oyk())
			{
				zzz.z0ZzZzkuk<z0ZzZzsmk> z0ZzZzkuk2 = base.z0lrk().z0pek;
				int count = z0ZzZzkuk2.Count;
				for (int i = 0; i < count; i++)
				{
					z0ZzZzsmk z0ZzZzsmk3 = z0ZzZzkuk2[i];
					if (z0ZzZzsmk3.z0lrk().z0eek(p0.z0rek(), p0.z0tek()) && !z0ZzZzsmk3.z0oek())
					{
						if (p1 == DocumentEventStyles.MouseMove)
						{
							z0xrk();
						}
						if (p0.z0uek() > 0)
						{
							return;
						}
					}
				}
			}
			z0ZzZzsmk z0ZzZzsmk4 = null;
			if (p0.z0yek() == (z0ZzZzqeh)0)
			{
				z0ZzZzsmk4 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, p3: false, p4: true);
				if (z0ZzZzsmk4 == null)
				{
					z0fx(z0ZzZzbwh.z0vek);
					if (p1 == DocumentEventStyles.MouseMove)
					{
						z0xrk();
					}
					return;
				}
			}
			z0ZzZzsmk4 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, p3: true, p4: true);
			if (p1 == DocumentEventStyles.MouseMove && p0.z0yek() == (z0ZzZzqeh)1 && !((z0ZzZzmwh)this).z0bek().z0eek(p0.z0rek(), p0.z0tek()) && z0wrk().z0qrk() != 0)
			{
				if (p0.z0tek() < ((z0ZzZzmwh)this).z0bek().z0mek())
				{
					z0ZzZzsmk4 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, (z0ZzZzepk)2, p4: true);
				}
				else if (p0.z0tek() > ((z0ZzZzmwh)this).z0bek().z0bek())
				{
					z0ZzZzsmk4 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, (z0ZzZzepk)3, p4: true);
				}
				else if (z0wrk().z0qrk() < 0)
				{
					z0ZzZzsmk4 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, (z0ZzZzepk)2, p4: true);
				}
				else if (z0wrk().z0qrk() > 0)
				{
					z0ZzZzsmk4 = base.z0lrk().z0eek(p0.z0rek(), p0.z0tek(), p2: true, (z0ZzZzepk)3, p4: true);
				}
			}
			if (z0ZzZzsmk4 == null)
			{
				return;
			}
			XTextDocument xTextDocument = (XTextDocument)z0ZzZzsmk4.z0eek();
			z0ZzZzodh p3 = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
			p3 = z0ZzZzjmk.z0eek(p3, z0ZzZzsmk4.z0tek_jiejie20260327142557());
			if (p3.z0tek() > p0.z0tek() && p1 == DocumentEventStyles.MouseMove && p0.z0yek() == (z0ZzZzqeh)1)
			{
				int num = p3.z0tek();
				p3.z0rek(num + 1);
			}
			if (p3.z0tek() == z0ZzZzsmk4.z0tek_jiejie20260327142557().z0bek())
			{
				p3.z0rek(z0ZzZzsmk4.z0tek_jiejie20260327142557().z0bek() - 2);
			}
			p3 = z0ZzZzsmk4.z0gwk(p3.z0rek(), p3.z0tek());
			if (z0ZzZzsmk4.z0vek() == PageContentPartyStyle.Body)
			{
				z0ZzZzoxj z0ZzZzoxj2 = z0drk();
				z0ZzZzgpk z0ZzZzgpk2 = z0rc();
				z0ZzZzwcj z0ZzZzwcj2 = xTextDocument.z0gik();
				if ((z0ZzZzwcj2 == null || z0ZzZzwcj2.Count == 0) && z0ZzZzoxj2 != null && z0ZzZzoxj2.CurrentComment != null)
				{
					z0ZzZzoxj2.CurrentComment = null;
					z0xek().z0eek(EventArgs.Empty);
					z0hz();
				}
				if (z0ZzZzgpk2 != null && z0ZzZzgpk2.z0yek() && z0ZzZzwcj2 != null && z0ZzZzwcj2.Count > 0 && (p1 == DocumentEventStyles.MouseDown || p1 == DocumentEventStyles.MouseDblClick || p1 == DocumentEventStyles.MouseUp))
				{
					z0ZzZzodh z0ZzZzodh2 = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
					z0ZzZzodh2 = z0ZzZzsmk4.z0gwk(z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek());
					foreach (DocumentComment item in z0ZzZzwcj2)
					{
						if (!item.z0oek() || !item.z0eek(z0ZzZzsmk4.z0cek() as z0ZzZzwrj) || !new z0ZzZzbdh(item.z0drk(), item.z0qrk(), item.z0wrk(), item.z0erk()).z0eek(z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek()))
						{
							continue;
						}
						switch (p1)
						{
						case DocumentEventStyles.MouseDown:
							if (z0ZzZzoxj2.CurrentComment != item)
							{
								z0ZzZzoxj2.CurrentComment = item;
								z0xek().z0eek(EventArgs.Empty);
								z0hz();
							}
							break;
						case DocumentEventStyles.MouseDblClick:
							if (z0ctk())
							{
								if (item.z0uek())
								{
									z0tek("EditComment", p1: true, null);
								}
								else if (z0byk().z0np(item.z0vrk()))
								{
									z0tek("EditComment", p1: true, null);
								}
								else if (z0xek().z0ork() && z0xek().z0ttk())
								{
									z0tek("EditComment", p1: true, null);
								}
							}
							break;
						case DocumentEventStyles.MouseUp:
							if (p0.z0yek() == (z0ZzZzqeh)2 && !item.z0uek())
							{
								z0iok = true;
							}
							break;
						case DocumentEventStyles.MouseClick:
							if (p0.z0yek() == (z0ZzZzqeh)1 && item.z0uek() && item.z0xek() is z0ZzZztlh)
							{
								((z0ZzZztlh)item.z0xek()).z0nek();
							}
							break;
						}
						return;
					}
					if (p1 == DocumentEventStyles.MouseDown && z0ZzZzoxj2.CurrentComment != null)
					{
						z0ZzZzoxj2.CurrentComment = null;
						z0hz();
					}
				}
			}
			DocumentEventArgs e = DocumentEventArgs.z0eek(xTextDocument, new z0ZzZzweh(p0.z0yek(), p0.z0uek(), p3.z0rek(), p3.z0tek(), p0.z0eek()));
			e.Tooltip = null;
			e.Cursor = null;
			if (z0fok != null)
			{
				e.Cursor = z0ZzZzppj.z0lrk();
			}
			e.z0nek = z0ZzZzsmk4.z0tek_jiejie20260327142557().z0eek(p0.z0rek(), p0.z0tek());
			e.z0qrk = p1;
			_ = 4;
			xTextDocument.z0mu(e);
			z0tek(p0: true, e);
			if (!e.Handled)
			{
				z0ppk?.z0eek(e);
				if (e.Handled)
				{
					z0fx(e.z0tek());
				}
			}
			z0fx(e.z0tek());
			if (e.Handled)
			{
				return;
			}
			bool flag = false;
			if (p1 == DocumentEventStyles.MouseDown)
			{
				if (p0.z0yek() == (z0ZzZzqeh)1)
				{
					flag = true;
				}
				else if (p0.z0yek() == (z0ZzZzqeh)2 && z0qtk().z0cuk().z0qrk() == 0)
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (p0.z0uek() != 1)
				{
					return;
				}
				int num2 = xTextDocument.z0cuk().z0urk();
				bool flag2 = false;
				if (z0prk() && z0wrk().z0qrk() != 0)
				{
					bool flag3 = true;
					foreach (XTextElement item2 in z0wrk())
					{
						if (item2 is XTextFieldBorderElement && !((XTextFieldElementBase)item2.z0ji()).z0xek())
						{
							break;
						}
						if (item2.z0ji() is XTextFieldElementBase)
						{
							XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)item2.z0ji();
							if (!xTextFieldElementBase.z0crk() && xTextFieldElementBase.z0eek(item2) && !xTextFieldElementBase.z0xek())
							{
								break;
							}
						}
					}
					if (flag3)
					{
						bool flag4 = false;
						z0ZzZzhkh z0ZzZzhkh2 = z0wrk();
						if (z0ZzZzhkh2.z0irk() != null && z0ZzZzhkh2.z0irk().Count > 0)
						{
							using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0irk().z0ltk();
							while (z0bpk.MoveNext())
							{
								XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
								if (xTextTableCellElement.z0bek())
								{
									xTextTableCellElement = xTextTableCellElement.z0hrk();
								}
								if (xTextTableCellElement.z0yi() && xTextTableCellElement.z0qyk().z0eek(p3.z0rek(), p3.z0tek()))
								{
									flag4 = true;
									break;
								}
							}
						}
						if (!flag4 && z0ZzZzhkh2.z0grk() != null && z0ZzZzhkh2.z0grk().Count > 0)
						{
							using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0grk().z0ltk();
							while (z0bpk.MoveNext())
							{
								XTextElement current2 = z0bpk.Current;
								z0ZzZzzlh z0ZzZzzlh2 = current2.z0ptk();
								if (z0ZzZzzlh2 != null && new z0ZzZzbdh(z0ZzZzzlh2.z0xtk() + current2.z0it(), z0ZzZzzlh2.z0xrk(), current2.Width + current2.z0pt(), z0ZzZzzlh2.z0ytk()).z0eek(p3.z0rek(), p3.z0tek()))
								{
									flag4 = true;
									break;
								}
							}
						}
						if (flag4)
						{
							z0lpk = true;
							return;
						}
					}
				}
				if (!flag2 && !e.AlreadSetSelection)
				{
					if (xTextDocument.z0cuk().z0urk() == num2)
					{
						xTextDocument.z0bek(new z0ZzZzhzj(e));
						xTextDocument.z0ryk().z0uek(!e.ShiftKey);
						xTextDocument.z0ryk().z0tek((float)e.X, (float)e.Y);
					}
					((z0ZzZzqrj)this).z0yek(p0: true);
				}
				return;
			}
			switch (p1)
			{
			case DocumentEventStyles.MouseDblClick:
			{
				XTextElement xTextElement3 = xTextDocument.z0ryk().z0tek(p3.z0rek(), p3.z0tek(), p2: true);
				if (xTextElement3 == null || new ElementMouseEventArgs(null, xTextElement3)
				{
					Button = p0.z0yek(),
					Clicks = p0.z0uek()
				}.Handled || !z0ZzZzsmk4.z0tek_jiejie20260327142557().z0eek(p0.z0rek(), p0.z0tek()))
				{
					break;
				}
				if (((z0ZzZzmwh)this).z0vek())
				{
					((z0ZzZzmwh)this).z0rek(p0: false);
				}
				if (z0mik > 0 || z0tek(xTextElement3, p1: false, ValueEditorActiveMode.MouseDblClick, p3: true, p4: true) || !z0crk().BehaviorOptions.DoubleClickToSelectWord)
				{
					break;
				}
				XTextElement xTextElement4 = z0tek(p0.z0rek(), p0.z0tek());
				if (xTextElement4 != null && !xTextElement4.z0mi())
				{
					break;
				}
				if (xTextElement4 != null && xTextElement4.z0ji() is XTextInputFieldElementBase)
				{
					XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement4.z0ji();
					if (((XTextFieldElementBase)xTextInputFieldElementBase).z0eek(xTextElement4))
					{
						break;
					}
					z0ZzZzplh z0ZzZzplh2 = z0npk.z0ryk();
					int num3 = z0ZzZzplh2.z0bek(((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk());
					int num4 = z0ZzZzplh2.z0bek(((XTextFieldElementBase)xTextInputFieldElementBase).z0tek());
					if (num3 >= 0 && num4 > num3 && num4 < num3 + 300)
					{
						bool flag5 = true;
						for (int j = num3 + 1; j < num4; j++)
						{
							XTextElement xTextElement5 = z0ZzZzplh2[j];
							if (!(xTextElement5 is XTextCharElement) && !(xTextElement5 is XTextParagraphFlagElement) && !(xTextElement5 is XTextObjectElement))
							{
								xTextElement5.z0tyk();
								flag5 = false;
								break;
							}
						}
						if (flag5)
						{
							z0ZzZzplh2.z0vek().z0uek(num3 + 1, num4 - num3 - 1);
							break;
						}
					}
				}
				z0npk.z0ryk().z0xek();
				break;
			}
			case DocumentEventStyles.MouseClick:
			{
				XTextElement xTextElement2 = xTextDocument.z0ryk().z0tek(p3.z0rek(), p3.z0tek(), p2: true);
				if (xTextElement2 != null && z0ZzZzsmk4.z0tek_jiejie20260327142557().z0eek(p0.z0rek(), p0.z0tek()))
				{
					if (((z0ZzZzmwh)this).z0vek())
					{
						((z0ZzZzmwh)this).z0rek(p0: false);
					}
					ValueEditorActiveMode valueEditorActiveMode = ValueEditorActiveMode.None;
					valueEditorActiveMode = ((p0.z0yek() == (z0ZzZzqeh)1) ? ValueEditorActiveMode.MouseClick : ((p0.z0yek() != (z0ZzZzqeh)2) ? ValueEditorActiveMode.MouseClick : ValueEditorActiveMode.MouseRightClick));
					if (z0mik <= 0 && xTextElement2.z0qek().z0oek().z0qrk() == 0)
					{
						z0tek(xTextElement2, p1: false, valueEditorActiveMode, p3: true, p4: true);
					}
				}
				break;
			}
			case DocumentEventStyles.MouseMove:
				z0fx(e.z0tek());
				break;
			default:
				_ = 3;
				break;
			}
		}
	}

	public z0ZzZzhkh z0wrk()
	{
		return z0npk?.z0cuk();
	}

	private new int z0erk()
	{
		int result = 1;
		if (z0npk != null && z0npk.PageSettings.z0grk() > 1 && !z0apk)
		{
			result = z0npk.PageSettings.z0grk();
		}
		return result;
	}

	public void z0tek(FunctionControlVisibility p0)
	{
		z0crk().BehaviorOptions.CommentVisibility = p0;
	}

	public new static string z0tek(Color p0)
	{
		if (p0.A == 255)
		{
			return z0ZzZzifh.z0eek(p0);
		}
		return "rgba(" + p0.R + "," + p0.G + "," + p0.B + "," + p0.A + ")";
	}

	internal Dictionary<string, object> z0yek(string p0)
	{
		if (((z0ZzZzmwh)this).z0rek())
		{
			throw new InvalidOperationException("control disposed");
		}
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		p0 = p0.Trim().ToLower();
		if (z0iik.ContainsKey(p0))
		{
			return z0iik[p0];
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		z0iik[p0] = dictionary;
		return dictionary;
	}

	public void z0tek(JumpPrintInfo p0)
	{
		z0bok = p0;
	}

	internal z0ZzZzkeh z0tek(ref z0ZzZzzwh p0)
	{
		z0lpk = false;
		z0fx(z0ZzZzbwh.z0vek);
		DocumentBehaviorOptions behaviorOptions = z0crk().BehaviorOptions;
		if (behaviorOptions.MoveFieldWhenDragWholeContent)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)z0tek(typeof(XTextInputFieldElementBase));
			if (xTextInputFieldElementBase != null)
			{
				XTextDocumentContentElement xTextDocumentContentElement = xTextInputFieldElementBase.z0qek();
				int num = xTextDocumentContentElement.z0frk().IndexOf(((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk());
				int num2 = xTextDocumentContentElement.z0frk().IndexOf(((XTextFieldElementBase)xTextInputFieldElementBase).z0tek());
				int num3 = xTextDocumentContentElement.z0oek().z0lrk();
				int num4 = xTextDocumentContentElement.z0oek().z0drk();
				if ((num == num3 || num == num3 - 1) && (num2 == num4 || num4 == num2 + 1))
				{
					xTextDocumentContentElement.z0uek(num, num2 - num + 1);
				}
			}
		}
		z0ZzZzkeh z0ZzZzkeh2 = z0byk().z0wn_jiejie20260327142557(z0tek(), p1: false, z0crk().EditOptions.ClearFieldValueWhenCopy, z0crk().EditOptions.CopyWithoutInputFieldStructure, p4: false);
		if (z0ZzZzkeh2 == null)
		{
			return null;
		}
		z0ZzZzkeh2.z0gj(z0ZzZzkfh.z0xrk, "1");
		switch (behaviorOptions.DataObjectRange)
		{
		case WriterDataObjectRange.SingleWriterControl:
			z0ZzZzkeh2.z0gj(z0ZzZzkfh.z0rrk, z0uok);
			break;
		case WriterDataObjectRange.Application:
			z0ZzZzkeh2.z0gj(z0ZzZzkfh.z0rrk, z0qpk);
			break;
		}
		p0 = (z0ZzZzzwh)1;
		if (!z0ork() && z0byk().z0vp())
		{
			p0 |= (z0ZzZzzwh)2;
		}
		z0mok = DragOperationState.DragingSelection;
		return z0ZzZzkeh2;
	}

	public void z0tek(z0ZzZzheh p0)
	{
		z0ec(p0);
	}

	public bool z0tek(XTextElement p0, z0ZzZzleh p1, float p2, float p3)
	{
		CanInsertObjectEventArgs e = new CanInsertObjectEventArgs(z0qtk());
		e.SpecifyPosition = z0qtk().z0ryk().z0bek(p0);
		e.DataObject = p1.z0uek();
		e.SpecifyFormat = null;
		e.AccessFlags = (z0ZzZzbcj)255;
		z0xek().z0eek(e);
		return e.Result;
	}

	public new bool z0rrk()
	{
		XTextDocument xTextDocument = z0npk;
		if (xTextDocument != null)
		{
			switch (z0itk())
			{
			case FunctionControlVisibility.Auto:
			{
				z0ZzZzwcj z0ZzZzwcj2 = xTextDocument.z0gik();
				if (z0ZzZzwcj2 != null)
				{
					return z0ZzZzwcj2.Count > 0;
				}
				return false;
			}
			case FunctionControlVisibility.Hide:
				return false;
			case FunctionControlVisibility.Visible:
				return true;
			}
		}
		return false;
	}

	public void z0tek(int p0, string p1)
	{
		if (p0 != z0fik || p1 == null || p1.Length <= 0)
		{
			return;
		}
		z0ZzZzdbj.z0cxk z0rek = z0xek().z0spk();
		if (z0rek == null || z0rek.z0yek == null || p1.Length <= z0rek.z0yek.Length)
		{
			return;
		}
		string p2;
		if (z0rek.z0yek != p1.Substring(0, z0rek.z0yek.Length))
		{
			z0npk.z0hxk = delegate(z0ZzZzezj z0ZzZzezj2)
			{
				z0ZzZzezj2.z0tek(z0ZzZzezj2.z0uek() - z0rek.z0yek.Length);
				z0ZzZzezj2.z0rek(z0rek.z0yek.Length);
			};
			p2 = p1;
		}
		else
		{
			p2 = p1.Substring(z0rek.z0yek.Length);
		}
		z0xek().z0erk().z0vm(p2);
		z0npk.z0hxk = null;
	}

	public new bool z0trk()
	{
		return z0byk().z0mm();
	}

	public new byte[] z0uek(int p0)
	{
		z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
		if (p0 < 0 || p0 >= z0ZzZzerj2.Count)
		{
			return null;
		}
		if (!z0apk)
		{
			z0npk.z0qtk().Printing = false;
			z0npk.z0qtk().PrintPreviewing = false;
		}
		z0ZzZzwrj z0ZzZzwrj2 = z0ZzZzerj2[p0];
		if (z0eok != null)
		{
			for (int num = z0eok.Count - 1; num >= 0; num--)
			{
				if (z0eok[num].z0tek == z0ZzZzwrj2)
				{
					z0eok.RemoveAt(num);
				}
			}
		}
		base.z0vrk = false;
		z0ZzZzadh z0ZzZzadh2 = new z0ZzZzadh();
		z0ZzZzadh2.z0eek(z0kyk() * z0xek().z0qik());
		z0ZzZzadh2.z0rek(-z0ZzZzwrj2.z0erk().z0pek(), -z0ZzZzwrj2.z0erk().z0mek());
		z0ZzZzreh p1 = new z0ZzZzreh(z0ZzZzadh2, z0ZzZzwrj2.z0erk());
		z0zpk = false;
		try
		{
			z0upk = z0ZzZzndh.z0cek;
			z0jz(p1);
			z0ZzZzwrj2.z0ntk = z0upk;
		}
		finally
		{
			z0zpk = true;
		}
		string text = z0xek().z0mj();
		if (text != null && text.Length > 0)
		{
			z0ZzZzadh2.z0eek(GraphicsUnit.Pixel);
			z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
			z0ZzZzlsh2.z0rek(StringAlignment.Far);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			z0ZzZzadh2.z0eek(text, z0kok, z0ZzZzyfh.z0krk, new z0ZzZzbdh(z0ZzZzwrj2.z0erk().z0pek(), z0ZzZzwrj2.z0erk().z0mek() + 5, z0ZzZzwrj2.z0erk().z0iek() - 50, 100f), z0ZzZzlsh2);
			z0ZzZzlsh2.Dispose();
		}
		z0ZzZzadh2.z0eek(GraphicsUnit.Document);
		byte[] result = z0ZzZzadh2.z0iek();
		z0ZzZzadh2.Dispose();
		return result;
	}

	public void z0tek(MoveFocusHotKeys p0)
	{
		z0crk().BehaviorOptions.MoveFocusHotKey = p0;
	}

	public new string z0yrk()
	{
		return z0crk().BehaviorOptions.ExcludeKeywords;
	}

	private void z0tek(z0ZzZzleh p0, int p1)
	{
		WriterDataObjectRange dataObjectRange = z0crk().BehaviorOptions.DataObjectRange;
		if ((dataObjectRange == WriterDataObjectRange.Application || dataObjectRange == WriterDataObjectRange.SingleWriterControl) && p0.z0uek().z0jj(z0ZzZzkfh.z0rrk))
		{
			string text = Convert.ToString(p0.z0uek().z0jj(z0ZzZzkfh.z0rrk));
			if ((dataObjectRange == WriterDataObjectRange.Application && text != z0qpk) || (dataObjectRange == WriterDataObjectRange.SingleWriterControl && text != z0uok))
			{
				return;
			}
		}
		if (base.z0lrk() == null)
		{
			return;
		}
		z0ZzZzsmk z0ZzZzsmk2 = base.z0lrk().z0eek(p0.z0tek(), p0.z0eek(), p2: true, p3: true, p4: true);
		if (z0ZzZzsmk2 == null)
		{
			return;
		}
		z0ZzZzpdh p2 = new z0ZzZzpdh(p0.z0tek(), p0.z0eek());
		p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk2.z0mek());
		p2 = z0ZzZzsmk2.z0bqk(p2.z0rek(), p2.z0tek());
		XTextDocument xTextDocument = (XTextDocument)z0ZzZzsmk2.z0eek();
		XTextElement xTextElement = xTextDocument.z0ryk().z0tek(p2.z0rek(), p2.z0tek(), p2: false);
		if (xTextElement == null)
		{
			return;
		}
		int num = xTextDocument.z0ryk().z0tek(xTextDocument.z0ryk().z0bek(xTextElement), (z0ZzZzfxj)2, p2: false);
		if (num >= 0)
		{
			xTextElement = xTextDocument.z0ryk()[num];
			z0rek(p0: true);
			((z0ZzZzqrj)this).z0yek(p0: true);
			if (z0mok == DragOperationState.DragingSelection)
			{
				bool p3 = z0pek();
				z0uek(p0: false);
				z0uek(xTextElement);
				z0uek(p3);
				if (xTextDocument.z0cuk().z0rek(xTextElement))
				{
					p0.z0eek((z0ZzZzzwh)0);
					z0mek((string)null);
					return;
				}
			}
			else
			{
				z0mok = DragOperationState.Drag;
				xTextDocument.z0ryk().z0uek(p0: true);
				xTextDocument.z0ryk().z0tek(p2.z0rek(), p2.z0tek());
				xTextElement = xTextDocument.z0itk();
			}
			((z0ZzZzqrj)this).z0yek(p0: false);
			if (z0qok == xTextElement && p1 != 1)
			{
				p0.z0eek(z0tik);
				return;
			}
			z0qok = xTextElement;
			if (z0tek(xTextElement, p0, p2.z0rek(), p2.z0tek()))
			{
				if ((p0.z0yek() & 4) == 4 && (p0.z0iek() & (z0ZzZzzwh)2) == (z0ZzZzzwh)2)
				{
					z0mek(z0ZzZziok.z0ook());
					p0.z0eek((z0ZzZzzwh)2);
				}
				else if ((p0.z0yek() & 8) == 8 && (p0.z0iek() & (z0ZzZzzwh)1) == (z0ZzZzzwh)1)
				{
					z0mek(z0ZzZziok.z0nik());
					p0.z0eek((z0ZzZzzwh)1);
				}
				else if ((p0.z0iek() & (z0ZzZzzwh)2) == (z0ZzZzzwh)2)
				{
					z0mek(z0ZzZziok.z0ook());
					p0.z0eek((z0ZzZzzwh)2);
				}
				else if ((p0.z0iek() & (z0ZzZzzwh)1) == (z0ZzZzzwh)1)
				{
					z0mek(z0ZzZziok.z0nik());
					p0.z0eek((z0ZzZzzwh)1);
				}
				else
				{
					z0mek((string)null);
					p0.z0eek((z0ZzZzzwh)0);
				}
				if (p1 == 1)
				{
					InsertObjectEventArgs e = new InsertObjectEventArgs(z0qtk());
					e.AllowedEffect = p0.z0iek();
					e.DragEffect = p0.z0rek();
					e.DataObject = p0.z0uek();
					e.ShowUI = true;
					e.AutoSelectContent = true;
					e.InputSource = InputValueSource.DragDrop;
					e.Result = false;
					e.CurrentElement = xTextElement;
					object data = e.GetData(z0ZzZzkfh.z0ark);
					if (data != null && data.ToString() == ((IntPtr)z0xek().z0hhk()).ToInt32().ToString())
					{
						z0mok = DragOperationState.DragDropInOwnerWriterControl;
					}
					if (z0mok == DragOperationState.DragDropInOwnerWriterControl && p0.z0rek() == (z0ZzZzzwh)2)
					{
						e.z0eek(p0: true);
						z0byk().z0en(e);
						e.z0eek(p0: false);
						if (!e.Result)
						{
							p0.z0eek((z0ZzZzzwh)0);
							z0tik = p0.z0rek();
							return;
						}
						e.CurrentElement = null;
						z0tek(p0: true);
						p0.z0eek((z0ZzZzzwh)1);
					}
					xTextDocument.z0ryk().z0uek(p0: true);
					z0rek(p0: false);
					((z0ZzZzqrj)this).z0yek(p0: true);
					xTextDocument.z0ryk().z0tek(xTextElement.z0jrk(), 0);
					((z0ZzZzqrj)this).z0yek(p0: false);
					if (z0mok == DragOperationState.DragDropInOwnerWriterControl)
					{
						z0byk().z0en(e);
					}
					else
					{
						z0xek().z0eek(e);
					}
					p0.z0eek(e.DragEffect);
					if (!e.Result)
					{
						p0.z0eek((z0ZzZzzwh)0);
					}
					z0mek((string)null);
					((z0ZzZzmwh)this).z0jrk();
					z0kx();
					z0qok = null;
				}
			}
			else
			{
				z0mek((string)null);
				p0.z0eek((z0ZzZzzwh)0);
			}
			z0tik = p0.z0rek();
		}
		else
		{
			p0.z0eek((z0ZzZzzwh)0);
		}
	}

	public WriterControlExtViewMode z0urk()
	{
		if (z0lyk() != null && z0lyk().z0rek())
		{
			return WriterControlExtViewMode.BoundsSelection;
		}
		if (z0bok != null && z0bok.Enabled)
		{
			if (z0syk().Mode == JumpPrintMode.Offset)
			{
				return WriterControlExtViewMode.OffsetJumpPrint;
			}
			return WriterControlExtViewMode.JumpPrint;
		}
		return WriterControlExtViewMode.Normal;
	}

	internal void z0yek(z0ZzZzheh p0)
	{
		z0hx(p0);
	}

	public new void z0irk()
	{
		z0npk?.z0jrk(p0: true);
	}

	internal new bool z0ork()
	{
		if (XTextDocument.z0gmk())
		{
			return true;
		}
		return z0lok;
	}

	public z0ZzZzndh z0tek(XTextElement p0)
	{
		if (p0 is XTextCharElement || p0 is XTextParagraphFlagElement || p0 is XTextObjectElement || p0 is XTextFieldBorderElement)
		{
			z0ZzZzbdh p1 = p0.z0qyk();
			foreach (z0ZzZzsmk item in base.z0lrk())
			{
				if (item.z0yek(p1))
				{
					z0ZzZzbdh z0ZzZzbdh2 = ((z0ZzZzqmk)item).z0rek(p1);
					z0ZzZzndh result = new z0ZzZzndh((int)Math.Ceiling(z0ZzZzbdh2.z0oek()), (int)Math.Ceiling(z0ZzZzbdh2.z0pek()), 0, 0);
					result.z0tek((int)Math.Ceiling(z0ZzZzbdh2.z0mek() - (float)result.z0pek()));
					result.z0yek((int)Math.Ceiling(z0ZzZzbdh2.z0nek() - (float)result.z0mek()));
					if (result.z0iek() < 0)
					{
						result.z0tek(0);
					}
					if (result.z0oek() < 0)
					{
						result.z0yek(0);
					}
					if (result.z0iek() > 0 && result.z0oek() > 0)
					{
						return result;
					}
					break;
				}
			}
			return z0ZzZzndh.z0cek;
		}
		XTextElementList xTextElementList = new XTextElementList();
		if (!(p0 is XTextInputFieldElement))
		{
			if (p0 is XTextShapeInputFieldElement)
			{
				if (!((XTextShapeInputFieldElement)p0).EditMode)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(p0);
				}
			}
			else
			{
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(p0);
			}
		}
		if (xTextElementList.Count == 0)
		{
			XTextDocumentContentElement xTextDocumentContentElement = p0.z0qek();
			if (p0 is XTextInputFieldElementBase && p0 is XTextContainerElement)
			{
				XTextElementList xTextElementList2 = new XTextElementList();
				XTextContainerElement obj = (XTextContainerElement)p0;
				XTextContainerElement.z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new XTextContainerElement.z0eok_jiejie20260327142557(obj.z0jr(), xTextElementList2, p2: true);
				obj.z0ue(z0eok_jiejie20260327142557);
				z0eok_jiejie20260327142557.Dispose();
				if (xTextElementList2.Count > 0)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (current.z0ptk() != null && xTextDocumentContentElement.z0frk().Contains(current))
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(current);
						}
					}
				}
			}
		}
		z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0cek;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzbdh p2 = z0bpk.Current.z0qyk();
			foreach (z0ZzZzsmk item2 in base.z0lrk())
			{
				if (item2.z0yek(p2))
				{
					z0ZzZzbdh z0ZzZzbdh3 = ((z0ZzZzqmk)item2).z0rek(p2);
					z0ZzZzndh z0ZzZzndh3 = new z0ZzZzndh((int)Math.Ceiling(z0ZzZzbdh3.z0oek()), (int)Math.Ceiling(z0ZzZzbdh3.z0pek()), 0, 0);
					z0ZzZzndh3.z0tek((int)Math.Ceiling(z0ZzZzbdh3.z0mek() - (float)z0ZzZzndh3.z0pek()));
					z0ZzZzndh3.z0yek((int)Math.Ceiling(z0ZzZzbdh3.z0nek() - (float)z0ZzZzndh3.z0mek()));
					if (z0ZzZzndh3.z0iek() < 0)
					{
						z0ZzZzndh3.z0tek(0);
					}
					if (z0ZzZzndh3.z0oek() < 0)
					{
						z0ZzZzndh3.z0yek(0);
					}
					if (z0ZzZzndh3.z0iek() > 0 && z0ZzZzndh3.z0oek() > 0)
					{
						z0ZzZzndh2 = ((!z0ZzZzndh2.z0vek()) ? z0ZzZzndh.z0yek(z0ZzZzndh3, z0ZzZzndh2) : z0ZzZzndh3);
					}
					break;
				}
			}
		}
		return z0ZzZzndh2;
	}

	public new bool z0prk()
	{
		return z0crk().BehaviorOptions.AllowDragContent;
	}

	public void z0uek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			z0zok = null;
			return;
		}
		z0zok = new z0ZzZzonj();
		z0zok.z0rek(p0);
	}

	internal new z0ZzZzgxj z0mrk()
	{
		if (!z0xok)
		{
			return null;
		}
		if (z0ppk == null)
		{
			z0ppk = new z0ZzZzgxj(this);
		}
		return z0ppk;
	}

	public object z0tek(string p0, bool p1, object p2)
	{
		object result = z0nyk().ExecuteCommand(p0, p1, p2);
		if (z0byk() != null)
		{
			z0byk().z0tn();
		}
		return result;
	}

	public new z0ZzZzjpk z0nrk()
	{
		z0ZzZzjpk obj = new z0ZzZzjpk(((z0ZzZzspj)this).z0mek());
		obj.z0eek(p0: true);
		return obj;
	}

	private new void z0brk()
	{
		if (z0gok != XTextDocument.z0aik())
		{
			z0gok = XTextDocument.z0aik();
			z0zik = null;
		}
	}

	public void z0tek(z0ZzZzwxj p0)
	{
		XTextDocument xTextDocument = z0qtk();
		if (xTextDocument == null || xTextDocument.z0htk() == null || xTextDocument.z0htk().z0lp() == p0)
		{
			return;
		}
		bool flag = xTextDocument.z0kyk();
		if (flag && xTextDocument.z0htk().z0lp() != null)
		{
			foreach (z0ZzZzqxj item in xTextDocument.z0htk().z0lp())
			{
				xTextDocument.z0bek(item.z0rek());
			}
		}
		xTextDocument.z0htk().z0dp(p0);
		if (!flag)
		{
			return;
		}
		foreach (z0ZzZzqxj item2 in xTextDocument.z0htk().z0lp())
		{
			xTextDocument.z0bek(item2.z0rek());
		}
	}

	public new void z0vrk()
	{
		z0tek((string)null, p1: true);
	}

	internal void z0iek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		if (p0.Length == 1 && (p0[0] == '\r' || p0[0] == '\n') && z0epk > 0)
		{
			if (z0ZzZzafh.z0uek() - z0epk < 80)
			{
				return;
			}
			z0epk = 0L;
		}
		p0 = z0cek(p0);
		if (string.IsNullOrEmpty(p0) || z0ork() || !z0byk().z0gm(typeof(XTextCharElement), (z0ZzZzbcj)255))
		{
			return;
		}
		DocumentEventArgs e = DocumentEventArgs.z0eek(z0qtk(), p0[0]);
		z0qtk().z0mu(e);
		if (!e.Handled)
		{
			z0byk().z0um(z0crk().BehaviorOptions.AutoUppercaseFirstCharInFirstLine);
			XTextElementList xTextElementList = z0byk().z0pn(p0, p1: true, InputValueSource.UI, null, null);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				z0duk();
			}
		}
	}

	public new DocumentOptions z0crk()
	{
		if (z0aik)
		{
			return z0jik;
		}
		if (z0jik == null)
		{
			z0jik = new DocumentOptions();
			z0jik.z0eek(this);
		}
		return z0jik;
	}

	internal z0ZzZzerj z0tek(z0ZzZzerj p0, z0bnk p1, z0ZzZzclh p2, bool p3)
	{
		z0ZzZzerj z0ZzZzerj2 = p0;
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		JumpPrintInfo jumpPrintInfo = null;
		if (p1 != null)
		{
			jumpPrintInfo = p1.z0ilk();
			if (p1.z0jkk() != null && p1.z0jkk().Length > 0)
			{
				XTextElement xTextElement = z0qtk().z0ki(p1.z0jkk());
				if (xTextElement != null)
				{
					z0yek(xTextElement, p1: false, p2: true);
					jumpPrintInfo = null;
				}
			}
			if (p1.z0mlk() != null && p1.z0mlk().Length > 0)
			{
				XTextElement xTextElement2 = z0qtk().z0ki(p1.z0mlk());
				if (xTextElement2 != null)
				{
					z0tek(xTextElement2, p1: false, p2: false);
					jumpPrintInfo = null;
				}
			}
		}
		if (jumpPrintInfo == null)
		{
			jumpPrintInfo = z0syk();
		}
		if (jumpPrintInfo != null && jumpPrintInfo.HasValidateInfo)
		{
			if (!p3)
			{
				z0tek(jumpPrintInfo);
				int num = Math.Max(0, z0syk().PageIndex);
				int num2 = p0.Count - 1;
				if (z0syk().EndPageIndex >= 0)
				{
					num2 = Math.Min(p0.Count, z0syk().EndPageIndex);
				}
				if (num > 0 || num2 < p0.Count - 1)
				{
					z0ZzZzerj2 = new z0ZzZzerj();
					z0ZzZzerj2.AddRange(p0.GetRange(num, num2 - num + 1));
				}
			}
		}
		else if (p1 != null)
		{
			int[] array = p1.z0xlk(p0.Count, ((z0ZzZzqrj)this).z0oek(), p2);
			z0ZzZzerj2 = new z0ZzZzerj();
			int[] array2 = array;
			foreach (int num3 in array2)
			{
				if (num3 >= 0 && num3 < p0.Count)
				{
					z0ZzZzerj2.Add(p0[num3]);
				}
			}
		}
		return z0ZzZzerj2;
	}

	internal void z0oek(string p0)
	{
		z0puk();
		z0qtk().z0wrk(p0);
		z0xyk();
		z0oek();
		z0hz();
	}

	internal new void z0xrk()
	{
		if (z0cyk() != null)
		{
			z0cyk().z0eek((object)null);
			z0cyk().z0eek(this, null);
		}
	}

	public new int z0zrk()
	{
		return (z0npk?.z0ryk()?.z0lrk())?.z0otk() ?? (-1);
	}

	protected override void z0xc(string p0)
	{
		z0puk();
		if (z0qtk() != null)
		{
			z0qtk().Text = p0;
		}
		z0xyk();
		z0oek();
		z0hz();
	}

	public XTextElement z0ltk()
	{
		return z0npk?.z0etk();
	}

	protected override void z0nx(EventArgs p0)
	{
		base.z0nx(p0);
		if (z0npk != null && !z0htk())
		{
			if (z0xpk)
			{
				z0npk.z0wnk();
			}
			z0npk.z0uuk();
		}
	}

	protected override void z0cc(EventArgs p0)
	{
		if (z0xtk())
		{
			base.z0cc(p0);
		}
	}

	public override void z0hz()
	{
		if (z0wpk)
		{
			z0nok = true;
			if (z0eok != null)
			{
				z0eok.Clear();
			}
			if (z0ayk() != null)
			{
				z0ayk().z0hlk();
			}
		}
	}

	internal z0ZzZzxbj z0ktk()
	{
		if (z0dok == null && !z0aik)
		{
			z0dok = new z0ZzZzxbj();
		}
		return z0dok;
	}

	public void z0tek(MoveTarget p0)
	{
		if (z0npk != null)
		{
			z0npk.z0ryk().z0uek(p0: true);
			z0npk.z0ryk().z0tek(p0);
		}
	}

	public string z0jtk()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (z0ZzZzrmj item in z0nyk().CommandContainer.z0tek())
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(item.z0tek);
		}
		return stringBuilder.ToString();
	}

	public override void z0vc(z0ZzZzgpk p0)
	{
		base.z0vc(p0);
	}

	public object z0tek(string p0, z0ZzZzomj p1)
	{
		object result = z0nyk().z0eek(p0, p1.ShowUI, p1.Parameter, p1.RaiseFromUI);
		if (z0byk() != null)
		{
			z0byk().z0tn();
		}
		return result;
	}

	public bool z0htk()
	{
		if (z0ayk() == null)
		{
			return false;
		}
		return z0ayk().z0cz();
	}

	internal void z0iek(int p0)
	{
		if (p0 > 0)
		{
			z0rok = DateTime.Now.AddMilliseconds(p0).Ticks;
		}
	}

	public void z0tek(IEnumerable p0)
	{
		if (p0 == null || z0npk == null || !z0npk.z0kyk())
		{
			return;
		}
		z0ZzZzzlh z0ZzZzzlh2 = null;
		float num = 0f;
		float num2 = 0f;
		PageContentPartyStyle p1 = PageContentPartyStyle.Body;
		bool flag = true;
		foreach (XTextElement item in p0)
		{
			if (item.z0qek() == null)
			{
				continue;
			}
			if (flag)
			{
				p1 = item.z0qek().z0fu();
				flag = false;
			}
			if (item.z0kik == null)
			{
				z0ZzZzbdh p2 = z0npk.z0zek(item);
				z0tek(p2, p1);
				continue;
			}
			if (z0ZzZzzlh2 == null || item.z0kik != z0ZzZzzlh2)
			{
				if (z0ZzZzzlh2 != null)
				{
					z0ZzZzbdh p3 = new z0ZzZzbdh(z0ZzZzzlh2.z0xtk() + num, z0ZzZzzlh2.z0xrk(), num2 - num, z0ZzZzzlh2.z0ytk());
					z0tek(p3, p1);
				}
				z0ZzZzzlh2 = item.z0kik;
				num = item.z0it();
			}
			num2 = item.z0it() + item.z0lu();
		}
		if (z0ZzZzzlh2 != null)
		{
			z0ZzZzbdh p4 = new z0ZzZzbdh(z0ZzZzzlh2.z0xtk() + num, z0ZzZzzlh2.z0xrk(), num2 - num, z0ZzZzzlh2.z0ytk());
			z0tek(p4, p1);
		}
	}

	public void z0tek(EventArgs p0)
	{
		z0hc(p0);
	}

	public bool z0gtk()
	{
		return z0spk;
	}

	protected override void z0sx(z0ZzZzgeh p0)
	{
		if (p0.z0eek() == '\r' && z0epk > 0)
		{
			if (z0ZzZzafh.z0uek() - z0epk < 80)
			{
				return;
			}
			z0epk = 0L;
		}
		if (z0dik_jiejie20260327142557 > 0 && Environment.TickCount < z0dik_jiejie20260327142557)
		{
			return;
		}
		if (z0gtk())
		{
			z0xek(p0: false);
		}
		else
		{
			if ((p0.z0eek() == '\r' && z0ZzZzmwh.z0oek() == Keys.Shift) || p0.z0eek() == '\b' || p0.z0eek() == '\n' || (p0.z0eek() < ' ' && p0.z0eek() != '\t' && p0.z0eek() != '\r'))
			{
				return;
			}
			if (z0npk != null)
			{
				DocumentEventArgs e = DocumentEventArgs.z0eek(z0npk, p0);
				z0npk.z0mu(e);
				if (e.Handled || p0.z0rek())
				{
					return;
				}
				if (p0.z0eek() == '\t' && z0ZzZzmwh.z0oek() != Keys.Control && z0crk().EditOptions.TabKeyToFirstLineIndent && z0wrk().z0qrk() == 0 && z0byk().z0jn(p0: true))
				{
					p0.z0eek(p0: true);
					return;
				}
				if (!z0ork() && z0byk().z0gm(typeof(XTextElement), (z0ZzZzbcj)255))
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0npk.z0onk().z0tek().Clone();
					z0byk().z0um(z0crk().BehaviorOptions.AutoUppercaseFirstCharInFirstLine);
					string text = z0cek(p0.z0eek().ToString());
					XTextElementList xTextElementList = null;
					try
					{
						z0aok = true;
						z0npk.z0drk(p0: true);
						if (text != null && (text.Contains('\r') || text.Contains('\n') || text.Contains('\t') || text.Contains(' ')))
						{
							z0aok = false;
						}
						z0npk.z0nok();
						xTextElementList = z0byk().z0pn(text, p1: true, InputValueSource.UI, null, null);
					}
					finally
					{
						z0aok = false;
						z0npk.z0fok();
					}
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						if (text == "\r" && z0npk.z0zyk())
						{
							if (z0qtk().z0vtk().BehaviorOptions.ResetTextFormatWhenCreateNewLine)
							{
								DocumentContentStyle p1 = (DocumentContentStyle)z0qtk().z0dik().Clone();
								z0npk.z0onk().z0eek(p1);
								z0npk.z0onk().z0rek(p1);
							}
							else
							{
								z0npk.z0onk().z0tek().Font = documentContentStyle.Font;
								z0npk.z0onk().z0iek().Font = documentContentStyle.Font;
							}
						}
						if (text.Trim().Length == text.Length)
						{
							z0duk();
						}
					}
					z0byk().z0um(p0: false);
				}
			}
			p0.z0eek(p0: true);
		}
	}

	public void z0uek(z0ZzZzheh p0)
	{
		z0ec(p0);
	}

	internal z0ZzZzpnj z0ftk()
	{
		return z0tpk;
	}

	protected override void z0xjk(z0ZzZzweh p0)
	{
		if (!z0xtk())
		{
			return;
		}
		base.z0xjk(p0);
		if (z0npk == null)
		{
			return;
		}
		if (z0urk() == WriterControlExtViewMode.BoundsSelection)
		{
			z0fx(z0ZzZzbwh.z0grk);
			return;
		}
		if (z0urk() == WriterControlExtViewMode.JumpPrint || z0urk() == WriterControlExtViewMode.OffsetJumpPrint)
		{
			z0fx(z0ZzZzbwh.z0vek);
			return;
		}
		z0ZzZzndh z0ZzZzndh2 = z0jrk();
		if (!z0ZzZzndh2.z0vek() && z0ZzZzndh2.z0eek(p0.z0rek(), p0.z0tek()))
		{
			z0fx(z0ZzZzbwh.z0krk);
			return;
		}
		z0tek(p0, DocumentEventStyles.MouseMove);
		bool flag = false;
		foreach (z0ZzZzwrj item in base.z0frk())
		{
			if (item.z0erk().z0eek(p0.z0rek(), p0.z0tek()))
			{
				flag = true;
				break;
			}
		}
	}

	public void z0tek(z0ZzZzzlh p0, PageContentPartyStyle p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("line");
		}
		z0ZzZzbdh p2 = p0.z0krk();
		p2.z0tek(p0.z0nrk());
		if (!p0.z0tek())
		{
			z0ZzZzmpj z0ZzZzmpj2 = null;
			if (z0qtk().z0iu().AdornTextVisibility != DCAdornTextVisibility.Hidden)
			{
				z0ZzZzmpj2 = z0qtk().z0jtk();
			}
			int count = p0.Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = array[i];
				if (xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement)
				{
					continue;
				}
				if (xTextElement is XTextObjectElement && (xTextElement.z0aek().z0xyk == ContentLayoutAlign.Surroundings || xTextElement.z0ci() != ElementZOrderStyle.Normal))
				{
					p2 = z0ZzZzbdh.z0yek(p2, xTextElement.z0qyk());
				}
				if (z0ZzZzmpj2 != null)
				{
					z0ZzZzbdh p3 = z0ZzZzmpj2.z0eek(xTextElement);
					if (!p3.z0bek())
					{
						p2 = z0ZzZzbdh.z0yek(p2, p3);
					}
				}
			}
		}
		z0tek(p2, p1);
	}

	public object z0pek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		p0 = p0.Trim();
		z0ZzZziik z0ZzZziik2 = new z0ZzZziik(p0);
		string text = z0ZzZziik2.z0eek(',');
		if (text != null)
		{
			text = text.Trim();
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		z0ZzZziik2.z0rek();
		string text2 = z0ZzZziik2.z0eek(',');
		bool p1 = true;
		if (text2 != null)
		{
			text2 = text2.Trim();
			if (text2 == "0" || string.Compare(text2, "false", StringComparison.OrdinalIgnoreCase) == 0)
			{
				p1 = false;
			}
		}
		z0ZzZziik2.z0rek();
		string text3 = z0ZzZziik2.z0eek();
		if (text3 != null)
		{
			text3 = text3.Trim();
			if (text3.Length > 1)
			{
				if (text3[0] == '\'' && text3[text3.Length - 1] == '\'')
				{
					text3 = text3.Substring(1, text3.Length - 1);
				}
				else if (text3[0] == '"' && text3[text3.Length - 1] == '"')
				{
					text3 = text3.Substring(1, text3.Length - 1);
				}
			}
		}
		return z0tek(text, p1, text3);
	}

	public void z0yek(XTextDocument p0)
	{
		z0npk = p0;
		if (z0npk != null)
		{
			if (z0crk() != null)
			{
				z0npk.z0bek(z0crk());
			}
			z0npk.z0bek(z0xek());
			z0npk.z0bek(z0byk());
			z0pok.z0yn(z0npk);
			z0npk.z0bek(z0crk());
			z0npk.z0xyk().z0gu();
			z0vpk = null;
		}
	}

	protected override void z0bc(z0ZzZzleh p0)
	{
		if (z0mok == DragOperationState.None)
		{
			z0mok = DragOperationState.Drag;
		}
		if (z0npk != null)
		{
			z0rek(p0: false);
			z0tek(p0, 1);
			if (z0mok != DragOperationState.DragDropInOwnerWriterControl)
			{
				z0mok = DragOperationState.None;
			}
		}
	}

	public void z0mek(string p0)
	{
		if (z0fpk != p0)
		{
			z0fpk = p0;
			StatusTextChangedEventArgs p1 = new StatusTextChangedEventArgs(z0xek(), z0fpk);
			z0xek().z0eek(p1);
		}
	}

	private object z0dtk()
	{
		if (z0zik is z0ZzZzipk z0ZzZzipk2 && z0ZzZzipk2.z0yek != z0ZzZzxcj.z0eek())
		{
			z0ZzZzipk2.z0rek();
			z0zik = null;
		}
		if (z0zik == null)
		{
			z0ZzZzipk z0ZzZzipk3 = new z0ZzZzipk();
			z0tek((object)z0ZzZzipk3);
			if (z0ZzZzipk3.Count > 0)
			{
				using z0ZzZzjpk p = z0krk();
				int num = 200;
				z0ZzZzipk3.z0eek(p, new z0ZzZzndh(z0vek() - num - 20, 10, num, z0frk()), ((z0ZzZzmwh)this).z0xek(), 4f, StringAlignment.Far);
			}
		}
		return z0zik;
	}

	public void z0yek(XTextElement p0)
	{
		if (p0 == null)
		{
			z0pik = null;
		}
		else
		{
			z0pik = z0nek(p0);
		}
	}

	public bool z0stk()
	{
		if (z0oc())
		{
			return true;
		}
		if (z0bpk)
		{
			return true;
		}
		return false;
	}

	public bool z0tek(string p0, string p1)
	{
		z0opk = null;
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("text");
		}
		p0 = p0.Trim();
		if (p0.Length == 0)
		{
			return false;
		}
		if (p0 != null && (p1 == null || string.Compare(p1, "xml", StringComparison.OrdinalIgnoreCase) == 0))
		{
			int num = p0.IndexOf('<');
			if (num > 0)
			{
				p0 = p0.Substring(num);
			}
		}
		StringReader p2 = new StringReader(p0);
		return z0tek(p2, p1);
	}

	public void z0tek(z0ZzZzymj p0)
	{
		if (z0qik != p0 && z0qik != null && p0 != null)
		{
			if (z0dpk == null)
			{
				z0dpk = new List<z0ZzZzymj>();
			}
			z0dpk.Add(z0qik);
			z0dpk.Add(p0);
		}
		else if (z0qik != null && p0 == null && z0dpk != null && z0dpk.Contains(z0qik))
		{
			z0dpk.Remove(z0qik);
		}
		z0qik = p0;
		if (z0qik != null)
		{
			if (z0qik.EditControl != null && z0qik.EditControl.z0ypk() != null)
			{
				z0qik.EditControl.z0ypk().z0qik = null;
			}
			z0qik = p0;
			z0qik.CommandContainer = z0suk().z0yek();
			z0qik.EditControl = z0xek();
		}
	}

	public XTextElement z0atk()
	{
		return z0rpk;
	}

	public XTextDocument z0qtk()
	{
		if (((z0ZzZzmwh)this).z0rek())
		{
			return null;
		}
		if (z0aik)
		{
			return z0npk;
		}
		if (z0npk == null)
		{
			z0npk = XTextDocument.z0kok();
			z0npk.z0pok();
			try
			{
				z0npk.z0bek(z0crk());
				z0npk.z0bek(z0xek());
				z0npk.z0bek(z0byk());
				if (z0rik)
				{
					z0zek(p0: false);
				}
			}
			finally
			{
				z0npk.z0smk();
			}
		}
		else if (!z0npk.z0qtk().Printing && !z0npk.z0qtk().PrintPreviewing)
		{
			z0npk.z0bek(z0crk());
			z0npk.z0bek(z0vuk);
			z0npk.z0bek(z0pok);
		}
		if (z0pok != null)
		{
			z0pok.z0yn(z0npk);
		}
		return z0npk;
	}

	public WriterDataFormats z0wtk()
	{
		return z0crk().BehaviorOptions.AcceptDataFormats;
	}

	public bool z0tek(UserLoginInfo p0, bool p1)
	{
		return z0yek(p0, p1);
	}

	public int z0etk()
	{
		if (z0eek() == null)
		{
			return z0otk();
		}
		return z0eek().z0yek();
	}

	public void z0rtk()
	{
		if (z0apk)
		{
			if (z0npk == null)
			{
				z0npk = new XTextDocument();
			}
			z0npk.z0juk();
			base.z0xrk = z0npk.z0suk();
			base.z0vrk = true;
			z0xek().z0knk.z0eek(p0: false);
			z0xek().z0xmk.z0eek(p0: false);
			z0xek().z0ij(z0tek(base.z0xrk));
		}
		else if (z0npk == null || !z0npk.z0frk())
		{
			if (z0npk != null)
			{
				z0qtk().z0li();
			}
			z0xyk();
		}
	}

	public bool z0ttk()
	{
		return z0qtk().Modified;
	}

	internal bool z0yek(int p0, int p1)
	{
		z0ZzZzhkh z0ZzZzhkh2 = z0wrk();
		if (z0ZzZzhkh2 == null || z0ZzZzhkh2.z0qrk() == 0)
		{
			return false;
		}
		z0fhk();
		z0ZzZzsmk z0ZzZzsmk2 = base.z0lrk().z0eek(p0, p1, p2: true, p3: true, p4: true);
		if (z0ZzZzsmk2 == null)
		{
			return false;
		}
		z0ZzZzodh p2 = new z0ZzZzodh(p0, p1);
		p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk2.z0tek_jiejie20260327142557());
		if (p2.z0tek() > p1)
		{
			int num = p2.z0tek();
			p2.z0rek(num + 1);
		}
		if (p2.z0tek() == z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek())
		{
			p2.z0rek(z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek() - 2);
		}
		p2 = z0ZzZzsmk2.z0gwk(p2.z0rek(), p2.z0tek());
		if (z0ZzZzhkh2.z0irk() != null && z0ZzZzhkh2.z0irk().Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0irk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement.z0bek())
				{
					xTextTableCellElement = xTextTableCellElement.z0hrk();
				}
				if (xTextTableCellElement.z0yi() && xTextTableCellElement.z0qyk().z0eek(p2.z0rek(), p2.z0tek()))
				{
					return true;
				}
			}
		}
		if (z0ZzZzhkh2.z0grk() != null && z0ZzZzhkh2.z0grk().Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0grk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				z0ZzZzzlh z0ZzZzzlh2 = current.z0ptk();
				if (new z0ZzZzbdh(z0ZzZzzlh2.z0xtk() + current.z0it(), z0ZzZzzlh2.z0xrk(), current.Width + current.z0pt(), z0ZzZzzlh2.z0ytk()).z0eek(p2.z0rek(), p2.z0tek()))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void z0tek(z0ZzZzkkh p0)
	{
		z0tek((IEnumerable)p0);
	}

	public void z0tek(z0ZzZzreh p0)
	{
		z0jz(p0);
	}

	internal bool z0ytk()
	{
		bool result = false;
		XTextDocument xTextDocument = z0npk;
		if (xTextDocument != null)
		{
			switch (z0itk())
			{
			case FunctionControlVisibility.Auto:
				if (xTextDocument.Comments.z0eek())
				{
					result = true;
				}
				else if (xTextDocument.z0enk() != null && xTextDocument.z0enk().Count > 0)
				{
					result = true;
				}
				break;
			case FunctionControlVisibility.Hide:
				result = false;
				break;
			case FunctionControlVisibility.Visible:
				result = true;
				break;
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	internal new void z0vek(bool p0)
	{
		z0buk = p0;
	}

	private object z0oek(int p0)
	{
		return XTextDocument.z0bek(this, p0);
	}

	public bool z0utk()
	{
		return z0jok;
	}

	public override z0ZzZzodh z0nc(int p0, int p1)
	{
		if (z0eek() == null)
		{
			return base.z0nc(p0, p1);
		}
		return z0eek().z0gwk(p0, p1);
	}

	public override void z0lz_jiejie20260327142557()
	{
		base.z0lz_jiejie20260327142557();
		z0qok = null;
		z0vik = null;
		if (z0jpk != null)
		{
			z0jpk.z0eek();
			z0jpk = null;
		}
		if (z0cok != null)
		{
			z0cok.Dispose();
			z0cok = null;
		}
		if (z0npk != null)
		{
			z0npk.Dispose();
			z0npk = null;
		}
		z0cok = null;
		if (z0dok != null)
		{
			z0dok.z0eek();
			z0dok = null;
		}
		if (z0zik != null)
		{
			((z0ZzZzipk)z0zik).z0rek();
			z0zik = null;
		}
		z0cek();
		z0aik = true;
		if (z0jik != null)
		{
			z0jik.z0eek();
			z0jik = null;
		}
		if (z0ppk != null)
		{
			z0ppk.z0eek();
			z0ppk = null;
		}
		if (z0vpk != null)
		{
			z0vpk.z0fb();
			z0vpk = null;
		}
		z0vuk = null;
		if (z0qik != null)
		{
			if (z0qik.EditControl == z0xek())
			{
				z0qik.EditControl = null;
			}
			z0qik = null;
		}
		if (z0npk != null && z0npk.z0yyk() == z0xek())
		{
			z0npk.z0bek((z0ZzZzdbj)null);
		}
		if (z0ypk && z0npk != null)
		{
			z0npk.Dispose();
			z0npk = null;
		}
		if (z0pok != null)
		{
			z0pok.z0jm();
			z0pok.z0zp();
			z0pok = null;
		}
		if (z0eok != null)
		{
			z0eok.Clear();
			z0eok = null;
		}
		if (z0bok != null)
		{
			z0bok.z0uek();
			z0bok = null;
		}
		if (z0cuk_jiejie20260327142557 != null)
		{
			z0cuk_jiejie20260327142557.z0uek();
			z0cuk_jiejie20260327142557 = null;
		}
		z0kpk = null;
		z0hpk = null;
		z0uok = null;
		z0pik = null;
		z0vuk = null;
		z0jik = null;
		z0rpk = null;
		z0dok = null;
		z0dok = null;
		if (z0iik != null)
		{
			z0iik.Clear();
			z0iik = null;
		}
		if (z0bik != null)
		{
			z0bik.Dispose();
			z0bik = null;
		}
		z0vuk = null;
		z0hpk = null;
		z0qik = null;
		z0iik = null;
		z0vpk = null;
		z0pok = null;
		z0jik = null;
		z0rpk = null;
		z0bik = null;
		z0bok = null;
		z0kpk = null;
		z0dok = null;
		z0hpk = null;
		z0pik = null;
		z0vuk = null;
		z0zuk = null;
		z0fok = null;
		z0tpk = null;
		z0uok = null;
	}

	private void z0tek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		if (z0npk == null || !z0npk.z0lrk(p0: true) || (((z0ZzZzqrj)this).z0cek() != PageViewMode.Page && ((z0ZzZzqrj)this).z0cek() != PageViewMode.CompressPage) || !z0ytk())
		{
			return;
		}
		foreach (z0ZzZzsmk item in base.z0lrk())
		{
			if (item.z0vek() == PageContentPartyStyle.Body && item.z0cek() != null)
			{
				z0ZzZzopk z0ZzZzopk2 = base.z0eek(new z0ZzZzopk(p0, new z0ZzZzndh((int)p1.z0oek(), (int)p1.z0pek(), (int)p1.z0uek(), (int)p1.z0iek())), item, p2: false);
				if (z0ZzZzopk2 != null)
				{
					z0ZzZzopk2.z0rek().z0rek();
					z0drk().z0ab(z0ZzZzopk2.z0rek(), z0ZzZzopk2.z0eek().z0eek(), (z0ZzZzwrj)item.z0cek(), p3: true);
				}
			}
		}
	}

	public bool z0yek(UserLoginInfo p0, bool p1)
	{
		return z0ZzZzdfh.z0rek().z0id(this, p0, p1);
	}

	protected override void z0mc(z0ZzZzleh p0)
	{
		p0.z0eek((z0ZzZzzwh)0);
		if (z0npk != null)
		{
			p0.z0eek((z0ZzZzzwh)0);
			z0tek(p0, 0);
		}
	}

	public FunctionControlVisibility z0itk()
	{
		return z0crk().BehaviorOptions.CommentVisibility;
	}

	public void z0tek(z0ZzZzleh p0)
	{
		z0mc(p0);
	}

	public new void z0cek(bool p0)
	{
		z0ook = p0;
		if (z0pok != null)
		{
			z0byk().z0pp(p0);
		}
	}

	public void z0uek(XTextElement p0)
	{
		if (((z0ZzZzspj)this).z0hrk() || z0npk == null || p0 == null)
		{
			return;
		}
		bool p1 = false;
		if (z0ntk())
		{
			p1 = true;
		}
		else
		{
			z0ZzZzivj.z0yek = false;
			try
			{
				p1 = !z0byk().z0np(p0);
			}
			finally
			{
				z0ZzZzivj.z0yek = true;
			}
		}
		if (p0.z0ptk() == null)
		{
			return;
		}
		float num = 3.125f;
		float num2 = p0.z0ptk().z0xrk();
		XTextDocumentContentElement xTextDocumentContentElement = z0npk.z0jrk();
		if (xTextDocumentContentElement.z0frk().z0frk() && xTextDocumentContentElement.z0oek().z0qrk() == 0)
		{
			XTextElement xTextElement = xTextDocumentContentElement.z0frk().z0nek(p0);
			if (xTextElement == null)
			{
				xTextElement = p0;
			}
			float num3 = xTextElement.z0ltk();
			float num4 = xTextElement.z0ltk() + xTextElement.Height + num;
			if (xTextElement.z0ptk() != null)
			{
				num3 = Math.Max(num3, xTextElement.z0ptk().z0xrk());
				num4 = Math.Min(xTextElement.z0ptk().z0xrk() + xTextElement.z0ptk().z0ytk(), num4);
			}
			if (z0pek() && z0wrk().z0qrk() != 0)
			{
				base.z0oek();
				z0eek((int)xTextElement.z0zrk(), (int)num3, (int)xTextElement.Width, (int)(num4 - num3));
				return;
			}
			if (z0oc() || z0eek())
			{
				base.z0yek();
			}
			z0eek((int)(xTextElement.z0zrk() + xTextElement.Width - 1f), (int)num4, (int)(num4 - num3), (int)xTextElement.Width, p1);
			return;
		}
		int num5 = 0;
		XTextElement xTextElement2 = p0;
		z0ZzZzzlh z0ZzZzzlh2 = p0.z0ptk();
		if (z0ZzZzzlh2 != null)
		{
			xTextElement2 = z0ZzZzzlh2.z0urk().z0pek(p0);
			if (xTextElement2 == null)
			{
				xTextElement2 = p0;
			}
			else if (xTextElement2 is z0ZzZzgkh || xTextElement2 is XTextTableElement || xTextElement2 is XTextSectionElement)
			{
				xTextElement2 = p0;
				num5 = 10;
			}
		}
		if (z0pek() && z0wrk().z0qrk() != 0)
		{
			if (base.z0uek())
			{
				z0eek((int)p0.z0zrk(), (int)p0.z0ltk(), (int)p0.Width, (int)p0.Height);
			}
			return;
		}
		if (z0oc() || z0eek())
		{
			base.z0yek();
		}
		float num6 = xTextElement2.Height;
		float num7 = xTextElement2.z0ltk();
		if (xTextElement2.z0ptk() != null)
		{
			num7 = Math.Max(num7, xTextElement2.z0ptk().z0xrk());
			num6 = Math.Min(num6, xTextElement2.z0ptk().z0ytk());
		}
		float num8 = p0.z0zrk();
		if (p0.z0jy() is XTextTableCellElement xTextTableCellElement && xTextTableCellElement.z0trk()[0] == p0 && xTextTableCellElement.z0aek().z0ryk == 0f)
		{
			num8 += 7f;
		}
		xTextElement2.z0ptk();
		z0eek((int)num8 + num5, (int)Math.Max(num2, num7 + num6 + num), (int)num6, (int)p0.Width, p1);
	}

	public bool z0tek(Stream p0, string p1)
	{
		z0opk = null;
		if (p0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		z0xek().z0wik();
		XTextDocument xTextDocument = z0qtk();
		try
		{
			xTextDocument.z0pok();
			xTextDocument.z0quk();
			z0uyk();
			string p2 = xTextDocument.z0amk();
			try
			{
				xTextDocument.z0bek(p0: false);
				xTextDocument.z0bek(p0, p1);
			}
			finally
			{
				xTextDocument.z0bek(p0: true);
			}
			z0xek().z0wik();
			xTextDocument.z0cek(p2);
			z0xyk();
			if (z0crk().BehaviorOptions.AutoDocumentValueValidate)
			{
				xTextDocument.z0stk();
			}
			xTextDocument.Modified = false;
			z0hz();
			z0xek().z0eek(new WriterEventArgs(z0xek(), xTextDocument, null));
		}
		finally
		{
			xTextDocument.z0qmk();
			xTextDocument.z0smk();
		}
		z0nok = false;
		return true;
	}

	public z0ZzZzqbj(z0ZzZzdbj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		z0vuk = p0;
		z0sik++;
		if (z0jik != null)
		{
			z0jik.z0eek(this);
		}
		((z0ZzZzgpj)this).z0rek = true;
	}

	public int z0otk()
	{
		z0ZzZzwrj z0ZzZzwrj2 = z0npk?.z0ryk()?.z0lrk()?.z0dtk();
		if (z0ZzZzwrj2 == null || base.z0xrk == null)
		{
			return 0;
		}
		return base.z0xrk.IndexOf(z0ZzZzwrj2);
	}

	protected override void z0pc(z0ZzZzopk p0, z0ZzZzsmk p1)
	{
		if (z0urk() == WriterControlExtViewMode.BoundsSelection && (p1.z0vek() == PageContentPartyStyle.Body || p1.z0vek() == PageContentPartyStyle.HeaderRows))
		{
			z0ZzZzndh p2 = p0.z0eek(p1.z0tek_jiejie20260327142557());
			if (p2.z0vek())
			{
				return;
			}
			using z0ZzZzvdh z0ZzZzvdh2 = new z0ZzZzvdh(p2);
			List<z0ZzZzndh> list = new List<z0ZzZzndh>();
			foreach (z0ZzZzcej item in z0lyk())
			{
				if (item.z0tek() == p1.z0yek())
				{
					z0ZzZzbdh p3 = z0ZzZzbdh.z0tek(item.z0eek(), p1.z0rek());
					if (!p3.z0bek())
					{
						z0ZzZzbdh z0ZzZzbdh2 = ((z0ZzZzqmk)p1).z0rek(p3);
						z0ZzZzndh z0ZzZzndh2 = new z0ZzZzndh((int)z0ZzZzbdh2.z0oek(), (int)z0ZzZzbdh2.z0pek(), (int)z0ZzZzbdh2.z0uek(), (int)z0ZzZzbdh2.z0iek());
						list.Add(z0ZzZzndh2);
						z0ZzZzndh2 = z0ZzZzndh.z0tek(z0ZzZzndh2, p0.z0eek());
						z0ZzZzvdh2.z0eek(z0ZzZzndh2);
					}
				}
			}
			using (z0ZzZzzdh p4 = new z0ZzZzzdh(Color.FromArgb(140, base.z0jrk())))
			{
				p0.z0rek().z0eek(p4, z0ZzZzvdh2);
			}
			if (list.Count <= 0)
			{
				return;
			}
			foreach (z0ZzZzndh item2 in list)
			{
				p0.z0rek().z0eek(z0ZzZzidh.z0cek, item2.z0pek(), item2.z0mek(), item2.z0iek() - 1, item2.z0oek() - 1, 0f);
			}
			return;
		}
		if (p1.z0oek() || !p1.z0nek() || !z0tyk() || !z0crk().ViewOptions.ShowGrayMaskOverDisableContentParty)
		{
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = null;
		if (p1.z0vek() == PageContentPartyStyle.Header)
		{
			xTextDocumentContentElement = ((XTextDocument)p1.z0eek()).z0pyk();
		}
		else if (p1.z0vek() == PageContentPartyStyle.Footer)
		{
			xTextDocumentContentElement = ((XTextDocument)p1.z0eek()).z0lik();
		}
		if (p1.z0vek() == PageContentPartyStyle.HeaderForFirstPage)
		{
			xTextDocumentContentElement = ((XTextDocument)p1.z0eek()).z0cyk();
		}
		else if (p1.z0vek() == PageContentPartyStyle.FooterForFirstPage)
		{
			xTextDocumentContentElement = ((XTextDocument)p1.z0eek()).z0guk();
		}
		if (xTextDocumentContentElement != null && !xTextDocumentContentElement.z0fi())
		{
			return;
		}
		z0ZzZzndh z0ZzZzndh3 = p0.z0eek(p1.z0tek_jiejie20260327142557());
		if (!z0ZzZzndh3.z0vek())
		{
			using (z0ZzZzzdh p5 = new z0ZzZzzdh(Color.FromArgb(140, base.z0jrk())))
			{
				p0.z0rek().z0eek(p5, z0ZzZzndh3.z0pek(), z0ZzZzndh3.z0mek(), z0ZzZzndh3.z0iek() + 2, z0ZzZzndh3.z0oek() + 2);
			}
		}
	}

	internal string z0tek(bool p0, z0bnk p1)
	{
		z0cok = p1;
		if (z0gpk != null && z0gpk.Count > 0)
		{
			if (p1 == null || p1.z0blk())
			{
				return z0tek(base.z0xrk, p0);
			}
			if (p1.z0nlk() > 0)
			{
				z0gpk.z0rek().z0bek((float)p1.z0nlk());
			}
			z0ZzZzerj z0ZzZzerj2 = new z0ZzZzerj();
			foreach (XTextDocument item in z0gpk)
			{
				item.z0bek(z0xek());
				item.z0bek(p1.z0lkk());
				if (p1.z0nlk() > 0)
				{
					item.z0krk();
				}
				z0ZzZzerj2.AddRange(item.z0suk());
			}
			p1.z0olk(z0gpk.z0rek());
			for (int i = 0; i < z0ZzZzerj2.Count; i++)
			{
				z0ZzZzerj2[i].z0eek(i);
			}
			z0ZzZzerj p2 = z0tek(z0ZzZzerj2, p1, z0gpk, p0);
			base.z0vrk = true;
			return z0tek(p2, p0);
		}
		return null;
	}

	public bool z0tek(XTextContainerElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0.z0eu())
		{
			p0.z0oe();
			z0qtk().Modified = true;
			z0xek().z0tek((EventArgs)null);
			z0xek().z0eek((EventArgs)null);
			return true;
		}
		return false;
	}

	public override bool z0oc()
	{
		return true;
	}

	public void z0tek(WriterDataFormats p0)
	{
		z0crk().BehaviorOptions.AcceptDataFormats = p0;
	}

	public void z0tek(DocumentOptions p0)
	{
		z0jik = p0;
		if (z0npk != null)
		{
			z0npk.z0bek(z0jik);
			z0jik.z0eek(this);
		}
	}

	private void z0tek(object p0)
	{
		z0ZzZzipk z0ZzZzipk2 = (z0ZzZzipk)(z0zik = new z0ZzZzipk());
		z0ZzZzipk2.z0yek = z0ZzZzxcj.z0eek();
		z0ZzZzxpk z0ZzZzxpk2 = (z0ZzZzxpk)z0oek(0);
		if (!z0ZzZzxpk2.z0yek)
		{
			return;
		}
		using (z0ZzZzjpk z0ZzZzjpk2 = z0krk())
		{
			_ = z0ZzZzxpk2.z0yek;
			z0ZzZzjpk2.z0eek(GraphicsUnit.Pixel);
			z0ZzZzjpk2.z0zek();
			z0ZzZzjpk2.z0rek();
			if (base.z0frk() != null && base.z0frk().Count > 0)
			{
				if (z0ZzZzxpk2.z0nek is z0ZzZzwok)
				{
					if (((z0ZzZzwok)z0ZzZzxpk2.z0nek).z0rek() <= 0)
					{
						z0ZzZzxpk2.z0nek = new z0ZzZzwok("南京都昌信息科技有限公司");
					}
				}
				else
				{
					string text = z0ZzZzxpk2.z0eek();
					if (text.Length == 0)
					{
						z0ZzZzxpk2.z0nek = new z0ZzZzwok("南京都昌信息科技有限公司");
					}
					else
					{
						z0ZzZzxpk2.z0nek = new z0ZzZzwok(text);
					}
				}
				for (int i = 0; i < base.z0frk().Count && (z0ZzZzxpk2.z0uek <= 0 || i < z0ZzZzxpk2.z0uek); i++)
				{
					z0ZzZzwrj z0ZzZzwrj2 = base.z0frk()[i];
					z0ZzZzndh z0ZzZzndh2 = z0ZzZzwrj2.z0erk();
					z0tek(z0ZzZzxpk2, z0ZzZzwrj2);
					z0ZzZzjpk p1 = z0ZzZzjpk2;
					z0ZzZzbdh p2 = z0ZzZzndh2.z0eek();
					if (z0ZzZzxpk2.z0iek)
					{
						z0ZzZzxpk2.z0tek = 1;
						z0ZzZzxpk2.z0eek(p1, p2, p2: true, z0ZzZzipk2);
						z0ZzZzxpk2.z0tek = 8;
						z0ZzZzxpk2.z0eek(p1, p2, p2: true, z0ZzZzipk2);
					}
					else
					{
						z0ZzZzxpk2.z0eek(p1, p2, p2: true, z0ZzZzipk2);
					}
					if (base.z0hrk())
					{
						break;
					}
				}
				z0ZzZzxpk.z0mek = null;
			}
		}
		string text2 = null;
		z0ZzZzwok z0ZzZzwok2 = null;
		foreach (z0ZzZzupk item in z0ZzZzipk2)
		{
			if (item.z0yek is string)
			{
				string text3 = (string)item.z0yek;
				if (text3 == text2)
				{
					item.z0yek = z0ZzZzwok2;
					continue;
				}
				text2 = text3;
				z0ZzZzwok2 = (z0ZzZzwok)(item.z0yek = new z0ZzZzwok(text2));
			}
		}
	}

	internal bool z0ptk()
	{
		int num = XTextDocument.z0aik();
		if (num != z0yok)
		{
			z0yok = num;
			XTextDocument.z0hrk();
			z0hz();
			return false;
		}
		return true;
	}

	public void z0yek(z0ZzZzleh p0)
	{
		z0bc(p0);
	}

	public void z0xek(bool p0)
	{
		z0spk = p0;
	}

	public int z0mtk()
	{
		return (z0npk?.z0ryk()?.z0lrk())?.z0hrk() ?? (-1);
	}

	public override string z0jhk()
	{
		if (z0qtk() != null)
		{
			return z0qtk().Text;
		}
		return string.Empty;
	}

	public ContentEffects z0zek(bool p0)
	{
		if (z0rik)
		{
			return z0tek(new z0ZzZzimk(((z0ZzZzmwh)this).z0xek()), ((z0ZzZzmwh)this).z0yek(), p0);
		}
		return ContentEffects.None;
	}

	public bool z0ntk()
	{
		return z0lok;
	}

	public bool z0btk()
	{
		if (z0qtk().z0eu())
		{
			z0qtk().Modified = true;
			z0tek(p0: false, p1: true);
			z0xek().z0tek((EventArgs)null);
			z0xek().z0eek((EventArgs)null);
		}
		return true;
	}

	public bool z0vtk()
	{
		return z0crk().BehaviorOptions.CommentEditableWhenReadonly;
	}

	public bool z0ctk()
	{
		return z0crk().BehaviorOptions.DoubleClickToEditComment;
	}

	public void z0tek(XPageSettings p0)
	{
		if (z0npk != null)
		{
			z0npk.PageSettings = p0;
		}
	}

	internal bool z0tek(byte[] p0, string p1)
	{
		MemoryStream p2 = new MemoryStream(p0);
		return z0tek(p2, p1);
	}

	public bool z0yek(string p0, string p1, int p2)
	{
		return z0tek(p0, p1, p2);
	}

	public void z0lrk(bool p0)
	{
		z0jok = p0;
	}

	internal bool z0xtk()
	{
		if (z0rok > 0)
		{
			if (DateTime.Now.Ticks > z0rok)
			{
				z0rok = 0L;
				return true;
			}
			return false;
		}
		return true;
	}

	public string z0pek(int p0)
	{
		z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
		if (p0 >= 0 && p0 < z0ZzZzerj2.Count)
		{
			z0ZzZzwrj z0ZzZzwrj2 = z0ZzZzerj2[p0];
			z0ZzZzndh z0ZzZzndh2 = z0ZzZzwrj2.z0ntk;
			if (!z0ZzZzndh2.z0vek())
			{
				float num = z0kyk();
				return z0ZzZzqik.z0eek((float)(z0ZzZzndh2.z0pek() - z0ZzZzwrj2.z0erk().z0pek()) * num) + "," + z0ZzZzqik.z0eek((float)(z0ZzZzndh2.z0mek() - z0ZzZzwrj2.z0erk().z0mek()) * num) + "," + z0ZzZzqik.z0eek((float)z0ZzZzndh2.z0iek() * num) + "," + z0ZzZzqik.z0eek((float)z0ZzZzndh2.z0oek() * num);
			}
		}
		return null;
	}

	public void z0tek(z0ZzZzyrj p0)
	{
		z0kpk = p0;
	}

	internal bool z0uek(int p0, int p1)
	{
		z0ZzZzsmk z0ZzZzsmk2 = null;
		z0ZzZzsmk2 = base.z0lrk().z0eek(p0, p1, p2: true, p3: true, p4: true);
		if (z0ZzZzsmk2 != null && z0npk != null)
		{
			z0ZzZzodh p2 = new z0ZzZzodh(p0, p1);
			p2 = z0ZzZzjmk.z0eek(p2, z0ZzZzsmk2.z0tek_jiejie20260327142557());
			if (p2.z0tek() == z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek())
			{
				p2.z0rek(z0ZzZzsmk2.z0tek_jiejie20260327142557().z0bek() - 2);
			}
			p2 = z0ZzZzsmk2.z0gwk(p2.z0rek(), p2.z0tek());
			z0npk.z0ryk().z0uek(p0: true);
			z0npk.z0ryk().z0tek((float)p2.z0rek(), (float)p2.z0tek());
			z0nek();
			return true;
		}
		return false;
	}

	internal void z0tek(int p0, int p1, int p2, int p3, z0ZzZzupj p4)
	{
		z0fhk();
		z0ZzZzodh p5 = z0jx().z0jwk(p0, p1);
		z0ZzZzodh p6 = z0jx().z0jwk(p2, p3);
		z0ZzZzndh p7 = z0ZzZzjmk.z0eek(p5, p6);
		p7.z0tek(p7.z0iek() + 1);
		p7.z0yek(p7.z0oek() + 1);
		for (int i = 0; i < base.z0frk().Count; i++)
		{
			z0ZzZzwrj z0ZzZzwrj2 = base.z0frk()[i];
			if (z0ZzZzwrj2.z0erk().z0rek(p7))
			{
				z0ayk().z0mz(i, p5.z0rek() - z0ZzZzwrj2.z0erk().z0pek(), p5.z0tek() - z0ZzZzwrj2.z0erk().z0mek(), p6.z0rek() - z0ZzZzwrj2.z0erk().z0pek(), p6.z0tek() - z0ZzZzwrj2.z0erk().z0mek(), (int)p4);
				break;
			}
		}
	}

	public bool z0ztk()
	{
		z0ayk()?.z0slk();
		return false;
	}

	public z0ZzZzvej z0lyk()
	{
		if (z0npk == null)
		{
			return null;
		}
		return z0npk.z0jik();
	}

	internal void z0tek(PageContentPartyStyle p0)
	{
		XTextDocument xTextDocument = z0qtk();
		if (xTextDocument.z0oik() == p0)
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextDocumentContentElement xTextDocumentContentElement = (XTextDocumentContentElement)z0bpk.Current;
			if (xTextDocumentContentElement.z0fu() == p0)
			{
				XTextDocumentContentElement xTextDocumentContentElement2 = xTextDocument.z0jrk();
				xTextDocument.z0bek(xTextDocumentContentElement);
				xTextDocument.z0jrk().z0tek(xTextDocumentContentElement2.z0zek(), xTextDocumentContentElement.z0zek());
				xTextDocument.z0jrk().z0gu();
				z0sc();
				z0hz();
				if (z0ZzZzdpk.z0eek(xTextDocumentContentElement.z0fu()) && z0oyk())
				{
					z0nek();
				}
			}
		}
	}

	private void z0tek(z0ZzZzwrj p0, z0ZzZzndh p1)
	{
		if (z0nok || p0 == null || p1.z0iek() <= 0 || p1.z0oek() <= 0)
		{
			return;
		}
		if (z0eok == null)
		{
			z0eok = new List<z0qgj>();
		}
		bool flag = true;
		for (int i = 0; i < z0eok.Count; i++)
		{
			z0qgj z0qgj = z0eok[i];
			if (z0qgj.z0tek == p0)
			{
				if (z0qgj.z0eek.z0eek(p1))
				{
					flag = false;
					break;
				}
				if (p1.z0eek(z0qgj.z0eek))
				{
					z0qgj.z0eek = p1;
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			for (int num = z0eok.Count - 1; num >= 0; num--)
			{
				z0qgj z0qgj2 = z0eok[num];
				if (z0qgj2.z0tek == p0)
				{
					z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0yek(z0qgj2.z0eek, p1);
					int num2 = z0qgj2.z0eek.z0iek() * z0qgj2.z0eek.z0oek() + p1.z0iek() * p1.z0oek();
					if ((float)(z0ZzZzndh2.z0iek() * z0ZzZzndh2.z0oek()) < (float)num2 * 1.5f)
					{
						z0qgj2.z0eek = z0ZzZzndh2;
						flag = false;
						break;
					}
				}
			}
		}
		if (flag)
		{
			z0qgj z0qgj3 = new z0qgj();
			z0qgj3.z0tek = p0;
			z0qgj3.z0rek = ((z0ZzZzqrj)this).z0rek().IndexOf(p0);
			z0qgj3.z0eek = p1;
			z0eok.Add(z0qgj3);
		}
		if (z0ayk() != null)
		{
			z0ayk().z0hlk();
		}
	}

	public float z0kyk()
	{
		return z0xek().z0vtk();
	}

	public void z0jyk()
	{
		if (z0gpk != null)
		{
			foreach (XTextDocument item in z0gpk)
			{
				item.Dispose();
			}
			z0gpk.Clear();
			z0gpk = null;
		}
		if (z0npk != null)
		{
			z0npk.Dispose();
			z0npk = null;
		}
		z0rtk();
	}

	private void z0eek(StringBuilder p0, List<z0ZzZzwrj> p1, int p2, int p3)
	{
		XPageSettings xPageSettings = p1[p2].z0trk();
		if (xPageSettings.z0grk() <= 1)
		{
			return;
		}
		p0.Append(",\"PageSpan\":[" + p3 + ",");
		for (int i = 0; i < xPageSettings.z0grk() && p2 + i < p1.Count; i++)
		{
			if (i > 0)
			{
				p0.Append(',');
			}
			p0.Append(base.z0xrk.IndexOf(p1[p2 + i]));
			if (xPageSettings != p1[p2 + i].z0trk())
			{
				break;
			}
		}
		p0.Append(']');
	}

	public override bool z0ic()
	{
		if (z0npk == null)
		{
			return false;
		}
		z0ZzZzzlh z0ZzZzzlh2 = z0npk.z0jrk().z0uek();
		if (z0ZzZzzlh2 != null)
		{
			z0ZzZzwrj p = z0ZzZzzlh2.z0dtk();
			return z0eek(p);
		}
		return base.z0ic();
	}

	internal string z0tek(z0ZzZzerj p0, bool p1 = true)
	{
		if (!z0wpk)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		if (p1)
		{
			z0tek(z0qtk(), stringBuilder);
			stringBuilder.Append(z0kyk());
		}
		else
		{
			stringBuilder.Append("\"@page{margin-left:0px;margin-top:0px;margin-right:0px;margin-bottom:0px;");
			if (z0qtk().PageSettings.z0ork())
			{
				stringBuilder.Append("size:landscape;");
			}
			stringBuilder.Append("\"," + Convert.ToString(1f));
		}
		for (int num = 0; num < p0.Count; num = z0rek(p0, num))
		{
			z0ZzZzwrj z0ZzZzwrj2 = p0[num];
			z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(z0ZzZzwrj2);
			z0ZzZzarj2.z0eek(GraphicsUnit.Pixel);
			z0ZzZzwrj2.z0eek(0, 0, (int)z0ZzZzarj2.z0xek(), (int)z0ZzZzarj2.z0nek());
			stringBuilder.Append(",{\"PageIndex\":" + base.z0xrk.IndexOf(z0ZzZzwrj2));
			if (p1)
			{
				stringBuilder.Append(",\"Width\":" + (int)z0ZzZzarj2.z0xek());
			}
			else
			{
				stringBuilder.Append(",\"Width\":" + (int)(z0ZzZzarj2.z0xek() * 1f));
			}
			if (p1)
			{
				stringBuilder.Append(",\"Height\":" + (int)z0ZzZzarj2.z0nek() * z0ZzZzwrj2.z0trk().z0grk());
				z0eek(stringBuilder, p0, num, (int)z0ZzZzarj2.z0nek());
			}
			else
			{
				stringBuilder.Append(",\"Height\":" + (int)(z0ZzZzarj2.z0nek() * (float)z0ZzZzwrj2.z0trk().z0grk() * 1f));
				z0eek(stringBuilder, p0, num, (int)(z0ZzZzarj2.z0nek() * 1f));
			}
			stringBuilder.Append('}');
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	internal void z0hyk()
	{
		z0hpk = null;
		z0xuk = null;
	}

	public MoveFocusHotKeys z0gyk()
	{
		return z0crk().BehaviorOptions.MoveFocusHotKey;
	}

	public bool z0tek(z0ZzZzcah p0, string p1)
	{
		z0opk = null;
		if (p0 == null)
		{
			throw new ArgumentNullException("reader");
		}
		z0xek().z0wik();
		XTextDocument xTextDocument = z0qtk();
		try
		{
			z0nik = true;
			xTextDocument.z0pok();
			xTextDocument.z0quk();
			z0uyk();
			try
			{
				xTextDocument.z0bek(p0: false);
				xTextDocument.z0bek(p0, p1);
			}
			finally
			{
				xTextDocument.z0bek(p0: true);
			}
			z0xek().z0wik();
			z0xyk();
			if (z0crk().BehaviorOptions.AutoDocumentValueValidate)
			{
				xTextDocument.z0stk();
			}
			xTextDocument.Modified = false;
			z0hz();
		}
		finally
		{
			z0nik = false;
			xTextDocument.z0qmk();
			xTextDocument.z0smk();
		}
		z0xek().z0eek(new WriterEventArgs(z0xek(), xTextDocument, null));
		return true;
	}

	protected override void z0uc(z0ZzZzjrj p0, z0ZzZzkrj p1, z0ZzZzopk p2)
	{
		if (p0 != null)
		{
			base.z0uc(p0, p1, p2);
		}
	}

	private void z0tek(z0ZzZzopk p0)
	{
		try
		{
			z0brk();
			z0yek(p0);
			base.z0crk = z0crk().ViewOptions.PageMarginLineLength;
			if (z0npk == null)
			{
				z0ZzZzbdh layoutRectangle = new z0ZzZzbdh(0f, 0f, z0vek(), z0frk());
				using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
				z0ZzZzlsh2.z0rek(StringAlignment.Center);
				z0ZzZzlsh2.z0eek(StringAlignment.Center);
				p0.z0rek().DrawString(z0ZzZziok.z0gyk(), ((z0ZzZzmwh)this).z0xek(), z0ZzZzyfh.z0oek, layoutRectangle, z0ZzZzlsh2);
			}
			else
			{
				z0npk.z0bik();
				z0npk.z0qtk().Printing = false;
				z0npk.z0qtk().PrintPreviewing = false;
				if (base.z0vek())
				{
					z0npk.z0qtk().RenderMode = DocumentRenderMode.ReadPaint;
				}
				else
				{
					z0npk.z0qtk().RenderMode = DocumentRenderMode.Paint;
				}
				if (base.z0vrk)
				{
					z0npk.z0qtk().Printing = true;
					z0npk.z0qtk().PrintPreviewing = true;
					z0npk.z0qtk().RenderMode = DocumentRenderMode.Print;
				}
				z0eek(z0npk.PageSettings.z0krk_jiejie20260327142557());
				z0eek(HeaderFooterFlagVisible.None);
				if (z0ZzZzdpk.z0eek(z0npk.z0oik()))
				{
					z0eek(HeaderFooterFlagVisible.HeaderFooter);
				}
				z0zuk = new List<z0ZzZzndh>();
				bool flag = z0npk.z0xyk().z0eek((z0ZzZzcxj)0) && ((z0ZzZzqrj)this).z0cek() == PageViewMode.Page;
				if (!flag)
				{
					z0ZzZzfpk z0ZzZzfpk2 = z0myk().z0trk();
					if (z0ZzZzfpk2 != null && (!string.IsNullOrEmpty(z0ZzZzfpk2.z0mek()) || !string.IsNullOrEmpty(z0ZzZzfpk2.z0rek())))
					{
						flag = true;
					}
				}
				foreach (z0ZzZzwrj item in base.z0frk())
				{
					item.z0eek(item.z0brk());
				}
				z0eek(p0, flag);
				DocumentViewOptions viewOptions = z0crk().ViewOptions;
				if (z0zuk != null && z0zuk.Count > 0)
				{
					using z0ZzZzzdh p1 = new z0ZzZzzdh(viewOptions.SelectionHightlightMaskColor);
					foreach (z0ZzZzsmk item2 in base.z0lrk())
					{
						if (!item2.z0oek() || item2.z0vek() != z0npk.z0oik())
						{
							continue;
						}
						foreach (z0ZzZzndh item3 in z0zuk)
						{
							z0ZzZzndh p2 = z0ZzZzndh.z0tek(item3, item2.z0uek());
							if (p2.z0vek())
							{
								continue;
							}
							p2 = ((z0ZzZzqmk)item2).z0eek(p2);
							z0ZzZzndh p3 = z0ZzZzndh.z0tek(p2, p0.z0eek());
							if (!p3.z0vek())
							{
								p3.z0rek(p3.z0uek() + 1);
								p3.z0yek(p3.z0oek() - 1);
								p0.z0rek().z0eek(p1, p3);
								if (z0upk.z0iek() == 0)
								{
									z0upk = p3;
								}
								else
								{
									z0upk = z0ZzZzndh.z0yek(z0upk, p3);
								}
							}
						}
					}
				}
				z0zuk = null;
				if (z0atk() != null && z0atk().z0qek() == z0npk.z0jrk())
				{
					z0ZzZzndh z0ZzZzndh2 = z0jrk();
					if (!z0ZzZzndh2.z0vek())
					{
						p0.z0rek().z0eek(z0vek().GetBitmap(DCStdImageKey.DragHandle), z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), null);
					}
				}
				z0tek(p0.z0rek(), p0.z0eek().z0eek());
				z0uek(p0);
				if (z0urk() != WriterControlExtViewMode.BoundsSelection && (z0urk() == WriterControlExtViewMode.JumpPrint || z0urk() == WriterControlExtViewMode.OffsetJumpPrint))
				{
					z0eek(p0.z0rek(), p0.z0eek(), z0bok, viewOptions.MaskColorForJumpPrint);
				}
			}
			p0.z0rek().z0zek();
		}
		catch (Exception ex)
		{
			string text = ex.ToString();
			z0ZzZzqok.z0rek.z0sh("DCWriter内部错误:" + text);
			DocumentViewOptions viewOptions2 = z0crk().ViewOptions;
			if (viewOptions2 == null || viewOptions2.ShowRedErrorMessageForPaint)
			{
				p0.z0rek().z0rek();
				p0.z0rek().z0zek();
				p0.z0rek().z0eek(GraphicsUnit.Pixel);
				using z0ZzZzlsh z0ZzZzlsh3 = new z0ZzZzlsh();
				z0ZzZzlsh3.z0rek(StringAlignment.Near);
				z0ZzZzlsh3.z0eek(StringAlignment.Near);
				p0.z0rek().DrawString(text, ((z0ZzZzmwh)this).z0xek(), z0ZzZzyfh.z0oek, new z0ZzZzbdh(0f, 0f, z0vek(), z0frk()), z0ZzZzlsh3);
			}
			if (XTextDocument.z0wbk)
			{
				z0ZzZzqok.z0rek.z0dh(ex.ToString());
			}
		}
		finally
		{
			z0npk?.z0aok();
		}
	}

	public bool z0krk(bool p0)
	{
		return z0byk().z0qn(p0);
	}

	public new void z0yek(z0ZzZzweh p0)
	{
		z0ZzZzmwh.z0qrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
		z0ZzZzmwh.z0ork = p0.z0yek();
		z0zc(p0);
	}

	public new void z0uek(z0ZzZzweh p0)
	{
		z0ZzZzmwh.z0qrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
		z0ZzZzmwh.z0ork = p0.z0yek();
		z0zjk(p0);
		if (z0jpk != null)
		{
			z0jpk.z0tek(p0);
		}
	}

	private z0ZzZzndh z0tek(z0ZzZzwrj p0, bool p1 = false)
	{
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(p0);
		z0ZzZzarj2.z0eek(GraphicsUnit.Pixel);
		float num = z0ZzZzarj2.z0bek();
		float num2 = z0ZzZzarj2.z0vek();
		float num3 = z0ZzZzarj2.z0xek() - z0ZzZzarj2.z0cek();
		num3 = Math.Max(num3, num + z0npk.z0xyk().z0xyk());
		float num4 = z0ZzZzarj2.z0nek() - z0ZzZzarj2.z0tek();
		if (z0ZzZzarj2.z0zek())
		{
			if (z0ZzZzarj2.z0rek() == DCGutterStyle.Left)
			{
				num = Math.Min(num, z0ZzZzarj2.z0uek());
			}
			else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Right)
			{
				num3 = Math.Max(num3, z0ZzZzarj2.z0uek());
			}
			else if (z0ZzZzarj2.z0rek() == DCGutterStyle.Top)
			{
				num2 = Math.Min(num2, z0ZzZzarj2.z0uek());
			}
		}
		if (p1)
		{
			return new z0ZzZzndh(0, 0, (int)z0ZzZzarj2.z0xek(), (int)num4);
		}
		return new z0ZzZzndh((int)(num - 2f), (int)(num2 - 2f), (int)(num3 - num + 4f), (int)(num4 - num2 + 4f));
	}

	public XTextElement z0fyk()
	{
		return z0npk?.z0itk();
	}

	internal z0dgj z0iek(XTextElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (z0apk)
		{
			z0ZzZzwrj z0ZzZzwrj2 = base.z0frk().z0rek(p0.z0je());
			if (z0ZzZzwrj2 != null)
			{
				float num = p0.z0mrk();
				float num2 = p0.z0fuk();
				if (num >= 0f && num2 >= 0f)
				{
					return new z0dgj
					{
						z0rek = z0ZzZzwrj2,
						z0iek = base.z0frk().IndexOf(z0ZzZzwrj2),
						z0eek = (int)(z0qtk().z0krk(num) * z0kyk()),
						z0yek = (int)(z0qtk().z0krk(num2) * z0kyk()),
						z0tek = (int)(p0.z0xyk() * z0kyk()),
						z0uek = (int)(p0.z0utk() * z0kyk())
					};
				}
			}
			return null;
		}
		z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
		float num3 = p0.z0zrk();
		float num4 = p0.z0ltk();
		if (p0.z0qek() is XTextDocumentBodyElement)
		{
			z0ZzZzodh p1 = z0tc((int)num3, (int)num4);
			foreach (z0ZzZzwrj item in z0ZzZzerj2)
			{
				if (item.z0erk().z0rek(p1))
				{
					return new z0dgj
					{
						z0rek = item,
						z0iek = z0ZzZzerj2.IndexOf(item),
						z0eek = (int)((float)(p1.z0rek() - item.z0erk().z0pek()) * z0kyk()),
						z0yek = (int)((float)(p1.z0tek() - item.z0erk().z0mek()) * z0kyk()),
						z0tek = (int)(p0.z0xyk() * z0kyk()),
						z0uek = (int)(p0.z0utk() * z0kyk())
					};
				}
			}
			return null;
		}
		z0dgj z0dgj = new z0dgj();
		z0ZzZzwrj z0ZzZzwrj3 = ((z0ZzZzqrj)this).z0xek();
		if (z0ZzZzwrj3 == null)
		{
			z0ZzZzwrj3 = z0ZzZzerj2[0];
		}
		z0dgj.z0iek = z0ZzZzerj2.IndexOf(z0ZzZzwrj3);
		z0dgj.z0rek = z0ZzZzwrj3;
		PageContentPartyStyle pageContentPartyStyle = p0.z0atk();
		foreach (z0ZzZzsmk item2 in base.z0lrk())
		{
			if (item2.z0cek() == z0ZzZzwrj3 && item2.z0vek() == pageContentPartyStyle)
			{
				z0ZzZzpdh z0ZzZzpdh2 = item2.z0xqk(num3, num4);
				z0dgj.z0eek = (int)((z0ZzZzpdh2.z0rek() - (float)z0ZzZzwrj3.z0erk().z0pek()) * z0kyk());
				z0dgj.z0yek = (int)((z0ZzZzpdh2.z0tek() - (float)z0ZzZzwrj3.z0erk().z0mek()) * z0kyk());
			}
		}
		return z0dgj;
	}

	internal bool z0yek(string p0, string p1)
	{
		byte[] p2 = Convert.FromBase64String(p0);
		return z0tek(p2, p1);
	}

	internal void z0jrk(bool p0)
	{
		z0wok = p0;
	}

	public void z0tek(z0bnk p0)
	{
		z0ZzZzerj z0ZzZzerj2 = new z0ZzZzerj();
		if (z0gpk == null || z0gpk.Count <= 0)
		{
			return;
		}
		if (p0 != null && p0.z0nlk() > 0)
		{
			z0gpk.z0rek().z0bek((float)p0.z0nlk());
		}
		foreach (XTextDocument item in z0gpk)
		{
			item.z0bek(z0xek());
			item.z0bek(p0.z0lkk());
			item.z0qtk().Printing = true;
			item.z0qtk().PrintPreviewing = true;
			item.z0krk(p0: false);
			item.z0bek(z0jik);
			item.z0juk();
			z0ZzZzerj2.AddRange(item.z0suk());
		}
		p0?.z0olk(z0gpk.z0rek());
		z0npk = z0gpk.z0rek();
		base.z0xrk = z0ZzZzerj2;
		for (int i = 0; i < z0ZzZzerj2.Count; i++)
		{
			z0ZzZzerj2[i].z0eek(i);
		}
		z0ZzZzerj p1 = z0tek(z0ZzZzerj2, p0, z0gpk, p3: true);
		base.z0vrk = true;
		z0cok = p0;
		z0xek().z0ij(z0tek(p1));
	}

	public z0ZzZzodh z0dyk()
	{
		XTextElement xTextElement = z0fyk();
		if (xTextElement != null)
		{
			return z0tek(xTextElement).z0rek();
		}
		return z0ZzZzodh.z0yek;
	}

	public JumpPrintInfo z0syk()
	{
		if (z0bok == null && !z0aik)
		{
			z0bok = new JumpPrintInfo();
		}
		return z0bok;
	}

	public z0ZzZzbnj z0ayk()
	{
		return z0xek().z0lh();
	}

	public new byte[] z0nek(string p0)
	{
		if (z0nok)
		{
			z0nok = false;
			return z0vok;
		}
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		z0qgj z0qgj = null;
		if (z0eok == null || z0eok.Count == 0)
		{
			return null;
		}
		base.z0vrk = false;
		for (int i = 0; i < z0eok.Count; i++)
		{
			z0qgj z0qgj2 = z0eok[i];
			if (z0qgj2.z0tek == ((z0ZzZzqrj)this).z0xek())
			{
				z0qgj = z0qgj2;
				z0eok.RemoveAt(i);
				break;
			}
		}
		if (z0qgj == null)
		{
			z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
			string[] array = p0.Split(',');
			foreach (string obj in array)
			{
				int num = 0;
				if (!int.TryParse(obj, out num) || num < 0 || num >= z0ZzZzerj2.Count)
				{
					continue;
				}
				for (int k = 0; k < z0eok.Count; k++)
				{
					z0qgj z0qgj3 = z0eok[k];
					if (z0qgj3.z0rek == num)
					{
						z0qgj = z0qgj3;
						z0eok.RemoveAt(k);
						break;
					}
				}
				if (z0qgj != null)
				{
					break;
				}
			}
		}
		if (z0qgj == null)
		{
			return null;
		}
		z0ZzZzydh z0ZzZzydh2 = new z0ZzZzydh(z0ZzZzydh.z0iek);
		z0ZzZzydh2.z0eek(z0eok != null && z0eok.Count > 0);
		short p1 = (short)z0qgj.z0rek;
		z0ZzZzydh2.z0eek(p1);
		float num2 = z0kyk() * z0xek().z0qik();
		z0ZzZzadh obj2 = new z0ZzZzadh();
		obj2.z0eek(num2);
		z0ZzZzydh2.z0eek(z0xek().z0ppk());
		obj2.z0rek(-z0qgj.z0tek.z0erk().z0pek(), -z0qgj.z0tek.z0erk().z0mek());
		z0ZzZzreh z0ZzZzreh2 = new z0ZzZzreh(obj2, z0qgj.z0eek);
		if (z0xek().z0tbk != null)
		{
			z0xek().z0tbk.z0eek(z0ZzZzreh2.z0tek());
		}
		z0ZzZzydh2.z0eek((int)((float)(z0qgj.z0eek.z0pek() - z0qgj.z0tek.z0erk().z0pek()) * num2), (int)((float)(z0qgj.z0eek.z0mek() - z0qgj.z0tek.z0erk().z0mek()) * num2), (int)((float)z0qgj.z0eek.z0iek() * num2), (int)((float)z0qgj.z0eek.z0oek() * num2));
		z0upk = z0ZzZzndh.z0cek;
		z0jz(z0ZzZzreh2);
		z0qgj.z0tek.z0tek(z0upk);
		obj2.z0eek(GraphicsUnit.Document);
		byte[] result = obj2.z0eek(z0ZzZzydh2);
		z0ZzZzydh2.Dispose();
		obj2.Dispose();
		return result;
	}

	private void z0tek(object p0, z0ZzZzwrj p1)
	{
		z0ZzZzxpk z0ZzZzxpk2 = (z0ZzZzxpk)p0;
		string text = z0ZzZzxpk2.z0eek();
		string text2 = text;
		string text3 = "[%pageindex%]";
		string text4 = "[%pagecount%]";
		if (text.Contains(text3))
		{
			text = ((p1 != null) ? text.Replace(text3, Convert.ToString(p1.z0brk() + 1)) : text.Replace(text3, string.Empty));
		}
		if (text.Contains(text4))
		{
			text = ((p1 != null) ? text.Replace(text4, base.z0frk().Count.ToString()) : text.Replace(text4, string.Empty));
		}
		if (text2 != text)
		{
			z0ZzZzxpk2.z0nek = new z0ZzZzwok(text);
		}
		z0ZzZzxpk2.z0oek = Color.White;
	}

	public void z0iek(z0ZzZzweh p0)
	{
		z0ZzZzmwh.z0qrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
		z0ZzZzmwh.z0ork = p0.z0yek();
		if (z0jpk != null)
		{
			z0jpk.z0eek(p0);
		}
		else
		{
			z0xjk(p0);
		}
	}

	protected override void z0yc(EventArgs p0)
	{
		base.z0yc(p0);
		if (z0xik > 0)
		{
			if (Math.Abs(Environment.TickCount - z0xik) <= 100)
			{
				return;
			}
			z0xik = 0L;
		}
		if (z0npk == null)
		{
			return;
		}
		if (z0mik > 0)
		{
			z0mik = 0L;
		}
		if (z0urk() == WriterControlExtViewMode.JumpPrint || z0urk() == WriterControlExtViewMode.OffsetJumpPrint || z0urk() == WriterControlExtViewMode.BoundsSelection)
		{
			return;
		}
		if (!z0syk().Enabled || z0syk().PageIndex < 0)
		{
			if (z0crk().BehaviorOptions.AutoScrollToCaretWhenGotFocus)
			{
				bool flag = z0wik;
				z0wik = true;
				try
				{
					z0nek();
				}
				finally
				{
					z0wik = flag;
				}
			}
			else
			{
				z0guk();
			}
		}
		if (!z0htk() && z0npk != null && z0xpk)
		{
			z0npk.z0bek();
		}
	}

	public float z0qyk()
	{
		if (z0bok != null)
		{
			return z0bok.NativePosition;
		}
		return 0f;
	}

	internal void z0wyk()
	{
		if (z0npk != null)
		{
			z0npk.Dispose();
			z0npk = null;
		}
	}

	public DragOperationState z0eyk()
	{
		return z0mok;
	}

	public z0ZzZzznj z0ryk()
	{
		if (z0aik)
		{
			return z0bik;
		}
		if (((z0ZzZzmwh)this).z0rek())
		{
			return null;
		}
		if (z0bik == null)
		{
			z0bik = z0ZzZzuok.z0eek<z0ZzZzznj>();
		}
		z0bik.z0ex(z0xek(), z0qtk());
		return z0bik;
	}

	internal bool z0tyk()
	{
		return z0buk;
	}

	public new XTextElement z0bek(string p0)
	{
		return z0npk?.z0ki(p0);
	}

	public bool z0tek(XTextDocument p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0opk = null;
		z0xek().z0wik();
		DocumentOptions p2 = z0crk();
		XTextDocument xTextDocument = z0npk;
		z0yek(p0);
		if (xTextDocument != null && p1)
		{
			xTextDocument.Dispose();
		}
		xTextDocument = null;
		p0.z0bek(z0xek());
		p0.z0bek(p2);
		p0.z0li();
		try
		{
			p0.z0pok();
			p0.z0quk();
			z0uyk();
			p0.z0rt(new ElementLoadEventArgs(p0, null));
			z0xek().z0wik();
			z0xyk();
			if (z0crk().BehaviorOptions.AutoDocumentValueValidate)
			{
				p0.z0stk();
			}
			p0.Modified = false;
			z0hz();
		}
		finally
		{
			p0.z0qmk();
			p0.z0smk();
		}
		z0xek().z0eek(new WriterEventArgs(z0xek(), p0, null));
		return true;
	}

	public override z0ZzZzodh z0tc(int p0, int p1)
	{
		if (z0eek() == null)
		{
			return base.z0tc(p0, p1);
		}
		return z0eek().z0jwk(p0, p1);
	}

	public bool z0oek(XTextElement p0)
	{
		return z0tek(p0, p1: false, ValueEditorActiveMode.Program, p3: false, p4: true);
	}

	public void z0tek(WriterControlExtViewMode p0)
	{
		if (p0 == z0urk())
		{
			return;
		}
		z0ztk();
		switch (p0)
		{
		case WriterControlExtViewMode.Normal:
			z0bok = null;
			z0cuk_jiejie20260327142557 = null;
			z0tek((z0ZzZzvej)null);
			break;
		case WriterControlExtViewMode.JumpPrint:
			z0bok = new JumpPrintInfo();
			z0bok.Enabled = true;
			z0bok.Mode = JumpPrintMode.Normal;
			z0cuk_jiejie20260327142557 = new JumpPrintInfo();
			z0cuk_jiejie20260327142557.Enabled = true;
			z0cuk_jiejie20260327142557.Mode = JumpPrintMode.Normal;
			z0tek((z0ZzZzvej)null);
			z0fx(z0ZzZzbwh.z0krk);
			break;
		case WriterControlExtViewMode.OffsetJumpPrint:
			z0bok = new JumpPrintInfo();
			z0bok.Enabled = true;
			z0bok.Mode = JumpPrintMode.Offset;
			z0cuk_jiejie20260327142557 = new JumpPrintInfo();
			z0cuk_jiejie20260327142557.Enabled = true;
			z0cuk_jiejie20260327142557.Mode = JumpPrintMode.Offset;
			z0tek((z0ZzZzvej)null);
			z0fx(z0ZzZzbwh.z0krk);
			break;
		case WriterControlExtViewMode.BoundsSelection:
			z0bok = null;
			z0cuk_jiejie20260327142557 = null;
			z0tek(new z0ZzZzvej());
			z0lyk().z0eek(p0: true);
			z0fx(z0ZzZzbwh.z0grk);
			if (base.z0lrk() == null)
			{
				break;
			}
			foreach (z0ZzZzsmk item in base.z0lrk())
			{
				item.z0rek(p0: false);
			}
			break;
		}
		z0hz();
	}

	public override z0ZzZzgpk z0rc()
	{
		if (base.z0vek())
		{
			return null;
		}
		switch (z0itk())
		{
		case FunctionControlVisibility.Hide:
			return null;
		case FunctionControlVisibility.Auto:
		{
			z0ZzZzwcj z0ZzZzwcj2 = z0qtk().z0gik();
			if (z0ZzZzwcj2 == null || z0ZzZzwcj2.Count == 0)
			{
				return null;
			}
			bool flag = false;
			foreach (DocumentComment item in z0ZzZzwcj2)
			{
				if (item.z0oek())
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return null;
			}
			break;
		}
		}
		z0ZzZzgpk obj = new z0ZzZzgpk();
		obj.z0eek(p0: true);
		obj.z0rek(z0ZzZzrpk.z0eek((int)obj.z0tek_jiejie20260327142557(), ((z0ZzZzspj)this).z0cek(), GraphicsUnit.Pixel));
		return obj;
	}

	public z0ZzZzyrj z0yyk()
	{
		return z0kpk;
	}

	public void z0uyk()
	{
		z0cek();
		z0grk();
		z0kpk = null;
		z0bok = null;
		z0tek((z0ZzZzvej)null);
		z0pik = null;
		z0zuk = null;
		z0fok = null;
		if (z0tpk != null)
		{
			z0tpk.z0eek();
		}
		z0eek((z0ZzZzsmk)null);
		if (z0ppk != null)
		{
			z0ppk.z0tek();
		}
		z0rpk = null;
	}

	internal string z0iyk()
	{
		z0hrk(p0: false);
		return z0iek();
	}

	protected override void z0ec(z0ZzZzheh p0)
	{
		base.z0ec(p0);
		if (p0.z0rek())
		{
			return;
		}
		p0.z0tek();
		if (z0npk == null)
		{
			return;
		}
		if (p0.z0uek() == Keys.Escape)
		{
			if (z0htk())
			{
				z0ztk();
				p0.z0eek(p0: true);
				return;
			}
			if (z0fok != null)
			{
				z0ark();
				return;
			}
			if (z0urk() == WriterControlExtViewMode.BoundsSelection)
			{
				z0tek(WriterControlExtViewMode.Normal);
				z0sc();
				return;
			}
		}
		DocumentEventArgs e = DocumentEventArgs.z0rek(z0npk, p0);
		try
		{
			z0npk.z0nok();
			z0npk.z0mu(e);
			if (e.Handled)
			{
				return;
			}
			if (z0npk.z0irk() != null)
			{
				XTextElement xTextElement = z0npk.z0itk();
				if (xTextElement != null)
				{
					XTextElement xTextElement2 = z0npk.z0irk().z0bb(xTextElement, p0.z0uek(), p0.z0yek(), p0);
					if (xTextElement2 != null)
					{
						z0xek(p0: true);
						xTextElement2.z0sr();
						e.Handled = true;
						p0.z0eek(p0: true);
						return;
					}
				}
			}
			if (p0.z0rek())
			{
				z0xek(p0: true);
				return;
			}
			z0ZzZzrmj z0ZzZzrmj2 = z0suk().z0yek().z0eek(z0xek(), z0npk, p0);
			if (z0ZzZzrmj2 != null)
			{
				z0tek(z0ZzZzrmj2.z0tek, p1: true, null);
				p0.z0eek(p0: true);
				if (p0.z0iek() && p0.z0uek() == Keys.I)
				{
					z0xek(p0: true);
				}
			}
		}
		finally
		{
			z0npk.z0fok();
		}
	}

	public bool z0oyk()
	{
		return z0yik;
	}

	public new bool z0vek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("id");
		}
		if (z0bek(p0) is XTextContainerElement p1)
		{
			return z0tek(p1);
		}
		return false;
	}

	public void z0pyk()
	{
		z0tek(p0: true, (string)null);
	}

	protected override void z0zjk(z0ZzZzweh p0)
	{
		if (z0hok)
		{
			z0hok = false;
		}
		if (!z0xtk())
		{
			return;
		}
		z0xik = Environment.TickCount;
		base.z0zjk(p0);
		z0htk();
		z0qrk();
		if (z0npk != null)
		{
			if (z0urk() == WriterControlExtViewMode.BoundsSelection)
			{
				if (z0dx() != z0ZzZzbwh.z0grk)
				{
					z0fx(z0ZzZzbwh.z0grk);
				}
				z0ZzZzndh z0ZzZzndh2 = z0ZzZzypj.z0eek(this, p0.z0rek(), p0.z0tek());
				if (!z0ZzZzndh2.z0vek())
				{
					foreach (z0ZzZzsmk item in base.z0lrk())
					{
						if (z0ZzZzdpk.z0eek(item.z0vek()))
						{
							continue;
						}
						z0ZzZzndh z0ZzZzndh3 = z0ZzZzndh.z0tek(item.z0tek_jiejie20260327142557(), z0ZzZzndh2);
						if (!z0ZzZzndh3.z0vek())
						{
							z0ZzZzbdh p1 = ((z0ZzZzqmk)item).z0eek(new z0ZzZzbdh(z0ZzZzndh3.z0pek(), z0ZzZzndh3.z0mek(), z0ZzZzndh3.z0iek(), z0ZzZzndh3.z0oek()));
							if ((z0ZzZzmwh.z0oek() & Keys.Shift) == Keys.Shift)
							{
								z0lyk().z0eek(item.z0yek(), p1);
								((z0ZzZzmwh)this).z0eek(z0ZzZzndh2);
							}
							else
							{
								z0lyk().Clear();
								z0lyk().z0eek(item.z0yek(), p1);
								z0hz();
							}
						}
					}
				}
			}
			else if (z0urk() == WriterControlExtViewMode.JumpPrint || z0urk() == WriterControlExtViewMode.OffsetJumpPrint)
			{
				JumpPrintInfo jumpPrintInfo = z0syk().z0eek();
				z0syk().PageIndex = -1;
				z0syk().Position = 0f;
				foreach (z0ZzZzsmk item2 in base.z0lrk())
				{
					if (item2.z0vek() != PageContentPartyStyle.Body || !(item2.z0mek().z0nek() >= (float)p0.z0tek()))
					{
						continue;
					}
					z0ZzZzwrj z0ZzZzwrj2 = (z0ZzZzwrj)item2.z0cek();
					XTextDocument xTextDocument = (XTextDocument)z0ZzZzwrj2.z0srk();
					float num = item2.z0gwk(p0.z0rek(), p0.z0tek()).z0tek();
					if (p0.z0tek() < item2.z0tek_jiejie20260327142557().z0mek())
					{
						num = (int)item2.z0rek().z0pek();
					}
					if (!(num >= 0f))
					{
						break;
					}
					if (z0syk().Mode == JumpPrintMode.Normal && z0ZzZzmwh.z0oek() == Keys.Control)
					{
						z0syk().PageIndex = jumpPrintInfo.PageIndex;
						z0syk().Position = jumpPrintInfo.Position;
						z0syk().EndPageIndex = -1;
						z0syk().z0rek(0f);
						JumpPrintInfo jumpPrintInfo2 = xTextDocument.z0drk(num);
						if (jumpPrintInfo2 != null && jumpPrintInfo2.NativePosition > z0syk().NativePosition)
						{
							z0syk().EndPageIndex = jumpPrintInfo2.PageIndex;
							z0syk().z0rek(num);
							z0syk().EndPosition = jumpPrintInfo2.Position;
						}
						break;
					}
					z0syk().PageIndex = base.z0frk().IndexOf(z0ZzZzwrj2);
					z0syk().z0eek(num);
					z0syk().EndPageIndex = -1;
					z0syk().z0rek(0f);
					JumpPrintInfo jumpPrintInfo3 = null;
					if (z0syk().Mode == JumpPrintMode.Offset)
					{
						jumpPrintInfo3 = xTextDocument.z0zek(num);
						if (jumpPrintInfo3 != null && jumpPrintInfo3.PageIndex != 0)
						{
							jumpPrintInfo3 = null;
						}
					}
					else
					{
						jumpPrintInfo3 = xTextDocument.z0drk(num);
					}
					if (jumpPrintInfo3 != null)
					{
						z0syk().PageIndex = jumpPrintInfo3.PageIndex;
						z0syk().Position = jumpPrintInfo3.Position;
					}
					else
					{
						z0syk().PageIndex = base.z0frk().IndexOf(z0ZzZzwrj2);
						z0syk().Position = num;
					}
					if (z0syk().Mode == JumpPrintMode.Offset)
					{
						if (jumpPrintInfo3 != null && jumpPrintInfo3.PageIndex == 0)
						{
							z0npk.z0bek(jumpPrintInfo3.AbsPosition);
						}
						else
						{
							z0npk.z0bek(0f);
							z0syk().PageIndex = 0;
							z0syk().Position = 0f;
						}
						z0tek(p0: false, p1: true);
						z0guk();
					}
					break;
				}
				if (z0syk().PageIndex != jumpPrintInfo.PageIndex || z0syk().Position != jumpPrintInfo.Position || z0syk().EndPageIndex != jumpPrintInfo.EndPageIndex || z0syk().EndPosition != jumpPrintInfo.EndPosition)
				{
					z0hz();
				}
			}
			else if (0 == 0)
			{
				z0ZzZzndh z0ZzZzndh4 = z0jrk();
				if (!z0ZzZzndh4.z0vek() && z0ZzZzndh4.z0eek(p0.z0rek(), p0.z0tek()))
				{
					XTextElement xTextElement = z0atk();
					xTextElement.z0hr();
					z0npk.z0krk(xTextElement);
					((z0ZzZzmwh)this).z0jrk();
				}
				else
				{
					z0tek(p0, DocumentEventStyles.MouseDown);
				}
			}
		}
		if (!z0oc())
		{
			z0kx();
		}
	}

	protected override string z0wc()
	{
		if (z0qtk() != null)
		{
			return z0qtk().Text;
		}
		return string.Empty;
	}

	public XPageSettings z0myk()
	{
		if (z0npk == null)
		{
			return null;
		}
		return z0npk.PageSettings;
	}

	private bool z0yek(object p0)
	{
		return false;
	}

	internal void z0tek(PageTitlePosition p0)
	{
		z0sok = p0;
	}

	public void z0hrk(bool p0)
	{
		z0npk?.z0jrk(p0);
	}

	public z0ZzZzymj z0nyk()
	{
		if (z0qik == null)
		{
			z0qik = new z0ZzZzymj();
		}
		z0qik.CommandContainer = z0suk().z0yek();
		z0qik.EditControl = z0xek();
		return z0qik;
	}

	public int z0tek(int p0, float p1)
	{
		XTextDocument xTextDocument = z0qtk();
		if (p0 <= 0 && p0 > xTextDocument.z0suk().Count)
		{
			return 0;
		}
		z0ZzZzzlh[] array = ((XTextContentElement)xTextDocument.z0xyk()).z0zek();
		z0ZzZzwrj z0ZzZzwrj2 = xTextDocument.z0suk()[p0 - 1];
		for (int num = array.Length - 1; num >= 0; num--)
		{
			z0ZzZzzlh z0ZzZzzlh2 = array[num];
			if (z0ZzZzzlh2.z0xrk() < z0ZzZzwrj2.z0qrk())
			{
				float num2 = z0ZzZzwrj2.z0irk() + z0ZzZzwrj2.z0urk() - z0ZzZzwrj2.z0krk().z0iek() - z0ZzZzzlh2.z0xrk() - z0ZzZzzlh2.z0ytk();
				float num3 = z0ZzZzzlh2.z0ytk();
				if (p1 > 0f)
				{
					num3 = p1;
				}
				return (int)Math.Floor(num2 / num3);
			}
		}
		return 0;
	}

	public void z0tek(float p0)
	{
		z0uek();
		JumpPrintInfo jumpPrintInfo = z0qtk().z0drk(p0);
		z0syk().z0rek(p0);
		if (jumpPrintInfo != null)
		{
			z0syk().EndPageIndex = jumpPrintInfo.PageIndex;
			z0syk().EndPosition = jumpPrintInfo.Position;
		}
		else
		{
			z0syk().EndPageIndex = -1;
			z0syk().EndPosition = 0f;
		}
		z0hz();
	}

	public z0ZzZzpxj z0byk()
	{
		if (z0aik)
		{
			return z0pok;
		}
		if (z0pok == null)
		{
			z0pok = z0ZzZzuok.z0eek<z0ZzZzpxj>();
		}
		if (z0pok == null)
		{
			return null;
		}
		if (z0pok.z0ip() != z0xek())
		{
			z0pok.z0mn(z0xek());
		}
		if (z0pok.z0dm() != z0npk)
		{
			z0pok.z0yn(z0npk);
		}
		return z0pok;
	}

	internal void z0vyk()
	{
		z0nok = false;
		z0wpk = true;
		base.z0ark = new z0ZzZzncj();
	}

	public z0ZzZzueh z0cyk()
	{
		if (z0cik == null && !((z0ZzZzmwh)this).z0rek())
		{
			z0cik = new z0ZzZzueh();
		}
		return z0cik;
	}

	public void z0xyk()
	{
		z0tek(p0: true, p1: true);
	}

	protected override int z0qc()
	{
		return 0;
	}

	public z0ZzZzwxj z0zyk()
	{
		return z0npk?.z0htk()?.z0lp();
	}

	private bool z0luk_jiejie20260327142557()
	{
		z0ZzZzkeh z0ZzZzkeh2 = z0quk().z0xk(z0xek());
		if (z0ZzZzkeh2 != null)
		{
			CanInsertObjectEventArgs e = new CanInsertObjectEventArgs(z0qtk());
			e.DataObject = z0ZzZzkeh2;
			z0xek().z0eek(e);
			return e.Result;
		}
		return false;
	}

	internal PageContentPartyStyle z0kuk()
	{
		return z0qtk().z0oik();
	}

	internal void z0yek(WriterDataFormats p0)
	{
		z0crk().BehaviorOptions.CreationDataFormats = p0;
	}

	public ContentEffects z0tek(z0ZzZzimk p0, Color p1, bool p2)
	{
		if (z0npk != null)
		{
			ContentEffects contentEffects = z0npk.SetDefaultFont(p0, p1, raiseEvent: true);
			if (p2 && ((z0ZzZzmwh)this).z0eek())
			{
				switch (contentEffects)
				{
				case ContentEffects.Display:
					z0hz();
					break;
				case ContentEffects.Layout:
					z0xyk();
					break;
				}
				return contentEffects;
			}
		}
		return ContentEffects.None;
	}

	public override void z0ac()
	{
		base.z0ac();
		if (z0xek().z0knk != null)
		{
			z0xek().z0knk.z0eek(null, null);
		}
		if (z0xek().z0xmk != null)
		{
			z0xek().z0xmk.z0eek(null, null);
		}
	}

	public void z0tek(z0ZzZzjpk p0, z0ZzZzwrj p1, bool p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("page");
		}
		JumpPrintInfo jumpPrintInfo = z0cuk_jiejie20260327142557;
		base.z0vrk = true;
		XTextDocument xTextDocument = (XTextDocument)p1.z0srk();
		int num = xTextDocument.z0suk().IndexOf(p1);
		if (num < 0)
		{
			num = p1.z0brk();
		}
		xTextDocument.z0wck = false;
		xTextDocument.z0qtk().Printing = true;
		xTextDocument.z0qtk().PrintPreviewing = true;
		bool p3 = true;
		if (jumpPrintInfo != null && jumpPrintInfo.HasValidateInfo)
		{
			if (jumpPrintInfo.PageIndex >= 0 && jumpPrintInfo.PageIndex == num && jumpPrintInfo.Position > 0f)
			{
				p3 = false;
			}
			else if (jumpPrintInfo.EndPageIndex >= 0 && jumpPrintInfo.EndPageIndex == num && jumpPrintInfo.EndPosition > 0f)
			{
				p3 = false;
			}
			else if (jumpPrintInfo.Mode == JumpPrintMode.Offset && num == 0)
			{
				p3 = false;
			}
		}
		else if (num == 0 && xTextDocument.z0iik() > 0f)
		{
			p3 = false;
		}
		if (z0cok != null && z0cok.z0ylk())
		{
			p3 = true;
		}
		if (!xTextDocument.PageSettings.z0mek())
		{
			p3 = false;
		}
		new z0ZzZzarj(xTextDocument.PageSettings, p1: false, p2: false).z0eek(GraphicsUnit.Pixel);
		if (p2)
		{
			xTextDocument.z0bek(p0, p1, p2: false, 1f, DocumentRenderMode.Print, p3, z0cok);
		}
		else
		{
			z0ZzZzndh z0ZzZzndh2 = z0tek(p1);
			if (XTextDocument.z0xok())
			{
				using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				p0.z0eek(z0ZzZzkfh.z0drk.z0tek(), z0ZzZzimk.z0oek, z0ZzZzyfh.z0uek, z0ZzZzndh2.z0pek() + 20, z0ZzZzndh2.z0mek() + 20);
			}
			JumpPrintInfo p4 = z0cok.z0ilk();
			z0cok.z0gkk(jumpPrintInfo);
			xTextDocument.z0bek(p0, p1, p2: false, 1f, DocumentRenderMode.Print, p3, z0cok);
			z0cok.z0gkk(p4);
		}
		if (jumpPrintInfo == null || !jumpPrintInfo.HasValidateInfo || jumpPrintInfo.Mode == JumpPrintMode.Offset)
		{
			return;
		}
		p0.z0rek();
		z0ZzZztfh p5 = (p2 ? new z0ZzZzzdh(z0crk().ViewOptions.MaskColorForJumpPrint) : z0ZzZzyfh.z0iek);
		if (jumpPrintInfo.PageIndex > 0 && num < jumpPrintInfo.PageIndex)
		{
			p0.z0zek();
			if (p2)
			{
				p0.z0eek(p5, 0f, 0f, p1.z0rrk(), p1.z0crk());
			}
			else
			{
				p0.z0eek(p5, 0f, 0f, p1.z0rrk(), p1.z0crk());
			}
			return;
		}
		if (jumpPrintInfo.EndPageIndex >= 0 && num > jumpPrintInfo.EndPageIndex)
		{
			p0.z0zek();
			if (p2)
			{
				p0.z0eek(p5, 0f, 0f, p1.z0rrk(), p1.z0crk());
			}
			else
			{
				p0.z0eek(p5, 0f, 0f, p1.z0rrk(), p1.z0crk());
			}
			return;
		}
		if (num >= 0 && num == jumpPrintInfo.PageIndex && jumpPrintInfo.Position > 0f)
		{
			p0.z0zek();
			float p6 = p1.z0yrk() + jumpPrintInfo.Position + p1.z0qtk + p1.z0krk().z0iek();
			if (p2)
			{
				p0.z0eek(p5, 0f, 0f, p1.z0rrk(), p6);
			}
			else
			{
				p0.z0eek(p5, 0f, 0f, p1.z0rrk(), p6);
			}
		}
		if (num >= 0 && num == jumpPrintInfo.EndPageIndex && jumpPrintInfo.EndPosition > 0f)
		{
			p0.z0zek();
			float num2 = p1.z0yrk() + jumpPrintInfo.EndPosition + p1.z0qtk;
			if (p2)
			{
				p0.z0eek(p5, 0f, num2, p1.z0rrk(), p1.z0crk() - num2);
			}
			else
			{
				p0.z0eek(p5, 0f, num2, p1.z0rrk(), p1.z0crk() - num2);
			}
		}
	}

	public string z0juk()
	{
		z0ZzZzzlh z0ZzZzzlh2 = z0npk?.z0jrk()?.z0uek();
		if (z0ZzZzzlh2 != null && z0ZzZzzlh2.z0dtk() != null)
		{
			return string.Format(z0ZzZziok.z0mrk(), Convert.ToString(z0ZzZzzlh2.z0dtk().z0brk() + 1), Convert.ToString(z0zrk()), Convert.ToString(z0mek()));
		}
		return null;
	}

	private void z0tek(XTextDocument p0, StringBuilder p1)
	{
		p1.Append("\"border-radius:5px;margin:5px 5px 5px 5px;vertical-align:top");
		if (base.z0jrk().A != 0)
		{
			p1.Append(";background-color:").Append(z0tek(base.z0jrk()));
		}
		if (p0.z0vtk().BehaviorOptions.DesignMode)
		{
			p1.Append(";border:4px dashed blue");
		}
		else if (base.z0drk().A != 0)
		{
			p1.Append(";border:1px solid ").Append(z0tek(base.z0drk()));
		}
		p1.Append("\",");
	}

	public void z0tek(z0ZzZzbdh p0, PageContentPartyStyle p1)
	{
		if (!z0zpk || z0npk == null)
		{
			return;
		}
		Span<z0ZzZzsmk> span = base.z0lrk().z0tek();
		int length = span.Length;
		for (int i = 0; i < length; i++)
		{
			z0ZzZzsmk z0ZzZzsmk2 = span[i];
			if (z0ZzZzsmk2.z0qrk != p1)
			{
				continue;
			}
			if ((p1 == PageContentPartyStyle.Body || p1 == PageContentPartyStyle.HeaderRows) && p0.z0pek() == z0ZzZzsmk2.z0pek())
			{
				float num = p0.z0yek();
				p0.z0rek(num + 1f);
				num = p0.z0iek();
				p0.z0yek(num - 1f);
			}
			z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh.z0tek(p0, z0ZzZzsmk2.z0rek());
			if (!(z0ZzZzbdh2.z0uek() > 2f) || !(z0ZzZzbdh2.z0iek() > 2f))
			{
				continue;
			}
			z0ZzZzpdh p2 = z0ZzZzsmk2.z0xqk(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek());
			z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzsmk2.z0mek();
			z0ZzZzbdh3.z0rek(3f, 3f);
			if (z0ZzZzbdh3.z0rek(p2))
			{
				z0ZzZzbdh z0ZzZzbdh4 = new z0ZzZzbdh(p2, z0ZzZzsmk2.z0lwk(p0.z0uek(), p0.z0iek()));
				if (z0ZzZzbdh4.z0uek() > 0f && z0ZzZzbdh4.z0iek() > 0f)
				{
					z0ZzZzbdh4.z0eek(z0ZzZzbdh4.z0tek() - 2f);
					z0ZzZzbdh4.z0tek(z0ZzZzbdh4.z0uek() + 4f);
					z0ZzZzndh p3 = z0ZzZzbdh4.z0cek();
					z0tek((z0ZzZzwrj)z0ZzZzsmk2.z0cek(), p3);
				}
			}
		}
	}

	public void z0huk()
	{
		z0tek(ScrollToViewStyle.Normal);
	}

	public void z0guk()
	{
		if (!((z0ZzZzspj)this).z0hrk() && z0npk != null)
		{
			bool p = base.z0uek();
			base.z0tek(p0: false);
			z0uek(z0npk.z0itk());
			base.z0tek(p);
		}
	}

	public bool z0fuk()
	{
		return z0urk() == WriterControlExtViewMode.JumpPrint;
	}

	public void z0duk()
	{
		if (!z0crk().BehaviorOptions.AutoAssistInsertString)
		{
			return;
		}
		z0ZzZzdbj.z0cxk z0cxk = z0xek().z0spk();
		if (z0cxk != null)
		{
			int autoAssistInsertStringDetectTextLength = z0crk().BehaviorOptions.AutoAssistInsertStringDetectTextLength;
			if (autoAssistInsertStringDetectTextLength > 0 && z0cxk.z0yek.Length < autoAssistInsertStringDetectTextLength)
			{
				z0qrk();
				return;
			}
			z0fik++;
			z0ayk().z0llk(z0cxk.z0tek, z0cxk.z0yek, z0fik);
		}
	}

	private new string z0cek(string p0)
	{
		return z0ZzZzdfh.z0rek().z0dd(z0xek(), p0);
	}

	public void z0iek(z0ZzZzheh p0)
	{
		z0hx(p0);
	}

	public void z0tek(z0ZzZzvej p0)
	{
		if (z0npk != null)
		{
			z0npk.z0bek(p0);
		}
	}

	public void z0tek(z0ZzZzgeh p0)
	{
		z0sx(p0);
	}

	public z0ZzZzlfh z0suk()
	{
		if (z0xek() == null)
		{
			return null;
		}
		return z0xek().z0pek();
	}

	private bool z0auk()
	{
		if (z0bok != null)
		{
			return z0bok.Mode == JumpPrintMode.Normal;
		}
		return false;
	}

	public z0ZzZzenj z0quk()
	{
		if (z0xek() != null && z0xek().z0suk() != null)
		{
			return z0xek().z0suk();
		}
		return z0suk().z0rek();
	}

	internal string z0yek(z0ZzZzerj p0, bool p1 = true)
	{
		if (!z0wpk)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		z0tek(z0qtk(), stringBuilder);
		if (p0 == null)
		{
			p0 = ((z0ZzZzqrj)this).z0rek();
		}
		stringBuilder.Append(z0kyk());
		if (p0 != null && p0.Count > 0)
		{
			int num = p0[0].z0erk().z0iek();
			int num2 = p0[0].z0erk().z0oek();
			string text = num.ToString();
			string text2 = num2.ToString();
			foreach (z0ZzZzwrj item in p0)
			{
				stringBuilder.Append(",{\"PageIndex\":").Append(p0.IndexOf(item));
				if (item.z0erk().z0iek() == num)
				{
					stringBuilder.Append(",\"Width\":").Append(text);
				}
				else
				{
					stringBuilder.Append(",\"Width\":").Append(item.z0erk().z0iek());
				}
				if (item.z0erk().z0oek() == num2)
				{
					stringBuilder.Append(",\"Height\":").Append(text2);
				}
				else
				{
					stringBuilder.Append(",\"Height\":").Append(item.z0erk().z0oek());
				}
				XTextDocument xTextDocument = (XTextDocument)item.z0srk();
				if (!p1 && xTextDocument.PageSettings.z0eek(item.z0brk(), p1: false))
				{
					stringBuilder.Append(",\"Background\":true");
				}
				else
				{
					stringBuilder.Append(",\"Background\":false");
				}
				stringBuilder.Append('}');
			}
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	protected override void z0lhk(z0ZzZzweh p0)
	{
		if (!z0xtk())
		{
			return;
		}
		base.z0lhk(p0);
		if (z0urk() == WriterControlExtViewMode.BoundsSelection || z0urk() == WriterControlExtViewMode.JumpPrint || z0urk() == WriterControlExtViewMode.OffsetJumpPrint || z0npk == null)
		{
			return;
		}
		bool flag = false;
		int p1 = p0.z0rek();
		int p2 = p0.z0tek();
		z0eek((z0ZzZzsmk)null);
		foreach (z0ZzZzsmk item in base.z0lrk())
		{
			XTextDocument xTextDocument = (XTextDocument)item.z0eek();
			if (!item.z0lrk().z0eek(p1, p2) || (z0oyk() && z0ZzZzdpk.z0eek(item.z0vek())) || item.z0vek() == PageContentPartyStyle.HeaderRows)
			{
				continue;
			}
			XTextDocumentContentElement xTextDocumentContentElement = null;
			switch (item.z0vek())
			{
			case PageContentPartyStyle.Body:
				xTextDocumentContentElement = xTextDocument.z0xyk();
				break;
			case PageContentPartyStyle.Header:
				xTextDocumentContentElement = xTextDocument.z0pyk();
				z0eek(item);
				break;
			case PageContentPartyStyle.Footer:
				xTextDocumentContentElement = xTextDocument.z0lik();
				z0eek(item);
				break;
			case PageContentPartyStyle.HeaderForFirstPage:
				xTextDocumentContentElement = xTextDocument.z0cyk();
				z0eek(item);
				break;
			case PageContentPartyStyle.FooterForFirstPage:
				xTextDocumentContentElement = xTextDocument.z0guk();
				z0eek(item);
				break;
			}
			if (xTextDocumentContentElement != null && !xTextDocumentContentElement.Visible)
			{
				return;
			}
			bool flag2 = false;
			XTextDocumentContentElement xTextDocumentContentElement2 = xTextDocument.z0jrk();
			if (xTextDocument.z0jrk() != xTextDocumentContentElement)
			{
				if (z0drk() != null && z0drk().CurrentComment != null)
				{
					z0drk().CurrentComment = null;
				}
				xTextDocument.z0bek(xTextDocumentContentElement);
				flag2 = true;
			}
			if (!item.z0oek())
			{
				xTextDocument.z0jrk().z0gu();
				z0sc();
				z0hz();
				z0ZzZzodh z0ZzZzodh2 = item.z0gwk(p0.z0rek(), p0.z0tek());
				XTextElement xTextElement = xTextDocument.z0ryk().z0tek(z0ZzZzodh2.z0rek(), z0ZzZzodh2.z0tek(), p2: false);
				if (xTextElement != null && xTextElement.z0jrk() >= 0)
				{
					xTextDocument.z0ryk().z0tek(xTextElement.z0jrk(), 0);
				}
				z0nek();
				flag = true;
			}
			if (flag2)
			{
				xTextDocument.z0jrk().z0tek(xTextDocumentContentElement2.z0zek(), xTextDocumentContentElement.z0zek());
			}
			break;
		}
		if (!flag)
		{
			z0tek(p0, DocumentEventStyles.MouseDblClick);
		}
	}

	public void z0tek(FormViewMode p0)
	{
		z0crk().BehaviorOptions.FormView = p0;
	}

	public byte[] z0yek(z0ZzZzwrj p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("page");
		}
		JumpPrintInfo jumpPrintInfo = z0cuk_jiejie20260327142557;
		bool flag = true;
		base.z0vrk = true;
		XTextDocument xTextDocument = (XTextDocument)p0.z0srk();
		int num = xTextDocument.z0suk().IndexOf(p0);
		if (num < 0)
		{
			num = p0.z0brk();
		}
		xTextDocument.z0wck = false;
		xTextDocument.z0qtk().Printing = true;
		xTextDocument.z0qtk().PrintPreviewing = true;
		bool p2 = true;
		if (jumpPrintInfo != null && jumpPrintInfo.HasValidateInfo)
		{
			if (jumpPrintInfo.PageIndex >= 0 && jumpPrintInfo.PageIndex == num && jumpPrintInfo.Position > 0f)
			{
				p2 = false;
				flag = false;
			}
			else if (jumpPrintInfo.EndPageIndex >= 0 && jumpPrintInfo.EndPageIndex == num && jumpPrintInfo.EndPosition > 0f)
			{
				p2 = false;
				flag = false;
			}
			else if (jumpPrintInfo.Mode == JumpPrintMode.Offset && num == 0)
			{
				p2 = false;
			}
		}
		else if (num == 0 && xTextDocument.z0iik() > 0f)
		{
			p2 = false;
		}
		if (z0cok != null && z0cok.z0ylk())
		{
			p2 = true;
		}
		z0ZzZzadh z0ZzZzadh2 = new z0ZzZzadh();
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(xTextDocument.PageSettings, p1: false, p2: false);
		z0ZzZzarj2.z0eek(GraphicsUnit.Pixel);
		if (p1)
		{
			if (z0apk)
			{
				z0ZzZzadh2.z0eek(z0kyk() * z0xek().z0qik());
			}
			else
			{
				z0ZzZzadh2.z0eek(z0kyk() * z0xek().z0qik());
			}
			if (flag && xTextDocument.PageSettings.z0eek(p0.z0brk(), p1: true))
			{
				z0tek(xTextDocument, z0ZzZzadh2, (int)z0ZzZzarj2.z0xek(), (int)(z0ZzZzarj2.z0nek() * (float)xTextDocument.PageSettings.z0grk()), 1f);
			}
			xTextDocument.z0bek(z0ZzZzadh2, p0, p2: false, 1f, DocumentRenderMode.Print, p2, z0cok);
		}
		else
		{
			z0ZzZzndh z0ZzZzndh2 = z0tek(p0);
			z0ZzZzadh2.z0eek(1f);
			if (flag && xTextDocument.PageSettings.z0eek(p0.z0brk(), p1: true))
			{
				z0tek(xTextDocument, z0ZzZzadh2, (int)z0ZzZzarj2.z0xek(), (int)(z0ZzZzarj2.z0nek() * (float)xTextDocument.PageSettings.z0grk()), 1f);
			}
			if (XTextDocument.z0xok())
			{
				using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				z0ZzZzadh2.z0eek(z0ZzZzkfh.z0drk.z0tek(), z0ZzZzimk.z0oek, z0ZzZzyfh.z0uek, z0ZzZzndh2.z0pek() + 20, z0ZzZzndh2.z0mek() + 20);
			}
			JumpPrintInfo p3 = z0cok.z0ilk();
			z0cok.z0gkk(jumpPrintInfo);
			xTextDocument.z0bek(z0ZzZzadh2, p0, p2: false, 1f, DocumentRenderMode.Print, p2, z0cok);
			z0cok.z0gkk(p3);
		}
		if (jumpPrintInfo != null && jumpPrintInfo.HasValidateInfo && jumpPrintInfo.Mode != JumpPrintMode.Offset)
		{
			z0ZzZztfh p4 = (p1 ? new z0ZzZzzdh(z0crk().ViewOptions.MaskColorForJumpPrint) : z0ZzZzyfh.z0iek);
			if (jumpPrintInfo.PageIndex > 0 && num < jumpPrintInfo.PageIndex)
			{
				z0ZzZzadh2.z0krk();
				if (p1)
				{
					z0ZzZzadh2.z0eek(p4, 0f, 0f, p0.z0rrk(), p0.z0crk(), 0f);
				}
				else
				{
					z0ZzZzadh2.z0eek(p4, 0f, 0f, p0.z0rrk(), p0.z0crk(), 0f);
				}
			}
			else if (jumpPrintInfo.EndPageIndex >= 0 && num > jumpPrintInfo.EndPageIndex)
			{
				z0ZzZzadh2.z0krk();
				if (p1)
				{
					z0ZzZzadh2.z0eek(p4, 0f, 0f, p0.z0rrk(), p0.z0crk(), 0f);
				}
				else
				{
					z0ZzZzadh2.z0eek(p4, 0f, 0f, p0.z0rrk(), p0.z0crk(), 0f);
				}
			}
			else
			{
				if (num >= 0 && num == jumpPrintInfo.PageIndex && jumpPrintInfo.Position > 0f)
				{
					z0ZzZzadh2.z0krk();
					float p5 = p0.z0yrk() + jumpPrintInfo.Position;
					if (p1)
					{
						z0ZzZzadh2.z0eek(p4, 0f, 0f, p0.z0rrk(), p5, 0f);
					}
					else
					{
						z0ZzZzadh2.z0eek(p4, 0f, 0f, p0.z0rrk(), p5, 0f);
					}
				}
				if (num >= 0 && num == jumpPrintInfo.EndPageIndex && jumpPrintInfo.EndPosition > 0f)
				{
					z0ZzZzadh2.z0krk();
					float num2 = p0.z0yrk() + jumpPrintInfo.EndPosition;
					if (p1)
					{
						z0ZzZzadh2.z0eek(p4, 0f, num2, p0.z0rrk(), p0.z0crk() - num2, 0f);
					}
					else
					{
						z0ZzZzadh2.z0eek(p4, 0f, num2, p0.z0rrk(), p0.z0crk() - num2, 0f);
					}
				}
			}
		}
		byte[] result = z0ZzZzadh2.z0iek();
		z0ZzZzadh2.Dispose();
		return result;
	}

	public bool z0wuk()
	{
		if (z0nok)
		{
			return true;
		}
		if (z0eok != null)
		{
			return z0eok.Count > 0;
		}
		return false;
	}

	public void z0pek(XTextElement p0)
	{
		if (z0rpk == p0)
		{
			return;
		}
		if (z0rpk != null && ((z0ZzZzmwh)this).z0eek())
		{
			z0ZzZzndh p1 = z0jrk();
			if (!p1.z0vek())
			{
				((z0ZzZzmwh)this).z0eek(p1);
			}
		}
		z0rpk = p0;
		if (z0rpk != null && ((z0ZzZzmwh)this).z0eek())
		{
			z0ZzZzndh p2 = z0jrk();
			if (!p2.z0vek())
			{
				((z0ZzZzmwh)this).z0eek(p2);
			}
		}
	}

	public override void z0sc(int p0 = 0)
	{
		if (z0npk == null)
		{
			return;
		}
		z0ptk();
		z0zik = null;
		z0eek(z0npk.z0suk());
		base.z0lrk().z0iek = base.z0hrk();
		base.z0sc(p0);
		PageContentPartyStyle pageContentPartyStyle = PageContentPartyStyle.Body;
		if (z0npk.z0jrk() != null)
		{
			pageContentPartyStyle = z0npk.z0jrk().z0du();
		}
		WriterControlExtViewMode writerControlExtViewMode = z0urk();
		foreach (z0ZzZzsmk item in base.z0lrk())
		{
			if (writerControlExtViewMode == WriterControlExtViewMode.BoundsSelection)
			{
				item.z0rek(p0: false);
			}
			else
			{
				item.z0rek(item.z0vek() == pageContentPartyStyle);
			}
		}
		if (z0eek() != null)
		{
			if (z0eek().z0vek() == z0qtk().z0oik())
			{
				bool flag = false;
				foreach (z0ZzZzsmk item2 in base.z0lrk())
				{
					if (item2.z0eek() == z0eek().z0eek() && item2.z0yek() == z0eek().z0yek() && item2.z0vek() == z0eek().z0vek())
					{
						z0eek(item2);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					z0eek((z0ZzZzsmk)null);
				}
			}
			else
			{
				z0eek((z0ZzZzsmk)null);
			}
		}
		foreach (z0ZzZzsmk item3 in base.z0lrk())
		{
			if (z0ZzZzdpk.z0eek(item3.z0vek()))
			{
				item3.z0rek(item3 == z0eek());
			}
		}
		z0ayk()?.z0jlk();
		z0krk();
	}

	public int z0euk()
	{
		if (z0yyk() == null || z0yyk().UserCancel)
		{
			return 0;
		}
		return z0yyk().Position;
	}

	public void z0tek(ScrollToViewStyle p0)
	{
		if (z0npk == null || ((z0ZzZzspj)this).z0hrk())
		{
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0npk.z0jrk();
		XTextElement xTextElement = xTextDocumentContentElement.z0frk().z0ork();
		if (xTextElement == null)
		{
			return;
		}
		if (xTextDocumentContentElement.z0frk().z0frk())
		{
			XTextElement xTextElement2 = xTextDocumentContentElement.z0frk().z0nek(xTextElement);
			if (xTextElement2 == null)
			{
				xTextElement2 = xTextElement;
			}
			z0gx((int)(xTextElement2.z0zrk() + xTextElement2.Width - 1f), (int)xTextElement2.z0ltk(), ((z0ZzZzxnj)this).z0iek() ? z0ZzZzxnj.z0nek : z0ZzZzxnj.z0bek, (int)xTextElement2.Height, p0);
		}
		else
		{
			z0gx((int)xTextElement.z0zrk(), (int)xTextElement.z0ltk(), ((z0ZzZzxnj)this).z0iek() ? z0ZzZzxnj.z0nek : z0ZzZzxnj.z0bek, (int)xTextElement.Height, p0);
		}
	}

	public void z0yek(z0ZzZzgeh p0)
	{
		z0sx(p0);
	}

	public void z0grk(bool p0)
	{
		z0yik = p0;
	}

	public void z0yek(float p0)
	{
		XTextDocument xTextDocument = z0qtk();
		z0syk().z0eek(p0);
		if (z0urk() == WriterControlExtViewMode.OffsetJumpPrint)
		{
			JumpPrintInfo jumpPrintInfo = xTextDocument.z0zek(p0);
			if (jumpPrintInfo != null && jumpPrintInfo.PageIndex == 0)
			{
				xTextDocument.z0bek(jumpPrintInfo.AbsPosition);
				z0syk().PageIndex = 0;
				z0syk().Position = jumpPrintInfo.Position;
				z0syk().EndPageIndex = -1;
				z0syk().EndPosition = -1f;
			}
			else
			{
				xTextDocument.z0bek(0f);
				z0syk().PageIndex = 0;
				z0syk().Position = 0f;
			}
			z0tek(p0: false, p1: true);
			z0guk();
		}
		else
		{
			if (xTextDocument.z0iik() != 0f)
			{
				xTextDocument.z0bek(0f);
				z0tek(p0: false, p1: true);
				z0guk();
			}
			JumpPrintInfo jumpPrintInfo2 = xTextDocument.z0drk(p0);
			if (jumpPrintInfo2 != null)
			{
				z0syk().PageIndex = jumpPrintInfo2.PageIndex;
				z0syk().Position = jumpPrintInfo2.Position;
			}
			else
			{
				z0syk().PageIndex = 0;
				z0syk().Position = 0f;
			}
			z0hz();
		}
	}

	public object z0tek(string p0, bool p1, object p2, bool p3)
	{
		object result = z0nyk().z0eek(p0, p1, p2, p3);
		z0byk().z0tn();
		return result;
	}

	public void z0tek(bool p0, bool p1)
	{
		if (z0ppk != null)
		{
			z0ppk.z0tek();
		}
		if (z0bik != null)
		{
			z0bik.z0px();
		}
		z0rpk = null;
		z0fok = null;
		z0grk();
		XTextDocument xTextDocument = z0qtk();
		xTextDocument.z0wck = base.z0hrk();
		xTextDocument.z0vik();
		if (base.z0vek())
		{
			xTextDocument.z0qtk().RenderMode = DocumentRenderMode.ReadPaint;
		}
		else
		{
			xTextDocument.z0qtk().RenderMode = DocumentRenderMode.Paint;
		}
		xTextDocument.z0bek(p0, p1, this);
	}

	public string z0tek(int p0, int p1, int p2, bool p3)
	{
		if (z0cuk_jiejie20260327142557 != null && z0cuk_jiejie20260327142557.Enabled && z0cuk_jiejie20260327142557.Mode == JumpPrintMode.Normal)
		{
			if (p0 < 0 || p0 >= base.z0frk().Count)
			{
				return null;
			}
			z0ZzZzwrj z0ZzZzwrj2 = base.z0frk()[p0];
			float num = z0qtk().z0xek((float)p2) / z0kyk();
			float num2 = Math.Max(z0ZzZzwrj2.z0frk(), z0ZzZzwrj2.z0trk().z0atk() + z0ZzZzwrj2.z0prk());
			if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
			{
				num2 += z0ZzZzwrj2.z0krk().z0iek();
			}
			num = num - num2 + z0ZzZzwrj2.z0irk();
			if (num < z0ZzZzwrj2.z0irk() || num >= z0ZzZzwrj2.z0qrk())
			{
				return null;
			}
			JumpPrintInfo jumpPrintInfo = z0qtk().z0drk(num);
			if (jumpPrintInfo == null)
			{
				int num3 = Math.Max(z0cuk_jiejie20260327142557.PageIndex, z0cuk_jiejie20260327142557.EndPageIndex);
				z0cuk_jiejie20260327142557.z0uek();
				z0cuk_jiejie20260327142557.Enabled = true;
				z0cuk_jiejie20260327142557.Mode = JumpPrintMode.Normal;
				return "0," + num3;
			}
			int num4 = -1;
			int num5 = -1;
			if (p3)
			{
				if (z0cuk_jiejie20260327142557.EndPageIndex != jumpPrintInfo.PageIndex || z0cuk_jiejie20260327142557.EndPosition != jumpPrintInfo.Position)
				{
					if (z0cuk_jiejie20260327142557.EndPageIndex >= 0)
					{
						num4 = Math.Min(z0cuk_jiejie20260327142557.EndPageIndex, jumpPrintInfo.PageIndex);
						num5 = Math.Max(z0cuk_jiejie20260327142557.EndPageIndex, jumpPrintInfo.PageIndex);
					}
					else
					{
						num4 = jumpPrintInfo.PageIndex;
						num5 = base.z0frk().Count - 1;
					}
					z0cuk_jiejie20260327142557.EndPageIndex = jumpPrintInfo.PageIndex;
					z0cuk_jiejie20260327142557.z0rek(num);
					z0cuk_jiejie20260327142557.EndPosition = jumpPrintInfo.Position;
				}
			}
			else if (z0cuk_jiejie20260327142557.PageIndex != jumpPrintInfo.PageIndex || z0cuk_jiejie20260327142557.Position != jumpPrintInfo.Position)
			{
				if (z0cuk_jiejie20260327142557.Position >= 0f)
				{
					num4 = Math.Min(z0cuk_jiejie20260327142557.PageIndex, jumpPrintInfo.PageIndex);
					num5 = Math.Max(z0cuk_jiejie20260327142557.PageIndex, jumpPrintInfo.PageIndex);
				}
				else
				{
					num4 = 0;
					num5 = jumpPrintInfo.PageIndex;
				}
				if (z0cuk_jiejie20260327142557.EndPageIndex >= 0)
				{
					num5 = z0ipk.Count;
				}
				z0cuk_jiejie20260327142557.EndPageIndex = -1;
				z0cuk_jiejie20260327142557.EndPosition = 0f;
				z0cuk_jiejie20260327142557.PageIndex = jumpPrintInfo.PageIndex;
				z0cuk_jiejie20260327142557.z0eek(num);
				z0cuk_jiejie20260327142557.Position = jumpPrintInfo.Position;
			}
			if (num4 >= 0 || num5 >= 0)
			{
				return num4 + "," + num5;
			}
		}
		return null;
	}

	internal void z0xek(string p0)
	{
		z0xek().z0yj();
	}

	private void z0uek(object p0)
	{
		if (z0oik)
		{
			return;
		}
		z0ZzZzopk z0ZzZzopk2 = (z0ZzZzopk)p0;
		z0ZzZzxpk z0ZzZzxpk2 = (z0ZzZzxpk)z0oek(0);
		z0ZzZzipk z0ZzZzipk2 = (z0ZzZzipk)z0zik;
		if (!z0ZzZzxpk2.z0yek)
		{
			if (z0zik != null && z0ZzZzipk2.Count > 0)
			{
				z0ZzZzipk2.Clear();
			}
		}
		else if (z0ZzZzipk2 == null || z0ZzZzipk2.Count == 0)
		{
			z0zik = null;
		}
		((z0ZzZzipk)z0dtk()).z0eek(this, z0ZzZzopk2.z0rek(), z0ZzZzopk2.z0eek().z0eek());
		if (z0ZzZzxpk2.z0grk)
		{
			z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk(z0ZzZzimk.DefaultFontName, 30f);
			int alpha = 120;
			int num = 1;
			if (z0ZzZzxpk2.z0eek() == null || z0ZzZzxpk2.z0eek().IndexOf(z0ZzZzkfh.z0drk.z0tek()) < 0)
			{
				alpha = 255;
				z0ZzZzimk2.Size = 60f;
				num = 3;
			}
			object p1 = z0ZzZzopk2.z0rek().z0bek();
			z0ZzZzopk2.z0rek().z0eek(new z0ZzZzjdh());
			float num2 = z0ZzZzimk2.z0eek(z0ZzZzopk2.z0rek());
			for (int i = 0; i < num; i++)
			{
				z0ZzZzopk2.z0rek().z0eek(z0ZzZziok.z0kyk(), z0ZzZzimk2, Color.FromArgb(alpha, Color.Red), 10f, 50f + (float)i * num2);
			}
			z0ZzZzopk2.z0rek().z0eek(p1);
		}
	}

	internal string z0ruk()
	{
		return z0qtk().z0brk();
	}

	protected override void z0dc(EventArgs p0)
	{
		if (z0xtk())
		{
			base.z0dc(p0);
			if (!z0auk() && z0npk != null)
			{
				DocumentEventArgs e = new DocumentEventArgs(z0npk, z0npk, DocumentEventStyles.MouseLeave);
				e.Cursor = null;
				z0npk.z0mu(e);
			}
			z0fx(z0ZzZzbwh.z0vek);
			z0xrk();
		}
	}

	public float z0tuk()
	{
		if (z0bok != null)
		{
			return z0bok.NativeEndPosition;
		}
		return 0f;
	}

	protected override void z0fc(z0ZzZzleh p0)
	{
		if (z0mok == DragOperationState.None)
		{
			z0mok = DragOperationState.Drag;
		}
		if (z0npk != null)
		{
			p0.z0eek((z0ZzZzzwh)0);
			z0tek(p0, 0);
		}
	}

	public void z0mek(XTextElement p0)
	{
		if (p0 == null)
		{
			p0 = z0fyk();
		}
		DocumentEventArgs e = new DocumentEventArgs(z0qtk(), p0, DocumentEventStyles.DefaultEditMethod);
		while (p0 != null)
		{
			e.Element = p0;
			p0.z0mu(e);
			if (!e.Handled)
			{
				p0 = p0.z0ji();
				continue;
			}
			break;
		}
	}

	private int z0iek(int p0, int p1)
	{
		if (p1 <= 1)
		{
			return p0;
		}
		if (p0 % p1 == 0)
		{
			return p0 / p1;
		}
		return (p0 + 1) / p1;
	}

	public bool z0yuk()
	{
		if (z0pok == null)
		{
			return z0ook;
		}
		return z0byk().z0wm();
	}

	public bool z0tek(TextReader p0, string p1)
	{
		z0opk = null;
		if (p0 == null)
		{
			throw new ArgumentNullException("reader");
		}
		z0xek().z0wik();
		XTextDocument xTextDocument = z0qtk();
		try
		{
			z0nik = true;
			xTextDocument.z0pok();
			xTextDocument.z0quk();
			z0uyk();
			try
			{
				xTextDocument.z0bek(p0: false);
				xTextDocument.z0bek(p0, p1);
			}
			finally
			{
				xTextDocument.z0bek(p0: true);
			}
			z0xek().z0wik();
			z0xyk();
			if (z0crk().BehaviorOptions.AutoDocumentValueValidate)
			{
				xTextDocument.z0stk();
			}
			xTextDocument.Modified = false;
			z0hz();
		}
		finally
		{
			xTextDocument.z0qmk();
			xTextDocument.z0smk();
			z0nik = false;
		}
		z0xek().z0eek(new WriterEventArgs(z0xek(), xTextDocument, null));
		return true;
	}

	public bool z0uuk()
	{
		if (z0bik != null)
		{
			return z0bik.z0ux();
		}
		return false;
	}

	public void z0uek(z0ZzZzleh p0)
	{
		z0fc(p0);
	}

	public void z0oek(z0ZzZzweh p0)
	{
		z0ZzZzmwh.z0qrk = new z0ZzZzodh(p0.z0rek(), p0.z0tek());
		z0ZzZzmwh.z0ork = p0.z0yek();
		z0lhk(p0);
	}

	public override void z0gc(int p0, int p1, int p2, int p3)
	{
		z0tek(p0, p1, p2, p3, (z0ZzZzupj)0);
	}

	protected override void z0hc(EventArgs p0)
	{
	}

	public z0ZzZzqxj z0iuk()
	{
		return z0npk?.z0htk()?.z0hp();
	}

	public void z0tek(XTextElement p0, string p1)
	{
	}

	private new int z0rek(List<z0ZzZzwrj> p0, int p1)
	{
		XPageSettings xPageSettings = p0[p1].z0trk();
		if (xPageSettings.z0grk() > 1)
		{
			for (int i = 1; i < xPageSettings.z0grk() && p1 + i < p0.Count; i++)
			{
				if (xPageSettings != p0[i].z0trk())
				{
					return p1 + i;
				}
			}
			return p1 + xPageSettings.z0grk();
		}
		return p1 + 1;
	}

	internal z0dgj z0tek(PageContentPartyStyle p0, int p1, int p2, int p3 = 0, int p4 = 0, bool p5 = false)
	{
		if (z0apk)
		{
			for (int i = 0; i < base.z0frk().Count; i++)
			{
				z0ZzZzwrj z0ZzZzwrj2 = base.z0frk()[i];
				if ((float)p2 >= z0ZzZzwrj2.z0irk() - 1f && (float)p2 < z0ZzZzwrj2.z0qrk())
				{
					float num = z0ZzZzwrj2.z0yrk();
					if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
					{
						num += z0ZzZzwrj2.z0krk().z0iek();
					}
					break;
				}
			}
		}
		else
		{
			if (p0 != PageContentPartyStyle.Body)
			{
				z0dgj z0dgj = new z0dgj();
				z0dgj.z0rek = base.z0frk()[0];
				foreach (z0ZzZzsmk item in base.z0lrk())
				{
					if (item.z0vek() == p0)
					{
						z0ZzZzpdh z0ZzZzpdh2 = item.z0xqk(p1, p2);
						z0dgj.z0iek = 0;
						z0dgj.z0eek = (int)((z0ZzZzpdh2.z0rek() - (float)z0dgj.z0rek.z0erk().z0pek()) * z0kyk());
						z0dgj.z0yek = (int)((z0ZzZzpdh2.z0tek() - (float)z0dgj.z0rek.z0erk().z0mek()) * z0kyk());
						if (p3 > 0 && p4 > 0)
						{
							z0ZzZzcdh z0ZzZzcdh2 = item.z0kwk(p3, p4);
							z0dgj.z0tek = (int)((float)z0ZzZzcdh2.z0rek() * z0kyk());
							z0dgj.z0uek = (int)((float)z0ZzZzcdh2.z0tek() * z0kyk());
						}
						break;
					}
				}
				return z0dgj;
			}
			z0ZzZzodh p6 = ((!p5) ? z0tc(p1, p2) : ((z0ZzZzhrj)((z0ZzZzspj)this).z0drk()).z0eek(p1, p2));
			z0ZzZzerj z0ZzZzerj2 = ((z0ZzZzqrj)this).z0rek();
			foreach (z0ZzZzwrj item2 in z0ZzZzerj2)
			{
				if (item2.z0erk().z0rek(p6))
				{
					z0dgj z0dgj2 = new z0dgj();
					z0dgj2.z0rek = item2;
					z0dgj2.z0iek = z0ZzZzerj2.IndexOf(item2);
					z0dgj2.z0eek = (int)((float)(p6.z0rek() - item2.z0erk().z0pek()) * z0kyk());
					z0dgj2.z0yek = (int)((float)(p6.z0tek() - item2.z0erk().z0mek()) * z0kyk());
					if (p3 > 0 && p4 > 0)
					{
						z0ZzZzcdh z0ZzZzcdh3 = ((z0ZzZzspj)this).z0drk().z0kwk(p3, p4);
						z0dgj2.z0tek = (int)((float)z0ZzZzcdh3.z0rek() * z0kyk());
						z0dgj2.z0uek = (int)((float)z0ZzZzcdh3.z0tek() * z0kyk());
					}
					return z0dgj2;
				}
			}
		}
		return null;
	}

	protected override bool z0jc()
	{
		return z0crk().BehaviorOptions.DesignMode;
	}

	internal void z0zek(string p0)
	{
		z0oek(p0);
	}

	internal void z0ouk()
	{
		z0xek().z0yj();
	}

	private void z0puk()
	{
		z0qtk().z0quk();
	}

	public void z0frk(bool p0)
	{
		z0crk().BehaviorOptions.CommentEditableWhenReadonly = p0;
	}

	internal PageTitlePosition z0muk()
	{
		return z0sok;
	}

	public string z0nuk()
	{
		return z0mpk;
	}

	internal new z0ZzZzsmk z0nek(XTextElement p0)
	{
		float p1 = p0.z0zrk();
		float p2 = p0.z0ltk();
		foreach (z0ZzZzsmk item in base.z0lrk())
		{
			if (item.z0rek().z0eek(p1, p2))
			{
				return item;
			}
		}
		return null;
	}

	internal void z0lrk(string p0)
	{
		z0oek(p0);
	}

	internal void z0tek(XTextDocumentContentElement p0)
	{
		z0eek((z0ZzZzsmk)null);
		z0ZzZzwrj z0ZzZzwrj2 = ((z0ZzZzqrj)this).z0xek();
		if (z0ZzZzwrj2 == null)
		{
			z0ZzZzwrj2 = z0qtk().z0suk().z0iek();
		}
		if (z0ZzZzwrj2 == null)
		{
			return;
		}
		foreach (z0ZzZzsmk item in base.z0lrk())
		{
			XTextDocument xTextDocument = (XTextDocument)item.z0eek();
			if (item.z0cek() != z0ZzZzwrj2 || item.z0vek() == PageContentPartyStyle.HeaderRows || item.z0vek() != p0.z0du() || (z0oyk() && z0ZzZzdpk.z0eek(item.z0vek())))
			{
				continue;
			}
			if (xTextDocument.z0jrk() != p0)
			{
				if (z0drk() != null && z0drk().CurrentComment != null)
				{
					z0drk().CurrentComment = null;
				}
				if (p0 != xTextDocument.z0xyk())
				{
					z0eek(item);
				}
				XTextDocumentContentElement xTextDocumentContentElement = xTextDocument.z0jrk();
				xTextDocument.z0bek(p0);
				xTextDocument.z0jrk().z0tek(xTextDocumentContentElement.z0zek(), p0.z0zek());
				xTextDocument.z0jrk().z0gu();
				z0sc();
				z0hz();
				z0nek();
			}
			break;
		}
	}
}
