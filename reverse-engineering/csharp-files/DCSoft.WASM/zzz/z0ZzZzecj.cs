using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;
using DCSoft.WASM;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzecj : z0ZzZzoxj
{
	private class z0ivk
	{
		private float z0rek;

		private DocumentComment z0tek;

		private float z0yek;

		private float z0uek;

		private bool z0iek;

		private float z0oek;

		private float z0pek;

		private float z0mek;

		private float z0nek;

		private float z0bek;

		public bool z0eek()
		{
			if (z0tek.z0oek() == z0iek && z0tek.z0drk() == z0bek && z0tek.z0qrk() == z0oek && z0tek.z0wrk() == z0pek && z0tek.z0erk() == z0nek && z0tek.z0mek() == z0yek && z0tek.z0cek() == z0rek && z0tek.z0hrk() == z0uek)
			{
				return z0tek.z0rek() != z0mek;
			}
			return true;
		}

		public z0ivk(DocumentComment p0)
		{
			z0iek = p0.z0oek();
			z0bek = p0.z0drk();
			z0oek = p0.z0qrk();
			z0pek = p0.z0wrk();
			z0nek = p0.z0erk();
			z0yek = p0.z0mek();
			z0rek = p0.z0cek();
			z0uek = p0.z0hrk();
			z0mek = p0.z0rek();
			z0tek = p0;
		}
	}

	public class z0hmk_jiejie20260327142557
	{
		public string z0eek;

		public Color z0rek = Color.Black;

		public Color z0tek = Color.White;

		public int z0yek;
	}

	private float z0oek = 200f;

	private static readonly z0ZzZzlsh z0pek;

	private z0ZzZzgpk z0mek = new z0ZzZzgpk();

	private bool z0nek;

	private bool z0bek;

	private DocumentComment z0vek;

	private float z0cek = 10f;

	private XTextDocument z0xek;

	private float z0zek = 20f;

	private float z0lrk = 500f;

	private static readonly z0ZzZzlsh z0krk;

	public DocumentComment CurrentComment
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

	public XTextDocument z0yb()
	{
		return z0xek;
	}

	public bool z0tb(z0ZzZzjpk p0, z0ZzZzqbj p1)
	{
		z0nek = false;
		WriterControlForWASM writerControlForWASM = (WriterControlForWASM)z0iek().z0ayk();
		z0ZzZzgpk z0ZzZzgpk2 = z0hb();
		XTextDocument xTextDocument = z0yb();
		z0ZzZzwcj z0ZzZzwcj2 = xTextDocument.z0gik();
		if (z0ZzZzwcj2 == null || z0ZzZzwcj2.Count == 0)
		{
			if (z0iek() != null && z0iek().z0grk())
			{
				writerControlForWASM?.z0bek("WriterControl_UI.CheckDocumentComentList", null);
				z0iek().z0sc();
			}
			return false;
		}
		z0ZzZzwcj2 = z0ZzZzwcj2.z0uek();
		z0eek(z0ZzZzwcj2, p1: false);
		z0ZzZzsdh z0ZzZzsdh2 = z0eek(xTextDocument);
		float num = p0.z0eek(z0ZzZzsdh2);
		float p2 = num + 10f;
		float num2 = z0ZzZzgpk2.z0eek() - z0ZzZzgpk2.z0tek_jiejie20260327142557() * 2f;
		List<z0ivk> list = new List<z0ivk>(z0ZzZzwcj2.Count);
		foreach (DocumentComment item in z0ZzZzwcj2)
		{
			item.z0jyk = false;
			list.Add(new z0ivk(item));
			item.z0tek(item.z0vrk() != null && !item.z0vrk().z0krk() && item.z0yrk());
			if (!item.z0oek())
			{
				continue;
			}
			if (item.z0mek() <= 0f)
			{
				string text = item.z0eek(z0yb());
				if (text != null && text.Length > 0)
				{
					item.z0oek((int)(Math.Ceiling(p0.z0eek(text, z0ZzZzsdh2, (int)(num2 - z0ZzZzgpk2.z0tek_jiejie20260327142557() * 2f), z0krk).z0tek() / num) * (double)num));
				}
				else
				{
					item.z0oek(num);
				}
				item.z0oek(item.z0mek() + 10f);
			}
			if (item.z0rek() <= 0f)
			{
				if (string.IsNullOrEmpty(item.z0nek()))
				{
					item.z0rek(p2);
				}
				else
				{
					item.z0rek(p0.z0eek(item.z0nek(), z0ZzZzsdh2, (int)(num2 - z0ZzZzgpk2.z0tek_jiejie20260327142557() * 2f), z0pek).z0tek());
				}
			}
			XTextElement xTextElement = item.z0vrk();
			if (xTextElement != null && xTextElement.z0ptk() != null)
			{
				item.z0pek(xTextElement.z0ptk().z0xrk());
				z0nek = true;
			}
			else
			{
				item.z0pek(0f);
				item.z0tek(p0: false);
			}
			item.z0yek(item.z0cek());
			item.z0eek(item.z0rek() + item.z0mek() + z0ZzZzgpk2.z0tek_jiejie20260327142557() * 2f + z0eek());
			if (writerControlForWASM == null || !writerControlForWASM.z0mtk)
			{
				continue;
			}
			JsonObject jsonObject = new JsonObject();
			z0eek(item, jsonObject);
			jsonObject.Add("Width", z0yb().z0grk(num2));
			jsonObject.Add("Height", z0yb().z0grk(item.z0hrk()));
			jsonObject.Add("ZoomRate", writerControlForWASM.ZoomRate);
			string text2 = z0ZzZzzij.z0eek(writerControlForWASM.z0bek("WriterControl_UI.BuildDocumentCommentContent", new object[1] { jsonObject }));
			if (text2 != null && text2.Length > 0)
			{
				float num3 = 0f;
				if (float.TryParse(text2, out num3) && num3 > 0f)
				{
					float wASMBaseZoomRate = writerControlForWASM.WASMBaseZoomRate;
					item.z0jyk = true;
					item.z0eek((z0yb().z0jrk(num3) * wASMBaseZoomRate + z0eek()) / writerControlForWASM.ZoomRate);
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		foreach (z0ZzZzwrj item2 in xTextDocument.z0suk())
		{
			z0ZzZzbdh z0ZzZzbdh2 = z0eek(item2, p1);
			List<DocumentComment> list2 = new List<DocumentComment>();
			foreach (DocumentComment item3 in z0ZzZzwcj2)
			{
				if (item3.z0eek(item2))
				{
					list2.Add(item3);
				}
			}
			if (list2.Count == 0)
			{
				continue;
			}
			float num4 = 0f;
			float num5 = item2.z0urk() * 0.5f;
			foreach (DocumentComment item4 in list2)
			{
				if (item4.z0oek())
				{
					if (item4.z0hrk() > num5)
					{
						item4.z0eek(num5);
					}
					num4 += item4.z0hrk();
					if (num4 >= z0ZzZzbdh2.z0iek())
					{
						item4.z0tek(p0: false);
					}
				}
			}
			float num6 = num4;
			float num7 = item2.z0irk();
			foreach (DocumentComment item5 in list2)
			{
				item5.z0yek(Math.Min(item5.z0cek(), z0ZzZzbdh2.z0nek() - num6));
				item5.z0yek(Math.Max(item5.z0qrk(), num7));
				num7 = item5.z0qrk() + item5.z0hrk();
				num6 -= item5.z0hrk();
			}
			float p3 = z0ZzZzbdh2.z0oek() + z0ZzZzgpk2.z0tek_jiejie20260327142557();
			foreach (DocumentComment item6 in list2)
			{
				item6.z0uek(p3);
				item6.z0iek(num2);
				item6.z0tek(item6.z0hrk() - z0eek());
				if (item6.z0jyk && item6.z0oek())
				{
					if (stringBuilder.Length > 1)
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(item6.GetHashCode().ToString());
				}
			}
		}
		stringBuilder.Append(']');
		writerControlForWASM.z0bek("WriterControl_UI.CheckDocumentComentList", new object[1] { stringBuilder.ToString() });
		bool flag = false;
		foreach (DocumentComment item7 in z0ZzZzwcj2)
		{
			if (item7.z0zek())
			{
				flag = true;
				item7.z0yek(p0: false);
			}
		}
		if (flag)
		{
			flag = false;
			foreach (z0ivk item8 in list)
			{
				if (item8.z0eek())
				{
					flag = true;
					break;
				}
			}
			if (flag && z0iek() != null && !XTextDocument.z0rmk())
			{
				z0iek().z0sc();
				z0iek().z0hz();
			}
		}
		return flag;
	}

	public void z0rb(XTextDocument p0)
	{
		z0xek = p0;
	}

	private void z0eek(DocumentComment p0, JsonObject p1)
	{
		p1.Add("IsSelected", p0 == CurrentComment);
		p1.Add("Index", p0.z0tek());
		p1.Add("HashCode", p0.GetHashCode());
		if (p0.z0ark() != null && p0.z0ark().Length > 0)
		{
			p1.Add("ID", p0.z0ark());
		}
		p1.Add("IsInternal", p0.z0uek());
		string text = p0.z0eek(z0yb());
		if (text != null && text.Length > 0)
		{
			p1.Add("Title", text);
		}
		if (p0.z0nek() != null && p0.z0nek().Length > 0)
		{
			p1.Add("Text", p0.z0nek());
		}
		if (!z0ZzZzkfh.z0eek(p0.z0mrk()))
		{
			p1.Add("CreationTime", z0ZzZzuyk.z0rek(p0.z0mrk()));
		}
		if (p0.z0bek() != null && p0.z0bek().Length > 0)
		{
			p1.Add("ToolTip", p0.z0bek());
		}
		if (p0.z0lrk() != null && p0.z0lrk().Count > 0)
		{
			JsonArray jsonArray = new JsonArray();
			using (zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.z0lrk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XAttribute current = z0bpk.Current;
					JsonObject jsonObject = new JsonObject();
					jsonObject.Add("Name", current.Name);
					jsonObject.Add("Value", current.Value);
					jsonArray.Add(jsonObject);
				}
			}
			p1.Add("Attributes", jsonArray);
		}
		if (p0.z0urk() >= 0)
		{
			p1.Add("CreatorIndex", p0.z0urk());
		}
	}

	private z0ZzZzbdh z0eek(z0ZzZzwrj p0, z0ZzZzqbj p1)
	{
		if (p1 != null && ((z0ZzZzqrj)p1).z0hrk())
		{
			if (z0ZzZzqrj.z0rrk)
			{
				return new z0ZzZzbdh(p0.z0bek() + p0.z0oek(), p0.z0irk(), z0hb().z0eek(), p0.z0xek());
			}
			return new z0ZzZzbdh(p0.z0bek() + p0.z0oek() + p0.z0ork(), p0.z0irk(), z0hb().z0eek(), p0.z0xek());
		}
		if (z0ZzZzqrj.z0rrk)
		{
			return new z0ZzZzbdh(p0.z0bek() + p0.z0oek(), p0.z0irk(), z0hb().z0eek(), p0.z0jrk());
		}
		return new z0ZzZzbdh(p0.z0bek() + p0.z0oek() + p0.z0ork(), p0.z0irk(), z0hb().z0eek(), p0.z0jrk());
	}

	public float z0eek()
	{
		return z0cek;
	}

	public bool z0rek()
	{
		return z0bek;
	}

	public void z0eek(float p0)
	{
		z0cek = p0;
	}

	public bool z0eb(z0ZzZzwcj p0, z0ZzZzwcj p1)
	{
		if (p0 == p1)
		{
			return false;
		}
		List<int> list = new List<int>();
		if (p0 != null)
		{
			foreach (DocumentComment item in p0)
			{
				if (p1 == null)
				{
					list.Add(item.z0tek());
					continue;
				}
				bool flag = false;
				foreach (DocumentComment item2 in p1)
				{
					if (item2.z0tek() == item.z0tek())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(item.z0tek());
				}
			}
		}
		if (p1 != null)
		{
			foreach (DocumentComment item3 in p1)
			{
				if (p0 == null)
				{
					list.Add(item3.z0tek());
					continue;
				}
				bool flag2 = false;
				foreach (DocumentComment item4 in p0)
				{
					if (item4.z0tek() == item3.z0tek())
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					list.Add(item3.z0tek());
				}
			}
		}
		bool result = false;
		if (list.Count > 0)
		{
			foreach (int item5 in list)
			{
				if (z0kb(item5))
				{
					result = true;
				}
			}
		}
		return result;
	}

	public float z0tek()
	{
		return z0lrk;
	}

	private z0ZzZzsdh z0eek(XTextDocument p0)
	{
		string text = p0.z0iu().CommentFontName;
		if (text == null || text.Length == 0)
		{
			text = z0ZzZzimk.DefaultFontName;
		}
		return new z0ZzZzsdh(text, p0.z0iu().CommentFontSize);
	}

	public bool z0wb()
	{
		return z0nek;
	}

	public void z0rek(float p0)
	{
		z0zek = p0;
	}

	public float z0yek()
	{
		return z0zek;
	}

	public void z0qb(DocumentComment p0, ScrollToViewStyle p1)
	{
	}

	public void z0tek(float p0)
	{
		z0lrk = p0;
	}

	public void z0ab(z0ZzZzjpk p0, z0ZzZzbdh p1, z0ZzZzwrj p2, bool p3)
	{
		if (!z0nek)
		{
			return;
		}
		z0ZzZzgpk z0ZzZzgpk2 = z0hb();
		z0ZzZzwcj z0ZzZzwcj2 = z0yb().z0gik();
		if (z0ZzZzwcj2 == null || z0ZzZzwcj2.Count == 0)
		{
			return;
		}
		SmoothingMode p4 = p0.z0mek();
		p0.z0eek(SmoothingMode.HighQuality);
		if (p3)
		{
			foreach (DocumentComment item in z0ZzZzwcj2)
			{
				if (!item.z0oek() || !item.z0eek(p2) || !item.z0yrk())
				{
					continue;
				}
				Color p5 = z0eek(z0sb(item));
				if (item.z0lrk() != null && item.z0lrk().Count > 0 && item.z0lrk().z0tek("TransparentConnection"))
				{
					string text = item.z0lrk().z0yek("TransparentConnection");
					if (text != null)
					{
						text = text.Trim();
						if (string.Equals(text, "true", StringComparison.OrdinalIgnoreCase))
						{
							p5 = Color.Transparent;
						}
					}
				}
				z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(item.z0drk(), item.z0qrk(), item.z0wrk(), item.z0erk());
				using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p5);
				if (item != CurrentComment)
				{
					z0ZzZzudh2.z0eek(DashStyle.Dash);
				}
				else
				{
					z0ZzZzudh2.z0eek(7f);
				}
				XTextElement xTextElement = item.z0vrk();
				float p6 = xTextElement.z0zrk() + xTextElement.Width;
				float num = xTextElement.z0ptk().z0lrk() + 7f;
				float num2 = p2.z0bek() + p2.z0oek() + z0ZzZzgpk2.z0tek_jiejie20260327142557() / 2f;
				if (z0ZzZzdpk.z0eek(p1, p6, num, num2, num))
				{
					p0.z0eek(z0ZzZzudh2, p6, num, num2, num);
				}
				if (z0ZzZzdpk.z0eek(p1, num2, num, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + 40f))
				{
					p0.z0eek(z0ZzZzudh2, num2, num, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + 40f);
				}
			}
		}
		WriterControlForWASM writerControlForWASM = (WriterControlForWASM)z0yb().z0yyk().z0lh();
		foreach (DocumentComment item2 in z0ZzZzwcj2)
		{
			if (!item2.z0oek() || !item2.z0eek(p2) || !item2.z0yrk() || !p1.z0tek(new z0ZzZzbdh((int)item2.z0drk(), (int)item2.z0qrk(), (int)item2.z0wrk(), (int)item2.z0erk())))
			{
				continue;
			}
			Color p7 = z0sb(item2);
			Color p8 = z0eek(p7);
			z0ZzZzbdh p9 = new z0ZzZzbdh(item2.z0drk(), item2.z0qrk(), item2.z0wrk(), item2.z0erk());
			string s = item2.z0eek(z0yb());
			bool flag = false;
			if (p0.z0lrk() != null && writerControlForWASM != null && writerControlForWASM.z0mtk && item2.z0jyk)
			{
				writerControlForWASM.z0trk();
				JsonObject jsonObject = new JsonObject();
				jsonObject.Add("PageIndex", p2.z0brk());
				z0ZzZzbdh z0ZzZzbdh3 = p0.z0lrk().z0eek(p9.z0oek(), p9.z0pek(), p9.z0uek(), p9.z0iek(), WriterControlForWASM.z0vek().ZoomRate);
				jsonObject.Add("Left", z0ZzZzbdh3.z0oek());
				jsonObject.Add("Top", z0ZzZzbdh3.z0pek());
				jsonObject.Add("Width", z0ZzZzbdh3.z0uek());
				jsonObject.Add("Height", z0ZzZzbdh3.z0iek());
				jsonObject.Add("TextColor", z0ZzZzifh.z0eek(item2.z0vek()));
				jsonObject.Add("BackColor", z0ZzZzifh.z0eek(p7));
				jsonObject.Add("BorderColor", z0ZzZzifh.z0eek(p8));
				jsonObject.Add("TitleHeight", item2.z0mek());
				jsonObject.Add("ZoomRate", writerControlForWASM.ZoomRate);
				z0eek(item2, jsonObject);
				flag = z0ZzZzzij.z0eek(writerControlForWASM.z0bek("WriterControl_UI.ShowDocumentComment", new object[1] { jsonObject }), p1: false);
			}
			if (!flag)
			{
				p0.z0eek(p7, p9, z0yek());
				z0ZzZzsdh z0ZzZzsdh2 = z0eek(z0yb());
				z0ZzZzbdh layoutRectangle = new z0ZzZzbdh(p9.z0oek() + z0ZzZzgpk2.z0tek_jiejie20260327142557(), p9.z0pek() + z0ZzZzgpk2.z0tek_jiejie20260327142557(), p9.z0uek() - z0ZzZzgpk2.z0tek_jiejie20260327142557() * 2f, item2.z0mek());
				z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
				z0ZzZzlsh2.z0rek(StringAlignment.Near);
				z0ZzZzlsh2.z0eek(StringAlignment.Near);
				z0ZzZzsdh2.z0eek(p0: true);
				p0.DrawString(s, z0ZzZzsdh2, z0ZzZzyfh.z0eek(item2.z0vek()), layoutRectangle, z0ZzZzlsh2);
				if (!string.IsNullOrEmpty(item2.z0nek()))
				{
					z0ZzZzbdh layoutRectangle2 = new z0ZzZzbdh(p9.z0oek() + z0ZzZzgpk2.z0tek_jiejie20260327142557(), layoutRectangle.z0nek(), p9.z0uek() - z0ZzZzgpk2.z0tek_jiejie20260327142557() * 2f + 0.5f, p9.z0iek() - z0ZzZzgpk2.z0tek_jiejie20260327142557() * 1f - layoutRectangle.z0iek());
					z0ZzZzlsh z0ZzZzlsh3 = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
					z0ZzZzsdh2.z0eek(p0: false);
					z0ZzZzlsh3.z0rek(StringAlignment.Near);
					z0ZzZzlsh3.z0eek(StringAlignment.Near);
					p0.DrawString(item2.z0nek(), z0ZzZzsdh2, z0ZzZzyfh.z0eek(item2.z0vek()), layoutRectangle2, z0ZzZzlsh3);
				}
				float p10 = 1f;
				if (item2 == CurrentComment)
				{
					p10 = 7f;
				}
				using z0ZzZzudh p11 = new z0ZzZzudh(p8, p10);
				p0.z0eek(p11, p9, z0yek());
			}
			if (p3)
			{
				continue;
			}
			using z0ZzZzudh z0ZzZzudh3 = new z0ZzZzudh(p8);
			if (item2 != CurrentComment)
			{
				z0ZzZzudh3.z0eek(DashStyle.Dash);
			}
			else
			{
				z0ZzZzudh3.z0eek(7f);
			}
			XTextElement xTextElement2 = item2.z0vrk();
			float p12 = xTextElement2.z0zrk() + xTextElement2.Width;
			float num3 = xTextElement2.z0ptk().z0lrk();
			float num4 = p2.z0bek() + p2.z0oek() + z0ZzZzgpk2.z0tek_jiejie20260327142557() / 2f;
			p0.z0eek(z0ZzZzudh3, p12, num3, num4, num3);
			p0.z0eek(z0ZzZzudh3, num4, num3, p9.z0oek(), p9.z0pek() + 40f);
		}
		p0.z0eek(p4);
	}

	public void Refreshview()
	{
		using z0ZzZzjpk p = z0yb().z0ru();
		z0tb(p, z0iek());
	}

	static z0ZzZzecj()
	{
		z0krk = z0ZzZzlsh.z0uek().z0eek();
		z0pek = z0ZzZzlsh.z0uek().z0eek();
	}

	public Color z0sb(DocumentComment p0)
	{
		if (p0 == CurrentComment)
		{
			return p0.z0frk();
		}
		return Color.FromArgb(100, p0.z0frk());
	}

	public void z0db(z0ZzZzgpk p0)
	{
		z0mek = p0;
	}

	public void z0fb()
	{
		z0vek = null;
		z0xek = null;
		z0mek = null;
	}

	public bool z0gb(bool p0)
	{
		return z0eek(z0yb().z0gik(), p0);
	}

	private bool z0eek(z0ZzZzwcj p0, bool p1)
	{
		if (p0 == null || p0.Count == 0)
		{
			return false;
		}
		bool result = false;
		z0ZzZzwcj z0ZzZzwcj2 = null;
		if (p1 && z0yb().z0uik())
		{
			z0ZzZzwcj2 = z0yb().Comments.z0eek(p0: false);
		}
		XTextDocument xTextDocument = z0yb();
		z0ZzZzplh z0ZzZzplh2 = xTextDocument.z0xyk().z0frk();
		z0ZzZzzok styles = xTextDocument.z0gnk().Styles;
		int count = styles.Count;
		int[] array = new int[count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = ((DocumentContentStyle)styles[i]).CommentIndex;
		}
		Dictionary<int, XTextElement> dictionary = new Dictionary<int, XTextElement>();
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzplh2).z0krk();
		for (int num = z0ZzZzplh2.Count - 1; num >= 0; num--)
		{
			int z0buk = array2[num].z0buk;
			if (z0buk >= 0 && z0buk < count && array[z0buk] >= 0)
			{
				int num2 = array[z0buk];
				if (num2 >= 0 && !dictionary.ContainsKey(num2))
				{
					dictionary[num2] = z0ZzZzplh2[num];
				}
			}
		}
		for (int num3 = p0.Count - 1; num3 >= 0; num3--)
		{
			DocumentComment documentComment = p0[num3];
			documentComment.z0tek(xTextDocument);
			if (!documentComment.z0uek())
			{
				documentComment.z0eek((XTextElementList)null);
				XTextElement xTextElement = null;
				if (dictionary.TryGetValue(documentComment.z0tek(), out xTextElement))
				{
					if (documentComment.z0vrk() != xTextElement)
					{
						documentComment.z0eek(xTextElement);
						documentComment.z0yek(p0: true);
						z0eek(documentComment);
						result = true;
					}
				}
				else if (documentComment.z0vrk() == null || !documentComment.z0vrk().z0ar(z0yb(), p1: false))
				{
					p0.RemoveAt(num3);
					result = true;
					num3--;
				}
			}
		}
		p0.z0rek();
		if (p0 != z0yb().Comments)
		{
			z0yb().Comments.z0rek();
		}
		if (p1 && z0ZzZzwcj2 != null && z0ZzZzwcj2.Count != z0yb().Comments.Count)
		{
			z0yb().z0imk().z0eek("Comments", z0ZzZzwcj2, z0yb().Comments, z0yb());
			if ((z0ZzZzwcj2 == null || z0ZzZzwcj2.Count == 0) != (z0yb().Comments == null || z0yb().Comments.Count == 0))
			{
				z0yb().z0imk().z0eek((z0ZzZzbzj)6);
				if (z0iek() != null)
				{
					z0iek().z0tek(p0: false, p1: true);
				}
			}
			z0eek(p0: true);
			result = true;
		}
		return result;
	}

	public z0ZzZzgpk z0hb()
	{
		return z0mek;
	}

	public void z0yek(float p0)
	{
		z0oek = p0;
	}

	public void z0jb(z0ZzZzqbj p0)
	{
		((WriterControlForWASM)(p0.z0xek()?.z0lh()))?.z0bek("WriterControl_UI.CheckDocumentComentList", null);
	}

	public static Color z0eek(Color p0)
	{
		return new z0ZzZzypk(p0).z0eek(0.1f);
	}

	public float z0uek()
	{
		return z0oek;
	}

	public void z0eek(bool p0)
	{
		z0bek = p0;
	}

	private z0ZzZzqbj z0iek()
	{
		if (z0xek == null)
		{
			return null;
		}
		return ((XTextElement)z0xek).z0uyk();
	}

	public bool z0kb(int p0)
	{
		XTextElementList xTextElementList = new XTextElementList();
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0yb().z0gnk().Styles.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
				if (documentContentStyle.CommentIndex != p0)
				{
					continue;
				}
				XTextElementList xTextElementList2 = z0yb().z0xyk().z0cek(z0yb().z0gnk().Styles.IndexOf(documentContentStyle));
				if (xTextElementList2 == null || xTextElementList2.Count <= 0)
				{
					break;
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList2.z0ltk())
				{
					while (z0bpk2.MoveNext())
					{
						XTextElement current = z0bpk2.Current;
						XTextElement xTextElement = current;
						if (current is XTextCharElement)
						{
							xTextElement = current.z0ji();
						}
						if (!xTextElementList.Contains(xTextElement))
						{
							xTextElementList.Add(xTextElement);
						}
					}
				}
				break;
			}
		}
		bool result = false;
		if (xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList.z0ltk();
			while (z0bpk2.MoveNext())
			{
				XTextElement current2 = z0bpk2.Current;
				current2.z0rrk();
				XTextContainerElement xTextContainerElement = null;
				xTextContainerElement = ((!(current2 is XTextContainerElement)) ? current2.z0ji() : ((XTextContainerElement)current2));
				if (xTextContainerElement != null)
				{
					ContentChangedEventArgs e = new ContentChangedEventArgs();
					e.Document = z0yb();
					e.Element = xTextContainerElement;
					xTextContainerElement.z0rr(e);
					result = true;
				}
			}
		}
		return result;
	}

	private void z0eek(DocumentComment p0)
	{
	}
}
