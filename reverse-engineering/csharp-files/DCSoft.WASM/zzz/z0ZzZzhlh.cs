using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzhlh : z0ZzZzxzj
{
	protected z0ZzZzqlh z0iek;

	protected object z0oek;

	protected bool z0pek;

	protected object z0mek;

	protected XTextElement z0nek;

	public new z0ZzZzqlh z0eek()
	{
		return z0iek;
	}

	public z0ZzZzhlh()
	{
	}

	public new bool z0rek()
	{
		return z0pek;
	}

	public void z0eek(bool p0)
	{
		z0pek = p0;
	}

	public object z0tek()
	{
		return z0oek;
	}

	public virtual void z0rek(bool p0)
	{
		z0pek = false;
		switch (z0iek)
		{
		case (z0ZzZzqlh)6:
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)z0nek;
			if (p0)
			{
				xTextInputFieldElementBase.InnerValue = (string)z0yek();
			}
			else
			{
				xTextInputFieldElementBase.InnerValue = (string)z0tek();
			}
			z0pek = true;
			break;
		}
		case (z0ZzZzqlh)1:
		{
			z0ZzZzxdh z0ZzZzxdh2 = (z0ZzZzxdh)z0yek();
			z0ZzZzxdh z0ZzZzxdh3 = (z0ZzZzxdh)z0tek();
			if (z0ZzZzxdh2.z0rek() > 0f && z0ZzZzxdh2.z0tek() > 0f && z0ZzZzxdh3.z0rek() > 0f && z0ZzZzxdh3.z0tek() > 0f)
			{
				if (p0)
				{
					z0nek.z0vy(z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek(), p2: true, p3: false);
				}
				else
				{
					z0nek.z0vy(z0ZzZzxdh3.z0rek(), z0ZzZzxdh3.z0tek(), p2: true, p3: false);
				}
				z0nek.z0xi(p0: false);
				z0pek = true;
			}
			break;
		}
		case (z0ZzZzqlh)2:
		{
			z0ZzZzxdh editorSize = (z0ZzZzxdh)z0mek;
			z0ZzZzxdh z0ZzZzxdh4 = (z0ZzZzxdh)z0oek;
			if (editorSize.z0rek() > 0f && editorSize.z0tek() > 0f && z0ZzZzxdh4.z0rek() > 0f && z0ZzZzxdh4.z0tek() > 0f && !editorSize.Equals(z0ZzZzxdh4))
			{
				if (p0)
				{
					z0nek.EditorSize = editorSize;
				}
				else
				{
					z0nek.EditorSize = z0ZzZzxdh4;
				}
				z0nek.z0xi(p0: true);
				z0pek = true;
			}
			break;
		}
		case (z0ZzZzqlh)3:
		{
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0nek;
			float num5 = (float)z0mek;
			float num6 = (float)z0oek;
			if (num5 != num6 && xTextTableRowElement != null)
			{
				if (p0)
				{
					xTextTableRowElement.z0eek(num5, p1: false);
				}
				else
				{
					xTextTableRowElement.z0eek(num6, p1: false);
				}
			}
			break;
		}
		case (z0ZzZzqlh)4:
		{
			int num3 = (int)z0mek;
			int num4 = (int)z0oek;
			if (num3 != num4 && z0nek != null)
			{
				DocumentContentStyle documentContentStyle2 = z0nek.z0aek().z0yek();
				documentContentStyle2.z0eek(p0: true);
				if (p0)
				{
					documentContentStyle2.CreatorIndex = num3;
				}
				else
				{
					documentContentStyle2.CreatorIndex = num4;
				}
				z0nek.z0oek(z0nek.z0jr().z0gnk().GetStyleIndex(documentContentStyle2));
				z0nek.z0xi(p0: true);
				z0pek = true;
			}
			break;
		}
		case (z0ZzZzqlh)5:
		{
			int num = (int)z0mek;
			int num2 = (int)z0oek;
			if (num != num2 && z0nek != null)
			{
				DocumentContentStyle documentContentStyle = z0nek.z0aek().z0yek();
				documentContentStyle.z0eek(p0: true);
				if (p0)
				{
					documentContentStyle.DeleterIndex = num;
				}
				else
				{
					documentContentStyle.DeleterIndex = num2;
				}
				z0nek.z0oek(z0nek.z0jr().z0gnk().GetStyleIndex(documentContentStyle));
				z0nek.z0xi(p0: true);
				z0pek = true;
			}
			break;
		}
		}
		if (z0pek)
		{
			z0nek.z0rrk();
			base.z0eek().z0rek().Add(z0nek.z0hy());
			base.z0eek().z0rek().Add(z0nek.z0xt());
		}
	}

	public z0ZzZzhlh(z0ZzZzqlh p0, object p1, object p2, XTextElement p3)
	{
		z0iek = p0;
		z0mek = p1;
		z0oek = p2;
		z0nek = p3;
	}

	public void z0eek(object p0)
	{
		z0mek = p0;
	}

	public void z0eek(z0ZzZzqlh p0)
	{
		z0iek = p0;
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0rek(p0: true);
	}

	public new object z0yek()
	{
		return z0mek;
	}

	public XTextElement z0uek()
	{
		return z0nek;
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0rek(p0: false);
	}

	public void z0eek(XTextElement p0)
	{
		z0nek = p0;
	}

	public void z0rek(object p0)
	{
		z0oek = p0;
	}
}
