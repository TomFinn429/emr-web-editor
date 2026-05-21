using System;
using System.Collections.Generic;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzvlh : IDisposable
{
	private bool z0cek;

	private static z0ZzZzlsh z0xek = null;

	private z0ZzZzlcj z0zek;

	private static z0ZzZzlsh z0lrk = null;

	private static readonly z0ZzZzlsh z0krk = z0mek();

	private GraphicsUnit z0jrk = GraphicsUnit.Document;

	private Dictionary<int, Dictionary<char, z0ZzZzxdh>> z0hrk;

	private readonly XTextDocument z0grk;

	private static z0ZzZzlsh z0frk = null;

	private DocumentOptions z0drk;

	private bool z0srk = true;

	internal bool z0ark;

	internal bool z0qrk;

	private MeasureMode z0wrk;

	private bool z0erk;

	private DocumentViewOptions z0rrk;

	public void z0eek(bool p0)
	{
		z0erk = p0;
	}

	public z0ZzZzvlh(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("doc");
		}
		z0grk = p0;
	}

	public bool z0eek()
	{
		return z0erk;
	}

	public static z0ZzZzlsh z0rek()
	{
		if (z0lrk == null)
		{
			z0lrk = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		}
		return z0lrk;
	}

	public virtual void z0eek(XTextElement p0, z0ZzZzvxj p1)
	{
		if (z0ark)
		{
			z0ark = false;
		}
		else if (p0 != null && p0.z0ptk() != null)
		{
			z0ZzZzpdh z0ZzZzpdh2 = p0.z0zw();
			z0ZzZzbdh p2 = new z0ZzZzbdh(z0ZzZzpdh2.z0rek(), z0ZzZzpdh2.z0tek(), p0.Width + p0.z0pt(), p0.Height);
			if (p0 is XTextSectionElement)
			{
				p2 = p1.z0gtk;
			}
			z0eek(p0, p1, p2);
		}
	}

	public virtual bool z0eek(XTextElement p0, z0ZzZzvxj p1, z0ZzZzbdh p2)
	{
		if (p1.z0nrk)
		{
			return false;
		}
		if (z0ark)
		{
			z0ark = false;
			return false;
		}
		z0ZzZzrzj z0ZzZzrzj2 = null;
		if (!p1.z0luk.z0duk && !(p0.z0ji() is XTextContentElement))
		{
			z0ZzZzrzj2 = p0.z0ji()?.z0cek(p0);
			if (z0ZzZzrzj2 == null)
			{
				z0ZzZzrzj2 = p1.z0luk;
			}
		}
		else
		{
			z0ZzZzrzj2 = p1.z0luk;
		}
		Color p3 = z0ZzZzrzj2.z0ark;
		if (p1.z0wyk && z0ZzZzrzj2.z0dtk)
		{
			p3 = z0ZzZzrzj2.z0crk;
		}
		if (p1.z0qrk && p3.A == 0)
		{
			if (z0ZzZzrzj2.z0vyk >= 0)
			{
				DocumentComment documentComment = p1.z0kuk.Comments.z0eek(z0ZzZzrzj2.z0vyk);
				if (documentComment != null && documentComment.z0oek())
				{
					p3 = ((p1.z0xyk == null) ? documentComment.z0frk() : p1.z0xyk.z0sb(documentComment));
				}
			}
			if (p1.z0kuk.z0wmk())
			{
				foreach (DocumentComment item in z0iek().z0enk())
				{
					if (item.z0oek())
					{
						bool flag = false;
						if (item.z0vrk() == p0 || item.z0rek(p0.z0jrk()))
						{
							p3 = ((p1.z0xyk == null) ? item.z0frk() : p1.z0xyk.z0sb(item));
							break;
						}
					}
				}
			}
		}
		if (p3.A != 0)
		{
			p2 = z0ZzZzbdh.z0tek(p2, p1.z0nek());
			if (!p2.z0bek())
			{
				if (p2.z0iek() < 8f && p1.z0lrk() != null && (double)(p2.z0pek() - p1.z0lrk().z0qrk()) < 0.5)
				{
					return false;
				}
				p1.z0gyk.z0rek(p3, p2);
				return true;
			}
		}
		if (p1.z0htk)
		{
			z0ZzZzqxj z0ZzZzqxj2 = null;
			z0ZzZzqxj2 = ((!(p0 is XTextFieldBorderElement)) ? p1.z0vtk.z0zo(p0, null) : p1.z0vtk.z0zo(p0, p1));
			p1.z0ryk = p0 as XTextCharElement;
			if (p1.z0ryk != null)
			{
				p1.z0qyk = z0ZzZzqxj2;
			}
			if (z0ZzZzqxj2 != null)
			{
				p1.z0xrk = z0ZzZzqxj2;
				if (p1.z0wyk && z0ZzZzqxj2.z0tek() != HighlightActiveStyle.AllTime)
				{
					return false;
				}
				z0ZzZzzlh z0kik = p0.z0kik;
				if (z0kik != null)
				{
					p2.z0rek(z0kik.z0xrk() + z0kik.z0atk());
					p2.z0yek(z0kik.z0wrk());
				}
				p2 = z0ZzZzbdh.z0tek(p2, p1.z0nek());
				if (!p2.z0bek() && z0ZzZzqxj2.z0yek().A != 0)
				{
					p1.z0gyk.z0eek(z0ZzZzqxj2.z0yek(), p2.z0oek(), p2.z0pek(), p2.z0uek(), p2.z0iek());
					return true;
				}
			}
		}
		return false;
	}

	public z0ZzZzlsh z0tek()
	{
		if (z0frk == null)
		{
			z0frk = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		}
		return z0frk;
	}

	public static void z0yek()
	{
	}

	public z0ZzZzlcj z0uek()
	{
		if (z0zek == null)
		{
			z0ZzZzlcj z0ZzZzlcj2 = new z0ZzZzlcj();
			z0zek = z0ZzZzlcj2;
		}
		return z0zek;
	}

	public void z0rek(bool p0)
	{
		z0srk = p0;
	}

	public XTextDocument z0iek()
	{
		return z0grk;
	}

	public z0ZzZzlsh z0oek()
	{
		return z0rek();
	}

	public z0ZzZzlsh z0pek()
	{
		return z0krk;
	}

	private static z0ZzZzlsh z0mek()
	{
		return new z0ZzZzlsh(z0ZzZzlsh.z0uek());
	}

	public z0ZzZzlsh z0nek()
	{
		if (z0xek == null)
		{
			z0xek = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		}
		return z0xek;
	}

	public virtual bool z0eek(XTextElement p0, z0ZzZzvxj p1, bool p2, bool p3)
	{
		if (p1.z0nrk)
		{
			return false;
		}
		XTextDocument xTextDocument = p0.z0jr();
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		if (z0ZzZzrzj2.z0jyk < 0 && z0ZzZzrzj2.z0jyk < 0 && p0 is XTextTableCellElement && p0.z0ji() != null)
		{
			z0ZzZzrzj2 = p0.z0ji().z0aek();
		}
		int num = -1;
		bool flag = false;
		if (z0ZzZzrzj2.z0jyk >= 0)
		{
			z0ZzZzyhh z0ZzZzyhh2 = xTextDocument.z0syk().z0tek(z0ZzZzrzj2.z0jyk);
			if (z0ZzZzyhh2 != null)
			{
				num = z0ZzZzyhh2.z0rek();
				flag = true;
			}
		}
		else if (z0ZzZzrzj2.z0nrk >= 0)
		{
			if (!p3 && z0ZzZzrzj2.z0nrk == 0)
			{
				return false;
			}
			z0ZzZzyhh z0ZzZzyhh3 = xTextDocument.z0syk().z0tek(z0ZzZzrzj2.z0nrk);
			if (z0ZzZzyhh3 != null)
			{
				num = z0ZzZzyhh3.z0rek();
				flag = false;
			}
		}
		if (num < 0)
		{
			return false;
		}
		z0ZzZzigh trackVisibleConfig = xTextDocument.z0hi().GetTrackVisibleConfig(num);
		if (trackVisibleConfig == null || !trackVisibleConfig.Enabled)
		{
			return false;
		}
		bool result = false;
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh.z0xek;
		z0ZzZzbdh2 = p1.z0gtk;
		z0ZzZzbdh2.z0tek(p0.Width + p0.z0pt());
		if (p0 is XTextParagraphFlagElement)
		{
			z0ZzZzbdh2.z0tek(p0.z0lu());
		}
		if (p2)
		{
			if (trackVisibleConfig.BackgroundColor.A != 0)
			{
				p1.z0gyk.z0rek(trackVisibleConfig.BackgroundColor, z0ZzZzbdh2);
				result = true;
			}
		}
		else if (flag)
		{
			if (trackVisibleConfig.DeleteLineNum > 0 && trackVisibleConfig.DeleteLineColor.A != 0)
			{
				using (z0ZzZzudh p4 = new z0ZzZzudh(trackVisibleConfig.DeleteLineColor))
				{
					for (int i = 0; i < trackVisibleConfig.DeleteLineNum; i++)
					{
						float num2 = z0ZzZzbdh2.z0pek() + (float)(i + 2) * z0ZzZzbdh2.z0iek() / (float)(trackVisibleConfig.DeleteLineNum + 3);
						p1.z0gyk.z0eek(p4, z0ZzZzbdh2.z0oek(), num2, z0ZzZzbdh2.z0mek(), num2);
					}
				}
				result = true;
			}
		}
		else if (trackVisibleConfig.UnderLineColorNum > 0 && trackVisibleConfig.UnderLineColor.A != 0)
		{
			float num3 = z0ZzZzrpk.z0eek(2f, GraphicsUnit.Pixel, GraphicsUnit.Document);
			TextUnderlineStyle textUnderlineStyle = trackVisibleConfig.UnderLineStyle;
			if (textUnderlineStyle == TextUnderlineStyle.WavyDouble)
			{
				textUnderlineStyle = TextUnderlineStyle.Wavy;
			}
			if (textUnderlineStyle == TextUnderlineStyle.Single)
			{
				using z0ZzZzudh p5 = new z0ZzZzudh(trackVisibleConfig.UnderLineColor);
				for (int j = 0; j < trackVisibleConfig.UnderLineColorNum; j++)
				{
					float num4 = z0ZzZzbdh2.z0nek() - num3 * (float)j;
					p1.z0gyk.z0eek(p5, z0ZzZzbdh2.z0oek(), num4, z0ZzZzbdh2.z0mek(), num4);
				}
			}
			else
			{
				for (int k = 0; k < trackVisibleConfig.UnderLineColorNum; k++)
				{
					float num5 = z0ZzZzbdh2.z0nek() - num3 * (float)k;
					z0ZzZzdpk.z0eek(p1.z0gyk, textUnderlineStyle, trackVisibleConfig.UnderLineColor, z0ZzZzbdh2.z0oek(), num5, z0ZzZzbdh2.z0mek(), num5, -z0ZzZzrpk.z0eek(3, GraphicsUnit.Pixel, p1.z0gyk.z0iek()));
				}
			}
			result = true;
		}
		return result;
	}

	public bool z0bek()
	{
		return z0srk;
	}

	public virtual bool z0eek(XTextTableCellElement p0, z0ZzZzvxj p1, z0ZzZzbdh p2, z0ZzZzqxj p3)
	{
		z0ZzZzrzj z0ZzZzrzj2 = p1.z0luk;
		if (!z0ZzZzrzj2.z0duk)
		{
			z0ZzZzrzj z0ZzZzrzj3 = p0.z0uik?.z0aek();
			if (z0ZzZzrzj3 != null && z0ZzZzrzj3.z0duk)
			{
				z0ZzZzrzj2 = z0ZzZzrzj3;
			}
		}
		Color p4 = z0ZzZzrzj2.z0ark;
		if (p1.z0wyk && z0ZzZzrzj2.z0dtk)
		{
			p4 = z0ZzZzrzj2.z0crk;
		}
		if (p1.z0qrk && p4.A == 0)
		{
			if (z0ZzZzrzj2.z0vyk >= 0)
			{
				DocumentComment documentComment = p1.z0kuk.Comments.z0eek(z0ZzZzrzj2.z0vyk);
				if (documentComment != null && documentComment.z0oek())
				{
					p4 = ((p1.z0xyk == null) ? documentComment.z0frk() : p1.z0xyk.z0sb(documentComment));
				}
			}
			if (p1.z0kuk.z0wmk())
			{
				foreach (DocumentComment item in z0iek().z0enk())
				{
					if (item.z0oek())
					{
						bool flag = false;
						if (item.z0vrk() == p0 || item.z0rek(((XTextElement)p0).z0jrk()))
						{
							p4 = ((p1.z0xyk == null) ? item.z0frk() : p1.z0xyk.z0sb(item));
							break;
						}
					}
				}
			}
		}
		if (p4.A != 0 && !p2.z0bek())
		{
			if (p2.z0iek() < 8f && p1.z0lrk() != null && (double)(p2.z0pek() - p1.z0lrk().z0qrk()) < 0.5)
			{
				return false;
			}
			p1.z0gyk.z0rek(p4, p2);
			return true;
		}
		if (p3 != null)
		{
			if (p1.z0wyk && p3.z0tek() != HighlightActiveStyle.AllTime)
			{
				return false;
			}
			p2 = z0ZzZzbdh.z0tek(p2, p1.z0nek());
			if (!p2.z0bek() && p3.z0yek().A != 0)
			{
				p1.z0gyk.z0eek(p3.z0yek(), p2.z0oek(), p2.z0pek(), p2.z0uek(), p2.z0iek());
				return true;
			}
		}
		return false;
	}

	public void Dispose()
	{
		z0zek = null;
		z0hrk = null;
	}

	internal void z0eek(z0ZzZzjpk p0)
	{
		XTextDocument xTextDocument = z0iek();
		if (z0drk == null)
		{
			z0drk = xTextDocument.z0vu();
		}
		if (z0rrk == null)
		{
			z0rrk = z0drk.ViewOptions;
		}
		z0wrk = xTextDocument.z0fnk();
		z0cek = z0rrk.OldWhitespaceWidth;
		z0jrk = p0.z0vek();
		foreach (DocumentContentStyle item in z0iek().z0gnk().Styles.z0xrk())
		{
			if (item.z0xek != null)
			{
				item.z0xek.z0luk = null;
			}
		}
		z0ZzZzlcj obj = z0uek();
		obj.z0rek(z0jrk);
		obj.z0rek(z0wrk);
		obj.z0rek(z0cek);
		z0qrk = z0drk.BehaviorOptions.SpecifyDebugMode;
	}

	public void z0eek(XTextElement p0, z0ZzZzvxj p1, Color p2, z0ZzZzbdh p3)
	{
		float num = p3.z0nek() - 3f;
		if (p1.z0byk == (z0ZzZzcxj)5)
		{
			num += 3.2f;
		}
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		Color color = p2;
		if (z0ZzZzrzj2.z0huk.A != 0)
		{
			color = z0ZzZzrzj2.z0huk;
		}
		if (z0ZzZzrzj2.z0ltk == TextUnderlineStyle.Single)
		{
			using (z0ZzZzudh p4 = new z0ZzZzudh(color))
			{
				p1.z0gyk.z0eek(p4, p3.z0oek(), num, p3.z0oek() + p0.Width + p0.z0pt(), num);
				return;
			}
		}
		num += 9.375f;
		z0ZzZzdpk.z0eek(p1.z0gyk, z0ZzZzrzj2.z0ltk, color, p3.z0oek(), num, p3.z0oek() + p0.Width + p0.z0pt(), num, -z0ZzZzrpk.z0eek(3, GraphicsUnit.Pixel, p1.z0gyk.z0iek()));
	}

	public void z0vek()
	{
		if (z0erk)
		{
			if (z0hrk == null)
			{
				z0hrk = new Dictionary<int, Dictionary<char, z0ZzZzxdh>>();
			}
			else
			{
				z0hrk.Clear();
			}
		}
		else
		{
			z0hrk = null;
		}
	}

	public virtual void z0rek(XTextElement p0, z0ZzZzvxj p1, z0ZzZzbdh p2)
	{
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		if (z0ZzZzrzj2.z0wrk)
		{
			z0ZzZzrzj2.z0eek(p1.z0gyk, p2);
		}
	}
}
