using System;
using DCSoft.WASM;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzinj : z0ZzZzsbj
{
	private void z0eek(string p0, object p1)
	{
		z0uek.z0bj(p0, p1);
	}

	public override void z0xx(EventArgs p0)
	{
		if (z0uek.z0ypk().z0rrk())
		{
			using z0ZzZzjpk p1 = z0tek().z0ru();
			if (z0uek.z0ypk().z0drk().z0tb(p1, z0uek.z0ypk()))
			{
				z0uek.z0ypk().z0guk();
			}
		}
		z0eek("DocumentContentChanged", p0);
	}

	public override void z0cx(z0ZzZzrmj p0, z0ZzZzomj p1, Exception p2)
	{
		if (XTextDocument.z0wbk)
		{
			z0ZzZzqok.z0rek.z0dh(p0.z0tek + "$$" + p2.ToString());
		}
		CommandErrorEventArgs e = new CommandErrorEventArgs();
		e.WriterControl = z0uek;
		e.CommandName = p0.z0tek;
		e.CommmandParameter = p1.Parameter;
		e.Document = e.Document;
		e.Exception = p2;
		z0eek("CommandError", e);
		if (!e.Handled)
		{
			string text = p0.z0tek;
			if (p2 != null)
			{
				text = text + ":" + p2.Message;
			}
			z0rek().z0pek().z0ub(z0uek, text, p2.ToString());
		}
	}

	public override void z0vx(WriterLinkEventArgs p0)
	{
		if (p0.Reference != null && p0.Reference.StartsWith("#"))
		{
			string text = p0.Reference.Substring(1);
			if (text.StartsWith("DCTopic_"))
			{
				int num = -1;
				if (!int.TryParse(text.Substring("DCTopic_".Length), out num))
				{
					return;
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0tek().z0xyk().z0nek<XTextParagraphFlagElement>().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)z0bpk.Current;
					if (xTextParagraphFlagElement.z0krk() == num)
					{
						if (xTextParagraphFlagElement.z0iek() == null)
						{
							xTextParagraphFlagElement.z0sr();
						}
						else
						{
							xTextParagraphFlagElement.z0iek().z0sr();
						}
						z0uek.z0ypk().z0tek(ScrollToViewStyle.Middle);
						break;
					}
				}
				return;
			}
		}
		z0eek("EventLinkClick", p0);
	}

	public override void z0bx(FilterValueEventArgs p0)
	{
		if (!z0eek())
		{
			return;
		}
		XTextElementList xTextElementList = p0.Value as XTextElementList;
		z0ZzZzdbj z0ZzZzdbj2 = z0uek;
		if (WriterControlForWASM.z0oyk && p0.Source == InputValueSource.Clipboard && xTextElementList != null && xTextElementList.Count == 2 && xTextElementList[0] is XTextTableElement && xTextElementList[1] is XTextParagraphFlagElement && z0ZzZzdbj2 != null && (z0ZzZzdbj2.z0yok() != null || (z0ZzZzdbj2.z0kok() != null && z0ZzZzdbj2.z0kok().z0irk() != null && z0ZzZzdbj2.z0kok().z0irk().Count > 0)))
		{
			z0ZzZzcoj.z0tek(z0ZzZzdbj2, p0);
			p0.Cancel = true;
			return;
		}
		z0eek("FilterValue", p0);
		if (!p0.Cancel)
		{
			z0ZzZzxkh z0ZzZzxkh2 = (z0ZzZzxkh)z0rek().z0tek().z0eek(typeof(z0ZzZzxkh));
			if (z0ZzZzxkh2 != null)
			{
				z0ZzZzxkh2(z0uek, p0);
				_ = p0.Cancel;
			}
		}
	}
}
