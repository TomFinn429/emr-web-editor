using System.Text;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

public class XTextParagraphListItemElement : XTextElement
{
	public class z0jmk
	{
		public Color z0rek = Color.Black;

		public string z0tek;

		public z0ZzZzxdh z0yek = new z0ZzZzxdh(0f, 0f);

		public z0ZzZzimk z0uek;

		public void z0eek(z0ZzZzjpk p0)
		{
			if (string.IsNullOrEmpty(z0tek))
			{
				z0yek = new z0ZzZzxdh(100f, 0f);
			}
			else
			{
				z0yek = z0ZzZzlcj.z0rek(p0.z0oek(), z0tek, z0uek, 100000, z0ZzZzlsh.z0uek());
				if (z0yek.z0rek() < 100f)
				{
					z0yek.z0eek(100f);
				}
				else
				{
					z0yek.z0eek(z0yek.z0rek() + 20f);
				}
			}
			z0yek.z0rek(z0ZzZzlcj.z0rek(p0.z0oek(), z0uek));
		}

		public z0jmk(XTextParagraphListItemElement p0, bool p1, bool p2)
		{
			z0ZzZzrzj z0ZzZzrzj = p0.z0eek()?.z0aek();
			if (z0ZzZzrzj == null)
			{
				z0tek = "?";
				z0uek = z0ZzZzimk.z0eek();
				return;
			}
			z0rek = p0.z0yek(z0ZzZzrzj.z0bek);
			if (z0ZzZzrzj.z0kuk)
			{
				z0tek = z0ZzZzrzj.z0vek;
				z0uek = new z0ZzZzimk("Wingdings", z0ZzZzrzj.z0wtk);
				if (p2)
				{
					char[] array = z0tek.ToCharArray();
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = (char)(array[i] & 0xFF);
					}
					z0tek = new string(array);
				}
				return;
			}
			string text = null;
			if (!z0ZzZzrzj.z0fyk)
			{
				text = ((!p1) ? z0ZzZzrzj.z0eek(p0.z0eek().z0zek()) : z0ZzZzrzj.z0eek(p0.z0eek().z0oek()));
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				XTextParagraphFlagElement xTextParagraphFlagElement = p0.z0eek();
				while (xTextParagraphFlagElement != null && !xTextParagraphFlagElement.z0mek())
				{
					if (z0ZzZzlmk.z0tek(xTextParagraphFlagElement.z0yek()))
					{
						if (p1)
						{
							stringBuilder.Insert(0, z0ZzZzrzj.z0eek(xTextParagraphFlagElement.z0oek()));
						}
						else
						{
							stringBuilder.Insert(0, z0ZzZzrzj.z0eek(xTextParagraphFlagElement.z0zek()));
						}
					}
					xTextParagraphFlagElement = xTextParagraphFlagElement.z0rek();
				}
				text = stringBuilder.ToString();
			}
			z0tek = text;
			z0uek = new z0ZzZzimk(z0ZzZzimk.DefaultFontName, z0ZzZzrzj.z0wtk);
		}

		public z0jmk(DocumentContentStyle p0, int p1)
		{
			z0rek = p0.Color;
			if (p0.IsBulletedList)
			{
				z0tek = p0.BulletedString;
				z0uek = new z0ZzZzimk("Wingdings", p0.FontSize);
			}
			else
			{
				string text = p0.z0eek(p1);
				z0tek = text;
				z0uek = new z0ZzZzimk(z0ZzZzimk.DefaultFontName, p0.FontSize);
			}
		}
	}

	private static z0ZzZzlsh z0rek;

	public override string Text
	{
		get
		{
			z0ZzZzrzj z0ZzZzrzj = z0eek().z0aek();
			if (z0ZzZzrzj.z0kuk)
			{
				return z0ZzZzrzj.z0brk switch
				{
					ParagraphListStyle.BulletedList => "●", 
					ParagraphListStyle.BulletedListBlock => "■", 
					ParagraphListStyle.BulletedListCheck => "√", 
					ParagraphListStyle.BulletedListDiamond => "◆", 
					ParagraphListStyle.BulletedListHollowStar => "◇", 
					ParagraphListStyle.BulletedListRightArrow => "＞", 
					_ => "●", 
				};
			}
			if (z0ZzZzrzj.z0ruk)
			{
				return new z0jmk(this, p1: false, p2: false).z0tek;
			}
			return string.Empty;
		}
		set
		{
		}
	}

	public override string z0ge()
	{
		return "LI:" + Text;
	}

	internal XTextParagraphFlagElement z0eek()
	{
		return z0ptk()?.z0grk();
	}

	internal void z0eek(z0ZzZzjpk p0)
	{
		z0jmk z0jmk = new z0jmk(this, p1: true, p2: false);
		z0jmk.z0eek(p0);
		Width = z0jmk.z0yek.z0rek();
		Height = z0jmk.z0yek.z0tek();
	}

	public static z0ZzZzxdh z0eek(DocumentContentStyle p0, z0ZzZzjpk p1, int p2)
	{
		z0jmk z0jmk = new z0jmk(p0, p2);
		z0jmk.z0eek(p1);
		return z0jmk.z0yek;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0eek(p0.z0gyk);
	}

	internal XTextParagraphListItemElement()
	{
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (z0rek == null)
		{
			z0rek = new z0ZzZzlsh();
			z0rek.z0rek(StringAlignment.Near);
			z0rek.z0eek(StringAlignment.Far);
			z0rek.z0eek((z0ZzZzksh)4096);
		}
		z0jmk z0jmk = new z0jmk(this, p1: false, p0.z0gyk.z0krk() && !p0.z0gyk.z0cek());
		if (!string.IsNullOrEmpty(z0jmk.z0tek))
		{
			z0ZzZzbdh p1 = p0.z0drk();
			p1.z0rek(p1.z0yek() + p0.z0yyk.z0uek().z0tek());
			p1.z0eek(p1.z0tek() + 3f);
			if (p0.z0gyk.z0krk())
			{
				p0.z0gyk.z0eek(z0jmk.z0tek, z0jmk.z0uek, z0jmk.z0rek, p1, z0rek);
			}
			else
			{
				p0.z0gyk.z0eek(z0jmk.z0tek, z0jmk.z0uek, z0jmk.z0rek, p0.z0gtk.z0tek(), p0.z0gtk.z0yek() + z0aik * 0.5f + 3.125f);
			}
		}
	}
}
