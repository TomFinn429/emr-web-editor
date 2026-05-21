using System;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzlbj : z0ZzZzznj, IDisposable
{
	private bool z0rek;

	private bool z0tek;

	private z0ZzZzmnj z0yek;

	private XTextDocument z0uek;

	private bool z0iek;

	private z0ZzZzdbj z0oek;

	public z0ZzZzdbj EditControl => z0oek;

	public XTextDocument Document => z0uek;

	public void z0eek(bool p0)
	{
		z0iek = p0;
	}

	public void Dispose()
	{
		z0yek = null;
		z0uek = null;
		z0oek = null;
	}

	public bool z0mx()
	{
		return z0tek;
	}

	public void z0px()
	{
		z0yek = null;
	}

	public ElementValueEditResult z0ox(XTextElement p0, z0ZzZznnj p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("editor");
		}
		if (z0rek)
		{
			return ElementValueEditResult.None;
		}
		z0rek = true;
		try
		{
			EditControl.z0cok();
			WriterEditElementValueEventArgs e = new WriterEditElementValueEventArgs(EditControl, Document, p0, p1);
			EditControl.z0eek(e);
			if (e.Handled)
			{
				return e.Result;
			}
			z0ZzZzmnj z0ZzZzmnj2 = new z0ZzZzmnj();
			z0ZzZzmnj2.z0eek(Document);
			z0ZzZzmnj2.z0eek(p0);
			z0ZzZzmnj2.z0eek((string)null);
			z0ZzZzmnj2.z0eek(p1);
			z0yek = z0ZzZzmnj2;
			z0yek.z0eek(p1.z0lc(this, z0ZzZzmnj2));
			z0eek(p0: false);
			ElementValueEditResult result = p1.z0kc(this, z0ZzZzmnj2);
			z0yek = null;
			z0rek = false;
			if (z0eek())
			{
				z0eek(p0: false);
				Document.OnDocumentContentChanged();
			}
			return result;
		}
		finally
		{
			z0yek = null;
			z0rek = false;
		}
	}

	public void z0ix(bool p0)
	{
		z0tek = p0;
	}

	public bool z0ux()
	{
		return false;
	}

	public bool z0eek()
	{
		return z0iek;
	}

	public z0ZzZzmnj z0yx()
	{
		return z0yek;
	}

	public static XTextElement z0eek(XTextElement p0)
	{
		if (!(p0 is XTextParagraphFlagElement))
		{
			ContentLayoutDirectionStyle contentLayoutDirectionStyle = ContentLayoutDirectionStyle.LeftToRight;
			z0ZzZzzlh z0ZzZzzlh2 = p0.z0qek().z0frk().z0lrk();
			if (!(p0 is XTextInputFieldElement) || z0ZzZzzlh2 == null)
			{
				p0 = ((contentLayoutDirectionStyle != ContentLayoutDirectionStyle.RightToLeft) ? p0.z0ie() : p0.z0dek());
			}
			else
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0;
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzzlh2.z0urk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (current.z0ji() == xTextInputFieldElement)
					{
						p0 = current;
						break;
					}
				}
			}
		}
		return p0;
	}

	public void z0tx()
	{
	}

	public void z0rx()
	{
	}

	public void z0ex(z0ZzZzdbj p0, XTextDocument p1)
	{
		z0oek = p0;
		z0uek = p1;
	}

	public bool z0wx()
	{
		return z0rek;
	}
}
