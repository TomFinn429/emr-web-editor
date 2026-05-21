using System;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZznmj : z0ZzZzbmj
{
	private z0ZzZztmj z0eek()
	{
		return z0eek_jiejie20260327142557().CommandContainer;
	}

	private object z0eek(z0ZzZzrmj p0, object p1, EventArgs p2, bool p3, object p4, bool p5)
	{
		XTextDocument xTextDocument = z0tek();
		z0ZzZzdbj z0ZzZzdbj2 = z0rek();
		z0ZzZzomj z0ZzZzomj2 = new z0ZzZzomj(z0ZzZzdbj2, xTextDocument, (z0ZzZzmmj)2, z0eek_jiejie20260327142557());
		if (z0ZzZzdbj2 != null)
		{
			z0ZzZzomj2.Host = z0ZzZzdbj2.z0pek();
		}
		else
		{
			z0ZzZzomj2.Host = z0ZzZzlfh.z0iek();
		}
		z0ZzZzomj2.RaiseFromUI = p5;
		z0ZzZzomj2.Name = p0.z0tek;
		z0ZzZzomj2.UIElement = p1;
		z0ZzZzomj2.UIEventArgs = p2;
		z0ZzZzomj2.ShowUI = p3;
		z0ZzZzomj2.Parameter = p4;
		z0ZzZzomj2.RaiseFromUI = p5;
		z0ZzZzomj2.Mode = (z0ZzZzmmj)2;
		xTextDocument?.z0bik();
		p0.z0iz(z0ZzZzomj2);
		xTextDocument?.z0aok();
		if (z0ZzZzomj2.Enabled)
		{
			z0ZzZzomj2.Mode = (z0ZzZzmmj)5;
			z0ZzZzomj2.Cancel = false;
			if (z0ZzZzdbj2 == null)
			{
				try
				{
					xTextDocument?.z0bik();
					if (!z0ZzZzomj2.Cancel)
					{
						p0.z0iz(z0ZzZzomj2);
					}
				}
				finally
				{
					xTextDocument?.z0aok();
				}
			}
			else if (z0ZzZzdbj2.z0cuk().BehaviorOptions.HandleCommandException)
			{
				try
				{
					z0ZzZzdbj2.z0rek(z0ZzZzomj2);
					if (z0ZzZzomj2.Cancel)
					{
						return z0ZzZzomj2.Result;
					}
					if (!z0ZzZzomj2.Cancel)
					{
						p0.z0iz(z0ZzZzomj2);
					}
					z0ZzZzdbj2.z0eek(z0ZzZzomj2);
				}
				catch (Exception p6)
				{
					z0ZzZzdbj2.z0cj(p0, z0ZzZzomj2, p6);
				}
			}
			else
			{
				z0ZzZzdbj2.z0rek(z0ZzZzomj2);
				if (z0ZzZzomj2.Cancel)
				{
					return z0ZzZzomj2.Result;
				}
				if (!z0ZzZzomj2.Cancel)
				{
					p0.z0iz(z0ZzZzomj2);
				}
				z0ZzZzdbj2.z0eek(z0ZzZzomj2);
			}
			z0ZzZzdbj2?.z0yj();
			return z0ZzZzomj2.Result;
		}
		return z0ZzZzomj2.Result;
	}

	public override void z0uz()
	{
		z0tek()?.z0yok();
	}

	public override object z0yz(string p0, bool p1, object p2)
	{
		z0ZzZzrmj z0ZzZzrmj2 = z0eek().z0eek(p0);
		if (z0ZzZzrmj2 == null && z0rek() != null)
		{
			z0ZzZzrmj2 = z0rek().z0ptk();
		}
		if (z0ZzZzrmj2 == null)
		{
			if (z0rek() != null)
			{
				z0ZzZzomj z0ZzZzomj2 = new z0ZzZzomj(z0rek(), z0tek(), (z0ZzZzmmj)5, z0eek_jiejie20260327142557());
				z0ZzZzomj2.Name = p0;
				z0ZzZzrmj z0ZzZzrmj3 = new z0ZzZzumj();
				z0ZzZzrmj3.z0tek = p0;
				if (string.IsNullOrEmpty(p0))
				{
					z0rek().z0cj(z0ZzZzrmj3, z0ZzZzomj2, new ArgumentNullException("commandName"));
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (z0ZzZzrmj item in z0eek().z0tek())
					{
						if (p0.Contains(item.z0tek, StringComparison.CurrentCultureIgnoreCase) || item.z0tek.Contains(p0, StringComparison.CurrentCultureIgnoreCase))
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							stringBuilder.Append(item.z0tek);
						}
					}
					string text = string.Format(z0ZzZziok.z0utk(), p0, stringBuilder.ToString());
					z0rek().z0cj(z0ZzZzrmj3, z0ZzZzomj2, new ArgumentException(text));
				}
			}
		}
		else if (z0ZzZzrmj2.z0uek)
		{
			return z0eek(z0ZzZzrmj2, null, null, p1, p2, p5: false);
		}
		return null;
	}

	private z0ZzZzdbj z0rek()
	{
		return z0eek_jiejie20260327142557().EditControl;
	}

	public override object z0tz(string p0, bool p1, object p2, bool p3)
	{
		z0ZzZzrmj z0ZzZzrmj2 = z0eek().z0eek(p0);
		if (z0ZzZzrmj2 == null && z0rek() != null)
		{
			z0ZzZzrmj2 = z0rek().z0ptk();
		}
		if (z0ZzZzrmj2 != null)
		{
			return z0eek(z0ZzZzrmj2, null, null, p1, p2, p3);
		}
		return null;
	}

	public override bool z0rz(string p0)
	{
		z0ZzZzrmj z0ZzZzrmj2 = z0eek().z0eek(p0);
		if (z0ZzZzrmj2 != null)
		{
			z0ZzZzomj z0ZzZzomj2 = new z0ZzZzomj(z0rek(), z0tek(), (z0ZzZzmmj)2, z0eek_jiejie20260327142557());
			z0ZzZzomj2.ShowUI = true;
			z0ZzZzrmj2.z0iz(z0ZzZzomj2);
			return z0ZzZzomj2.Checked;
		}
		return false;
	}

	public override bool z0ez(string p0)
	{
		z0ZzZzrmj z0ZzZzrmj2 = z0eek().z0eek(p0);
		if (z0ZzZzrmj2 != null)
		{
			z0ZzZzomj z0ZzZzomj2 = new z0ZzZzomj(z0rek(), z0tek(), (z0ZzZzmmj)2, z0eek_jiejie20260327142557());
			z0ZzZzomj2.ShowUI = true;
			z0ZzZzrmj2.z0iz(z0ZzZzomj2);
			return z0ZzZzomj2.Enabled;
		}
		return false;
	}

	private XTextDocument z0tek()
	{
		return z0eek_jiejie20260327142557().Document;
	}

	public override bool z0wz(string p0)
	{
		return z0eek().z0rek(p0) != null;
	}
}
