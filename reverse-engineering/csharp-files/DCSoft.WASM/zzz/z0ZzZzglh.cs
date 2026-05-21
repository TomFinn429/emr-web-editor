using System;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzglh : z0ZzZzxzj
{
	private new XTextElementList z0rek;

	private XTextElementList z0tek;

	private new readonly int z0yek;

	private XTextContainerElement z0uek;

	public override void z0yo(z0ZzZzpgh p0)
	{
		if (z0uek == null)
		{
			return;
		}
		z0uek.z0we();
		XTextContentElement xTextContentElement = z0uek.z0jy();
		if (z0tek != null && z0rek == null)
		{
			int p1 = xTextContentElement.z0trk().IndexOf(z0tek.z0grk());
			z0uek.z0be().z0oek(z0tek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0tek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					XTextElement xTextElement = z0eek(current);
					if (xTextElement != null && xTextElement.z0ptk() != null)
					{
						xTextElement.z0ptk().z0tek(p0: true);
					}
					current.z0yek((z0ZzZzzlh)null);
					if (z0uek.z0jr().z0htk() != null)
					{
						z0uek.z0jr().z0htk().z0qp(current);
					}
				}
			}
			((XTextElement)z0uek).z0rrk();
			z0eek().z0eek(xTextContentElement, p1);
		}
		else if (z0tek == null && z0rek != null)
		{
			if (z0yek < 0 || z0yek > z0uek.z0be().Count)
			{
				return;
			}
			z0uek.z0be().z0yek(z0yek, z0rek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current2 = z0bpk.Current;
					XTextElement xTextElement2 = z0eek(current2);
					if (xTextElement2 != null && xTextElement2.z0ptk() != null)
					{
						xTextElement2.z0ptk().z0tek(p0: true);
					}
					current2.z0yek((z0ZzZzzlh)null);
				}
			}
			((XTextElement)z0uek).z0rrk();
			z0eek(z0rek.z0grk(), z0rek.z0lrk());
		}
		else if (z0tek != null && z0rek != null)
		{
			int p2 = xTextContentElement.z0trk().IndexOf(z0tek.z0grk());
			z0uek.z0be().z0oek(z0tek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0tek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current3 = z0bpk.Current;
					XTextElement xTextElement3 = z0eek(current3);
					if (xTextElement3 != null && xTextElement3.z0ptk() != null)
					{
						xTextElement3.z0ptk().z0tek(p0: true);
					}
					current3.z0yek((z0ZzZzzlh)null);
					if (z0uek.z0jr().z0htk() != null)
					{
						z0uek.z0jr().z0htk().z0qp(current3);
					}
				}
			}
			z0eek().z0eek(xTextContentElement, p2);
			if (z0yek < 0 || z0yek > z0uek.z0be().Count)
			{
				return;
			}
			z0uek.z0be().z0yek(z0yek, z0rek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current4 = z0bpk.Current;
					if (current4.z0ptk() != null)
					{
						current4.z0ptk().z0tek(p0: true);
						current4.z0yek((z0ZzZzzlh)null);
					}
				}
			}
			((XTextElement)z0uek).z0rrk();
			xTextContentElement.z0bek(p0: true);
			z0eek(z0rek.z0grk(), z0rek.z0lrk());
		}
		if (!z0eek().z0yek_jiejie20260327142557().Contains(z0uek))
		{
			z0eek().z0yek_jiejie20260327142557().Add(z0uek);
		}
	}

	public z0ZzZzglh(XTextContainerElement p0, int p1, XTextElementList p2, XTextElementList p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("container");
		}
		if (p1 != 0 || p0.z0be().Count != 0)
		{
			if (p1 < 0)
			{
				throw new ArgumentOutOfRangeException("index<0");
			}
			int num = p0.z0be().Count - 1;
			if (p2 != null)
			{
				num += p2.Count;
			}
			if (p1 > num)
			{
				throw new ArgumentOutOfRangeException("index>" + num);
			}
		}
		z0uek = p0;
		z0yek = p1;
		if (p2 != null && p2.Count > 0)
		{
			z0tek = new XTextElementList();
			((zzz.z0ZzZzkuk<XTextElement>)z0tek).z0tek((zzz.z0ZzZzkuk<XTextElement>)p2);
		}
		if (p3 != null && p3.Count > 0)
		{
			z0rek = new XTextElementList();
			((zzz.z0ZzZzkuk<XTextElement>)z0rek).z0tek((zzz.z0ZzZzkuk<XTextElement>)p3);
		}
	}

	private void z0eek(XTextElement p0, XTextElement p1)
	{
		XTextContentElement xTextContentElement = z0uek.z0jy();
		XTextElementList xTextElementList = z0eek().z0rek();
		if (!xTextElementList.Contains(p0))
		{
			xTextElementList.Add(p0);
		}
		z0ZzZzzlh p2 = null;
		while (p0 != null)
		{
			if (xTextContentElement.z0trk().Contains(p0))
			{
				p2 = p0.z0ptk();
				if (!xTextElementList.Contains(p0))
				{
					xTextElementList.Add(p0);
				}
				break;
			}
			p0 = p0.z0ji();
		}
		if (!xTextElementList.Contains(p1))
		{
			xTextElementList.Add(p1);
		}
		z0ZzZzzlh p3 = null;
		while (p1 != null)
		{
			if (xTextContentElement.z0trk().Contains(p1))
			{
				p3 = p1.z0ptk();
				if (!xTextElementList.Contains(p1))
				{
					xTextElementList.Add(p1);
				}
				break;
			}
			p1 = p1.z0ji();
		}
		xTextContentElement.z0eek(p2, p3);
	}

	private XTextElement z0eek(XTextElement p0)
	{
		XTextContentElement xTextContentElement = z0uek.z0jy();
		for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextContentElement.z0trk().Contains(xTextElement))
			{
				return xTextElement;
			}
		}
		if (p0 is XTextSectionElement)
		{
			return p0;
		}
		return p0.z0ie();
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		if (z0uek == null)
		{
			return;
		}
		z0uek.z0we();
		XTextContentElement xTextContentElement = z0uek.z0jy();
		p0.z0rek()["ContentElement"] = xTextContentElement;
		if (z0tek != null && z0rek == null)
		{
			if (z0yek < 0 || z0yek > z0uek.z0be().Count)
			{
				return;
			}
			z0uek.z0be().z0yek(z0yek, z0tek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0tek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					XTextElement xTextElement = z0eek(current);
					if (xTextElement != null && xTextElement.z0ptk() != null)
					{
						xTextElement.z0ptk().z0tek(p0: true);
					}
					current.z0yek((z0ZzZzzlh)null);
					current.z0nu(z0uek);
				}
			}
			((XTextElement)z0uek).z0rrk();
			z0eek(z0tek.z0grk(), z0tek.z0lrk());
		}
		else if (z0tek == null && z0rek != null)
		{
			int num = xTextContentElement.z0trk().IndexOf(z0rek.z0grk());
			z0uek.z0be().z0oek(z0rek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current2 = z0bpk.Current;
					if (current2 is XTextCharElement)
					{
						num = Math.Min(num, current2.z0jrk());
						if (current2.z0ptk() != null)
						{
							current2.z0ptk().z0tek(p0: true);
							current2.z0yek((z0ZzZzzlh)null);
						}
					}
					else if (current2.z0hy() != null)
					{
						num = Math.Min(num, current2.z0hy().z0jrk());
						if (z0uek.z0jr().z0htk() != null)
						{
							z0uek.z0jr().z0htk().z0qp(current2);
						}
						XTextElement xTextElement2 = z0eek(current2.z0hy());
						XTextElement xTextElement3 = z0eek(current2.z0xt());
						xTextContentElement.z0eek(xTextElement2?.z0ptk(), xTextElement3?.z0ptk());
						if (current2.z0ptk() != null)
						{
							current2.z0ptk().z0tek(p0: true);
							current2.z0yek((z0ZzZzzlh)null);
						}
					}
				}
			}
			((XTextElement)z0uek).z0rrk();
			z0eek().z0eek(xTextContentElement, num);
		}
		else if (z0tek != null && z0rek != null)
		{
			int num2 = xTextContentElement.z0trk().IndexOf(z0rek.z0grk());
			z0uek.z0be().z0oek(z0rek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current3 = z0bpk.Current;
					if (current3 is XTextCharElement)
					{
						num2 = Math.Min(num2, current3.z0jrk());
						if (current3.z0ptk() != null)
						{
							current3.z0ptk().z0tek(p0: true);
							current3.z0yek((z0ZzZzzlh)null);
						}
					}
					else
					{
						if (current3.z0hy() == null)
						{
							continue;
						}
						num2 = Math.Min(num2, current3.z0hy().z0jrk());
						if (z0uek.z0jr().z0htk() != null)
						{
							z0uek.z0jr().z0htk().z0qp(current3);
						}
						XTextElement xTextElement4 = z0eek(current3.z0hy());
						XTextElement xTextElement5 = z0eek(current3.z0xt());
						if (xTextElement4 == xTextElement5)
						{
							if (xTextElement4.z0ptk() != null)
							{
								xTextElement4.z0ptk().z0tek(p0: true);
							}
						}
						else
						{
							xTextContentElement.z0eek(xTextElement4?.z0ptk(), xTextElement5?.z0ptk());
						}
						current3.z0yek((z0ZzZzzlh)null);
					}
				}
			}
			z0eek().z0eek(xTextContentElement, num2);
			if (z0yek < 0 || z0yek > z0uek.z0be().Count)
			{
				return;
			}
			z0uek.z0be().z0yek(z0yek, z0tek);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0tek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current4 = z0bpk.Current;
					if (current4.z0ptk() != null)
					{
						current4.z0ptk().z0tek(p0: true);
						current4.z0yek((z0ZzZzzlh)null);
					}
					current4.z0nu(z0uek);
				}
			}
			((XTextElement)z0uek).z0rrk();
			z0eek().z0rek().Add(z0eek(z0tek.z0grk()));
			z0eek().z0rek().Add(z0eek(z0tek.z0lrk()));
		}
		if (!z0eek().z0yek_jiejie20260327142557().Contains(z0uek))
		{
			z0eek().z0yek_jiejie20260327142557().Add(z0uek);
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		z0uek = null;
		if (z0tek != null)
		{
			z0tek.Clear();
			z0tek = null;
		}
		if (z0rek != null)
		{
			z0rek.Clear();
			z0rek = null;
		}
	}

	public override string z0uo()
	{
		if (z0tek != null && z0tek.Count > 0)
		{
			if (z0tek.Count == 1)
			{
				return string.Format(z0ZzZziok.z0bek(), z0tek[0].ToString());
			}
			return string.Format(z0ZzZziok.z0fuk(), z0tek.Count);
		}
		if (z0rek != null && z0rek.Count > 0)
		{
			if (z0rek.Count == 1)
			{
				return string.Format(z0ZzZziok.z0suk(), z0rek[0].ToString());
			}
			return string.Format(z0ZzZziok.z0ayk(), z0rek.Count);
		}
		return null;
	}
}
